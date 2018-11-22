namespace MyVideoExplorer
{
    partial class FormOptions
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
            this.tabPageMetaData = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.labelForWatchedExtra = new System.Windows.Forms.Label();
            this.linkLabelMVE = new System.Windows.Forms.LinkLabel();
            this.labelForMVE = new System.Windows.Forms.Label();
            this.linkLabelMB = new System.Windows.Forms.LinkLabel();
            this.labelForMB = new System.Windows.Forms.Label();
            this.checkBoxCreateMB = new System.Windows.Forms.CheckBox();
            this.checkBoxUpdateMB = new System.Windows.Forms.CheckBox();
            this.linkLabelXBMC = new System.Windows.Forms.LinkLabel();
            this.labelForXBMC = new System.Windows.Forms.Label();
            this.checkBoxCreateXBMC = new System.Windows.Forms.CheckBox();
            this.labelForUpdateVIdeoInfo = new System.Windows.Forms.Label();
            this.checkBoxUpdateXBMC = new System.Windows.Forms.CheckBox();
            this.checkBoxMarkWatched = new System.Windows.Forms.CheckBox();
            this.panelForUpdateVideoInfo = new System.Windows.Forms.Panel();
            this.labelForWatchedAfterMinutes = new System.Windows.Forms.Label();
            this.checkBoxCreateMVE = new System.Windows.Forms.CheckBox();
            this.comboBoxWatchedAfter = new System.Windows.Forms.ComboBox();
            this.tabPageExternal = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelForExternalProgram = new System.Windows.Forms.Label();
            this.panelForExternalProgram = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelFFProbeStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelForFFProbePath = new System.Windows.Forms.Label();
            this.labelForFFProbeInfo = new System.Windows.Forms.Label();
            this.labelForFFProbeDownload = new System.Windows.Forms.Label();
            this.tabPageGallery = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.labelForGalleryCache = new System.Windows.Forms.Label();
            this.panelForGalleryCache = new System.Windows.Forms.Panel();
            this.buttonEmptyGalleryCache = new System.Windows.Forms.Button();
            this.checkBoxEnableGalleryCache = new System.Windows.Forms.CheckBox();
            this.labelForGalleryCacheSize = new System.Windows.Forms.Label();
            this.labelForGalleryCacheDir = new System.Windows.Forms.Label();
            this.labelForGalleryCacheDescription = new System.Windows.Forms.Label();
            this.labelForGallery = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxEnableGallery = new System.Windows.Forms.CheckBox();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.labelGalleryBackColor = new System.Windows.Forms.Label();
            this.labelForBackgroundColor = new System.Windows.Forms.Label();
            this.splitContainerSettingsClose = new System.Windows.Forms.SplitContainer();
            this.buttonClose = new System.Windows.Forms.Button();
            this.colorDialogGalleryBackColor = new System.Windows.Forms.ColorDialog();
            this.tabControlSettings.SuspendLayout();
            this.tabPageMetaData.SuspendLayout();
            this.panelForUpdateVideoInfo.SuspendLayout();
            this.tabPageExternal.SuspendLayout();
            this.panelForExternalProgram.SuspendLayout();
            this.tabPageGallery.SuspendLayout();
            this.panelForGalleryCache.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsClose)).BeginInit();
            this.splitContainerSettingsClose.Panel1.SuspendLayout();
            this.splitContainerSettingsClose.Panel2.SuspendLayout();
            this.splitContainerSettingsClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageMetaData);
            this.tabControlSettings.Controls.Add(this.tabPageExternal);
            this.tabControlSettings.Controls.Add(this.tabPageGallery);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(880, 324);
            this.tabControlSettings.TabIndex = 0;
            this.tabControlSettings.SelectedIndexChanged += new System.EventHandler(this.tabControlSettings_SelectedIndexChanged);
            // 
            // tabPageMetaData
            // 
            this.tabPageMetaData.Controls.Add(this.label7);
            this.tabPageMetaData.Controls.Add(this.labelForWatchedExtra);
            this.tabPageMetaData.Controls.Add(this.linkLabelMVE);
            this.tabPageMetaData.Controls.Add(this.labelForMVE);
            this.tabPageMetaData.Controls.Add(this.linkLabelMB);
            this.tabPageMetaData.Controls.Add(this.labelForMB);
            this.tabPageMetaData.Controls.Add(this.checkBoxCreateMB);
            this.tabPageMetaData.Controls.Add(this.checkBoxUpdateMB);
            this.tabPageMetaData.Controls.Add(this.linkLabelXBMC);
            this.tabPageMetaData.Controls.Add(this.labelForXBMC);
            this.tabPageMetaData.Controls.Add(this.checkBoxCreateXBMC);
            this.tabPageMetaData.Controls.Add(this.labelForUpdateVIdeoInfo);
            this.tabPageMetaData.Controls.Add(this.checkBoxUpdateXBMC);
            this.tabPageMetaData.Controls.Add(this.checkBoxMarkWatched);
            this.tabPageMetaData.Controls.Add(this.panelForUpdateVideoInfo);
            this.tabPageMetaData.Location = new System.Drawing.Point(4, 25);
            this.tabPageMetaData.Name = "tabPageMetaData";
            this.tabPageMetaData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMetaData.Size = new System.Drawing.Size(872, 295);
            this.tabPageMetaData.TabIndex = 1;
            this.tabPageMetaData.Text = "Meta Data";
            this.tabPageMetaData.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(599, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 32);
            this.label7.TabIndex = 20;
            this.label7.Text = "This space intentionally left blank.\r\nMaybe, other settings will arrive later.";
            // 
            // labelForWatchedExtra
            // 
            this.labelForWatchedExtra.AutoSize = true;
            this.labelForWatchedExtra.Location = new System.Drawing.Point(66, 79);
            this.labelForWatchedExtra.Name = "labelForWatchedExtra";
            this.labelForWatchedExtra.Size = new System.Drawing.Size(139, 16);
            this.labelForWatchedExtra.TabIndex = 11;
            this.labelForWatchedExtra.Text = "if played for more than";
            // 
            // linkLabelMVE
            // 
            this.linkLabelMVE.AutoSize = true;
            this.linkLabelMVE.Location = new System.Drawing.Point(58, 37);
            this.linkLabelMVE.Name = "linkLabelMVE";
            this.linkLabelMVE.Size = new System.Drawing.Size(200, 16);
            this.linkLabelMVE.TabIndex = 10;
            this.linkLabelMVE.TabStop = true;
            this.linkLabelMVE.Text = "http://www.myvideoexplorer.com";
            this.linkLabelMVE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMVE_LinkClicked);
            // 
            // labelForMVE
            // 
            this.labelForMVE.AutoSize = true;
            this.labelForMVE.Location = new System.Drawing.Point(15, 37);
            this.labelForMVE.Name = "labelForMVE";
            this.labelForMVE.Size = new System.Drawing.Size(37, 16);
            this.labelForMVE.TabIndex = 9;
            this.labelForMVE.Text = "MVE";
            // 
            // linkLabelMB
            // 
            this.linkLabelMB.AutoSize = true;
            this.linkLabelMB.Location = new System.Drawing.Point(58, 203);
            this.linkLabelMB.Name = "linkLabelMB";
            this.linkLabelMB.Size = new System.Drawing.Size(143, 16);
            this.linkLabelMB.TabIndex = 3;
            this.linkLabelMB.TabStop = true;
            this.linkLabelMB.Text = "http://mediabrowser.tv/";
            this.linkLabelMB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMB_LinkClicked);
            // 
            // labelForMB
            // 
            this.labelForMB.AutoSize = true;
            this.labelForMB.Location = new System.Drawing.Point(15, 205);
            this.labelForMB.Name = "labelForMB";
            this.labelForMB.Size = new System.Drawing.Size(28, 16);
            this.labelForMB.TabIndex = 4;
            this.labelForMB.Text = "MB";
            // 
            // checkBoxCreateMB
            // 
            this.checkBoxCreateMB.AutoSize = true;
            this.checkBoxCreateMB.Location = new System.Drawing.Point(39, 250);
            this.checkBoxCreateMB.Name = "checkBoxCreateMB";
            this.checkBoxCreateMB.Size = new System.Drawing.Size(262, 20);
            this.checkBoxCreateMB.TabIndex = 8;
            this.checkBoxCreateMB.Text = "Create MB movie.xml, if it does not exist";
            this.checkBoxCreateMB.UseVisualStyleBackColor = true;
            this.checkBoxCreateMB.CheckedChanged += new System.EventHandler(this.checkBoxCreateMB_CheckedChanged);
            // 
            // checkBoxUpdateMB
            // 
            this.checkBoxUpdateMB.AutoSize = true;
            this.checkBoxUpdateMB.Location = new System.Drawing.Point(39, 224);
            this.checkBoxUpdateMB.Name = "checkBoxUpdateMB";
            this.checkBoxUpdateMB.Size = new System.Drawing.Size(258, 20);
            this.checkBoxUpdateMB.TabIndex = 7;
            this.checkBoxUpdateMB.Text = "Update existing MB movie.xml, if exists";
            this.checkBoxUpdateMB.UseVisualStyleBackColor = true;
            this.checkBoxUpdateMB.CheckedChanged += new System.EventHandler(this.checkBoxUpdateMB_CheckedChanged);
            // 
            // linkLabelXBMC
            // 
            this.linkLabelXBMC.AutoSize = true;
            this.linkLabelXBMC.Location = new System.Drawing.Point(58, 129);
            this.linkLabelXBMC.Name = "linkLabelXBMC";
            this.linkLabelXBMC.Size = new System.Drawing.Size(99, 16);
            this.linkLabelXBMC.TabIndex = 0;
            this.linkLabelXBMC.TabStop = true;
            this.linkLabelXBMC.Text = "http://xbmc.org/";
            this.linkLabelXBMC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelXBMC_LinkClicked);
            // 
            // labelForXBMC
            // 
            this.labelForXBMC.AutoSize = true;
            this.labelForXBMC.Location = new System.Drawing.Point(15, 129);
            this.labelForXBMC.Name = "labelForXBMC";
            this.labelForXBMC.Size = new System.Drawing.Size(45, 16);
            this.labelForXBMC.TabIndex = 1;
            this.labelForXBMC.Text = "XBMC";
            // 
            // checkBoxCreateXBMC
            // 
            this.checkBoxCreateXBMC.AutoSize = true;
            this.checkBoxCreateXBMC.Location = new System.Drawing.Point(39, 178);
            this.checkBoxCreateXBMC.Name = "checkBoxCreateXBMC";
            this.checkBoxCreateXBMC.Size = new System.Drawing.Size(277, 20);
            this.checkBoxCreateXBMC.TabIndex = 6;
            this.checkBoxCreateXBMC.Text = "Create XBMC movie.nfo, if it does not exist";
            this.checkBoxCreateXBMC.UseVisualStyleBackColor = true;
            this.checkBoxCreateXBMC.CheckedChanged += new System.EventHandler(this.checkBoxCreateXBMC_CheckedChanged);
            // 
            // labelForUpdateVIdeoInfo
            // 
            this.labelForUpdateVIdeoInfo.AutoSize = true;
            this.labelForUpdateVIdeoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.985075F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForUpdateVIdeoInfo.Location = new System.Drawing.Point(15, 14);
            this.labelForUpdateVIdeoInfo.Name = "labelForUpdateVIdeoInfo";
            this.labelForUpdateVIdeoInfo.Size = new System.Drawing.Size(239, 17);
            this.labelForUpdateVIdeoInfo.TabIndex = 5;
            this.labelForUpdateVIdeoInfo.Text = "When update video information:";
            // 
            // checkBoxUpdateXBMC
            // 
            this.checkBoxUpdateXBMC.AutoSize = true;
            this.checkBoxUpdateXBMC.Location = new System.Drawing.Point(39, 152);
            this.checkBoxUpdateXBMC.Name = "checkBoxUpdateXBMC";
            this.checkBoxUpdateXBMC.Size = new System.Drawing.Size(273, 20);
            this.checkBoxUpdateXBMC.TabIndex = 5;
            this.checkBoxUpdateXBMC.Text = "Update existing XBMC movie.nfo, if exists";
            this.checkBoxUpdateXBMC.UseVisualStyleBackColor = true;
            this.checkBoxUpdateXBMC.CheckedChanged += new System.EventHandler(this.checkBoxUpdateXBMC_CheckedChanged);
            // 
            // checkBoxMarkWatched
            // 
            this.checkBoxMarkWatched.AutoSize = true;
            this.checkBoxMarkWatched.Location = new System.Drawing.Point(39, 56);
            this.checkBoxMarkWatched.Name = "checkBoxMarkWatched";
            this.checkBoxMarkWatched.Size = new System.Drawing.Size(472, 20);
            this.checkBoxMarkWatched.TabIndex = 0;
            this.checkBoxMarkWatched.Text = "After playing video, auto mark video as Watched and increment Play Count";
            this.checkBoxMarkWatched.UseVisualStyleBackColor = true;
            this.checkBoxMarkWatched.CheckedChanged += new System.EventHandler(this.checkBoxMarkWatched_CheckedChanged);
            // 
            // panelForUpdateVideoInfo
            // 
            this.panelForUpdateVideoInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForUpdateVideoInfo.Controls.Add(this.labelForWatchedAfterMinutes);
            this.panelForUpdateVideoInfo.Controls.Add(this.checkBoxCreateMVE);
            this.panelForUpdateVideoInfo.Controls.Add(this.comboBoxWatchedAfter);
            this.panelForUpdateVideoInfo.Location = new System.Drawing.Point(8, 33);
            this.panelForUpdateVideoInfo.Name = "panelForUpdateVideoInfo";
            this.panelForUpdateVideoInfo.Size = new System.Drawing.Size(509, 245);
            this.panelForUpdateVideoInfo.TabIndex = 19;
            // 
            // labelForWatchedAfterMinutes
            // 
            this.labelForWatchedAfterMinutes.AutoSize = true;
            this.labelForWatchedAfterMinutes.Location = new System.Drawing.Point(249, 45);
            this.labelForWatchedAfterMinutes.Name = "labelForWatchedAfterMinutes";
            this.labelForWatchedAfterMinutes.Size = new System.Drawing.Size(54, 16);
            this.labelForWatchedAfterMinutes.TabIndex = 3;
            this.labelForWatchedAfterMinutes.Text = "Minutes";
            // 
            // checkBoxCreateMVE
            // 
            this.checkBoxCreateMVE.AutoSize = true;
            this.checkBoxCreateMVE.Location = new System.Drawing.Point(30, 67);
            this.checkBoxCreateMVE.Name = "checkBoxCreateMVE";
            this.checkBoxCreateMVE.Size = new System.Drawing.Size(347, 20);
            this.checkBoxCreateMVE.TabIndex = 2;
            this.checkBoxCreateMVE.Text = "Store video meta information per video as movie.mve";
            this.checkBoxCreateMVE.UseVisualStyleBackColor = true;
            this.checkBoxCreateMVE.CheckedChanged += new System.EventHandler(this.checkBoxCreateMVE_CheckedChanged);
            // 
            // comboBoxWatchedAfter
            // 
            this.comboBoxWatchedAfter.FormattingEnabled = true;
            this.comboBoxWatchedAfter.Location = new System.Drawing.Point(196, 42);
            this.comboBoxWatchedAfter.Name = "comboBoxWatchedAfter";
            this.comboBoxWatchedAfter.Size = new System.Drawing.Size(49, 24);
            this.comboBoxWatchedAfter.TabIndex = 1;
            this.comboBoxWatchedAfter.SelectedIndexChanged += new System.EventHandler(this.comboBoxWatchedAfter_SelectedIndexChanged);
            // 
            // tabPageExternal
            // 
            this.tabPageExternal.Controls.Add(this.label1);
            this.tabPageExternal.Controls.Add(this.label8);
            this.tabPageExternal.Controls.Add(this.labelForExternalProgram);
            this.tabPageExternal.Controls.Add(this.panelForExternalProgram);
            this.tabPageExternal.Location = new System.Drawing.Point(4, 25);
            this.tabPageExternal.Name = "tabPageExternal";
            this.tabPageExternal.Size = new System.Drawing.Size(872, 295);
            this.tabPageExternal.TabIndex = 2;
            this.tabPageExternal.Text = "External";
            this.tabPageExternal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 32);
            this.label1.TabIndex = 24;
            this.label1.Text = "Note: FFProbe may crash on invalid video files.\r\nAlways try the latest version of" +
    " FFProbe.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(494, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 32);
            this.label8.TabIndex = 23;
            this.label8.Text = "This space intentionally left blank.\r\nMaybe, other settings will arrive later.";
            // 
            // labelForExternalProgram
            // 
            this.labelForExternalProgram.AutoSize = true;
            this.labelForExternalProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.985075F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForExternalProgram.Location = new System.Drawing.Point(11, 16);
            this.labelForExternalProgram.Name = "labelForExternalProgram";
            this.labelForExternalProgram.Size = new System.Drawing.Size(141, 17);
            this.labelForExternalProgram.TabIndex = 21;
            this.labelForExternalProgram.Text = "External Programs";
            // 
            // panelForExternalProgram
            // 
            this.panelForExternalProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForExternalProgram.Controls.Add(this.linkLabel1);
            this.panelForExternalProgram.Controls.Add(this.labelFFProbeStatus);
            this.panelForExternalProgram.Controls.Add(this.label3);
            this.panelForExternalProgram.Controls.Add(this.labelForFFProbePath);
            this.panelForExternalProgram.Controls.Add(this.labelForFFProbeInfo);
            this.panelForExternalProgram.Controls.Add(this.labelForFFProbeDownload);
            this.panelForExternalProgram.Location = new System.Drawing.Point(8, 35);
            this.panelForExternalProgram.Name = "panelForExternalProgram";
            this.panelForExternalProgram.Size = new System.Drawing.Size(321, 188);
            this.panelForExternalProgram.TabIndex = 22;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(70, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(138, 16);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.ffmpeg.org/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelFFProbeStatus
            // 
            this.labelFFProbeStatus.AutoSize = true;
            this.labelFFProbeStatus.Location = new System.Drawing.Point(203, 159);
            this.labelFFProbeStatus.Name = "labelFFProbeStatus";
            this.labelFFProbeStatus.Size = new System.Drawing.Size(78, 16);
            this.labelFFProbeStatus.TabIndex = 17;
            this.labelFFProbeStatus.Text = "Not Present";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "FFProbe";
            // 
            // labelForFFProbePath
            // 
            this.labelForFFProbePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelForFFProbePath.Location = new System.Drawing.Point(18, 158);
            this.labelForFFProbePath.Name = "labelForFFProbePath";
            this.labelForFFProbePath.Size = new System.Drawing.Size(179, 23);
            this.labelForFFProbePath.TabIndex = 16;
            this.labelForFFProbePath.Text = "libs/ffmpeg/bin/ffprobe.exe";
            // 
            // labelForFFProbeInfo
            // 
            this.labelForFFProbeInfo.Location = new System.Drawing.Point(15, 24);
            this.labelForFFProbeInfo.Name = "labelForFFProbeInfo";
            this.labelForFFProbeInfo.Size = new System.Drawing.Size(279, 74);
            this.labelForFFProbeInfo.TabIndex = 14;
            this.labelForFFProbeInfo.Text = "ffprobe, which is part of the open source project ffmpeg, can be used to scan you" +
    "r video files for additional information; such as width, height, codec, and bitr" +
    "ate.";
            // 
            // labelForFFProbeDownload
            // 
            this.labelForFFProbeDownload.Location = new System.Drawing.Point(15, 96);
            this.labelForFFProbeDownload.Name = "labelForFFProbeDownload";
            this.labelForFFProbeDownload.Size = new System.Drawing.Size(262, 62);
            this.labelForFFProbeDownload.TabIndex = 15;
            this.labelForFFProbeDownload.Text = "Download the latest ffmpeg for windows, extract and place in your MVE install dir" +
    "ectory as libs/ffmpeg";
            // 
            // tabPageGallery
            // 
            this.tabPageGallery.Controls.Add(this.label10);
            this.tabPageGallery.Controls.Add(this.labelForGalleryCache);
            this.tabPageGallery.Controls.Add(this.panelForGalleryCache);
            this.tabPageGallery.Controls.Add(this.labelForGallery);
            this.tabPageGallery.Controls.Add(this.panel1);
            this.tabPageGallery.Location = new System.Drawing.Point(4, 25);
            this.tabPageGallery.Name = "tabPageGallery";
            this.tabPageGallery.Size = new System.Drawing.Size(872, 295);
            this.tabPageGallery.TabIndex = 3;
            this.tabPageGallery.Text = "Gallery";
            this.tabPageGallery.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(493, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 32);
            this.label10.TabIndex = 23;
            this.label10.Text = "This space intentionally left blank.\r\nMaybe, other settings will arrive later.";
            // 
            // labelForGalleryCache
            // 
            this.labelForGalleryCache.AutoSize = true;
            this.labelForGalleryCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.985075F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForGalleryCache.Location = new System.Drawing.Point(14, 124);
            this.labelForGalleryCache.Name = "labelForGalleryCache";
            this.labelForGalleryCache.Size = new System.Drawing.Size(110, 17);
            this.labelForGalleryCache.TabIndex = 23;
            this.labelForGalleryCache.Text = "Gallery Cache";
            // 
            // panelForGalleryCache
            // 
            this.panelForGalleryCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForGalleryCache.Controls.Add(this.buttonEmptyGalleryCache);
            this.panelForGalleryCache.Controls.Add(this.checkBoxEnableGalleryCache);
            this.panelForGalleryCache.Controls.Add(this.labelForGalleryCacheSize);
            this.panelForGalleryCache.Controls.Add(this.labelForGalleryCacheDir);
            this.panelForGalleryCache.Controls.Add(this.labelForGalleryCacheDescription);
            this.panelForGalleryCache.Location = new System.Drawing.Point(7, 144);
            this.panelForGalleryCache.Name = "panelForGalleryCache";
            this.panelForGalleryCache.Size = new System.Drawing.Size(302, 148);
            this.panelForGalleryCache.TabIndex = 22;
            // 
            // buttonEmptyGalleryCache
            // 
            this.buttonEmptyGalleryCache.Location = new System.Drawing.Point(210, 111);
            this.buttonEmptyGalleryCache.Name = "buttonEmptyGalleryCache";
            this.buttonEmptyGalleryCache.Size = new System.Drawing.Size(75, 23);
            this.buttonEmptyGalleryCache.TabIndex = 4;
            this.buttonEmptyGalleryCache.Text = "Empty";
            this.buttonEmptyGalleryCache.UseVisualStyleBackColor = true;
            this.buttonEmptyGalleryCache.Click += new System.EventHandler(this.buttonEmptyGalleryCache_Click);
            // 
            // checkBoxEnableGalleryCache
            // 
            this.checkBoxEnableGalleryCache.AutoSize = true;
            this.checkBoxEnableGalleryCache.Location = new System.Drawing.Point(12, 12);
            this.checkBoxEnableGalleryCache.Name = "checkBoxEnableGalleryCache";
            this.checkBoxEnableGalleryCache.Size = new System.Drawing.Size(161, 20);
            this.checkBoxEnableGalleryCache.TabIndex = 3;
            this.checkBoxEnableGalleryCache.Text = "Enable Gallery Cache";
            this.checkBoxEnableGalleryCache.UseVisualStyleBackColor = true;
            // 
            // labelForGalleryCacheSize
            // 
            this.labelForGalleryCacheSize.AutoSize = true;
            this.labelForGalleryCacheSize.Location = new System.Drawing.Point(118, 114);
            this.labelForGalleryCacheSize.Name = "labelForGalleryCacheSize";
            this.labelForGalleryCacheSize.Size = new System.Drawing.Size(72, 16);
            this.labelForGalleryCacheSize.TabIndex = 2;
            this.labelForGalleryCacheSize.Text = "cache size";
            // 
            // labelForGalleryCacheDir
            // 
            this.labelForGalleryCacheDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelForGalleryCacheDir.Location = new System.Drawing.Point(12, 113);
            this.labelForGalleryCacheDir.Name = "labelForGalleryCacheDir";
            this.labelForGalleryCacheDir.Size = new System.Drawing.Size(100, 23);
            this.labelForGalleryCacheDir.TabIndex = 1;
            this.labelForGalleryCacheDir.Text = "cache/gallery";
            // 
            // labelForGalleryCacheDescription
            // 
            this.labelForGalleryCacheDescription.Location = new System.Drawing.Point(9, 41);
            this.labelForGalleryCacheDescription.Name = "labelForGalleryCacheDescription";
            this.labelForGalleryCacheDescription.Size = new System.Drawing.Size(289, 74);
            this.labelForGalleryCacheDescription.TabIndex = 0;
            this.labelForGalleryCacheDescription.Text = "The Gallery uses posters from your video library, if available, so you can visual" +
    "ly browse your videos.  For faster loading, posters can be resized and cached.";
            // 
            // labelForGallery
            // 
            this.labelForGallery.AutoSize = true;
            this.labelForGallery.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.985075F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForGallery.Location = new System.Drawing.Point(14, 17);
            this.labelForGallery.Name = "labelForGallery";
            this.labelForGallery.Size = new System.Drawing.Size(139, 17);
            this.labelForGallery.TabIndex = 20;
            this.labelForGallery.Text = "Gallery of Posters";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxEnableGallery);
            this.panel1.Controls.Add(this.buttonBackColor);
            this.panel1.Controls.Add(this.labelGalleryBackColor);
            this.panel1.Controls.Add(this.labelForBackgroundColor);
            this.panel1.Location = new System.Drawing.Point(7, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 75);
            this.panel1.TabIndex = 21;
            // 
            // checkBoxEnableGallery
            // 
            this.checkBoxEnableGallery.AutoSize = true;
            this.checkBoxEnableGallery.Location = new System.Drawing.Point(9, 12);
            this.checkBoxEnableGallery.Name = "checkBoxEnableGallery";
            this.checkBoxEnableGallery.Size = new System.Drawing.Size(119, 20);
            this.checkBoxEnableGallery.TabIndex = 24;
            this.checkBoxEnableGallery.Text = "Enable Gallery";
            this.checkBoxEnableGallery.UseVisualStyleBackColor = true;
            this.checkBoxEnableGallery.CheckedChanged += new System.EventHandler(this.checkBoxEnableGallery_CheckedChanged);
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(207, 41);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(75, 23);
            this.buttonBackColor.TabIndex = 2;
            this.buttonBackColor.Text = "Pick";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // labelGalleryBackColor
            // 
            this.labelGalleryBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelGalleryBackColor.Location = new System.Drawing.Point(128, 41);
            this.labelGalleryBackColor.Name = "labelGalleryBackColor";
            this.labelGalleryBackColor.Size = new System.Drawing.Size(73, 23);
            this.labelGalleryBackColor.TabIndex = 1;
            this.labelGalleryBackColor.Text = "back color";
            this.labelGalleryBackColor.Click += new System.EventHandler(this.labelGalleryBackColor_Click);
            // 
            // labelForBackgroundColor
            // 
            this.labelForBackgroundColor.AutoSize = true;
            this.labelForBackgroundColor.Location = new System.Drawing.Point(6, 44);
            this.labelForBackgroundColor.Name = "labelForBackgroundColor";
            this.labelForBackgroundColor.Size = new System.Drawing.Size(116, 16);
            this.labelForBackgroundColor.TabIndex = 0;
            this.labelForBackgroundColor.Text = "Background Color";
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
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 367);
            this.Controls.Add(this.splitContainerSettingsClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormOptions";
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptions_FormClosing);
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.Shown += new System.EventHandler(this.FormOptions_Shown);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageMetaData.ResumeLayout(false);
            this.tabPageMetaData.PerformLayout();
            this.panelForUpdateVideoInfo.ResumeLayout(false);
            this.panelForUpdateVideoInfo.PerformLayout();
            this.tabPageExternal.ResumeLayout(false);
            this.tabPageExternal.PerformLayout();
            this.panelForExternalProgram.ResumeLayout(false);
            this.panelForExternalProgram.PerformLayout();
            this.tabPageGallery.ResumeLayout(false);
            this.tabPageGallery.PerformLayout();
            this.panelForGalleryCache.ResumeLayout(false);
            this.panelForGalleryCache.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainerSettingsClose.Panel1.ResumeLayout(false);
            this.splitContainerSettingsClose.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsClose)).EndInit();
            this.splitContainerSettingsClose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.SplitContainer splitContainerSettingsClose;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TabPage tabPageMetaData;
        private System.Windows.Forms.Label labelForWatchedExtra;
        private System.Windows.Forms.LinkLabel linkLabelMVE;
        private System.Windows.Forms.Label labelForMVE;
        private System.Windows.Forms.LinkLabel linkLabelMB;
        private System.Windows.Forms.Label labelForMB;
        private System.Windows.Forms.CheckBox checkBoxCreateMB;
        private System.Windows.Forms.CheckBox checkBoxUpdateMB;
        private System.Windows.Forms.LinkLabel linkLabelXBMC;
        private System.Windows.Forms.Label labelForXBMC;
        private System.Windows.Forms.CheckBox checkBoxCreateXBMC;
        private System.Windows.Forms.Label labelForUpdateVIdeoInfo;
        private System.Windows.Forms.CheckBox checkBoxUpdateXBMC;
        private System.Windows.Forms.ComboBox comboBoxWatchedAfter;
        private System.Windows.Forms.CheckBox checkBoxMarkWatched;
        private System.Windows.Forms.Panel panelForUpdateVideoInfo;
        private System.Windows.Forms.CheckBox checkBoxCreateMVE;
        private System.Windows.Forms.Label labelForWatchedAfterMinutes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPageExternal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelForExternalProgram;
        private System.Windows.Forms.Panel panelForExternalProgram;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelFFProbeStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelForFFProbePath;
        private System.Windows.Forms.Label labelForFFProbeInfo;
        private System.Windows.Forms.Label labelForFFProbeDownload;
        private System.Windows.Forms.TabPage tabPageGallery;
        private System.Windows.Forms.Label labelForGallery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Label labelGalleryBackColor;
        private System.Windows.Forms.Label labelForBackgroundColor;
        private System.Windows.Forms.ColorDialog colorDialogGalleryBackColor;
        private System.Windows.Forms.Label labelForGalleryCache;
        private System.Windows.Forms.Panel panelForGalleryCache;
        private System.Windows.Forms.CheckBox checkBoxEnableGalleryCache;
        private System.Windows.Forms.Label labelForGalleryCacheSize;
        private System.Windows.Forms.Label labelForGalleryCacheDir;
        private System.Windows.Forms.Label labelForGalleryCacheDescription;
        private System.Windows.Forms.Button buttonEmptyGalleryCache;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxEnableGallery;

    }
}