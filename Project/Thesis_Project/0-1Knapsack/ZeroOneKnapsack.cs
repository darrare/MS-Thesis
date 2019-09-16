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

namespace _0_1Knapsack
{
    public partial class ZeroOneKnapsack : Form
    {
        Random rand = new Random();

        Dictionary<Control, string> toolTips;

        public ZeroOneKnapsack()
        {
            InitializeComponent();

            //Set tooltip strings for all input fields
            toolTips = new Dictionary<Control, string>()
            {
                { TxtBx_Capacity, "The maximum space the knapsack can hold." },
                { TxtBx_MinimumWeight, "The minimum possible randomly generated weight for a knapsack object." },
                { TxtBx_MaximumWeight, "The maximum possible randomly generated weight for a knapsack object." },
                { TxtBx_MinimumValue, "The minimum possible randomly generated value for a knapsack object." },
                { TxtBx_MaximumValue, "The maximum possible randomly generated value for a knapsack object." },
                { TxtBx_PopulationSize , "Must be in the form of Size = X + Y where x = y(y-1)/2) where y is the number of chromosomes kept each iteration to breed." + Environment.NewLine + "Some valid values: 36, 136, 528, 2080" },
                { TxtBx_Convergence, "The percentage of convergence at which we stop the algorithm because all chromosomes are within this range of each other." },
                { TxtBx_DefaultGeneValue, "All genes will start at this value, and will be mutated once prior to calculating fitness." },
                { TxtBx_MaxIterations, "Maximum amount of times the algorithm will reproduce." },
                { TxtBx_PercentChromosomesMutated, "% chance a chromosome will be selected to mutate." + Environment.NewLine + "Some chromosomes are left the same if not 100%" },
                { TxtBx_PercentGenesMutated, "After a chromosome has been selected to mutate, this is the percentage chance for each gene to actually be mutated." },
                { TxtBx_PercentMutationDeviation, "How much off of the value can we mutate." + Environment.NewLine + ".5 means +- 50%, IE: 90 -> 45-135 and 180 -> 90-270" },
                { TxtBx_Seed, "Random seed used to generate same results every time you run the algorithm." },
                { TxtBx_NumberKnapsackObjects, "Number of knapsack objects to generate randomly with the below weights and values randomized." }
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
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/ZeroOneKnapsack/MostRecentRun.rd"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/ZeroOneKnapsack/MostRecentRun.rd"))
                    {
                        TxtBx_Capacity.Text = sr.ReadLine();
                        TxtBx_MinimumWeight.Text = sr.ReadLine();
                        TxtBx_MaximumWeight.Text = sr.ReadLine();
                        TxtBx_MinimumValue.Text = sr.ReadLine();
                        TxtBx_MaximumValue.Text = sr.ReadLine();
                        TxtBx_NumberKnapsackObjects.Text = sr.ReadLine();
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
        }

        /// <summary>
        /// The randomize parameters button has been clicked.
        /// Randomize the values of the parameter fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RandomizeParameters_Click(object sender, EventArgs e)
        {
            TxtBx_Capacity.Text = rand.Next(10, 100).ToString();

            double weightA = (rand.NextDouble() * 5), weightB = (rand.NextDouble() * 5);
            TxtBx_MinimumWeight.Text = (weightA > weightB ? weightB : weightA).ToString("#.###");
            TxtBx_MaximumWeight.Text = (weightA < weightB ? weightB : weightA).ToString("#.###");

            double valueA = (rand.NextDouble() * 5), valueB = (rand.NextDouble() * 5);
            TxtBx_MinimumValue.Text = (valueA > valueB ? valueB : valueA).ToString("#.###");
            TxtBx_MaximumValue.Text = (valueA < valueB ? valueB : valueA).ToString("#.###");

            TxtBx_NumberKnapsackObjects.Text = rand.Next(25, 200).ToString();

            int y = rand.Next(10, 50);
            TxtBx_PopulationSize.Text = (y + (y * (y - 1) / 2)).ToString();
            TxtBx_Convergence.Text = rand.NextDouble().ToString("#.###");
            TxtBx_DefaultGeneValue.Text = (rand.NextDouble() * 10).ToString("#.###");
            TxtBx_MaxIterations.Text = 1000.ToString();
            TxtBx_PercentChromosomesMutated.Text = rand.NextDouble().ToString("#.###");
            TxtBx_PercentGenesMutated.Text = rand.NextDouble().ToString("#.###");
            TxtBx_PercentMutationDeviation.Text = rand.NextDouble().ToString("#.###");
        }

