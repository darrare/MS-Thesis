namespace RandomGame
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.resultsListView = new System.Windows.Forms.ListView();
            this.satisfiedPercentage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            this.SuspendLayout();
            // 
            // chartResults
            // 
            chartArea2.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartResults.Legends.Add(legend2);
            this.chartResults.Location = new System.Drawing.Point(12, 12);
            this.chartResults.Name = "chartResults";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartResults.Series.Add(series2);
            this.chartResults.Size = new System.Drawing.Size(992, 695);
            this.chartResults.TabIndex = 0;
            this.chartResults.Text = "chart1";
            // 
            // resultsListView
            // 
            this.resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.satisfiedPercentage,
            this.count});
            this.resultsListView.HideSelection = false;
            this.resultsListView.Location = new System.Drawing.Point(1010, 12);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(676, 695);
            this.resultsListView.TabIndex = 1;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.Details;
            // 
            // satisfiedPercentage
            // 
            this.satisfiedPercentage.Text = "Satisfied Percentage";
            this.satisfiedPercentage.Width = 200;
            // 
            // count
            // 
            this.count.Text = "Count";
            this.count.Width = 200;
            // 
            // FormResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1801, 719);
            this.Controls.Add(this.resultsListView);
            this.Controls.Add(this.chartResults);
            this.Name = "FormResults";
            this.Text = "Results";
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.ColumnHeader satisfiedPercentage;
        private System.Windows.Forms.ColumnHeader count;
    }
}