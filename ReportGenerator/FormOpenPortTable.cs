using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportGenerator.Record;

namespace ReportGenerator
{
    public partial class FormOpenPortTable : Form
    {
        public FormOpenPortTable()
        {
            InitializeComponent();
            dataGridViewOpenPortTable.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceOpenPortTable();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            List<DataEntry> entryList = new List<DataEntry>();
            int counter = 0;
            String description = "";
            foreach (DataGridViewRow row in dataGridViewOpenPortTable.Rows)
            {
               
                counter++;
                String ip = row.Cells[0].Value.ToString();
                String protocol = row.Cells[1].Value.ToString();
                String port = row.Cells[5].Value.ToString();


                if (!String.IsNullOrEmpty(port))
                    description += port.Replace(" ", "/" + protocol + ", ") + "/" + protocol + ", ";
                if (counter == 3)
                {
                    if (!String.IsNullOrEmpty(description))
                        description = description.Substring(0, description.Length - 2);
                    GuiDataEntry entry = new GuiDataEntry("Open Port Findings",
                                                ip,
                                                description, "",
                                                RiskFactor.OPEN, "", null, null, null, "", DataEntry.EntryType.NMAP,null,null);
                    entryList.Add(entry);
                    counter = 0;
                    description = "";

                }
            }

            Program.state.panelRecordEdit_recordDatabaser.insertOpenPortToDatabase(entryList);
            this.Close();
        }
    }
}
