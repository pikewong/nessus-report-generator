using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportGenerator {
	public partial class Form5 : Form {

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

		public Form5(int n, List<String> dataArray) {
			InitializeComponent();
			
			//this.editColumnNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.editColumnOld = new System.Windows.Forms.DataGridViewTextBoxColumn();

			dataGridViewOld.Columns[0].HeaderText = headerText[n];//dataGridViewNew.Columns[0].HeaderText = headerText[n];

			int no;
			foreach (String s in dataArray) {
				no = dataGridViewOld.Rows.Add();
				dataGridViewOld.Rows[no].Cells[0].Value = s;
				//changeString(s);
			}

			//int no2 = dataGridViewNew.Rows.Add();
			//dataGridViewNew.Rows[no2].Cells[0].Value = dataGridViewOld.Rows[0].Cells[0].Value;
			dataNew_richTextBox.Text = dataArray[0];//dataGridViewOld.Rows[0].Cells[0].Value.ToString();
		}

		private void ok_Click(object sender, EventArgs e) {
			Program.state.form5Data = changeBack(dataNew_richTextBox.Text);//dataGridViewNew.Rows[0].Cells[0].Value.ToString());
			Program.state.form5State = State.Form5State.OK;
			this.Close();
		}

		private void cancel_Click(object sender, EventArgs e) {
			Program.state.form5State = State.Form5State.CANCEL;
			this.Close();
		}

		private String changeString(String s) {
			return s.Replace("\r\n", "\\n").Replace("\r", "").Replace("\n", "\\n");
		}

		private String changeBack(String s) {
			return s.Replace("\\n", "\n");
		}
	}
}
