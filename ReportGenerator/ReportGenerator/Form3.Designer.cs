namespace ReportGenerator {
	partial class Form3 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.cancel = new System.Windows.Forms.Button();
			this.next = new System.Windows.Forms.Button();
			this.back = new System.Windows.Forms.Button();
			this.main = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel2_saveConfig = new System.Windows.Forms.Button();
			this.panel2_labelSelectRiskLevel = new System.Windows.Forms.Label();
			this.panel2_ComboBox = new System.Windows.Forms.ComboBox();
			this.panel2_updateRecord = new System.Windows.Forms.Button();
			this.panel2_selectMerge = new System.Windows.Forms.Button();
			this.panel2_selectUpdate = new System.Windows.Forms.Button();
			this.panel2_mergeRecord = new System.Windows.Forms.Button();
			this.panel2_reverse = new System.Windows.Forms.Button();
			this.panel2_selectNone = new System.Windows.Forms.Button();
			this.panel2_selectAll = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1_reverse = new System.Windows.Forms.Button();
			this.panel1_selectNone = new System.Windows.Forms.Button();
			this.panel1_selectAll = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1_importFile = new System.Windows.Forms.Button();
			this.panel1_importFolder = new System.Windows.Forms.Button();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel5_label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel4_label1 = new System.Windows.Forms.Label();
			this.panel4_dataGridView = new System.Windows.Forms.DataGridView();
			this.replaceString = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stringAfterReplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel3_groupBoxOutputSelection = new System.Windows.Forms.GroupBox();
			this.panel3_html = new System.Windows.Forms.Button();
			this.panel3_docxDefault = new System.Windows.Forms.Button();
			this.panel3_docxFromDocx = new System.Windows.Forms.Button();
			this.panel3_xlsxDefault = new System.Windows.Forms.Button();
			this.panel3_groupBoxSetting = new System.Windows.Forms.GroupBox();
			this.panel3_settingLabel = new System.Windows.Forms.Label();
			this.panel3_templatePathGroupBox = new System.Windows.Forms.GroupBox();
			this.panel3_templatePathOpen = new System.Windows.Forms.Button();
			this.panel3_templatePath = new System.Windows.Forms.TextBox();
			this.panel3_outputFilePathGroupBox = new System.Windows.Forms.GroupBox();
			this.panel3_outputPathSaveAs = new System.Windows.Forms.Button();
			this.panel3_outputFilePath = new System.Windows.Forms.TextBox();
			this.one = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.five = new System.Windows.Forms.Label();
			this.four = new System.Windows.Forms.Label();
			this.three = new System.Windows.Forms.Label();
			this.two = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.form3_label = new System.Windows.Forms.Label();
			this.panel2_checkboxHigh = new System.Windows.Forms.CheckBox();
			this.panel2_checkboxMedium = new System.Windows.Forms.CheckBox();
			this.panel2_checkboxLow = new System.Windows.Forms.CheckBox();
			this.panel2_checkboxNone = new System.Windows.Forms.CheckBox();
			this.panel2_checkboxOpenPort = new System.Windows.Forms.CheckBox();
			this.panel2_bottom = new System.Windows.Forms.Panel();
			this.form3Panel2_noOfRowSelected = new System.Windows.Forms.Label();
			this.panel2_showLabel = new System.Windows.Forms.Label();
			this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.merge = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.change = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.pluginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ipList = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.impact = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.riskLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.recommendations = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reference_CVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reference_BID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reference_OSVDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.referenceLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.oldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.main.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panel4_dataGridView)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel3_groupBoxOutputSelection.SuspendLayout();
			this.panel3_groupBoxSetting.SuspendLayout();
			this.panel3_templatePathGroupBox.SuspendLayout();
			this.panel3_outputFilePathGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2_bottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(918, 516);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 11;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// next
			// 
			this.next.Location = new System.Drawing.Point(837, 516);
			this.next.Name = "next";
			this.next.Size = new System.Drawing.Size(75, 23);
			this.next.TabIndex = 10;
			this.next.Text = "Next >";
			this.next.UseVisualStyleBackColor = true;
			this.next.Click += new System.EventHandler(this.next_Click);
			// 
			// back
			// 
			this.back.Location = new System.Drawing.Point(756, 516);
			this.back.Name = "back";
			this.back.Size = new System.Drawing.Size(75, 23);
			this.back.TabIndex = 9;
			this.back.Text = "< Back";
			this.back.UseVisualStyleBackColor = true;
			this.back.Click += new System.EventHandler(this.back_Click);
			// 
			// main
			// 
			this.main.Controls.Add(this.panel2);
			this.main.Controls.Add(this.panel1);
			this.main.Controls.Add(this.panel5);
			this.main.Controls.Add(this.panel4);
			this.main.Controls.Add(this.panel3);
			this.main.Location = new System.Drawing.Point(12, 80);
			this.main.Name = "main";
			this.main.Size = new System.Drawing.Size(984, 430);
			this.main.TabIndex = 4;
			this.main.TabStop = false;
			this.main.Text = "Main";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.Controls.Add(this.panel2_saveConfig);
			this.panel2.Controls.Add(this.panel2_labelSelectRiskLevel);
			this.panel2.Controls.Add(this.panel2_ComboBox);
			this.panel2.Controls.Add(this.panel2_updateRecord);
			this.panel2.Controls.Add(this.panel2_selectMerge);
			this.panel2.Controls.Add(this.panel2_selectUpdate);
			this.panel2.Controls.Add(this.panel2_mergeRecord);
			this.panel2.Controls.Add(this.panel2_reverse);
			this.panel2.Controls.Add(this.panel2_selectNone);
			this.panel2.Controls.Add(this.panel2_selectAll);
			this.panel2.Controls.Add(this.dataGridView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 16);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(978, 411);
			this.panel2.TabIndex = 11;
			// 
			// panel2_saveConfig
			// 
			this.panel2_saveConfig.Location = new System.Drawing.Point(662, 383);
			this.panel2_saveConfig.Name = "panel2_saveConfig";
			this.panel2_saveConfig.Size = new System.Drawing.Size(75, 23);
			this.panel2_saveConfig.TabIndex = 103;
			this.panel2_saveConfig.Text = "Save Config";
			this.panel2_saveConfig.UseVisualStyleBackColor = true;
			this.panel2_saveConfig.Click += new System.EventHandler(this.panel2_saveConfig_Click);
			// 
			// panel2_labelSelectRiskLevel
			// 
			this.panel2_labelSelectRiskLevel.AutoSize = true;
			this.panel2_labelSelectRiskLevel.Location = new System.Drawing.Point(785, 388);
			this.panel2_labelSelectRiskLevel.Name = "panel2_labelSelectRiskLevel";
			this.panel2_labelSelectRiskLevel.Size = new System.Drawing.Size(67, 13);
			this.panel2_labelSelectRiskLevel.TabIndex = 102;
			this.panel2_labelSelectRiskLevel.Text = "Select Risk: ";
			// 
			// panel2_ComboBox
			// 
			this.panel2_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.panel2_ComboBox.FormattingEnabled = true;
			this.panel2_ComboBox.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low",
            "None",
            "Open Port"});
			this.panel2_ComboBox.Location = new System.Drawing.Point(854, 385);
			this.panel2_ComboBox.Name = "panel2_ComboBox";
			this.panel2_ComboBox.Size = new System.Drawing.Size(121, 21);
			this.panel2_ComboBox.TabIndex = 101;
			this.panel2_ComboBox.SelectedIndexChanged += new System.EventHandler(this.panel2_ComboBox_SelectedIndexChanged);
			// 
			// panel2_updateRecord
			// 
			this.panel2_updateRecord.Enabled = false;
			this.panel2_updateRecord.Location = new System.Drawing.Point(568, 383);
			this.panel2_updateRecord.Name = "panel2_updateRecord";
			this.panel2_updateRecord.Size = new System.Drawing.Size(88, 23);
			this.panel2_updateRecord.TabIndex = 8;
			this.panel2_updateRecord.Text = "Update Record";
			this.panel2_updateRecord.UseVisualStyleBackColor = true;
			this.panel2_updateRecord.Click += new System.EventHandler(this.panel2_updateRecord_Click);
			// 
			// panel2_selectMerge
			// 
			this.panel2_selectMerge.Location = new System.Drawing.Point(191, 383);
			this.panel2_selectMerge.Name = "panel2_selectMerge";
			this.panel2_selectMerge.Size = new System.Drawing.Size(88, 23);
			this.panel2_selectMerge.TabIndex = 3;
			this.panel2_selectMerge.Text = "Select Merge";
			this.panel2_selectMerge.UseVisualStyleBackColor = true;
			this.panel2_selectMerge.Click += new System.EventHandler(this.panel2_selectMerge_Click);
			// 
			// panel2_selectUpdate
			// 
			this.panel2_selectUpdate.Location = new System.Drawing.Point(285, 383);
			this.panel2_selectUpdate.Name = "panel2_selectUpdate";
			this.panel2_selectUpdate.Size = new System.Drawing.Size(88, 23);
			this.panel2_selectUpdate.TabIndex = 5;
			this.panel2_selectUpdate.Text = "Select Update";
			this.panel2_selectUpdate.UseVisualStyleBackColor = true;
			this.panel2_selectUpdate.Click += new System.EventHandler(this.panel2_selectUpdate_Click);
			// 
			// panel2_mergeRecord
			// 
			this.panel2_mergeRecord.Enabled = false;
			this.panel2_mergeRecord.Location = new System.Drawing.Point(474, 383);
			this.panel2_mergeRecord.Name = "panel2_mergeRecord";
			this.panel2_mergeRecord.Size = new System.Drawing.Size(88, 23);
			this.panel2_mergeRecord.TabIndex = 7;
			this.panel2_mergeRecord.Text = "Merge Record";
			this.panel2_mergeRecord.UseVisualStyleBackColor = true;
			this.panel2_mergeRecord.Click += new System.EventHandler(this.panel2_mergeRecord_Click);
			// 
			// panel2_reverse
			// 
			this.panel2_reverse.Location = new System.Drawing.Point(379, 383);
			this.panel2_reverse.Name = "panel2_reverse";
			this.panel2_reverse.Size = new System.Drawing.Size(88, 23);
			this.panel2_reverse.TabIndex = 6;
			this.panel2_reverse.Text = "Reverse Select";
			this.panel2_reverse.UseVisualStyleBackColor = true;
			this.panel2_reverse.Click += new System.EventHandler(this.panel2_selectReverse_Click);
			// 
			// panel2_selectNone
			// 
			this.panel2_selectNone.Location = new System.Drawing.Point(97, 383);
			this.panel2_selectNone.Name = "panel2_selectNone";
			this.panel2_selectNone.Size = new System.Drawing.Size(88, 23);
			this.panel2_selectNone.TabIndex = 1;
			this.panel2_selectNone.Text = "Select None";
			this.panel2_selectNone.UseVisualStyleBackColor = true;
			this.panel2_selectNone.Click += new System.EventHandler(this.panel2_selectNone_Click);
			// 
			// panel2_selectAll
			// 
			this.panel2_selectAll.Location = new System.Drawing.Point(3, 383);
			this.panel2_selectAll.Name = "panel2_selectAll";
			this.panel2_selectAll.Size = new System.Drawing.Size(88, 23);
			this.panel2_selectAll.TabIndex = 0;
			this.panel2_selectAll.Text = "Select All";
			this.panel2_selectAll.UseVisualStyleBackColor = true;
			this.panel2_selectAll.Click += new System.EventHandler(this.panel2_selectAll_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.merge,
            this.change,
            this.pluginName,
            this.ipList,
            this.description,
            this.impact,
            this.riskLevel,
            this.recommendations,
            this.reference_CVE,
            this.reference_BID,
            this.reference_OSVDB,
            this.referenceLink,
            this.id,
            this.oldId});
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(970, 376);
			this.dataGridView1.TabIndex = 100;
			this.dataGridView1.TabStop = false;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel1_reverse);
			this.panel1.Controls.Add(this.panel1_selectNone);
			this.panel1.Controls.Add(this.panel1_selectAll);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.panel1_importFile);
			this.panel1.Controls.Add(this.panel1_importFolder);
			this.panel1.Controls.Add(this.checkedListBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 411);
			this.panel1.TabIndex = 12;
			// 
			// panel1_reverse
			// 
			this.panel1_reverse.Location = new System.Drawing.Point(164, 385);
			this.panel1_reverse.Name = "panel1_reverse";
			this.panel1_reverse.Size = new System.Drawing.Size(75, 23);
			this.panel1_reverse.TabIndex = 7;
			this.panel1_reverse.Text = "Reverse";
			this.panel1_reverse.UseVisualStyleBackColor = true;
			this.panel1_reverse.Click += new System.EventHandler(this.panel1_reverse_Click);
			// 
			// panel1_selectNone
			// 
			this.panel1_selectNone.Location = new System.Drawing.Point(83, 385);
			this.panel1_selectNone.Name = "panel1_selectNone";
			this.panel1_selectNone.Size = new System.Drawing.Size(75, 23);
			this.panel1_selectNone.TabIndex = 6;
			this.panel1_selectNone.Text = "Select None";
			this.panel1_selectNone.UseVisualStyleBackColor = true;
			this.panel1_selectNone.Click += new System.EventHandler(this.panel1_selectNone_Click);
			// 
			// panel1_selectAll
			// 
			this.panel1_selectAll.Location = new System.Drawing.Point(2, 385);
			this.panel1_selectAll.Name = "panel1_selectAll";
			this.panel1_selectAll.Size = new System.Drawing.Size(75, 23);
			this.panel1_selectAll.TabIndex = 5;
			this.panel1_selectAll.Text = "Select All";
			this.panel1_selectAll.UseVisualStyleBackColor = true;
			this.panel1_selectAll.Click += new System.EventHandler(this.panel1_selectAll_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "File List";
			// 
			// panel1_importFile
			// 
			this.panel1_importFile.Location = new System.Drawing.Point(856, 385);
			this.panel1_importFile.Name = "panel1_importFile";
			this.panel1_importFile.Size = new System.Drawing.Size(117, 23);
			this.panel1_importFile.TabIndex = 1;
			this.panel1_importFile.Text = "Import file";
			this.panel1_importFile.UseVisualStyleBackColor = true;
			this.panel1_importFile.Click += new System.EventHandler(this.panel1_importFile_Click);
			// 
			// panel1_importFolder
			// 
			this.panel1_importFolder.Location = new System.Drawing.Point(733, 385);
			this.panel1_importFolder.Name = "panel1_importFolder";
			this.panel1_importFolder.Size = new System.Drawing.Size(117, 23);
			this.panel1_importFolder.TabIndex = 0;
			this.panel1_importFolder.Text = "Import from folder";
			this.panel1_importFolder.UseVisualStyleBackColor = true;
			this.panel1_importFolder.Click += new System.EventHandler(this.panel1_importFolder_Click);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.CheckOnClick = true;
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.HorizontalScrollbar = true;
			this.checkedListBox1.Location = new System.Drawing.Point(3, 28);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.checkedListBox1.Size = new System.Drawing.Size(970, 349);
			this.checkedListBox1.Sorted = true;
			this.checkedListBox1.TabIndex = 0;
			this.checkedListBox1.Click += new System.EventHandler(this.checkedListBox1_Click);
			this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
			this.checkedListBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkedListBox1_KeyPress);
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Transparent;
			this.panel5.Controls.Add(this.panel5_label1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(3, 16);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(978, 411);
			this.panel5.TabIndex = 8;
			// 
			// panel5_label1
			// 
			this.panel5_label1.AutoSize = true;
			this.panel5_label1.Location = new System.Drawing.Point(10, 388);
			this.panel5_label1.Name = "panel5_label1";
			this.panel5_label1.Size = new System.Drawing.Size(315, 13);
			this.panel5_label1.TabIndex = 0;
			this.panel5_label1.Text = "Press Finished Button to Output, this step may take a few minutes";
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Transparent;
			this.panel4.Controls.Add(this.panel4_label1);
			this.panel4.Controls.Add(this.panel4_dataGridView);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 16);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(978, 411);
			this.panel4.TabIndex = 9;
			// 
			// panel4_label1
			// 
			this.panel4_label1.AutoSize = true;
			this.panel4_label1.Location = new System.Drawing.Point(6, 3);
			this.panel4_label1.Name = "panel4_label1";
			this.panel4_label1.Size = new System.Drawing.Size(175, 13);
			this.panel4_label1.TabIndex = 1;
			this.panel4_label1.Text = "Docx Template String Replacement";
			// 
			// panel4_dataGridView
			// 
			this.panel4_dataGridView.AllowUserToAddRows = false;
			this.panel4_dataGridView.AllowUserToDeleteRows = false;
			this.panel4_dataGridView.AllowUserToResizeRows = false;
			this.panel4_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.panel4_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.replaceString,
            this.stringAfterReplace});
			this.panel4_dataGridView.Location = new System.Drawing.Point(3, 19);
			this.panel4_dataGridView.Name = "panel4_dataGridView";
			this.panel4_dataGridView.RowHeadersVisible = false;
			this.panel4_dataGridView.Size = new System.Drawing.Size(972, 389);
			this.panel4_dataGridView.TabIndex = 0;
			this.panel4_dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.panel4_dataGridView_CellEndEdit);
			// 
			// replaceString
			// 
			this.replaceString.FillWeight = 275F;
			this.replaceString.HeaderText = "String required to replace";
			this.replaceString.Name = "replaceString";
			this.replaceString.ReadOnly = true;
			this.replaceString.Width = 275;
			// 
			// stringAfterReplace
			// 
			this.stringAfterReplace.FillWeight = 675F;
			this.stringAfterReplace.HeaderText = "Replaced String";
			this.stringAfterReplace.Name = "stringAfterReplace";
			this.stringAfterReplace.Width = 675;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Transparent;
			this.panel3.Controls.Add(this.panel3_groupBoxOutputSelection);
			this.panel3.Controls.Add(this.panel3_groupBoxSetting);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 16);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(978, 411);
			this.panel3.TabIndex = 10;
			// 
			// panel3_groupBoxOutputSelection
			// 
			this.panel3_groupBoxOutputSelection.Controls.Add(this.panel3_html);
			this.panel3_groupBoxOutputSelection.Controls.Add(this.panel3_docxDefault);
			this.panel3_groupBoxOutputSelection.Controls.Add(this.panel3_docxFromDocx);
			this.panel3_groupBoxOutputSelection.Controls.Add(this.panel3_xlsxDefault);
			this.panel3_groupBoxOutputSelection.Location = new System.Drawing.Point(3, 3);
			this.panel3_groupBoxOutputSelection.Name = "panel3_groupBoxOutputSelection";
			this.panel3_groupBoxOutputSelection.Size = new System.Drawing.Size(223, 403);
			this.panel3_groupBoxOutputSelection.TabIndex = 6;
			this.panel3_groupBoxOutputSelection.TabStop = false;
			this.panel3_groupBoxOutputSelection.Text = "Output Selection";
			// 
			// panel3_html
			// 
			this.panel3_html.Location = new System.Drawing.Point(6, 35);
			this.panel3_html.Name = "panel3_html";
			this.panel3_html.Size = new System.Drawing.Size(211, 80);
			this.panel3_html.TabIndex = 0;
			this.panel3_html.Text = "HTML";
			this.panel3_html.UseVisualStyleBackColor = true;
			this.panel3_html.Click += new System.EventHandler(this.panel3_html_Click);
			// 
			// panel3_docxDefault
			// 
			this.panel3_docxDefault.Location = new System.Drawing.Point(6, 121);
			this.panel3_docxDefault.Name = "panel3_docxDefault";
			this.panel3_docxDefault.Size = new System.Drawing.Size(211, 80);
			this.panel3_docxDefault.TabIndex = 1;
			this.panel3_docxDefault.Text = "DOCX with no style applied";
			this.panel3_docxDefault.UseVisualStyleBackColor = true;
			this.panel3_docxDefault.Click += new System.EventHandler(this.panel3_docxDefault_Click);
			// 
			// panel3_docxFromDocx
			// 
			this.panel3_docxFromDocx.Location = new System.Drawing.Point(6, 207);
			this.panel3_docxFromDocx.Name = "panel3_docxFromDocx";
			this.panel3_docxFromDocx.Size = new System.Drawing.Size(211, 80);
			this.panel3_docxFromDocx.TabIndex = 2;
			this.panel3_docxFromDocx.Text = "DOCX with style from DOCX file";
			this.panel3_docxFromDocx.UseVisualStyleBackColor = true;
			this.panel3_docxFromDocx.Click += new System.EventHandler(this.panel3_docxFromDocx_Click);
			// 
			// panel3_xlsxDefault
			// 
			this.panel3_xlsxDefault.Location = new System.Drawing.Point(6, 293);
			this.panel3_xlsxDefault.Name = "panel3_xlsxDefault";
			this.panel3_xlsxDefault.Size = new System.Drawing.Size(211, 80);
			this.panel3_xlsxDefault.TabIndex = 3;
			this.panel3_xlsxDefault.Text = "XLSX with no style applied";
			this.panel3_xlsxDefault.UseVisualStyleBackColor = true;
			this.panel3_xlsxDefault.Click += new System.EventHandler(this.panel3_xlsxDefault_Click);
			// 
			// panel3_groupBoxSetting
			// 
			this.panel3_groupBoxSetting.Controls.Add(this.panel3_settingLabel);
			this.panel3_groupBoxSetting.Controls.Add(this.panel3_templatePathGroupBox);
			this.panel3_groupBoxSetting.Controls.Add(this.panel3_outputFilePathGroupBox);
			this.panel3_groupBoxSetting.Location = new System.Drawing.Point(232, 3);
			this.panel3_groupBoxSetting.Name = "panel3_groupBoxSetting";
			this.panel3_groupBoxSetting.Size = new System.Drawing.Size(741, 403);
			this.panel3_groupBoxSetting.TabIndex = 5;
			this.panel3_groupBoxSetting.TabStop = false;
			this.panel3_groupBoxSetting.Text = "Settings";
			// 
			// panel3_settingLabel
			// 
			this.panel3_settingLabel.AutoSize = true;
			this.panel3_settingLabel.Location = new System.Drawing.Point(11, 35);
			this.panel3_settingLabel.Name = "panel3_settingLabel";
			this.panel3_settingLabel.Size = new System.Drawing.Size(0, 13);
			this.panel3_settingLabel.TabIndex = 3;
			// 
			// panel3_templatePathGroupBox
			// 
			this.panel3_templatePathGroupBox.Controls.Add(this.panel3_templatePathOpen);
			this.panel3_templatePathGroupBox.Controls.Add(this.panel3_templatePath);
			this.panel3_templatePathGroupBox.Location = new System.Drawing.Point(8, 154);
			this.panel3_templatePathGroupBox.Name = "panel3_templatePathGroupBox";
			this.panel3_templatePathGroupBox.Size = new System.Drawing.Size(727, 80);
			this.panel3_templatePathGroupBox.TabIndex = 2;
			this.panel3_templatePathGroupBox.TabStop = false;
			this.panel3_templatePathGroupBox.Text = "Template Selection";
			// 
			// panel3_templatePathOpen
			// 
			this.panel3_templatePathOpen.Location = new System.Drawing.Point(6, 45);
			this.panel3_templatePathOpen.Name = "panel3_templatePathOpen";
			this.panel3_templatePathOpen.Size = new System.Drawing.Size(100, 23);
			this.panel3_templatePathOpen.TabIndex = 1;
			this.panel3_templatePathOpen.Text = "Browse";
			this.panel3_templatePathOpen.UseVisualStyleBackColor = true;
			this.panel3_templatePathOpen.Click += new System.EventHandler(this.panel3_templatePathOpen_Click);
			// 
			// panel3_templatePath
			// 
			this.panel3_templatePath.BackColor = System.Drawing.SystemColors.Window;
			this.panel3_templatePath.Location = new System.Drawing.Point(6, 19);
			this.panel3_templatePath.Name = "panel3_templatePath";
			this.panel3_templatePath.ReadOnly = true;
			this.panel3_templatePath.Size = new System.Drawing.Size(715, 20);
			this.panel3_templatePath.TabIndex = 0;
			this.panel3_templatePath.Click += new System.EventHandler(this.panel3_templatePathOpen_Click);
			// 
			// panel3_outputFilePathGroupBox
			// 
			this.panel3_outputFilePathGroupBox.Controls.Add(this.panel3_outputPathSaveAs);
			this.panel3_outputFilePathGroupBox.Controls.Add(this.panel3_outputFilePath);
			this.panel3_outputFilePathGroupBox.Location = new System.Drawing.Point(8, 65);
			this.panel3_outputFilePathGroupBox.Name = "panel3_outputFilePathGroupBox";
			this.panel3_outputFilePathGroupBox.Size = new System.Drawing.Size(727, 80);
			this.panel3_outputFilePathGroupBox.TabIndex = 2;
			this.panel3_outputFilePathGroupBox.TabStop = false;
			this.panel3_outputFilePathGroupBox.Text = "Output File Path Selection";
			// 
			// panel3_outputPathSaveAs
			// 
			this.panel3_outputPathSaveAs.Location = new System.Drawing.Point(6, 45);
			this.panel3_outputPathSaveAs.Name = "panel3_outputPathSaveAs";
			this.panel3_outputPathSaveAs.Size = new System.Drawing.Size(100, 23);
			this.panel3_outputPathSaveAs.TabIndex = 1;
			this.panel3_outputPathSaveAs.Text = "Browse";
			this.panel3_outputPathSaveAs.UseVisualStyleBackColor = true;
			this.panel3_outputPathSaveAs.Click += new System.EventHandler(this.panel3_outputPathSaveAs_Click);
			// 
			// panel3_outputFilePath
			// 
			this.panel3_outputFilePath.BackColor = System.Drawing.SystemColors.Window;
			this.panel3_outputFilePath.Location = new System.Drawing.Point(6, 19);
			this.panel3_outputFilePath.Name = "panel3_outputFilePath";
			this.panel3_outputFilePath.ReadOnly = true;
			this.panel3_outputFilePath.Size = new System.Drawing.Size(715, 20);
			this.panel3_outputFilePath.TabIndex = 0;
			this.panel3_outputFilePath.Click += new System.EventHandler(this.panel3_outputPathSaveAs_Click);
			// 
			// one
			// 
			this.one.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.one.Location = new System.Drawing.Point(6, 16);
			this.one.Name = "one";
			this.one.Size = new System.Drawing.Size(150, 36);
			this.one.TabIndex = 0;
			this.one.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.five);
			this.groupBox1.Controls.Add(this.four);
			this.groupBox1.Controls.Add(this.three);
			this.groupBox1.Controls.Add(this.two);
			this.groupBox1.Controls.Add(this.one);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(984, 62);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Report Generator";
			// 
			// five
			// 
			this.five.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.five.Location = new System.Drawing.Point(630, 16);
			this.five.Name = "five";
			this.five.Size = new System.Drawing.Size(150, 36);
			this.five.TabIndex = 5;
			this.five.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// four
			// 
			this.four.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.four.Location = new System.Drawing.Point(474, 16);
			this.four.Name = "four";
			this.four.Size = new System.Drawing.Size(150, 36);
			this.four.TabIndex = 4;
			this.four.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// three
			// 
			this.three.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.three.Location = new System.Drawing.Point(318, 16);
			this.three.Name = "three";
			this.three.Size = new System.Drawing.Size(150, 36);
			this.three.TabIndex = 3;
			this.three.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// two
			// 
			this.two.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.two.Location = new System.Drawing.Point(162, 16);
			this.two.Name = "two";
			this.two.Size = new System.Drawing.Size(150, 36);
			this.two.TabIndex = 2;
			this.two.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// form3_label
			// 
			this.form3_label.AutoSize = true;
			this.form3_label.Location = new System.Drawing.Point(15, 517);
			this.form3_label.Name = "form3_label";
			this.form3_label.Size = new System.Drawing.Size(0, 13);
			this.form3_label.TabIndex = 12;
			// 
			// panel2_checkboxHigh
			// 
			this.panel2_checkboxHigh.AutoSize = true;
			this.panel2_checkboxHigh.Checked = true;
			this.panel2_checkboxHigh.CheckState = System.Windows.Forms.CheckState.Checked;
			this.panel2_checkboxHigh.Location = new System.Drawing.Point(45, 3);
			this.panel2_checkboxHigh.Name = "panel2_checkboxHigh";
			this.panel2_checkboxHigh.Size = new System.Drawing.Size(48, 17);
			this.panel2_checkboxHigh.TabIndex = 13;
			this.panel2_checkboxHigh.Text = "High";
			this.panel2_checkboxHigh.UseVisualStyleBackColor = true;
			this.panel2_checkboxHigh.CheckedChanged += new System.EventHandler(this.panel2_checkboxHigh_CheckedChanged);
			// 
			// panel2_checkboxMedium
			// 
			this.panel2_checkboxMedium.AutoSize = true;
			this.panel2_checkboxMedium.Checked = true;
			this.panel2_checkboxMedium.CheckState = System.Windows.Forms.CheckState.Checked;
			this.panel2_checkboxMedium.Location = new System.Drawing.Point(99, 3);
			this.panel2_checkboxMedium.Name = "panel2_checkboxMedium";
			this.panel2_checkboxMedium.Size = new System.Drawing.Size(63, 17);
			this.panel2_checkboxMedium.TabIndex = 13;
			this.panel2_checkboxMedium.Text = "Medium";
			this.panel2_checkboxMedium.UseVisualStyleBackColor = true;
			this.panel2_checkboxMedium.CheckedChanged += new System.EventHandler(this.panel2_checkboxMedium_CheckedChanged);
			// 
			// panel2_checkboxLow
			// 
			this.panel2_checkboxLow.AutoSize = true;
			this.panel2_checkboxLow.Checked = true;
			this.panel2_checkboxLow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.panel2_checkboxLow.Location = new System.Drawing.Point(168, 3);
			this.panel2_checkboxLow.Name = "panel2_checkboxLow";
			this.panel2_checkboxLow.Size = new System.Drawing.Size(46, 17);
			this.panel2_checkboxLow.TabIndex = 13;
			this.panel2_checkboxLow.Text = "Low";
			this.panel2_checkboxLow.UseVisualStyleBackColor = true;
			this.panel2_checkboxLow.CheckedChanged += new System.EventHandler(this.panel2_checkboxLow_CheckedChanged);
			// 
			// panel2_checkboxNone
			// 
			this.panel2_checkboxNone.AutoSize = true;
			this.panel2_checkboxNone.Checked = true;
			this.panel2_checkboxNone.CheckState = System.Windows.Forms.CheckState.Checked;
			this.panel2_checkboxNone.Location = new System.Drawing.Point(220, 3);
			this.panel2_checkboxNone.Name = "panel2_checkboxNone";
			this.panel2_checkboxNone.Size = new System.Drawing.Size(52, 17);
			this.panel2_checkboxNone.TabIndex = 13;
			this.panel2_checkboxNone.Text = "None";
			this.panel2_checkboxNone.UseVisualStyleBackColor = true;
			this.panel2_checkboxNone.CheckedChanged += new System.EventHandler(this.panel2_checkboxNone_CheckedChanged);
			// 
			// panel2_checkboxOpenPort
			// 
			this.panel2_checkboxOpenPort.AutoSize = true;
			this.panel2_checkboxOpenPort.Checked = true;
			this.panel2_checkboxOpenPort.CheckState = System.Windows.Forms.CheckState.Checked;
			this.panel2_checkboxOpenPort.Location = new System.Drawing.Point(278, 3);
			this.panel2_checkboxOpenPort.Name = "panel2_checkboxOpenPort";
			this.panel2_checkboxOpenPort.Size = new System.Drawing.Size(74, 17);
			this.panel2_checkboxOpenPort.TabIndex = 13;
			this.panel2_checkboxOpenPort.Text = "Open Port";
			this.panel2_checkboxOpenPort.UseVisualStyleBackColor = true;
			this.panel2_checkboxOpenPort.CheckedChanged += new System.EventHandler(this.panel2_checkboxOpenPort_CheckedChanged);
			// 
			// panel2_bottom
			// 
			this.panel2_bottom.Controls.Add(this.form3Panel2_noOfRowSelected);
			this.panel2_bottom.Controls.Add(this.panel2_showLabel);
			this.panel2_bottom.Controls.Add(this.panel2_checkboxHigh);
			this.panel2_bottom.Controls.Add(this.panel2_checkboxOpenPort);
			this.panel2_bottom.Controls.Add(this.panel2_checkboxMedium);
			this.panel2_bottom.Controls.Add(this.panel2_checkboxNone);
			this.panel2_bottom.Controls.Add(this.panel2_checkboxLow);
			this.panel2_bottom.Location = new System.Drawing.Point(17, 506);
			this.panel2_bottom.Name = "panel2_bottom";
			this.panel2_bottom.Size = new System.Drawing.Size(732, 36);
			this.panel2_bottom.TabIndex = 14;
			// 
			// form3Panel2_noOfRowSelected
			// 
			this.form3Panel2_noOfRowSelected.AutoSize = true;
			this.form3Panel2_noOfRowSelected.Location = new System.Drawing.Point(4, 19);
			this.form3Panel2_noOfRowSelected.Name = "form3Panel2_noOfRowSelected";
			this.form3Panel2_noOfRowSelected.Size = new System.Drawing.Size(0, 13);
			this.form3Panel2_noOfRowSelected.TabIndex = 15;
			// 
			// panel2_showLabel
			// 
			this.panel2_showLabel.AutoSize = true;
			this.panel2_showLabel.Location = new System.Drawing.Point(4, 4);
			this.panel2_showLabel.Name = "panel2_showLabel";
			this.panel2_showLabel.Size = new System.Drawing.Size(34, 13);
			this.panel2_showLabel.TabIndex = 14;
			this.panel2_showLabel.Text = "Show";
			// 
			// select
			// 
			this.select.FillWeight = 45F;
			this.select.HeaderText = "Select";
			this.select.Name = "select";
			this.select.ReadOnly = true;
			this.select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.select.Width = 45;
			// 
			// merge
			// 
			this.merge.FillWeight = 45F;
			this.merge.HeaderText = "Merge";
			this.merge.Name = "merge";
			this.merge.ReadOnly = true;
			this.merge.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.merge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.merge.Width = 45;
			// 
			// change
			// 
			this.change.FillWeight = 45F;
			this.change.HeaderText = "Edited";
			this.change.Name = "change";
			this.change.ReadOnly = true;
			this.change.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.change.Width = 45;
			// 
			// pluginName
			// 
			this.pluginName.FillWeight = 86F;
			this.pluginName.HeaderText = "Plugin Name";
			this.pluginName.Name = "pluginName";
			this.pluginName.ReadOnly = true;
			this.pluginName.Width = 86;
			// 
			// ipList
			// 
			this.ipList.FillWeight = 86F;
			this.ipList.HeaderText = "Host Affected";
			this.ipList.Name = "ipList";
			this.ipList.ReadOnly = true;
			this.ipList.Width = 86;
			// 
			// description
			// 
			this.description.FillWeight = 86F;
			this.description.HeaderText = "Description";
			this.description.Name = "description";
			this.description.ReadOnly = true;
			this.description.Width = 86;
			// 
			// impact
			// 
			this.impact.FillWeight = 86F;
			this.impact.HeaderText = "Impact";
			this.impact.Name = "impact";
			this.impact.ReadOnly = true;
			this.impact.Width = 86;
			// 
			// riskLevel
			// 
			this.riskLevel.FillWeight = 60F;
			this.riskLevel.HeaderText = "Risk Level";
			this.riskLevel.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low",
            "None",
            "OpenPort"});
			this.riskLevel.Name = "riskLevel";
			this.riskLevel.ReadOnly = true;
			this.riskLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.riskLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.riskLevel.Width = 60;
			// 
			// recommendations
			// 
			this.recommendations.FillWeight = 86F;
			this.recommendations.HeaderText = "Recommendations";
			this.recommendations.Name = "recommendations";
			this.recommendations.ReadOnly = true;
			this.recommendations.Width = 86;
			// 
			// reference_CVE
			// 
			this.reference_CVE.FillWeight = 86F;
			this.reference_CVE.HeaderText = "Reference (CVE)";
			this.reference_CVE.Name = "reference_CVE";
			this.reference_CVE.ReadOnly = true;
			this.reference_CVE.Width = 86;
			// 
			// reference_BID
			// 
			this.reference_BID.FillWeight = 86F;
			this.reference_BID.HeaderText = "Reference (BID)";
			this.reference_BID.Name = "reference_BID";
			this.reference_BID.ReadOnly = true;
			this.reference_BID.Width = 86;
			// 
			// reference_OSVDB
			// 
			this.reference_OSVDB.FillWeight = 86F;
			this.reference_OSVDB.HeaderText = "Reference (OSVDB)";
			this.reference_OSVDB.Name = "reference_OSVDB";
			this.reference_OSVDB.ReadOnly = true;
			this.reference_OSVDB.Width = 86;
			// 
			// referenceLink
			// 
			this.referenceLink.FillWeight = 66F;
			this.referenceLink.HeaderText = "Reference Link";
			this.referenceLink.Name = "referenceLink";
			this.referenceLink.ReadOnly = true;
			this.referenceLink.Width = 66;
			// 
			// id
			// 
			this.id.HeaderText = "Id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// oldId
			// 
			this.oldId.HeaderText = "oldId";
			this.oldId.Name = "oldId";
			this.oldId.ReadOnly = true;
			this.oldId.Visible = false;
			// 
			// Form3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(1008, 547);
			this.Controls.Add(this.form3_label);
			this.Controls.Add(this.main);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.back);
			this.Controls.Add(this.next);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel2_bottom);
			this.MaximumSize = new System.Drawing.Size(1024, 585);
			this.MinimumSize = new System.Drawing.Size(1024, 585);
			this.Name = "Form3";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ReportGenerator";
			this.main.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.panel4_dataGridView)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3_groupBoxOutputSelection.ResumeLayout(false);
			this.panel3_groupBoxSetting.ResumeLayout(false);
			this.panel3_groupBoxSetting.PerformLayout();
			this.panel3_templatePathGroupBox.ResumeLayout(false);
			this.panel3_templatePathGroupBox.PerformLayout();
			this.panel3_outputFilePathGroupBox.ResumeLayout(false);
			this.panel3_outputFilePathGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel2_bottom.ResumeLayout(false);
			this.panel2_bottom.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button next;
		private System.Windows.Forms.Button back;
		private System.Windows.Forms.GroupBox main;
		private System.Windows.Forms.Label one;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label two;
		private System.Windows.Forms.Label five;
		private System.Windows.Forms.Label four;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button panel1_importFile;
		private System.Windows.Forms.Button panel1_importFolder;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button panel1_selectAll;
		private System.Windows.Forms.Button panel1_reverse;
		private System.Windows.Forms.Button panel1_selectNone;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button panel2_reverse;
		private System.Windows.Forms.Button panel2_selectNone;
		private System.Windows.Forms.Button panel2_selectAll;
		private System.Windows.Forms.Button panel2_selectMerge;
		private System.Windows.Forms.Button panel2_selectUpdate;
		private System.Windows.Forms.Button panel2_mergeRecord;
		private System.Windows.Forms.Button panel2_updateRecord;
		private System.Windows.Forms.Button panel3_html;
		private System.Windows.Forms.Button panel3_xlsxDefault;
		private System.Windows.Forms.Button panel3_docxFromDocx;
		private System.Windows.Forms.Button panel3_docxDefault;
		private System.Windows.Forms.GroupBox panel3_groupBoxSetting;
		private System.Windows.Forms.GroupBox panel3_groupBoxOutputSelection;
		private System.Windows.Forms.GroupBox panel3_templatePathGroupBox;
		private System.Windows.Forms.Button panel3_templatePathOpen;
		private System.Windows.Forms.TextBox panel3_templatePath;
		private System.Windows.Forms.GroupBox panel3_outputFilePathGroupBox;
		private System.Windows.Forms.Button panel3_outputPathSaveAs;
		private System.Windows.Forms.TextBox panel3_outputFilePath;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label panel4_label1;
		private System.Windows.Forms.DataGridView panel4_dataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn replaceString;
		private System.Windows.Forms.DataGridViewTextBoxColumn stringAfterReplace;
		private System.Windows.Forms.Label panel3_settingLabel;
		private System.Windows.Forms.Label panel5_label1;
		private System.Windows.Forms.Label form3_label;
		private System.Windows.Forms.Label three;
		private System.Windows.Forms.CheckBox panel2_checkboxHigh;
		private System.Windows.Forms.CheckBox panel2_checkboxMedium;
		private System.Windows.Forms.CheckBox panel2_checkboxLow;
		private System.Windows.Forms.CheckBox panel2_checkboxNone;
		private System.Windows.Forms.CheckBox panel2_checkboxOpenPort;
		private System.Windows.Forms.Panel panel2_bottom;
		private System.Windows.Forms.Label panel2_labelSelectRiskLevel;
		private System.Windows.Forms.ComboBox panel2_ComboBox;
		private System.Windows.Forms.Label panel2_showLabel;
		private System.Windows.Forms.Label form3Panel2_noOfRowSelected;
		private System.Windows.Forms.Button panel2_saveConfig;
		private System.Windows.Forms.DataGridViewCheckBoxColumn select;
		private System.Windows.Forms.DataGridViewCheckBoxColumn merge;
		private System.Windows.Forms.DataGridViewCheckBoxColumn change;
		private System.Windows.Forms.DataGridViewTextBoxColumn pluginName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ipList;
		private System.Windows.Forms.DataGridViewTextBoxColumn description;
		private System.Windows.Forms.DataGridViewTextBoxColumn impact;
		private System.Windows.Forms.DataGridViewComboBoxColumn riskLevel;
		private System.Windows.Forms.DataGridViewTextBoxColumn recommendations;
		private System.Windows.Forms.DataGridViewTextBoxColumn reference_CVE;
		private System.Windows.Forms.DataGridViewTextBoxColumn reference_BID;
		private System.Windows.Forms.DataGridViewTextBoxColumn reference_OSVDB;
		private System.Windows.Forms.DataGridViewTextBoxColumn referenceLink;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn oldId;
	}
}

