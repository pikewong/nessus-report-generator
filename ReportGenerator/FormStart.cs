using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportGenerator {

	/// <summary>
	/// This is the FormStart Class extends Form.
	/// This form is shown on Report Generator start.
	/// </summary>
	public partial class FormStart : Form {

		/// <summary>
		/// This is the constructor of FormStart.
		/// </summary>
		public FormStart() {
			InitializeComponent();
			Program.state.initialize();
            this.TopMost = true;
		}

		/// <summary>
		/// This is the buttonCreateCase_Click method.
		/// This method handles click event on button buttonCreateCase.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCreateCase_Click(object sender, EventArgs e) {
			this.Hide();
			Program.state.formStartState = State.FormStartState.CREATE;
			//new FormCaseCreateAndOpen().ShowDialog();
            new FormInputProjectNameAndRemark().ShowDialog();
            this.Close();
		}

		/// <summary>
		/// This is the buttonOpenCase_Click method.
		/// This method handles click event on button buttonOpenCase.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOpenCase_Click(object sender, EventArgs e) {
			this.Hide();
			Program.state.formStartState = State.FormStartState.OPEN;
			new FormCaseCreateAndOpen().ShowDialog();
			this.Close();
		}

		/// <summary>
		/// This is the buttonExit_Click method.
		/// This method handles click event on button buttonExit.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonExit_Click(object sender, EventArgs e) {
			this.Close();
		}

        private void FormStartTableLayout_Paint(object sender, PaintEventArgs e)
        {

        }
	}
}
