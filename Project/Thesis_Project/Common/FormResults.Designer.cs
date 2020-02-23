namespace Common
{
    partial class FormResults
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart_Results = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart_FitnessScores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart_FitnessRange = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart_FitnessRangeFocused = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessRangeFocused)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart_Results
            // 
            chartArea13.Name = "ChartArea1";
            this.Chart_Results.ChartAreas.Add(chartArea13);
            this.Chart_Results.Location = new System.Drawing.Point(13, 13);
            this.Chart_Results.Name = "Chart_Results";
            series13.ChartArea = "ChartArea1";
            series13.Name = "Series1";
            this.Chart_Results.Series.Add(series13);
            this.Chart_Results.Size = new System.Drawing.Size(775, 328);
            this.Chart_Results.TabIndex = 0;
            this.Chart_Results.Text = "chart1";
            // 
            // Chart_FitnessScores
            // 
            chartArea14.Name = "ChartArea1";
            this.Chart_FitnessScores.ChartAreas.Add(chartArea14);
            this.Chart_FitnessScores.Location = new System.Drawing.Point(13, 374);
            this.Chart_FitnessScores.Name = "Chart_FitnessScores";
            series14.ChartArea = "ChartArea1";
            series14.Name = "Series1";
            this.Chart_FitnessScores.Series.Add(series14);
            this.Chart_FitnessScores.Size = new System.Drawing.Size(775, 328);
            this.Chart_FitnessScores.TabIndex = 1;
            this.Chart_FitnessScores.Text = "chart1";
            // 
            // Chart_FitnessRange
            // 
            chartArea15.Name = "ChartArea1";
            this.Chart_FitnessRange.ChartAreas.Add(chartArea15);
            this.Chart_FitnessRange.Location = new System.Drawing.Point(794, 13);
            this.Chart_FitnessRange.Name = "Chart_FitnessRange";
            series15.ChartArea = "ChartArea1";
            series15.Name = "Series1";
            this.Chart_FitnessRange.Series.Add(series15);
            this.Chart_FitnessRange.Size = new System.Drawing.Size(775, 662);
            this.Chart_FitnessRange.TabIndex = 2;
            this.Chart_FitnessRange.Text = "chart1";
            // 
            // Chart_FitnessRangeFocused
            // 
            chartArea16.Name = "ChartArea1";
            this.Chart_FitnessRangeFocused.ChartAreas.Add(chartArea16);
            this.Chart_FitnessRangeFocused.Location = new System.Drawing.Point(1575, 14);
            this.Chart_FitnessRangeFocused.Name = "Chart_FitnessRangeFocused";
            series16.ChartArea = "ChartArea1";
            series16.Name = "Series1";
            this.Chart_FitnessRangeFocused.Series.Add(series16);
            this.Chart_FitnessRangeFocused.Size = new System.Drawing.Size(775, 662);
            this.Chart_FitnessRangeFocused.TabIndex = 3;
            this.Chart_FitnessRangeFocused.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Convergence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 705);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fitness Scores of Breeders";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(794, 678);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fitness Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1572, 679);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fitness Range Focused";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1154, 678);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Orange = Maximum Fitness";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1154, 691);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Blue = Average Fitness";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1154, 705);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Red = Minimum Fitness";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1801, 705);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Red = Minimum Fitness";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1801, 691);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Blue = Average Fitness";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1801, 678);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Orange = Maximum Fitness";
            // 
            // FormResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2360, 736);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Chart_FitnessRangeFocused);
            this.Controls.Add(this.Chart_FitnessRange);
            this.Controls.Add(this.Chart_FitnessScores);
            this.Controls.Add(this.Chart_Results);
            this.Name = "FormResults";
            this.Text = "ResultsForm";
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Results)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessRangeFocused)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Results;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_FitnessScores;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_FitnessRange;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_FitnessRangeFocused;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}