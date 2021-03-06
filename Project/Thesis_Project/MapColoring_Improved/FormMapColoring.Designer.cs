﻿namespace MapColoring_Improved
{
    partial class FormMapColoring
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtBx_Seed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtBx_PercentMutationDeviation = new System.Windows.Forms.TextBox();
            this.TxtBx_PercentChromosomesMutated = new System.Windows.Forms.TextBox();
            this.labelasd = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtBx_PercentGenesMutated = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtBx_MaxIterations = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBx_DefaultGeneValue = new System.Windows.Forms.TextBox();
            this.TxtBx_PopulationSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelpopsize = new System.Windows.Forms.Label();
            this.TxtBx_Convergence = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBx_MinEdgesPerCountry = new System.Windows.Forms.TextBox();
            this.Btn_GenerateGraph = new System.Windows.Forms.Button();
            this.Btn_RandomizeParameters = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBx_MaxEdgesPerCountry = new System.Windows.Forms.TextBox();
            this.TxtBx_NumCountries = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtBx_EdgeDensity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.PictureBox_Graph = new System.Windows.Forms.PictureBox();
            this.Btn_RunAlgorithm = new System.Windows.Forms.Button();
            this.Btn_SolveGraph = new System.Windows.Forms.Button();
            this.LBL_Iteration = new System.Windows.Forms.Label();
            this.LBL_Convergence = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PB_MapColoring = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGV_Results = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graph)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtBx_Seed);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TxtBx_PercentMutationDeviation);
            this.groupBox3.Controls.Add(this.TxtBx_PercentChromosomesMutated);
            this.groupBox3.Controls.Add(this.labelasd);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TxtBx_PercentGenesMutated);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.TxtBx_MaxIterations);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.TxtBx_DefaultGeneValue);
            this.groupBox3.Controls.Add(this.TxtBx_PopulationSize);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.labelpopsize);
            this.groupBox3.Controls.Add(this.TxtBx_Convergence);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 187);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Genetic Algorithm Parameters";
            // 
            // TxtBx_Seed
            // 
            this.TxtBx_Seed.Location = new System.Drawing.Point(112, 149);
            this.TxtBx_Seed.Name = "TxtBx_Seed";
            this.TxtBx_Seed.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_Seed.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(109, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Seed (Optional)";
            // 
            // TxtBx_PercentMutationDeviation
            // 
            this.TxtBx_PercentMutationDeviation.Location = new System.Drawing.Point(112, 110);
            this.TxtBx_PercentMutationDeviation.Name = "TxtBx_PercentMutationDeviation";
            this.TxtBx_PercentMutationDeviation.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_PercentMutationDeviation.TabIndex = 25;
            // 
            // TxtBx_PercentChromosomesMutated
            // 
            this.TxtBx_PercentChromosomesMutated.Location = new System.Drawing.Point(112, 32);
            this.TxtBx_PercentChromosomesMutated.Name = "TxtBx_PercentChromosomesMutated";
            this.TxtBx_PercentChromosomesMutated.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_PercentChromosomesMutated.TabIndex = 21;
            // 
            // labelasd
            // 
            this.labelasd.AutoSize = true;
            this.labelasd.Location = new System.Drawing.Point(109, 94);
            this.labelasd.Name = "labelasd";
            this.labelasd.Size = new System.Drawing.Size(107, 13);
            this.labelasd.TabIndex = 24;
            this.labelasd.Text = "% Mutation Deviation";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(109, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "% Chromosomes Mutated";
            // 
            // TxtBx_PercentGenesMutated
            // 
            this.TxtBx_PercentGenesMutated.Location = new System.Drawing.Point(112, 71);
            this.TxtBx_PercentGenesMutated.Name = "TxtBx_PercentGenesMutated";
            this.TxtBx_PercentGenesMutated.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_PercentGenesMutated.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(109, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "% Genes Mutated";
            // 
            // TxtBx_MaxIterations
            // 
            this.TxtBx_MaxIterations.Location = new System.Drawing.Point(6, 149);
            this.TxtBx_MaxIterations.Name = "TxtBx_MaxIterations";
            this.TxtBx_MaxIterations.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_MaxIterations.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Max Iterations";
            // 
            // TxtBx_DefaultGeneValue
            // 
            this.TxtBx_DefaultGeneValue.Location = new System.Drawing.Point(6, 110);
            this.TxtBx_DefaultGeneValue.Name = "TxtBx_DefaultGeneValue";
            this.TxtBx_DefaultGeneValue.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_DefaultGeneValue.TabIndex = 17;
            // 
            // TxtBx_PopulationSize
            // 
            this.TxtBx_PopulationSize.Location = new System.Drawing.Point(6, 32);
            this.TxtBx_PopulationSize.Name = "TxtBx_PopulationSize";
            this.TxtBx_PopulationSize.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_PopulationSize.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Default Gene Value";
            // 
            // labelpopsize
            // 
            this.labelpopsize.AutoSize = true;
            this.labelpopsize.Location = new System.Drawing.Point(3, 16);
            this.labelpopsize.Name = "labelpopsize";
            this.labelpopsize.Size = new System.Drawing.Size(80, 13);
            this.labelpopsize.TabIndex = 12;
            this.labelpopsize.Text = "Population Size";
            // 
            // TxtBx_Convergence
            // 
            this.TxtBx_Convergence.Location = new System.Drawing.Point(6, 71);
            this.TxtBx_Convergence.Name = "TxtBx_Convergence";
            this.TxtBx_Convergence.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_Convergence.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Convergence";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBx_MinEdgesPerCountry);
            this.groupBox1.Controls.Add(this.Btn_GenerateGraph);
            this.groupBox1.Controls.Add(this.Btn_RandomizeParameters);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtBx_MaxEdgesPerCountry);
            this.groupBox1.Controls.Add(this.TxtBx_NumCountries);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TxtBx_EdgeDensity);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(260, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 146);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Generating Parameters";
            // 
            // TxtBx_MinEdgesPerCountry
            // 
            this.TxtBx_MinEdgesPerCountry.Location = new System.Drawing.Point(112, 71);
            this.TxtBx_MinEdgesPerCountry.Name = "TxtBx_MinEdgesPerCountry";
            this.TxtBx_MinEdgesPerCountry.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_MinEdgesPerCountry.TabIndex = 19;
            // 
            // Btn_GenerateGraph
            // 
            this.Btn_GenerateGraph.Location = new System.Drawing.Point(112, 97);
            this.Btn_GenerateGraph.Name = "Btn_GenerateGraph";
            this.Btn_GenerateGraph.Size = new System.Drawing.Size(100, 43);
            this.Btn_GenerateGraph.TabIndex = 30;
            this.Btn_GenerateGraph.Text = "Generate Graph";
            this.Btn_GenerateGraph.UseVisualStyleBackColor = true;
            this.Btn_GenerateGraph.Click += new System.EventHandler(this.Btn_GenerateGraph_Click);
            // 
            // Btn_RandomizeParameters
            // 
            this.Btn_RandomizeParameters.Location = new System.Drawing.Point(6, 97);
            this.Btn_RandomizeParameters.Name = "Btn_RandomizeParameters";
            this.Btn_RandomizeParameters.Size = new System.Drawing.Size(100, 43);
            this.Btn_RandomizeParameters.TabIndex = 29;
            this.Btn_RandomizeParameters.Text = "Randomize Parameters";
            this.Btn_RandomizeParameters.UseVisualStyleBackColor = true;
            this.Btn_RandomizeParameters.Click += new System.EventHandler(this.Btn_RandomizeParameters_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Min Edges / Country";
            // 
            // TxtBx_MaxEdgesPerCountry
            // 
            this.TxtBx_MaxEdgesPerCountry.Location = new System.Drawing.Point(112, 32);
            this.TxtBx_MaxEdgesPerCountry.Name = "TxtBx_MaxEdgesPerCountry";
            this.TxtBx_MaxEdgesPerCountry.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_MaxEdgesPerCountry.TabIndex = 17;
            // 
            // TxtBx_NumCountries
            // 
            this.TxtBx_NumCountries.Location = new System.Drawing.Point(6, 32);
            this.TxtBx_NumCountries.Name = "TxtBx_NumCountries";
            this.TxtBx_NumCountries.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumCountries.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Max Edges / Country";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "# Countries";
            // 
            // TxtBx_EdgeDensity
            // 
            this.TxtBx_EdgeDensity.Location = new System.Drawing.Point(6, 71);
            this.TxtBx_EdgeDensity.Name = "TxtBx_EdgeDensity";
            this.TxtBx_EdgeDensity.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_EdgeDensity.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Edge Density";
            // 
            // PictureBox_Graph
            // 
            this.PictureBox_Graph.BackColor = System.Drawing.Color.White;
            this.PictureBox_Graph.Location = new System.Drawing.Point(485, 13);
            this.PictureBox_Graph.Name = "PictureBox_Graph";
            this.PictureBox_Graph.Size = new System.Drawing.Size(910, 778);
            this.PictureBox_Graph.TabIndex = 31;
            this.PictureBox_Graph.TabStop = false;
            // 
            // Btn_RunAlgorithm
            // 
            this.Btn_RunAlgorithm.Location = new System.Drawing.Point(373, 161);
            this.Btn_RunAlgorithm.Name = "Btn_RunAlgorithm";
            this.Btn_RunAlgorithm.Size = new System.Drawing.Size(106, 38);
            this.Btn_RunAlgorithm.TabIndex = 32;
            this.Btn_RunAlgorithm.Text = "Run Algorithm";
            this.Btn_RunAlgorithm.UseVisualStyleBackColor = true;
            this.Btn_RunAlgorithm.Click += new System.EventHandler(this.Btn_RunAlgorithm_Click);
            // 
            // Btn_SolveGraph
            // 
            this.Btn_SolveGraph.Location = new System.Drawing.Point(260, 161);
            this.Btn_SolveGraph.Name = "Btn_SolveGraph";
            this.Btn_SolveGraph.Size = new System.Drawing.Size(106, 38);
            this.Btn_SolveGraph.TabIndex = 33;
            this.Btn_SolveGraph.Text = "Solve Graph";
            this.Btn_SolveGraph.UseVisualStyleBackColor = true;
            this.Btn_SolveGraph.Click += new System.EventHandler(this.Btn_SolveGraph_Click);
            // 
            // LBL_Iteration
            // 
            this.LBL_Iteration.AutoSize = true;
            this.LBL_Iteration.Location = new System.Drawing.Point(92, 840);
            this.LBL_Iteration.Name = "LBL_Iteration";
            this.LBL_Iteration.Size = new System.Drawing.Size(13, 13);
            this.LBL_Iteration.TabIndex = 38;
            this.LBL_Iteration.Text = "0";
            // 
            // LBL_Convergence
            // 
            this.LBL_Convergence.AutoSize = true;
            this.LBL_Convergence.Location = new System.Drawing.Point(92, 827);
            this.LBL_Convergence.Name = "LBL_Convergence";
            this.LBL_Convergence.Size = new System.Drawing.Size(13, 13);
            this.LBL_Convergence.TabIndex = 37;
            this.LBL_Convergence.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 840);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Iteration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 827);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Convergence";
            // 
            // PB_MapColoring
            // 
            this.PB_MapColoring.Location = new System.Drawing.Point(18, 797);
            this.PB_MapColoring.Name = "PB_MapColoring";
            this.PB_MapColoring.Size = new System.Drawing.Size(1004, 23);
            this.PB_MapColoring.TabIndex = 34;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_Results);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 586);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // DGV_Results
            // 
            this.DGV_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Results.Location = new System.Drawing.Point(6, 19);
            this.DGV_Results.Name = "DGV_Results";
            this.DGV_Results.Size = new System.Drawing.Size(454, 561);
            this.DGV_Results.TabIndex = 0;
            // 
            // FormMapColoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 867);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LBL_Iteration);
            this.Controls.Add(this.LBL_Convergence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PB_MapColoring);
            this.Controls.Add(this.Btn_SolveGraph);
            this.Controls.Add(this.Btn_RunAlgorithm);
            this.Controls.Add(this.PictureBox_Graph);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormMapColoring";
            this.Text = "Map Coloring";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graph)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtBx_Seed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtBx_PercentMutationDeviation;
        private System.Windows.Forms.TextBox TxtBx_PercentChromosomesMutated;
        private System.Windows.Forms.Label labelasd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtBx_PercentGenesMutated;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtBx_MaxIterations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtBx_DefaultGeneValue;
        private System.Windows.Forms.TextBox TxtBx_PopulationSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelpopsize;
        private System.Windows.Forms.TextBox TxtBx_Convergence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtBx_MinEdgesPerCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBx_MaxEdgesPerCountry;
        private System.Windows.Forms.TextBox TxtBx_NumCountries;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtBx_EdgeDensity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button Btn_GenerateGraph;
        private System.Windows.Forms.Button Btn_RandomizeParameters;
        private System.Windows.Forms.PictureBox PictureBox_Graph;
        private System.Windows.Forms.Button Btn_RunAlgorithm;
        private System.Windows.Forms.Button Btn_SolveGraph;
        private System.Windows.Forms.Label LBL_Iteration;
        private System.Windows.Forms.Label LBL_Convergence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar PB_MapColoring;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DGV_Results;
    }
}

