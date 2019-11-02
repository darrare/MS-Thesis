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
    public partial class FormCompareAgainstGreedy : Form
    {

        List<KnapsackItem> items;
        int capacity;

        public FormCompareAgainstGreedy()
        {
            InitializeComponent();
        }

        public void InstantiateWithExistingData(DataTable results, DataTable knapsackObjects, int capacity)
        {
            DGV_Results.DataSource = results;
            DGV_KnapsackObjects.DataSource = knapsackObjects;
            items = knapsackObjects.AsEnumerable().Select(t => new KnapsackItem() { Weight = double.Parse((string)t[1]), Value = double.Parse((string)t[2]) }).ToList();
            this.capacity = capacity;
            TxtBx_GreedyAlgorithmMaximumValue.Text = GreedyAlgorithm(items, capacity).ToString("#.###");
        }

        private double GreedyAlgorithm(List<KnapsackItem> items, int capacity)
        {
            double weightSum = 0;
            double valueSum = 0;
            foreach (KnapsackItem item in items.OrderBy(t => t.Value / t.Weight).Reverse())
            {
                if (weightSum + item.Weight > 300)
                    break;

                weightSum += item.Weight;
                valueSum += item.Value;
            }
            return valueSum;
        }

        private void Btn_Compare_Click(object sender, EventArgs e)
        {
            double maximumWeight = items.Max(t => t.Weight);
            double maximumValue = items.Max(t => t.Value);
            List<KnapsackItem> inBag = new List<KnapsackItem>();
            foreach (KnapsackItem item in items.OrderByDescending(item =>
                (maximumWeight - item.Weight) * double.Parse(TxtBx_MinWeight.Text) +
                item.Weight * double.Parse(TxtBx_MaxWeight.Text) +
                (maximumValue - item.Value) * double.Parse(TxtBx_MinValue.Text) +
                item.Value * double.Parse(TxtBx_MaxValue.Text)
                ))
            {
                if (inBag.Sum(t => t.Weight) + item.Weight < capacity)
                {
                    inBag.Add(item);
                }
            }

            TxtBx_TotalValue.Text = inBag.Sum(t => t.Value).ToString("#.###");
        }
    }
}
