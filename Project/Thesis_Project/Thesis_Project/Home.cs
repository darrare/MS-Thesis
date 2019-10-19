using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thesis_Project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Btn_01Knapsack_Click(object sender, EventArgs e)
        {
            _0_1Knapsack.ZeroOneKnapsack form = new _0_1Knapsack.ZeroOneKnapsack();
            form.Show();
        }

        private void Btn_GraphColoring_Click(object sender, EventArgs e)
        {
            MapColoring.MapColoring form = new MapColoring.MapColoring();
            form.Show();
        }
    }
}
