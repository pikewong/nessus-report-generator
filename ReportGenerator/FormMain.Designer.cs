namespace ReportGenerator {
	partial class FormMain {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.formMain_groupBoxMain = new System.Windows.Forms.GroupBox();
            this.panelRecordEdit = new System.Windows.Forms.Panel();
            this.panelRecordEdit_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecordEdit_dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.oldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.databaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plugin_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plugin_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecordEdit_buttonMergeRecord = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonUpdateRecord = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonDeleteRecord = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonUndo = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonUp = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonDown = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecordEdit_comboBoxFilterMode = new System.Windows.Forms.ComboBox();
            this.panelRecordEdit_labelKeyword = new System.Windows.Forms.Label();
            this.panelRecordEdit_comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.panelRecordEdit_textBoxKeyWord = new System.Windows.Forms.TextBox();
            this.panelRecordEdit_buttonFilter = new System.Windows.Forms.Button();
            this.panelRecordEdit_comboBoxCase = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecordEdit_buttonSelectAll = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonSelectNone = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonSelectUpdate = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonSelectMerge = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonReverse = new System.Windows.Forms.Button();
            this.panelRecordEdit_comboBoxBottom = new System.Windows.Forms.ComboBox();
            this.panelRecordEdit_tableLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecordEdit_buttonPermanentDataBase = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonIPHostTable = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonSaveConfig = new System.Windows.Forms.Button();
            this.panelRecordEdit_buttonCreateExcel = new System.Windows.Forms.Button();
            this.panelOutputSelect = new System.Windows.Forms.Panel();
            this.panelOutputSelect_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelOutputSelect_groupBoxOutputSelection = new System.Windows.Forms.GroupBox();
            this.panelOutputSelect_tableLayoutLeft = new System.Windows.Forms.TableLayoutPanel();
            this.panelOutputSelect_buttonHtml = new System.Windows.Forms.Button();
            this.panelOutputSelect_buttonXlsxDefault = new System.Windows.Forms.Button();
            this.panelOutputSelect_buttonDocxFromDocx = new System.Windows.Forms.Button();
            this.panelOutputSelect_buttonDocxDefault = new System.Windows.Forms.Button();
            this.panelOutputSelect_groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.panelOutputSelect_TableLayoutRight = new System.Windows.Forms.TableLayoutPanel();
            this.panelOutputSelect_labelRightTopText = new System.Windows.Forms.Label();
            this.panelOutputSelect_groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            this.panelOutputSelect_labelTextFileBrowse = new System.Windows.Forms.Label();
            this.panelOutputSelect_textBoxTextFileBrowse = new System.Windows.Forms.TextBox();
            this.panelOutputSelect_buttonTextFileBrowse = new System.Windows.Forms.Button();
            this.panelOutputSelect_checkboxExportPluginOutput = new System.Windows.Forms.CheckBox();
            this.panelOutputSelect_checkboxIpHostOutput = new System.Windows.Forms.CheckBox();
            this.panelOutputSelect_checkboxOpenPortOutput = new System.Windows.Forms.CheckBox();
            this.panelOutputSelect_checkboxHotfixOutput = new System.Windows.Forms.CheckBox();
            this.panelOutputSelect_groupBoxOutputFilePath = new System.Windows.Forms.GroupBox();
            this.panelOutputSelect_buttonOutputPathSaveAs = new System.Windows.Forms.Button();
            this.panelOutputSelect_textBoxOutputFilePath = new System.Windows.Forms.TextBox();
            this.panelOutputSelect_groupBoxTemplatePath = new System.Windows.Forms.GroupBox();
            this.panelOutputSelect_buttonTemplatePathOpen = new System.Windows.Forms.Button();
            this.panelOutputSelect_textBoxTemplatePath = new System.Windows.Forms.TextBox();
            this.panelTemplateStringEdit = new System.Windows.Forms.Panel();
            this.panelTemplateStringEdit_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelTemplateStringEdit_labelTopText = new System.Windows.Forms.Label();
            this.panelTemplateStringEdit_dataGridView = new System.Windows.Forms.DataGridView();
            this.replaceString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stringAfterReplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFileInput = new System.Windows.Forms.Panel();
            this.panelFileInput_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelFileInput_tableLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.panelFileInput_buttonSelectAll = new System.Windows.Forms.Button();
            this.panelFileInput_buttonSelectNone = new System.Windows.Forms.Button();
            this.panelFileInput_buttonImportFile = new System.Windows.Forms.Button();
            this.panelFileInput_buttonClear = new System.Windows.Forms.Button();
            this.panelFileInput_buttonImportFolder = new System.Windows.Forms.Button();
            this.panelFileInput_buttonReverse = new System.Windows.Forms.Button();
            this.panelFileInput_labelFileList = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelFileInput_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.panelFileInput_treeViewFileName = new System.Windows.Forms.TreeView();
            this.panelRawView_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelRawView_tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelRawView_dataGridViewNmap = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelRawView_dataGridViewNessus = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panelRawView_dataGridViewMBSA = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelRawView_dataGridViewAcunetix = new System.Windows.Forms.DataGridView();
            this.panelRawView_treeViewFileName = new System.Windows.Forms.TreeView();
            this.panelLast = new System.Windows.Forms.Panel();
            this.panelLast_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelLast_labelText = new System.Windows.Forms.Label();
            this.panelRawView = new System.Windows.Forms.Panel();
            this.buttonGenExcelSelected = new System.Windows.Forms.Button();
            this.buttonGenExcel = new System.Windows.Forms.Button();
            this.panelRawView_buttonShowAll = new System.Windows.Forms.Button();
            this.panelRawView_labelKeyWord = new System.Windows.Forms.Label();
            this.panelRawView_textBoxKeyword = new System.Windows.Forms.TextBox();
            this.panelRawView_comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.panelRawView_buttonFilter = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Label();
            this.formMainTop_groupBox = new System.Windows.Forms.GroupBox();
            this.formMainTopTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.five = new System.Windows.Forms.Label();
            this.two = new System.Windows.Forms.Label();
            this.four = new System.Windows.Forms.Label();
            this.three = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelRecordEdit_checkboxHigh = new System.Windows.Forms.CheckBox();
            this.panelRecordEdit_checkboxMedium = new System.Windows.Forms.CheckBox();
            this.panelRecordEdit_checkboxLow = new System.Windows.Forms.CheckBox();
            this.panelRecordEdit_checkboxNone = new System.Windows.Forms.CheckBox();
            this.panelRecordEdit_checkboxOpenPort = new System.Windows.Forms.CheckBox();
            this.formMainBottomPanel = new System.Windows.Forms.Panel();
            this.panelRecordEdit_checkboxNessus = new System.Windows.Forms.CheckBox();
            this.panelRecordEdit_labelNoOfRowSelected = new System.Windows.Forms.Label();
            this.panelRecordEdit_checkboxNmap = new System.Windows.Forms.CheckBox();
            this.panelRecordEdit_checkboxMbsa = new System.Windows.Forms.CheckBox();
            this.panelRecordEdit_labelShow = new System.Windows.Forms.Label();
            this.formMainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.formMainTableLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.saveFileDialogExcel = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogExcelSelected = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogCreateExcelInPanelRecordEdit = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogTextFileBrowse = new System.Windows.Forms.OpenFileDialog();
            this.formMain_groupBoxMain.SuspendLayout();
            this.panelRecordEdit.SuspendLayout();
            this.panelRecordEdit_tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRecordEdit_dataGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panelRecordEdit_tableLayoutBottom.SuspendLayout();
            this.panelOutputSelect.SuspendLayout();
            this.panelOutputSelect_tableLayout.SuspendLayout();
            this.panelOutputSelect_groupBoxOutputSelection.SuspendLayout();
            this.panelOutputSelect_tableLayoutLeft.SuspendLayout();
            this.panelOutputSelect_groupBoxSetting.SuspendLayout();
            this.panelOutputSelect_TableLayoutRight.SuspendLayout();
            this.panelOutputSelect_groupBoxOtherSettings.SuspendLayout();
            this.panelOutputSelect_groupBoxOutputFilePath.SuspendLayout();
            this.panelOutputSelect_groupBoxTemplatePath.SuspendLayout();
            this.panelTemplateStringEdit.SuspendLayout();
            this.panelTemplateStringEdit_tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTemplateStringEdit_dataGridView)).BeginInit();
            this.panelFileInput.SuspendLayout();
            this.panelFileInput_tableLayout.SuspendLayout();
            this.panelFileInput_tableLayoutBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelRawView_tableLayoutPanel.SuspendLayout();
            this.panelRawView_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewNmap)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewNessus)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewMBSA)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewAcunetix)).BeginInit();
            this.panelLast.SuspendLayout();
            this.panelLast_tableLayout.SuspendLayout();
            this.panelRawView.SuspendLayout();
            this.formMainTop_groupBox.SuspendLayout();
            this.formMainTopTableLayout.SuspendLayout();
            this.formMainBottomPanel.SuspendLayout();
            this.formMainTableLayout.SuspendLayout();
            this.formMainTableLayoutBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCancel.Location = new System.Drawing.Point(878, 14);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(79, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonNext.Location = new System.Drawing.Point(793, 14);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(79, 23);
            this.buttonNext.TabIndex = 10;
            this.buttonNext.Text = "Next >";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonBack.Location = new System.Drawing.Point(708, 14);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(79, 23);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "< Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // formMain_groupBoxMain
            // 
            this.formMain_groupBoxMain.Controls.Add(this.panelRecordEdit);
            this.formMain_groupBoxMain.Controls.Add(this.panelOutputSelect);
            this.formMain_groupBoxMain.Controls.Add(this.panelTemplateStringEdit);
            this.formMain_groupBoxMain.Controls.Add(this.panelFileInput);
            this.formMain_groupBoxMain.Controls.Add(this.panelRawView_tableLayoutPanel);
            this.formMain_groupBoxMain.Controls.Add(this.panelLast);
            this.formMain_groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formMain_groupBoxMain.Location = new System.Drawing.Point(0, 70);
            this.formMain_groupBoxMain.Margin = new System.Windows.Forms.Padding(0);
            this.formMain_groupBoxMain.Name = "formMain_groupBoxMain";
            this.formMain_groupBoxMain.Size = new System.Drawing.Size(963, 436);
            this.formMain_groupBoxMain.TabIndex = 4;
            this.formMain_groupBoxMain.TabStop = false;
            this.formMain_groupBoxMain.Text = "Main";
            // 
            // panelRecordEdit
            // 
            this.panelRecordEdit.BackColor = System.Drawing.Color.Transparent;
            this.panelRecordEdit.Controls.Add(this.panelRecordEdit_tableLayout);
            this.panelRecordEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit.Location = new System.Drawing.Point(3, 16);
            this.panelRecordEdit.Name = "panelRecordEdit";
            this.panelRecordEdit.Size = new System.Drawing.Size(957, 417);
            this.panelRecordEdit.TabIndex = 11;
            // 
            // panelRecordEdit_tableLayout
            // 
            this.panelRecordEdit_tableLayout.ColumnCount = 1;
            this.panelRecordEdit_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRecordEdit_tableLayout.Controls.Add(this.panelRecordEdit_dataGridView, 0, 0);
            this.panelRecordEdit_tableLayout.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.panelRecordEdit_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.panelRecordEdit_tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.panelRecordEdit_tableLayout.Name = "panelRecordEdit_tableLayout";
            this.panelRecordEdit_tableLayout.RowCount = 2;
            this.panelRecordEdit_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRecordEdit_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.panelRecordEdit_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.panelRecordEdit_tableLayout.Size = new System.Drawing.Size(957, 417);
            this.panelRecordEdit_tableLayout.TabIndex = 104;
            // 
            // panelRecordEdit_dataGridView
            // 
            this.panelRecordEdit_dataGridView.AllowUserToAddRows = false;
            this.panelRecordEdit_dataGridView.AllowUserToDeleteRows = false;
            this.panelRecordEdit_dataGridView.AllowUserToResizeRows = false;
            this.panelRecordEdit_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.panelRecordEdit_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
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
            this.oldId,
            this.entryType,
            this.databaseId,
            this.plugin_version,
            this.plugin_ID});
            this.panelRecordEdit_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.panelRecordEdit_dataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.panelRecordEdit_dataGridView.Name = "panelRecordEdit_dataGridView";
            this.panelRecordEdit_dataGridView.ReadOnly = true;
            this.panelRecordEdit_dataGridView.RowHeadersVisible = false;
            this.panelRecordEdit_dataGridView.RowTemplate.Height = 24;
            this.panelRecordEdit_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.panelRecordEdit_dataGridView.Size = new System.Drawing.Size(957, 309);
            this.panelRecordEdit_dataGridView.TabIndex = 100;
            this.panelRecordEdit_dataGridView.TabStop = false;
            this.panelRecordEdit_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.panelRecordEdit_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.panelRecordEdit_dataGridView_CellContentClick);
            this.panelRecordEdit_dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.panelRecordEdit_dataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.panelRecordEdit_dataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.panelRecordEdit_dataGridView_SortCompare);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // select
            // 
            this.select.FillWeight = 45F;
            this.select.HeaderText = "Select";
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select.Width = 62;
            // 
            // merge
            // 
            this.merge.FillWeight = 45F;
            this.merge.HeaderText = "Merge";
            this.merge.Name = "merge";
            this.merge.ReadOnly = true;
            this.merge.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.merge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.merge.Width = 62;
            // 
            // change
            // 
            this.change.FillWeight = 45F;
            this.change.HeaderText = "Edited";
            this.change.Name = "change";
            this.change.ReadOnly = true;
            this.change.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.change.Width = 62;
            // 
            // pluginName
            // 
            this.pluginName.HeaderText = "Plugin Name";
            this.pluginName.Name = "pluginName";
            this.pluginName.ReadOnly = true;
            this.pluginName.Width = 92;
            // 
            // ipList
            // 
            this.ipList.FillWeight = 86F;
            this.ipList.HeaderText = "Host Affected";
            this.ipList.Name = "ipList";
            this.ipList.ReadOnly = true;
            this.ipList.Width = 97;
            // 
            // description
            // 
            this.description.FillWeight = 86F;
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 85;
            // 
            // impact
            // 
            this.impact.FillWeight = 86F;
            this.impact.HeaderText = "Impact";
            this.impact.Name = "impact";
            this.impact.ReadOnly = true;
            this.impact.Width = 64;
            // 
            // riskLevel
            // 
            this.riskLevel.FillWeight = 70F;
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
            this.riskLevel.Width = 82;
            // 
            // recommendations
            // 
            this.recommendations.FillWeight = 86F;
            this.recommendations.HeaderText = "Recommendations";
            this.recommendations.Name = "recommendations";
            this.recommendations.ReadOnly = true;
            this.recommendations.Width = 120;
            // 
            // reference_CVE
            // 
            this.reference_CVE.FillWeight = 67F;
            this.reference_CVE.HeaderText = "Reference (CVE)";
            this.reference_CVE.Name = "reference_CVE";
            this.reference_CVE.ReadOnly = true;
            this.reference_CVE.Width = 112;
            // 
            // reference_BID
            // 
            this.reference_BID.FillWeight = 67F;
            this.reference_BID.HeaderText = "Reference (BID)";
            this.reference_BID.Name = "reference_BID";
            this.reference_BID.ReadOnly = true;
            this.reference_BID.Width = 109;
            // 
            // reference_OSVDB
            // 
            this.reference_OSVDB.FillWeight = 67F;
            this.reference_OSVDB.HeaderText = "Reference (OSVDB)";
            this.reference_OSVDB.Name = "reference_OSVDB";
            this.reference_OSVDB.ReadOnly = true;
            this.reference_OSVDB.Width = 128;
            // 
            // referenceLink
            // 
            this.referenceLink.FillWeight = 67F;
            this.referenceLink.HeaderText = "Reference Link";
            this.referenceLink.Name = "referenceLink";
            this.referenceLink.ReadOnly = true;
            this.referenceLink.Width = 105;
            // 
            // oldId
            // 
            this.oldId.HeaderText = "oldID";
            this.oldId.Name = "oldId";
            this.oldId.ReadOnly = true;
            this.oldId.Visible = false;
            this.oldId.Width = 57;
            // 
            // entryType
            // 
            this.entryType.FillWeight = 65F;
            this.entryType.HeaderText = "Entry Type";
            this.entryType.Items.AddRange(new object[] {
            "NESSUS",
            "MBSA",
            "NMAP",
            "Acunetix",
            "MBSA_NESSUS"});
            this.entryType.Name = "entryType";
            this.entryType.ReadOnly = true;
            this.entryType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.entryType.Width = 83;
            // 
            // databaseId
            // 
            this.databaseId.HeaderText = "Database ID";
            this.databaseId.Name = "databaseId";
            this.databaseId.ReadOnly = true;
            this.databaseId.Visible = false;
            this.databaseId.Width = 92;
            // 
            // plugin_version
            // 
            this.plugin_version.HeaderText = "plugin_version";
            this.plugin_version.Name = "plugin_version";
            this.plugin_version.ReadOnly = true;
            this.plugin_version.Visible = false;
            // 
            // plugin_ID
            // 
            this.plugin_ID.HeaderText = "plugin_ID";
            this.plugin_ID.Name = "plugin_ID";
            this.plugin_ID.ReadOnly = true;
            this.plugin_ID.Visible = false;
            this.plugin_ID.Width = 77;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.1811F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.11811F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.79921F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelRecordEdit_tableLayoutBottom, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 312);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(951, 102);
            this.tableLayoutPanel2.TabIndex = 101;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(251, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(517, 96);
            this.tableLayoutPanel3.TabIndex = 107;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Controls.Add(this.panelRecordEdit_buttonMergeRecord, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelRecordEdit_buttonUpdateRecord, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelRecordEdit_buttonDeleteRecord, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelRecordEdit_buttonUndo, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelRecordEdit_buttonUp, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelRecordEdit_buttonDown, 5, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(511, 42);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panelRecordEdit_buttonMergeRecord
            // 
            this.panelRecordEdit_buttonMergeRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonMergeRecord.Enabled = false;
            this.panelRecordEdit_buttonMergeRecord.Location = new System.Drawing.Point(4, 4);
            this.panelRecordEdit_buttonMergeRecord.Name = "panelRecordEdit_buttonMergeRecord";
            this.panelRecordEdit_buttonMergeRecord.Size = new System.Drawing.Size(94, 34);
            this.panelRecordEdit_buttonMergeRecord.TabIndex = 7;
            this.panelRecordEdit_buttonMergeRecord.Text = "Merge Record";
            this.panelRecordEdit_buttonMergeRecord.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonMergeRecord.Click += new System.EventHandler(this.panelRecordEdit_buttonMergeRecord_Click);
            // 
            // panelRecordEdit_buttonUpdateRecord
            // 
            this.panelRecordEdit_buttonUpdateRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonUpdateRecord.Enabled = false;
            this.panelRecordEdit_buttonUpdateRecord.Location = new System.Drawing.Point(105, 4);
            this.panelRecordEdit_buttonUpdateRecord.Name = "panelRecordEdit_buttonUpdateRecord";
            this.panelRecordEdit_buttonUpdateRecord.Size = new System.Drawing.Size(94, 34);
            this.panelRecordEdit_buttonUpdateRecord.TabIndex = 8;
            this.panelRecordEdit_buttonUpdateRecord.Text = "Edit Record";
            this.panelRecordEdit_buttonUpdateRecord.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonUpdateRecord.Click += new System.EventHandler(this.panelRecordEdit_buttonUpdateRecord_Click);
            // 
            // panelRecordEdit_buttonDeleteRecord
            // 
            this.panelRecordEdit_buttonDeleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonDeleteRecord.Location = new System.Drawing.Point(206, 4);
            this.panelRecordEdit_buttonDeleteRecord.Name = "panelRecordEdit_buttonDeleteRecord";
            this.panelRecordEdit_buttonDeleteRecord.Size = new System.Drawing.Size(94, 34);
            this.panelRecordEdit_buttonDeleteRecord.TabIndex = 123;
            this.panelRecordEdit_buttonDeleteRecord.Text = "Delete Record";
            this.panelRecordEdit_buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonDeleteRecord.Click += new System.EventHandler(this.panelRecordEdit_buttonDeleteRecord_Click);
            // 
            // panelRecordEdit_buttonUndo
            // 
            this.panelRecordEdit_buttonUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonUndo.Enabled = false;
            this.panelRecordEdit_buttonUndo.Location = new System.Drawing.Point(307, 4);
            this.panelRecordEdit_buttonUndo.Name = "panelRecordEdit_buttonUndo";
            this.panelRecordEdit_buttonUndo.Size = new System.Drawing.Size(94, 34);
            this.panelRecordEdit_buttonUndo.TabIndex = 124;
            this.panelRecordEdit_buttonUndo.Text = "Undo";
            this.panelRecordEdit_buttonUndo.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonUndo.Click += new System.EventHandler(this.panelRecordEdit_buttonUndo_Click);
            // 
            // panelRecordEdit_buttonUp
            // 
            this.panelRecordEdit_buttonUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonUp.Location = new System.Drawing.Point(408, 4);
            this.panelRecordEdit_buttonUp.Name = "panelRecordEdit_buttonUp";
            this.panelRecordEdit_buttonUp.Size = new System.Drawing.Size(44, 34);
            this.panelRecordEdit_buttonUp.TabIndex = 125;
            this.panelRecordEdit_buttonUp.Text = "↑";
            this.panelRecordEdit_buttonUp.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonUp.Click += new System.EventHandler(this.panelRecordEdit_buttonUp_Click);
            // 
            // panelRecordEdit_buttonDown
            // 
            this.panelRecordEdit_buttonDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonDown.Location = new System.Drawing.Point(459, 4);
            this.panelRecordEdit_buttonDown.Name = "panelRecordEdit_buttonDown";
            this.panelRecordEdit_buttonDown.Size = new System.Drawing.Size(48, 34);
            this.panelRecordEdit_buttonDown.TabIndex = 126;
            this.panelRecordEdit_buttonDown.Text = "↓";
            this.panelRecordEdit_buttonDown.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonDown.Click += new System.EventHandler(this.panelRecordEdit_buttonDown_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 6;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.88889F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.68191F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.05567F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4831F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tableLayoutPanel6.Controls.Add(this.panelRecordEdit_comboBoxFilterMode, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.panelRecordEdit_labelKeyword, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.panelRecordEdit_comboBoxFilter, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.panelRecordEdit_textBoxKeyWord, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.panelRecordEdit_buttonFilter, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.panelRecordEdit_comboBoxCase, 4, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(511, 42);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // panelRecordEdit_comboBoxFilterMode
            // 
            this.panelRecordEdit_comboBoxFilterMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRecordEdit_comboBoxFilterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.panelRecordEdit_comboBoxFilterMode.FormattingEnabled = true;
            this.panelRecordEdit_comboBoxFilterMode.Items.AddRange(new object[] {
            "Partial Filter",
            "Exact Match Filter"});
            this.panelRecordEdit_comboBoxFilterMode.Location = new System.Drawing.Point(129, 10);
            this.panelRecordEdit_comboBoxFilterMode.Name = "panelRecordEdit_comboBoxFilterMode";
            this.panelRecordEdit_comboBoxFilterMode.Size = new System.Drawing.Size(35, 21);
            this.panelRecordEdit_comboBoxFilterMode.TabIndex = 118;
            // 
            // panelRecordEdit_labelKeyword
            // 
            this.panelRecordEdit_labelKeyword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRecordEdit_labelKeyword.AutoSize = true;
            this.panelRecordEdit_labelKeyword.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.panelRecordEdit_labelKeyword.Location = new System.Drawing.Point(5, 1);
            this.panelRecordEdit_labelKeyword.Name = "panelRecordEdit_labelKeyword";
            this.panelRecordEdit_labelKeyword.Size = new System.Drawing.Size(23, 40);
            this.panelRecordEdit_labelKeyword.TabIndex = 107;
            this.panelRecordEdit_labelKeyword.Text = "Keyword : ";
            // 
            // panelRecordEdit_comboBoxFilter
            // 
            this.panelRecordEdit_comboBoxFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRecordEdit_comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.panelRecordEdit_comboBoxFilter.FormattingEnabled = true;
            this.panelRecordEdit_comboBoxFilter.Items.AddRange(new object[] {
            "Plugin Name",
            "Host Affected",
            "Description",
            "Impact",
            "Risk Level",
            "Recommendation",
            "CVE",
            "BID",
            "OSVDB",
            "Reference Link"});
            this.panelRecordEdit_comboBoxFilter.Location = new System.Drawing.Point(78, 10);
            this.panelRecordEdit_comboBoxFilter.Name = "panelRecordEdit_comboBoxFilter";
            this.panelRecordEdit_comboBoxFilter.Size = new System.Drawing.Size(44, 21);
            this.panelRecordEdit_comboBoxFilter.TabIndex = 18;
            // 
            // panelRecordEdit_textBoxKeyWord
            // 
            this.panelRecordEdit_textBoxKeyWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRecordEdit_textBoxKeyWord.Location = new System.Drawing.Point(36, 11);
            this.panelRecordEdit_textBoxKeyWord.Name = "panelRecordEdit_textBoxKeyWord";
            this.panelRecordEdit_textBoxKeyWord.Size = new System.Drawing.Size(35, 20);
            this.panelRecordEdit_textBoxKeyWord.TabIndex = 18;
            // 
            // panelRecordEdit_buttonFilter
            // 
            this.panelRecordEdit_buttonFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonFilter.Location = new System.Drawing.Point(218, 4);
            this.panelRecordEdit_buttonFilter.Name = "panelRecordEdit_buttonFilter";
            this.panelRecordEdit_buttonFilter.Size = new System.Drawing.Size(289, 34);
            this.panelRecordEdit_buttonFilter.TabIndex = 17;
            this.panelRecordEdit_buttonFilter.Text = "Filter";
            this.panelRecordEdit_buttonFilter.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonFilter.Click += new System.EventHandler(this.panelRecordEdit_buttonFilter_Click);
            // 
            // panelRecordEdit_comboBoxCase
            // 
            this.panelRecordEdit_comboBoxCase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRecordEdit_comboBoxCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.panelRecordEdit_comboBoxCase.FormattingEnabled = true;
            this.panelRecordEdit_comboBoxCase.Items.AddRange(new object[] {
            "Case insensitive",
            "Case sensitive"});
            this.panelRecordEdit_comboBoxCase.Location = new System.Drawing.Point(171, 10);
            this.panelRecordEdit_comboBoxCase.Name = "panelRecordEdit_comboBoxCase";
            this.panelRecordEdit_comboBoxCase.Size = new System.Drawing.Size(40, 21);
            this.panelRecordEdit_comboBoxCase.TabIndex = 119;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.Controls.Add(this.panelRecordEdit_buttonSelectAll, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.panelRecordEdit_buttonSelectNone, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.panelRecordEdit_buttonSelectUpdate, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.panelRecordEdit_buttonSelectMerge, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.panelRecordEdit_buttonReverse, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.panelRecordEdit_comboBoxBottom, 2, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(242, 96);
            this.tableLayoutPanel5.TabIndex = 108;
            // 
            // panelRecordEdit_buttonSelectAll
            // 
            this.panelRecordEdit_buttonSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonSelectAll.Location = new System.Drawing.Point(4, 4);
            this.panelRecordEdit_buttonSelectAll.Name = "panelRecordEdit_buttonSelectAll";
            this.panelRecordEdit_buttonSelectAll.Size = new System.Drawing.Size(73, 40);
            this.panelRecordEdit_buttonSelectAll.TabIndex = 0;
            this.panelRecordEdit_buttonSelectAll.Text = "Select All";
            this.panelRecordEdit_buttonSelectAll.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonSelectAll.Click += new System.EventHandler(this.panelRecordEdit_buttonSelectAll_Click);
            // 
            // panelRecordEdit_buttonSelectNone
            // 
            this.panelRecordEdit_buttonSelectNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonSelectNone.Location = new System.Drawing.Point(4, 51);
            this.panelRecordEdit_buttonSelectNone.Name = "panelRecordEdit_buttonSelectNone";
            this.panelRecordEdit_buttonSelectNone.Size = new System.Drawing.Size(73, 41);
            this.panelRecordEdit_buttonSelectNone.TabIndex = 1;
            this.panelRecordEdit_buttonSelectNone.Text = "Select None";
            this.panelRecordEdit_buttonSelectNone.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonSelectNone.Click += new System.EventHandler(this.panelRecordEdit_buttonSelectNone_Click);
            // 
            // panelRecordEdit_buttonSelectUpdate
            // 
            this.panelRecordEdit_buttonSelectUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonSelectUpdate.Location = new System.Drawing.Point(84, 4);
            this.panelRecordEdit_buttonSelectUpdate.Name = "panelRecordEdit_buttonSelectUpdate";
            this.panelRecordEdit_buttonSelectUpdate.Size = new System.Drawing.Size(73, 40);
            this.panelRecordEdit_buttonSelectUpdate.TabIndex = 5;
            this.panelRecordEdit_buttonSelectUpdate.Text = "Select Edited";
            this.panelRecordEdit_buttonSelectUpdate.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonSelectUpdate.Click += new System.EventHandler(this.panelRecordEdit_buttonSelectUpdate_Click);
            // 
            // panelRecordEdit_buttonSelectMerge
            // 
            this.panelRecordEdit_buttonSelectMerge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonSelectMerge.Location = new System.Drawing.Point(84, 51);
            this.panelRecordEdit_buttonSelectMerge.Name = "panelRecordEdit_buttonSelectMerge";
            this.panelRecordEdit_buttonSelectMerge.Size = new System.Drawing.Size(73, 41);
            this.panelRecordEdit_buttonSelectMerge.TabIndex = 3;
            this.panelRecordEdit_buttonSelectMerge.Text = "Select Merged";
            this.panelRecordEdit_buttonSelectMerge.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonSelectMerge.Click += new System.EventHandler(this.panelRecordEdit_buttonSelectMerge_Click);
            // 
            // panelRecordEdit_buttonReverse
            // 
            this.panelRecordEdit_buttonReverse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonReverse.Location = new System.Drawing.Point(164, 4);
            this.panelRecordEdit_buttonReverse.Name = "panelRecordEdit_buttonReverse";
            this.panelRecordEdit_buttonReverse.Size = new System.Drawing.Size(74, 40);
            this.panelRecordEdit_buttonReverse.TabIndex = 6;
            this.panelRecordEdit_buttonReverse.Text = "Reverse Select";
            this.panelRecordEdit_buttonReverse.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonReverse.Click += new System.EventHandler(this.panelRecordEdit_buttonSelectReverse_Click);
            // 
            // panelRecordEdit_comboBoxBottom
            // 
            this.panelRecordEdit_comboBoxBottom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRecordEdit_comboBoxBottom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.panelRecordEdit_comboBoxBottom.FormattingEnabled = true;
            this.panelRecordEdit_comboBoxBottom.Items.AddRange(new object[] {
            "Select Risk",
            "High",
            "Medium",
            "Low",
            "None",
            "Open Port"});
            this.panelRecordEdit_comboBoxBottom.Location = new System.Drawing.Point(164, 61);
            this.panelRecordEdit_comboBoxBottom.Name = "panelRecordEdit_comboBoxBottom";
            this.panelRecordEdit_comboBoxBottom.Size = new System.Drawing.Size(74, 21);
            this.panelRecordEdit_comboBoxBottom.TabIndex = 101;
            // 
            // panelRecordEdit_tableLayoutBottom
            // 
            this.panelRecordEdit_tableLayoutBottom.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelRecordEdit_tableLayoutBottom.ColumnCount = 2;
            this.panelRecordEdit_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.84298F));
            this.panelRecordEdit_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.15702F));
            this.panelRecordEdit_tableLayoutBottom.Controls.Add(this.panelRecordEdit_buttonPermanentDataBase, 1, 1);
            this.panelRecordEdit_tableLayoutBottom.Controls.Add(this.panelRecordEdit_buttonIPHostTable, 1, 0);
            this.panelRecordEdit_tableLayoutBottom.Controls.Add(this.panelRecordEdit_buttonSaveConfig, 0, 0);
            this.panelRecordEdit_tableLayoutBottom.Controls.Add(this.panelRecordEdit_buttonCreateExcel, 0, 1);
            this.panelRecordEdit_tableLayoutBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_tableLayoutBottom.Location = new System.Drawing.Point(771, 0);
            this.panelRecordEdit_tableLayoutBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelRecordEdit_tableLayoutBottom.Name = "panelRecordEdit_tableLayoutBottom";
            this.panelRecordEdit_tableLayoutBottom.RowCount = 2;
            this.panelRecordEdit_tableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.panelRecordEdit_tableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.panelRecordEdit_tableLayoutBottom.Size = new System.Drawing.Size(180, 102);
            this.panelRecordEdit_tableLayoutBottom.TabIndex = 106;
            // 
            // panelRecordEdit_buttonPermanentDataBase
            // 
            this.panelRecordEdit_buttonPermanentDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonPermanentDataBase.Location = new System.Drawing.Point(73, 61);
            this.panelRecordEdit_buttonPermanentDataBase.Name = "panelRecordEdit_buttonPermanentDataBase";
            this.panelRecordEdit_buttonPermanentDataBase.Size = new System.Drawing.Size(103, 37);
            this.panelRecordEdit_buttonPermanentDataBase.TabIndex = 119;
            this.panelRecordEdit_buttonPermanentDataBase.Text = "Permanent Database";
            this.panelRecordEdit_buttonPermanentDataBase.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonPermanentDataBase.Click += new System.EventHandler(this.panelRecordEdit_buttonPermanentDataBase_Click);
            // 
            // panelRecordEdit_buttonIPHostTable
            // 
            this.panelRecordEdit_buttonIPHostTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonIPHostTable.Location = new System.Drawing.Point(73, 4);
            this.panelRecordEdit_buttonIPHostTable.Name = "panelRecordEdit_buttonIPHostTable";
            this.panelRecordEdit_buttonIPHostTable.Size = new System.Drawing.Size(103, 50);
            this.panelRecordEdit_buttonIPHostTable.TabIndex = 120;
            this.panelRecordEdit_buttonIPHostTable.Text = "IP Host Table";
            this.panelRecordEdit_buttonIPHostTable.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonIPHostTable.Click += new System.EventHandler(this.panelRecordEdit_buttonIPHostTable_Click);
            // 
            // panelRecordEdit_buttonSaveConfig
            // 
            this.panelRecordEdit_buttonSaveConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecordEdit_buttonSaveConfig.Location = new System.Drawing.Point(4, 4);
            this.panelRecordEdit_buttonSaveConfig.Name = "panelRecordEdit_buttonSaveConfig";
            this.panelRecordEdit_buttonSaveConfig.Size = new System.Drawing.Size(62, 50);
            this.panelRecordEdit_buttonSaveConfig.TabIndex = 122;
            this.panelRecordEdit_buttonSaveConfig.Text = "Save Status";
            this.panelRecordEdit_buttonSaveConfig.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonSaveConfig.Click += new System.EventHandler(this.panelRecordEdit_saveConfig_Click);
            // 
            // panelRecordEdit_buttonCreateExcel
            // 
            this.panelRecordEdit_buttonCreateExcel.Location = new System.Drawing.Point(4, 61);
            this.panelRecordEdit_buttonCreateExcel.Name = "panelRecordEdit_buttonCreateExcel";
            this.panelRecordEdit_buttonCreateExcel.Size = new System.Drawing.Size(61, 37);
            this.panelRecordEdit_buttonCreateExcel.TabIndex = 123;
            this.panelRecordEdit_buttonCreateExcel.Text = "Create Excel";
            this.panelRecordEdit_buttonCreateExcel.UseVisualStyleBackColor = true;
            this.panelRecordEdit_buttonCreateExcel.Click += new System.EventHandler(this.panelRecordEdit_buttonCreateExcel_Click);
            // 
            // panelOutputSelect
            // 
            this.panelOutputSelect.BackColor = System.Drawing.Color.Transparent;
            this.panelOutputSelect.Controls.Add(this.panelOutputSelect_tableLayout);
            this.panelOutputSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect.Location = new System.Drawing.Point(3, 16);
            this.panelOutputSelect.Name = "panelOutputSelect";
            this.panelOutputSelect.Size = new System.Drawing.Size(957, 417);
            this.panelOutputSelect.TabIndex = 10;
            // 
            // panelOutputSelect_tableLayout
            // 
            this.panelOutputSelect_tableLayout.ColumnCount = 2;
            this.panelOutputSelect_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelOutputSelect_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.panelOutputSelect_tableLayout.Controls.Add(this.panelOutputSelect_groupBoxOutputSelection, 0, 0);
            this.panelOutputSelect_tableLayout.Controls.Add(this.panelOutputSelect_groupBoxSetting, 1, 0);
            this.panelOutputSelect_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.panelOutputSelect_tableLayout.Name = "panelOutputSelect_tableLayout";
            this.panelOutputSelect_tableLayout.RowCount = 1;
            this.panelOutputSelect_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelOutputSelect_tableLayout.Size = new System.Drawing.Size(957, 417);
            this.panelOutputSelect_tableLayout.TabIndex = 13;
            // 
            // panelOutputSelect_groupBoxOutputSelection
            // 
            this.panelOutputSelect_groupBoxOutputSelection.Controls.Add(this.panelOutputSelect_tableLayoutLeft);
            this.panelOutputSelect_groupBoxOutputSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_groupBoxOutputSelection.Location = new System.Drawing.Point(3, 3);
            this.panelOutputSelect_groupBoxOutputSelection.Name = "panelOutputSelect_groupBoxOutputSelection";
            this.panelOutputSelect_groupBoxOutputSelection.Size = new System.Drawing.Size(233, 411);
            this.panelOutputSelect_groupBoxOutputSelection.TabIndex = 6;
            this.panelOutputSelect_groupBoxOutputSelection.TabStop = false;
            this.panelOutputSelect_groupBoxOutputSelection.Text = "Output Selection";
            // 
            // panelOutputSelect_tableLayoutLeft
            // 
            this.panelOutputSelect_tableLayoutLeft.ColumnCount = 1;
            this.panelOutputSelect_tableLayoutLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelOutputSelect_tableLayoutLeft.Controls.Add(this.panelOutputSelect_buttonHtml, 0, 0);
            this.panelOutputSelect_tableLayoutLeft.Controls.Add(this.panelOutputSelect_buttonXlsxDefault, 0, 3);
            this.panelOutputSelect_tableLayoutLeft.Controls.Add(this.panelOutputSelect_buttonDocxFromDocx, 0, 2);
            this.panelOutputSelect_tableLayoutLeft.Controls.Add(this.panelOutputSelect_buttonDocxDefault, 0, 1);
            this.panelOutputSelect_tableLayoutLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_tableLayoutLeft.Location = new System.Drawing.Point(3, 16);
            this.panelOutputSelect_tableLayoutLeft.Name = "panelOutputSelect_tableLayoutLeft";
            this.panelOutputSelect_tableLayoutLeft.RowCount = 4;
            this.panelOutputSelect_tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelOutputSelect_tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelOutputSelect_tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelOutputSelect_tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelOutputSelect_tableLayoutLeft.Size = new System.Drawing.Size(227, 392);
            this.panelOutputSelect_tableLayoutLeft.TabIndex = 4;
            // 
            // panelOutputSelect_buttonHtml
            // 
            this.panelOutputSelect_buttonHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_buttonHtml.Location = new System.Drawing.Point(3, 3);
            this.panelOutputSelect_buttonHtml.Name = "panelOutputSelect_buttonHtml";
            this.panelOutputSelect_buttonHtml.Size = new System.Drawing.Size(221, 92);
            this.panelOutputSelect_buttonHtml.TabIndex = 0;
            this.panelOutputSelect_buttonHtml.Text = "HTML";
            this.panelOutputSelect_buttonHtml.UseVisualStyleBackColor = true;
            this.panelOutputSelect_buttonHtml.Click += new System.EventHandler(this.panelOutputSelect_buttonHtml_Click);
            // 
            // panelOutputSelect_buttonXlsxDefault
            // 
            this.panelOutputSelect_buttonXlsxDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_buttonXlsxDefault.Location = new System.Drawing.Point(3, 297);
            this.panelOutputSelect_buttonXlsxDefault.Name = "panelOutputSelect_buttonXlsxDefault";
            this.panelOutputSelect_buttonXlsxDefault.Size = new System.Drawing.Size(221, 92);
            this.panelOutputSelect_buttonXlsxDefault.TabIndex = 3;
            this.panelOutputSelect_buttonXlsxDefault.Text = "XLSX with no style applied";
            this.panelOutputSelect_buttonXlsxDefault.UseVisualStyleBackColor = true;
            this.panelOutputSelect_buttonXlsxDefault.Click += new System.EventHandler(this.panelOutputSelect_buttonXlsxDefault_Click);
            // 
            // panelOutputSelect_buttonDocxFromDocx
            // 
            this.panelOutputSelect_buttonDocxFromDocx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_buttonDocxFromDocx.Location = new System.Drawing.Point(3, 199);
            this.panelOutputSelect_buttonDocxFromDocx.Name = "panelOutputSelect_buttonDocxFromDocx";
            this.panelOutputSelect_buttonDocxFromDocx.Size = new System.Drawing.Size(221, 92);
            this.panelOutputSelect_buttonDocxFromDocx.TabIndex = 2;
            this.panelOutputSelect_buttonDocxFromDocx.Text = "DOCX with style from DOCX file";
            this.panelOutputSelect_buttonDocxFromDocx.UseVisualStyleBackColor = true;
            this.panelOutputSelect_buttonDocxFromDocx.Click += new System.EventHandler(this.panelOutputSelect_buttonDocxFromDocx_Click);
            // 
            // panelOutputSelect_buttonDocxDefault
            // 
            this.panelOutputSelect_buttonDocxDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_buttonDocxDefault.Location = new System.Drawing.Point(3, 101);
            this.panelOutputSelect_buttonDocxDefault.Name = "panelOutputSelect_buttonDocxDefault";
            this.panelOutputSelect_buttonDocxDefault.Size = new System.Drawing.Size(221, 92);
            this.panelOutputSelect_buttonDocxDefault.TabIndex = 1;
            this.panelOutputSelect_buttonDocxDefault.Text = "DOCX with no style applied";
            this.panelOutputSelect_buttonDocxDefault.UseVisualStyleBackColor = true;
            this.panelOutputSelect_buttonDocxDefault.Click += new System.EventHandler(this.panelOutputSelect_buttonDocxDefault_Click);
            // 
            // panelOutputSelect_groupBoxSetting
            // 
            this.panelOutputSelect_groupBoxSetting.Controls.Add(this.panelOutputSelect_TableLayoutRight);
            this.panelOutputSelect_groupBoxSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_groupBoxSetting.Location = new System.Drawing.Point(242, 3);
            this.panelOutputSelect_groupBoxSetting.Name = "panelOutputSelect_groupBoxSetting";
            this.panelOutputSelect_groupBoxSetting.Size = new System.Drawing.Size(712, 411);
            this.panelOutputSelect_groupBoxSetting.TabIndex = 5;
            this.panelOutputSelect_groupBoxSetting.TabStop = false;
            this.panelOutputSelect_groupBoxSetting.Text = "Settings";
            // 
            // panelOutputSelect_TableLayoutRight
            // 
            this.panelOutputSelect_TableLayoutRight.ColumnCount = 1;
            this.panelOutputSelect_TableLayoutRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelOutputSelect_TableLayoutRight.Controls.Add(this.panelOutputSelect_labelRightTopText, 0, 0);
            this.panelOutputSelect_TableLayoutRight.Controls.Add(this.panelOutputSelect_groupBoxOtherSettings, 0, 2);
            this.panelOutputSelect_TableLayoutRight.Controls.Add(this.panelOutputSelect_groupBoxOutputFilePath, 0, 1);
            this.panelOutputSelect_TableLayoutRight.Controls.Add(this.panelOutputSelect_groupBoxTemplatePath, 0, 3);
            this.panelOutputSelect_TableLayoutRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_TableLayoutRight.Location = new System.Drawing.Point(3, 16);
            this.panelOutputSelect_TableLayoutRight.Name = "panelOutputSelect_TableLayoutRight";
            this.panelOutputSelect_TableLayoutRight.RowCount = 5;
            this.panelOutputSelect_TableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelOutputSelect_TableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelOutputSelect_TableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelOutputSelect_TableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelOutputSelect_TableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelOutputSelect_TableLayoutRight.Size = new System.Drawing.Size(706, 392);
            this.panelOutputSelect_TableLayoutRight.TabIndex = 5;
            // 
            // panelOutputSelect_labelRightTopText
            // 
            this.panelOutputSelect_labelRightTopText.AutoSize = true;
            this.panelOutputSelect_labelRightTopText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOutputSelect_labelRightTopText.Location = new System.Drawing.Point(3, 17);
            this.panelOutputSelect_labelRightTopText.Name = "panelOutputSelect_labelRightTopText";
            this.panelOutputSelect_labelRightTopText.Size = new System.Drawing.Size(700, 13);
            this.panelOutputSelect_labelRightTopText.TabIndex = 3;
            // 
            // panelOutputSelect_groupBoxOtherSettings
            // 
            this.panelOutputSelect_groupBoxOtherSettings.Controls.Add(this.panelOutputSelect_labelTextFileBrowse);
            this.panelOutputSelect_groupBoxOtherSettings.Controls.Add(this.panelOutputSelect_textBoxTextFileBrowse);
            this.panelOutputSelect_groupBoxOtherSettings.Controls.Add(this.panelOutputSelect_buttonTextFileBrowse);
            this.panelOutputSelect_groupBoxOtherSettings.Controls.Add(this.panelOutputSelect_checkboxExportPluginOutput);
            this.panelOutputSelect_groupBoxOtherSettings.Controls.Add(this.panelOutputSelect_checkboxIpHostOutput);
            this.panelOutputSelect_groupBoxOtherSettings.Controls.Add(this.panelOutputSelect_checkboxOpenPortOutput);
            this.panelOutputSelect_groupBoxOtherSettings.Controls.Add(this.panelOutputSelect_checkboxHotfixOutput);
            this.panelOutputSelect_groupBoxOtherSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_groupBoxOtherSettings.Location = new System.Drawing.Point(3, 147);
            this.panelOutputSelect_groupBoxOtherSettings.Name = "panelOutputSelect_groupBoxOtherSettings";
            this.panelOutputSelect_groupBoxOtherSettings.Size = new System.Drawing.Size(700, 108);
            this.panelOutputSelect_groupBoxOtherSettings.TabIndex = 4;
            this.panelOutputSelect_groupBoxOtherSettings.TabStop = false;
            this.panelOutputSelect_groupBoxOtherSettings.Text = "Other Settings";
            // 
            // panelOutputSelect_labelTextFileBrowse
            // 
            this.panelOutputSelect_labelTextFileBrowse.AutoSize = true;
            this.panelOutputSelect_labelTextFileBrowse.Location = new System.Drawing.Point(200, 40);
            this.panelOutputSelect_labelTextFileBrowse.Name = "panelOutputSelect_labelTextFileBrowse";
            this.panelOutputSelect_labelTextFileBrowse.Size = new System.Drawing.Size(175, 13);
            this.panelOutputSelect_labelTextFileBrowse.TabIndex = 6;
            this.panelOutputSelect_labelTextFileBrowse.Text = "Hide Specific Host From Output File";
            // 
            // panelOutputSelect_textBoxTextFileBrowse
            // 
            this.panelOutputSelect_textBoxTextFileBrowse.Location = new System.Drawing.Point(200, 55);
            this.panelOutputSelect_textBoxTextFileBrowse.Name = "panelOutputSelect_textBoxTextFileBrowse";
            this.panelOutputSelect_textBoxTextFileBrowse.Size = new System.Drawing.Size(200, 20);
            this.panelOutputSelect_textBoxTextFileBrowse.TabIndex = 5;
            this.panelOutputSelect_textBoxTextFileBrowse.Click += new System.EventHandler(this.panelOutputSelect_buttonTextFileBrowse_Click);
            // 
            // panelOutputSelect_buttonTextFileBrowse
            // 
            this.panelOutputSelect_buttonTextFileBrowse.Location = new System.Drawing.Point(400, 55);
            this.panelOutputSelect_buttonTextFileBrowse.Name = "panelOutputSelect_buttonTextFileBrowse";
            this.panelOutputSelect_buttonTextFileBrowse.Size = new System.Drawing.Size(100, 23);
            this.panelOutputSelect_buttonTextFileBrowse.TabIndex = 4;
            this.panelOutputSelect_buttonTextFileBrowse.Text = "Text File Browse";
            this.panelOutputSelect_buttonTextFileBrowse.UseVisualStyleBackColor = true;
            this.panelOutputSelect_buttonTextFileBrowse.Click += new System.EventHandler(this.panelOutputSelect_buttonTextFileBrowse_Click);
            // 
            // panelOutputSelect_checkboxExportPluginOutput
            // 
            this.panelOutputSelect_checkboxExportPluginOutput.AutoSize = true;
            this.panelOutputSelect_checkboxExportPluginOutput.Checked = true;
            this.panelOutputSelect_checkboxExportPluginOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelOutputSelect_checkboxExportPluginOutput.Location = new System.Drawing.Point(200, 19);
            this.panelOutputSelect_checkboxExportPluginOutput.Name = "panelOutputSelect_checkboxExportPluginOutput";
            this.panelOutputSelect_checkboxExportPluginOutput.Size = new System.Drawing.Size(120, 17);
            this.panelOutputSelect_checkboxExportPluginOutput.TabIndex = 3;
            this.panelOutputSelect_checkboxExportPluginOutput.Text = "Export PluginOutput";
            this.panelOutputSelect_checkboxExportPluginOutput.UseVisualStyleBackColor = true;
            this.panelOutputSelect_checkboxExportPluginOutput.CheckedChanged += new System.EventHandler(this.panelOutputSelect_checkboxExportPluginOutput_CheckedChanged);
            // 
            // panelOutputSelect_checkboxIpHostOutput
            // 
            this.panelOutputSelect_checkboxIpHostOutput.AutoSize = true;
            this.panelOutputSelect_checkboxIpHostOutput.Checked = true;
            this.panelOutputSelect_checkboxIpHostOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelOutputSelect_checkboxIpHostOutput.Location = new System.Drawing.Point(5, 65);
            this.panelOutputSelect_checkboxIpHostOutput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelOutputSelect_checkboxIpHostOutput.Name = "panelOutputSelect_checkboxIpHostOutput";
            this.panelOutputSelect_checkboxIpHostOutput.Size = new System.Drawing.Size(117, 17);
            this.panelOutputSelect_checkboxIpHostOutput.TabIndex = 2;
            this.panelOutputSelect_checkboxIpHostOutput.Text = "IP Hostname Table";
            this.panelOutputSelect_checkboxIpHostOutput.UseVisualStyleBackColor = true;
            // 
            // panelOutputSelect_checkboxOpenPortOutput
            // 
            this.panelOutputSelect_checkboxOpenPortOutput.AutoSize = true;
            this.panelOutputSelect_checkboxOpenPortOutput.Checked = true;
            this.panelOutputSelect_checkboxOpenPortOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelOutputSelect_checkboxOpenPortOutput.Location = new System.Drawing.Point(6, 42);
            this.panelOutputSelect_checkboxOpenPortOutput.Name = "panelOutputSelect_checkboxOpenPortOutput";
            this.panelOutputSelect_checkboxOpenPortOutput.Size = new System.Drawing.Size(146, 17);
            this.panelOutputSelect_checkboxOpenPortOutput.TabIndex = 1;
            this.panelOutputSelect_checkboxOpenPortOutput.Text = "Open Port Findings Table";
            this.panelOutputSelect_checkboxOpenPortOutput.UseVisualStyleBackColor = true;
            this.panelOutputSelect_checkboxOpenPortOutput.CheckedChanged += new System.EventHandler(this.panelOutputSelect_checkboxOpenPortOutput_CheckedChanged);
            // 
            // panelOutputSelect_checkboxHotfixOutput
            // 
            this.panelOutputSelect_checkboxHotfixOutput.AutoSize = true;
            this.panelOutputSelect_checkboxHotfixOutput.Checked = true;
            this.panelOutputSelect_checkboxHotfixOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelOutputSelect_checkboxHotfixOutput.Location = new System.Drawing.Point(6, 19);
            this.panelOutputSelect_checkboxHotfixOutput.Name = "panelOutputSelect_checkboxHotfixOutput";
            this.panelOutputSelect_checkboxHotfixOutput.Size = new System.Drawing.Size(129, 17);
            this.panelOutputSelect_checkboxHotfixOutput.TabIndex = 0;
            this.panelOutputSelect_checkboxHotfixOutput.Text = "Microsoft Hotfix Table";
            this.panelOutputSelect_checkboxHotfixOutput.UseVisualStyleBackColor = true;
            this.panelOutputSelect_checkboxHotfixOutput.CheckedChanged += new System.EventHandler(this.panelOutputSelect_checkboxHotfixOutput_CheckedChanged);
            // 
            // panelOutputSelect_groupBoxOutputFilePath
            // 
            this.panelOutputSelect_groupBoxOutputFilePath.Controls.Add(this.panelOutputSelect_buttonOutputPathSaveAs);
            this.panelOutputSelect_groupBoxOutputFilePath.Controls.Add(this.panelOutputSelect_textBoxOutputFilePath);
            this.panelOutputSelect_groupBoxOutputFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_groupBoxOutputFilePath.Location = new System.Drawing.Point(3, 33);
            this.panelOutputSelect_groupBoxOutputFilePath.Name = "panelOutputSelect_groupBoxOutputFilePath";
            this.panelOutputSelect_groupBoxOutputFilePath.Size = new System.Drawing.Size(700, 108);
            this.panelOutputSelect_groupBoxOutputFilePath.TabIndex = 2;
            this.panelOutputSelect_groupBoxOutputFilePath.TabStop = false;
            this.panelOutputSelect_groupBoxOutputFilePath.Text = "Output File Path Selection";
            // 
            // panelOutputSelect_buttonOutputPathSaveAs
            // 
            this.panelOutputSelect_buttonOutputPathSaveAs.Location = new System.Drawing.Point(6, 45);
            this.panelOutputSelect_buttonOutputPathSaveAs.Name = "panelOutputSelect_buttonOutputPathSaveAs";
            this.panelOutputSelect_buttonOutputPathSaveAs.Size = new System.Drawing.Size(100, 23);
            this.panelOutputSelect_buttonOutputPathSaveAs.TabIndex = 1;
            this.panelOutputSelect_buttonOutputPathSaveAs.Text = "Browse";
            this.panelOutputSelect_buttonOutputPathSaveAs.UseVisualStyleBackColor = true;
            this.panelOutputSelect_buttonOutputPathSaveAs.Click += new System.EventHandler(this.panelOutputSelect_buttonOutputPathSaveAs_Click);
            // 
            // panelOutputSelect_textBoxOutputFilePath
            // 
            this.panelOutputSelect_textBoxOutputFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutputSelect_textBoxOutputFilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOutputSelect_textBoxOutputFilePath.Location = new System.Drawing.Point(3, 16);
            this.panelOutputSelect_textBoxOutputFilePath.Name = "panelOutputSelect_textBoxOutputFilePath";
            this.panelOutputSelect_textBoxOutputFilePath.ReadOnly = true;
            this.panelOutputSelect_textBoxOutputFilePath.Size = new System.Drawing.Size(694, 20);
            this.panelOutputSelect_textBoxOutputFilePath.TabIndex = 0;
            this.panelOutputSelect_textBoxOutputFilePath.Click += new System.EventHandler(this.panelOutputSelect_buttonOutputPathSaveAs_Click);
            // 
            // panelOutputSelect_groupBoxTemplatePath
            // 
            this.panelOutputSelect_groupBoxTemplatePath.Controls.Add(this.panelOutputSelect_buttonTemplatePathOpen);
            this.panelOutputSelect_groupBoxTemplatePath.Controls.Add(this.panelOutputSelect_textBoxTemplatePath);
            this.panelOutputSelect_groupBoxTemplatePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputSelect_groupBoxTemplatePath.Location = new System.Drawing.Point(3, 261);
            this.panelOutputSelect_groupBoxTemplatePath.Name = "panelOutputSelect_groupBoxTemplatePath";
            this.panelOutputSelect_groupBoxTemplatePath.Size = new System.Drawing.Size(700, 108);
            this.panelOutputSelect_groupBoxTemplatePath.TabIndex = 2;
            this.panelOutputSelect_groupBoxTemplatePath.TabStop = false;
            this.panelOutputSelect_groupBoxTemplatePath.Text = "Template Selection";
            // 
            // panelOutputSelect_buttonTemplatePathOpen
            // 
            this.panelOutputSelect_buttonTemplatePathOpen.Location = new System.Drawing.Point(6, 45);
            this.panelOutputSelect_buttonTemplatePathOpen.Name = "panelOutputSelect_buttonTemplatePathOpen";
            this.panelOutputSelect_buttonTemplatePathOpen.Size = new System.Drawing.Size(100, 23);
            this.panelOutputSelect_buttonTemplatePathOpen.TabIndex = 1;
            this.panelOutputSelect_buttonTemplatePathOpen.Text = "Browse";
            this.panelOutputSelect_buttonTemplatePathOpen.UseVisualStyleBackColor = true;
            this.panelOutputSelect_buttonTemplatePathOpen.Click += new System.EventHandler(this.panelOutputSelect_buttonTemplatePathOpen_Click);
            // 
            // panelOutputSelect_textBoxTemplatePath
            // 
            this.panelOutputSelect_textBoxTemplatePath.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutputSelect_textBoxTemplatePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOutputSelect_textBoxTemplatePath.Location = new System.Drawing.Point(3, 16);
            this.panelOutputSelect_textBoxTemplatePath.Name = "panelOutputSelect_textBoxTemplatePath";
            this.panelOutputSelect_textBoxTemplatePath.ReadOnly = true;
            this.panelOutputSelect_textBoxTemplatePath.Size = new System.Drawing.Size(694, 20);
            this.panelOutputSelect_textBoxTemplatePath.TabIndex = 0;
            this.panelOutputSelect_textBoxTemplatePath.Click += new System.EventHandler(this.panelOutputSelect_buttonTemplatePathOpen_Click);
            // 
            // panelTemplateStringEdit
            // 
            this.panelTemplateStringEdit.BackColor = System.Drawing.Color.Transparent;
            this.panelTemplateStringEdit.Controls.Add(this.panelTemplateStringEdit_tableLayout);
            this.panelTemplateStringEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTemplateStringEdit.Location = new System.Drawing.Point(3, 16);
            this.panelTemplateStringEdit.Name = "panelTemplateStringEdit";
            this.panelTemplateStringEdit.Size = new System.Drawing.Size(957, 417);
            this.panelTemplateStringEdit.TabIndex = 9;
            // 
            // panelTemplateStringEdit_tableLayout
            // 
            this.panelTemplateStringEdit_tableLayout.ColumnCount = 1;
            this.panelTemplateStringEdit_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTemplateStringEdit_tableLayout.Controls.Add(this.panelTemplateStringEdit_labelTopText, 0, 0);
            this.panelTemplateStringEdit_tableLayout.Controls.Add(this.panelTemplateStringEdit_dataGridView, 0, 1);
            this.panelTemplateStringEdit_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTemplateStringEdit_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.panelTemplateStringEdit_tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.panelTemplateStringEdit_tableLayout.Name = "panelTemplateStringEdit_tableLayout";
            this.panelTemplateStringEdit_tableLayout.RowCount = 2;
            this.panelTemplateStringEdit_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.panelTemplateStringEdit_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTemplateStringEdit_tableLayout.Size = new System.Drawing.Size(957, 417);
            this.panelTemplateStringEdit_tableLayout.TabIndex = 2;
            // 
            // panelTemplateStringEdit_labelTopText
            // 
            this.panelTemplateStringEdit_labelTopText.AutoSize = true;
            this.panelTemplateStringEdit_labelTopText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTemplateStringEdit_labelTopText.Location = new System.Drawing.Point(3, 6);
            this.panelTemplateStringEdit_labelTopText.Name = "panelTemplateStringEdit_labelTopText";
            this.panelTemplateStringEdit_labelTopText.Size = new System.Drawing.Size(951, 13);
            this.panelTemplateStringEdit_labelTopText.TabIndex = 1;
            this.panelTemplateStringEdit_labelTopText.Text = "Docx Template String Replacement";
            // 
            // panelTemplateStringEdit_dataGridView
            // 
            this.panelTemplateStringEdit_dataGridView.AllowUserToAddRows = false;
            this.panelTemplateStringEdit_dataGridView.AllowUserToDeleteRows = false;
            this.panelTemplateStringEdit_dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.panelTemplateStringEdit_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelTemplateStringEdit_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.replaceString,
            this.stringAfterReplace});
            this.panelTemplateStringEdit_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTemplateStringEdit_dataGridView.Location = new System.Drawing.Point(3, 22);
            this.panelTemplateStringEdit_dataGridView.MultiSelect = false;
            this.panelTemplateStringEdit_dataGridView.Name = "panelTemplateStringEdit_dataGridView";
            this.panelTemplateStringEdit_dataGridView.ReadOnly = true;
            this.panelTemplateStringEdit_dataGridView.RowHeadersVisible = false;
            this.panelTemplateStringEdit_dataGridView.RowHeadersWidth = 40;
            this.panelTemplateStringEdit_dataGridView.RowTemplate.Height = 24;
            this.panelTemplateStringEdit_dataGridView.Size = new System.Drawing.Size(951, 428);
            this.panelTemplateStringEdit_dataGridView.TabIndex = 0;
            this.panelTemplateStringEdit_dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.panelTemplateStringEdit_dataGridView_CellDoubleClick);
            // 
            // replaceString
            // 
            this.replaceString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.replaceString.FillWeight = 275F;
            this.replaceString.HeaderText = "String required to replace";
            this.replaceString.Name = "replaceString";
            this.replaceString.ReadOnly = true;
            // 
            // stringAfterReplace
            // 
            this.stringAfterReplace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stringAfterReplace.DefaultCellStyle = dataGridViewCellStyle1;
            this.stringAfterReplace.FillWeight = 698F;
            this.stringAfterReplace.HeaderText = "Replaced String";
            this.stringAfterReplace.Name = "stringAfterReplace";
            this.stringAfterReplace.ReadOnly = true;
            // 
            // panelFileInput
            // 
            this.panelFileInput.Controls.Add(this.panelFileInput_tableLayout);
            this.panelFileInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput.Location = new System.Drawing.Point(3, 16);
            this.panelFileInput.Name = "panelFileInput";
            this.panelFileInput.Size = new System.Drawing.Size(957, 417);
            this.panelFileInput.TabIndex = 12;
            // 
            // panelFileInput_tableLayout
            // 
            this.panelFileInput_tableLayout.ColumnCount = 1;
            this.panelFileInput_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFileInput_tableLayout.Controls.Add(this.panelFileInput_tableLayoutBottom, 0, 2);
            this.panelFileInput_tableLayout.Controls.Add(this.panelFileInput_labelFileList, 0, 0);
            this.panelFileInput_tableLayout.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.panelFileInput_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.panelFileInput_tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.panelFileInput_tableLayout.Name = "panelFileInput_tableLayout";
            this.panelFileInput_tableLayout.RowCount = 3;
            this.panelFileInput_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.panelFileInput_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFileInput_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelFileInput_tableLayout.Size = new System.Drawing.Size(957, 417);
            this.panelFileInput_tableLayout.TabIndex = 9;
            // 
            // panelFileInput_tableLayoutBottom
            // 
            this.panelFileInput_tableLayoutBottom.ColumnCount = 7;
            this.panelFileInput_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.panelFileInput_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.panelFileInput_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.panelFileInput_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.panelFileInput_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFileInput_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.panelFileInput_tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.panelFileInput_tableLayoutBottom.Controls.Add(this.panelFileInput_buttonSelectAll, 0, 0);
            this.panelFileInput_tableLayoutBottom.Controls.Add(this.panelFileInput_buttonSelectNone, 1, 0);
            this.panelFileInput_tableLayoutBottom.Controls.Add(this.panelFileInput_buttonImportFile, 6, 0);
            this.panelFileInput_tableLayoutBottom.Controls.Add(this.panelFileInput_buttonClear, 3, 0);
            this.panelFileInput_tableLayoutBottom.Controls.Add(this.panelFileInput_buttonImportFolder, 5, 0);
            this.panelFileInput_tableLayoutBottom.Controls.Add(this.panelFileInput_buttonReverse, 2, 0);
            this.panelFileInput_tableLayoutBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_tableLayoutBottom.Location = new System.Drawing.Point(0, 387);
            this.panelFileInput_tableLayoutBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelFileInput_tableLayoutBottom.Name = "panelFileInput_tableLayoutBottom";
            this.panelFileInput_tableLayoutBottom.RowCount = 1;
            this.panelFileInput_tableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFileInput_tableLayoutBottom.Size = new System.Drawing.Size(957, 30);
            this.panelFileInput_tableLayoutBottom.TabIndex = 10;
            // 
            // panelFileInput_buttonSelectAll
            // 
            this.panelFileInput_buttonSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_buttonSelectAll.Location = new System.Drawing.Point(3, 3);
            this.panelFileInput_buttonSelectAll.Name = "panelFileInput_buttonSelectAll";
            this.panelFileInput_buttonSelectAll.Size = new System.Drawing.Size(84, 24);
            this.panelFileInput_buttonSelectAll.TabIndex = 5;
            this.panelFileInput_buttonSelectAll.Text = "Select All";
            this.panelFileInput_buttonSelectAll.UseVisualStyleBackColor = true;
            this.panelFileInput_buttonSelectAll.Click += new System.EventHandler(this.panelFileInput_buttonSelectAll_Click);
            // 
            // panelFileInput_buttonSelectNone
            // 
            this.panelFileInput_buttonSelectNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_buttonSelectNone.Location = new System.Drawing.Point(93, 3);
            this.panelFileInput_buttonSelectNone.Name = "panelFileInput_buttonSelectNone";
            this.panelFileInput_buttonSelectNone.Size = new System.Drawing.Size(84, 24);
            this.panelFileInput_buttonSelectNone.TabIndex = 6;
            this.panelFileInput_buttonSelectNone.Text = "Select None";
            this.panelFileInput_buttonSelectNone.UseVisualStyleBackColor = true;
            this.panelFileInput_buttonSelectNone.Click += new System.EventHandler(this.panelFileInput_buttonSelectNone_Click);
            // 
            // panelFileInput_buttonImportFile
            // 
            this.panelFileInput_buttonImportFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_buttonImportFile.Location = new System.Drawing.Point(850, 3);
            this.panelFileInput_buttonImportFile.Name = "panelFileInput_buttonImportFile";
            this.panelFileInput_buttonImportFile.Size = new System.Drawing.Size(104, 24);
            this.panelFileInput_buttonImportFile.TabIndex = 1;
            this.panelFileInput_buttonImportFile.Text = "Import file";
            this.panelFileInput_buttonImportFile.UseVisualStyleBackColor = true;
            this.panelFileInput_buttonImportFile.Click += new System.EventHandler(this.panelFileInput_buttonImportFile_Click);
            // 
            // panelFileInput_buttonClear
            // 
            this.panelFileInput_buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_buttonClear.Location = new System.Drawing.Point(273, 3);
            this.panelFileInput_buttonClear.Name = "panelFileInput_buttonClear";
            this.panelFileInput_buttonClear.Size = new System.Drawing.Size(84, 24);
            this.panelFileInput_buttonClear.TabIndex = 8;
            this.panelFileInput_buttonClear.Text = "Clear";
            this.panelFileInput_buttonClear.UseVisualStyleBackColor = true;
            this.panelFileInput_buttonClear.Click += new System.EventHandler(this.panelFileInput_buttonClear_Click);
            // 
            // panelFileInput_buttonImportFolder
            // 
            this.panelFileInput_buttonImportFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_buttonImportFolder.Location = new System.Drawing.Point(740, 3);
            this.panelFileInput_buttonImportFolder.Name = "panelFileInput_buttonImportFolder";
            this.panelFileInput_buttonImportFolder.Size = new System.Drawing.Size(104, 24);
            this.panelFileInput_buttonImportFolder.TabIndex = 0;
            this.panelFileInput_buttonImportFolder.Text = "Import from folder";
            this.panelFileInput_buttonImportFolder.UseVisualStyleBackColor = true;
            this.panelFileInput_buttonImportFolder.Click += new System.EventHandler(this.panelFileInput_buttonImportFolder_Click);
            // 
            // panelFileInput_buttonReverse
            // 
            this.panelFileInput_buttonReverse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_buttonReverse.Location = new System.Drawing.Point(183, 3);
            this.panelFileInput_buttonReverse.Name = "panelFileInput_buttonReverse";
            this.panelFileInput_buttonReverse.Size = new System.Drawing.Size(84, 24);
            this.panelFileInput_buttonReverse.TabIndex = 7;
            this.panelFileInput_buttonReverse.Text = "Reverse";
            this.panelFileInput_buttonReverse.UseVisualStyleBackColor = true;
            this.panelFileInput_buttonReverse.Click += new System.EventHandler(this.panelFileInput_buttonReverse_Click);
            // 
            // panelFileInput_labelFileList
            // 
            this.panelFileInput_labelFileList.AutoSize = true;
            this.panelFileInput_labelFileList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFileInput_labelFileList.Location = new System.Drawing.Point(3, 6);
            this.panelFileInput_labelFileList.Name = "panelFileInput_labelFileList";
            this.panelFileInput_labelFileList.Size = new System.Drawing.Size(951, 13);
            this.panelFileInput_labelFileList.TabIndex = 3;
            this.panelFileInput_labelFileList.Text = "File List";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.74206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.25793F));
            this.tableLayoutPanel1.Controls.Add(this.panelFileInput_checkedListBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelFileInput_treeViewFileName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 362);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panelFileInput_checkedListBox
            // 
            this.panelFileInput_checkedListBox.CheckOnClick = true;
            this.panelFileInput_checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_checkedListBox.FormattingEnabled = true;
            this.panelFileInput_checkedListBox.HorizontalScrollbar = true;
            this.panelFileInput_checkedListBox.Location = new System.Drawing.Point(187, 0);
            this.panelFileInput_checkedListBox.Margin = new System.Windows.Forms.Padding(0);
            this.panelFileInput_checkedListBox.Name = "panelFileInput_checkedListBox";
            this.panelFileInput_checkedListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelFileInput_checkedListBox.Size = new System.Drawing.Size(764, 362);
            this.panelFileInput_checkedListBox.Sorted = true;
            this.panelFileInput_checkedListBox.TabIndex = 1;
            this.panelFileInput_checkedListBox.Click += new System.EventHandler(this.panelFileInput_checkedListBox_Click_1);
            this.panelFileInput_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.panelFileInput_checkedListBox_SelectedIndexChanged_1);
            // 
            // panelFileInput_treeViewFileName
            // 
            this.panelFileInput_treeViewFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileInput_treeViewFileName.Location = new System.Drawing.Point(3, 3);
            this.panelFileInput_treeViewFileName.Name = "panelFileInput_treeViewFileName";
            this.panelFileInput_treeViewFileName.Size = new System.Drawing.Size(181, 356);
            this.panelFileInput_treeViewFileName.TabIndex = 2;
            // 
            // panelRawView_tableLayoutPanel
            // 
            this.panelRawView_tableLayoutPanel.ColumnCount = 2;
            this.panelRawView_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.77381F));
            this.panelRawView_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.22619F));
            this.panelRawView_tableLayoutPanel.Controls.Add(this.panelRawView_tabControl, 1, 0);
            this.panelRawView_tableLayoutPanel.Controls.Add(this.panelRawView_treeViewFileName, 0, 0);
            this.panelRawView_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView_tableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.panelRawView_tableLayoutPanel.Name = "panelRawView_tableLayoutPanel";
            this.panelRawView_tableLayoutPanel.RowCount = 1;
            this.panelRawView_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelRawView_tableLayoutPanel.Size = new System.Drawing.Size(957, 417);
            this.panelRawView_tableLayoutPanel.TabIndex = 17;
            this.panelRawView_tableLayoutPanel.Visible = false;
            // 
            // panelRawView_tabControl
            // 
            this.panelRawView_tabControl.AccessibleName = "";
            this.panelRawView_tabControl.Controls.Add(this.tabPage1);
            this.panelRawView_tabControl.Controls.Add(this.tabPage2);
            this.panelRawView_tabControl.Controls.Add(this.tabPage3);
            this.panelRawView_tabControl.Controls.Add(this.tabPage4);
            this.panelRawView_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView_tabControl.Location = new System.Drawing.Point(153, 3);
            this.panelRawView_tabControl.Name = "panelRawView_tabControl";
            this.panelRawView_tabControl.SelectedIndex = 0;
            this.panelRawView_tabControl.Size = new System.Drawing.Size(801, 411);
            this.panelRawView_tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.panelRawView_tabControl.TabIndex = 16;
            this.panelRawView_tabControl.Visible = false;
            this.panelRawView_tabControl.SelectedIndexChanged += new System.EventHandler(this.panelRawView_tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelRawView_dataGridViewNmap);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nmap";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelRawView_dataGridViewNmap
            // 
            this.panelRawView_dataGridViewNmap.AllowUserToAddRows = false;
            this.panelRawView_dataGridViewNmap.AllowUserToDeleteRows = false;
            this.panelRawView_dataGridViewNmap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.panelRawView_dataGridViewNmap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelRawView_dataGridViewNmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView_dataGridViewNmap.Location = new System.Drawing.Point(3, 3);
            this.panelRawView_dataGridViewNmap.Name = "panelRawView_dataGridViewNmap";
            this.panelRawView_dataGridViewNmap.ReadOnly = true;
            this.panelRawView_dataGridViewNmap.RowTemplate.Height = 24;
            this.panelRawView_dataGridViewNmap.Size = new System.Drawing.Size(787, 379);
            this.panelRawView_dataGridViewNmap.TabIndex = 13;
            this.panelRawView_dataGridViewNmap.Visible = false;
            this.panelRawView_dataGridViewNmap.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.panelRawView_dataGridViewNmap_SortCompare);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelRawView_dataGridViewNessus);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nessus";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelRawView_dataGridViewNessus
            // 
            this.panelRawView_dataGridViewNessus.AllowUserToAddRows = false;
            this.panelRawView_dataGridViewNessus.AllowUserToDeleteRows = false;
            this.panelRawView_dataGridViewNessus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.panelRawView_dataGridViewNessus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelRawView_dataGridViewNessus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView_dataGridViewNessus.Location = new System.Drawing.Point(3, 3);
            this.panelRawView_dataGridViewNessus.Name = "panelRawView_dataGridViewNessus";
            this.panelRawView_dataGridViewNessus.ReadOnly = true;
            this.panelRawView_dataGridViewNessus.RowTemplate.Height = 24;
            this.panelRawView_dataGridViewNessus.Size = new System.Drawing.Size(787, 379);
            this.panelRawView_dataGridViewNessus.TabIndex = 14;
            this.panelRawView_dataGridViewNessus.Visible = false;
            this.panelRawView_dataGridViewNessus.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.panelRawView_dataGridViewNessus_SortCompare);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelRawView_dataGridViewMBSA);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(793, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "MBSA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panelRawView_dataGridViewMBSA
            // 
            this.panelRawView_dataGridViewMBSA.AllowUserToAddRows = false;
            this.panelRawView_dataGridViewMBSA.AllowUserToDeleteRows = false;
            this.panelRawView_dataGridViewMBSA.AllowUserToOrderColumns = true;
            this.panelRawView_dataGridViewMBSA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.panelRawView_dataGridViewMBSA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelRawView_dataGridViewMBSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView_dataGridViewMBSA.Location = new System.Drawing.Point(3, 3);
            this.panelRawView_dataGridViewMBSA.Name = "panelRawView_dataGridViewMBSA";
            this.panelRawView_dataGridViewMBSA.ReadOnly = true;
            this.panelRawView_dataGridViewMBSA.RowTemplate.Height = 24;
            this.panelRawView_dataGridViewMBSA.Size = new System.Drawing.Size(787, 379);
            this.panelRawView_dataGridViewMBSA.TabIndex = 15;
            this.panelRawView_dataGridViewMBSA.Visible = false;
            this.panelRawView_dataGridViewMBSA.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.panelRawView_dataGridViewMBSA_SortCompare);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panelRawView_dataGridViewAcunetix);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(793, 385);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Acunetix";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelRawView_dataGridViewAcunetix
            // 
            this.panelRawView_dataGridViewAcunetix.AllowUserToAddRows = false;
            this.panelRawView_dataGridViewAcunetix.AllowUserToDeleteRows = false;
            this.panelRawView_dataGridViewAcunetix.AllowUserToOrderColumns = true;
            this.panelRawView_dataGridViewAcunetix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.panelRawView_dataGridViewAcunetix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelRawView_dataGridViewAcunetix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView_dataGridViewAcunetix.Location = new System.Drawing.Point(3, 3);
            this.panelRawView_dataGridViewAcunetix.Name = "panelRawView_dataGridViewAcunetix";
            this.panelRawView_dataGridViewAcunetix.ReadOnly = true;
            this.panelRawView_dataGridViewAcunetix.RowTemplate.Height = 24;
            this.panelRawView_dataGridViewAcunetix.Size = new System.Drawing.Size(787, 379);
            this.panelRawView_dataGridViewAcunetix.TabIndex = 16;
            this.panelRawView_dataGridViewAcunetix.Visible = false;
            // 
            // panelRawView_treeViewFileName
            // 
            this.panelRawView_treeViewFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView_treeViewFileName.Location = new System.Drawing.Point(3, 3);
            this.panelRawView_treeViewFileName.Name = "panelRawView_treeViewFileName";
            this.panelRawView_treeViewFileName.Size = new System.Drawing.Size(144, 411);
            this.panelRawView_treeViewFileName.TabIndex = 17;
            // 
            // panelLast
            // 
            this.panelLast.BackColor = System.Drawing.Color.Transparent;
            this.panelLast.Controls.Add(this.panelLast_tableLayout);
            this.panelLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLast.Location = new System.Drawing.Point(3, 16);
            this.panelLast.Name = "panelLast";
            this.panelLast.Size = new System.Drawing.Size(957, 417);
            this.panelLast.TabIndex = 8;
            // 
            // panelLast_tableLayout
            // 
            this.panelLast_tableLayout.ColumnCount = 1;
            this.panelLast_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLast_tableLayout.Controls.Add(this.panelLast_labelText, 0, 1);
            this.panelLast_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLast_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.panelLast_tableLayout.Name = "panelLast_tableLayout";
            this.panelLast_tableLayout.RowCount = 2;
            this.panelLast_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLast_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.panelLast_tableLayout.Size = new System.Drawing.Size(957, 417);
            this.panelLast_tableLayout.TabIndex = 1;
            // 
            // panelLast_labelText
            // 
            this.panelLast_labelText.AutoSize = true;
            this.panelLast_labelText.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLast_labelText.Location = new System.Drawing.Point(10, 401);
            this.panelLast_labelText.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.panelLast_labelText.Name = "panelLast_labelText";
            this.panelLast_labelText.Size = new System.Drawing.Size(315, 13);
            this.panelLast_labelText.TabIndex = 0;
            this.panelLast_labelText.Text = "Press Finished Button to Output, this step may take a few minutes";
            // 
            // panelRawView
            // 
            this.panelRawView.AllowDrop = true;
            this.panelRawView.BackColor = System.Drawing.SystemColors.Control;
            this.panelRawView.Controls.Add(this.buttonGenExcelSelected);
            this.panelRawView.Controls.Add(this.buttonGenExcel);
            this.panelRawView.Controls.Add(this.panelRawView_buttonShowAll);
            this.panelRawView.Controls.Add(this.panelRawView_labelKeyWord);
            this.panelRawView.Controls.Add(this.panelRawView_textBoxKeyword);
            this.panelRawView.Controls.Add(this.panelRawView_comboBoxFilter);
            this.panelRawView.Controls.Add(this.panelRawView_buttonFilter);
            this.panelRawView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawView.Location = new System.Drawing.Point(0, 0);
            this.panelRawView.Name = "panelRawView";
            this.panelRawView.Size = new System.Drawing.Size(705, 45);
            this.panelRawView.TabIndex = 10;
            // 
            // buttonGenExcelSelected
            // 
            this.buttonGenExcelSelected.Location = new System.Drawing.Point(603, 12);
            this.buttonGenExcelSelected.Name = "buttonGenExcelSelected";
            this.buttonGenExcelSelected.Size = new System.Drawing.Size(145, 25);
            this.buttonGenExcelSelected.TabIndex = 119;
            this.buttonGenExcelSelected.Text = "Gen Excel from Selected Cells";
            this.buttonGenExcelSelected.UseVisualStyleBackColor = true;
            this.buttonGenExcelSelected.Click += new System.EventHandler(this.buttonGenExcelSelected_Click);
            // 
            // buttonGenExcel
            // 
            this.buttonGenExcel.Location = new System.Drawing.Point(499, 12);
            this.buttonGenExcel.Name = "buttonGenExcel";
            this.buttonGenExcel.Size = new System.Drawing.Size(102, 25);
            this.buttonGenExcel.TabIndex = 118;
            this.buttonGenExcel.Text = "Gen Excel";
            this.buttonGenExcel.UseVisualStyleBackColor = true;
            this.buttonGenExcel.Click += new System.EventHandler(this.buttonGenExcel_Click);
            // 
            // panelRawView_buttonShowAll
            // 
            this.panelRawView_buttonShowAll.Location = new System.Drawing.Point(397, 12);
            this.panelRawView_buttonShowAll.Name = "panelRawView_buttonShowAll";
            this.panelRawView_buttonShowAll.Size = new System.Drawing.Size(98, 25);
            this.panelRawView_buttonShowAll.TabIndex = 115;
            this.panelRawView_buttonShowAll.Text = "Show All";
            this.panelRawView_buttonShowAll.UseVisualStyleBackColor = true;
            this.panelRawView_buttonShowAll.Click += new System.EventHandler(this.panelRawView_buttonShowAll_Click);
            // 
            // panelRawView_labelKeyWord
            // 
            this.panelRawView_labelKeyWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRawView_labelKeyWord.AutoSize = true;
            this.panelRawView_labelKeyWord.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.panelRawView_labelKeyWord.Location = new System.Drawing.Point(-23, 16);
            this.panelRawView_labelKeyWord.Name = "panelRawView_labelKeyWord";
            this.panelRawView_labelKeyWord.Size = new System.Drawing.Size(62, 15);
            this.panelRawView_labelKeyWord.TabIndex = 117;
            this.panelRawView_labelKeyWord.Text = "Keyword : ";
            // 
            // panelRawView_textBoxKeyword
            // 
            this.panelRawView_textBoxKeyword.Location = new System.Drawing.Point(71, 10);
            this.panelRawView_textBoxKeyword.Name = "panelRawView_textBoxKeyword";
            this.panelRawView_textBoxKeyword.Size = new System.Drawing.Size(102, 20);
            this.panelRawView_textBoxKeyword.TabIndex = 116;
            // 
            // panelRawView_comboBoxFilter
            // 
            this.panelRawView_comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.panelRawView_comboBoxFilter.FormattingEnabled = true;
            this.panelRawView_comboBoxFilter.Items.AddRange(new object[] {
            "Plugin Name",
            "Host Affected",
            "Description",
            "Impact",
            "Risk Level",
            "Recommendation",
            "CVE",
            "BID",
            "OSVDB",
            "Reference Link"});
            this.panelRawView_comboBoxFilter.Location = new System.Drawing.Point(179, 12);
            this.panelRawView_comboBoxFilter.Name = "panelRawView_comboBoxFilter";
            this.panelRawView_comboBoxFilter.Size = new System.Drawing.Size(110, 21);
            this.panelRawView_comboBoxFilter.TabIndex = 114;
            // 
            // panelRawView_buttonFilter
            // 
            this.panelRawView_buttonFilter.Location = new System.Drawing.Point(295, 12);
            this.panelRawView_buttonFilter.Name = "panelRawView_buttonFilter";
            this.panelRawView_buttonFilter.Size = new System.Drawing.Size(96, 25);
            this.panelRawView_buttonFilter.TabIndex = 113;
            this.panelRawView_buttonFilter.Text = "Filter";
            this.panelRawView_buttonFilter.UseVisualStyleBackColor = true;
            this.panelRawView_buttonFilter.Click += new System.EventHandler(this.panelRawView_buttonFilter_Click);
            // 
            // one
            // 
            this.one.Dock = System.Windows.Forms.DockStyle.Fill;
            this.one.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.one.Location = new System.Drawing.Point(3, 3);
            this.one.Margin = new System.Windows.Forms.Padding(3);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(185, 45);
            this.one.TabIndex = 0;
            this.one.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formMainTop_groupBox
            // 
            this.formMainTop_groupBox.Controls.Add(this.formMainTopTableLayout);
            this.formMainTop_groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formMainTop_groupBox.Location = new System.Drawing.Point(0, 0);
            this.formMainTop_groupBox.Margin = new System.Windows.Forms.Padding(0);
            this.formMainTop_groupBox.Name = "formMainTop_groupBox";
            this.formMainTop_groupBox.Size = new System.Drawing.Size(963, 70);
            this.formMainTop_groupBox.TabIndex = 2;
            this.formMainTop_groupBox.TabStop = false;
            this.formMainTop_groupBox.Text = "Report Generator";
            // 
            // formMainTopTableLayout
            // 
            this.formMainTopTableLayout.ColumnCount = 5;
            this.formMainTopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.formMainTopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.formMainTopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.formMainTopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.formMainTopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.formMainTopTableLayout.Controls.Add(this.one, 0, 0);
            this.formMainTopTableLayout.Controls.Add(this.five, 4, 0);
            this.formMainTopTableLayout.Controls.Add(this.two, 1, 0);
            this.formMainTopTableLayout.Controls.Add(this.four, 3, 0);
            this.formMainTopTableLayout.Controls.Add(this.three, 2, 0);
            this.formMainTopTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formMainTopTableLayout.Location = new System.Drawing.Point(3, 16);
            this.formMainTopTableLayout.Name = "formMainTopTableLayout";
            this.formMainTopTableLayout.RowCount = 1;
            this.formMainTopTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formMainTopTableLayout.Size = new System.Drawing.Size(957, 51);
            this.formMainTopTableLayout.TabIndex = 6;
            // 
            // five
            // 
            this.five.Dock = System.Windows.Forms.DockStyle.Fill;
            this.five.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.five.Location = new System.Drawing.Point(767, 3);
            this.five.Margin = new System.Windows.Forms.Padding(3);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(187, 45);
            this.five.TabIndex = 5;
            this.five.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // two
            // 
            this.two.Dock = System.Windows.Forms.DockStyle.Fill;
            this.two.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.two.Location = new System.Drawing.Point(194, 3);
            this.two.Margin = new System.Windows.Forms.Padding(3);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(185, 45);
            this.two.TabIndex = 2;
            this.two.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // four
            // 
            this.four.Dock = System.Windows.Forms.DockStyle.Fill;
            this.four.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.four.Location = new System.Drawing.Point(576, 3);
            this.four.Margin = new System.Windows.Forms.Padding(3);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(185, 45);
            this.four.TabIndex = 4;
            this.four.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // three
            // 
            this.three.Dock = System.Windows.Forms.DockStyle.Fill;
            this.three.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.three.Location = new System.Drawing.Point(385, 3);
            this.three.Margin = new System.Windows.Forms.Padding(3);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(185, 45);
            this.three.TabIndex = 3;
            this.three.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRecordEdit_checkboxHigh
            // 
            this.panelRecordEdit_checkboxHigh.AutoSize = true;
            this.panelRecordEdit_checkboxHigh.Checked = true;
            this.panelRecordEdit_checkboxHigh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxHigh.Location = new System.Drawing.Point(45, 3);
            this.panelRecordEdit_checkboxHigh.Name = "panelRecordEdit_checkboxHigh";
            this.panelRecordEdit_checkboxHigh.Size = new System.Drawing.Size(48, 17);
            this.panelRecordEdit_checkboxHigh.TabIndex = 13;
            this.panelRecordEdit_checkboxHigh.Text = "High";
            this.panelRecordEdit_checkboxHigh.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxHigh.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxHigh_CheckedChanged);
            // 
            // panelRecordEdit_checkboxMedium
            // 
            this.panelRecordEdit_checkboxMedium.AutoSize = true;
            this.panelRecordEdit_checkboxMedium.Checked = true;
            this.panelRecordEdit_checkboxMedium.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxMedium.Location = new System.Drawing.Point(99, 3);
            this.panelRecordEdit_checkboxMedium.Name = "panelRecordEdit_checkboxMedium";
            this.panelRecordEdit_checkboxMedium.Size = new System.Drawing.Size(63, 17);
            this.panelRecordEdit_checkboxMedium.TabIndex = 13;
            this.panelRecordEdit_checkboxMedium.Text = "Medium";
            this.panelRecordEdit_checkboxMedium.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxMedium.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxMedium_CheckedChanged);
            // 
            // panelRecordEdit_checkboxLow
            // 
            this.panelRecordEdit_checkboxLow.AutoSize = true;
            this.panelRecordEdit_checkboxLow.Checked = true;
            this.panelRecordEdit_checkboxLow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxLow.Location = new System.Drawing.Point(168, 3);
            this.panelRecordEdit_checkboxLow.Name = "panelRecordEdit_checkboxLow";
            this.panelRecordEdit_checkboxLow.Size = new System.Drawing.Size(46, 17);
            this.panelRecordEdit_checkboxLow.TabIndex = 13;
            this.panelRecordEdit_checkboxLow.Text = "Low";
            this.panelRecordEdit_checkboxLow.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxLow.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxLow_CheckedChanged);
            // 
            // panelRecordEdit_checkboxNone
            // 
            this.panelRecordEdit_checkboxNone.AutoSize = true;
            this.panelRecordEdit_checkboxNone.Checked = true;
            this.panelRecordEdit_checkboxNone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxNone.Location = new System.Drawing.Point(220, 3);
            this.panelRecordEdit_checkboxNone.Name = "panelRecordEdit_checkboxNone";
            this.panelRecordEdit_checkboxNone.Size = new System.Drawing.Size(52, 17);
            this.panelRecordEdit_checkboxNone.TabIndex = 13;
            this.panelRecordEdit_checkboxNone.Text = "None";
            this.panelRecordEdit_checkboxNone.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxNone.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxNone_CheckedChanged);
            // 
            // panelRecordEdit_checkboxOpenPort
            // 
            this.panelRecordEdit_checkboxOpenPort.AutoSize = true;
            this.panelRecordEdit_checkboxOpenPort.Checked = true;
            this.panelRecordEdit_checkboxOpenPort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxOpenPort.Location = new System.Drawing.Point(278, 3);
            this.panelRecordEdit_checkboxOpenPort.Name = "panelRecordEdit_checkboxOpenPort";
            this.panelRecordEdit_checkboxOpenPort.Size = new System.Drawing.Size(74, 17);
            this.panelRecordEdit_checkboxOpenPort.TabIndex = 13;
            this.panelRecordEdit_checkboxOpenPort.Text = "Open Port";
            this.panelRecordEdit_checkboxOpenPort.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxOpenPort.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxOpenPort_CheckedChanged);
            // 
            // formMainBottomPanel
            // 
            this.formMainBottomPanel.Controls.Add(this.panelRawView);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxNessus);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_labelNoOfRowSelected);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxNmap);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxMbsa);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_labelShow);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxHigh);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxOpenPort);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxMedium);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxNone);
            this.formMainBottomPanel.Controls.Add(this.panelRecordEdit_checkboxLow);
            this.formMainBottomPanel.Location = new System.Drawing.Point(0, 0);
            this.formMainBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.formMainBottomPanel.Name = "formMainBottomPanel";
            this.formMainBottomPanel.Size = new System.Drawing.Size(705, 45);
            this.formMainBottomPanel.TabIndex = 14;
            // 
            // panelRecordEdit_checkboxNessus
            // 
            this.panelRecordEdit_checkboxNessus.AutoSize = true;
            this.panelRecordEdit_checkboxNessus.Checked = true;
            this.panelRecordEdit_checkboxNessus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxNessus.Location = new System.Drawing.Point(358, 3);
            this.panelRecordEdit_checkboxNessus.Name = "panelRecordEdit_checkboxNessus";
            this.panelRecordEdit_checkboxNessus.Size = new System.Drawing.Size(61, 17);
            this.panelRecordEdit_checkboxNessus.TabIndex = 16;
            this.panelRecordEdit_checkboxNessus.Text = "Nessus";
            this.panelRecordEdit_checkboxNessus.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxNessus.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxNessus_CheckedChanged);
            // 
            // panelRecordEdit_labelNoOfRowSelected
            // 
            this.panelRecordEdit_labelNoOfRowSelected.AutoSize = true;
            this.panelRecordEdit_labelNoOfRowSelected.Location = new System.Drawing.Point(4, 19);
            this.panelRecordEdit_labelNoOfRowSelected.Name = "panelRecordEdit_labelNoOfRowSelected";
            this.panelRecordEdit_labelNoOfRowSelected.Size = new System.Drawing.Size(0, 13);
            this.panelRecordEdit_labelNoOfRowSelected.TabIndex = 15;
            // 
            // panelRecordEdit_checkboxNmap
            // 
            this.panelRecordEdit_checkboxNmap.AutoSize = true;
            this.panelRecordEdit_checkboxNmap.Checked = true;
            this.panelRecordEdit_checkboxNmap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxNmap.Location = new System.Drawing.Point(487, 3);
            this.panelRecordEdit_checkboxNmap.Name = "panelRecordEdit_checkboxNmap";
            this.panelRecordEdit_checkboxNmap.Size = new System.Drawing.Size(54, 17);
            this.panelRecordEdit_checkboxNmap.TabIndex = 16;
            this.panelRecordEdit_checkboxNmap.Text = "Nmap";
            this.panelRecordEdit_checkboxNmap.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxNmap.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxNmap_CheckedChanged);
            // 
            // panelRecordEdit_checkboxMbsa
            // 
            this.panelRecordEdit_checkboxMbsa.AutoSize = true;
            this.panelRecordEdit_checkboxMbsa.Checked = true;
            this.panelRecordEdit_checkboxMbsa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelRecordEdit_checkboxMbsa.Location = new System.Drawing.Point(425, 3);
            this.panelRecordEdit_checkboxMbsa.Name = "panelRecordEdit_checkboxMbsa";
            this.panelRecordEdit_checkboxMbsa.Size = new System.Drawing.Size(56, 17);
            this.panelRecordEdit_checkboxMbsa.TabIndex = 16;
            this.panelRecordEdit_checkboxMbsa.Text = "MBSA";
            this.panelRecordEdit_checkboxMbsa.UseVisualStyleBackColor = true;
            this.panelRecordEdit_checkboxMbsa.CheckedChanged += new System.EventHandler(this.panelRecordEdit_checkboxMbsa_CheckedChanged);
            // 
            // panelRecordEdit_labelShow
            // 
            this.panelRecordEdit_labelShow.AutoSize = true;
            this.panelRecordEdit_labelShow.Location = new System.Drawing.Point(4, 4);
            this.panelRecordEdit_labelShow.Name = "panelRecordEdit_labelShow";
            this.panelRecordEdit_labelShow.Size = new System.Drawing.Size(34, 13);
            this.panelRecordEdit_labelShow.TabIndex = 14;
            this.panelRecordEdit_labelShow.Text = "Show";
            // 
            // formMainTableLayout
            // 
            this.formMainTableLayout.ColumnCount = 1;
            this.formMainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formMainTableLayout.Controls.Add(this.formMainTop_groupBox, 0, 0);
            this.formMainTableLayout.Controls.Add(this.formMainTableLayoutBottom, 0, 2);
            this.formMainTableLayout.Controls.Add(this.formMain_groupBoxMain, 0, 1);
            this.formMainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formMainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.formMainTableLayout.Name = "formMainTableLayout";
            this.formMainTableLayout.RowCount = 3;
            this.formMainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.formMainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formMainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.formMainTableLayout.Size = new System.Drawing.Size(963, 551);
            this.formMainTableLayout.TabIndex = 15;
            // 
            // formMainTableLayoutBottom
            // 
            this.formMainTableLayoutBottom.ColumnCount = 4;
            this.formMainTableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formMainTableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.formMainTableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.formMainTableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.formMainTableLayoutBottom.Controls.Add(this.buttonCancel, 3, 0);
            this.formMainTableLayoutBottom.Controls.Add(this.buttonNext, 2, 0);
            this.formMainTableLayoutBottom.Controls.Add(this.buttonBack, 1, 0);
            this.formMainTableLayoutBottom.Controls.Add(this.formMainBottomPanel, 0, 0);
            this.formMainTableLayoutBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formMainTableLayoutBottom.Location = new System.Drawing.Point(0, 506);
            this.formMainTableLayoutBottom.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.formMainTableLayoutBottom.Name = "formMainTableLayoutBottom";
            this.formMainTableLayoutBottom.RowCount = 1;
            this.formMainTableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formMainTableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.formMainTableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.formMainTableLayoutBottom.Size = new System.Drawing.Size(960, 45);
            this.formMainTableLayoutBottom.TabIndex = 16;
            // 
            // saveFileDialogExcel
            // 
            this.saveFileDialogExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogExcel_FileOk);
            // 
            // saveFileDialogExcelSelected
            // 
            this.saveFileDialogExcelSelected.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogExcelSelected_FileOk);
            // 
            // openFileDialogTextFileBrowse
            // 
            this.openFileDialogTextFileBrowse.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(963, 551);
            this.Controls.Add(this.formMainTableLayout);
            this.MinimumSize = new System.Drawing.Size(962, 585);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportGenerator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.formMain_groupBoxMain.ResumeLayout(false);
            this.panelRecordEdit.ResumeLayout(false);
            this.panelRecordEdit_tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRecordEdit_dataGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panelRecordEdit_tableLayoutBottom.ResumeLayout(false);
            this.panelOutputSelect.ResumeLayout(false);
            this.panelOutputSelect_tableLayout.ResumeLayout(false);
            this.panelOutputSelect_groupBoxOutputSelection.ResumeLayout(false);
            this.panelOutputSelect_tableLayoutLeft.ResumeLayout(false);
            this.panelOutputSelect_groupBoxSetting.ResumeLayout(false);
            this.panelOutputSelect_TableLayoutRight.ResumeLayout(false);
            this.panelOutputSelect_TableLayoutRight.PerformLayout();
            this.panelOutputSelect_groupBoxOtherSettings.ResumeLayout(false);
            this.panelOutputSelect_groupBoxOtherSettings.PerformLayout();
            this.panelOutputSelect_groupBoxOutputFilePath.ResumeLayout(false);
            this.panelOutputSelect_groupBoxOutputFilePath.PerformLayout();
            this.panelOutputSelect_groupBoxTemplatePath.ResumeLayout(false);
            this.panelOutputSelect_groupBoxTemplatePath.PerformLayout();
            this.panelTemplateStringEdit.ResumeLayout(false);
            this.panelTemplateStringEdit_tableLayout.ResumeLayout(false);
            this.panelTemplateStringEdit_tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTemplateStringEdit_dataGridView)).EndInit();
            this.panelFileInput.ResumeLayout(false);
            this.panelFileInput_tableLayout.ResumeLayout(false);
            this.panelFileInput_tableLayout.PerformLayout();
            this.panelFileInput_tableLayoutBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelRawView_tableLayoutPanel.ResumeLayout(false);
            this.panelRawView_tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewNmap)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewNessus)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewMBSA)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRawView_dataGridViewAcunetix)).EndInit();
            this.panelLast.ResumeLayout(false);
            this.panelLast_tableLayout.ResumeLayout(false);
            this.panelLast_tableLayout.PerformLayout();
            this.panelRawView.ResumeLayout(false);
            this.panelRawView.PerformLayout();
            this.formMainTop_groupBox.ResumeLayout(false);
            this.formMainTopTableLayout.ResumeLayout(false);
            this.formMainBottomPanel.ResumeLayout(false);
            this.formMainBottomPanel.PerformLayout();
            this.formMainTableLayout.ResumeLayout(false);
            this.formMainTableLayoutBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.GroupBox formMain_groupBoxMain;
		private System.Windows.Forms.Label one;
		private System.Windows.Forms.GroupBox formMainTop_groupBox;
		private System.Windows.Forms.Label two;
		private System.Windows.Forms.Label five;
		private System.Windows.Forms.Label four;
		private System.Windows.Forms.Panel panelFileInput;
		private System.Windows.Forms.Panel panelRecordEdit;
		private System.Windows.Forms.Panel panelLast;
		private System.Windows.Forms.Panel panelTemplateStringEdit;
        private System.Windows.Forms.Panel panelOutputSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label panelFileInput_labelFileList;
		private System.Windows.Forms.DataGridView panelRecordEdit_dataGridView;
		private System.Windows.Forms.Button panelOutputSelect_buttonHtml;
		private System.Windows.Forms.Button panelOutputSelect_buttonXlsxDefault;
		private System.Windows.Forms.Button panelOutputSelect_buttonDocxFromDocx;
		private System.Windows.Forms.Button panelOutputSelect_buttonDocxDefault;
		private System.Windows.Forms.GroupBox panelOutputSelect_groupBoxSetting;
        private System.Windows.Forms.GroupBox panelOutputSelect_groupBoxOutputSelection;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label panelTemplateStringEdit_labelTopText;
        private System.Windows.Forms.DataGridView panelTemplateStringEdit_dataGridView;
		private System.Windows.Forms.Label panelLast_labelText;
		private System.Windows.Forms.Label three;
		private System.Windows.Forms.CheckBox panelRecordEdit_checkboxHigh;
		private System.Windows.Forms.CheckBox panelRecordEdit_checkboxMedium;
		private System.Windows.Forms.CheckBox panelRecordEdit_checkboxLow;
		private System.Windows.Forms.CheckBox panelRecordEdit_checkboxNone;
		private System.Windows.Forms.CheckBox panelRecordEdit_checkboxOpenPort;
		private System.Windows.Forms.Panel formMainBottomPanel;
		private System.Windows.Forms.Label panelRecordEdit_labelShow;
        private System.Windows.Forms.Label panelRecordEdit_labelNoOfRowSelected;
		private System.Windows.Forms.CheckBox panelRecordEdit_checkboxNmap;
		private System.Windows.Forms.CheckBox panelRecordEdit_checkboxMbsa;
        private System.Windows.Forms.CheckBox panelRecordEdit_checkboxNessus;
		private System.Windows.Forms.TableLayoutPanel formMainTableLayout;
		private System.Windows.Forms.TableLayoutPanel formMainTableLayoutBottom;
        private System.Windows.Forms.TableLayoutPanel panelRecordEdit_tableLayout;
		private System.Windows.Forms.TableLayoutPanel panelTemplateStringEdit_tableLayout;
		private System.Windows.Forms.TableLayoutPanel panelOutputSelect_tableLayout;
        private System.Windows.Forms.TableLayoutPanel panelFileInput_tableLayout;
        private System.Windows.Forms.TableLayoutPanel panelOutputSelect_tableLayoutLeft;
		private System.Windows.Forms.TableLayoutPanel formMainTopTableLayout;
		private System.Windows.Forms.TableLayoutPanel panelLast_tableLayout;
		private System.Windows.Forms.DataGridViewTextBoxColumn replaceString;
        private System.Windows.Forms.DataGridViewTextBoxColumn stringAfterReplace;
        private System.Windows.Forms.Panel panelRawView;
        private System.Windows.Forms.DataGridView panelRawView_dataGridViewMBSA;
        private System.Windows.Forms.DataGridView panelRawView_dataGridViewNessus;
        private System.Windows.Forms.DataGridView panelRawView_dataGridViewNmap;
        private System.Windows.Forms.Button panelRawView_buttonShowAll;
        private System.Windows.Forms.Label panelRawView_labelKeyWord;
        private System.Windows.Forms.TextBox panelRawView_textBoxKeyword;
        private System.Windows.Forms.ComboBox panelRawView_comboBoxFilter;
        private System.Windows.Forms.Button panelRawView_buttonFilter;
        private System.Windows.Forms.TabControl panelRawView_tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView panelRawView_dataGridViewAcunetix;
        private System.Windows.Forms.Button buttonGenExcel;
        private System.Windows.Forms.Button buttonGenExcelSelected;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExcelSelected;
        private System.Windows.Forms.TableLayoutPanel panelRawView_tableLayoutPanel;
        private System.Windows.Forms.TreeView panelRawView_treeViewFileName;
        private System.Windows.Forms.TableLayoutPanel panelFileInput_tableLayoutBottom;
        private System.Windows.Forms.Button panelFileInput_buttonSelectAll;
        private System.Windows.Forms.Button panelFileInput_buttonSelectNone;
        private System.Windows.Forms.Button panelFileInput_buttonImportFile;
        private System.Windows.Forms.Button panelFileInput_buttonClear;
        private System.Windows.Forms.Button panelFileInput_buttonImportFolder;
        private System.Windows.Forms.Button panelFileInput_buttonReverse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox panelFileInput_checkedListBox;
        private System.Windows.Forms.TreeView panelFileInput_treeViewFileName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel panelRecordEdit_tableLayoutBottom;
        private System.Windows.Forms.Button panelRecordEdit_buttonSelectAll;
        private System.Windows.Forms.Label panelRecordEdit_labelKeyword;
        private System.Windows.Forms.TextBox panelRecordEdit_textBoxKeyWord;
        private System.Windows.Forms.ComboBox panelRecordEdit_comboBoxFilter;
        private System.Windows.Forms.ComboBox panelRecordEdit_comboBoxFilterMode;
        private System.Windows.Forms.Button panelRecordEdit_buttonSelectNone;
        private System.Windows.Forms.ComboBox panelRecordEdit_comboBoxBottom;
        private System.Windows.Forms.Button panelRecordEdit_buttonSelectUpdate;
        private System.Windows.Forms.Button panelRecordEdit_buttonSelectMerge;
        private System.Windows.Forms.Button panelRecordEdit_buttonReverse;
        private System.Windows.Forms.Button panelRecordEdit_buttonMergeRecord;
        private System.Windows.Forms.Button panelRecordEdit_buttonUpdateRecord;
        private System.Windows.Forms.Button panelRecordEdit_buttonDeleteRecord;
        private System.Windows.Forms.Button panelRecordEdit_buttonUndo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button panelRecordEdit_buttonPermanentDataBase;
        private System.Windows.Forms.Button panelRecordEdit_buttonIPHostTable;
        private System.Windows.Forms.Button panelRecordEdit_buttonSaveConfig;
        private System.Windows.Forms.Button panelRecordEdit_buttonFilter;
        private System.Windows.Forms.Button panelRecordEdit_buttonUp;
        private System.Windows.Forms.Button panelRecordEdit_buttonDown;
        private System.Windows.Forms.ComboBox panelRecordEdit_comboBoxCase;
        private System.Windows.Forms.TableLayoutPanel panelOutputSelect_TableLayoutRight;
        private System.Windows.Forms.Label panelOutputSelect_labelRightTopText;
        private System.Windows.Forms.GroupBox panelOutputSelect_groupBoxOtherSettings;
        private System.Windows.Forms.CheckBox panelOutputSelect_checkboxIpHostOutput;
        private System.Windows.Forms.CheckBox panelOutputSelect_checkboxOpenPortOutput;
        private System.Windows.Forms.CheckBox panelOutputSelect_checkboxHotfixOutput;
        private System.Windows.Forms.GroupBox panelOutputSelect_groupBoxOutputFilePath;
        private System.Windows.Forms.Button panelOutputSelect_buttonOutputPathSaveAs;
        private System.Windows.Forms.TextBox panelOutputSelect_textBoxOutputFilePath;
        private System.Windows.Forms.GroupBox panelOutputSelect_groupBoxTemplatePath;
        private System.Windows.Forms.Button panelOutputSelect_buttonTemplatePathOpen;
        private System.Windows.Forms.TextBox panelOutputSelect_textBoxTemplatePath;
        private System.Windows.Forms.Button panelRecordEdit_buttonCreateExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCreateExcelInPanelRecordEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn oldId;
        private System.Windows.Forms.DataGridViewComboBoxColumn entryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn plugin_version;
        private System.Windows.Forms.DataGridViewTextBoxColumn plugin_ID;
        private System.Windows.Forms.CheckBox panelOutputSelect_checkboxExportPluginOutput;
        private System.Windows.Forms.TextBox panelOutputSelect_textBoxTextFileBrowse;
        private System.Windows.Forms.Button panelOutputSelect_buttonTextFileBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialogTextFileBrowse;
        private System.Windows.Forms.Label panelOutputSelect_labelTextFileBrowse;
	}
}
