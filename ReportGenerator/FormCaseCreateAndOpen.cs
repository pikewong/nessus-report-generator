using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ReportGenerator {

	/// <summary>
	/// This is the FormCaseCreateAndOpen Class extends Form.
	/// This form is shown after create case and open case.
	/// </summary>
	public partial class FormCaseCreateAndOpen : Form {

		/// <summary>
		/// This is the constructor of FormCaseCreateAndOpen.
		/// </summary>
		public FormCaseCreateAndOpen() {
			InitializeComponent();
			switch (Program.state.formStartState) {
				case State.FormStartState.CREATE:
					labelTextDisplay.Text = "Select the file destination to store the case:";
					break;
				case State.FormStartState.OPEN:
					labelTextDisplay.Text = "Select the file to load the case:";
					break;
			}
			textBoxBrowse.Text = Program.state.formCaseCreateAndOpenPath;
            this.TopMost = true;
		}

		/// <summary>
		/// This is the buttonBack_Click method.
		/// It is used to handle the click event of button buttonBack.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonBack_Click(object sender, EventArgs e) {
			this.Hide();
            if (Program.state.formStartState == State.FormStartState.CREATE)
                new FormInputProjectNameAndRemark().ShowDialog();
            else
                new FormStart().ShowDialog();
			
            this.Close();
		}

		/// <summary>
		/// This is the buttonNext_Click method.
		/// It is used to handle the click event of button buttonNext.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonNext_Click(object sender, EventArgs e) {
			this.Hide();
			Program.state.formCaseCreateAndOpenPath = textBoxBrowse.Text;
			new FormMain().ShowDialog();
			this.Close();
		}

		/// <summary>
		/// This is the buttonCancel_Click method.
		/// It is used to handle the click event of button buttonCancel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// This is the browse_Click method.
		/// It is used to handle the click event on both button buttonBrowse
		/// and textBoxBrowse.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void browse_Click(object sender, EventArgs e) {
			switch (Program.state.formStartState){
				case State.FormStartState.CREATE:
                    /*
                    System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
					folderBrowserDialog.ShowDialog();
					textBoxBrowse.Text = folderBrowserDialog.SelectedPath;
                     */
                    CommonOpenFileDialog folderOpenDialog = new CommonOpenFileDialog();
                    folderOpenDialog.IsFolderPicker = true;
                    folderOpenDialog.Multiselect = false;
                    if (folderOpenDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        textBoxBrowse.Text = folderOpenDialog.FileName;

                    }

					break;
				case State.FormStartState.OPEN:
					openFileDialog.Filter = "Report Database|*.db";
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        textBoxBrowse.Text = openFileDialog.FileName;
                    }
					break;
			}
		}

		/// <summary>
		/// This is the textBoxBrowse_TextChanged method.
		/// It is used to handle the text change event on textBox textBoxBrowse.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBoxBrowse_TextChanged(object sender, EventArgs e) {

			// nearly no validation here, may need to add some validation on the path
			if (Program.state.formStartState == State.FormStartState.OPEN) {
				if (File.Exists(textBoxBrowse.Text)) {
					buttonNext.Enabled = true;
				}
				else {
					buttonNext.Enabled = false;
				}
			}
			else {
				if (Directory.Exists(textBoxBrowse.Text)) {
					buttonNext.Enabled = true;
				}
				else {
					buttonNext.Enabled = false;
				}
			}
		}

        private void FormCaseCreateAndOpenTableLayout_Paint(object sender, PaintEventArgs e)
        {

        }
	}
}
