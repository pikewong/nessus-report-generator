namespace ReportGenerator
{
    partial class FormChoosePermanentDatabasePath
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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.radioButtonLoad = new System.Windows.Forms.RadioButton();
            this.radioButtonCreate = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBrowse = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonLoad
            // 
            this.radioButtonLoad.AutoSize = true;
            this.radioButtonLoad.Location = new System.Drawing.Point(194, 13);
            this.radioButtonLoad.Name = "radioButtonLoad";
            this.radioButtonLoad.Size = new System.Drawing.Size(49, 17);
            this.radioButtonLoad.TabIndex = 0;
            this.radioButtonLoad.TabStop = true;
            this.radioButtonLoad.Text = "Load";
            this.radioButtonLoad.UseVisualStyleBackColor = true;
            this.radioButtonLoad.CheckedChanged += new System.EventHandler(this.radioButtonLoad_CheckedChanged);
            // 
            // radioButtonCreate
            // 
            this.radioButtonCreate.AutoSize = true;
            this.radioButtonCreate.Location = new System.Drawing.Point(305, 13);
            this.radioButtonCreate.Name = "radioButtonCreate";
            this.radioButtonCreate.Size = new System.Drawing.Size(56, 17);
            this.radioButtonCreate.TabIndex = 1;
            this.radioButtonCreate.TabStop = true;
            this.radioButtonCreate.Text = "Create";
            this.radioButtonCreate.UseVisualStyleBackColor = true;
            this.radioButtonCreate.CheckedChanged += new System.EventHandler(this.radioButtonCreate_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.textBoxBrowse);
            this.groupBox.Controls.Add(this.buttonBrowse);
            this.groupBox.Location = new System.Drawing.Point(12, 52);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(576, 131);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Load";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the destination of permanent amendent database : ";
            // 
            // textBoxBrowse
            // 
            this.textBoxBrowse.Location = new System.Drawing.Point(39, 73);
            this.textBoxBrowse.Name = "textBoxBrowse";
            this.textBoxBrowse.ReadOnly = true;
            this.textBoxBrowse.Size = new System.Drawing.Size(377, 20);
            this.textBoxBrowse.TabIndex = 1;
            this.textBoxBrowse.TextChanged += new System.EventHandler(this.textBoxBrowse_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(449, 73);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(496, 209);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 25);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "OK";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // FormChoosePermanentDatabasePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 247);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.radioButtonCreate);
            this.Controls.Add(this.radioButtonLoad);
            this.Name = "FormChoosePermanentDatabasePath";
            this.Text = "FormChoosePermanentDatabasePath";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RadioButton radioButtonLoad;
        private System.Windows.Forms.RadioButton radioButtonCreate;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxBrowse;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label1;
    }
}