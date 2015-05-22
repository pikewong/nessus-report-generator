using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportGenerator
{
    public partial class FormInputProjectNameAndRemark : Form
    {
        public FormInputProjectNameAndRemark()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Program.state.ProjectName = TextBoxProjectName.Text;
            Program.state.Remark = TextBoxRemark.Text;
            this.Hide();
            new FormCaseCreateAndOpen().ShowDialog();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormStart().ShowDialog();
            this.Close();
        }
    }
}
