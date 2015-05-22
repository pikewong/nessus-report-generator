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
	/// This is the FormMessage Class extends Form.
	/// This Form is used to display the progress of creating/saving
	/// databse/config file.
	/// </summary>
	public partial class FormMessage : Form {

		/// <summary>
		/// This is the constructor of FormMessage.
		/// </summary>
		/// <param name="text">text on top controlBox and labelMessage</param>
		public FormMessage(String text) {
			InitializeComponent();
			this.Text = text;
			this.labelMessage.Text = text;
            this.TopMost = true;
		}
	}
}
