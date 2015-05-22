namespace ReportGenerator {
	partial class Form4 {
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
			this.dataGridViewNew = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewNew)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewOld
			// 
			this.dataGridViewOld.AllowUserToAddRows = false;
			this.dataGridViewOld.AllowUserToDeleteRows = false;
			this.dataGridViewOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewOld.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pluginName,
            this.ipList,
            this.description,
            this.impact,
            this.riskLevel,
            this.recommendations,
            this.reference_CVE,
            this.reference_BID,
            this.reference_OSVDB,
            this.referenceLink});
			this.dataGridViewOld.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewOld.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewOld.Name = "dataGridViewOld";
			this.dataGridViewOld.ReadOnly = true;
			this.dataGridViewOld.RowHeadersVisible = false;
			this.dataGridViewOld.Size = new System.Drawing.Size(854, 154);
			this.dataGridViewOld.TabIndex = 1;
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
			this.referenceLink.FillWeight = 86F;
			this.referenceLink.HeaderText = "Reference Link";
			this.referenceLink.Name = "referenceLink";
			this.referenceLink.ReadOnly = true;
			this.referenceLink.Width = 86;
			// 
			// dataGridViewNew
			// 
			this.dataGridViewNew.AllowUserToAddRows = false;
			this.dataGridViewNew.AllowUserToDeleteRows = false;
			this.dataGridViewNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
			this.dataGridViewNew.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewNew.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewNew.Name = "dataGridViewNew";
			this.dataGridViewNew.RowHeadersVisible = false;
			this.dataGridViewNew.Size = new System.Drawing.Size(854, 81);
			this.dataGridViewNew.TabIndex = 2;
			this.dataGridViewNew.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewNew_CellMouseDoubleClick);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.FillWeight = 86F;
			this.dataGridViewTextBoxColumn1.HeaderText = "Plugin Name";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 86;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.FillWeight = 86F;
			this.dataGridViewTextBoxColumn2.HeaderText = "Host Affected";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 86;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.FillWeight = 86F;
			this.dataGridViewTextBoxColumn3.HeaderText = "Description";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 86;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.FillWeight = 86F;
			this.dataGridViewTextBoxColumn4.HeaderText = "Impact";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 86;
			// 
			// dataGridViewComboBoxColumn1
			// 
			this.dataGridViewComboBoxColumn1.FillWeight = 60F;
			this.dataGridViewComboBoxColumn1.HeaderText = "Risk Level";
			this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low",
            "None",
            "OpenPort"});
			this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
			this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewComboBoxColumn1.Width = 60;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.FillWeight = 86F;
			this.dataGridViewTextBoxColumn5.HeaderText = "Recommendations";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Width = 86;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.FillWeight = 86F;
			this.dataGridViewTextBoxColumn6.HeaderText = "Reference (CVE)";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Width = 86;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.FillWeight = 86F;
			this.dataGridViewTextBoxColumn7.HeaderText = "Reference (BID)";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Width = 86;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.FillWeight = 86F;
			this.dataGridViewTextBoxColumn8.HeaderText = "Reference (OSVDB)";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Width = 86;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.FillWeight = 86F;
			this.dataGridViewTextBoxColumn9.HeaderText = "Reference Link";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Width = 86;
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(716, 281);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 23);
			this.ok.TabIndex = 3;
			this.ok.Text = "OK";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(797, 281);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 4;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridViewOld);
			this.groupBox1.Location = new System.Drawing.Point(12, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(860, 173);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Record(s)";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dataGridViewNew);
			this.groupBox2.Location = new System.Drawing.Point(12, 178);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(860, 100);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "New Record";
			// 
			// Form4
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 312);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.MaximumSize = new System.Drawing.Size(900, 350);
			this.MinimumSize = new System.Drawing.Size(900, 350);
			this.Name = "Form4";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Report Generator";
			this.Load += new System.EventHandler(this.Form4_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewNew)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewOld;
		private System.Windows.Forms.DataGridView dataGridViewNew;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
	}
}