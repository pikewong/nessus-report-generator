using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ReportGenerator
{
    public partial class IPHostTable : Form
    {
        private enum CellColumnIndex : int
        {
            IP = 0,
            HOSTNAME = 1
        }

        public IPHostTable()
        {
            InitializeComponent();
            Record.Record record  =Program.state.panelRecordEdit_record;
            labelNumRisk.Text = "Number of risks: High " + record.getHighRisk().Count() +
                                            " Medium " + record.getMediumRisk().Count() +
                                            " Low " + record.getLowRisk().Count() +
                                            " None " + record.getNoneRisk().Count() +
                                            " Open " + record.getOpenPort().Count();
            //dataGridViewIPHostTable.Sort(new Sort());
            dataGridViewIPHostTable.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceIPHostTable();

            this.TopMost = true;
            this.TopMost = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> ipHostName = new Dictionary<String, String>();
            foreach (DataGridViewRow row in dataGridViewIPHostTable.Rows)
            { 
                String key = row.Cells[(int)CellColumnIndex.IP].Value.ToString();
                String value = row.Cells[(int)CellColumnIndex.HOSTNAME].Value.ToString();
                if (key!= null)
                    ipHostName[key] = value == null ? "" : value;
            }
            Program.state.panelRecordEdit_recordDatabaser.updateIPHostTable(ipHostName);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewIPHostTable_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            for (int i = 0; i < dataGridViewIPHostTable.ColumnCount; i++)
            {
                e.Row.Cells[i].Value = "";
            }
        }

    //    private void dataGridViewIPHostTable_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    //    {
    //        if (e.Column.Name == "ip")
    //        {
    //            string tempString1 = e.CellValue1.ToString();
    //            string tempString2 = e.CellValue2.ToString();

    //            while (tempString1 != null && tempString2 != null)
    //            {
    //                int cell1 =0;
    //                int cell2 = 0;
    //                if (tempString1.Contains('.'))
    //                {
    //                    cell1 = int.Parse(tempString1.Substring(0, tempString1.IndexOf('.')));
    //                    tempString1 = tempString1.Substring(tempString1.IndexOf('.')+1);
    //                }
    //                else
    //                {
    //                    cell1 = int.Parse(tempString1);
    //                    tempString1 = null;
    //                }

    //                if (tempString2.Contains('.'))
    //                {
    //                    cell2 = int.Parse(tempString2.Substring(0, tempString2.IndexOf('.')));
    //                    tempString2 = tempString2.Substring(tempString2.IndexOf('.') + 1);
    //                }
    //                else
    //                {
    //                    cell2 = int.Parse(tempString2);
    //                    tempString2 = null;
    //                }


    //                if (cell1 > cell2)
    //                {
    //                    e.SortResult = 1;
    //                    e.Handled = true;
    //                    return;
    //                }
    //                else if (cell1 < cell2)
    //                {
    //                    e.SortResult = -1;
    //                    e.Handled = true;
    //                    return;
    //                }


    //            }
    //            e.SortResult = 0;
    //            e.Handled = true;
    //            return;

    //        }
    //        else
    //        {
    //            // Try to sort based on the cells in the current column.
    //            e.SortResult = System.String.Compare(
    //                e.CellValue1.ToString(), e.CellValue2.ToString());
    //            e.Handled = true;
    //        }
    //    }

    //}
    //class Sort : IComparer
    //{
    //    int IComparer.Compare(object x, object y)
    //    {
    //        return int.Parse((string)x).CompareTo(int.Parse((string)y));

    //    }
    }
}
