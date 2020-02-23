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

namespace MapColoring_Improved
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
                { TxtBx_TargetHighColorDegree, "Weight on the total number of neighbors on the node that are colored." },
                { TxtBx_TargetLowColorDegree, "Weight on the total number of neighbors on the node that are colored." },
                { TxtBx_TargetHighPossibleColors, "Weight on the nodes total colors" },
                { TxtBx_TargetLowPossibleColors, "Weight on the nodes total colors" }
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
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring_Improved/SolveGraphSettings.rd"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring_Improved/SolveGraphSettings.rd"))
                    {
                        TxtBx_TargetHighColorDegree.Text = sr.ReadLine();
                        TxtBx_TargetLowColorDegree.Text = sr.ReadLine();
                        TxtBx_TargetHighPossibleColors.Text = sr.ReadLine();
                        TxtBx_TargetLowPossibleColors.Text = sr.ReadLine();
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

            if (!double.TryParse(TxtBx_TargetHighColorDegree.Text, out resultD))
                errors += "Invalid value for TxtBx_TargetHighBlackDegree" + Environment.NewLine;
            if (!double.TryParse(TxtBx_TargetLowColorDegree.Text, out resultD))
                errors += "Invalid value for TxtBx_TargetLowBlackDegree" + Environment.NewLine;
            if (!double.TryParse(TxtBx_TargetHighPossibleColors.Text, out resultD))
                errors += "Invalid value for TxtBx_TargetHighPossibleColors" + Environment.NewLine;
            if (!double.TryParse(TxtBx_TargetLowPossibleColors.Text, out resultD))
                errors += "Invalid value for TxtBx_TargetLowPossibleColors" + Environment.NewLine;

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
            string destination = AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring_Improved";
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            using (StreamWriter sw = new StreamWriter(new FileStream(destination + "/SolveGraphSettings.rd", FileMode.Create)))
            {
                sw.WriteLine(TxtBx_TargetHighColorDegree.Text);
                sw.WriteLine(TxtBx_TargetLowColorDegree.Text);
                sw.WriteLine(TxtBx_TargetHighPossibleColors.Text);
            }

            double[] genes = new double[] 
            { 
                double.Parse(TxtBx_TargetHighColorDegree.Text), double.Parse(TxtBx_TargetLowColorDegree.Text),
                double.Parse(TxtBx_TargetHighPossibleColors.Text), double.Parse(TxtBx_TargetLowPossibleColors.Text)
            };

            Graph graph = new Graph(originalGraph);
            TxtBx_TimeToSolve.Text = (graph.Solve(genes) / 1000f).ToString("#.###") + " seconds";
            DrawGraph(graph.validGraph);
        }
    }
}
