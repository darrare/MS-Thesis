using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomGame
{
    public partial class FormResults : Form
    {
        public FormResults()
        {
            InitializeComponent();
        }

        public void Initialize(List<Tuple<int, int>> results)
        {
            List<double> actualResults = results.Select(t => (double)t.Item1 / ((double)t.Item1 + (double)t.Item2)).OrderBy(t => t).ToList();
            IEnumerable<IGrouping<double, double>> groups = actualResults.GroupBy(t => t);

            chartResults.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartResults.ChartAreas[0].AxisX.Minimum = 0;
            chartResults.ChartAreas[0].AxisX.Maximum = 1;
            chartResults.ChartAreas[0].AxisX.Interval = 1.0 / ((double)groups.Count() - 1.0);
            chartResults.ChartAreas[0].AxisY.Minimum = groups.Min(t => t.Count());
            chartResults.ChartAreas[0].AxisY.Maximum = groups.Max(t => t.Count());
            chartResults.ChartAreas[0].AxisY.Interval = (chartResults.ChartAreas[0].AxisY.Maximum - chartResults.ChartAreas[0].AxisY.Minimum) / 10.0;
            List<double> values = groups.Select(t => t.Key).ToList();
            List<int> counts = groups.Select(t => t.Count()).ToList();
            chartResults.Series[0].Points.DataBindXY(values, counts);

            foreach (var group in groups)
            {
                resultsListView.Items.Add(new ListViewItem(new string[] { group.Key.ToString(), group.Count().ToString()}));
            }
        }

        public void InitializeMultipleResults(List<List<Tuple<int, int>>> results)
        {

        }
    }
}
