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
    public partial class FormRemoveDuplicate : Form
    {
        Dictionary<String, List<DataEntry>> duplicateRecord;
        // Create a new DataTable.
        DataTable table = new DataTable();
        List<DataEntry> tempEntryList;

        public FormRemoveDuplicate(Dictionary<String, List<DataEntry>> duplicateRecord)
        {
            InitializeComponent();
            this.duplicateRecord = duplicateRecord;
            createColumn();
            createNextKeyRow();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            dataGridViewRemoveDuplicate.DataSource = bindingSource;
            dataGridViewRemoveDuplicate.AutoResizeColumns();
            this.TopMost = true;
        }

        private void createColumn() {
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Microsoft ID";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Plugin Name";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Host Affected";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Description";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Impact";
            column.ReadOnly = true;
            column.Unique = false;

            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Risk Level";
            column.ReadOnly = true;
            column.Unique = false;

            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Recommendation";
            column.ReadOnly = true;
            column.Unique = false;

            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Reference (CVE)";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Reference (BID)";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Reference (OSVDB)";
            column.ReadOnly = true;
            column.Unique = false;

            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Reference Link";
            column.ReadOnly = true;
            column.Unique = false;

            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Entry Type";
            column.ReadOnly = true;
            column.Unique = false;

            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
        }

        private void createNextKeyRow()
        {
            table.Clear();

            DataRow row;
            String key = duplicateRecord.Keys.First();
            tempEntryList = new List<DataEntry>();
            foreach (DataEntry rawEntry in duplicateRecord[key])
            {
                    int dbid = Program.state.panelRecordEdit_recordDatabaser.getDBID(rawEntry);
                    if (dbid == -1)
                        //error
                        break;
                    DataEntry entry = Program.state.panelRecordEdit_recordDatabaser.getEntryFromDatabaseId(dbid);
                    row = table.NewRow();
                    String MicrosoftID = key.Substring(0, key.IndexOf('@'));
                    row["Microsoft ID"] = MicrosoftID;
                    row["Plugin Name"] = entry.getPluginName();
                    row["Host Affected"] = entry.getIp();
                    row["Description"] = entry.getDescription();
                    row["Impact"] = entry.getImpact();
                    row["Risk Level"] = RiskFactorFunction.getEnumString(entry.getRiskFactor());
                    row["Recommendation"] = entry.getRecommendation();

                    row["Reference (CVE)"] = entry.getCve();
                    row["Reference (BID)"] = entry.getBid();
                    row["Reference (OSVDB)"] = entry.getOsvdb();

                    row["Reference Link"] = entry.getReferenceLink();
                    row["Entry Type"] = entry.getEntryTypeString();
                    table.Rows.Add(row);
                    tempEntryList.Add(entry);
            }
            duplicateRecord.Remove(key);
      
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //remove and merge
            this.Enabled = false;
            new FormEditFinding(null, tempEntryList).ShowDialog();
            this.Enabled = true;

            if (Program.state.formEditFindingState == State.FormEditFindingState.OK)
            {
                DataEntry firstEntry = tempEntryList.First();
                int firstDBID = Program.state.panelRecordEdit_recordDatabaser.getDBID(firstEntry);
                //@@@@@Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateRecordToDatabase(Program.state.formEditFindingEntry, firstDBID);
                 Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateNessusFindingToDatabase(Program.state.formEditFindingEntry, firstDBID);
                tempEntryList.RemoveAt(0);

                int counting_for_FindingDetail = 0;

                foreach (DataEntry entry in tempEntryList)
                {
                    int dbid = Program.state.panelRecordEdit_recordDatabaser.getDBID(entry);
                    //@@@@@Program.state.panelRecordEdit_recordDatabaser.deleteEditedRecordEntry(dbid);
                    Program.state.panelRecordEdit_recordDatabaser.guideleteNessusFindingEntry(dbid);
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdateMergeFindingDetailToDatabase(firstDBID, dbid, counting_for_FindingDetail);
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdateMergeFindingReferenceToDatabase(firstDBID, dbid, counting_for_FindingDetail);
                    
                    counting_for_FindingDetail++;
                }

                Program.state.formEditFindingState = State.FormEditFindingState.NULL;
            }
            else
            {
                Program.state.formEditFindingState = State.FormEditFindingState.NULL;
                return;
            }


            if (duplicateRecord.Count > 0)
                createNextKeyRow();
            else
                this.Close();


        }

        private void buttonNotRemove_Click(object sender, EventArgs e)
        {
            if (duplicateRecord.Count > 0)
                createNextKeyRow();
            else
                this.Close();
        }
    }
}
