namespace ReportGenerator {
	partial class FormEditFinding {
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
            this.dataGridViewOld = new System.Windows.Forms.DataGridView();
            this.dataGridViewNew = new System.Windows.Forms.DataGridView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.formEditFinding_groupBoxTop = new System.Windows.Forms.GroupBox();
            this.formEditFinding_groupBoxBottom = new System.Windows.Forms.GroupBox();
            this.formEditFinding_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.formEditFinding_tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.pluginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.riskLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.recommendation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.osvdb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.plugin_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plugin_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pluginNameNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipListNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impactNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.riskLevelNew = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.recommendationNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cveNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.osvdbNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceLinkNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryTypeNew = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.plugin_versionNEW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plugin_IDNEW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNew)).BeginInit();
            this.formEditFinding_groupBoxTop.SuspendLayout();
            this.formEditFinding_groupBoxBottom.SuspendLayout();
            this.formEditFinding_tableLayoutPanel.SuspendLayout();
            this.formEditFinding_tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOld
            // 
            this.dataGridViewOld.AllowUserToAddRows = false;
            this.dataGridViewOld.AllowUserToDeleteRows = false;
            this.dataGridViewOld.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOld.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pluginName,
            this.ipList,
            this.description,
            this.impact,
            this.riskLevel,
            this.recommendation,
            this.cve,
            this.bid,
            this.osvdb,
            this.referenceLink,
            this.entryType,
            this.plugin_version,
            this.plugin_ID});
            this.dataGridViewOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOld.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewOld.Name = "dataGridViewOld";
            this.dataGridViewOld.ReadOnly = true;
            this.dataGridViewOld.RowHeadersVisible = false;
            this.dataGridViewOld.RowTemplate.Height = 24;
            this.dataGridViewOld.Size = new System.Drawing.Size(880, 143);
            this.dataGridViewOld.TabIndex = 1;
            this.dataGridViewOld.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOld_CellContentClick);
            // 
            // dataGridViewNew
            // 
            this.dataGridViewNew.AllowUserToAddRows = false;
            this.dataGridViewNew.AllowUserToDeleteRows = false;
            this.dataGridViewNew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pluginNameNew,
            this.ipListNew,
            this.descriptionNew,
            this.impactNew,
            this.riskLevelNew,
            this.recommendationNew,
            this.cveNew,
            this.bidNew,
            this.osvdbNew,
            this.referenceLinkNew,
            this.entryTypeNew,
            this.plugin_versionNEW,
            this.plugin_IDNEW});
            this.dataGridViewNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewNew.Location = new System.Drawing.Point(3, 20);
            this.dataGridViewNew.Name = "dataGridViewNew";
            this.dataGridViewNew.RowHeadersVisible = false;
            this.dataGridViewNew.RowTemplate.Height = 24;
            this.dataGridViewNew.Size = new System.Drawing.Size(880, 83);
            this.dataGridViewNew.TabIndex = 2;
            this.dataGridViewNew.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewNew_CellMouseDoubleClick);
            // 
            // buttonOk
            // 
            this.buttonOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOk.Location = new System.Drawing.Point(3, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(103, 24);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(112, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 24);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // formEditFinding_groupBoxTop
            // 
            this.formEditFinding_groupBoxTop.Controls.Add(this.dataGridViewOld);
            this.formEditFinding_groupBoxTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formEditFinding_groupBoxTop.Location = new System.Drawing.Point(3, 3);
            this.formEditFinding_groupBoxTop.Name = "formEditFinding_groupBoxTop";
            this.formEditFinding_groupBoxTop.Size = new System.Drawing.Size(886, 162);
            this.formEditFinding_groupBoxTop.TabIndex = 5;
            this.formEditFinding_groupBoxTop.TabStop = false;
            this.formEditFinding_groupBoxTop.Text = "Selected Record(s)";
            // 
            // formEditFinding_groupBoxBottom
            // 
            this.formEditFinding_groupBoxBottom.Controls.Add(this.dataGridViewNew);
            this.formEditFinding_groupBoxBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formEditFinding_groupBoxBottom.Location = new System.Drawing.Point(3, 171);
            this.formEditFinding_groupBoxBottom.Name = "formEditFinding_groupBoxBottom";
            this.formEditFinding_groupBoxBottom.Size = new System.Drawing.Size(886, 106);
            this.formEditFinding_groupBoxBottom.TabIndex = 6;
            this.formEditFinding_groupBoxBottom.TabStop = false;
            this.formEditFinding_groupBoxBottom.Text = "New Record";
            // 
            // formEditFinding_tableLayoutPanel
            // 
            this.formEditFinding_tableLayoutPanel.ColumnCount = 1;
            this.formEditFinding_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formEditFinding_tableLayoutPanel.Controls.Add(this.formEditFinding_groupBoxTop, 0, 0);
            this.formEditFinding_tableLayoutPanel.Controls.Add(this.formEditFinding_tableLayoutPanelBottom, 0, 2);
            this.formEditFinding_tableLayoutPanel.Controls.Add(this.formEditFinding_groupBoxBottom, 0, 1);
            this.formEditFinding_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formEditFinding_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.formEditFinding_tableLayoutPanel.Name = "formEditFinding_tableLayoutPanel";
            this.formEditFinding_tableLayoutPanel.RowCount = 3;
            this.formEditFinding_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.formEditFinding_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.formEditFinding_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.formEditFinding_tableLayoutPanel.Size = new System.Drawing.Size(892, 316);
            this.formEditFinding_tableLayoutPanel.TabIndex = 7;
            // 
            // formEditFinding_tableLayoutPanelBottom
            // 
            this.formEditFinding_tableLayoutPanelBottom.ColumnCount = 2;
            this.formEditFinding_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.54546F));
            this.formEditFinding_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.45454F));
            this.formEditFinding_tableLayoutPanelBottom.Controls.Add(this.buttonOk, 0, 0);
            this.formEditFinding_tableLayoutPanelBottom.Controls.Add(this.buttonCancel, 1, 0);
            this.formEditFinding_tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.formEditFinding_tableLayoutPanelBottom.Location = new System.Drawing.Point(669, 283);
            this.formEditFinding_tableLayoutPanelBottom.Name = "formEditFinding_tableLayoutPanelBottom";
            this.formEditFinding_tableLayoutPanelBottom.RowCount = 1;
            this.formEditFinding_tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formEditFinding_tableLayoutPanelBottom.Size = new System.Drawing.Size(220, 30);
            this.formEditFinding_tableLayoutPanelBottom.TabIndex = 8;
            // 
            // pluginName
            // 
            this.pluginName.FillWeight = 86F;
            this.pluginName.HeaderText = "Plugin Name";
            this.pluginName.Name = "pluginName";
            this.pluginName.ReadOnly = true;
            // 
            // ipList
            // 
            this.ipList.FillWeight = 86F;
            this.ipList.HeaderText = "Host Affected";
            this.ipList.Name = "ipList";
            this.ipList.ReadOnly = true;
            // 
            // description
            // 
            this.description.FillWeight = 86F;
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // impact
            // 
            this.impact.FillWeight = 86F;
            this.impact.HeaderText = "Impact";
            this.impact.Name = "impact";
            this.impact.ReadOnly = true;
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
            // 
            // recommendation
            // 
            this.recommendation.FillWeight = 86F;
            this.recommendation.HeaderText = "Recommendations";
            this.recommendation.Name = "recommendation";
            this.recommendation.ReadOnly = true;
            // 
            // cve
            // 
            this.cve.FillWeight = 78F;
            this.cve.HeaderText = "Reference (CVE)";
            this.cve.Name = "cve";
            this.cve.ReadOnly = true;
            // 
            // bid
            // 
            this.bid.FillWeight = 78F;
            this.bid.HeaderText = "Reference (BID)";
            this.bid.Name = "bid";
            this.bid.ReadOnly = true;
            // 
            // osvdb
            // 
            this.osvdb.FillWeight = 78F;
            this.osvdb.HeaderText = "Reference (OSVDB)";
            this.osvdb.Name = "osvdb";
            this.osvdb.ReadOnly = true;
            // 
            // referenceLink
            // 
            this.referenceLink.FillWeight = 68F;
            this.referenceLink.HeaderText = "Reference Link";
            this.referenceLink.Name = "referenceLink";
            this.referenceLink.ReadOnly = true;
            // 
            // entryType
            // 
            this.entryType.FillWeight = 58F;
            this.entryType.HeaderText = "Entry Type";
            this.entryType.Items.AddRange(new object[] {
            "NESSUS",
            "MBSA",
            "NMAP",
            "Acunetix",
            "MBSA_NESSUS"});
            this.entryType.Name = "entryType";
            this.entryType.ReadOnly = true;
            this.entryType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.entryType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // 
            // pluginNameNew
            // 
            this.pluginNameNew.FillWeight = 86F;
            this.pluginNameNew.HeaderText = "Plugin Name";
            this.pluginNameNew.Name = "pluginNameNew";
            this.pluginNameNew.ReadOnly = true;
            // 
            // ipListNew
            // 
            this.ipListNew.FillWeight = 86F;
            this.ipListNew.HeaderText = "Host Affected";
            this.ipListNew.Name = "ipListNew";
            this.ipListNew.ReadOnly = true;
            // 
            // descriptionNew
            // 
            this.descriptionNew.FillWeight = 86F;
            this.descriptionNew.HeaderText = "Description";
            this.descriptionNew.Name = "descriptionNew";
            this.descriptionNew.ReadOnly = true;
            // 
            // impactNew
            // 
            this.impactNew.FillWeight = 86F;
            this.impactNew.HeaderText = "Impact";
            this.impactNew.Name = "impactNew";
            this.impactNew.ReadOnly = true;
            // 
            // riskLevelNew
            // 
            this.riskLevelNew.FillWeight = 60F;
            this.riskLevelNew.HeaderText = "Risk Level";
            this.riskLevelNew.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low",
            "None",
            "OpenPort"});
            this.riskLevelNew.Name = "riskLevelNew";
            this.riskLevelNew.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.riskLevelNew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // recommendationNew
            // 
            this.recommendationNew.FillWeight = 86F;
            this.recommendationNew.HeaderText = "Recommendations";
            this.recommendationNew.Name = "recommendationNew";
            this.recommendationNew.ReadOnly = true;
            // 
            // cveNew
            // 
            this.cveNew.FillWeight = 78F;
            this.cveNew.HeaderText = "Reference (CVE)";
            this.cveNew.Name = "cveNew";
            this.cveNew.ReadOnly = true;
            // 
            // bidNew
            // 
            this.bidNew.FillWeight = 78F;
            this.bidNew.HeaderText = "Reference (BID)";
            this.bidNew.Name = "bidNew";
            this.bidNew.ReadOnly = true;
            // 
            // osvdbNew
            // 
            this.osvdbNew.FillWeight = 78F;
            this.osvdbNew.HeaderText = "Reference (OSVDB)";
            this.osvdbNew.Name = "osvdbNew";
            this.osvdbNew.ReadOnly = true;
            // 
            // referenceLinkNew
            // 
            this.referenceLinkNew.FillWeight = 68F;
            this.referenceLinkNew.HeaderText = "Reference Link";
            this.referenceLinkNew.Name = "referenceLinkNew";
            this.referenceLinkNew.ReadOnly = true;
            // 
            // entryTypeNew
            // 
            this.entryTypeNew.FillWeight = 58F;
            this.entryTypeNew.HeaderText = "Entry Type";
            this.entryTypeNew.Items.AddRange(new object[] {
            "NESSUS",
            "MBSA",
            "NMAP",
            "Acunetix",
            "MBSA_NESSUS"});
            this.entryTypeNew.Name = "entryTypeNew";
            this.entryTypeNew.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.entryTypeNew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // plugin_versionNEW
            // 
            this.plugin_versionNEW.HeaderText = "plugin_version";
            this.plugin_versionNEW.Name = "plugin_versionNEW";
            this.plugin_versionNEW.Visible = false;
            // 
            // plugin_IDNEW
            // 
            this.plugin_IDNEW.HeaderText = "plugin_ID";
            this.plugin_IDNEW.Name = "plugin_IDNEW";
            this.plugin_IDNEW.Visible = false;
            // 
            // FormEditFinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 316);
            this.Controls.Add(this.formEditFinding_tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(900, 350);
            this.Name = "FormEditFinding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Generator";
            this.Load += new System.EventHandler(this.FormEditFinding_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNew)).EndInit();
            this.formEditFinding_groupBoxTop.ResumeLayout(false);
            this.formEditFinding_groupBoxBottom.ResumeLayout(false);
            this.formEditFinding_tableLayoutPanel.ResumeLayout(false);
            this.formEditFinding_tableLayoutPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewOld;
		private System.Windows.Forms.DataGridView dataGridViewNew;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox formEditFinding_groupBoxTop;
        private System.Windows.Forms.GroupBox formEditFinding_groupBoxBottom;
		private System.Windows.Forms.TableLayoutPanel formEditFinding_tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel formEditFinding_tableLayoutPanelBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn pluginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipList;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn impact;
        private System.Windows.Forms.DataGridViewComboBoxColumn riskLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn recommendation;
        private System.Windows.Forms.DataGridViewTextBoxColumn cve;
        private System.Windows.Forms.DataGridViewTextBoxColumn bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn osvdb;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceLink;
        private System.Windows.Forms.DataGridViewComboBoxColumn entryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn plugin_version;
        private System.Windows.Forms.DataGridViewTextBoxColumn plugin_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pluginNameNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipListNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn impactNew;
        private System.Windows.Forms.DataGridViewComboBoxColumn riskLevelNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn recommendationNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn cveNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn osvdbNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceLinkNew;
        private System.Windows.Forms.DataGridViewComboBoxColumn entryTypeNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn plugin_versionNEW;
        private System.Windows.Forms.DataGridViewTextBoxColumn plugin_IDNEW;
	}
}
