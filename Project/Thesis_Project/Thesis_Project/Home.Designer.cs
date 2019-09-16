namespace Thesis_Project
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_01Knapsack = new System.Windows.Forms.Button();
            this.Btn_NQueens = new System.Windows.Forms.Button();
            this.Btn_TravelingSalesman = new System.Windows.Forms.Button();
            this.Btn_JobShopScheduling = new System.Windows.Forms.Button();
            this.Btn_GraphColoring = new System.Windows.Forms.Button();
            this.Btn_Settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A genetic algorithm to optimize heuristic variables for constraint satisfaction p" +
    "roblems";
            // 
            // Btn_01Knapsack
            // 
            this.Btn_01Knapsack.Location = new System.Drawing.Point(12, 25);
            this.Btn_01Knapsack.Name = "Btn_01Knapsack";
            this.Btn_01Knapsack.Size = new System.Drawing.Size(126, 33);
            this.Btn_01Knapsack.TabIndex = 1;
            this.Btn_01Knapsack.Text = "0-1 Knapsack";
            this.Btn_01Knapsack.UseVisualStyleBackColor = true;
            this.Btn_01Knapsack.Click += new System.EventHandler(this.Btn_01Knapsack_Click);
            // 
            // Btn_NQueens
            // 
            this.Btn_NQueens.Location = new System.Drawing.Point(288, 25);
            this.Btn_NQueens.Name = "Btn_NQueens";
            this.Btn_NQueens.Size = new System.Drawing.Size(126, 33);
            this.Btn_NQueens.TabIndex = 2;
            this.Btn_NQueens.Text = "N-Queens";
            this.Btn_NQueens.UseVisualStyleBackColor = true;
            // 
            // Btn_TravelingSalesman
            // 
            this.Btn_TravelingSalesman.Location = new System.Drawing.Point(150, 25);
            this.Btn_TravelingSalesman.Name = "Btn_TravelingSalesman";
            this.Btn_TravelingSalesman.Size = new System.Drawing.Size(126, 33);
            this.Btn_TravelingSalesman.TabIndex = 3;
            this.Btn_TravelingSalesman.Text = "Traveling Salesman";
            this.Btn_TravelingSalesman.UseVisualStyleBackColor = true;
            // 
            // Btn_JobShopScheduling
            // 
            this.Btn_JobShopScheduling.Location = new System.Drawing.Point(12, 64);
            this.Btn_JobShopScheduling.Name = "Btn_JobShopScheduling";
            this.Btn_JobShopScheduling.Size = new System.Drawing.Size(126, 33);
            this.Btn_JobShopScheduling.TabIndex = 4;
            this.Btn_JobShopScheduling.Text = "Job Shop Scheduling";
            this.Btn_JobShopScheduling.UseVisualStyleBackColor = true;
            // 
            // Btn_GraphColoring
            // 
            this.Btn_GraphColoring.Location = new System.Drawing.Point(150, 64);
            this.Btn_GraphColoring.Name = "Btn_GraphColoring";
            this.Btn_GraphColoring.Size = new System.Drawing.Size(126, 33);
            this.Btn_GraphColoring.TabIndex = 5;
            this.Btn_GraphColoring.Text = "Graph Coloring";
            this.Btn_GraphColoring.UseVisualStyleBackColor = true;
            // 
            // Btn_Settings
            // 
            this.Btn_Settings.Location = new System.Drawing.Point(288, 64);
            this.Btn_Settings.Name = "Btn_Settings";
            this.Btn_Settings.Size = new System.Drawing.Size(126, 33);
            this.Btn_Settings.TabIndex = 6;
            this.Btn_Settings.Text = "Settings";
            this.Btn_Settings.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 113);
            this.Controls.Add(this.Btn_Settings);
            this.Controls.Add(this.Btn_GraphColoring);
            this.Controls.Add(this.Btn_JobShopScheduling);
            this.Controls.Add(this.Btn_TravelingSalesman);
            this.Controls.Add(this.Btn_NQueens);
            this.Controls.Add(this.Btn_01Knapsack);
            this.Controls.Add(this.label1);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_01Knapsack;
        private System.Windows.Forms.Button Btn_NQueens;
        private System.Windows.Forms.Button Btn_TravelingSalesman;
        private System.Windows.Forms.Button Btn_JobShopScheduling;
        private System.Windows.Forms.Button Btn_GraphColoring;
        private System.Windows.Forms.Button Btn_Settings;
    }
}

