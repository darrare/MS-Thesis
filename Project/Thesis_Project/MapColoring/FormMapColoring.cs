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
    public partial class FormMapColoring : Form
    {
        Random rand = new Random();

        Dictionary<Control, string> toolTips;

        Graph graph;

        public FormMapColoring()
        {
            InitializeComponent();

            //Set tooltip strings for all input fields
            toolTips = new Dictionary<Control, string>()
            {
                { TxtBx_NumCountries, "The number of countries to generate" },
                { TxtBx_EdgeDensity, "The percentage of connections between countries. "+ Environment.NewLine+".5 = each country is neighbors to roughly 1/2 all countries. "+ Environment.NewLine+"1 = every country is connected to every other country."+ Environment.NewLine+"This is overruled by min and max edge requirements."  },
                { TxtBx_MaxEdgesPerCountry, "Maximum amount of edges a country can have." },
                { TxtBx_MinEdgesPerCountry, "Minimum amount of edges a country can have. Must be less than Num Countries" },
                { TxtBx_PopulationSize , "Must be in the form of Size = X + Y where x = y(y-1)/2) where y is the number of chromosomes kept each iteration to breed." + Environment.NewLine + "Some valid values: 36, 136, 528, 2080" },
                { TxtBx_Convergence, "The percentage of convergence at which we stop the algorithm because all chromosomes are within this range of each other." },
                { TxtBx_DefaultGeneValue, "All genes will start at this value, and will be mutated once prior to calculating fitness." },
                { TxtBx_MaxIterations, "Maximum amount of times the algorithm will reproduce." },
                { TxtBx_PercentChromosomesMutated, "% chance a chromosome will be selected to mutate." + Environment.NewLine + "Some chromosomes are left the same if not 100%" },
                { TxtBx_PercentGenesMutated, "After a chromosome has been selected to mutate, this is the percentage chance for each gene to actually be mutated." },
                { TxtBx_PercentMutationDeviation, "How much off of the value can we mutate." + Environment.NewLine + ".5 means +- 50%, IE: 90 -> 45-135 and 180 -> 90-270" },
                { TxtBx_Seed, "Random seed used to generate same results every time you run the algorithm." },
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
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring/MostRecentRun.rd"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring/MostRecentRun.rd"))
                    {
                        TxtBx_NumCountries.Text = sr.ReadLine();
                        TxtBx_EdgeDensity.Text = sr.ReadLine();
                        TxtBx_MaxEdgesPerCountry.Text = sr.ReadLine();
                        TxtBx_MinEdgesPerCountry.Text = sr.ReadLine();
                        TxtBx_Seed.Text = sr.ReadLine();
                        TxtBx_PopulationSize.Text = sr.ReadLine();
                        TxtBx_Convergence.Text = sr.ReadLine();
                        TxtBx_DefaultGeneValue.Text = sr.ReadLine();
                        TxtBx_MaxIterations.Text = sr.ReadLine();
                        TxtBx_PercentChromosomesMutated.Text = sr.ReadLine();
                        TxtBx_PercentGenesMutated.Text = sr.ReadLine();
                        TxtBx_PercentMutationDeviation.Text = sr.ReadLine();
                    }
                }
                catch { /*Just leave values at 0 if the above crashes (someone messed with the file or debugging issues, should fix after next run) */ }
            }

            Btn_GenerateGraph_Click(null, null);
        }

        /// <summary>
        /// Logic of the algorithm
        /// </summary>
        private void GenerateGraph()
        {
            graph = new Graph(int.Parse(TxtBx_NumCountries.Text), double.Parse(TxtBx_EdgeDensity.Text),
                int.Parse(TxtBx_MinEdgesPerCountry.Text), int.Parse(TxtBx_MaxEdgesPerCountry.Text),
                PictureBox_Graph.Width, PictureBox_Graph.Height, rand);
            DrawGraph(graph);
            if (!TestGraph())
            {
                throw new Exception("Graph did not pass test. Duplicate edges");
            }
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

        /// <summary>
        /// Test the graph to make sure it doesn't have duplicate edges
        /// </summary>
        private bool TestGraph()
        {
            this.Update();
            List<Edge> edges = graph.GetAllEdges();

            if (edges.Distinct().Count() != edges.Count())
                return false;

            return true;
        }

        /// <summary>
        /// The randomize parameters button has been clicked.
        /// Randomize the values of the parameter fields
        /// </summary>
        private void Btn_RandomizeParameters_Click(object sender, EventArgs e)
        {
            TxtBx_NumCountries.Text = rand.Next(10, 30).ToString();

            TxtBx_EdgeDensity.Text = rand.NextDouble().ToString("#.###");
            TxtBx_MaxEdgesPerCountry.Text = rand.Next(6, 10).ToString();
            TxtBx_MinEdgesPerCountry.Text = rand.Next(1, 6).ToString();

            int y = rand.Next(10, 50);
            TxtBx_PopulationSize.Text = (y + (y * (y - 1) / 2)).ToString();
            TxtBx_Convergence.Text = rand.NextDouble().ToString("#.###");
            TxtBx_DefaultGeneValue.Text = (rand.NextDouble() * 10).ToString("#.###");
            TxtBx_MaxIterations.Text = 1000.ToString();
            TxtBx_PercentChromosomesMutated.Text = rand.NextDouble().ToString("#.###");
            TxtBx_PercentGenesMutated.Text = rand.NextDouble().ToString("#.###");
            TxtBx_PercentMutationDeviation.Text = rand.NextDouble().ToString("#.###");
        }

        private void Btn_GenerateGraph_Click(object sender, EventArgs e)
        {
            if (IsParameterError())
                return;

            //Save our current parameters to be spawned next time we run the program
            string destination = AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/MapColoring";
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            using (StreamWriter sw = new StreamWriter(new FileStream(destination + "/MostRecentRun.rd", FileMode.Create)))
            {
                sw.WriteLine(TxtBx_NumCountries.Text);
                sw.WriteLine(TxtBx_EdgeDensity.Text);
                sw.WriteLine(TxtBx_MaxEdgesPerCountry.Text);
                sw.WriteLine(TxtBx_MinEdgesPerCountry.Text);
                sw.WriteLine(TxtBx_Seed.Text);
                sw.WriteLine(TxtBx_PopulationSize.Text);
                sw.WriteLine(TxtBx_Convergence.Text);
                sw.WriteLine(TxtBx_DefaultGeneValue.Text);
                sw.WriteLine(TxtBx_MaxIterations.Text);
                sw.WriteLine(TxtBx_PercentChromosomesMutated.Text);
                sw.WriteLine(TxtBx_PercentGenesMutated.Text);
                sw.WriteLine(TxtBx_PercentMutationDeviation.Text);
            }

            GenerateGraph();
        }

        private bool IsParameterError()
        {
            string errors = "";
            double resultD;
            int resultI;

            //map coloring default parameters
            if (!int.TryParse(TxtBx_NumCountries.Text, out resultI))
                errors += "Invalid value for Num Countries" + Environment.NewLine;
            if (!double.TryParse(TxtBx_EdgeDensity.Text, out resultD) && 1 >= resultD && resultD >= 0)
                errors += "Invalid value for Edge Density (0-1)" + Environment.NewLine;
            if (!int.TryParse(TxtBx_MaxEdgesPerCountry.Text, out resultI))
                errors += "Invalid value for Max Edges Per Country" + Environment.NewLine;
            if (!int.TryParse(TxtBx_MaxEdgesPerCountry.Text, out resultI))
                errors += "Invalid value for Min Edges Per Country" + Environment.NewLine;

            //map coloring conflict parameters
            if (string.IsNullOrEmpty(errors))
            {
                if (int.Parse(TxtBx_NumCountries.Text) <= int.Parse(TxtBx_MinEdgesPerCountry.Text))
                    errors += "Min edges must be less than num countries" + Environment.NewLine;
                if (int.Parse(TxtBx_MaxEdgesPerCountry.Text) < int.Parse(TxtBx_MinEdgesPerCountry.Text))
                    errors += "Min edges cannot be greater than max edges" + Environment.NewLine;
            }
            else
            {
                errors += "Error within map generating parameters, cannot check parameter conflicts" + Environment.NewLine;
            }

            //genetic algorithm parameters
            if (!int.TryParse(TxtBx_PopulationSize.Text, out resultI) || !ValidatePopulationSize(int.Parse(TxtBx_PopulationSize.Text)))
                errors += "Invalid value for Population Size" + Environment.NewLine;
            if (!double.TryParse(TxtBx_Convergence.Text, out resultD))
                errors += "Invalid value for Convergence" + Environment.NewLine;
            if (!double.TryParse(TxtBx_DefaultGeneValue.Text, out resultD))
                errors += "Invalid value for Default Gene Value" + Environment.NewLine;
            if (!int.TryParse(TxtBx_MaxIterations.Text, out resultI) && !string.IsNullOrEmpty(TxtBx_MaxIterations.Text))
                errors += "Invalid value for Max Iterations" + Environment.NewLine;
            if (!double.TryParse(TxtBx_PercentChromosomesMutated.Text, out resultD))
                errors += "Invalid value for % Chromosomes Mutated" + Environment.NewLine;
            if (!double.TryParse(TxtBx_PercentGenesMutated.Text, out resultD))
                errors += "Invalid value for % Genes Mutated" + Environment.NewLine;
            if (!double.TryParse(TxtBx_PercentMutationDeviation.Text, out resultD))
                errors += "Invalid value for % Deviation Mutation" + Environment.NewLine;
            if (!int.TryParse(TxtBx_Seed.Text, out resultI) && !string.IsNullOrEmpty(TxtBx_Seed.Text))
                errors += "Invalid value for Seed" + Environment.NewLine;

            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifies that the population size follows the formula size = y + y(y-1)/2
        /// Uses the quadratic forumla to verify with a = -.5, b = -.5 and c = size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private bool ValidatePopulationSize(int size)
        {
            int y;
            if (!int.TryParse(((.5 - Math.Sqrt(.25 - (4 * -.5 * size))) / -1).ToString(), out y))
            {
                return false;
            }
            return (size == y + y * (y - 1) / 2);
        }

        private async void Btn_RunAlgorithm_Click(object sender, EventArgs e)
        {
            if (IsParameterError())
                return;

            Btn_RandomizeParameters.Enabled = false;
            Btn_GenerateGraph.Enabled = false;
            Btn_SolveGraph.Enabled = false;
            Btn_RunAlgorithm.Enabled = false;

            List<Tuple<int, double, double>> dataPoints = new List<Tuple<int, double, double>>();
            List<Tuple<int, List<double>>> selectedChromosomesFitness = new List<Tuple<int, List<double>>>();
            GeneticAlgorithm.GeneticAlgorithmClass.UpdateProgressBar = (percent, convergence, iteration, averageFitness, selectedFitness) =>
            {
                PB_MapColoring.Invoke((MethodInvoker)delegate ()
                {
                    PB_MapColoring.Value = percent;
                    LBL_Convergence.Text = convergence.ToString();
                    LBL_Iteration.Text = iteration.ToString();
                    dataPoints.Add(new Tuple<int, double, double>(iteration, convergence, averageFitness));
                    selectedChromosomesFitness.Add(selectedFitness);
                });
            };
            int logInterval = 1;
            List<GeneticAlgorithm.Chromosome> chromosomes = await Task.Factory.StartNew(() =>
            {
                return GeneticAlgorithm.GeneticAlgorithmClass.RunGeneticAlgorithm(
                   int.Parse(TxtBx_PopulationSize.Text),
                   double.Parse(TxtBx_Convergence.Text),
                   new object[] { double.Parse(TxtBx_DefaultGeneValue.Text), double.Parse(TxtBx_DefaultGeneValue.Text), double.Parse(TxtBx_DefaultGeneValue.Text), double.Parse(TxtBx_DefaultGeneValue.Text), double.Parse(TxtBx_DefaultGeneValue.Text) },
                   double.Parse(TxtBx_PercentChromosomesMutated.Text),
                   double.Parse(TxtBx_PercentGenesMutated.Text),
                   double.Parse(TxtBx_PercentMutationDeviation.Text),
                   graph.Solve,
                   int.Parse(TxtBx_MaxIterations.Text),
                   logInterval,
                   false);
            });


            Btn_RandomizeParameters.Enabled = true;
            Btn_GenerateGraph.Enabled = true;
            Btn_SolveGraph.Enabled = true;
            Btn_RunAlgorithm.Enabled = true;

            DrawGraph(graph.validGraph);

            GenerateResultsDataGridView(chromosomes);
            Common.FormResults form = new Common.FormResults();
            form.InitializeChart(dataPoints.Select(t => t.Item1).ToList(), dataPoints.Select(t => t.Item2).ToList(), dataPoints.Select(t => t.Item3).ToList(), selectedChromosomesFitness, logInterval);
            form.Show();
        }

        private void GenerateResultsDataGridView(List<GeneticAlgorithm.Chromosome> solutions)
        {
            DataTable table = new DataTable("Final Evolution");
            table.Columns.Add("id");
            table.Columns.Add("Duration");
            table.Columns.Add("Total Color Count Gene");
            table.Columns.Add("Colored Nodes Gene");
            table.Columns.Add("Num Edges Neighboring Black Gene");
            table.Columns.Add("Uncolored Neighbor Count Gene");
            table.Columns.Add("Node Degree Gene");

            List<List<double>> genes = new List<List<double>>();
            solutions.ForEach(t => genes.Add(t.Genes.Select(x => (double)x / (double)t.Genes.Max()).ToList()));
            

            table.Rows.Add(new object[] {0, "AVERAGE",
                genes.Average(t => (double)t[0]),
                genes.Average(t => (double)t[1]),
                genes.Average(t => (double)t[2]),
                genes.Average(t => (double)t[3]),
                genes.Average(t => (double)t[4])});

            for (int i = 0; i < solutions.Count; i++)
            {
                double[] normalizedGenes = solutions[i].Genes.Select(t => (double)t / (double)solutions[i].Genes.Max()).ToArray();
                table.Rows.Add(new object[] { i + 1,
                    solutions[i].FitnessScore,
                    normalizedGenes[0].ToString("#.###"),
                    normalizedGenes[1].ToString("#.###"),
                    normalizedGenes[2].ToString("#.###"),
                    normalizedGenes[3].ToString("#.###"),
                    normalizedGenes[4].ToString("#.###")
                });
            }

            DGV_Results.DataSource = table;
            for (int i = 0; i < DGV_Results.Columns.Count; i++)
            {
                DGV_Results.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
        }

        private void Btn_SolveGraph_Click(object sender, EventArgs e)
        {
            FormSolveGraph form = new FormSolveGraph();
            form.GenerateGraph(graph);
            form.Show();
        }
    }
}
