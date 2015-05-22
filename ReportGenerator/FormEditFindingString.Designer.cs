namespace ReportGenerator {
	partial class FormEditFindingString {
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
            this.dataGridViewOld = new System.Windows.Forms.DataGridView();
            this.editColumnOld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormEditFindingString_groupBoxTop = new System.Windows.Forms.GroupBox();
            this.FormEditFindingString_groupBoxBottom = new System.Windows.Forms.GroupBox();
            this.FormEditFindingString_richTextBox = new System.Windows.Forms.RichTextBox();
            this.FormEditFindingString_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FormEditFindingString_tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonApplyToAll = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).BeginInit();
            this.FormEditFindingString_groupBoxTop.SuspendLayout();
            this.FormEditFindingString_groupBoxBottom.SuspendLayout();
            this.FormEditFindingString_tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.FormEditFindingString_tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOld
            // 
            this.dataGridViewOld.AllowUserToAddRows = false;
            this.dataGridViewOld.AllowUserToDeleteRows = false;
            this.dataGridViewOld.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOld.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editColumnOld});
            this.dataGridViewOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOld.Location = new System.Drawing.Point(3, 20);
            this.dataGridViewOld.Name = "dataGridViewOld";
            this.dataGridViewOld.ReadOnly = true;
            this.dataGridViewOld.RowHeadersVisible = false;
            this.dataGridViewOld.Size = new System.Drawing.Size(880, 171);
            this.dataGridViewOld.TabIndex = 1;
            // 
            // editColumnOld
            // 
            this.editColumnOld.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editColumnOld.DefaultCellStyle = dataGridViewCellStyle1;
            this.editColumnOld.FillWeight = 850F;
            this.editColumnOld.HeaderText = "";
            this.editColumnOld.Name = "editColumnOld";
            this.editColumnOld.ReadOnly = true;
            // 
            // FormEditFindingString_groupBoxTop
            // 
            this.FormEditFindingString_groupBoxTop.Controls.Add(this.dataGridViewOld);
            this.FormEditFindingString_groupBoxTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormEditFindingString_groupBoxTop.Location = new System.Drawing.Point(3, 3);
            this.FormEditFindingString_groupBoxTop.Name = "FormEditFindingString_groupBoxTop";
            this.FormEditFindingString_groupBoxTop.Size = new System.Drawing.Size(886, 194);
            this.FormEditFindingString_groupBoxTop.TabIndex = 9;
            this.FormEditFindingString_groupBoxTop.TabStop = false;
            this.FormEditFindingString_groupBoxTop.Text = "Selected Field";
            // 
            // FormEditFindingString_groupBoxBottom
            // 
            this.FormEditFindingString_groupBoxBottom.Controls.Add(this.FormEditFindingString_richTextBox);
            this.FormEditFindingString_groupBoxBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormEditFindingString_groupBoxBottom.Location = new System.Drawing.Point(3, 203);
            this.FormEditFindingString_groupBoxBottom.Name = "FormEditFindingString_groupBoxBottom";
            this.FormEditFindingString_groupBoxBottom.Size = new System.Drawing.Size(886, 171);
            this.FormEditFindingString_groupBoxBottom.TabIndex = 10;
            this.FormEditFindingString_groupBoxBottom.TabStop = false;
            this.FormEditFindingString_groupBoxBottom.Text = "New Field Data";
            // 
            // FormEditFindingString_richTextBox
            // 
            this.FormEditFindingString_richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormEditFindingString_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormEditFindingString_richTextBox.Location = new System.Drawing.Point(3, 16);
            this.FormEditFindingString_richTextBox.Name = "FormEditFindingString_richTextBox";
            this.FormEditFindingString_richTextBox.Size = new System.Drawing.Size(880, 152);
            this.FormEditFindingString_richTextBox.TabIndex = 0;
            this.FormEditFindingString_richTextBox.Text = "";
            // 
            // FormEditFindingString_tableLayoutPanel
            // 
            this.FormEditFindingString_tableLayoutPanel.ColumnCount = 1;
            this.FormEditFindingString_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormEditFindingString_tableLayoutPanel.Controls.Add(this.FormEditFindingString_groupBoxTop, 0, 0);
            this.FormEditFindingString_tableLayoutPanel.Controls.Add(this.FormEditFindingString_groupBoxBottom, 0, 1);
            this.FormEditFindingString_tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.FormEditFindingString_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormEditFindingString_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FormEditFindingString_tableLayoutPanel.Name = "FormEditFindingString_tableLayoutPanel";
            this.FormEditFindingString_tableLayoutPanel.RowCount = 3;
            this.FormEditFindingString_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.16092F));
            this.FormEditFindingString_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.83908F));
            this.FormEditFindingString_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.FormEditFindingString_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.FormEditFindingString_tableLayoutPanel.Size = new System.Drawing.Size(892, 421);
            this.FormEditFindingString_tableLayoutPanel.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.75621F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.24379F));
            this.tableLayoutPanel1.Controls.Add(this.FormEditFindingString_tableLayoutPanelBottom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddSelected, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 380);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 38);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // FormEditFindingString_tableLayoutPanelBottom
            // 
            this.FormEditFindingString_tableLayoutPanelBottom.ColumnCount = 3;
            this.FormEditFindingString_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.FormEditFindingString_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.FormEditFindingString_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.FormEditFindingString_tableLayoutPanelBottom.Controls.Add(this.buttonApplyToAll, 0, 0);
            this.FormEditFindingString_tableLayoutPanelBottom.Controls.Add(this.buttonOk, 0, 0);
            this.FormEditFindingString_tableLayoutPanelBottom.Controls.Add(this.buttonCancel, 1, 0);
            this.FormEditFindingString_tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.FormEditFindingString_tableLayoutPanelBottom.Location = new System.Drawing.Point(505, 3);
            this.FormEditFindingString_tableLayoutPanelBottom.Name = "FormEditFindingString_tableLayoutPanelBottom";
            this.FormEditFindingString_tableLayoutPanelBottom.RowCount = 1;
            this.FormEditFindingString_tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormEditFindingString_tableLayoutPanelBottom.Size = new System.Drawing.Size(378, 32);
            this.FormEditFindingString_tableLayoutPanelBottom.TabIndex = 10;
            // 
            // buttonApplyToAll
            // 
            this.buttonApplyToAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonApplyToAll.Location = new System.Drawing.Point(103, 3);
            this.buttonApplyToAll.Name = "buttonApplyToAll";
            this.buttonApplyToAll.Size = new System.Drawing.Size(164, 26);
            this.buttonApplyToAll.TabIndex = 9;
            this.buttonApplyToAll.Text = "Apply to all permanently";
            this.buttonApplyToAll.UseVisualStyleBackColor = true;
            this.buttonApplyToAll.Click += new System.EventHandler(this.buttonApplyToAll_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOk.Location = new System.Drawing.Point(3, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(94, 26);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(273, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 26);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddSelected
            // 
            this.buttonAddSelected.Location = new System.Drawing.Point(3, 3);
            this.buttonAddSelected.Name = "buttonAddSelected";
            this.buttonAddSelected.Size = new System.Drawing.Size(75, 25);
            this.buttonAddSelected.TabIndex = 0;
            this.buttonAddSelected.Text = "Add Selected";
            this.buttonAddSelected.UseVisualStyleBackColor = true;
            this.buttonAddSelected.Click += new System.EventHandler(this.buttonAddSelected_Click);
            // 
            // FormEditFindingString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 421);
            this.Controls.Add(this.FormEditFindingString_tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(900, 450);
            this.Name = "FormEditFindingString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).EndInit();
            this.FormEditFindingString_groupBoxTop.ResumeLayout(false);
            this.FormEditFindingString_groupBoxBottom.ResumeLayout(false);
            this.FormEditFindingString_tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.FormEditFindingString_tableLayoutPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewOld;
        private System.Windows.Forms.GroupBox FormEditFindingString_groupBoxTop;
		private System.Windows.Forms.GroupBox FormEditFindingString_groupBoxBottom;
		private System.Windows.Forms.RichTextBox FormEditFindingString_richTextBox;
        private System.Windows.Forms.TableLayoutPanel FormEditFindingString_tableLayoutPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn editColumnOld;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel FormEditFindingString_tableLayoutPanelBottom;
        private System.Windows.Forms.Button buttonApplyToAll;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddSelected;

	}
}
