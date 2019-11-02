namespace _0_1Knapsack
{
    partial class FormCompareAgainstGreedy
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DGV_KnapsackObjects = new System.Windows.Forms.DataGridView();
            this.DGV_Results = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBx_GreedyAlgorithmMaximumValue = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtBx_MinWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBx_MaxWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBx_MinValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBx_MaxValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Compare = new System.Windows.Forms.Button();
            this.TxtBx_TotalValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_KnapsackObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DGV_KnapsackObjects);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(417, 187);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Knapsack Objects";
            // 
            // DGV_KnapsackObjects
            // 
            this.DGV_KnapsackObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_KnapsackObjects.Location = new System.Drawing.Point(6, 16);
            this.DGV_KnapsackObjects.Name = "DGV_KnapsackObjects";
            this.DGV_KnapsackObjects.Size = new System.Drawing.Size(405, 165);
            this.DGV_KnapsackObjects.TabIndex = 0;
            // 
            // DGV_Results
            // 
            this.DGV_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Results.Location = new System.Drawing.Point(6, 19);
            this.DGV_Results.Name = "DGV_Results";
            this.DGV_Results.Size = new System.Drawing.Size(877, 332);
            this.DGV_Results.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGV_Results);
            this.groupBox1.Location = new System.Drawing.Point(12, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 357);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBx_GreedyAlgorithmMaximumValue);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(435, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 43);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Greedy Algorithm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Maximum Value";
            // 
            // TxtBx_GreedyAlgorithmMaximumValue
            // 
            this.TxtBx_GreedyAlgorithmMaximumValue.Location = new System.Drawing.Point(93, 13);
            this.TxtBx_GreedyAlgorithmMaximumValue.Name = "TxtBx_GreedyAlgorithmMaximumValue";
            this.TxtBx_GreedyAlgorithmMaximumValue.ReadOnly = true;
            this.TxtBx_GreedyAlgorithmMaximumValue.Size = new System.Drawing.Size(114, 20);
            this.TxtBx_GreedyAlgorithmMaximumValue.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.TxtBx_TotalValue);
            this.groupBox3.Controls.Add(this.Btn_Compare);
            this.groupBox3.Controls.Add(this.TxtBx_MaxValue);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TxtBx_MinValue);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TxtBx_MaxWeight);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TxtBx_MinWeight);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(435, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 138);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Custom Heuristic Values";
            // 
            // TxtBx_MinWeight
            // 
            this.TxtBx_MinWeight.Location = new System.Drawing.Point(73, 13);
            this.TxtBx_MinWeight.Name = "TxtBx_MinWeight";
            this.TxtBx_MinWeight.Size = new System.Drawing.Size(114, 20);
            this.TxtBx_MinWeight.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Min Weight";
            // 
            // TxtBx_MaxWeight
            // 
            this.TxtBx_MaxWeight.Location = new System.Drawing.Point(73, 39);
            this.TxtBx_MaxWeight.Name = "TxtBx_MaxWeight";
            this.TxtBx_MaxWeight.Size = new System.Drawing.Size(114, 20);
            this.TxtBx_MaxWeight.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Max Weight";
            // 
            // TxtBx_MinValue
            // 
            this.TxtBx_MinValue.Location = new System.Drawing.Point(73, 65);
            this.TxtBx_MinValue.Name = "TxtBx_MinValue";
            this.TxtBx_MinValue.Size = new System.Drawing.Size(114, 20);
            this.TxtBx_MinValue.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Min Value";
            // 
            // TxtBx_MaxValue
            // 
            this.TxtBx_MaxValue.Location = new System.Drawing.Point(73, 91);
            this.TxtBx_MaxValue.Name = "TxtBx_MaxValue";
            this.TxtBx_MaxValue.Size = new System.Drawing.Size(114, 20);
            this.TxtBx_MaxValue.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Max Value";
            // 
            // Btn_Compare
            // 
            this.Btn_Compare.Location = new System.Drawing.Point(385, 109);
            this.Btn_Compare.Name = "Btn_Compare";
            this.Btn_Compare.Size = new System.Drawing.Size(75, 23);
            this.Btn_Compare.TabIndex = 21;
            this.Btn_Compare.Text = "Compare";
            this.Btn_Compare.UseVisualStyleBackColor = true;
            this.Btn_Compare.Click += new System.EventHandler(this.Btn_Compare_Click);
            // 
            // TxtBx_TotalValue
            // 
            this.TxtBx_TotalValue.Location = new System.Drawing.Point(322, 39);
            this.TxtBx_TotalValue.Name = "TxtBx_TotalValue";
            this.TxtBx_TotalValue.Size = new System.Drawing.Size(114, 20);
            this.TxtBx_TotalValue.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Total Value";
            // 
            // CompareAgainstGreedy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 575);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompareAgainstGreedy";
            this.Text = "CompareAgainstGreedy";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_KnapsackObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DGV_KnapsackObjects;
        private System.Windows.Forms.DataGridView DGV_Results;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtBx_GreedyAlgorithmMaximumValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtBx_MinWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBx_MaxValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBx_MinValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBx_MaxWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Compare;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBx_TotalValue;
    }
}