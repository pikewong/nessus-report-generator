using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReportGenerator
{
    public partial class FormChoosePermanentDatabasePath : Form
    {
        private enum Mode:int
        {
            LOAD = 0,
            CREATE = 1
        }

        private Mode mode =0;

        public FormChoosePermanentDatabasePath()
        {
            InitializeComponent();
            textBoxBrowse.Text = Program.state.amendmentDatabaserDefaultPath;
            this.TopMost = true;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (radioButtonCreate.Checked)
            {
                saveFileDialog.DefaultExt = "db";
                saveFileDialog.Filter = "Amendent Database (.db)|*.db";
                saveFileDialog.ShowDialog();
                textBoxBrowse.Text = saveFileDialog.FileName;
            }
            else if (radioButtonLoad.Checked)
            {
                openFileDialog.Filter = "Amendent Database (.db)|*.db";
                openFileDialog.ShowDialog();
                textBoxBrowse.Text = openFileDialog.FileName;
            }
            
        }

        private void radioButtonLoad_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBrowse.Text = Program.state.amendmentDatabaserDefaultPath;
            if (radioButtonLoad.Checked)
            {
                groupBox.Text = radioButtonLoad.Text;
                mode = Mode.LOAD;
            }
        }

        private void radioButtonCreate_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBrowse.Text = Program.state.amendmentDatabaserDefaultPath;
            if (radioButtonCreate.Checked)
            {
                groupBox.Text = radioButtonCreate.Text;
                mode = Mode.CREATE;
            }
        }

        private void textBoxBrowse_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBrowse.Text == "")
                buttonNext.Enabled = false;
            else
                buttonNext.Enabled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Program.state.amendmentDatabaserDefaultPath = textBoxBrowse.Text;
            if (mode == Mode.CREATE)              
			    if (File.Exists(Program.state.amendmentDatabaserDefaultPath))
				    File.Delete(Program.state.amendmentDatabaserDefaultPath);
            

           Program.state.amendmentDatabaser = new Database.PermanentDatabaser(Program.state.amendmentDatabaserDefaultPath);

            this.Close();
        }


    }
}
