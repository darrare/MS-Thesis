﻿using System;
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
    public partial class MapColoring : Form
    {
        Random rand = new Random();

        Dictionary<Control, string> toolTips;

        public MapColoring()
        {
            InitializeComponent();

            //Set tooltip strings for all input fields
            toolTips = new Dictionary<Control, string>()
            {
                { TxtBx_NumCountries, "The number of countries to generate" },
                { TxtBx_EdgeDensity, "The percentage of connections between countries. .5 = each country is neighbors to roughly 1/2 all countries. 1 = every country is connected to every other country. " },
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

        private void Btn_RunAlgorithm_Click(object sender, EventArgs e)
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
    }
}