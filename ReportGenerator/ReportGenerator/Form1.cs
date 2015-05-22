using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportGenerator {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			Program.state.initialize();
		}

		private void button1_Click(object sender, EventArgs e) {
			this.Hide();
			Program.state.form1State = State.Form1State.CREATE;
			new Form2().ShowDialog();
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e) {
			this.Hide();
			Program.state.form1State = State.Form1State.OPEN;
			new Form2().ShowDialog();
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
