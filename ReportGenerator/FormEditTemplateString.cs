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
	/// This is the FormEditTemplateString Class extends Form.
	/// It is used to let user edit the replaced string from template string.
	/// </summary>
	public partial class FormEditTemplateString : Form {

		/// <summary>
		/// This is the constructor of FormEditTemplateString.
		/// </summary>
		/// <param name="originalString">the string not yet replace, display to this form</param>
		/// <param name="replacedString">the string that need replace to, display to this form for edit</param>
		public FormEditTemplateString(String originalString, String replacedString) {

			InitializeComponent();

			richTextBoxOld.Text = originalString;
			richTextBoxNew.Text = replacedString;
            this.TopMost = true;
		}

		/// <summary>
		/// This is the buttonOk_Click method.
		/// It is used to handle the click event on button buttonOk.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOk_Click(object sender, EventArgs e) {
			Program.state.formEditTemplateStringState = State.FormEditTemplateStringState.OK;
			Program.state.formEditTemplateString_stringText = richTextBoxNew.Text;
			this.Close();
		}

		/// <summary>
		/// This is the buttonCancel_Click method.
		/// It is used to handle the click event on button buttonCancel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCancel_Click(object sender, EventArgs e) {
			Program.state.formEditTemplateStringState = State.FormEditTemplateStringState.CANCEL;
			Program.state.formEditTemplateString_stringText = "";
			this.Close();
		}
	}
}
