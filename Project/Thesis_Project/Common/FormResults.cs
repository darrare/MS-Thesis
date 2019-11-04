using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class FormResults : Form
    {
        public FormResults()
        {
            InitializeComponent();
        }

        public void InitializeChart(List<int> iterations, List<double> convergences, List<double> averageFitnesses, List<Tuple<int, List<double>>> selectedFitnesses, int logInterval)
        {
            Chart_Results.Series[0].LegendText = "Convergence";
            Chart_Results.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_Results.ChartAreas[0].AxisX.Minimum = 0;
            Chart_Results.ChartAreas[0].AxisX.Maximum = iterations.Last() + logInterval - iterations.Last() % logInterval;
            Chart_Results.ChartAreas[0].AxisX.Interval = logInterval;
            Chart_Results.ChartAreas[0].AxisY.Minimum = 0;
            Chart_Results.ChartAreas[0].AxisY.Maximum = 1;
            Chart_Results.Series[0].Points.DataBindXY(iterations, convergences.Select(t => 1 - t).ToList());

            //Chart_Results.Series.Add("Average Fitness");
            //Chart_Results.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //Chart_Results.Series[1].Points.DataBindXY(iterations, averageFitnesses);

            Chart_FitnessScores.Series[0].LegendText = "Selected Chromosomes Fitness";
            Chart_FitnessScores.Series[0]["IsXAxisQuantitative"] = "true";
            Chart_FitnessScores.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            Chart_FitnessScores.ChartAreas[0].AxisX.Minimum = 0;
            Chart_FitnessScores.ChartAreas[0].AxisX.Maximum = iterations.Last() + logInterval - iterations.Last() % logInterval;
            Chart_FitnessScores.ChartAreas[0].AxisX.Interval = logInterval;

            int parentCount = selectedFitnesses[0].Item2.Count;
            List<int> iters = new List<int>();
            List<double> points = new List<double>();
            foreach(var yData in selectedFitnesses)
            {
                foreach(var yDataPoints in yData.Item2)
                {
                    iters.Add(yData.Item1);
                }
                points.AddRange(yData.Item2);
            }
            Chart_FitnessScores.Series[0].Points.DataBindXY(iters, points);
        }
    }
}
