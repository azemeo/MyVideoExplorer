namespace MyVideoExplorer
{
    partial class SubFormVideoForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.linkLabelBing = new System.Windows.Forms.LinkLabel();
            this.labelForYear = new System.Windows.Forms.Label();
            this.labelForPlot = new System.Windows.Forms.Label();
            this.tabControlTitle = new System.Windows.Forms.TabControl();
            this.tabPageTitle = new System.Windows.Forms.TabPage();
            this.tabPageMovieSet = new System.Windows.Forms.TabPage();
            this.textBoxMovieSet = new System.Windows.Forms.TextBox();
            this.linkLabelIMDB = new System.Windows.Forms.LinkLabel();
            this.linkLabelTMDB = new System.Windows.Forms.LinkLabel();
            this.comboBoxIMDBRating = new System.Windows.Forms.ComboBox();
            this.comboBoxMPAA = new System.Windows.Forms.ComboBox();
            this.textBoxRunTime = new System.Windows.Forms.TextBox();
            this.checkBoxWatched = new System.Windows.Forms.CheckBox();
            this.comboBoxPlayCount = new System.Windows.Forms.ComboBox();
            this.comboBoxRating = new System.Windows.Forms.ComboBox();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.labelForLastPlayed = new System.Windows.Forms.Label();
            this.labelLastPlayed = new System.Windows.Forms.Label();
            this.labelForUpdated = new System.Windows.Forms.Label();
            this.labelUpdated = new System.Windows.Forms.Label();
            this.labelFroIMDBRating = new System.Windows.Forms.Label();
            this.labelForRating = new System.Windows.Forms.Label();
            this.labelForRunTime = new System.Windows.Forms.Label();
            this.labelForMPAA = new System.Windows.Forms.Label();
            this.labelForSource = new System.Windows.Forms.Label();
            this.labelForplayCount = new System.Windows.Forms.Label();
            this.labelForNotes = new System.Windows.Forms.Label();
            this.linkLabelGoogle = new System.Windows.Forms.LinkLabel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxIMDB = new System.Windows.Forms.TextBox();
            this.textBoxTMDB = new System.Windows.Forms.TextBox();
            this.labelForTags = new System.Windows.Forms.Label();
            this.dataGridViewActors = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelForGenre = new System.Windows.Forms.Label();
            this.labelForActors = new System.Windows.Forms.Label();
            this.labelForRole = new System.Windows.Forms.Label();
            this.dataGridViewTags = new System.Windows.Forms.DataGridView();
            this.ColumnTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewGenres = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumnGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelForVersion = new System.Windows.Forms.Label();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.linkLabelRT = new System.Windows.Forms.LinkLabel();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelForWidth = new System.Windows.Forms.Label();
            this.labelForHeight = new System.Windows.Forms.Label();
            this.labelForBitrate = new System.Windows.Forms.Label();
            this.textBoxBitrate = new System.Windows.Forms.TextBox();
            this.labelForBitrateFormatted = new System.Windows.Forms.Label();
            this.labelForCodec = new System.Windows.Forms.Label();
            this.comboBoxCodec = new System.Windows.Forms.ComboBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.labelForUPC = new System.Windows.Forms.Label();
            this.textBoxUPC = new System.Windows.Forms.TextBox();
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.richTextBoxPlot = new System.Windows.Forms.RichTextBox();
            this.tabControlTitle.SuspendLayout();
            this.tabPageTitle.SuspendLayout();
            this.tabPageMovieSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenres)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTitle.Location = new System.Drawing.Point(3, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(214, 15);
            this.textBoxTitle.TabIndex = 0;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxSearchTitle_TextChanged);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(238, 32);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(59, 24);
            this.comboBoxYear.TabIndex = 1;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // linkLabelBing
            // 
            this.linkLabelBing.AutoSize = true;
            this.linkLabelBing.Location = new System.Drawing.Point(306, 32);
            this.linkLabelBing.Name = "linkLabelBing";
            this.linkLabelBing.Size = new System.Drawing.Size(35, 16);
            this.linkLabelBing.TabIndex = 3;
            this.linkLabelBing.TabStop = true;
            this.linkLabelBing.Text = "Bing";
            this.linkLabelBing.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBing_LinkClicked);
            this.linkLabelBing.MouseHover += new System.EventHandler(this.linkLabelBing_MouseHover);
            // 
            // labelForYear
            // 
            this.labelForYear.AutoSize = true;
            this.labelForYear.Location = new System.Drawing.Point(241, 10);
            this.labelForYear.Name = "labelForYear";
            this.labelForYear.Size = new System.Drawing.Size(37, 16);
            this.labelForYear.TabIndex = 5;
            this.labelForYear.Text = "Year";
            // 
            // labelForPlot
            // 
            this.labelForPlot.AutoSize = true;
            this.labelForPlot.Location = new System.Drawing.Point(11, 64);
            this.labelForPlot.Name = "labelForPlot";
            this.labelForPlot.Size = new System.Drawing.Size(31, 16);
            this.labelForPlot.TabIndex = 6;
            this.labelForPlot.Text = "Plot";
            // 
            // tabControlTitle
            // 
            this.tabControlTitle.Controls.Add(this.tabPageTitle);
            this.tabControlTitle.Controls.Add(this.tabPageMovieSet);
            this.tabControlTitle.Location = new System.Drawing.Point(7, 7);
            this.tabControlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlTitle.Name = "tabControlTitle";
            this.tabControlTitle.Padding = new System.Drawing.Point(0, 0);
            this.tabControlTitle.SelectedIndex = 0;
            this.tabControlTitle.Size = new System.Drawing.Size(228, 50);
            this.tabControlTitle.TabIndex = 7;
            // 
            // tabPageTitle
            // 
            this.tabPageTitle.Controls.Add(this.textBoxTitle);
            this.tabPageTitle.Location = new System.Drawing.Point(4, 25);
            this.tabPageTitle.Name = "tabPageTitle";
            this.tabPageTitle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTitle.Size = new System.Drawing.Size(220, 21);
            this.tabPageTitle.TabIndex = 0;
            this.tabPageTitle.Text = "Title";
            // 
            // tabPageMovieSet
            // 
            this.tabPageMovieSet.Controls.Add(this.textBoxMovieSet);
            this.tabPageMovieSet.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovieSet.Name = "tabPageMovieSet";
            this.tabPageMovieSet.Size = new System.Drawing.Size(220, 21);
            this.tabPageMovieSet.TabIndex = 2;
            this.tabPageMovieSet.Text = "Movie Set";
            // 
            // textBoxMovieSet
            // 
            this.textBoxMovieSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMovieSet.Location = new System.Drawing.Point(3, 3);
            this.textBoxMovieSet.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxMovieSet.Name = "textBoxMovieSet";
            this.textBoxMovieSet.Size = new System.Drawing.Size(214, 15);
            this.textBoxMovieSet.TabIndex = 9;
            // 
            // linkLabelIMDB
            // 
            this.linkLabelIMDB.AutoSize = true;
            this.linkLabelIMDB.Location = new System.Drawing.Point(10, 237);
            this.linkLabelIMDB.Name = "linkLabelIMDB";
            this.linkLabelIMDB.Size = new System.Drawing.Size(41, 16);
            this.linkLabelIMDB.TabIndex = 9;
            this.linkLabelIMDB.TabStop = true;
            this.linkLabelIMDB.Text = "IMDB";
            this.linkLabelIMDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelIMDB_LinkClicked);
            this.linkLabelIMDB.MouseHover += new System.EventHandler(this.linkLabelIMDB_MouseHover);
            // 
            // linkLabelTMDB
            // 
            this.linkLabelTMDB.AutoSize = true;
            this.linkLabelTMDB.Location = new System.Drawing.Point(11, 185);
            this.linkLabelTMDB.Name = "linkLabelTMDB";
            this.linkLabelTMDB.Size = new System.Drawing.Size(47, 16);
            this.linkLabelTMDB.TabIndex = 10;
            this.linkLabelTMDB.TabStop = true;
            this.linkLabelTMDB.Text = "TMDB";
            this.linkLabelTMDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTMDB_LinkClicked);
            this.linkLabelTMDB.MouseHover += new System.EventHandler(this.linkLabelTMDB_MouseHover);
            // 
            // comboBoxIMDBRating
            // 
            this.comboBoxIMDBRating.FormattingEnabled = true;
            this.comboBoxIMDBRating.Location = new System.Drawing.Point(87, 256);
            this.comboBoxIMDBRating.Name = "comboBoxIMDBRating";
            this.comboBoxIMDBRating.Size = new System.Drawing.Size(60, 24);
            this.comboBoxIMDBRating.TabIndex = 11;
            // 
            // comboBoxMPAA
            // 
            this.comboBoxMPAA.FormattingEnabled = true;
            this.comboBoxMPAA.Location = new System.Drawing.Point(87, 201);
            this.comboBoxMPAA.Name = "comboBoxMPAA";
            this.comboBoxMPAA.Size = new System.Drawing.Size(60, 24);
            this.comboBoxMPAA.TabIndex = 12;
            // 
            // textBoxRunTime
            // 
            this.textBoxRunTime.Location = new System.Drawing.Point(161, 203);
            this.textBoxRunTime.Name = "textBoxRunTime";
            this.textBoxRunTime.Size = new System.Drawing.Size(59, 22);
            this.textBoxRunTime.TabIndex = 13;
            this.textBoxRunTime.Text = "1234";
            this.textBoxRunTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxWatched
            // 
            this.checkBoxWatched.AutoSize = true;
            this.checkBoxWatched.Location = new System.Drawing.Point(135, 62);
            this.checkBoxWatched.Name = "checkBoxWatched";
            this.checkBoxWatched.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxWatched.Size = new System.Drawing.Size(84, 20);
            this.checkBoxWatched.TabIndex = 16;
            this.checkBoxWatched.Text = "Watched";
            this.checkBoxWatched.UseVisualStyleBackColor = true;
            this.checkBoxWatched.CheckedChanged += new System.EventHandler(this.checkBoxWatched_CheckedChanged);
            // 
            // comboBoxPlayCount
            // 
            this.comboBoxPlayCount.FormattingEnabled = true;
            this.comboBoxPlayCount.Location = new System.Drawing.Point(233, 449);
            this.comboBoxPlayCount.Name = "comboBoxPlayCount";
            this.comboBoxPlayCount.Size = new System.Drawing.Size(60, 24);
            this.comboBoxPlayCount.TabIndex = 17;
            // 
            // comboBoxRating
            // 
            this.comboBoxRating.FormattingEnabled = true;
            this.comboBoxRating.Location = new System.Drawing.Point(161, 256);
            this.comboBoxRating.Name = "comboBoxRating";
            this.comboBoxRating.Size = new System.Drawing.Size(60, 24);
            this.comboBoxRating.TabIndex = 18;
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Location = new System.Drawing.Point(236, 83);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(105, 24);
            this.comboBoxSource.TabIndex = 19;
            // 
            // labelForLastPlayed
            // 
            this.labelForLastPlayed.AutoSize = true;
            this.labelForLastPlayed.Location = new System.Drawing.Point(120, 433);
            this.labelForLastPlayed.Name = "labelForLastPlayed";
            this.labelForLastPlayed.Size = new System.Drawing.Size(79, 16);
            this.labelForLastPlayed.TabIndex = 27;
            this.labelForLastPlayed.Text = "Last Played";
            // 
            // labelLastPlayed
            // 
            this.labelLastPlayed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLastPlayed.Location = new System.Drawing.Point(118, 451);
            this.labelLastPlayed.Name = "labelLastPlayed";
            this.labelLastPlayed.Size = new System.Drawing.Size(100, 22);
            this.labelLastPlayed.TabIndex = 26;
            this.labelLastPlayed.Text = "last played";
            this.labelLastPlayed.MouseHover += new System.EventHandler(this.labelLastPlayed_MouseHover);
            // 
            // labelForUpdated
            // 
            this.labelForUpdated.AutoSize = true;
            this.labelForUpdated.Location = new System.Drawing.Point(10, 430);
            this.labelForUpdated.Name = "labelForUpdated";
            this.labelForUpdated.Size = new System.Drawing.Size(61, 16);
            this.labelForUpdated.TabIndex = 29;
            this.labelForUpdated.Text = "Updated";
            // 
            // labelUpdated
            // 
            this.labelUpdated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelUpdated.Location = new System.Drawing.Point(7, 451);
            this.labelUpdated.Name = "labelUpdated";
            this.labelUpdated.Size = new System.Drawing.Size(100, 22);
            this.labelUpdated.TabIndex = 28;
            this.labelUpdated.Text = "updated";
            this.labelUpdated.MouseHover += new System.EventHandler(this.labelUpdated_MouseHover);
            // 
            // labelFroIMDBRating
            // 
            this.labelFroIMDBRating.AutoSize = true;
            this.labelFroIMDBRating.Location = new System.Drawing.Point(64, 237);
            this.labelFroIMDBRating.Name = "labelFroIMDBRating";
            this.labelFroIMDBRating.Size = new System.Drawing.Size(83, 16);
            this.labelFroIMDBRating.TabIndex = 38;
            this.labelFroIMDBRating.Text = "IMDB Rating";
            // 
            // labelForRating
            // 
            this.labelForRating.AutoSize = true;
            this.labelForRating.Location = new System.Drawing.Point(164, 237);
            this.labelForRating.Name = "labelForRating";
            this.labelForRating.Size = new System.Drawing.Size(47, 16);
            this.labelForRating.TabIndex = 39;
            this.labelForRating.Text = "Rating";
            // 
            // labelForRunTime
            // 
            this.labelForRunTime.AutoSize = true;
            this.labelForRunTime.Location = new System.Drawing.Point(163, 184);
            this.labelForRunTime.Name = "labelForRunTime";
            this.labelForRunTime.Size = new System.Drawing.Size(57, 16);
            this.labelForRunTime.TabIndex = 40;
            this.labelForRunTime.Text = "Runtime";
            // 
            // labelForMPAA
            // 
            this.labelForMPAA.AutoSize = true;
            this.labelForMPAA.Location = new System.Drawing.Point(93, 182);
            this.labelForMPAA.Name = "labelForMPAA";
            this.labelForMPAA.Size = new System.Drawing.Size(46, 16);
            this.labelForMPAA.TabIndex = 41;
            this.labelForMPAA.Text = "MPAA";
            // 
            // labelForSource
            // 
            this.labelForSource.AutoSize = true;
            this.labelForSource.Location = new System.Drawing.Point(238, 63);
            this.labelForSource.Name = "labelForSource";
            this.labelForSource.Size = new System.Drawing.Size(51, 16);
            this.labelForSource.TabIndex = 42;
            this.labelForSource.Text = "Source";
            // 
            // labelForplayCount
            // 
            this.labelForplayCount.AutoSize = true;
            this.labelForplayCount.Location = new System.Drawing.Point(237, 430);
            this.labelForplayCount.Name = "labelForplayCount";
            this.labelForplayCount.Size = new System.Drawing.Size(72, 16);
            this.labelForplayCount.TabIndex = 43;
            this.labelForplayCount.Text = "Play Count";
            // 
            // labelForNotes
            // 
            this.labelForNotes.AutoSize = true;
            this.labelForNotes.Location = new System.Drawing.Point(238, 162);
            this.labelForNotes.Name = "labelForNotes";
            this.labelForNotes.Size = new System.Drawing.Size(44, 16);
            this.labelForNotes.TabIndex = 44;
            this.labelForNotes.Text = "Notes";
            // 
            // linkLabelGoogle
            // 
            this.linkLabelGoogle.AutoSize = true;
            this.linkLabelGoogle.Location = new System.Drawing.Point(289, 7);
            this.linkLabelGoogle.Name = "linkLabelGoogle";
            this.linkLabelGoogle.Size = new System.Drawing.Size(53, 16);
            this.linkLabelGoogle.TabIndex = 47;
            this.linkLabelGoogle.TabStop = true;
            this.linkLabelGoogle.Text = "Google";
            this.linkLabelGoogle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoogle_LinkClicked);
            this.linkLabelGoogle.MouseHover += new System.EventHandler(this.linkLabelGoogle_MouseHover);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(8, 486);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 48;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxIMDB
            // 
            this.textBoxIMDB.Location = new System.Drawing.Point(8, 258);
            this.textBoxIMDB.Name = "textBoxIMDB";
            this.textBoxIMDB.Size = new System.Drawing.Size(62, 22);
            this.textBoxIMDB.TabIndex = 49;
            this.textBoxIMDB.TextChanged += new System.EventHandler(this.textBoxIMDB_TextChanged);
            // 
            // textBoxTMDB
            // 
            this.textBoxTMDB.Location = new System.Drawing.Point(8, 204);
            this.textBoxTMDB.Name = "textBoxTMDB";
            this.textBoxTMDB.Size = new System.Drawing.Size(61, 22);
            this.textBoxTMDB.TabIndex = 50;
            this.textBoxTMDB.TextChanged += new System.EventHandler(this.textBoxTMDB_TextChanged);
            // 
            // labelForTags
            // 
            this.labelForTags.AutoSize = true;
            this.labelForTags.Location = new System.Drawing.Point(236, 244);
            this.labelForTags.Name = "labelForTags";
            this.labelForTags.Size = new System.Drawing.Size(40, 16);
            this.labelForTags.TabIndex = 77;
            this.labelForTags.Text = "Tags";
            // 
            // dataGridViewActors
            // 
            this.dataGridViewActors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActors.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewActors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewActors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActors.ColumnHeadersVisible = false;
            this.dataGridViewActors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnRole});
            this.dataGridViewActors.Location = new System.Drawing.Point(8, 309);
            this.dataGridViewActors.Name = "dataGridViewActors";
            this.dataGridViewActors.RowHeadersVisible = false;
            this.dataGridViewActors.RowTemplate.Height = 24;
            this.dataGridViewActors.Size = new System.Drawing.Size(213, 110);
            this.dataGridViewActors.TabIndex = 81;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnRole
            // 
            this.ColumnRole.HeaderText = "Role";
            this.ColumnRole.Name = "ColumnRole";
            // 
            // labelForGenre
            // 
            this.labelForGenre.AutoSize = true;
            this.labelForGenre.Location = new System.Drawing.Point(235, 348);
            this.labelForGenre.Name = "labelForGenre";
            this.labelForGenre.Size = new System.Drawing.Size(45, 16);
            this.labelForGenre.TabIndex = 83;
            this.labelForGenre.Text = "Genre";
            // 
            // labelForActors
            // 
            this.labelForActors.AutoSize = true;
            this.labelForActors.Location = new System.Drawing.Point(11, 290);
            this.labelForActors.Name = "labelForActors";
            this.labelForActors.Size = new System.Drawing.Size(104, 16);
            this.labelForActors.TabIndex = 84;
            this.labelForActors.Text = "Actors/Directors";
            // 
            // labelForRole
            // 
            this.labelForRole.AutoSize = true;
            this.labelForRole.Location = new System.Drawing.Point(174, 290);
            this.labelForRole.Name = "labelForRole";
            this.labelForRole.Size = new System.Drawing.Size(37, 16);
            this.labelForRole.TabIndex = 85;
            this.labelForRole.Text = "Role";
            // 
            // dataGridViewTags
            // 
            this.dataGridViewTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTags.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTags.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTags.ColumnHeadersVisible = false;
            this.dataGridViewTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTag});
            this.dataGridViewTags.Location = new System.Drawing.Point(233, 264);
            this.dataGridViewTags.Name = "dataGridViewTags";
            this.dataGridViewTags.RowHeadersVisible = false;
            this.dataGridViewTags.RowTemplate.Height = 24;
            this.dataGridViewTags.Size = new System.Drawing.Size(109, 80);
            this.dataGridViewTags.TabIndex = 86;
            // 
            // ColumnTag
            // 
            this.ColumnTag.HeaderText = "Tag";
            this.ColumnTag.Name = "ColumnTag";
            // 
            // dataGridViewGenres
            // 
            this.dataGridViewGenres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGenres.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewGenres.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGenres.ColumnHeadersVisible = false;
            this.dataGridViewGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumnGenre});
            this.dataGridViewGenres.Location = new System.Drawing.Point(233, 367);
            this.dataGridViewGenres.Name = "dataGridViewGenres";
            this.dataGridViewGenres.RowHeadersVisible = false;
            this.dataGridViewGenres.RowTemplate.Height = 24;
            this.dataGridViewGenres.Size = new System.Drawing.Size(109, 52);
            this.dataGridViewGenres.TabIndex = 87;
            // 
            // dataGridViewTextBoxColumnGenre
            // 
            this.dataGridViewTextBoxColumnGenre.HeaderText = "Genre";
            this.dataGridViewTextBoxColumnGenre.Name = "dataGridViewTextBoxColumnGenre";
            // 
            // labelForVersion
            // 
            this.labelForVersion.AutoSize = true;
            this.labelForVersion.Location = new System.Drawing.Point(237, 113);
            this.labelForVersion.Name = "labelForVersion";
            this.labelForVersion.Size = new System.Drawing.Size(54, 16);
            this.labelForVersion.TabIndex = 89;
            this.labelForVersion.Text = "Version";
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Location = new System.Drawing.Point(235, 133);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(106, 24);
            this.comboBoxVersion.TabIndex = 88;
            // 
            // linkLabelRT
            // 
            this.linkLabelRT.AutoSize = true;
            this.linkLabelRT.Location = new System.Drawing.Point(314, 56);
            this.linkLabelRT.Name = "linkLabelRT";
            this.linkLabelRT.Size = new System.Drawing.Size(27, 16);
            this.linkLabelRT.TabIndex = 90;
            this.linkLabelRT.TabStop = true;
            this.linkLabelRT.Text = "RT";
            this.linkLabelRT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRT_LinkClicked);
            this.linkLabelRT.MouseHover += new System.EventHandler(this.linkLabelRT_MouseHover);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(118, 505);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(45, 22);
            this.textBoxWidth.TabIndex = 91;
            this.textBoxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(174, 505);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(45, 22);
            this.textBoxHeight.TabIndex = 92;
            this.textBoxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelForWidth
            // 
            this.labelForWidth.AutoSize = true;
            this.labelForWidth.Location = new System.Drawing.Point(121, 486);
            this.labelForWidth.Name = "labelForWidth";
            this.labelForWidth.Size = new System.Drawing.Size(42, 16);
            this.labelForWidth.TabIndex = 93;
            this.labelForWidth.Text = "Width";
            // 
            // labelForHeight
            // 
            this.labelForHeight.AutoSize = true;
            this.labelForHeight.Location = new System.Drawing.Point(177, 486);
            this.labelForHeight.Name = "labelForHeight";
            this.labelForHeight.Size = new System.Drawing.Size(47, 16);
            this.labelForHeight.TabIndex = 94;
            this.labelForHeight.Text = "Height";
            // 
            // labelForBitrate
            // 
            this.labelForBitrate.AutoSize = true;
            this.labelForBitrate.Location = new System.Drawing.Point(236, 538);
            this.labelForBitrate.Name = "labelForBitrate";
            this.labelForBitrate.Size = new System.Drawing.Size(55, 16);
            this.labelForBitrate.TabIndex = 96;
            this.labelForBitrate.Text = "Bit Rate";
            // 
            // textBoxBitrate
            // 
            this.textBoxBitrate.Location = new System.Drawing.Point(233, 557);
            this.textBoxBitrate.Name = "textBoxBitrate";
            this.textBoxBitrate.Size = new System.Drawing.Size(64, 22);
            this.textBoxBitrate.TabIndex = 95;
            this.textBoxBitrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelForBitrateFormatted
            // 
            this.labelForBitrateFormatted.AutoSize = true;
            this.labelForBitrateFormatted.Location = new System.Drawing.Point(304, 543);
            this.labelForBitrateFormatted.Name = "labelForBitrateFormatted";
            this.labelForBitrateFormatted.Size = new System.Drawing.Size(29, 16);
            this.labelForBitrateFormatted.TabIndex = 97;
            this.labelForBitrateFormatted.Text = "       ";
            // 
            // labelForCodec
            // 
            this.labelForCodec.AutoSize = true;
            this.labelForCodec.Location = new System.Drawing.Point(237, 486);
            this.labelForCodec.Name = "labelForCodec";
            this.labelForCodec.Size = new System.Drawing.Size(48, 16);
            this.labelForCodec.TabIndex = 101;
            this.labelForCodec.Text = "Codec";
            // 
            // comboBoxCodec
            // 
            this.comboBoxCodec.FormattingEnabled = true;
            this.comboBoxCodec.Location = new System.Drawing.Point(233, 505);
            this.comboBoxCodec.Name = "comboBoxCodec";
            this.comboBoxCodec.Size = new System.Drawing.Size(100, 24);
            this.comboBoxCodec.TabIndex = 100;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(7, 570);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 102;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(7, 529);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 103;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // labelForUPC
            // 
            this.labelForUPC.AutoSize = true;
            this.labelForUPC.Location = new System.Drawing.Point(121, 538);
            this.labelForUPC.Name = "labelForUPC";
            this.labelForUPC.Size = new System.Drawing.Size(36, 16);
            this.labelForUPC.TabIndex = 105;
            this.labelForUPC.Text = "UPC";
            // 
            // textBoxUPC
            // 
            this.textBoxUPC.Location = new System.Drawing.Point(118, 557);
            this.textBoxUPC.Name = "textBoxUPC";
            this.textBoxUPC.Size = new System.Drawing.Size(103, 22);
            this.textBoxUPC.TabIndex = 104;
            this.textBoxUPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Location = new System.Drawing.Point(235, 181);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxNotes.Size = new System.Drawing.Size(106, 60);
            this.richTextBoxNotes.TabIndex = 106;
            this.richTextBoxNotes.Text = "";
            // 
            // richTextBoxPlot
            // 
            this.richTextBoxPlot.Location = new System.Drawing.Point(7, 83);
            this.richTextBoxPlot.Name = "richTextBoxPlot";
            this.richTextBoxPlot.Size = new System.Drawing.Size(215, 90);
            this.richTextBoxPlot.TabIndex = 107;
            this.richTextBoxPlot.Text = "";
            // 
            // SubFormVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxPlot);
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.labelForUPC);
            this.Controls.Add(this.textBoxUPC);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.labelForCodec);
            this.Controls.Add(this.comboBoxCodec);
            this.Controls.Add(this.labelForBitrateFormatted);
            this.Controls.Add(this.labelForBitrate);
            this.Controls.Add(this.textBoxBitrate);
            this.Controls.Add(this.labelForHeight);
            this.Controls.Add(this.labelForWidth);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.linkLabelRT);
            this.Controls.Add(this.labelForVersion);
            this.Controls.Add(this.comboBoxVersion);
            this.Controls.Add(this.dataGridViewGenres);
            this.Controls.Add(this.dataGridViewTags);
            this.Controls.Add(this.labelForRole);
            this.Controls.Add(this.labelForActors);
            this.Controls.Add(this.labelForGenre);
            this.Controls.Add(this.dataGridViewActors);
            this.Controls.Add(this.labelForTags);
            this.Controls.Add(this.textBoxTMDB);
            this.Controls.Add(this.textBoxIMDB);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.linkLabelGoogle);
            this.Controls.Add(this.labelForNotes);
            this.Controls.Add(this.labelForplayCount);
            this.Controls.Add(this.labelForSource);
            this.Controls.Add(this.labelForMPAA);
            this.Controls.Add(this.labelForRunTime);
            this.Controls.Add(this.labelForRating);
            this.Controls.Add(this.labelFroIMDBRating);
            this.Controls.Add(this.labelForUpdated);
            this.Controls.Add(this.labelUpdated);
            this.Controls.Add(this.labelForLastPlayed);
            this.Controls.Add(this.labelLastPlayed);
            this.Controls.Add(this.comboBoxSource);
            this.Controls.Add(this.comboBoxRating);
            this.Controls.Add(this.comboBoxPlayCount);
            this.Controls.Add(this.checkBoxWatched);
            this.Controls.Add(this.textBoxRunTime);
            this.Controls.Add(this.comboBoxMPAA);
            this.Controls.Add(this.comboBoxIMDBRating);
            this.Controls.Add(this.linkLabelTMDB);
            this.Controls.Add(this.linkLabelIMDB);
            this.Controls.Add(this.tabControlTitle);
            this.Controls.Add(this.labelForPlot);
            this.Controls.Add(this.labelForYear);
            this.Controls.Add(this.linkLabelBing);
            this.Controls.Add(this.comboBoxYear);
            this.Name = "SubFormVideoForm";
            this.Size = new System.Drawing.Size(350, 600);
            this.Load += new System.EventHandler(this.UserControlVideoInfo_Load);
            this.tabControlTitle.ResumeLayout(false);
            this.tabPageTitle.ResumeLayout(false);
            this.tabPageTitle.PerformLayout();
            this.tabPageMovieSet.ResumeLayout(false);
            this.tabPageMovieSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.LinkLabel linkLabelBing;
        private System.Windows.Forms.Label labelForYear;
        private System.Windows.Forms.Label labelForPlot;
        private System.Windows.Forms.TabControl tabControlTitle;
        private System.Windows.Forms.TabPage tabPageTitle;
        private System.Windows.Forms.LinkLabel linkLabelIMDB;
        private System.Windows.Forms.LinkLabel linkLabelTMDB;
        private System.Windows.Forms.ComboBox comboBoxIMDBRating;
        private System.Windows.Forms.ComboBox comboBoxMPAA;
        private System.Windows.Forms.TextBox textBoxRunTime;
        private System.Windows.Forms.CheckBox checkBoxWatched;
        private System.Windows.Forms.ComboBox comboBoxPlayCount;
        private System.Windows.Forms.ComboBox comboBoxRating;
        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.Label labelForLastPlayed;
        private System.Windows.Forms.Label labelLastPlayed;
        private System.Windows.Forms.Label labelForUpdated;
        private System.Windows.Forms.Label labelUpdated;
        private System.Windows.Forms.Label labelFroIMDBRating;
        private System.Windows.Forms.Label labelForRating;
        private System.Windows.Forms.Label labelForRunTime;
        private System.Windows.Forms.Label labelForMPAA;
        private System.Windows.Forms.Label labelForSource;
        private System.Windows.Forms.Label labelForplayCount;
        private System.Windows.Forms.Label labelForNotes;
        private System.Windows.Forms.TabPage tabPageMovieSet;
        private System.Windows.Forms.TextBox textBoxMovieSet;
        private System.Windows.Forms.LinkLabel linkLabelGoogle;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxIMDB;
        private System.Windows.Forms.TextBox textBoxTMDB;
        private System.Windows.Forms.Label labelForTags;
        private System.Windows.Forms.DataGridView dataGridViewActors;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRole;
        private System.Windows.Forms.Label labelForGenre;
        private System.Windows.Forms.Label labelForActors;
        private System.Windows.Forms.Label labelForRole;
        private System.Windows.Forms.DataGridView dataGridViewTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTag;
        private System.Windows.Forms.DataGridView dataGridViewGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnGenre;
        private System.Windows.Forms.Label labelForVersion;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.LinkLabel linkLabelRT;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelForWidth;
        private System.Windows.Forms.Label labelForHeight;
        private System.Windows.Forms.Label labelForBitrate;
        private System.Windows.Forms.TextBox textBoxBitrate;
        private System.Windows.Forms.Label labelForBitrateFormatted;
        private System.Windows.Forms.Label labelForCodec;
        private System.Windows.Forms.ComboBox comboBoxCodec;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Label labelForUPC;
        private System.Windows.Forms.TextBox textBoxUPC;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.RichTextBox richTextBoxPlot;
    }
}
