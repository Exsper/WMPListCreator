namespace WMPListCreator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.SelectFolderBotton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FileTypeTextBox = new System.Windows.Forms.TextBox();
            this.ResetFileTypeButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CreateWPLButton = new System.Windows.Forms.Button();
            this.IncludeSubFolder = new System.Windows.Forms.CheckBox();
            this.StateTimer = new System.Windows.Forms.Timer(this.components);
            this.AbsoluteRadioButton = new System.Windows.Forms.RadioButton();
            this.RelativeRadioButton = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件夹：";
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.AllowDrop = true;
            this.FolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderTextBox.Location = new System.Drawing.Point(103, 8);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.Size = new System.Drawing.Size(320, 21);
            this.FolderTextBox.TabIndex = 1;
            this.FolderTextBox.TextChanged += new System.EventHandler(this.FolderTextBox_TextChanged);
            this.FolderTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FolderTextBox_DragDrop);
            this.FolderTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FolderTextBox_DragEnter);
            this.FolderTextBox.Enter += new System.EventHandler(this.FolderTextBox_Enter);
            // 
            // SelectFolderBotton
            // 
            this.SelectFolderBotton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SelectFolderBotton.Location = new System.Drawing.Point(429, 7);
            this.SelectFolderBotton.Name = "SelectFolderBotton";
            this.SelectFolderBotton.Size = new System.Drawing.Size(74, 22);
            this.SelectFolderBotton.TabIndex = 2;
            this.SelectFolderBotton.Text = "选择";
            this.SelectFolderBotton.UseVisualStyleBackColor = true;
            this.SelectFolderBotton.Click += new System.EventHandler(this.SelectFolderBotton_Click);
            this.SelectFolderBotton.MouseEnter += new System.EventHandler(this.SelectFolderBotton_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "生成文件路径：";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameTextBox.Location = new System.Drawing.Point(103, 68);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(320, 21);
            this.FileNameTextBox.TabIndex = 4;
            this.FileNameTextBox.Enter += new System.EventHandler(this.FileNameTextBox_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "文件类型：";
            // 
            // FileTypeTextBox
            // 
            this.FileTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTypeTextBox.Location = new System.Drawing.Point(103, 38);
            this.FileTypeTextBox.Name = "FileTypeTextBox";
            this.FileTypeTextBox.Size = new System.Drawing.Size(320, 21);
            this.FileTypeTextBox.TabIndex = 7;
            this.FileTypeTextBox.Enter += new System.EventHandler(this.FileTypeTextBox_Enter);
            // 
            // ResetFileTypeButton
            // 
            this.ResetFileTypeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ResetFileTypeButton.Location = new System.Drawing.Point(429, 38);
            this.ResetFileTypeButton.Name = "ResetFileTypeButton";
            this.ResetFileTypeButton.Size = new System.Drawing.Size(74, 21);
            this.ResetFileTypeButton.TabIndex = 8;
            this.ResetFileTypeButton.Text = "默认";
            this.ResetFileTypeButton.UseVisualStyleBackColor = true;
            this.ResetFileTypeButton.Click += new System.EventHandler(this.ResetFileTypeButton_Click);
            this.ResetFileTypeButton.MouseEnter += new System.EventHandler(this.ResetFileTypeButton_MouseEnter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 119);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(514, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(32, 17);
            this.StatusLabel.Text = "状态";
            // 
            // CreateWPLButton
            // 
            this.CreateWPLButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CreateWPLButton.Location = new System.Drawing.Point(429, 68);
            this.CreateWPLButton.Name = "CreateWPLButton";
            this.CreateWPLButton.Size = new System.Drawing.Size(74, 21);
            this.CreateWPLButton.TabIndex = 10;
            this.CreateWPLButton.Text = "生成";
            this.CreateWPLButton.UseVisualStyleBackColor = true;
            this.CreateWPLButton.Click += new System.EventHandler(this.CreateWPLButton_Click);
            this.CreateWPLButton.MouseEnter += new System.EventHandler(this.CreateWPLButton_MouseEnter);
            // 
            // IncludeSubFolder
            // 
            this.IncludeSubFolder.AutoSize = true;
            this.IncludeSubFolder.Location = new System.Drawing.Point(10, 96);
            this.IncludeSubFolder.Name = "IncludeSubFolder";
            this.IncludeSubFolder.Size = new System.Drawing.Size(96, 16);
            this.IncludeSubFolder.TabIndex = 11;
            this.IncludeSubFolder.Text = "包含子文件夹";
            this.IncludeSubFolder.UseVisualStyleBackColor = true;
            this.IncludeSubFolder.MouseEnter += new System.EventHandler(this.IncludeSubFolder_MouseEnter);
            // 
            // StateTimer
            // 
            this.StateTimer.Interval = 500;
            this.StateTimer.Tick += new System.EventHandler(this.StateTimer_Tick);
            // 
            // AbsoluteRadioButton
            // 
            this.AbsoluteRadioButton.AutoSize = true;
            this.AbsoluteRadioButton.Checked = true;
            this.AbsoluteRadioButton.Location = new System.Drawing.Point(140, 96);
            this.AbsoluteRadioButton.Name = "AbsoluteRadioButton";
            this.AbsoluteRadioButton.Size = new System.Drawing.Size(71, 16);
            this.AbsoluteRadioButton.TabIndex = 12;
            this.AbsoluteRadioButton.TabStop = true;
            this.AbsoluteRadioButton.Text = "绝对路径";
            this.AbsoluteRadioButton.UseVisualStyleBackColor = true;
            this.AbsoluteRadioButton.MouseEnter += new System.EventHandler(this.AbsoluteRadioButton_MouseEnter);
            // 
            // RelativeRadioButton
            // 
            this.RelativeRadioButton.AutoSize = true;
            this.RelativeRadioButton.Location = new System.Drawing.Point(217, 96);
            this.RelativeRadioButton.Name = "RelativeRadioButton";
            this.RelativeRadioButton.Size = new System.Drawing.Size(71, 16);
            this.RelativeRadioButton.TabIndex = 13;
            this.RelativeRadioButton.Text = "相对路径";
            this.RelativeRadioButton.UseVisualStyleBackColor = true;
            this.RelativeRadioButton.MouseEnter += new System.EventHandler(this.RelativeRadioButton_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 141);
            this.Controls.Add(this.RelativeRadioButton);
            this.Controls.Add(this.AbsoluteRadioButton);
            this.Controls.Add(this.IncludeSubFolder);
            this.Controls.Add(this.CreateWPLButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ResetFileTypeButton);
            this.Controls.Add(this.FileTypeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectFolderBotton);
            this.Controls.Add(this.FolderTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 180);
            this.MinimumSize = new System.Drawing.Size(530, 180);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMP播放列表生成器 Ver1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.Button SelectFolderBotton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FileTypeTextBox;
        private System.Windows.Forms.Button ResetFileTypeButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button CreateWPLButton;
        private System.Windows.Forms.CheckBox IncludeSubFolder;
        private System.Windows.Forms.Timer StateTimer;
        private System.Windows.Forms.RadioButton AbsoluteRadioButton;
        private System.Windows.Forms.RadioButton RelativeRadioButton;
    }
}

