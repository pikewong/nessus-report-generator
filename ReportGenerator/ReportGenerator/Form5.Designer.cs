namespace ReportGenerator {
	partial class Form5 {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewOld = new System.Windows.Forms.DataGridView();
			this.editColumnOld = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cancel = new System.Windows.Forms.Button();
			this.ok = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dataNew_richTextBox = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.dataGridViewOld.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewOld.Name = "dataGridViewOld";
			this.dataGridViewOld.ReadOnly = true;
			this.dataGridViewOld.RowHeadersVisible = false;
			this.dataGridViewOld.Size = new System.Drawing.Size(854, 207);
			this.dataGridViewOld.TabIndex = 1;
			// 
			// editColumnOld
			// 
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.editColumnOld.DefaultCellStyle = dataGridViewCellStyle5;
			this.editColumnOld.FillWeight = 850F;
			this.editColumnOld.HeaderText = "";
			this.editColumnOld.Name = "editColumnOld";
			this.editColumnOld.ReadOnly = true;
			this.editColumnOld.Width = 850;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridViewOld);
			this.groupBox1.Location = new System.Drawing.Point(12, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(860, 226);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Field";
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(797, 377);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 8;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(716, 377);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 23);
			this.ok.TabIndex = 7;
			this.ok.Text = "OK";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dataNew_richTextBox);
			this.groupBox2.Location = new System.Drawing.Point(12, 236);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(860, 135);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "New Field Data";
			// 
			// dataNew_richTextBox
			// 
			this.dataNew_richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataNew_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataNew_richTextBox.Location = new System.Drawing.Point(3, 16);
			this.dataNew_richTextBox.Name = "dataNew_richTextBox";
			this.dataNew_richTextBox.Size = new System.Drawing.Size(854, 116);
			this.dataNew_richTextBox.TabIndex = 0;
			this.dataNew_richTextBox.Text = "";
			// 
			// Form5
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 412);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.groupBox2);
			this.MaximumSize = new System.Drawing.Size(900, 450);
			this.MinimumSize = new System.Drawing.Size(900, 450);
			this.Name = "Form5";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Report Generator";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOld)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewOld;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridViewTextBoxColumn editColumnOld;
		private System.Windows.Forms.RichTextBox dataNew_richTextBox;

	}
}