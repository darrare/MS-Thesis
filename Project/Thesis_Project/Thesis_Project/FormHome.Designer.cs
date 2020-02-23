namespace Thesis_Project
{
    partial class FormHome
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
            this.Btn_GraphColoring = new System.Windows.Forms.Button();
            this.Btn_GraphColoringImproved = new System.Windows.Forms.Button();
            this.Btn_RandomGame = new System.Windows.Forms.Button();
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
            this.Btn_01Knapsack.Location = new System.Drawing.Point(11, 25);
            this.Btn_01Knapsack.Name = "Btn_01Knapsack";
            this.Btn_01Knapsack.Size = new System.Drawing.Size(126, 37);
            this.Btn_01Knapsack.TabIndex = 1;
            this.Btn_01Knapsack.Text = "0-1 Knapsack";
            this.Btn_01Knapsack.UseVisualStyleBackColor = true;
            this.Btn_01Knapsack.Click += new System.EventHandler(this.Btn_01Knapsack_Click);
            // 
            // Btn_GraphColoring
            // 
            this.Btn_GraphColoring.Location = new System.Drawing.Point(149, 25);
            this.Btn_GraphColoring.Name = "Btn_GraphColoring";
            this.Btn_GraphColoring.Size = new System.Drawing.Size(126, 37);
            this.Btn_GraphColoring.TabIndex = 5;
            this.Btn_GraphColoring.Text = "Graph Coloring";
            this.Btn_GraphColoring.UseVisualStyleBackColor = true;
            this.Btn_GraphColoring.Click += new System.EventHandler(this.Btn_GraphColoring_Click);
            // 
            // Btn_GraphColoringImproved
            // 
            this.Btn_GraphColoringImproved.Location = new System.Drawing.Point(287, 25);
            this.Btn_GraphColoringImproved.Name = "Btn_GraphColoringImproved";
            this.Btn_GraphColoringImproved.Size = new System.Drawing.Size(126, 37);
            this.Btn_GraphColoringImproved.TabIndex = 6;
            this.Btn_GraphColoringImproved.Text = "Graph Coloring Improved";
            this.Btn_GraphColoringImproved.UseVisualStyleBackColor = true;
            this.Btn_GraphColoringImproved.Click += new System.EventHandler(this.Btn_GraphColoringImproved_Click);
            // 
            // Btn_RandomGame
            // 
            this.Btn_RandomGame.Location = new System.Drawing.Point(12, 68);
            this.Btn_RandomGame.Name = "Btn_RandomGame";
            this.Btn_RandomGame.Size = new System.Drawing.Size(126, 37);
            this.Btn_RandomGame.TabIndex = 7;
            this.Btn_RandomGame.Text = "Random Game";
            this.Btn_RandomGame.UseVisualStyleBackColor = true;
            this.Btn_RandomGame.Click += new System.EventHandler(this.Btn_RandomGame_Click);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 114);
            this.Controls.Add(this.Btn_RandomGame);
            this.Controls.Add(this.Btn_GraphColoringImproved);
            this.Controls.Add(this.Btn_GraphColoring);
            this.Controls.Add(this.Btn_01Knapsack);
            this.Controls.Add(this.label1);
            this.Name = "FormHome";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_01Knapsack;
        private System.Windows.Forms.Button Btn_GraphColoring;
        private System.Windows.Forms.Button Btn_GraphColoringImproved;
        private System.Windows.Forms.Button Btn_RandomGame;
    }
}

