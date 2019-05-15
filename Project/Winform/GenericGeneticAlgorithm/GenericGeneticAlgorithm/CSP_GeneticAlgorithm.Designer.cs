namespace GenericGeneticAlgorithm
{
    partial class CSP_GeneticAlgorithm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label_CurrentConvergence = new System.Windows.Forms.Label();
            this.Label_CurrentWorstFitness = new System.Windows.Forms.Label();
            this.Label_CurrentBestFitness = new System.Windows.Forms.Label();
            this.Label_CurrentGeneration = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage_Knapsack = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TextBox_KnapsackMutateChance = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBox_KnapsackPopulationSize = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBox_KnapsackValueMax = new System.Windows.Forms.TextBox();
            this.TextBox_KnapsackValueMin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBox_KnapsackWeightMax = new System.Windows.Forms.TextBox();
            this.TextBox_KnapsackWeightMin = new System.Windows.Forms.TextBox();
            this.TextBox_KnapsackRandomSeed = new System.Windows.Forms.TextBox();
            this.TextBox_KnapsackNumItems = new System.Windows.Forms.TextBox();
            this.TextBox_KnapsackCapacity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RichTextBox_KnapsackNotifications = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Button_KnapsackStartFull = new System.Windows.Forms.Button();
            this.Button_KnapsackStartSequential = new System.Windows.Forms.Button();
            this.Button_KnapsackNextIteration = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPage_Knapsack.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label_CurrentConvergence);
            this.panel1.Controls.Add(this.Label_CurrentWorstFitness);
            this.panel1.Controls.Add(this.Label_CurrentBestFitness);
            this.panel1.Controls.Add(this.Label_CurrentGeneration);
            this.panel1.Location = new System.Drawing.Point(378, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 66);
            this.panel1.TabIndex = 0;
            // 
            // Label_CurrentConvergence
            // 
            this.Label_CurrentConvergence.AutoSize = true;
            this.Label_CurrentConvergence.Location = new System.Drawing.Point(3, 43);
            this.Label_CurrentConvergence.Name = "Label_CurrentConvergence";
            this.Label_CurrentConvergence.Size = new System.Drawing.Size(77, 13);
            this.Label_CurrentConvergence.TabIndex = 3;
            this.Label_CurrentConvergence.Text = "Convergence: ";
            // 
            // Label_CurrentWorstFitness
            // 
            this.Label_CurrentWorstFitness.AutoSize = true;
            this.Label_CurrentWorstFitness.Location = new System.Drawing.Point(4, 30);
            this.Label_CurrentWorstFitness.Name = "Label_CurrentWorstFitness";
            this.Label_CurrentWorstFitness.Size = new System.Drawing.Size(77, 13);
            this.Label_CurrentWorstFitness.TabIndex = 2;
            this.Label_CurrentWorstFitness.Text = "Worst Fitness: ";
            // 
            // Label_CurrentBestFitness
            // 
            this.Label_CurrentBestFitness.AutoSize = true;
            this.Label_CurrentBestFitness.Location = new System.Drawing.Point(4, 17);
            this.Label_CurrentBestFitness.Name = "Label_CurrentBestFitness";
            this.Label_CurrentBestFitness.Size = new System.Drawing.Size(70, 13);
            this.Label_CurrentBestFitness.TabIndex = 1;
            this.Label_CurrentBestFitness.Text = "Best Fitness: ";
            // 
            // Label_CurrentGeneration
            // 
            this.Label_CurrentGeneration.AutoSize = true;
            this.Label_CurrentGeneration.Location = new System.Drawing.Point(3, 4);
            this.Label_CurrentGeneration.Name = "Label_CurrentGeneration";
            this.Label_CurrentGeneration.Size = new System.Drawing.Size(65, 13);
            this.Label_CurrentGeneration.TabIndex = 0;
            this.Label_CurrentGeneration.Text = "Generation: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPage_Knapsack);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 307);
            this.tabControl1.TabIndex = 1;
            // 
            // TabPage_Knapsack
            // 
            this.TabPage_Knapsack.Controls.Add(this.Button_KnapsackNextIteration);
            this.TabPage_Knapsack.Controls.Add(this.Button_KnapsackStartSequential);
            this.TabPage_Knapsack.Controls.Add(this.Button_KnapsackStartFull);
            this.TabPage_Knapsack.Controls.Add(this.label14);
            this.TabPage_Knapsack.Controls.Add(this.RichTextBox_KnapsackNotifications);
            this.TabPage_Knapsack.Controls.Add(this.textBox4);
            this.TabPage_Knapsack.Controls.Add(this.label13);
            this.TabPage_Knapsack.Controls.Add(this.textBox3);
            this.TabPage_Knapsack.Controls.Add(this.label12);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackMutateChance);
            this.TabPage_Knapsack.Controls.Add(this.label11);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackPopulationSize);
            this.TabPage_Knapsack.Controls.Add(this.label10);
            this.TabPage_Knapsack.Controls.Add(this.label9);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackValueMax);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackValueMin);
            this.TabPage_Knapsack.Controls.Add(this.label8);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackWeightMax);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackWeightMin);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackRandomSeed);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackNumItems);
            this.TabPage_Knapsack.Controls.Add(this.TextBox_KnapsackCapacity);
            this.TabPage_Knapsack.Controls.Add(this.label7);
            this.TabPage_Knapsack.Controls.Add(this.label6);
            this.TabPage_Knapsack.Controls.Add(this.label5);
            this.TabPage_Knapsack.Controls.Add(this.label4);
            this.TabPage_Knapsack.Controls.Add(this.label3);
            this.TabPage_Knapsack.Controls.Add(this.label2);
            this.TabPage_Knapsack.Controls.Add(this.label1);
            this.TabPage_Knapsack.Controls.Add(this.panel1);
            this.TabPage_Knapsack.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Knapsack.Name = "TabPage_Knapsack";
            this.TabPage_Knapsack.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Knapsack.Size = new System.Drawing.Size(584, 281);
            this.TabPage_Knapsack.TabIndex = 0;
            this.TabPage_Knapsack.Text = "0-1 Knapsack";
            this.TabPage_Knapsack.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(248, 100);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(38, 20);
            this.textBox4.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(143, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Mutate Gene Value";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(248, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(38, 20);
            this.textBox3.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(165, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Mutate Gene %";
            // 
            // TextBox_KnapsackMutateChance
            // 
            this.TextBox_KnapsackMutateChance.Location = new System.Drawing.Point(248, 48);
            this.TextBox_KnapsackMutateChance.Name = "TextBox_KnapsackMutateChance";
            this.TextBox_KnapsackMutateChance.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackMutateChance.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(130, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Mutate Chromosome %";
            // 
            // TextBox_KnapsackPopulationSize
            // 
            this.TextBox_KnapsackPopulationSize.Location = new System.Drawing.Point(248, 22);
            this.TextBox_KnapsackPopulationSize.Name = "TextBox_KnapsackPopulationSize";
            this.TextBox_KnapsackPopulationSize.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackPopulationSize.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Population Size";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "-";
            // 
            // TextBox_KnapsackValueMax
            // 
            this.TextBox_KnapsackValueMax.Location = new System.Drawing.Point(86, 152);
            this.TextBox_KnapsackValueMax.Name = "TextBox_KnapsackValueMax";
            this.TextBox_KnapsackValueMax.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackValueMax.TabIndex = 15;
            // 
            // TextBox_KnapsackValueMin
            // 
            this.TextBox_KnapsackValueMin.Location = new System.Drawing.Point(26, 152);
            this.TextBox_KnapsackValueMin.Name = "TextBox_KnapsackValueMin";
            this.TextBox_KnapsackValueMin.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackValueMin.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "-";
            // 
            // TextBox_KnapsackWeightMax
            // 
            this.TextBox_KnapsackWeightMax.Location = new System.Drawing.Point(86, 113);
            this.TextBox_KnapsackWeightMax.Name = "TextBox_KnapsackWeightMax";
            this.TextBox_KnapsackWeightMax.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackWeightMax.TabIndex = 12;
            // 
            // TextBox_KnapsackWeightMin
            // 
            this.TextBox_KnapsackWeightMin.Location = new System.Drawing.Point(26, 113);
            this.TextBox_KnapsackWeightMin.Name = "TextBox_KnapsackWeightMin";
            this.TextBox_KnapsackWeightMin.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackWeightMin.TabIndex = 11;
            // 
            // TextBox_KnapsackRandomSeed
            // 
            this.TextBox_KnapsackRandomSeed.Location = new System.Drawing.Point(86, 74);
            this.TextBox_KnapsackRandomSeed.Name = "TextBox_KnapsackRandomSeed";
            this.TextBox_KnapsackRandomSeed.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackRandomSeed.TabIndex = 10;
            // 
            // TextBox_KnapsackNumItems
            // 
            this.TextBox_KnapsackNumItems.Location = new System.Drawing.Point(86, 48);
            this.TextBox_KnapsackNumItems.Name = "TextBox_KnapsackNumItems";
            this.TextBox_KnapsackNumItems.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackNumItems.TabIndex = 9;
            // 
            // TextBox_KnapsackCapacity
            // 
            this.TextBox_KnapsackCapacity.Location = new System.Drawing.Point(86, 22);
            this.TextBox_KnapsackCapacity.Name = "TextBox_KnapsackCapacity";
            this.TextBox_KnapsackCapacity.Size = new System.Drawing.Size(38, 20);
            this.TextBox_KnapsackCapacity.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Num Items";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Random Seed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Value Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Weight Range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Capacity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Genetic Variables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Knapsack Variables";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(584, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RichTextBox_KnapsackNotifications
            // 
            this.RichTextBox_KnapsackNotifications.Location = new System.Drawing.Point(9, 197);
            this.RichTextBox_KnapsackNotifications.Name = "RichTextBox_KnapsackNotifications";
            this.RichTextBox_KnapsackNotifications.Size = new System.Drawing.Size(277, 78);
            this.RichTextBox_KnapsackNotifications.TabIndex = 25;
            this.RichTextBox_KnapsackNotifications.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Notifications";
            // 
            // Button_KnapsackStartFull
            // 
            this.Button_KnapsackStartFull.Location = new System.Drawing.Point(332, 6);
            this.Button_KnapsackStartFull.Name = "Button_KnapsackStartFull";
            this.Button_KnapsackStartFull.Size = new System.Drawing.Size(120, 23);
            this.Button_KnapsackStartFull.TabIndex = 27;
            this.Button_KnapsackStartFull.Text = "Start Full";
            this.Button_KnapsackStartFull.UseVisualStyleBackColor = true;
            // 
            // Button_KnapsackStartSequential
            // 
            this.Button_KnapsackStartSequential.Location = new System.Drawing.Point(458, 6);
            this.Button_KnapsackStartSequential.Name = "Button_KnapsackStartSequential";
            this.Button_KnapsackStartSequential.Size = new System.Drawing.Size(120, 23);
            this.Button_KnapsackStartSequential.TabIndex = 28;
            this.Button_KnapsackStartSequential.Text = "Start Sequential";
            this.Button_KnapsackStartSequential.UseVisualStyleBackColor = true;
            // 
            // Button_KnapsackNextIteration
            // 
            this.Button_KnapsackNextIteration.Location = new System.Drawing.Point(458, 35);
            this.Button_KnapsackNextIteration.Name = "Button_KnapsackNextIteration";
            this.Button_KnapsackNextIteration.Size = new System.Drawing.Size(120, 23);
            this.Button_KnapsackNextIteration.TabIndex = 29;
            this.Button_KnapsackNextIteration.Text = "Next Sequence";
            this.Button_KnapsackNextIteration.UseVisualStyleBackColor = true;
            // 
            // CSP_GeneticAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 331);
            this.Controls.Add(this.tabControl1);
            this.Name = "CSP_GeneticAlgorithm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPage_Knapsack.ResumeLayout(false);
            this.TabPage_Knapsack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label_CurrentWorstFitness;
        private System.Windows.Forms.Label Label_CurrentBestFitness;
        private System.Windows.Forms.Label Label_CurrentGeneration;
        private System.Windows.Forms.Label Label_CurrentConvergence;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPage_Knapsack;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBox_KnapsackNumItems;
        private System.Windows.Forms.TextBox TextBox_KnapsackCapacity;
        private System.Windows.Forms.TextBox TextBox_KnapsackRandomSeed;
        private System.Windows.Forms.TextBox TextBox_KnapsackWeightMax;
        private System.Windows.Forms.TextBox TextBox_KnapsackWeightMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextBox_KnapsackValueMax;
        private System.Windows.Forms.TextBox TextBox_KnapsackValueMin;
        private System.Windows.Forms.TextBox TextBox_KnapsackPopulationSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TextBox_KnapsackMutateChance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox RichTextBox_KnapsackNotifications;
        private System.Windows.Forms.Button Button_KnapsackStartSequential;
        private System.Windows.Forms.Button Button_KnapsackStartFull;
        private System.Windows.Forms.Button Button_KnapsackNextIteration;
    }
}

