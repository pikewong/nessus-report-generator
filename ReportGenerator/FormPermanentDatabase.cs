using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportGenerator.Record;
using ReportGenerator.Database;

namespace ReportGenerator
{
    public partial class FormPermanentDatabase : Form
    {
        private enum CellColumnIndex : int
        {
            ID = 0,
            ENTRYTYPE = 1,
            ORIGIANALDESCRIPTION = 2,
            EDITEDDESCRIPTION = 3,
            ORIGIANALRECOMMENDATION = 4,
            EDITEDRECOMMENDATION = 5,
            ORIGIANALREFERENCELINK = 6,
            EDITEDREFERENCELINK = 7
        }

        public FormPermanentDatabase()
        {
            InitializeComponent();
            if (Program.state.amendmentDatabaser == null)
                Program.state.amendmentDatabaser = new PermanentDatabaser();  
            //dataGridViewPermanentDatabase
            dataGridViewPermanentDatabase.DataSource = Program.state.amendmentDatabaser.getBindingSource();
            this.TopMost = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Program.state.amendmentDatabaser.deleteAllRows();
            Amendment tempAmendent;
            int lastIndex = dataGridViewPermanentDatabase.Rows.Count - 1;
            foreach (DataGridViewRow row in dataGridViewPermanentDatabase.Rows)
            {
                string origialDescription, origialRecommendation, editDescription, editRecommendation, originalReferenceLink, editReferenceLink;
                if (row.Index == lastIndex)
                    break;
                if (row.Cells[(int)CellColumnIndex.ORIGIANALDESCRIPTION].Value == null)
                    origialDescription = null;
                else
                    origialDescription = row.Cells[(int)CellColumnIndex.ORIGIANALDESCRIPTION].Value.ToString();
                if (row.Cells[(int)CellColumnIndex.EDITEDDESCRIPTION].Value == null)
                    editDescription = null;
                else
                    editDescription = row.Cells[(int)CellColumnIndex.EDITEDDESCRIPTION].Value.ToString();
                if (row.Cells[(int)CellColumnIndex.ORIGIANALRECOMMENDATION].Value == null)
                    origialRecommendation = null;
                else
                    origialRecommendation = row.Cells[(int)CellColumnIndex.ORIGIANALRECOMMENDATION].Value.ToString();
                if (row.Cells[(int)CellColumnIndex.EDITEDRECOMMENDATION].Value == null)
                    editRecommendation = null;
                else
                    editRecommendation = row.Cells[(int)CellColumnIndex.EDITEDRECOMMENDATION].Value.ToString();
                if (row.Cells[(int)CellColumnIndex.ORIGIANALREFERENCELINK].Value == null)
                    originalReferenceLink = null;
                else
                    originalReferenceLink = row.Cells[(int)CellColumnIndex.ORIGIANALREFERENCELINK].Value.ToString();
                if (row.Cells[(int)CellColumnIndex.EDITEDREFERENCELINK].Value == null)
                    editReferenceLink = null;
                else
                    editReferenceLink = row.Cells[(int)CellColumnIndex.EDITEDREFERENCELINK].Value.ToString();
                tempAmendent = new Amendment(row.Cells[(int)CellColumnIndex.ID].Value.ToString(),
                                                       row.Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString(),
                                                       origialDescription,
                                                       editDescription,
                                                       origialRecommendation,
                                                       editRecommendation,
                                                       originalReferenceLink,
                                                       editReferenceLink);
                Program.state.amendmentDatabaser.storeAmendment(tempAmendent);
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dataGridViewPermanentDatabase_RowLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewRow row = dataGridViewPermanentDatabase.Rows[e.RowIndex];
        //    for (int i = 0; i < dataGridViewPermanentDatabase.RowCount; i++)
        //        if (row.Cells[e.ColumnIndex].Value == null)
        //            row.Cells[e.ColumnIndex].Value = "";
        //}

        //private void dataGridViewPermanentDatabase_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    DataGridViewRow row = dataGridViewPermanentDatabase.Rows[e.RowIndex];
        //    for (int i = 0; i < dataGridViewPermanentDatabase.RowCount; i++)
        //        if (row.Cells[e.ColumnIndex].Value == null)
        //            row.Cells[e.ColumnIndex].Value = "";
        //}

        private void dataGridViewPermanentDatabase_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

            for (int i = 0; i < dataGridViewPermanentDatabase.ColumnCount; i++)
            {
                e.Row.Cells[i].Value = "";
            }
        }

        //private void dataGridViewPermanentDatabase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ||
        //        dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
        //        dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = " ";
        //}

        //private void dataGridViewPermanentDatabase_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void dataGridViewPermanentDatabase_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    e.Cancel = true;
        //    if (dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ||
        //        dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
        //        dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //}

        //private void dataGridViewPermanentDatabase_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ||
        //        dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
        //        dataGridViewPermanentDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //}


    }
}
