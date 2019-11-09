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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart_Results = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart_FitnessScores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart_FitnessRange = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart_FitnessRangeFocused = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_FitnessRangeFocused)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart_Results
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart_Results.ChartAreas.Add(chartArea1);
            this.Chart_Results.Location = new System.Drawing.Point(13, 13);
            this.Chart_Results.Name = "Chart_Results";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.Chart_Results.Series.Add(series1);
            this.Chart_Results.Size = new System.Drawing.Size(775, 328);
            this.Chart_Results.TabIndex = 0;
            this.Chart_Results.Text = "chart1";
            // 
            // Chart_FitnessScores
            // 
            chartArea2.Name = "ChartArea1";
            this.Chart_FitnessScores.ChartAreas.Add(chartArea2);
            this.Chart_FitnessScores.Location = new System.Drawing.Point(13, 347);
            this.Chart_FitnessScores.Name = "Chart_FitnessScores";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.Chart_FitnessScores.Series.Add(series2);
            this.Chart_FitnessScores.Size = new System.Drawing.Size(775, 328);
            this.Chart_FitnessScores.TabIndex = 1;
            this.Chart_FitnessScores.Text = "chart1";
            // 
            // Chart_FitnessRange
            // 
            chartArea3.Name = "ChartArea1";
            this.Chart_FitnessRange.ChartAreas.Add(chartArea3);
            this.Chart_FitnessRange.Location = new System.Drawing.Point(794, 13);
            this.Chart_FitnessRange.Name = "Chart_FitnessRange";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.Chart_FitnessRange.Series.Add(series3);
            this.Chart_FitnessRange.Size = new System.Drawing.Size(775, 662);
            this.Chart_FitnessRange.TabIndex = 2;
            this.Chart_FitnessRange.Text = "chart1";
            // 
            // Chart_FitnessRangeFocused
            // 
            chartArea4.Name = "ChartArea1";
            this.Chart_FitnessRangeFocused.ChartAreas.Add(chartArea4);
            this.Chart_FitnessRangeFocused.Location = new System.Drawing.Point(1575, 14);
            this.Chart_FitnessRangeFocused.Name = "Chart_FitnessRangeFocused";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.Chart_FitnessRangeFocused.Series.Add(series4);
            this.Chart_FitnessRangeFocused.Size = new System.Drawing.Size(775, 662);
            this.Chart_FitnessRangeFocused.TabIndex = 3;
            this.Chart_FitnessRangeFocused.Text = "chart1";
            // 
            // FormResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2360, 688);
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

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Results;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_FitnessScores;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_FitnessRange;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_FitnessRangeFocused;
    }
}