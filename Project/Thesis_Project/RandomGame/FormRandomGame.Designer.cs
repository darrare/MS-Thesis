namespace RandomGame
{
    partial class FormRandomGame
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBx_RandomSeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBx_NumberOfConstraintsPerEdge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBx_MaxNumberOfColorsAllowed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBx_NumberOfIterations = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBx_MinEdgesPerNode = new System.Windows.Forms.TextBox();
            this.TxtBx_NumberOfNodes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelpopsize = new System.Windows.Forms.Label();
            this.TxtBx_MaxEdgesPerNode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.PictureBox_Graph = new System.Windows.Forms.PictureBox();
            this.TxtBx_DrawNodeAtIndex = new System.Windows.Forms.TextBox();
            this.Btn_DrawGraphAtIndex = new System.Windows.Forms.Button();
            this.Btn_DrawPrevious = new System.Windows.Forms.Button();
            this.Btn_DrawNext = new System.Windows.Forms.Button();
            this.Label_GraphsCount = new System.Windows.Forms.Label();
            this.TxtBx_EdgeConstraints = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBx_RandomSeed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtBx_NumberOfConstraintsPerEdge);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtBx_MaxNumberOfColorsAllowed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtBx_NumberOfIterations);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TxtBx_MinEdgesPerNode);
            this.groupBox1.Controls.Add(this.TxtBx_NumberOfNodes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelpopsize);
            this.groupBox1.Controls.Add(this.TxtBx_MaxEdgesPerNode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 174);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // TxtBx_RandomSeed
            // 
            this.TxtBx_RandomSeed.Location = new System.Drawing.Point(9, 149);
            this.TxtBx_RandomSeed.Name = "TxtBx_RandomSeed";
            this.TxtBx_RandomSeed.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_RandomSeed.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Random Seed";
            // 
            // TxtBx_NumberOfConstraintsPerEdge
            // 
            this.TxtBx_NumberOfConstraintsPerEdge.Location = new System.Drawing.Point(118, 71);
            this.TxtBx_NumberOfConstraintsPerEdge.Name = "TxtBx_NumberOfConstraintsPerEdge";
            this.TxtBx_NumberOfConstraintsPerEdge.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumberOfConstraintsPerEdge.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Number of constraints per edge";
            // 
            // TxtBx_MaxNumberOfColorsAllowed
            // 
            this.TxtBx_MaxNumberOfColorsAllowed.Location = new System.Drawing.Point(118, 110);
            this.TxtBx_MaxNumberOfColorsAllowed.Name = "TxtBx_MaxNumberOfColorsAllowed";
            this.TxtBx_MaxNumberOfColorsAllowed.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_MaxNumberOfColorsAllowed.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Max number of colors allowed";
            // 
            // TxtBx_NumberOfIterations
            // 
            this.TxtBx_NumberOfIterations.Location = new System.Drawing.Point(118, 32);
            this.TxtBx_NumberOfIterations.Name = "TxtBx_NumberOfIterations";
            this.TxtBx_NumberOfIterations.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumberOfIterations.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(115, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Number of iterations";
            // 
            // TxtBx_MinEdgesPerNode
            // 
            this.TxtBx_MinEdgesPerNode.Location = new System.Drawing.Point(9, 110);
            this.TxtBx_MinEdgesPerNode.Name = "TxtBx_MinEdgesPerNode";
            this.TxtBx_MinEdgesPerNode.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_MinEdgesPerNode.TabIndex = 25;
            // 
            // TxtBx_NumberOfNodes
            // 
            this.TxtBx_NumberOfNodes.Location = new System.Drawing.Point(9, 32);
            this.TxtBx_NumberOfNodes.Name = "TxtBx_NumberOfNodes";
            this.TxtBx_NumberOfNodes.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_NumberOfNodes.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Min edges per node";
            // 
            // labelpopsize
            // 
            this.labelpopsize.AutoSize = true;
            this.labelpopsize.Location = new System.Drawing.Point(6, 16);
            this.labelpopsize.Name = "labelpopsize";
            this.labelpopsize.Size = new System.Drawing.Size(88, 13);
            this.labelpopsize.TabIndex = 20;
            this.labelpopsize.Text = "Number of nodes";
            // 
            // TxtBx_MaxEdgesPerNode
            // 
            this.TxtBx_MaxEdgesPerNode.Location = new System.Drawing.Point(9, 71);
            this.TxtBx_MaxEdgesPerNode.Name = "TxtBx_MaxEdgesPerNode";
            this.TxtBx_MaxEdgesPerNode.Size = new System.Drawing.Size(100, 20);
            this.TxtBx_MaxEdgesPerNode.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Max edges per node";
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(180, 192);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(106, 38);
            this.Btn_Start.TabIndex = 34;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // PictureBox_Graph
            // 
            this.PictureBox_Graph.BackColor = System.Drawing.Color.White;
            this.PictureBox_Graph.Location = new System.Drawing.Point(292, 12);
            this.PictureBox_Graph.Name = "PictureBox_Graph";
            this.PictureBox_Graph.Size = new System.Drawing.Size(350, 350);
            this.PictureBox_Graph.TabIndex = 35;
            this.PictureBox_Graph.TabStop = false;
            // 
            // TxtBx_DrawNodeAtIndex
            // 
            this.TxtBx_DrawNodeAtIndex.Location = new System.Drawing.Point(419, 368);
            this.TxtBx_DrawNodeAtIndex.Name = "TxtBx_DrawNodeAtIndex";
            this.TxtBx_DrawNodeAtIndex.Size = new System.Drawing.Size(96, 20);
            this.TxtBx_DrawNodeAtIndex.TabIndex = 34;
            this.TxtBx_DrawNodeAtIndex.Text = "0";
            // 
            // Btn_DrawGraphAtIndex
            // 
            this.Btn_DrawGraphAtIndex.Location = new System.Drawing.Point(406, 394);
            this.Btn_DrawGraphAtIndex.Name = "Btn_DrawGraphAtIndex";
            this.Btn_DrawGraphAtIndex.Size = new System.Drawing.Size(121, 20);
            this.Btn_DrawGraphAtIndex.TabIndex = 36;
            this.Btn_DrawGraphAtIndex.Text = "Draw Graph at index";
            this.Btn_DrawGraphAtIndex.UseVisualStyleBackColor = true;
            this.Btn_DrawGraphAtIndex.Click += new System.EventHandler(this.Btn_DrawGraphAtIndex_Click);
            // 
            // Btn_DrawPrevious
            // 
            this.Btn_DrawPrevious.Location = new System.Drawing.Point(292, 368);
            this.Btn_DrawPrevious.Name = "Btn_DrawPrevious";
            this.Btn_DrawPrevious.Size = new System.Drawing.Size(121, 20);
            this.Btn_DrawPrevious.TabIndex = 37;
            this.Btn_DrawPrevious.Text = "Draw Previous";
            this.Btn_DrawPrevious.UseVisualStyleBackColor = true;
            this.Btn_DrawPrevious.Click += new System.EventHandler(this.Btn_DrawPrevious_Click);
            // 
            // Btn_DrawNext
            // 
            this.Btn_DrawNext.Location = new System.Drawing.Point(521, 368);
            this.Btn_DrawNext.Name = "Btn_DrawNext";
            this.Btn_DrawNext.Size = new System.Drawing.Size(121, 20);
            this.Btn_DrawNext.TabIndex = 38;
            this.Btn_DrawNext.Text = "Draw Next";
            this.Btn_DrawNext.UseVisualStyleBackColor = true;
            this.Btn_DrawNext.Click += new System.EventHandler(this.Btn_DrawNext_Click);
            // 
            // Label_GraphsCount
            // 
            this.Label_GraphsCount.AutoSize = true;
            this.Label_GraphsCount.Location = new System.Drawing.Point(562, 394);
            this.Label_GraphsCount.Name = "Label_GraphsCount";
            this.Label_GraphsCount.Size = new System.Drawing.Size(35, 13);
            this.Label_GraphsCount.TabIndex = 39;
            this.Label_GraphsCount.Text = "label2";
            // 
            // TxtBx_EdgeConstraints
            // 
            this.TxtBx_EdgeConstraints.Location = new System.Drawing.Point(12, 434);
            this.TxtBx_EdgeConstraints.Multiline = true;
            this.TxtBx_EdgeConstraints.Name = "TxtBx_EdgeConstraints";
            this.TxtBx_EdgeConstraints.Size = new System.Drawing.Size(1297, 275);
            this.TxtBx_EdgeConstraints.TabIndex = 40;
            // 
            // FormRandomGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 721);
            this.Controls.Add(this.TxtBx_EdgeConstraints);
            this.Controls.Add(this.Label_GraphsCount);
            this.Controls.Add(this.Btn_DrawNext);
            this.Controls.Add(this.Btn_DrawPrevious);
            this.Controls.Add(this.Btn_DrawGraphAtIndex);
            this.Controls.Add(this.TxtBx_DrawNodeAtIndex);
            this.Controls.Add(this.PictureBox_Graph);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRandomGame";
            this.Text = "FormRandomGame";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtBx_NumberOfIterations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtBx_MinEdgesPerNode;
        private System.Windows.Forms.TextBox TxtBx_NumberOfNodes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelpopsize;
        private System.Windows.Forms.TextBox TxtBx_MaxEdgesPerNode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtBx_NumberOfConstraintsPerEdge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBx_MaxNumberOfColorsAllowed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.TextBox TxtBx_RandomSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PictureBox_Graph;
        private System.Windows.Forms.TextBox TxtBx_DrawNodeAtIndex;
        private System.Windows.Forms.Button Btn_DrawGraphAtIndex;
        private System.Windows.Forms.Button Btn_DrawPrevious;
        private System.Windows.Forms.Button Btn_DrawNext;
        private System.Windows.Forms.Label Label_GraphsCount;
        private System.Windows.Forms.TextBox TxtBx_EdgeConstraints;
    }
}