        /// <summary>
        /// The run algorithm button has been clicked
        /// Store the value of the parameters in a file and then proceed to run the genetic algorithm
        /// </summary>
        private async void Btn_RunAlgorithm_Click(object sender, EventArgs e)
        {
            if (IsParameterError())
                return;

            //Save our current parameters to be spawned next time we run the program
            string destination = AppDomain.CurrentDomain.BaseDirectory + @"/StoredVariables/ZeroOneKnapsack";
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            using (StreamWriter sw = new StreamWriter(new FileStream(destination + "/MostRecentRun.rd", FileMode.Create)))
            {
                sw.WriteLine(TxtBx_Capacity.Text);
                sw.WriteLine(TxtBx_MinimumWeight.Text);
                sw.WriteLine(TxtBx_MaximumWeight.Text);
                sw.WriteLine(TxtBx_MinimumValue.Text);
                sw.WriteLine(TxtBx_MaximumValue.Text);
                sw.WriteLine(TxtBx_NumberKnapsackObjects.Text);
                sw.WriteLine(TxtBx_Seed.Text);
                sw.WriteLine(TxtBx_PopulationSize.Text);
                sw.WriteLine(TxtBx_Convergence.Text);
                sw.WriteLine(TxtBx_DefaultGeneValue.Text);
                sw.WriteLine(TxtBx_MaxIterations.Text);
                sw.WriteLine(TxtBx_PercentChromosomesMutated.Text);
                sw.WriteLine(TxtBx_PercentGenesMutated.Text);
                sw.WriteLine(TxtBx_PercentMutationDeviation.Text);
            }

            Knapsack knapsack = new Knapsack(
                int.Parse(TxtBx_Capacity.Text),
                double.Parse(TxtBx_MinimumWeight.Text),
                double.Parse(TxtBx_MaximumWeight.Text),
                double.Parse(TxtBx_MinimumValue.Text),
                double.Parse(TxtBx_MaximumValue.Text),
                int.Parse(TxtBx_NumberKnapsackObjects.Text),
                string.IsNullOrEmpty(TxtBx_Seed.Text) ? 0 : int.Parse(TxtBx_Seed.Text));

            GenerateKnapsackObjectsDataGridView(knapsack.Items);

            Btn_RandomizeParameters.Enabled = false;
            Btn_RunAlgorithm.Enabled = false;

            List<Tuple<int, double, double>> dataPoints = new List<Tuple<int, double, double>>();
            List<Tuple<int, List<double>>> selectedChromosomesFitness = new List<Tuple<int, List<double>>>();
            GeneticAlgorithm.GeneticAlgorithmClass.UpdateProgressBar = (percent, convergence, iteration, averageFitness, selectedFitness) =>
            {
                PB_Knapsack.Invoke((MethodInvoker)delegate ()
               {
                   PB_Knapsack.Value = percent;
                   LBL_Convergence.Text = convergence.ToString();
                   LBL_Iteration.Text = iteration.ToString();
                   dataPoints.Add(new Tuple<int, double, double>(iteration, convergence, averageFitness));
                   selectedChromosomesFitness.Add(selectedFitness);
               });
            };

            List<GeneticAlgorithm.Chromosome> chromosomes = await Task.Factory.StartNew(() =>
            {
                return GeneticAlgorithm.GeneticAlgorithmClass.RunGeneticAlgorithm(
                   int.Parse(TxtBx_PopulationSize.Text),
                   double.Parse(TxtBx_Convergence.Text),
                   new object[] { double.Parse(TxtBx_DefaultGeneValue.Text), double.Parse(TxtBx_DefaultGeneValue.Text), double.Parse(TxtBx_DefaultGeneValue.Text), double.Parse(TxtBx_DefaultGeneValue.Text) },
                   double.Parse(TxtBx_PercentChromosomesMutated.Text),
                   double.Parse(TxtBx_PercentGenesMutated.Text),
                   double.Parse(TxtBx_PercentMutationDeviation.Text),
                   knapsack.Fitness,
                   int.Parse(TxtBx_MaxIterations.Text),
                   string.IsNullOrEmpty(TxtBx_Seed.Text) ? 0 : int.Parse(TxtBx_Seed.Text));
            });

            Btn_RandomizeParameters.Enabled = true;
            Btn_RunAlgorithm.Enabled = true;

            //handle chromosomes in results data grid view
            GenerateResultsDataGridView(knapsack.GetKnapsackSolutionsFromGenes(chromosomes.Select(t => t.Genes).ToList()), knapsack.Items.ToList());
            ResultsForm form = new ResultsForm();
            form.InitializeChart(dataPoints.Select(t => t.Item1).ToList(), dataPoints.Select(t => t.Item2).ToList(), dataPoints.Select(t => t.Item3).ToList(), selectedChromosomesFitness);
            form.Show();
        }

