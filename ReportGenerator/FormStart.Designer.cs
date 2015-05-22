namespace ReportGenerator {
	partial class FormStart {
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
            this.buttonCreateCase = new System.Windows.Forms.Button();
            this.buttonOpenCase = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.FormStartTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FormStartTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateCase
            // 
            this.buttonCreateCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateCase.Location = new System.Drawing.Point(10, 10);
            this.buttonCreateCase.Margin = new System.Windows.Forms.Padding(10, 10, 10, 3);
            this.buttonCreateCase.Name = "buttonCreateCase";
            this.buttonCreateCase.Size = new System.Drawing.Size(264, 79);
            this.buttonCreateCase.TabIndex = 0;
            this.buttonCreateCase.Text = "Create New Case";
            this.buttonCreateCase.UseVisualStyleBackColor = true;
            this.buttonCreateCase.Click += new System.EventHandler(this.buttonCreateCase_Click);
            // 
            // buttonOpenCase
            // 
            this.buttonOpenCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenCase.Location = new System.Drawing.Point(10, 92);
            this.buttonOpenCase.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.buttonOpenCase.Name = "buttonOpenCase";
            this.buttonOpenCase.Size = new System.Drawing.Size(264, 76);
            this.buttonOpenCase.TabIndex = 1;
            this.buttonOpenCase.Text = "Open Case";
            this.buttonOpenCase.UseVisualStyleBackColor = true;
            this.buttonOpenCase.Click += new System.EventHandler(this.buttonOpenCase_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(10, 171);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(264, 81);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormStartTableLayout
            // 
            this.FormStartTableLayout.ColumnCount = 1;
            this.FormStartTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormStartTableLayout.Controls.Add(this.buttonCreateCase, 0, 0);
            this.FormStartTableLayout.Controls.Add(this.buttonExit, 0, 2);
            this.FormStartTableLayout.Controls.Add(this.buttonOpenCase, 0, 1);
            this.FormStartTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormStartTableLayout.Location = new System.Drawing.Point(0, 0);
            this.FormStartTableLayout.Name = "FormStartTableLayout";
            this.FormStartTableLayout.RowCount = 3;
            this.FormStartTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.33353F));
            this.FormStartTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.33293F));
            this.FormStartTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.33353F));
            this.FormStartTableLayout.Size = new System.Drawing.Size(284, 262);
            this.FormStartTableLayout.TabIndex = 3;
            this.FormStartTableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.FormStartTableLayout_Paint);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.FormStartTableLayout);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportGenerator";
            this.FormStartTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCreateCase;
		private System.Windows.Forms.Button buttonOpenCase;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.TableLayoutPanel FormStartTableLayout;

	}
}
