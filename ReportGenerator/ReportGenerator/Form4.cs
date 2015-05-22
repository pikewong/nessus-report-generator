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
	public partial class Form4 : Form {
		private List<int> indexArray = null;
		private int columnIndex = -1;

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
			MAX = 10
		}

		public Form4(List<int> indexArray, List<DataEntry> dataArray) {
			this.indexArray = indexArray;
			InitializeComponent();

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
			}

			int no = dataGridViewNew.Rows.Add();
			for (int i = 0; i < (int)ColumnIndex.MAX; i++) {
				dataGridViewNew.Rows[no].Cells[i].Value = dataGridViewOld.Rows[0].Cells[i].Value;
			}
		}

		public Form4(List<int> indexArray, List<DataEntry> dataArray, int columnIndex) {
			this.indexArray = indexArray;
			this.columnIndex = columnIndex;
			InitializeComponent();

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
			}

			int no = dataGridViewNew.Rows.Add();
			for (int i = 0; i < (int)ColumnIndex.MAX; i++) {
				dataGridViewNew.Rows[no].Cells[i].Value = dataGridViewOld.Rows[0].Cells[i].Value;
			}
		}

		private DataEntry rowToDataEntry(DataGridViewRow row) {
			List<String> cveList = null;
			if (row.Cells[(int)ColumnIndex.CVE].Value == null) {
				cveList = new List<string>();
			}
			else {
				cveList = row.Cells[(int)ColumnIndex.CVE].Value.ToString().Split(',').ToList<String>();
			}

			List<String> bidList = null;
			if (row.Cells[(int)ColumnIndex.BID].Value == null) {
				bidList = new List<string>();
			}
			else{
				bidList = row.Cells[(int)ColumnIndex.BID].Value.ToString().Split(',').ToList<String>();
			}

			List<String> osvdbList = null;
			if (row.Cells[(int)ColumnIndex.OSVDB].Value == null) {
				osvdbList = new List<string>();
			}
			else {
				osvdbList = row.Cells[(int)ColumnIndex.OSVDB].Value.ToString().Split(',').ToList<String>();
			}

			for (int i = 0; i < cveList.Count; i++) {
				String tempString = "";
				foreach (char c in cveList[i]) {
					if (c != ' ') {
						tempString += c;
					}
				}
				cveList[i] = tempString;
			}

			for (int i = 0; i < bidList.Count; i++) {
				String tempString = "";
				foreach (char c in bidList[i]) {
					if (c != ' ') {
						tempString += c;
					}
				}
				bidList[i] = tempString;
			}

			for (int i = 0; i < osvdbList.Count; i++) {
				String tempString = "";
				foreach (char c in osvdbList[i]) {
					if (c != ' ') {
						tempString += c;
					}
				}
				osvdbList[i] = tempString;
			}

			return new NessusDataEntry(row.Cells[(int)ColumnIndex.PLUGINNAME].Value.ToString(),
								 	   row.Cells[(int)ColumnIndex.IPLIST].Value.ToString(),
									   row.Cells[(int)ColumnIndex.DESCRIPTION].Value.ToString(),
									   row.Cells[(int)ColumnIndex.IMPACT].Value.ToString(),
									   (int)RiskFactorFunction.getEnum(row.Cells[(int)ColumnIndex.RISKFACTOR].Value.ToString()),
									   RiskFactorFunction.getEnum(row.Cells[(int)ColumnIndex.RISKFACTOR].Value.ToString()),
									   row.Cells[(int)ColumnIndex.RECOMMENDATION].Value.ToString(),
									   cveList,
									   bidList,
									   osvdbList,
									   row.Cells[(int)ColumnIndex.REFERENCELINK].Value.ToString());
		}

		private void ok_Click(object sender, EventArgs e) {
			Program.state.form4State = State.Form4State.OK;
			Program.state.form4entry = rowToDataEntry(dataGridViewNew.Rows[0]);
			this.Close();
		}

		private void cancel_Click(object sender, EventArgs e) {
			Program.state.form4State = State.Form4State.CANCEL;
			this.Close();
		}

		private void dataGridViewNew_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.Button != System.Windows.Forms.MouseButtons.Left || e.ColumnIndex == 4 || e.RowIndex < 0) {
				return;
			}
			List<String> dataArray = new List<string>();
			foreach (DataGridViewRow row in dataGridViewOld.Rows) {
				dataArray.Add(row.Cells[e.ColumnIndex].Value.ToString());
			}
			new Form5(e.ColumnIndex, dataArray).ShowDialog();
			
			if (Program.state.form5State == State.Form5State.OK) {
				dataGridViewNew.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Program.state.form5Data;
			}
			Program.state.form5State = State.Form5State.NULL;
		}

		private void Form4_Load(object sender, EventArgs e) {
			if (columnIndex != -1) {
				List<String> dataArray = new List<string>();
				foreach (DataGridViewRow row in dataGridViewOld.Rows) {
					dataArray.Add(row.Cells[columnIndex].Value.ToString());
				}
				new Form5(columnIndex, dataArray).ShowDialog();

				if (Program.state.form5State == State.Form5State.OK) {
					dataGridViewNew.Rows[0].Cells[columnIndex].Value = Program.state.form5Data;
					Program.state.form4State = State.Form4State.OK;
					Program.state.form4entry = rowToDataEntry(dataGridViewNew.Rows[0]);
				}
				Program.state.form5State = State.Form5State.NULL;

				this.Close();
			}
		}

	}
}
