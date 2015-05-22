namespace ReportGenerator {
	partial class FormEditTemplateString {
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
            this.FormEditTemplateString_groupBoxBottom = new System.Windows.Forms.GroupBox();
            this.richTextBoxNew = new System.Windows.Forms.RichTextBox();
            this.FormEditTemplateString_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FormEditTemplateString_tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.FormEditTemplateString_groupBoxTop = new System.Windows.Forms.GroupBox();
            this.richTextBoxOld = new System.Windows.Forms.RichTextBox();
            this.FormEditTemplateString_groupBoxBottom.SuspendLayout();
            this.FormEditTemplateString_tableLayoutPanel.SuspendLayout();
            this.FormEditTemplateString_tableLayoutPanelBottom.SuspendLayout();
            this.FormEditTemplateString_groupBoxTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormEditTemplateString_groupBoxBottom
            // 
            this.FormEditTemplateString_groupBoxBottom.Controls.Add(this.richTextBoxNew);
            this.FormEditTemplateString_groupBoxBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormEditTemplateString_groupBoxBottom.Location = new System.Drawing.Point(0, 81);
            this.FormEditTemplateString_groupBoxBottom.Margin = new System.Windows.Forms.Padding(0);
            this.FormEditTemplateString_groupBoxBottom.Name = "FormEditTemplateString_groupBoxBottom";
            this.FormEditTemplateString_groupBoxBottom.Size = new System.Drawing.Size(692, 150);
            this.FormEditTemplateString_groupBoxBottom.TabIndex = 0;
            this.FormEditTemplateString_groupBoxBottom.TabStop = false;
            this.FormEditTemplateString_groupBoxBottom.Text = "Replaced String";
            // 
            // richTextBoxNew
            // 
            this.richTextBoxNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxNew.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxNew.Name = "richTextBoxNew";
            this.richTextBoxNew.Size = new System.Drawing.Size(686, 131);
            this.richTextBoxNew.TabIndex = 0;
            this.richTextBoxNew.Text = "";
            // 
            // FormEditTemplateString_tableLayoutPanel
            // 
            this.FormEditTemplateString_tableLayoutPanel.ColumnCount = 1;
            this.FormEditTemplateString_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormEditTemplateString_tableLayoutPanel.Controls.Add(this.FormEditTemplateString_tableLayoutPanelBottom, 0, 2);
            this.FormEditTemplateString_tableLayoutPanel.Controls.Add(this.FormEditTemplateString_groupBoxBottom, 0, 1);
            this.FormEditTemplateString_tableLayoutPanel.Controls.Add(this.FormEditTemplateString_groupBoxTop, 0, 0);
            this.FormEditTemplateString_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormEditTemplateString_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FormEditTemplateString_tableLayoutPanel.Name = "FormEditTemplateString_tableLayoutPanel";
            this.FormEditTemplateString_tableLayoutPanel.RowCount = 3;
            this.FormEditTemplateString_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.FormEditTemplateString_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.FormEditTemplateString_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.FormEditTemplateString_tableLayoutPanel.Size = new System.Drawing.Size(692, 267);
            this.FormEditTemplateString_tableLayoutPanel.TabIndex = 1;
            // 
            // FormEditTemplateString_tableLayoutPanelBottom
            // 
            this.FormEditTemplateString_tableLayoutPanelBottom.ColumnCount = 3;
            this.FormEditTemplateString_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormEditTemplateString_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.FormEditTemplateString_tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.FormEditTemplateString_tableLayoutPanelBottom.Controls.Add(this.buttonOk, 1, 0);
            this.FormEditTemplateString_tableLayoutPanelBottom.Controls.Add(this.buttonCancel, 2, 0);
            this.FormEditTemplateString_tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.FormEditTemplateString_tableLayoutPanelBottom.Location = new System.Drawing.Point(489, 234);
            this.FormEditTemplateString_tableLayoutPanelBottom.Name = "FormEditTemplateString_tableLayoutPanelBottom";
            this.FormEditTemplateString_tableLayoutPanelBottom.RowCount = 1;
            this.FormEditTemplateString_tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormEditTemplateString_tableLayoutPanelBottom.Size = new System.Drawing.Size(200, 30);
            this.FormEditTemplateString_tableLayoutPanelBottom.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOk.Location = new System.Drawing.Point(33, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(79, 24);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(118, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(79, 24);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormEditTemplateString_groupBoxTop
            // 
            this.FormEditTemplateString_groupBoxTop.Controls.Add(this.richTextBoxOld);
            this.FormEditTemplateString_groupBoxTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormEditTemplateString_groupBoxTop.Location = new System.Drawing.Point(3, 3);
            this.FormEditTemplateString_groupBoxTop.Name = "FormEditTemplateString_groupBoxTop";
            this.FormEditTemplateString_groupBoxTop.Size = new System.Drawing.Size(686, 75);
            this.FormEditTemplateString_groupBoxTop.TabIndex = 2;
            this.FormEditTemplateString_groupBoxTop.TabStop = false;
            this.FormEditTemplateString_groupBoxTop.Text = "Original String";
            // 
            // richTextBoxOld
            // 
            this.richTextBoxOld.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOld.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxOld.Name = "richTextBoxOld";
            this.richTextBoxOld.ReadOnly = true;
            this.richTextBoxOld.Size = new System.Drawing.Size(680, 56);
            this.richTextBoxOld.TabIndex = 0;
            this.richTextBoxOld.Text = "";
            // 
            // FormEditTemplateString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 267);
            this.Controls.Add(this.FormEditTemplateString_tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "FormEditTemplateString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form6";
            this.FormEditTemplateString_groupBoxBottom.ResumeLayout(false);
            this.FormEditTemplateString_tableLayoutPanel.ResumeLayout(false);
            this.FormEditTemplateString_tableLayoutPanelBottom.ResumeLayout(false);
            this.FormEditTemplateString_groupBoxTop.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox FormEditTemplateString_groupBoxBottom;
		private System.Windows.Forms.RichTextBox richTextBoxNew;
		private System.Windows.Forms.TableLayoutPanel FormEditTemplateString_tableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel FormEditTemplateString_tableLayoutPanelBottom;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox FormEditTemplateString_groupBoxTop;
		private System.Windows.Forms.RichTextBox richTextBoxOld;

	}
}
