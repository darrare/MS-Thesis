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

namespace MapColoring
{
    public partial class FormSolveGraph : Form
    {
        Random rand = new Random();

        Dictionary<Control, string> toolTips;

        Graph originalGraph;

        public FormSolveGraph()
        {
            InitializeComponent();

            //Set tooltip strings for all input fields
            toolTips = new Dictionary<Control, string>()
            {
                { TxtBx_NumColors, "Weight on the total number of colors."  },
                { TxtBx_NumUncolored, $"Weight on the number of uncolored nodes in the graph.{Environment.NewLine}Essentially the graphs level of completeness." },
                { TxtBx_NumEdgesNeighboringBlack, "Weight on the total number of edges in the graph that are neighboring a black node." },
                { TxtBx_NumUncoloredNeighbors, "Weight on each node for the number of uncolored neighbors it has." },
                { TxtBx_NodeDegree, "Weight on the nodes degree." }
            };

            //Add mouseover and leave events for each control that has a tooltip associated with it
            foreach (KeyValuePair<Control, string> tip in toolTips)
            {
                ToolTip tt = new ToolTip();
                tip.Key.MouseEnter += (s, o) =>
                {
                    tt = new ToolTip();
                    tt.InitialDelay = 300;
                    tt.Show(tip.Value, tip.Key, 0);
                };

                tip.Key.MouseLeave += (s, o) =>
                {
                    tt.Dispose();
                };

            }

            //Load the previous runs values into the fields
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring/SolveGraphSettings.rd"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring/SolveGraphSettings.rd"))
                    {
                        TxtBx_NumColors.Text = sr.ReadLine();
                        TxtBx_NumUncolored.Text = sr.ReadLine();
                        TxtBx_NumEdgesNeighboringBlack.Text = sr.ReadLine();
                        TxtBx_NumUncoloredNeighbors.Text = sr.ReadLine();
                        TxtBx_NodeDegree.Text = sr.ReadLine();
                    }
                }
                catch { /*Just leave values at 0 if the above crashes (someone messed with the file or debugging issues, should fix after next run) */ }
            }
        }

        /// <summary>
        /// Logic of the algorithm
        /// </summary>
        public void GenerateGraph(Graph graph)
        {
            originalGraph = graph;
            DrawGraph(graph);
        }

        private void DrawGraph(Graph graph)
        {
            Dictionary<Color, Brush> brushColors = new Dictionary<Color, Brush>();
            brushColors.Add(Color.Black, new SolidBrush(Color.Black));
            foreach (Color c in Graph.colorOrder)
            {
                brushColors.Add(c, new SolidBrush(c));
            }
            Pen pen = new Pen(Color.Black);
            Bitmap image = new Bitmap(PictureBox_Graph.Width, PictureBox_Graph.Height);
            Graphics g = Graphics.FromImage(image);

            foreach (var edge in graph.Nodes.SelectMany(t => t.Neighbors).Distinct())
            {
                g.DrawLine(pen, edge.Nodes[0].X, edge.Nodes[0].Y, edge.Nodes[1].X, edge.Nodes[1].Y);
            }

            foreach (var node in graph.Nodes)
            {
                g.FillEllipse(brushColors[node.Color], node.X - 10, node.Y - 10, 20, 20); //TODO: Make the width and height scale based on image size and numnodes
            }

            PictureBox_Graph.Image = image;
        }

        private bool IsParameterError()
        {
            string errors = "";
            double resultD;

            //map coloring default parameters
            if (!double.TryParse(TxtBx_NumColors.Text, out resultD))
                errors += "Invalid value for num colors" + Environment.NewLine;
            if (!double.TryParse(TxtBx_NumUncolored.Text, out resultD))
                errors += "Invalid value for num uncolored" + Environment.NewLine;
            if (!double.TryParse(TxtBx_NumEdgesNeighboringBlack.Text, out resultD))
                errors += "Invalid value for num edges neighboring black" + Environment.NewLine;
            if (!double.TryParse(TxtBx_NumUncoloredNeighbors.Text, out resultD))
                errors += "Invalid value for num uncolored neighbors" + Environment.NewLine;
            if (!double.TryParse(TxtBx_NodeDegree.Text, out resultD))
                errors += "Invalid value for node degree" + Environment.NewLine;

            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors);
                return true;
            }
            return false;
        }

        private void Btn_SolveGraph_Click(object sender, EventArgs e)
        {
            if (IsParameterError())
                return;

            //Save our current parameters to be spawned next time we run the program
            string destination = AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring";
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            using (StreamWriter sw = new StreamWriter(new FileStream(destination + "/SolveGraphSettings.rd", FileMode.Create)))
            {
                sw.WriteLine(TxtBx_NumColors.Text);
                sw.WriteLine(TxtBx_NumUncolored.Text);
                sw.WriteLine(TxtBx_NumEdgesNeighboringBlack.Text);
                sw.WriteLine(TxtBx_NumUncoloredNeighbors.Text);
                sw.WriteLine(TxtBx_NodeDegree.Text);
            }

            double getTotalColorCountWeight = double.Parse(TxtBx_NumColors.Text);
            double getUncoloredCountWeight = double.Parse(TxtBx_NumUncolored.Text);
            double getNumEdgesNeighboringBlackWeight = double.Parse(TxtBx_NumEdgesNeighboringBlack.Text);
            double getUncoloredNeighborCountWeight = double.Parse(TxtBx_NumUncoloredNeighbors.Text);
            double getNodeDegreeWeight = double.Parse(TxtBx_NodeDegree.Text);

            object[] genes = new object[] { getTotalColorCountWeight, getUncoloredCountWeight, getNumEdgesNeighboringBlackWeight, getUncoloredNeighborCountWeight, getNodeDegreeWeight };

            Graph graph = new Graph(originalGraph);
            TxtBx_TimeToSolve.Text = (graph.Solve(genes) / 1000f).ToString("#.###") + " seconds";
            DrawGraph(graph.validGraph);
        }
    }
}
