using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ReportGenerator {
	public partial class Form2 : Form {

		public Form2() {
			InitializeComponent();
			switch (Program.state.form1State) {
				case State.Form1State.CREATE:
					label1.Text = "Select the file destination to store the case:";
					break;
				case State.Form1State.OPEN:
					label1.Text = "Select the file to load the case:";
					break;
			}
			textBox1.Text = Program.state.form2Path;
		}

		private void back_Click(object sender, EventArgs e) {
			this.Hide();
			new Form1().ShowDialog();
			this.Close();
		}

		private void next_Click(object sender, EventArgs e) {
			this.Hide();
			Program.state.form2Path = textBox1.Text;
			new Form3().ShowDialog();
			this.Close();
		}

		private void cancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void browse_Click(object sender, EventArgs e) {
			switch (Program.state.form1State){
				case State.Form1State.CREATE:
					folderBrowserDialog.ShowDialog();
					textBox1.Text = folderBrowserDialog.SelectedPath;
					break;
				case State.Form1State.OPEN:
					openFileDialog.Filter = "Report Database|*.db";
					openFileDialog.ShowDialog();
					textBox1.Text = openFileDialog.FileName;
					break;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			if (textBox1.Text != "") {
				next.Enabled = true;
			}
			else {
				next.Enabled = false;
			}
		}
	}
}
