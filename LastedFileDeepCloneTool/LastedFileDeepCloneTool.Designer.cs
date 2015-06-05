namespace LastedFileDeepCloneTool
{
    partial class LastedFileDeepCloneTool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastedFileDeepCloneTool));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseSource = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetectedPath = new System.Windows.Forms.TextBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseOutput = new System.Windows.Forms.Button();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chkCustomFolder = new System.Windows.Forms.CheckBox();
            this.txtExcludeSuffix = new System.Windows.Forms.TextBox();
            this.chkExcludeSuffix = new System.Windows.Forms.CheckBox();
            this.chkExcludeFolder = new System.Windows.Forms.CheckBox();
            this.txtExcludeFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChooseSource
            // 
            this.btnChooseSource.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnChooseSource.Location = new System.Drawing.Point(40, 166);
            this.btnChooseSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseSource.Name = "btnChooseSource";
            this.btnChooseSource.Size = new System.Drawing.Size(226, 45);
            this.btnChooseSource.TabIndex = 0;
            this.btnChooseSource.Text = "选择复制源目录";
            this.btnChooseSource.UseVisualStyleBackColor = true;
            this.btnChooseSource.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnLaunch.Location = new System.Drawing.Point(535, 164);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(226, 47);
            this.btnLaunch.TabIndex = 1;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(133, 23);
            this.dtpBeginDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBeginDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "筛选在此日期:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "检索目录:";
            // 
            // txtDetectedPath
            // 
            this.txtDetectedPath.Location = new System.Drawing.Point(105, 69);
            this.txtDetectedPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDetectedPath.Name = "txtDetectedPath";
            this.txtDetectedPath.ReadOnly = true;
            this.txtDetectedPath.Size = new System.Drawing.Size(375, 23);
            this.txtDetectedPath.TabIndex = 5;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(105, 116);
            this.txtOutputPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.ReadOnly = true;
            this.txtOutputPath.Size = new System.Drawing.Size(659, 23);
            this.txtOutputPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "输出目录:";
            // 
            // btnChooseOutput
            // 
            this.btnChooseOutput.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnChooseOutput.Location = new System.Drawing.Point(290, 166);
            this.btnChooseOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseOutput.Name = "btnChooseOutput";
            this.btnChooseOutput.Size = new System.Drawing.Size(226, 45);
            this.btnChooseOutput.TabIndex = 8;
            this.btnChooseOutput.Text = "选择输出目录";
            this.btnChooseOutput.UseVisualStyleBackColor = true;
            this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(344, 23);
            this.txtHour.MaxLength = 3;
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(34, 23);
            this.txtHour.TabIndex = 9;
            this.txtHour.Text = "8";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHour_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "当前小时-(减)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "小时之后的文件";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(43, 235);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(718, 79);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // chkCustomFolder
            // 
            this.chkCustomFolder.AutoSize = true;
            this.chkCustomFolder.Location = new System.Drawing.Point(535, 23);
            this.chkCustomFolder.Name = "chkCustomFolder";
            this.chkCustomFolder.Size = new System.Drawing.Size(147, 21);
            this.chkCustomFolder.TabIndex = 13;
            this.chkCustomFolder.Text = "文件复制到日期文件夹";
            this.chkCustomFolder.UseVisualStyleBackColor = true;
            // 
            // txtExcludeSuffix
            // 
            this.txtExcludeSuffix.Location = new System.Drawing.Point(683, 48);
            this.txtExcludeSuffix.Name = "txtExcludeSuffix";
            this.txtExcludeSuffix.Size = new System.Drawing.Size(81, 23);
            this.txtExcludeSuffix.TabIndex = 15;
            // 
            // chkExcludeSuffix
            // 
            this.chkExcludeSuffix.AutoSize = true;
            this.chkExcludeSuffix.Location = new System.Drawing.Point(535, 50);
            this.chkExcludeSuffix.Name = "chkExcludeSuffix";
            this.chkExcludeSuffix.Size = new System.Drawing.Size(142, 21);
            this.chkExcludeSuffix.TabIndex = 16;
            this.chkExcludeSuffix.Text = "排除指定后缀文件:  *.";
            this.chkExcludeSuffix.UseVisualStyleBackColor = true;
            this.chkExcludeSuffix.CheckedChanged += new System.EventHandler(this.chkExcludeSuffix_CheckedChanged);
            // 
            // chkExcludeFolder
            // 
            this.chkExcludeFolder.AutoSize = true;
            this.chkExcludeFolder.Location = new System.Drawing.Point(535, 77);
            this.chkExcludeFolder.Name = "chkExcludeFolder";
            this.chkExcludeFolder.Size = new System.Drawing.Size(135, 21);
            this.chkExcludeFolder.TabIndex = 18;
            this.chkExcludeFolder.Text = "排除指定名称文件夹";
            this.chkExcludeFolder.UseVisualStyleBackColor = true;
            this.chkExcludeFolder.CheckedChanged += new System.EventHandler(this.chkExcludeFolder_CheckedChanged);
            // 
            // txtExcludeFolder
            // 
            this.txtExcludeFolder.Location = new System.Drawing.Point(683, 75);
            this.txtExcludeFolder.Name = "txtExcludeFolder";
            this.txtExcludeFolder.Size = new System.Drawing.Size(81, 23);
            this.txtExcludeFolder.TabIndex = 17;
            // 
            // LastedFileDeepCloneTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 326);
            this.Controls.Add(this.chkExcludeFolder);
            this.Controls.Add(this.txtExcludeFolder);
            this.Controls.Add(this.chkExcludeSuffix);
            this.Controls.Add(this.txtExcludeSuffix);
            this.Controls.Add(this.chkCustomFolder);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.btnChooseOutput);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDetectedPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpBeginDate);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnChooseSource);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(806, 364);
            this.Name = "LastedFileDeepCloneTool";
            this.Text = "DeepClone Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LastedFileDeepCloneTool_FormClosed);
            this.Load += new System.EventHandler(this.LastedFileDeepCloneTool_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastedFileDeepCloneTool_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LastedFileDeepCloneTool_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnChooseSource;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetectedPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChooseOutput;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox chkCustomFolder;
        private System.Windows.Forms.TextBox txtExcludeSuffix;
        private System.Windows.Forms.CheckBox chkExcludeSuffix;
        private System.Windows.Forms.CheckBox chkExcludeFolder;
        private System.Windows.Forms.TextBox txtExcludeFolder;
    }
}

