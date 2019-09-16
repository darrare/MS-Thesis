namespace _0_1Knapsack
{
    partial class ResultsForm
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart_Results = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Results)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart_Results
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart_Results.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart_Results.Legends.Add(legend1);
            this.Chart_Results.Location = new System.Drawing.Point(13, 13);
            this.Chart_Results.Name = "Chart_Results";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Chart_Results.Series.Add(series1);
            this.Chart_Results.Size = new System.Drawing.Size(775, 328);
            this.Chart_Results.TabIndex = 0;
            this.Chart_Results.Text = "chart1";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Chart_Results);
            this.Name = "ResultsForm";
            this.Text = "ResultsForm";
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Results)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Results;
    }
}