        /// <summary>
        /// Checks to make sure all values are doubles
        /// </summary>
        /// <returns>True: an error was returned</returns>
        private bool IsParameterError()
        {
            string errors = "";
            double resultD;
            int resultI;

            //knapsack parameters
            if (!int.TryParse(TxtBx_Capacity.Text, out resultI))
                errors += "Invalid value for Capacity" + Environment.NewLine;
            if (!double.TryParse(TxtBx_MinimumWeight.Text, out resultD))
                errors += "Invalid value for Min Weight" + Environment.NewLine;
            if (!double.TryParse(TxtBx_MaximumWeight.Text, out resultD))
                errors += "Invalid value for Max Weight" + Environment.NewLine;
            if (!double.TryParse(TxtBx_MinimumValue.Text, out resultD))
                errors += "Invalid value for Min Value" + Environment.NewLine;
            if (!double.TryParse(TxtBx_MaximumValue.Text, out resultD))
                errors += "Invalid value for Max Value" + Environment.NewLine;
            if (!int.TryParse(TxtBx_NumberKnapsackObjects.Text, out resultI))
                errors += "Invalid value for # Knapsack Objects" + Environment.NewLine;


            //genetic algorithm parameters
            if (!int.TryParse(TxtBx_PopulationSize.Text, out resultI) && ValidatePopulationSize(int.Parse(TxtBx_PopulationSize.Text)))
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

        private void GenerateKnapsackObjectsDataGridView(KnapsackItem[] items)
        {
            DataTable table = new DataTable("Knapsack Objects");
            table.Columns.Add("id");
            table.Columns.Add("weight");
            table.Columns.Add("value");
            table.Columns.Add("value/weight");

            for (int i = 0; i < items.Length; i++)
            {
                table.Rows.Add(new object[] { i, items[i].Weight.ToString("#.###"), items[i].Value.ToString("#.###"), (items[i].Value / items[i].Weight).ToString("#.###") });
            }

            DGV_KnapsackObjects.DataSource = table;
            for (int i = 0; i < DGV_KnapsackObjects.Columns.Count; i++)
            {
                DGV_KnapsackObjects.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
        }

        /// <summary>
        /// Generates the results data grid view
        /// </summary>
        /// <param name="solutions">The solutions generated by the algorithm</param>
        /// <param name="items">Used to get the index of these items to connect to the other data grid view</param>
        private void GenerateResultsDataGridView(List<KnapsackSolution> solutions, List<KnapsackItem> items)
        {
            DataTable table = new DataTable("Final Evolution");
            table.Columns.Add("id");
            table.Columns.Add("Min Weight Gene");
            table.Columns.Add("Max Weight Gene");
            table.Columns.Add("Min Value Gene");
            table.Columns.Add("Max Value Gene");
            table.Columns.Add("Total Weight");
            table.Columns.Add("Total Value");
            table.Columns.Add("Total Value / Total Weight");
            table.Columns.Add("Contained Knapsack Objects");

            for (int i = 0; i < solutions.Count; i++)
            {
                table.Rows.Add(new object[] { i,
                    ((double)solutions[i].Genes[0]).ToString("#.###"),
                    ((double)solutions[i].Genes[1]).ToString("#.###"),
                    ((double)solutions[i].Genes[2]).ToString("#.###"),
                    ((double)solutions[i].Genes[3]).ToString("#.###"),
                    solutions[i].TotalWeight.ToString("#.###"),
                    solutions[i].TotalValue.ToString("#.###"),
                    (solutions[i].TotalValue / solutions[i].TotalWeight).ToString("#.###"),
                    solutions[i].Items.Select(t => items.IndexOf(t)).OrderBy(t => t).Select(t => t.ToString()).Aggregate((accum, cur) => accum += ", " + cur)
                });
            }

            DGV_Results.DataSource = table;
            for (int i = 0; i < DGV_Results.Columns.Count; i++)
            {
                DGV_Results.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
        }
    }
}
