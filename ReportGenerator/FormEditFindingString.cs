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
	/// This is the FormEditFindingString Class extends Form.
	/// It is used to let user to edit the string from a finding.
	/// </summary>
	public partial class FormEditFindingString : Form {

		// Variables
		private String[] headerText = { "Plugin Name", 
										"Host Affected",
										"Description",
										"Impact",
										"Risk Level",
										"Recommendations",
										"Reference (CVE)",
										"Reference (BID)",
										"Reference (OSVDB)",
									    "Reference Link"};

        /// <summary>
        /// This is the enum ColumnIndex
        /// It is used to determine the index of column of dataGridView
        /// </summary>
        private enum ColumnIndex : int
        {
            PLUGINNAME = 0,
            IPLIST = 1,
            DESCRIPTION = 2,
            IMPACT = 3,
            RISKFACTOR = 4,
            RECOMMENDATION = 5,
            CVE = 6,
            BID = 7,
            OSVDB = 8,
            REFERENCELINK = 9,
            ENTRYTYPE = 10,
            MAX = 11
        }
		/// <summary>
		/// This is the constructor of FormEditFindingString.
		/// </summary>
		/// <param name="n">index to determine which column to display out</param>
		/// <param name="dataArray">data display on this form</param>
		public FormEditFindingString(int n, List<String> dataArray, String newText = null) {
			InitializeComponent(); 
			
			this.editColumnOld = new System.Windows.Forms.DataGridViewTextBoxColumn();

			dataGridViewOld.Columns[0].HeaderText = headerText[n];//dataGridViewNew.Columns[0].HeaderText = headerText[n];
            //description / recommendation
            if (n == (int)ColumnIndex.DESCRIPTION || n == (int)ColumnIndex.RECOMMENDATION || n == (int)ColumnIndex.REFERENCELINK)
                buttonApplyToAll.Show();
            else
                buttonApplyToAll.Hide();

			int no;
			foreach (String s in dataArray) {
				no = dataGridViewOld.Rows.Add();
				dataGridViewOld.Rows[no].Cells[0].Value = s;
			}
            if (newText == null)
                FormEditFindingString_richTextBox.Text = dataArray[0];
            else
                FormEditFindingString_richTextBox.Text = newText;
            this.TopMost = true;
            this.TopMost = false;
		}

		/// <summary>
		/// This is the buttonOk_Click event.
		/// It is used to handle the click event of button buttonOk.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOk_Click(object sender, EventArgs e) {
			Program.state.formEditFindingString_stringText = FormEditFindingString_richTextBox.Text;
			Program.state.formEditFindingStringState = State.FormEditFindingStringState.OK;
			this.Close();
		}

		/// <summary>
		/// This is the buttonCancel_Click event.
		/// It is used to handle the click event of button buttonCancel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCancel_Click(object sender, EventArgs e) {
			Program.state.formEditFindingStringState = State.FormEditFindingStringState.CANCEL;
			this.Close();
		}

		/// <summary>
		/// This is the dataGridViewOld_CellClick event.
		/// It is used to handle the cell click event on cell in DataGridView
		/// dataGridViewOld.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        //private void dataGridViewOld_CellClick(object sender, DataGridViewCellEventArgs e) {
        //    if (e.RowIndex != -1) {
        //        String temp = dataGridViewOld.Rows[e.RowIndex].Cells[0].Value.ToString();
        //        if (!FormEditFindingString_richTextBox.Text.Contains(temp))
        //            FormEditFindingString_richTextBox.Text += '\n' + temp;
        //    }
        //}

        private void buttonApplyToAll_Click(object sender, EventArgs e)
        {

            Program.state.formEditFindingString_stringText = FormEditFindingString_richTextBox.Text;
            Program.state.formEditFindingStringState = State.FormEditFindingStringState.APPLYTOALL;
            this.Close();
        }

        private void buttonAddSelected_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewOld.Rows)
                if (row.Cells[0].Selected)
                {
                    String temp =row.Cells[0].Value.ToString();
                    if (FormEditFindingString_richTextBox.Text == "")
                        FormEditFindingString_richTextBox.Text = temp;
                    else
                        FormEditFindingString_richTextBox.Text += '\n' + temp;
                }
        }

	}
}
