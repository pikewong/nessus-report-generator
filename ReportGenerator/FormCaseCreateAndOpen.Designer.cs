namespace ReportGenerator {
	partial class FormCaseCreateAndOpen {
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxBrowse = new System.Windows.Forms.TextBox();
            this.labelTextDisplay = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FormCaseCreateAndOpenBrowseTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FormCaseCreateAndOpenBottomButtonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FormCaseCreateAndOpenTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FormCaseCreateAndOpenBrowseTableLayout.SuspendLayout();
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.SuspendLayout();
            this.FormCaseCreateAndOpenTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCancel.Location = new System.Drawing.Point(163, 10);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBack.Location = new System.Drawing.Point(3, 10);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(74, 23);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "< Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNext.Enabled = false;
            this.buttonNext.Location = new System.Drawing.Point(83, 10);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(74, 23);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Next >";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxBrowse
            // 
            this.textBoxBrowse.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBrowse.Location = new System.Drawing.Point(3, 5);
            this.textBoxBrowse.Margin = new System.Windows.Forms.Padding(3, 5, 3, 8);
            this.textBoxBrowse.Name = "textBoxBrowse";
            this.textBoxBrowse.ReadOnly = true;
            this.textBoxBrowse.Size = new System.Drawing.Size(375, 20);
            this.textBoxBrowse.TabIndex = 0;
            this.textBoxBrowse.Click += new System.EventHandler(this.browse_Click);
            this.textBoxBrowse.TextChanged += new System.EventHandler(this.textBoxBrowse_TextChanged);
            // 
            // labelTextDisplay
            // 
            this.labelTextDisplay.AutoSize = true;
            this.labelTextDisplay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTextDisplay.Location = new System.Drawing.Point(10, 12);
            this.labelTextDisplay.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelTextDisplay.Name = "labelTextDisplay";
            this.labelTextDisplay.Size = new System.Drawing.Size(471, 13);
            this.labelTextDisplay.TabIndex = 8;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBrowse.Location = new System.Drawing.Point(386, 3);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(77, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.browse_Click);
            // 
            // FormCaseCreateAndOpenBrowseTableLayout
            // 
            this.FormCaseCreateAndOpenBrowseTableLayout.ColumnCount = 2;
            this.FormCaseCreateAndOpenBrowseTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormCaseCreateAndOpenBrowseTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.FormCaseCreateAndOpenBrowseTableLayout.Controls.Add(this.textBoxBrowse, 0, 0);
            this.FormCaseCreateAndOpenBrowseTableLayout.Controls.Add(this.buttonBrowse, 1, 0);
            this.FormCaseCreateAndOpenBrowseTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormCaseCreateAndOpenBrowseTableLayout.Location = new System.Drawing.Point(10, 25);
            this.FormCaseCreateAndOpenBrowseTableLayout.Margin = new System.Windows.Forms.Padding(10, 0, 8, 3);
            this.FormCaseCreateAndOpenBrowseTableLayout.Name = "FormCaseCreateAndOpenBrowseTableLayout";
            this.FormCaseCreateAndOpenBrowseTableLayout.RowCount = 1;
            this.FormCaseCreateAndOpenBrowseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormCaseCreateAndOpenBrowseTableLayout.Size = new System.Drawing.Size(466, 36);
            this.FormCaseCreateAndOpenBrowseTableLayout.TabIndex = 9;
            // 
            // FormCaseCreateAndOpenBottomButtonsTableLayout
            // 
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.ColumnCount = 3;
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Controls.Add(this.buttonBack, 0, 0);
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Controls.Add(this.buttonNext, 1, 0);
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Controls.Add(this.buttonCancel, 2, 0);
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Dock = System.Windows.Forms.DockStyle.Right;
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Location = new System.Drawing.Point(232, 67);
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Name = "FormCaseCreateAndOpenBottomButtonsTableLayout";
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.RowCount = 1;
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.Size = new System.Drawing.Size(242, 42);
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.TabIndex = 10;
            // 
            // FormCaseCreateAndOpenTableLayout
            // 
            this.FormCaseCreateAndOpenTableLayout.ColumnCount = 1;
            this.FormCaseCreateAndOpenTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormCaseCreateAndOpenTableLayout.Controls.Add(this.FormCaseCreateAndOpenBottomButtonsTableLayout, 0, 2);
            this.FormCaseCreateAndOpenTableLayout.Controls.Add(this.labelTextDisplay, 0, 0);
            this.FormCaseCreateAndOpenTableLayout.Controls.Add(this.FormCaseCreateAndOpenBrowseTableLayout, 0, 1);
            this.FormCaseCreateAndOpenTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormCaseCreateAndOpenTableLayout.Location = new System.Drawing.Point(0, 0);
            this.FormCaseCreateAndOpenTableLayout.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.FormCaseCreateAndOpenTableLayout.Name = "FormCaseCreateAndOpenTableLayout";
            this.FormCaseCreateAndOpenTableLayout.RowCount = 3;
            this.FormCaseCreateAndOpenTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FormCaseCreateAndOpenTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.FormCaseCreateAndOpenTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.FormCaseCreateAndOpenTableLayout.Size = new System.Drawing.Size(484, 112);
            this.FormCaseCreateAndOpenTableLayout.TabIndex = 11;
            this.FormCaseCreateAndOpenTableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.FormCaseCreateAndOpenTableLayout_Paint);
            // 
            // FormCaseCreateAndOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 112);
            this.Controls.Add(this.FormCaseCreateAndOpenTableLayout);
            this.MaximumSize = new System.Drawing.Size(500, 150);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "FormCaseCreateAndOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Generator";
            this.FormCaseCreateAndOpenBrowseTableLayout.ResumeLayout(false);
            this.FormCaseCreateAndOpenBrowseTableLayout.PerformLayout();
            this.FormCaseCreateAndOpenBottomButtonsTableLayout.ResumeLayout(false);
            this.FormCaseCreateAndOpenTableLayout.ResumeLayout(false);
            this.FormCaseCreateAndOpenTableLayout.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.TextBox textBoxBrowse;
		private System.Windows.Forms.Label labelTextDisplay;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TableLayoutPanel FormCaseCreateAndOpenBrowseTableLayout;
		private System.Windows.Forms.TableLayoutPanel FormCaseCreateAndOpenBottomButtonsTableLayout;
		private System.Windows.Forms.TableLayoutPanel FormCaseCreateAndOpenTableLayout;

	}
}