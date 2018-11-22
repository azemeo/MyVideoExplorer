namespace MyVideoExplorer
{
    partial class FormSources
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
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageSource = new System.Windows.Forms.TabPage();
            this.labelLastScanned = new System.Windows.Forms.Label();
            this.panelForFiles = new System.Windows.Forms.Panel();
            this.labelOtherFilesQty = new System.Windows.Forms.Label();
            this.labelForOtherFilesQty = new System.Windows.Forms.Label();
            this.labelForVideoFileQty = new System.Windows.Forms.Label();
            this.labelVideoFileQty = new System.Windows.Forms.Label();
            this.labelForLastScanned = new System.Windows.Forms.Label();
            this.listViewSource = new System.Windows.Forms.ListView();
            this.columnHeaderAlias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderScanned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelForSource = new System.Windows.Forms.Panel();
            this.buttonSaveSource = new System.Windows.Forms.Button();
            this.buttonSourceDirectory = new System.Windows.Forms.Button();
            this.textBoxDirectory = new System.Windows.Forms.TextBox();
            this.labelAlias = new System.Windows.Forms.Label();
            this.labelForType = new System.Windows.Forms.Label();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonRemoveSource = new System.Windows.Forms.Button();
            this.buttonAddSource = new System.Windows.Forms.Button();
            this.textBoxAlias = new System.Windows.Forms.TextBox();
            this.panelForScan = new System.Windows.Forms.Panel();
            this.buttonScanSource = new System.Windows.Forms.Button();
            this.subFormProgressOptions = new MyVideoExplorer.SubFormProgress();
            this.splitContainerSettingsClose = new System.Windows.Forms.SplitContainer();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControlSettings.SuspendLayout();
            this.tabPageSource.SuspendLayout();
            this.panelForFiles.SuspendLayout();
            this.panelForSource.SuspendLayout();
            this.panelForScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsClose)).BeginInit();
            this.splitContainerSettingsClose.Panel1.SuspendLayout();
            this.splitContainerSettingsClose.Panel2.SuspendLayout();
            this.splitContainerSettingsClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageSource);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(880, 324);
            this.tabControlSettings.TabIndex = 0;
            this.tabControlSettings.SelectedIndexChanged += new System.EventHandler(this.tabControlSettings_SelectedIndexChanged);
            // 
            // tabPageSource
            // 
            this.tabPageSource.Controls.Add(this.labelLastScanned);
            this.tabPageSource.Controls.Add(this.panelForFiles);
            this.tabPageSource.Controls.Add(this.labelForLastScanned);
            this.tabPageSource.Controls.Add(this.listViewSource);
            this.tabPageSource.Controls.Add(this.panelForSource);
            this.tabPageSource.Controls.Add(this.panelForScan);
            this.tabPageSource.Location = new System.Drawing.Point(4, 25);
            this.tabPageSource.Name = "tabPageSource";
            this.tabPageSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSource.Size = new System.Drawing.Size(872, 295);
            this.tabPageSource.TabIndex = 0;
            this.tabPageSource.Text = "Sources";
            this.tabPageSource.UseVisualStyleBackColor = true;
            this.tabPageSource.Click += new System.EventHandler(this.tabPageSource_Click);
            // 
            // labelLastScanned
            // 
            this.labelLastScanned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLastScanned.Location = new System.Drawing.Point(539, 229);
            this.labelLastScanned.Name = "labelLastScanned";
            this.labelLastScanned.Size = new System.Drawing.Size(101, 22);
            this.labelLastScanned.TabIndex = 11;
            this.labelLastScanned.Text = "labelLastScanned";
            this.labelLastScanned.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelForFiles
            // 
            this.panelForFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForFiles.Controls.Add(this.labelOtherFilesQty);
            this.panelForFiles.Controls.Add(this.labelForOtherFilesQty);
            this.panelForFiles.Controls.Add(this.labelForVideoFileQty);
            this.panelForFiles.Controls.Add(this.labelVideoFileQty);
            this.panelForFiles.Location = new System.Drawing.Point(356, 190);
            this.panelForFiles.Name = "panelForFiles";
            this.panelForFiles.Size = new System.Drawing.Size(151, 100);
            this.panelForFiles.TabIndex = 14;
            // 
            // labelOtherFilesQty
            // 
            this.labelOtherFilesQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOtherFilesQty.Location = new System.Drawing.Point(34, 67);
            this.labelOtherFilesQty.Name = "labelOtherFilesQty";
            this.labelOtherFilesQty.Size = new System.Drawing.Size(62, 22);
            this.labelOtherFilesQty.TabIndex = 1;
            this.labelOtherFilesQty.Text = "# Qty";
            this.labelOtherFilesQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelForOtherFilesQty
            // 
            this.labelForOtherFilesQty.AutoSize = true;
            this.labelForOtherFilesQty.Location = new System.Drawing.Point(18, 48);
            this.labelForOtherFilesQty.Name = "labelForOtherFilesQty";
            this.labelForOtherFilesQty.Size = new System.Drawing.Size(95, 16);
            this.labelForOtherFilesQty.TabIndex = 4;
            this.labelForOtherFilesQty.Text = "Qty Other Files";
            // 
            // labelForVideoFileQty
            // 
            this.labelForVideoFileQty.AutoSize = true;
            this.labelForVideoFileQty.Location = new System.Drawing.Point(18, 1);
            this.labelForVideoFileQty.Name = "labelForVideoFileQty";
            this.labelForVideoFileQty.Size = new System.Drawing.Size(99, 16);
            this.labelForVideoFileQty.TabIndex = 4;
            this.labelForVideoFileQty.Text = "Qty Video Files";
            // 
            // labelVideoFileQty
            // 
            this.labelVideoFileQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVideoFileQty.Location = new System.Drawing.Point(34, 20);
            this.labelVideoFileQty.Name = "labelVideoFileQty";
            this.labelVideoFileQty.Size = new System.Drawing.Size(62, 22);
            this.labelVideoFileQty.TabIndex = 1;
            this.labelVideoFileQty.Text = "# Qty";
            this.labelVideoFileQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelForLastScanned
            // 
            this.labelForLastScanned.AutoSize = true;
            this.labelForLastScanned.Location = new System.Drawing.Point(546, 209);
            this.labelForLastScanned.Name = "labelForLastScanned";
            this.labelForLastScanned.Size = new System.Drawing.Size(90, 16);
            this.labelForLastScanned.TabIndex = 10;
            this.labelForLastScanned.Text = "Last Scanned";
            // 
            // listViewSource
            // 
            this.listViewSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAlias,
            this.columnHeaderType,
            this.columnHeaderScanned});
            this.listViewSource.FullRowSelect = true;
            this.listViewSource.Location = new System.Drawing.Point(6, 6);
            this.listViewSource.Name = "listViewSource";
            this.listViewSource.Size = new System.Drawing.Size(344, 284);
            this.listViewSource.TabIndex = 3;
            this.listViewSource.UseCompatibleStateImageBehavior = false;
            this.listViewSource.View = System.Windows.Forms.View.Details;
            this.listViewSource.SelectedIndexChanged += new System.EventHandler(this.listViewSource_SelectedIndexChanged);
            // 
            // columnHeaderAlias
            // 
            this.columnHeaderAlias.Text = "Alias";
            this.columnHeaderAlias.Width = 133;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 87;
            // 
            // columnHeaderScanned
            // 
            this.columnHeaderScanned.Text = "Last Scanned";
            this.columnHeaderScanned.Width = 106;
            // 
            // panelForSource
            // 
            this.panelForSource.BackColor = System.Drawing.Color.Transparent;
            this.panelForSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForSource.Controls.Add(this.buttonSaveSource);
            this.panelForSource.Controls.Add(this.buttonSourceDirectory);
            this.panelForSource.Controls.Add(this.textBoxDirectory);
            this.panelForSource.Controls.Add(this.labelAlias);
            this.panelForSource.Controls.Add(this.labelForType);
            this.panelForSource.Controls.Add(this.labelDirectory);
            this.panelForSource.Controls.Add(this.comboBoxType);
            this.panelForSource.Controls.Add(this.buttonRemoveSource);
            this.panelForSource.Controls.Add(this.buttonAddSource);
            this.panelForSource.Controls.Add(this.textBoxAlias);
            this.panelForSource.Location = new System.Drawing.Point(356, 6);
            this.panelForSource.Name = "panelForSource";
            this.panelForSource.Size = new System.Drawing.Size(508, 178);
            this.panelForSource.TabIndex = 13;
            // 
            // buttonSaveSource
            // 
            this.buttonSaveSource.Location = new System.Drawing.Point(192, 136);
            this.buttonSaveSource.Name = "buttonSaveSource";
            this.buttonSaveSource.Size = new System.Drawing.Size(125, 23);
            this.buttonSaveSource.TabIndex = 16;
            this.buttonSaveSource.Text = "Save Source";
            this.buttonSaveSource.UseVisualStyleBackColor = true;
            this.buttonSaveSource.Click += new System.EventHandler(this.buttonSaveSource_Click);
            // 
            // buttonSourceDirectory
            // 
            this.buttonSourceDirectory.Location = new System.Drawing.Point(372, 81);
            this.buttonSourceDirectory.Name = "buttonSourceDirectory";
            this.buttonSourceDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonSourceDirectory.TabIndex = 6;
            this.buttonSourceDirectory.Text = "Browse";
            this.buttonSourceDirectory.UseVisualStyleBackColor = true;
            this.buttonSourceDirectory.Click += new System.EventHandler(this.buttonSourceBrowse_Click);
            // 
            // textBoxDirectory
            // 
            this.textBoxDirectory.Location = new System.Drawing.Point(10, 82);
            this.textBoxDirectory.Name = "textBoxDirectory";
            this.textBoxDirectory.Size = new System.Drawing.Size(347, 22);
            this.textBoxDirectory.TabIndex = 5;
            // 
            // labelAlias
            // 
            this.labelAlias.AutoSize = true;
            this.labelAlias.Location = new System.Drawing.Point(18, 12);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new System.Drawing.Size(38, 16);
            this.labelAlias.TabIndex = 1;
            this.labelAlias.Text = "Alias";
            // 
            // labelForType
            // 
            this.labelForType.AutoSize = true;
            this.labelForType.Location = new System.Drawing.Point(277, 10);
            this.labelForType.Name = "labelForType";
            this.labelForType.Size = new System.Drawing.Size(40, 16);
            this.labelForType.TabIndex = 9;
            this.labelForType.Text = "Type";
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(18, 63);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(62, 16);
            this.labelDirectory.TabIndex = 7;
            this.labelDirectory.Text = "Directory";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(267, 29);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(90, 24);
            this.comboBoxType.TabIndex = 8;
            // 
            // buttonRemoveSource
            // 
            this.buttonRemoveSource.Location = new System.Drawing.Point(372, 136);
            this.buttonRemoveSource.Name = "buttonRemoveSource";
            this.buttonRemoveSource.Size = new System.Drawing.Size(125, 23);
            this.buttonRemoveSource.TabIndex = 2;
            this.buttonRemoveSource.Text = "Remove Source";
            this.buttonRemoveSource.UseVisualStyleBackColor = true;
            this.buttonRemoveSource.Click += new System.EventHandler(this.buttonRemoveSource_Click);
            // 
            // buttonAddSource
            // 
            this.buttonAddSource.Location = new System.Drawing.Point(10, 136);
            this.buttonAddSource.Name = "buttonAddSource";
            this.buttonAddSource.Size = new System.Drawing.Size(125, 23);
            this.buttonAddSource.TabIndex = 1;
            this.buttonAddSource.Text = "New Source";
            this.buttonAddSource.UseVisualStyleBackColor = true;
            this.buttonAddSource.Click += new System.EventHandler(this.buttonAddSource_Click);
            // 
            // textBoxAlias
            // 
            this.textBoxAlias.Location = new System.Drawing.Point(10, 31);
            this.textBoxAlias.Name = "textBoxAlias";
            this.textBoxAlias.Size = new System.Drawing.Size(242, 22);
            this.textBoxAlias.TabIndex = 4;
            // 
            // panelForScan
            // 
            this.panelForScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForScan.Controls.Add(this.buttonScanSource);
            this.panelForScan.Controls.Add(this.subFormProgressOptions);
            this.panelForScan.Location = new System.Drawing.Point(513, 190);
            this.panelForScan.Name = "panelForScan";
            this.panelForScan.Size = new System.Drawing.Size(351, 100);
            this.panelForScan.TabIndex = 17;
            // 
            // buttonScanSource
            // 
            this.buttonScanSource.Location = new System.Drawing.Point(179, 73);
            this.buttonScanSource.Name = "buttonScanSource";
            this.buttonScanSource.Size = new System.Drawing.Size(125, 23);
            this.buttonScanSource.TabIndex = 12;
            this.buttonScanSource.Text = "Scan";
            this.buttonScanSource.UseVisualStyleBackColor = true;
            this.buttonScanSource.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // subFormProgressOptions
            // 
            this.subFormProgressOptions.Location = new System.Drawing.Point(149, 5);
            this.subFormProgressOptions.Margin = new System.Windows.Forms.Padding(0);
            this.subFormProgressOptions.MinimumSize = new System.Drawing.Size(160, 60);
            this.subFormProgressOptions.Name = "subFormProgressOptions";
            this.subFormProgressOptions.Size = new System.Drawing.Size(192, 65);
            this.subFormProgressOptions.TabIndex = 16;
            // 
            // splitContainerSettingsClose
            // 
            this.splitContainerSettingsClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSettingsClose.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSettingsClose.Name = "splitContainerSettingsClose";
            this.splitContainerSettingsClose.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSettingsClose.Panel1
            // 
            this.splitContainerSettingsClose.Panel1.Controls.Add(this.tabControlSettings);
            // 
            // splitContainerSettingsClose.Panel2
            // 
            this.splitContainerSettingsClose.Panel2.Controls.Add(this.buttonClose);
            this.splitContainerSettingsClose.Size = new System.Drawing.Size(880, 367);
            this.splitContainerSettingsClose.SplitterDistance = 324;
            this.splitContainerSettingsClose.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(414, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormSources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 367);
            this.Controls.Add(this.splitContainerSettingsClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSources";
            this.Text = "Sources";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSources_FormClosing);
            this.Load += new System.EventHandler(this.FormSources_Load);
            this.Shown += new System.EventHandler(this.FormSources_Shown);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageSource.ResumeLayout(false);
            this.tabPageSource.PerformLayout();
            this.panelForFiles.ResumeLayout(false);
            this.panelForFiles.PerformLayout();
            this.panelForSource.ResumeLayout(false);
            this.panelForSource.PerformLayout();
            this.panelForScan.ResumeLayout(false);
            this.splitContainerSettingsClose.Panel1.ResumeLayout(false);
            this.splitContainerSettingsClose.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsClose)).EndInit();
            this.splitContainerSettingsClose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageSource;
        private System.Windows.Forms.Button buttonRemoveSource;
        private System.Windows.Forms.Button buttonAddSource;
        private System.Windows.Forms.ListView listViewSource;
        private System.Windows.Forms.ColumnHeader columnHeaderAlias;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderScanned;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Label labelAlias;
        private System.Windows.Forms.Button buttonSourceDirectory;
        private System.Windows.Forms.TextBox textBoxDirectory;
        private System.Windows.Forms.TextBox textBoxAlias;
        private System.Windows.Forms.SplitContainer splitContainerSettingsClose;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelForType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelForLastScanned;
        private System.Windows.Forms.Label labelLastScanned;
        private System.Windows.Forms.Label labelForOtherFilesQty;
        private System.Windows.Forms.Label labelOtherFilesQty;
        private System.Windows.Forms.Panel panelForFiles;
        private System.Windows.Forms.Label labelForVideoFileQty;
        private System.Windows.Forms.Label labelVideoFileQty;
        private System.Windows.Forms.Panel panelForSource;
        private System.Windows.Forms.Button buttonScanSource;
        private System.Windows.Forms.Button buttonSaveSource;
        private SubFormProgress subFormProgressOptions;
        private System.Windows.Forms.Panel panelForScan;

    }
}