using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0_1Knapsack
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        public void InitializeChart(List<int> iterations, List<double> convergences, List<double> averageFitnesses)
        {
            Chart_Results.Series[0].LegendText = "Convergence";
            Chart_Results.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_Results.ChartAreas[0].AxisX.Minimum = 0;
            Chart_Results.ChartAreas[0].AxisX.Maximum = iterations.Last() + 5 - iterations.Last() % 5;
            Chart_Results.ChartAreas[0].AxisX.Interval = 5;
            Chart_Results.ChartAreas[0].AxisY.Minimum = 0;
            Chart_Results.ChartAreas[0].AxisY.Maximum = 1;
            Chart_Results.Series[0].Points.DataBindXY(iterations, convergences);

            Chart_Results.Series.Add("Average Fitness");
            Chart_Results.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart_Results.Series[1].Points.DataBindXY(iterations, averageFitnesses);
        }
    }
}
