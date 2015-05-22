using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportGenerator.Record;

namespace ReportGenerator {

	/// <summary>
	/// This is the FormEditFinding Class extends Form.
	/// It is used to show the selected findings and the finding being updated/merged.
	/// </summary>
	public partial class FormEditFinding : Form {

		// Variables
		private List<int> indexArray = null;
		private int columnIndex = -1;

		/// <summary>
		/// This is the enum ColumnIndex
		/// It is used to determine the index of column of dataGridView
		/// </summary>
		private enum ColumnIndex : int {
			PLUGINNAME = 0,
			IPLIST = 1,
			DESCRIPTION = 2,
			IMPACT = 3,
			RISKFACTOR = 4,
			RECOMMENDATION = 5,
			CVE = 6,
			BID = 7,
			OSVDB = 8,
			REFERENCELINK = 9,
			ENTRYTYPE = 10,
			
            PLUGINVERSION = 11,
            PLUGINID=12,
            MAX = 13
		}

		/// <summary>
		/// This is the FormEditFinding method.
		/// It is used to display the current Form and fill the dataGridView with
		/// given data.
		/// </summary>
		/// <param name="indexArray">list of indexes that selected from the dataGridView on the previous form</param>
		/// <param name="dataArray">data to fill the dataGridView on this form</param>
		public FormEditFinding(List<int> indexArray, List<DataEntry> dataArray) {
            bool haveNessus = false;
            bool haveMBSA = false;
			this.indexArray = indexArray;
			InitializeComponent();
            //buttonApplyToAll.Hide();

            List<String> tempIPListNew = new List<String>();
            List<String> tempBidListNew = new List<String>();
            List<String> tempCveListNew = new List<String>();
            List<String> tempOsvdbListNew = new List<String>();
            List<String> tempReferenceLinkListNew = new List<String>();
			// fill cell values on dataGridView dataGridViewOld.
			foreach (DataEntry entry in dataArray) {
				int n = dataGridViewOld.Rows.Add();

				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.PLUGINNAME].Value = entry.getPluginName();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.IPLIST].Value = entry.getIp();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.DESCRIPTION].Value = entry.getDescription();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.IMPACT].Value = entry.getImpact();
				if (entry.getRiskFactor() == RiskFactor.OPEN) {
					dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.RISKFACTOR].Value = "OpenPort";
				}
				else {
					dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.RISKFACTOR].Value = RiskFactorFunction.getEnumString(entry.getRiskFactor());
				}
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.RECOMMENDATION].Value = entry.getRecommendation();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.CVE].Value = entry.getCve();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.BID].Value = entry.getBid();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.OSVDB].Value = entry.getOsvdb();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.REFERENCELINK].Value = entry.getReferenceLink();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.ENTRYTYPE].Value = entry.getEntryTypeString();
                dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.PLUGINVERSION].Value = entry.getpluginversion();
                dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.PLUGINID].Value = entry.getpluginID();

                //check whether it is NESSUS + MBSA
                if (entry.getEntryType() == DataEntry.EntryType.NESSUS)
                    haveNessus =true;
                else if (entry.getEntryType() == DataEntry.EntryType.MBSA)
                    haveMBSA = true;

                List<String> tempIpList = entry.getIpList();
                foreach (string ip in tempIpList)
                    if (!String.IsNullOrEmpty(ip) && !tempIPListNew.Contains(ip))
                        tempIPListNew.Add(ip);

                List<String> tempBidList = entry.getBidList();
                foreach (string bid in tempBidList)
                    if (!String.IsNullOrEmpty(bid) && !tempBidListNew.Contains(bid))
                        tempBidListNew.Add(bid);
                List<String> tempCveList = entry.getCveList();
                foreach (string cve in tempCveList)
                    if (!String.IsNullOrEmpty(cve) && !tempCveListNew.Contains(cve))
                        tempCveListNew.Add(cve);
                List<String> tempOsvdbList = entry.getOsvdbList();
                foreach (string osvdb in tempOsvdbList)
                    if (!String.IsNullOrEmpty(osvdb) && !tempOsvdbListNew.Contains(osvdb))
                        tempOsvdbListNew.Add(osvdb);
                String tempReferenceLink = entry.getReferenceLink();
                if (!String.IsNullOrEmpty(tempReferenceLink) && !tempReferenceLinkListNew.Contains(tempReferenceLink))
                    tempReferenceLinkListNew.Add(tempReferenceLink);
            }

            String ips = "";
			foreach (String ip in tempIPListNew) {
				ips += ip + ", ";
			}
			if (!String.IsNullOrEmpty(ips)) {
				ips = ips.Substring(0, ips.Length - 2);
			}

            String bids = "";
            foreach (String bid in tempBidListNew)
            {
                bids += bid + ", ";
            }
            if (!String.IsNullOrEmpty(bids))
            {
                bids = bids.Substring(0, bids.Length - 2);
            }

            String cves = "";
            foreach (String cve in tempCveListNew)
            {
                cves += cve + ", ";
            }
            if (!String.IsNullOrEmpty(cves))
            {
                cves = cves.Substring(0, cves.Length - 2);
            }

            String osvdbs = "";
            foreach (String osvdb in tempOsvdbListNew)
            {
                osvdbs += osvdb + ", ";
            }
            if (!String.IsNullOrEmpty(osvdbs))
            {
                osvdbs = osvdbs.Substring(0, osvdbs.Length - 2);
            }

            String referenceLinks = "";
            foreach (String referenceLink in tempReferenceLinkListNew)
            {
                referenceLinks += referenceLink + ", ";
            }
            if (!String.IsNullOrEmpty(referenceLinks))
            {
                referenceLinks = referenceLinks.Substring(0, referenceLinks.Length - 2);
            }
			// fill cell values on dataGridView dataGridViewNew.
			int no = dataGridViewNew.Rows.Add();
			for (int i = 0; i < (int)ColumnIndex.MAX; i++) {
                if (i == (int)ColumnIndex.IPLIST){
                    dataGridViewNew.Rows[no].Cells[i].Value = ips;
                    continue;
                }
                if (i == (int)ColumnIndex.BID)
                {
                    dataGridViewNew.Rows[no].Cells[i].Value = bids;
                    continue;
                }
                if (i == (int)ColumnIndex.CVE)
                {
                    dataGridViewNew.Rows[no].Cells[i].Value = cves;
                    continue;
                }
                if (i == (int)ColumnIndex.OSVDB)
                {
                    dataGridViewNew.Rows[no].Cells[i].Value = osvdbs;
                    continue;
                }
                if (i == (int)ColumnIndex.REFERENCELINK)
                {
                    dataGridViewNew.Rows[no].Cells[i].Value = referenceLinks;
                    continue;
                }
                if (i == (int)ColumnIndex.ENTRYTYPE)
                {
                    if (haveNessus && haveMBSA)
                    {
                        dataGridViewNew.Rows[no].Cells[i].Value = DataEntry.getEntryTypeString(DataEntry.EntryType.MBSA_NESSUS);
                        continue;
                    }
                }
				dataGridViewNew.Rows[no].Cells[i].Value = dataGridViewOld.Rows[0].Cells[i].Value;
                if (dataGridViewNew.Rows[no].Cells[i].Value.ToString() == "")
                    for (int j = 1; j < dataGridViewOld.Rows.Count; j++)
                    {
                        dataGridViewNew.Rows[no].Cells[i].Value = dataGridViewOld.Rows[j].Cells[i].Value;
                        if (dataGridViewNew.Rows[no].Cells[i].Value.ToString() != "")
                            break;
                    }
			}
            this.TopMost = true;
            this.TopMost = false;
		}

		/// <summary>
		/// This is the FormEditFinding method.
		/// It is used to hide the current Form and display the Form
		/// FormEditFindingString for user to edit.
		/// </summary>
		/// <param name="indexArray">list of indexes that selected from the dataGridView on the previous form</param>
		/// <param name="dataArray">data to fill the dataGridView on this form (actually the next form)</param>
		/// <param name="columnIndex">determine which column needs to display on next form</param>
		public FormEditFinding(List<int> indexArray, List<DataEntry> dataArray, int columnIndex) {
			this.indexArray = indexArray;
			this.columnIndex = columnIndex;
			InitializeComponent();
            //buttonApplyToAll.Show();
			#region // actually useless on filling values on this form's dataGridViews
			foreach (DataEntry entry in dataArray) {
				int n = dataGridViewOld.Rows.Add();

				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.PLUGINNAME].Value = entry.getPluginName();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.IPLIST].Value = entry.getIp();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.DESCRIPTION].Value = entry.getDescription();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.IMPACT].Value = entry.getImpact();
				if (entry.getRiskFactor() == RiskFactor.OPEN) {
					dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.RISKFACTOR].Value = "OpenPort";
				}
				else {
					dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.RISKFACTOR].Value = RiskFactorFunction.getEnumString(entry.getRiskFactor());
				}
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.RECOMMENDATION].Value = entry.getRecommendation();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.CVE].Value = entry.getCve();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.BID].Value = entry.getBid();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.OSVDB].Value = entry.getOsvdb();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.REFERENCELINK].Value = entry.getReferenceLink();
				dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.ENTRYTYPE].Value = entry.getEntryTypeString();
                dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.PLUGINVERSION].Value = entry.getpluginversion();
                dataGridViewOld.Rows[n].Cells[(int)ColumnIndex.PLUGINID].Value = entry.getpluginID();

			}

			int no = dataGridViewNew.Rows.Add();
			for (int i = 0; i < (int)ColumnIndex.MAX; i++) {
				dataGridViewNew.Rows[no].Cells[i].Value = dataGridViewOld.Rows[0].Cells[i].Value;
			}
			#endregion

		}

		/// <summary>
		/// This is the rowToDataEntry method.
		/// </summary>
		/// <param name="row">DataGridViewRow that being transformed to DataEntry</param>
		/// <returns>a DataEntry from given DataGridViewRow.</returns>
		private DataEntry rowToDataEntry(DataGridViewRow row) {
            #region string CVE/BID/OSVDB to CVE/BID/OSVDB List
            List<String> cveList = null;
            if (row.Cells[(int)ColumnIndex.CVE].Value == null)
            {
                cveList = new List<string>();
            }
            else
            {
                cveList = row.Cells[(int)ColumnIndex.CVE].Value.ToString().Split(',').ToList<String>();
            }

            List<String> bidList = null;
            if (row.Cells[(int)ColumnIndex.BID].Value == null)
            {
                bidList = new List<string>();
            }
            else
            {
                bidList = row.Cells[(int)ColumnIndex.BID].Value.ToString().Split(',').ToList<String>();
            }

            List<String> osvdbList = null;
            if (row.Cells[(int)ColumnIndex.OSVDB].Value == null)
            {
                osvdbList = new List<string>();
            }
            else
            {
                osvdbList = row.Cells[(int)ColumnIndex.OSVDB].Value.ToString().Split(',').ToList<String>();
            }

            for (int i = 0; i < cveList.Count; i++)
            {
                String tempString = "";
                foreach (char c in cveList[i])
                {
                    if (c != ' ')
                    {
                        tempString += c;
                    }
                }
                cveList[i] = tempString;
            }

            for (int i = 0; i < bidList.Count; i++)
            {
                String tempString = "";
                foreach (char c in bidList[i])
                {
                    if (c != ' ')
                    {
                        tempString += c;
                    }
                }
                bidList[i] = tempString;
            }

            for (int i = 0; i < osvdbList.Count; i++)
            {
                String tempString = "";
                foreach (char c in osvdbList[i])
                {
                    if (c != ' ')
                    {
                        tempString += c;
                    }
                }
                osvdbList[i] = tempString;
            }
            #endregion

            return new GuiDataEntry(row.Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
                                    row.Cells[(int)ColumnIndex.IPLIST].Value.ToString(),
                                    row.Cells[(int)ColumnIndex.DESCRIPTION].Value.ToString(),
                                    row.Cells[(int)ColumnIndex.IMPACT].Value.ToString(),
                                    RiskFactorFunction.getEnum(row.Cells[(int)ColumnIndex.RISKFACTOR].Value.ToString()),
                                    row.Cells[(int)ColumnIndex.RECOMMENDATION].Value.ToString(),
                                    cveList,
                                    bidList,
                                    osvdbList,
                                    row.Cells[(int)ColumnIndex.REFERENCELINK].Value.ToString(),
                                    DataEntry.stringToEntryType(row.Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString()),
                                    row.Cells[(int)ColumnIndex.PLUGINVERSION].Value.ToString(),
                                    row.Cells[(int)ColumnIndex.PLUGINID].Value.ToString());
		}

		/// <summary>
		/// This is the buttonOk_Click method.
		/// It is used to handle the click event on button buttonOk.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOk_Click(object sender, EventArgs e) {
			Program.state.formEditFindingState = State.FormEditFindingState.OK;
			Program.state.formEditFindingEntry = rowToDataEntry(dataGridViewNew.Rows[0]);
			this.Close();
		}

		/// <summary>
		/// This is the buttonCancel_Click method.
		/// It is used to handle the click event on button buttonCancel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCancel_Click(object sender, EventArgs e) {
			Program.state.formEditFindingState = State.FormEditFindingState.CANCEL;
			this.Close();
		}

		/// <summary>
		/// This is the dataGridViewNew_CellMouseDoubleClick method.
		/// It is used to handle the mouse double click event on cell in DataGridView
		/// dataGridViewNew.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridViewNew_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.Button != System.Windows.Forms.MouseButtons.Left ||
				e.ColumnIndex == (int)ColumnIndex.RISKFACTOR ||
				e.ColumnIndex == (int)ColumnIndex.ENTRYTYPE ||
				e.RowIndex < 0 ||
				e.ColumnIndex < 0 ) {
				return;
			}
			List<String> dataArray = new List<string>();
			foreach (DataGridViewRow row in dataGridViewOld.Rows) {
				dataArray.Add(row.Cells[e.ColumnIndex].Value.ToString());
			}
            new FormEditFindingString(e.ColumnIndex, dataArray, dataGridViewNew.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ShowDialog();

            if (Program.state.formEditFindingStringState == State.FormEditFindingStringState.OK || Program.state.formEditFindingStringState == State.FormEditFindingStringState.APPLYTOALL)
            {
				 if (Program.state.formEditFindingStringState == State.FormEditFindingStringState.APPLYTOALL)
                 {
                    if (e.ColumnIndex == (int)ColumnIndex.DESCRIPTION)
                        Program.state.amendmentDatabaser.storeAmendment(new Amendment(dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString() +
                                    "_" + dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
                                    dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString(),
                                    dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.DESCRIPTION].Value.ToString(),
                                    Program.state.formEditFindingString_stringText,
                                    null,
                                    null,
                                    null,
                                    null));
                    else if (e.ColumnIndex == (int)ColumnIndex.RECOMMENDATION)
                        Program.state.amendmentDatabaser.storeAmendment(new Amendment(dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString() +
                                    "_" + dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
                                    dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString(),
                                    null,
                                    null,
                                    dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.RECOMMENDATION].Value.ToString(),
                                    Program.state.formEditFindingString_stringText,
                                    null,
                                    null));
                    else if (e.ColumnIndex == (int)ColumnIndex.REFERENCELINK)
                        Program.state.amendmentDatabaser.storeAmendment(new Amendment(dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString() +
                                    "_" + dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
                                    dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString(),
                                    null,
                                    null,
                                    null,
                                    null,
                                    dataGridViewNew.Rows[e.RowIndex].Cells[(int)ColumnIndex.REFERENCELINK].Value.ToString(),
                                    Program.state.formEditFindingString_stringText));
                 }  
                 dataGridViewNew.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Program.state.formEditFindingString_stringText;
			}
            else
			Program.state.formEditFindingStringState = State.FormEditFindingStringState.NULL;
		}

		/// <summary>
		/// This is the FormEditFinding_Load method.
		/// It is used to hide the current Form and display the Form
		/// FormEditFindingString for user to edit if the columnIndex in 
		/// this form is not equal to negative no.
		/// 
		/// positive no. of the columnIndex would trigger and show the form
		/// FormEditFindingString out, for further edition to user.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormEditFinding_Load(object sender, EventArgs e) {
			if (columnIndex != -1) {
				List<String> dataArray = new List<string>();
				foreach (DataGridViewRow row in dataGridViewOld.Rows) {
					dataArray.Add(row.Cells[columnIndex].Value.ToString());
				}
				new FormEditFindingString(columnIndex, dataArray).ShowDialog();

                if (Program.state.formEditFindingStringState == State.FormEditFindingStringState.OK || Program.state.formEditFindingStringState == State.FormEditFindingStringState.APPLYTOALL)
                {
                    if (Program.state.formEditFindingStringState == State.FormEditFindingStringState.APPLYTOALL)
                    {
                        if (columnIndex == (int)ColumnIndex.DESCRIPTION)
                            Program.state.amendmentDatabaser.storeAmendment(new Amendment(dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString() +
                                        "_" + dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
                                        dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString(),
                                        dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.DESCRIPTION].Value.ToString(),
                                        Program.state.formEditFindingString_stringText,
                                        null,
                                        null,
                                        null,
                                        null));
                        else if (columnIndex == (int)ColumnIndex.RECOMMENDATION)
                            Program.state.amendmentDatabaser.storeAmendment(new Amendment(dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString() +
                                        "_" + dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
                                        dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString(),
                                        null,
                                        null,
                                        dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.RECOMMENDATION].Value.ToString(),
                                        Program.state.formEditFindingString_stringText,
                                        null,
                                        null));
                        else if (columnIndex == (int)ColumnIndex.REFERENCELINK)
                            Program.state.amendmentDatabaser.storeAmendment(new Amendment(dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString() +
                                        "_" + dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
                                        dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.ENTRYTYPE].Value.ToString(),
                                        null,
                                        null,
                                        null,
                                        null,
                                        dataGridViewNew.Rows[0].Cells[(int)ColumnIndex.REFERENCELINK].Value.ToString(),
                                        Program.state.formEditFindingString_stringText));
                    }  
					dataGridViewNew.Rows[0].Cells[columnIndex].Value = Program.state.formEditFindingString_stringText;
					Program.state.formEditFindingState = State.FormEditFindingState.OK;
					Program.state.formEditFindingEntry = rowToDataEntry(dataGridViewNew.Rows[0]);
				}
				Program.state.formEditFindingStringState = State.FormEditFindingStringState.NULL;

				this.Close();
			}
		}

        private void dataGridViewOld_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //private void buttonApplyToAll_Click(object sender, EventArgs e)
        //{

        //    Program.state.formEditFindingEntry = rowToDataEntry(dataGridViewNew.Rows[0]);
        //    Program.state.formEditFindingStringState = State.FormEditFindingStringState.APPLYTOALL;
        //    this.Close();
        //}

	}
}
