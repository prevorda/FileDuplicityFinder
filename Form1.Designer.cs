
namespace Testapp
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
            this.ChkInclSubdirs = new System.Windows.Forms.CheckBox();
            this.SelectedFolderText = new System.Windows.Forms.TextBox();
            this.BtnFolderSelect = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.SelectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkSsdDisk = new System.Windows.Forms.CheckBox();
            this.TextBoxResult = new System.Windows.Forms.TextBox();
            this.LblReult = new System.Windows.Forms.Label();
            this.StatBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusPrg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDuplicityFound = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChkInclSubdirs
            // 
            this.ChkInclSubdirs.AutoSize = true;
            this.ChkInclSubdirs.Location = new System.Drawing.Point(16, 97);
            this.ChkInclSubdirs.Name = "ChkInclSubdirs";
            this.ChkInclSubdirs.Size = new System.Drawing.Size(205, 24);
            this.ChkInclSubdirs.TabIndex = 0;
            this.ChkInclSubdirs.Text = "Include Sub-directories";
            this.ChkInclSubdirs.UseVisualStyleBackColor = true;
            // 
            // SelectedFolderText
            // 
            this.SelectedFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedFolderText.Location = new System.Drawing.Point(16, 60);
            this.SelectedFolderText.Name = "SelectedFolderText";
            this.SelectedFolderText.Size = new System.Drawing.Size(1194, 26);
            this.SelectedFolderText.TabIndex = 1;
            // 
            // BtnFolderSelect
            // 
            this.BtnFolderSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFolderSelect.Location = new System.Drawing.Point(1238, 60);
            this.BtnFolderSelect.Name = "BtnFolderSelect";
            this.BtnFolderSelect.Size = new System.Drawing.Size(124, 31);
            this.BtnFolderSelect.TabIndex = 2;
            this.BtnFolderSelect.Text = "Select folder";
            this.BtnFolderSelect.UseVisualStyleBackColor = true;
            this.BtnFolderSelect.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnStart.Location = new System.Drawing.Point(509, 135);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(232, 89);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.Text = "Start finding file duplicities";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1381, 43);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find file duplicities";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChkSsdDisk
            // 
            this.ChkSsdDisk.AutoSize = true;
            this.ChkSsdDisk.Location = new System.Drawing.Point(267, 97);
            this.ChkSsdDisk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChkSsdDisk.Name = "ChkSsdDisk";
            this.ChkSsdDisk.Size = new System.Drawing.Size(139, 24);
            this.ChkSsdDisk.TabIndex = 5;
            this.ChkSsdDisk.Text = "SSD disk type";
            this.ChkSsdDisk.UseVisualStyleBackColor = true;
            // 
            // TextBoxResult
            // 
            this.TextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxResult.Location = new System.Drawing.Point(13, 270);
            this.TextBoxResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxResult.Multiline = true;
            this.TextBoxResult.Name = "TextBoxResult";
            this.TextBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxResult.Size = new System.Drawing.Size(1343, 527);
            this.TextBoxResult.TabIndex = 9;
            // 
            // LblReult
            // 
            this.LblReult.AutoSize = true;
            this.LblReult.Location = new System.Drawing.Point(12, 245);
            this.LblReult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblReult.Name = "LblReult";
            this.LblReult.Size = new System.Drawing.Size(66, 20);
            this.LblReult.TabIndex = 7;
            this.LblReult.Text = "Results";
            // 
            // StatBar
            // 
            this.StatBar.ImageScalingSize = new System.Drawing.Size(26, 26);
            this.StatBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusPrg,
            this.toolStripStatFileCount,
            this.toolStripStatTime,
            this.toolStripDuplicityFound});
            this.StatBar.Location = new System.Drawing.Point(0, 807);
            this.StatBar.Name = "StatBar";
            this.StatBar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.StatBar.Size = new System.Drawing.Size(1381, 28);
            this.StatBar.TabIndex = 8;
            this.StatBar.Text = "statusStrip1";
            // 
            // toolStripStatusPrg
            // 
            this.toolStripStatusPrg.Name = "toolStripStatusPrg";
            this.toolStripStatusPrg.Size = new System.Drawing.Size(88, 21);
            this.toolStripStatusPrg.Text = "State: Idle";
            // 
            // toolStripStatFileCount
            // 
            this.toolStripStatFileCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatFileCount.Margin = new System.Windows.Forms.Padding(10, 5, 0, 3);
            this.toolStripStatFileCount.Name = "toolStripStatFileCount";
            this.toolStripStatFileCount.Size = new System.Drawing.Size(86, 29);
            this.toolStripStatFileCount.Text = "TotalFiles";
            this.toolStripStatFileCount.Visible = false;
            // 
            // toolStripStatTime
            // 
            this.toolStripStatTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 3);
            this.toolStripStatTime.Name = "toolStripStatTime";
            this.toolStripStatTime.Size = new System.Drawing.Size(117, 30);
            this.toolStripStatTime.Text = "Elapsed time: ";
            this.toolStripStatTime.Visible = false;
            // 
            // toolStripDuplicityFound
            // 
            this.toolStripDuplicityFound.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripDuplicityFound.Font = new System.Drawing.Font("Segoe UI", 8.883117F, System.Drawing.FontStyle.Bold);
            this.toolStripDuplicityFound.Margin = new System.Windows.Forms.Padding(10, 5, 0, 3);
            this.toolStripDuplicityFound.Name = "toolStripDuplicityFound";
            this.toolStripDuplicityFound.Size = new System.Drawing.Size(169, 29);
            this.toolStripDuplicityFound.Text = "Founded duplicity";
            this.toolStripDuplicityFound.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 835);
            this.Controls.Add(this.StatBar);
            this.Controls.Add(this.LblReult);
            this.Controls.Add(this.TextBoxResult);
            this.Controls.Add(this.ChkSsdDisk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnFolderSelect);
            this.Controls.Add(this.SelectedFolderText);
            this.Controls.Add(this.ChkInclSubdirs);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find duplicity";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StatBar.ResumeLayout(false);
            this.StatBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkInclSubdirs;
        private System.Windows.Forms.TextBox SelectedFolderText;
        private System.Windows.Forms.Button BtnFolderSelect;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.FolderBrowserDialog SelectFolderDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkSsdDisk;
        private System.Windows.Forms.TextBox TextBoxResult;
        private System.Windows.Forms.Label LblReult;
        private System.Windows.Forms.StatusStrip StatBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPrg;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatFileCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDuplicityFound;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatTime;
    }
}

