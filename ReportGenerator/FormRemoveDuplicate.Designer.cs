namespace ReportGenerator
{
    partial class FormRemoveDuplicate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewRemoveDuplicate = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonNotRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemoveDuplicate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRemoveDuplicate
            // 
            this.dataGridViewRemoveDuplicate.AllowUserToAddRows = false;
            this.dataGridViewRemoveDuplicate.AllowUserToDeleteRows = false;
            this.dataGridViewRemoveDuplicate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRemoveDuplicate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRemoveDuplicate.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRemoveDuplicate.Name = "dataGridViewRemoveDuplicate";
            this.dataGridViewRemoveDuplicate.ReadOnly = true;
            this.dataGridViewRemoveDuplicate.RowTemplate.Height = 24;
            this.dataGridViewRemoveDuplicate.Size = new System.Drawing.Size(640, 327);
            this.dataGridViewRemoveDuplicate.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewRemoveDuplicate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.53488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.46512F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 373);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.19355F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.80645F));
            this.tableLayoutPanel2.Controls.Add(this.buttonRemove, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonNotRemove, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(483, 336);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(160, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRemove.Location = new System.Drawing.Point(3, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(72, 28);
            this.buttonRemove.TabIndex = 0;
            this.buttonRemove.Text = "Merge";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonNotRemove
            // 
            this.buttonNotRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonNotRemove.Location = new System.Drawing.Point(82, 3);
            this.buttonNotRemove.Name = "buttonNotRemove";
            this.buttonNotRemove.Size = new System.Drawing.Size(75, 28);
            this.buttonNotRemove.TabIndex = 1;
            this.buttonNotRemove.Text = "Not Merge";
            this.buttonNotRemove.UseVisualStyleBackColor = true;
            this.buttonNotRemove.Click += new System.EventHandler(this.buttonNotRemove_Click);
            // 
            // FormRemoveDuplicate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 373);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRemoveDuplicate";
            this.Text = "FormRemoveDuplicate";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemoveDuplicate)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRemoveDuplicate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonNotRemove;
    }
}