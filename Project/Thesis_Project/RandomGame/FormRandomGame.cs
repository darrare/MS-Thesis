using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RandomGame
{
    public partial class FormRandomGame : Form
    {
        //This should be plenty of colors, will never want to try more than this
        List<Color> colors = new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple, Color.Aqua, Color.Pink, Color.Orange, Color.Gray};

        List<Graph> Graphs { get; set; } = new List<Graph>();

        Random rand = new Random();

        public FormRandomGame()
        {
            InitializeComponent();

            //Load the previous runs values into the fields
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/RandomGame/MostRecentRun.rd"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/RandomGame/MostRecentRun.rd"))
                    {
                        TxtBx_NumberOfNodes.Text = sr.ReadLine();
                        TxtBx_MaxEdgesPerNode.Text = sr.ReadLine();
                        TxtBx_MinEdgesPerNode.Text = sr.ReadLine();
                        TxtBx_RandomSeed.Text = sr.ReadLine();
                        TxtBx_NumberOfIterations.Text = sr.ReadLine();
                        TxtBx_NumberOfConstraintsPerEdge.Text = sr.ReadLine();
                        TxtBx_MaxNumberOfColorsAllowed.Text = sr.ReadLine();
                    }
                }
                catch { /*Just leave values at 0 if the above crashes (someone messed with the file or debugging issues, should fix after next run) */ }
            }
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            //When start, save these values
            string destination = AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/RandomGame";
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            using (StreamWriter sw = new StreamWriter(new FileStream(destination + "/MostRecentRun.rd", FileMode.Create)))
            {
                sw.WriteLine(TxtBx_NumberOfNodes.Text);
                sw.WriteLine(TxtBx_MaxEdgesPerNode.Text);
                sw.WriteLine(TxtBx_MinEdgesPerNode.Text);
                sw.WriteLine(TxtBx_RandomSeed.Text);
                sw.WriteLine(TxtBx_NumberOfIterations.Text);
                sw.WriteLine(TxtBx_NumberOfConstraintsPerEdge.Text);
                sw.WriteLine(TxtBx_MaxNumberOfColorsAllowed.Text);
            }


            Random rand = string.IsNullOrEmpty(TxtBx_RandomSeed.Text) ? new Random() : new Random(int.Parse(TxtBx_RandomSeed.Text));
            Graph gra = new Graph(int.Parse(TxtBx_NumberOfNodes.Text), int.Parse(TxtBx_MinEdgesPerNode.Text), int.Parse(TxtBx_MaxEdgesPerNode.Text), PictureBox_Graph.Width, PictureBox_Graph.Height, rand);
            Graphs = gra.ExhaustiveSolve(colors.Take(int.Parse(TxtBx_MaxNumberOfColorsAllowed.Text)).ToArray());

            //populate edges for debuggings sake
            Graphs.ForEach(t => t.GetAllEdges());

            Label_GraphsCount.Text = Graphs.Count.ToString();
            DrawGraph(Graphs[0]);
            currentDrawIndex = 0;

            //Now that the graphs are generated, apply edge constraints to them
            //Create the edge constraints
            Tuple<string, List<Func<Graph, int, bool>>>[] constraints = new Tuple<string, List<Func<Graph, int, bool>>>[Graphs[0].GetAllEdges().Count];
            List<Color> possibleColors = colors.Take(int.Parse(TxtBx_MaxNumberOfColorsAllowed.Text)).ToList();
            List<string> textBuilderForPrinting = new List<string>();

            for (int i = 0; i < Graphs[0].GetAllEdges().Count; i++)
            {
                int selection = rand.Next(1, 5); //1-4 corresponding to the constraint methods
                switch (selection)
                {
                    case 1:
                        constraints[i] = new Tuple<string, List<Func<Graph, int, bool>>>("", new List<Func<Graph, int, bool>>() { (g, edge) => Constraint_MustBeDifferentColor(g, edge) });
                        textBuilderForPrinting.Add($"Edge {i} constraint: Constraint_MustBeDifferentColor");
                        break;                                                                                         
                    case 2:                                                                                            
                        constraints[i] = new Tuple<string, List<Func<Graph, int, bool>>>("", new List<Func<Graph, int, bool>>() { (g, edge) => Constraint_MustBeSameColor(g, edge) });
                        textBuilderForPrinting.Add($"Edge {i} constraint: Constraint_MustBeSameColor");
                        break;
                    case 3:
                        StringBuilder sb = new StringBuilder();
                        List<Func<Graph, int, bool>> mustBeOneOfEachCons = new List<Func<Graph, int, bool>>();
                        for (int j = 0; j < rand.Next(2, 4); j++) //rand 2 or 3
                        {
                            Color a = possibleColors[rand.Next(0, possibleColors.Count)];
                            Color b = possibleColors[rand.Next(0, possibleColors.Count)];
                            mustBeOneOfEachCons.Add((g, edge) => Constraint_MustBeOneOfEach(g, edge, a, b));
                            sb.Append($"Constraint_MustBeOneOfEach({a.ToString()}, {b.ToString()}) - ");
                        }
                        constraints[i] = new Tuple<string, List<Func<Graph, int, bool>>>("OR", mustBeOneOfEachCons);
                        textBuilderForPrinting.Add($"Edge {i} constraint: {sb.ToString()}");
                        break;
                    case 4:
                        StringBuilder sb2 = new StringBuilder();
                        List<Func<Graph, int, bool>> mustNotBeOneOfEachCons = new List<Func<Graph, int, bool>>();
                        for (int j = 0; j < rand.Next(2, 4); j++) //rand 2 or 3
                        {
                            Color a = possibleColors[rand.Next(0, possibleColors.Count)];
                            Color b = possibleColors[rand.Next(0, possibleColors.Count)];
                            mustNotBeOneOfEachCons.Add((g, edge) => Constraint_MustNotBeOneOfEach(g, edge, a, b));
                            sb2.Append($"Constraint_MustNotBeOneOfEach({a.ToString()}, {b.ToString()}) - ");
                        }
                        constraints[i] = new Tuple<string, List<Func<Graph, int, bool>>>("AND", mustNotBeOneOfEachCons);
                        textBuilderForPrinting.Add($"Edge {i} constraint: {sb2.ToString()}");
                        break;
                }
            }

            TxtBx_EdgeConstraints.Lines = textBuilderForPrinting.ToArray();
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();
            //Now all the edges have randomized constraints on them, so run the constraints against every single graph to find the interesting values
            foreach (var graph in Graphs)
            {
                int passCount = 0;
                int failCount = 0;
                for (int i = 0; i < graph.GetAllEdges().Count; i++) //GetAllEdges optimized to only be expensive once.
                {
                    if (constraints[i].Item1 == "")
                    {
                        if (constraints[i].Item2[0](graph, i))
                            passCount++;
                        else
                            failCount++;
                    }
                    else if (constraints[i].Item1 == "OR")
                    {
                        if (constraints[i].Item2.Any(t => t(graph, i)))
                            passCount++;
                        else
                            failCount++;
                    }
                    else if (constraints[i].Item1 == "AND")
                    {
                        if (constraints[i].Item2.All(t => t(graph, i)))
                            passCount++;
                        else
                            failCount++;
                    }
                }
                results.Add(new Tuple<int, int>(passCount, failCount));
            }

            listViewSatisfiabilityResults.Items.Clear();

            //We have our results from the constraints on the edges, now time to show some results to the user
            for(int i = 0; i < results.Count; i++)
            {
                double satisfiability = ((double)results[i].Item1 / ((double)results[i].Item1 + (double)results[i].Item2));
                if (satisfiability >= .8)
                {

                    listViewSatisfiabilityResults.Items.Add(new ListViewItem(new string[] { i.ToString(), satisfiability.ToString() }));
                }
            }

            FormResults fResults = new FormResults();
            fResults.Show();
            fResults.Initialize(results);

            //Might want to do something with later
            //double highestValue = results.Max(t => t.Item1 / (t.Item1 + t.Item2));
        }

        //1
        public bool Constraint_MustBeDifferentColor(Graph g, int edge)
        {
            return g.GetAllEdges()[edge].Nodes[0].Color != g.GetAllEdges()[edge].Nodes[1].Color;
        }

        //2
        public bool Constraint_MustBeSameColor(Graph g, int edge)
        {
            return g.GetAllEdges()[edge].Nodes[0].Color == g.GetAllEdges()[edge].Nodes[1].Color;
        }

        //3
        public bool Constraint_MustBeOneOfEach(Graph g, int edge, Color a, Color b)
        {
            return g.GetAllEdges()[edge].Nodes[0].Color == a && g.GetAllEdges()[edge].Nodes[1].Color == b
                || g.GetAllEdges()[edge].Nodes[0].Color == b && g.GetAllEdges()[edge].Nodes[1].Color == a;
        }

        //4
        public bool Constraint_MustNotBeOneOfEach(Graph g, int edge, Color a, Color b)
        {
            return !Constraint_MustBeOneOfEach(g, edge, a, b);
        }



        private void DrawGraph(Graph graph)
        {
            Dictionary<Color, Brush> brushColors = new Dictionary<Color, Brush>();
            brushColors.Add(Color.Black, new SolidBrush(Color.Black));
            foreach (Color c in colors)
            {
                brushColors.Add(c, new SolidBrush(c));
            }
            Pen pen = new Pen(Color.Black);
            Bitmap image = new Bitmap(PictureBox_Graph.Width, PictureBox_Graph.Height);
            Font font = new Font("Arial", 12);
            Graphics g = Graphics.FromImage(image);

            foreach (var edge in graph.Nodes.SelectMany(t => t.Neighbors).Distinct())
            {
                g.DrawString(graph.Edges.IndexOf(edge).ToString(), font, brushColors[Color.Black], new PointF(((edge.Nodes[0].X + edge.Nodes[1].X) / 2), ((edge.Nodes[0].Y + edge.Nodes[1].Y) / 2)));
                g.DrawLine(pen, edge.Nodes[0].X, edge.Nodes[0].Y, edge.Nodes[1].X, edge.Nodes[1].Y);
            }

            foreach (var node in graph.Nodes)
            {
                g.FillEllipse(brushColors[node.Color], node.X - 10, node.Y - 10, 20, 20); //TODO: Make the width and height scale based on image size and numnodes
            }

            PictureBox_Graph.Image = image;
        }

        private void Btn_DrawGraphAtIndex_Click(object sender, EventArgs e)
        {
            try
            {
                DrawGraph(Graphs[int.Parse(TxtBx_DrawNodeAtIndex.Text)]);
                currentDrawIndex = int.Parse(TxtBx_DrawNodeAtIndex.Text);
                TxtBx_DrawNodeAtIndex.Text = currentDrawIndex.ToString();
            }
            catch(Exception ex)
            {
                //Just don't do anything
            }
        }

        int currentDrawIndex = 0;
        private void Btn_DrawPrevious_Click(object sender, EventArgs e)
        {
            if (currentDrawIndex > 0)
            {
                DrawGraph(Graphs[--currentDrawIndex]);
                TxtBx_DrawNodeAtIndex.Text = currentDrawIndex.ToString();
            }
        }

        private void Btn_DrawNext_Click(object sender, EventArgs e)
        {
            if (currentDrawIndex <= Graphs.Count)
            {
                DrawGraph(Graphs[++currentDrawIndex]);
                TxtBx_DrawNodeAtIndex.Text = currentDrawIndex.ToString();
            }
        }
    }
}
