namespace MapColoring
{
    partial class FormSolveGraph
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
            this.PictureBox_Graph = new System.Windows.Forms.PictureBox();
            this.Btn_SolveGraph = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBx_NodeDegree = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBx_NumUncoloredNeighbors = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBx_NumEdgesNeighboringBlack = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBx_NumUncolored = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBx_NumColors = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBx_TimeToSolve = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox_Graph
            // 
            this.PictureBox_Graph.BackColor = System.Drawing.Color.White;
            this.PictureBox_Graph.Location = new System.Drawing.Point(290, 12);
            this.PictureBox_Graph.Name = "PictureBox_Graph";
            this.PictureBox_Graph.Size = new System.Drawing.Size(531, 420);
            this.PictureBox_Graph.TabIndex = 31;
            this.PictureBox_Graph.TabStop = false;
            // 
            // Btn_SolveGraph
            // 
            this.Btn_SolveGraph.Location = new System.Drawing.Point(178, 165);
            this.Btn_SolveGraph.Name = "Btn_SolveGraph";
            this.Btn_SolveGraph.Size = new System.Drawing.Size(106, 38);
            this.Btn_SolveGraph.TabIndex = 33;
            this.Btn_SolveGraph.Text = "Solve Graph";
            this.Btn_SolveGraph.UseVisualStyleBackColor = true;
            this.Btn_SolveGraph.Click += new System.EventHandler(this.Btn_SolveGraph_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBx_NodeDegree);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtBx_NumUncoloredNeighbors);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtBx_NumEdgesNeighboringBlack);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtBx_NumUncolored);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtBx_NumColors);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 147);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gene Weights";
            // 
            // TxtBx_NodeDegree
            // 
            this.TxtBx_NodeDegree.Location = new System.Drawing.Point(154, 119);
            this.TxtBx_NodeDegree.Name = "TxtBx_NodeDegree";
            this.TxtBx_NodeDegree.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NodeDegree.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "N-Node Degree";
            // 
            // TxtBx_NumUncoloredNeighbors
            // 
            this.TxtBx_NumUncoloredNeighbors.Location = new System.Drawing.Point(154, 93);
            this.TxtBx_NumUncoloredNeighbors.Name = "TxtBx_NumUncoloredNeighbors";
            this.TxtBx_NumUncoloredNeighbors.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumUncoloredNeighbors.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "N-# Uncolored Neighbors";
            // 
            // TxtBx_NumEdgesNeighboringBlack
            // 
            this.TxtBx_NumEdgesNeighboringBlack.Location = new System.Drawing.Point(154, 67);
            this.TxtBx_NumEdgesNeighboringBlack.Name = "TxtBx_NumEdgesNeighboringBlack";
            this.TxtBx_NumEdgesNeighboringBlack.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumEdgesNeighboringBlack.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "G-# Edges Neighboring Black";
            // 
            // TxtBx_NumUncolored
            // 
            this.TxtBx_NumUncolored.Location = new System.Drawing.Point(154, 41);
            this.TxtBx_NumUncolored.Name = "TxtBx_NumUncolored";
            this.TxtBx_NumUncolored.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumUncolored.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "G-# Uncolored";
            // 
            // TxtBx_NumColors
            // 
            this.TxtBx_NumColors.Location = new System.Drawing.Point(154, 15);
            this.TxtBx_NumColors.Name = "TxtBx_NumColors";
            this.TxtBx_NumColors.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumColors.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "G-# Colors";
            // 
            // TxtBx_TimeToSolve
            // 
            this.TxtBx_TimeToSolve.Location = new System.Drawing.Point(12, 183);
            this.TxtBx_TimeToSolve.Name = "TxtBx_TimeToSolve";
            this.TxtBx_TimeToSolve.ReadOnly = true;
            this.TxtBx_TimeToSolve.Size = new System.Drawing.Size(154, 20);
            this.TxtBx_TimeToSolve.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Time To Solve";
            // 
            // FormSolveGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 444);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtBx_TimeToSolve);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_SolveGraph);
            this.Controls.Add(this.PictureBox_Graph);
            this.Name = "FormSolveGraph";
            this.Text = "Map Coloring";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBox_Graph;
        private System.Windows.Forms.Button Btn_SolveGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtBx_NodeDegree;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtBx_NumUncoloredNeighbors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBx_NumEdgesNeighboringBlack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBx_NumUncolored;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBx_NumColors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBx_TimeToSolve;
        private System.Windows.Forms.Label label7;
    }
}

