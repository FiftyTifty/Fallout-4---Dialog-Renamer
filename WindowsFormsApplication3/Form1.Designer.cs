namespace WindowsFormsApplication3
{
    partial class formMainWindow
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
            this.dialogOpenDialogExport = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenDialogExport = new System.Windows.Forms.Button();
            this.groupboxGetDialogExportFile = new System.Windows.Forms.GroupBox();
            this.textboxDialogExportFullPath = new System.Windows.Forms.TextBox();
            this.buttonProcessDialogExport = new System.Windows.Forms.Button();
            this.statusstripProcessing = new System.Windows.Forms.StatusStrip();
            this.progressbarProcessing = new System.Windows.Forms.ToolStripProgressBar();
            this.buttonGetRenamePairs = new System.Windows.Forms.Button();
            this.groupboxGetRenamePairs = new System.Windows.Forms.GroupBox();
            this.textboxGetVoiceFolder = new System.Windows.Forms.TextBox();
            this.buttonOpenVoiceFolder = new System.Windows.Forms.Button();
            this.statusstripGetRenamePairs = new System.Windows.Forms.StatusStrip();
            this.progressbarProcessingFuzFilenames = new System.Windows.Forms.ToolStripProgressBar();
            this.buttonProcessFuzFiles = new System.Windows.Forms.Button();
            this.textboxGetRenamePairs = new System.Windows.Forms.TextBox();
            this.tabcontrolMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dialogOpenVoiceFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dialogOpenRenamePairs = new System.Windows.Forms.OpenFileDialog();
            this.groupboxGetDialogExportFile.SuspendLayout();
            this.statusstripProcessing.SuspendLayout();
            this.groupboxGetRenamePairs.SuspendLayout();
            this.statusstripGetRenamePairs.SuspendLayout();
            this.tabcontrolMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogOpenDialogExport
            // 
            this.dialogOpenDialogExport.ShowReadOnly = true;
            // 
            // buttonOpenDialogExport
            // 
            this.buttonOpenDialogExport.Location = new System.Drawing.Point(6, 19);
            this.buttonOpenDialogExport.Name = "buttonOpenDialogExport";
            this.buttonOpenDialogExport.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenDialogExport.TabIndex = 0;
            this.buttonOpenDialogExport.Text = "Open...";
            this.buttonOpenDialogExport.UseVisualStyleBackColor = true;
            this.buttonOpenDialogExport.Click += new System.EventHandler(this.buttonOpenDialogExport_Click);
            // 
            // groupboxGetDialogExportFile
            // 
            this.groupboxGetDialogExportFile.Controls.Add(this.textboxDialogExportFullPath);
            this.groupboxGetDialogExportFile.Controls.Add(this.buttonProcessDialogExport);
            this.groupboxGetDialogExportFile.Controls.Add(this.buttonOpenDialogExport);
            this.groupboxGetDialogExportFile.Controls.Add(this.statusstripProcessing);
            this.groupboxGetDialogExportFile.Location = new System.Drawing.Point(6, 6);
            this.groupboxGetDialogExportFile.Name = "groupboxGetDialogExportFile";
            this.groupboxGetDialogExportFile.Size = new System.Drawing.Size(529, 195);
            this.groupboxGetDialogExportFile.TabIndex = 1;
            this.groupboxGetDialogExportFile.TabStop = false;
            this.groupboxGetDialogExportFile.Text = "Get dialogExport.txt";
            // 
            // textboxDialogExportFullPath
            // 
            this.textboxDialogExportFullPath.Location = new System.Drawing.Point(87, 21);
            this.textboxDialogExportFullPath.Name = "textboxDialogExportFullPath";
            this.textboxDialogExportFullPath.Size = new System.Drawing.Size(436, 20);
            this.textboxDialogExportFullPath.TabIndex = 1;
            this.textboxDialogExportFullPath.Text = "Insert full path to the .txt file here. Click \"Begin!\" to output a valid rename p" +
    "airs file.";
            // 
            // buttonProcessDialogExport
            // 
            this.buttonProcessDialogExport.Location = new System.Drawing.Point(232, 63);
            this.buttonProcessDialogExport.Name = "buttonProcessDialogExport";
            this.buttonProcessDialogExport.Size = new System.Drawing.Size(75, 23);
            this.buttonProcessDialogExport.TabIndex = 2;
            this.buttonProcessDialogExport.Text = "Begin!";
            this.buttonProcessDialogExport.UseVisualStyleBackColor = true;
            this.buttonProcessDialogExport.Click += new System.EventHandler(this.buttonProcessDialogExport_Click);
            // 
            // statusstripProcessing
            // 
            this.statusstripProcessing.Dock = System.Windows.Forms.DockStyle.None;
            this.statusstripProcessing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressbarProcessing});
            this.statusstripProcessing.Location = new System.Drawing.Point(3, 97);
            this.statusstripProcessing.Name = "statusstripProcessing";
            this.statusstripProcessing.Size = new System.Drawing.Size(539, 22);
            this.statusstripProcessing.SizingGrip = false;
            this.statusstripProcessing.TabIndex = 3;
            // 
            // progressbarProcessing
            // 
            this.progressbarProcessing.MarqueeAnimationSpeed = 30;
            this.progressbarProcessing.Name = "progressbarProcessing";
            this.progressbarProcessing.Size = new System.Drawing.Size(520, 16);
            this.progressbarProcessing.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // buttonGetRenamePairs
            // 
            this.buttonGetRenamePairs.Location = new System.Drawing.Point(6, 19);
            this.buttonGetRenamePairs.Name = "buttonGetRenamePairs";
            this.buttonGetRenamePairs.Size = new System.Drawing.Size(75, 23);
            this.buttonGetRenamePairs.TabIndex = 4;
            this.buttonGetRenamePairs.Text = "Open...";
            this.buttonGetRenamePairs.UseVisualStyleBackColor = true;
            this.buttonGetRenamePairs.Click += new System.EventHandler(this.buttonGetRenamePairs_Click);
            // 
            // groupboxGetRenamePairs
            // 
            this.groupboxGetRenamePairs.Controls.Add(this.textboxGetVoiceFolder);
            this.groupboxGetRenamePairs.Controls.Add(this.buttonOpenVoiceFolder);
            this.groupboxGetRenamePairs.Controls.Add(this.statusstripGetRenamePairs);
            this.groupboxGetRenamePairs.Controls.Add(this.buttonProcessFuzFiles);
            this.groupboxGetRenamePairs.Controls.Add(this.textboxGetRenamePairs);
            this.groupboxGetRenamePairs.Controls.Add(this.buttonGetRenamePairs);
            this.groupboxGetRenamePairs.Location = new System.Drawing.Point(6, 6);
            this.groupboxGetRenamePairs.Name = "groupboxGetRenamePairs";
            this.groupboxGetRenamePairs.Size = new System.Drawing.Size(529, 184);
            this.groupboxGetRenamePairs.TabIndex = 5;
            this.groupboxGetRenamePairs.TabStop = false;
            this.groupboxGetRenamePairs.Text = "Get Rename Pairs .txt file";
            // 
            // textboxGetVoiceFolder
            // 
            this.textboxGetVoiceFolder.Location = new System.Drawing.Point(87, 50);
            this.textboxGetVoiceFolder.Name = "textboxGetVoiceFolder";
            this.textboxGetVoiceFolder.Size = new System.Drawing.Size(408, 20);
            this.textboxGetVoiceFolder.TabIndex = 7;
            this.textboxGetVoiceFolder.Text = "Insert full path to the folder containing the .fuz files. E.g, C:\\Fallout 4\\Data\\" +
    "Voices";
            // 
            // buttonOpenVoiceFolder
            // 
            this.buttonOpenVoiceFolder.Location = new System.Drawing.Point(6, 48);
            this.buttonOpenVoiceFolder.Name = "buttonOpenVoiceFolder";
            this.buttonOpenVoiceFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenVoiceFolder.TabIndex = 8;
            this.buttonOpenVoiceFolder.Text = "Open...";
            this.buttonOpenVoiceFolder.UseVisualStyleBackColor = true;
            this.buttonOpenVoiceFolder.Click += new System.EventHandler(this.buttonOpenVoiceFolder_Click);
            // 
            // statusstripGetRenamePairs
            // 
            this.statusstripGetRenamePairs.Dock = System.Windows.Forms.DockStyle.None;
            this.statusstripGetRenamePairs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressbarProcessingFuzFilenames});
            this.statusstripGetRenamePairs.Location = new System.Drawing.Point(3, 124);
            this.statusstripGetRenamePairs.Name = "statusstripGetRenamePairs";
            this.statusstripGetRenamePairs.Size = new System.Drawing.Size(539, 22);
            this.statusstripGetRenamePairs.SizingGrip = false;
            this.statusstripGetRenamePairs.TabIndex = 6;
            this.statusstripGetRenamePairs.Text = "statusStrip1";
            // 
            // progressbarProcessingFuzFilenames
            // 
            this.progressbarProcessingFuzFilenames.Name = "progressbarProcessingFuzFilenames";
            this.progressbarProcessingFuzFilenames.Size = new System.Drawing.Size(520, 16);
            // 
            // buttonProcessFuzFiles
            // 
            this.buttonProcessFuzFiles.Location = new System.Drawing.Point(232, 90);
            this.buttonProcessFuzFiles.Name = "buttonProcessFuzFiles";
            this.buttonProcessFuzFiles.Size = new System.Drawing.Size(75, 23);
            this.buttonProcessFuzFiles.TabIndex = 6;
            this.buttonProcessFuzFiles.Text = "Begin!";
            this.buttonProcessFuzFiles.UseVisualStyleBackColor = true;
            this.buttonProcessFuzFiles.Click += new System.EventHandler(this.buttonProcessFuzFiles_Click);
            // 
            // textboxGetRenamePairs
            // 
            this.textboxGetRenamePairs.Location = new System.Drawing.Point(87, 21);
            this.textboxGetRenamePairs.Name = "textboxGetRenamePairs";
            this.textboxGetRenamePairs.Size = new System.Drawing.Size(408, 20);
            this.textboxGetRenamePairs.TabIndex = 2;
            this.textboxGetRenamePairs.Text = "Insert full path to the Rename Pairs .txt file here.";
            // 
            // tabcontrolMain
            // 
            this.tabcontrolMain.Controls.Add(this.tabPage1);
            this.tabcontrolMain.Controls.Add(this.tabPage2);
            this.tabcontrolMain.Location = new System.Drawing.Point(2, 5);
            this.tabcontrolMain.Name = "tabcontrolMain";
            this.tabcontrolMain.SelectedIndex = 0;
            this.tabcontrolMain.Size = new System.Drawing.Size(571, 222);
            this.tabcontrolMain.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupboxGetDialogExportFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(563, 196);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate Rename Pairs List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupboxGetRenamePairs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(563, 196);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Process .fuz Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // formMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 226);
            this.Controls.Add(this.tabcontrolMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fallout 4 - DialogExport To BulkRenameUtility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupboxGetDialogExportFile.ResumeLayout(false);
            this.groupboxGetDialogExportFile.PerformLayout();
            this.statusstripProcessing.ResumeLayout(false);
            this.statusstripProcessing.PerformLayout();
            this.groupboxGetRenamePairs.ResumeLayout(false);
            this.groupboxGetRenamePairs.PerformLayout();
            this.statusstripGetRenamePairs.ResumeLayout(false);
            this.statusstripGetRenamePairs.PerformLayout();
            this.tabcontrolMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dialogOpenDialogExport;
        private System.Windows.Forms.Button buttonOpenDialogExport;
        private System.Windows.Forms.GroupBox groupboxGetDialogExportFile;
        private System.Windows.Forms.TextBox textboxDialogExportFullPath;
        private System.Windows.Forms.Button buttonProcessDialogExport;
        private System.Windows.Forms.StatusStrip statusstripProcessing;
        private System.Windows.Forms.ToolStripProgressBar progressbarProcessing;
        private System.Windows.Forms.Button buttonGetRenamePairs;
        private System.Windows.Forms.GroupBox groupboxGetRenamePairs;
        private System.Windows.Forms.TextBox textboxGetRenamePairs;
        private System.Windows.Forms.Button buttonProcessFuzFiles;
        private System.Windows.Forms.StatusStrip statusstripGetRenamePairs;
        private System.Windows.Forms.ToolStripProgressBar progressbarProcessingFuzFilenames;
        private System.Windows.Forms.TabControl tabcontrolMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textboxGetVoiceFolder;
        private System.Windows.Forms.Button buttonOpenVoiceFolder;
        private System.Windows.Forms.FolderBrowserDialog dialogOpenVoiceFolder;
        private System.Windows.Forms.OpenFileDialog dialogOpenRenamePairs;
    }
}

