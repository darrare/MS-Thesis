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

        public void InitializeChart(List<int> iterations, List<double> convergences, List<double> averageFitnesses, List<double> minimumFitness, List<double> maximumFitness, List<Tuple<int, List<double>>> selectedFitnesses, int logInterval)
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

            Chart_FitnessRange.Series[0].LegendText = "Average fitness";
            Chart_FitnessRange.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_FitnessRange.ChartAreas[0].AxisX.Minimum = 0;
            Chart_FitnessRange.ChartAreas[0].AxisX.Maximum = iterations.Last() + logInterval - iterations.Last() % logInterval;
            Chart_FitnessRange.ChartAreas[0].AxisX.Interval = logInterval;
            Chart_FitnessRange.ChartAreas[0].AxisY.Minimum = 0;
            //Chart_FitnessRange.ChartAreas[0].AxisY.Maximum = Math.Ceiling(averageFitnesses.Average()); //average of averages
            Chart_FitnessRange.Series[0].Points.DataBindXY(iterations, averageFitnesses);

            Chart_FitnessRange.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            Chart_FitnessRange.Series[1].LegendText = "Maximum fitness";
            Chart_FitnessRange.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_FitnessRange.Series[1].Points.DataBindXY(iterations, maximumFitness);

            Chart_FitnessRange.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            Chart_FitnessRange.Series[2].LegendText = "Minimum fitness";
            Chart_FitnessRange.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_FitnessRange.Series[2].Points.DataBindXY(iterations, minimumFitness);


            Chart_FitnessRangeFocused.Series[0].LegendText = "Average fitness";
            Chart_FitnessRangeFocused.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_FitnessRangeFocused.ChartAreas[0].AxisX.Minimum = 0;
            Chart_FitnessRangeFocused.ChartAreas[0].AxisX.Maximum = iterations.Last() + logInterval - iterations.Last() % logInterval;
            Chart_FitnessRangeFocused.ChartAreas[0].AxisX.Interval = logInterval;
            Chart_FitnessRangeFocused.ChartAreas[0].AxisY.Minimum = minimumFitness.Min();
            Chart_FitnessRangeFocused.ChartAreas[0].AxisY.Maximum = minimumFitness.Max();
            Chart_FitnessRangeFocused.Series[0].Points.DataBindXY(iterations, averageFitnesses);

            Chart_FitnessRangeFocused.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            Chart_FitnessRangeFocused.Series[1].LegendText = "Maximum fitness";
            Chart_FitnessRangeFocused.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_FitnessRangeFocused.Series[1].Points.DataBindXY(iterations, maximumFitness);

            Chart_FitnessRangeFocused.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            Chart_FitnessRangeFocused.Series[2].LegendText = "Minimum fitness";
            Chart_FitnessRangeFocused.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_FitnessRangeFocused.Series[2].Points.DataBindXY(iterations, minimumFitness);

        }
    }
}
