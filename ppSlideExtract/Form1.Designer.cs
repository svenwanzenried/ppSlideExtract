namespace ppSlideExtract
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.buttonInputFile = new System.Windows.Forms.Button();
            this.cbMask = new System.Windows.Forms.CheckBox();
            this.cbShadow = new System.Windows.Forms.CheckBox();
            this.numMask = new System.Windows.Forms.NumericUpDown();
            this.numShadow = new System.Windows.Forms.NumericUpDown();
            this.buttonOutputFolder = new System.Windows.Forms.Button();
            this.textBoxOutputFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShadow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose PowerPoint File:";
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInputFile.Location = new System.Drawing.Point(15, 25);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(523, 20);
            this.textBoxInputFile.TabIndex = 2;
            // 
            // buttonInputFile
            // 
            this.buttonInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInputFile.Location = new System.Drawing.Point(544, 23);
            this.buttonInputFile.Name = "buttonInputFile";
            this.buttonInputFile.Size = new System.Drawing.Size(31, 23);
            this.buttonInputFile.TabIndex = 3;
            this.buttonInputFile.Text = "...";
            this.buttonInputFile.UseVisualStyleBackColor = true;
            this.buttonInputFile.Click += new System.EventHandler(this.buttonInputFile_Click);
            // 
            // cbMask
            // 
            this.cbMask.AutoSize = true;
            this.cbMask.Location = new System.Drawing.Point(15, 52);
            this.cbMask.Name = "cbMask";
            this.cbMask.Size = new System.Drawing.Size(147, 17);
            this.cbMask.TabIndex = 4;
            this.cbMask.Text = "Slide Nr. of Banner Mask:";
            this.cbMask.UseVisualStyleBackColor = true;
            this.cbMask.CheckedChanged += new System.EventHandler(this.cbMask_CheckedChanged);
            // 
            // cbShadow
            // 
            this.cbShadow.AutoSize = true;
            this.cbShadow.Enabled = false;
            this.cbShadow.Location = new System.Drawing.Point(27, 75);
            this.cbShadow.Name = "cbShadow";
            this.cbShadow.Size = new System.Drawing.Size(152, 17);
            this.cbShadow.TabIndex = 5;
            this.cbShadow.Text = "Slide Nr. of Shadow Mask:";
            this.cbShadow.UseVisualStyleBackColor = true;
            this.cbShadow.CheckedChanged += new System.EventHandler(this.cbShadow_CheckedChanged);
            // 
            // numMask
            // 
            this.numMask.Enabled = false;
            this.numMask.Location = new System.Drawing.Point(169, 51);
            this.numMask.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMask.Name = "numMask";
            this.numMask.Size = new System.Drawing.Size(46, 20);
            this.numMask.TabIndex = 6;
            this.numMask.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numShadow
            // 
            this.numShadow.Enabled = false;
            this.numShadow.Location = new System.Drawing.Point(181, 74);
            this.numShadow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShadow.Name = "numShadow";
            this.numShadow.Size = new System.Drawing.Size(46, 20);
            this.numShadow.TabIndex = 7;
            this.numShadow.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonOutputFolder
            // 
            this.buttonOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutputFolder.Location = new System.Drawing.Point(544, 117);
            this.buttonOutputFolder.Name = "buttonOutputFolder";
            this.buttonOutputFolder.Size = new System.Drawing.Size(31, 23);
            this.buttonOutputFolder.TabIndex = 10;
            this.buttonOutputFolder.Text = "...";
            this.buttonOutputFolder.UseVisualStyleBackColor = true;
            this.buttonOutputFolder.Click += new System.EventHandler(this.buttonOutputFolder_Click);
            // 
            // textBoxOutputFolder
            // 
            this.textBoxOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputFolder.Location = new System.Drawing.Point(15, 119);
            this.textBoxOutputFolder.Name = "textBoxOutputFolder";
            this.textBoxOutputFolder.Size = new System.Drawing.Size(523, 20);
            this.textBoxOutputFolder.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose Output Folder:";
            // 
            // buttonExtract
            // 
            this.buttonExtract.Location = new System.Drawing.Point(15, 150);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(75, 23);
            this.buttonExtract.TabIndex = 11;
            this.buttonExtract.Text = "Extract";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInfo.Location = new System.Drawing.Point(544, 150);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(38, 23);
            this.buttonInfo.TabIndex = 12;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Items.AddRange(new object[] {
            "1: HD (1280x720)",
            "2: Full HD (1920x1080)",
            "3: 4K (3840x2160)"});
            this.comboBoxResolution.Location = new System.Drawing.Point(369, 50);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(206, 21);
            this.comboBoxResolution.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Export Resolution";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 182);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxResolution);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonExtract);
            this.Controls.Add(this.buttonOutputFolder);
            this.Controls.Add(this.textBoxOutputFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numShadow);
            this.Controls.Add(this.numMask);
            this.Controls.Add(this.cbShadow);
            this.Controls.Add(this.cbMask);
            this.Controls.Add(this.buttonInputFile);
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ppSlideExtract";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShadow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.Button buttonInputFile;
        private System.Windows.Forms.CheckBox cbMask;
        private System.Windows.Forms.CheckBox cbShadow;
        private System.Windows.Forms.NumericUpDown numMask;
        private System.Windows.Forms.NumericUpDown numShadow;
        private System.Windows.Forms.Button buttonOutputFolder;
        private System.Windows.Forms.TextBox textBoxOutputFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Label label3;
    }
}

