namespace MapColoring_Improved
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
            this.TxtBx_TargetLowPossibleColors = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBx_TargetHighPossibleColors = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBx_TargetLowColorDegree = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBx_TargetHighColorDegree = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.PictureBox_Graph.Size = new System.Drawing.Size(910, 778);
            this.PictureBox_Graph.TabIndex = 31;
            this.PictureBox_Graph.TabStop = false;
            // 
            // Btn_SolveGraph
            // 
            this.Btn_SolveGraph.Location = new System.Drawing.Point(166, 199);
            this.Btn_SolveGraph.Name = "Btn_SolveGraph";
            this.Btn_SolveGraph.Size = new System.Drawing.Size(106, 38);
            this.Btn_SolveGraph.TabIndex = 33;
            this.Btn_SolveGraph.Text = "Solve Graph";
            this.Btn_SolveGraph.UseVisualStyleBackColor = true;
            this.Btn_SolveGraph.Click += new System.EventHandler(this.Btn_SolveGraph_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBx_TargetLowPossibleColors);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtBx_TargetHighPossibleColors);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtBx_TargetLowColorDegree);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtBx_TargetHighColorDegree);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 181);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gene Weights";
            // 
            // TxtBx_TargetLowPossibleColors
            // 
            this.TxtBx_TargetLowPossibleColors.Location = new System.Drawing.Point(154, 145);
            this.TxtBx_TargetLowPossibleColors.Name = "TxtBx_TargetLowPossibleColors";
            this.TxtBx_TargetLowPossibleColors.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_TargetLowPossibleColors.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Target Low Possible Colors";
            // 
            // TxtBx_TargetHighPossibleColors
            // 
            this.TxtBx_TargetHighPossibleColors.Location = new System.Drawing.Point(154, 119);
            this.TxtBx_TargetHighPossibleColors.Name = "TxtBx_TargetHighPossibleColors";
            this.TxtBx_TargetHighPossibleColors.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_TargetHighPossibleColors.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Target High Possible Colors";
            // 
            // TxtBx_TargetLowColorDegree
            // 
            this.TxtBx_TargetLowColorDegree.Location = new System.Drawing.Point(154, 93);
            this.TxtBx_TargetLowColorDegree.Name = "TxtBx_TargetLowColorDegree";
            this.TxtBx_TargetLowColorDegree.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_TargetLowColorDegree.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Target Low Colored Degree";
            // 
            // TxtBx_TargetHighColorDegree
            // 
            this.TxtBx_TargetHighColorDegree.Location = new System.Drawing.Point(154, 67);
            this.TxtBx_TargetHighColorDegree.Name = "TxtBx_TargetHighColorDegree";
            this.TxtBx_TargetHighColorDegree.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_TargetHighColorDegree.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Target High Colored Degree";
            // 
            // TxtBx_TimeToSolve
            // 
            this.TxtBx_TimeToSolve.Location = new System.Drawing.Point(6, 217);
            this.TxtBx_TimeToSolve.Name = "TxtBx_TimeToSolve";
            this.TxtBx_TimeToSolve.ReadOnly = true;
            this.TxtBx_TimeToSolve.Size = new System.Drawing.Size(154, 20);
            this.TxtBx_TimeToSolve.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Time To Solve";
            // 
            // FormSolveGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 799);
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
        private System.Windows.Forms.TextBox TxtBx_TargetHighPossibleColors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtBx_TargetLowColorDegree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBx_TargetHighColorDegree;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBx_TimeToSolve;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtBx_TargetLowPossibleColors;
        private System.Windows.Forms.Label label1;
    }
}

