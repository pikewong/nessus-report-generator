using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ReportGenerator.ReportInput;
using ReportGenerator.Record;
using ReportGenerator.ReportOutput;
using ReportGenerator.Database;
using ReportGenerator.ReportOutput.OutputFormatter;
using ReportGenerator.ReportInput.InputParser;

namespace ReportGenerator {
	public partial class Form3 : Form {

		private enum Panel {
			ONE,
			TWO,
			THREE,
			FOUR,
			FIVE
		};

		private static class PanelString {
			public static String one = "1. Import report(s)";
			public static String two = "2. Edit report field(s)";
			public static String three = "3. Output Selection";
			public static String four = "4. Template String Replace";
			public static String five = "5. Output Panel";
			public static String none = "";
		};

		private enum CellColumnIndex : int {
			SELECTED = 0,
			MERGED = 1,
			EDITED = 2,
			PLUGINNAME = 3,
			IPLIST = 4,
			DESCRIPTION = 5,
			IMPACT = 6,
			RISKFACTOR = 7,
			RECOMMENDATION = 8,
			CVE = 9,
			BID = 10,
			OSVDB = 11,
			REFERENCELINK = 12,
			ID = 13,
			OLDID = 14
		}

		Panel panel;

		public Form3() {
			panel = Panel.ONE;
			InitializeComponent();

			switch(Program.state.form1State){
				case State.Form1State.CREATE:
					panel1Show();
					break;
				case State.Form1State.OPEN:
					String directory = Program.state.form2Path.Substring(0, Program.state.form2Path.LastIndexOf('\\'));
					CaseDatabaser caseDatabaser = new CaseDatabaser(directory, Program.state.form2Path);
					if (caseDatabaser.loadRGConfigFile()) {
						panel2Show();
					}
					else {
						MessageBox.Show("Error in getting results from the database, please select the proper data files.");
						this.Hide();
						new Form2().ShowDialog();
						this.Close();
					}
					break;
			}
		}

		#region PANEL Movement
		private void next_Click(object sender, EventArgs e) {
			switch (panel) {
				case Panel.ONE:
					panel1_nextAction();
					panel2Show();
					break;
				case Panel.TWO:
					panel2_nextAction();
					panel3Show();
					break;
				case Panel.THREE:
					panel3_nextAction();
					if (Program.state.form3Panel3State == State.Form3Panel3State.DOCXTEM) {
						panel4Show();
					}
					else {
						panel5Show();
					}
					break;
				case Panel.FOUR:
					panel4_nextAction();
					panel5Show();

					break;
				case Panel.FIVE:
					panel5_nextAction();
					this.Close();
					break;
			}
		}

		private void back_Click(object sender, EventArgs e) {
			switch (panel) {
				case Panel.ONE:
					this.Hide();
					new Form2().ShowDialog();
					this.Close();

					break;
				case Panel.TWO:
					panel1Show();
					break;
				case Panel.THREE:
					panel2Show();

					break;
				case Panel.FOUR:
					panel3Show();

					break;
				case Panel.FIVE:
					if (Program.state.form3Panel3State == State.Form3Panel3State.DOCXTEM) {
						panel4Show();
					}
					else {
						panel3Show();
					}
					break;
			}
		}

		private void cancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void panel1Show() {
			panel2.Hide();
			panel2_bottom.Hide();
			panel3.Hide();
			panel4.Hide();
			panel5.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.none;
			three.Text = PanelString.none;
			four.Text = PanelString.none;
			five.Text = PanelString.none;

			next.Text = "Next >";
			next.Enabled = false;
			panel1_initialize();
			panel1.Show();

			panel = Panel.ONE;
		}

		private void panel2Show() {
			panel1.Hide();
			panel3.Hide();
			panel4.Hide();
			panel5.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.none;
			four.Text = PanelString.none;
			five.Text = PanelString.none;

			next.Text = "Next >";
			next.Enabled = false;
			panel2_initialize();
			panel2.Show();
			panel2_bottom.Show();

			panel = Panel.TWO;
		}

		private void panel3Show() {
			panel1.Hide();
			panel2.Hide();
			panel2_bottom.Hide();
			panel4.Hide();
			panel5.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.three;
			four.Text = PanelString.none;
			five.Text = PanelString.none;

			next.Text = "Next >";
			next.Enabled = false;
			panel3_initialize();
			panel3.Show();

			panel = Panel.THREE;
		}

		private void panel4Show() {
			panel1.Hide();
			panel2.Hide();
			panel2_bottom.Hide();
			panel3.Hide();
			panel5.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.three;
			four.Text = PanelString.four;
			five.Text = PanelString.none;

			next.Text = "Next >";
			next.Enabled = false;
			panel4_initialize();
			panel4.Show();

			panel = Panel.FOUR;
		}

		private void panel5Show() {
			panel1.Hide();
			panel2.Hide();
			panel2_bottom.Hide();
			panel3.Hide();
			panel4.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.three;
			if (Program.state.form3Panel3State == State.Form3Panel3State.DOCXTEM) {
				four.Text = PanelString.four;
				five.Text = PanelString.five;
			}
			else {
				four.Text = "4. Output Panel";
			}
			
			next.Text = "Finish";
			panel5.Show();

			panel = Panel.FIVE;
		}
		#endregion

		#region PANEL1 Functions
		private void panel1_initialize() {
			checkedListBox1.Items.Clear();
			if (Program.state.form3PathSelected != null) {
				for (int i = 0; i < Program.state.form3PathSelected.Count; i++) {
					checkedListBox1.Items.Add(Program.state.form3Paths[i], Program.state.form3PathSelected[i]);
				}
			}

			panel1_enableNextButton();
		}

		private void panel1_enableNextButton() {
			int counter = 0;
			for (int i = 0; i < checkedListBox1.Items.Count; i++) {
				if (checkedListBox1.GetItemChecked(i)) {
					counter++;
				}
			}

			next.Enabled = (counter == 0)? false : true;
		}

		private void panel1_importFolder_Click(object sender, EventArgs e) {
			folderBrowserDialog.ShowDialog();
			String folderPath = folderBrowserDialog.SelectedPath;

			if (!String.IsNullOrEmpty(folderPath)) {
				String[] paths = Directory.GetFiles(folderPath, "*.nessus", SearchOption.AllDirectories);
				foreach (String path in paths) {
					if (!checkedListBox1.Items.Contains(path)) {
						checkedListBox1.Items.Add(path, true);
					}
				}

				paths = Directory.GetFiles(folderPath, "*.mbsa", SearchOption.AllDirectories);
				foreach (String path in paths) {
					if (!checkedListBox1.Items.Contains(path)) {
						checkedListBox1.Items.Add(path, true);
					}
				}

				paths = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);
				foreach (String path in paths){
					if (!checkedListBox1.Items.Contains(path)) {
						if (NmapParser.isNmapXmlFile(path)) {
							checkedListBox1.Items.Add(path, true);
						}
					}
				}

				paths = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
				foreach (String path in paths) {
					if (!checkedListBox1.Items.Contains(path)) {
						if (NmapTxtParser.isNmapTxtFile(path)) {
							checkedListBox1.Items.Add(path, true);
						}
					}
				}
			}

			panel1_enableNextButton();
		}

		private void panel1_importFile_Click(object sender, EventArgs e) {
			openFileDialog.Filter = "Nessus Report(.nessus)|*.nessus|MBSA Report (.mbsa)|*.mbsa";
			openFileDialog.Multiselect = true;
			openFileDialog.ShowDialog();

			String path = openFileDialog.FileName;
			if (!String.IsNullOrEmpty(path) && !checkedListBox1.Items.Contains(path)) {
				checkedListBox1.Items.Add(path, true);
			}

			panel1_enableNextButton();
		}

		private void panel1_selectAll_Click(object sender, EventArgs e) {
			for (int i = 0; i < checkedListBox1.Items.Count; i++) {
				checkedListBox1.SetItemChecked(i, true);
			}

			if (checkedListBox1.Items.Count > 0) {
				next.Enabled = true;
			}
		}

		private void panel1_selectNone_Click(object sender, EventArgs e) {
			for (int i = 0; i < checkedListBox1.Items.Count; i++) {
				checkedListBox1.SetItemChecked(i, false);
			}
			next.Enabled = false;
		}

		private void panel1_reverse_Click(object sender, EventArgs e) {
			for (int i = 0; i < checkedListBox1.Items.Count; i++) {
				if (checkedListBox1.GetItemChecked(i)) {
					checkedListBox1.SetItemChecked(i, false);
				}
				else {
					checkedListBox1.SetItemChecked(i, true);
				}
			}

			panel1_enableNextButton();
		}

		private void checkedListBox1_Click(object sender, EventArgs e) {
			panel1_enableNextButton();
		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) {
			panel1_enableNextButton();
		}

		private void checkedListBox1_KeyPress(object sender, KeyPressEventArgs e) {
			panel1_enableNextButton();
		}

		private void panel1_nextAction() {
			Program.state.form3Paths = new List<string>();
			Program.state.form3PathSelected = new List<bool>();
			Program.state.form3DatabasePath = "";
			for (int i = 0; i < checkedListBox1.Items.Count; i++) {
				Program.state.form3Paths.Add(new String(checkedListBox1.Items[i].ToString().ToCharArray()));
				Program.state.form3PathSelected.Add(checkedListBox1.GetItemChecked(i));
			}
		}
		#endregion

		#region PANEL2 Functions
		private void panel2_initialize() {
			dataGridView1.Rows.Clear();
			if (String.IsNullOrEmpty(Program.state.form3DatabasePath)) {
				List<String> tempPaths = new List<string>();
				for (int i = 0; i < Program.state.form3Paths.Count; i++) {
					if (Program.state.form3PathSelected[i]) {
						tempPaths.Add(Program.state.form3Paths[i]);
					}
				}

				Program.state.form3Record = new ReportInputer().getData(tempPaths);
				Program.state.form3DatabasePath = Program.state.form2Path + "\\Data" + DateTime.Now.ToString("HHmmss_ddMMyy") + ".db";
				Program.state.form3Databaser = new Databaser(Program.state.form3DatabasePath, ref Program.state.form3Record);
			}
			else {
				Program.state.form3Record = Program.state.form3Databaser.getRecord();
			}

			panel2_addRow(Program.state.form3Record.getHighRisk());
			panel2_addRow(Program.state.form3Record.getMediumRisk());
			panel2_addRow(Program.state.form3Record.getLowRisk());
			panel2_addRow(Program.state.form3Record.getNoneRisk());
			panel2_addRow(Program.state.form3Record.getOpenPort());

			if (Program.state.form3RecordSelected != null) {
				for (int i = 0; i < Program.state.form3RecordSelected.Count; i++) {
					dataGridView1.Rows[i].Cells[(int)CellColumnIndex.SELECTED].Value = Program.state.form3RecordSelected[i];
					dataGridView1.Rows[i].Cells[(int)CellColumnIndex.MERGED].Value = Program.state.form3RecordMerged[i];
					dataGridView1.Rows[i].Cells[(int)CellColumnIndex.EDITED].Value = Program.state.form3RecordEdited[i];
					dataGridView1.Rows[i].Cells[(int)CellColumnIndex.ID].Value = Program.state.form3Id[i];
					dataGridView1.Rows[i].Cells[(int)CellColumnIndex.OLDID].Value = Program.state.form3OldId[i];
				}
			}
			else {
				for (int i = 0; i < dataGridView1.Rows.Count; i++) {
					dataGridView1.Rows[i].Cells[(int)CellColumnIndex.ID].Value = i + 1;
					dataGridView1.Rows[i].Cells[(int)CellColumnIndex.OLDID].Value = i + 1;
				}
			}

			if (Program.state.form3Panel2showHigh) {
				panel2_checkboxHigh.CheckState = CheckState.Checked;
			}
			else {
				panel2_checkboxHigh.CheckState = CheckState.Unchecked;
			}

			if (Program.state.form3Panel2showMedium) {
				panel2_checkboxMedium.CheckState = CheckState.Checked;
			}
			else {
				panel2_checkboxMedium.CheckState = CheckState.Unchecked;
			}

			if (Program.state.form3Panel2showLow) {
				panel2_checkboxLow.CheckState = CheckState.Checked;
			}
			else {
				panel2_checkboxLow.CheckState = CheckState.Unchecked;
			}

			if (Program.state.form3Panel2showNone) {
				panel2_checkboxNone.CheckState = CheckState.Checked;
			}
			else {
				panel2_checkboxNone.CheckState = CheckState.Unchecked;
			}

			if (Program.state.form3Panel2showOpenPort) {
				panel2_checkboxOpenPort.CheckState = CheckState.Checked;
			}
			else {
				panel2_checkboxOpenPort.CheckState = CheckState.Unchecked;
			}

			panel2_checkboxCheckedChangedAction();
			panel2_enableNextButton();
		}

		private void panel2_addRow(Dictionary<int, DataEntry> risk) {
			foreach (KeyValuePair<int, DataEntry> entry in risk) {
				int n = dataGridView1.Rows.Add();

				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = false;
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.MERGED].Value = false;
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.EDITED].Value = false;
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.PLUGINNAME].Value = entry.Value.getPluginName();
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.IPLIST].Value = entry.Value.getIp();
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.DESCRIPTION].Value = entry.Value.getDescription();
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.IMPACT].Value = entry.Value.getImpact();
				if (entry.Value.getRiskFactor() == RiskFactor.OPEN) {
					dataGridView1.Rows[n].Cells[(int)CellColumnIndex.RISKFACTOR].Value = "OpenPort";
				}
				else {
					dataGridView1.Rows[n].Cells[(int)CellColumnIndex.RISKFACTOR].Value = RiskFactorFunction.getEnumString(entry.Value.getRiskFactor());
				}
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.RECOMMENDATION].Value = entry.Value.getRecommendation();
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.CVE].Value = entry.Value.getCve();
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.BID].Value = entry.Value.getBid();
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.OSVDB].Value = entry.Value.getOsvdb();
				dataGridView1.Rows[n].Cells[(int)CellColumnIndex.REFERENCELINK].Value = entry.Value.getReferenceLink();
			}
		}

		private void panel2_addRowForMerge(DataEntry entry) {
			int n = dataGridView1.Rows.Add();

			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = false;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.MERGED].Value = true;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.EDITED].Value = false;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.PLUGINNAME].Value = entry.getPluginName();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.IPLIST].Value = entry.getIp();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.DESCRIPTION].Value = entry.getDescription();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.IMPACT].Value = entry.getImpact();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.RISKFACTOR].Value = RiskFactorFunction.getEnumString(entry.getRiskFactor());
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.RECOMMENDATION].Value = entry.getRecommendation();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.CVE].Value = entry.getCve();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.BID].Value = entry.getBid();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.OSVDB].Value = entry.getOsvdb();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.REFERENCELINK].Value = entry.getReferenceLink();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.ID].Value = n + 1;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.OLDID].Value = n + 1;

			Program.state.form3Databaser.guiInsertMergeRecordToDatabase(entry);
		}

		private void panel2_addRowForUpdate(DataEntry entry, int oldId) {
			int n = dataGridView1.Rows.Add();

			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = false;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.MERGED].Value = false;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.EDITED].Value = true;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.PLUGINNAME].Value = entry.getPluginName();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.IPLIST].Value = entry.getIp();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.DESCRIPTION].Value = entry.getDescription();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.IMPACT].Value = entry.getImpact();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.RISKFACTOR].Value = RiskFactorFunction.getEnumString(entry.getRiskFactor());
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.RECOMMENDATION].Value = entry.getRecommendation();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.CVE].Value = entry.getCve();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.BID].Value = entry.getBid();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.OSVDB].Value = entry.getOsvdb();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.REFERENCELINK].Value = entry.getReferenceLink();
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.ID].Value = n + 1;
			dataGridView1.Rows[n].Cells[(int)CellColumnIndex.OLDID].Value = oldId;

			Program.state.form3Databaser.guiInsertUpdateRecordToDatabase(entry, oldId);
		}

		private DataEntry panel2_getEntryWithoutEntryType(DataGridViewRow row) {
			List<String> cveList = row.Cells[(int)CellColumnIndex.CVE].Value.ToString().Split(',').ToList<String>();
			List<String> bidList = row.Cells[(int)CellColumnIndex.BID].Value.ToString().Split(',').ToList<String>();
			List<String> osvdbList = row.Cells[(int)CellColumnIndex.OSVDB].Value.ToString().Split(',').ToList<String>();

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

			String tempPluginName = objectToString(row.Cells[(int)CellColumnIndex.PLUGINNAME].Value);
			String tempIpList = objectToString(row.Cells[(int)CellColumnIndex.IPLIST].Value);
			String tempDescription = objectToString(row.Cells[(int)CellColumnIndex.DESCRIPTION].Value);
			String tempImpact = objectToString(row.Cells[(int)CellColumnIndex.IMPACT].Value);
			String tempRecommendation = objectToString(row.Cells[(int)CellColumnIndex.RECOMMENDATION].Value);
			String tempReferenceLink = objectToString(row.Cells[(int)CellColumnIndex.REFERENCELINK].Value);

			return new GuiDataEntry(tempPluginName,
									tempIpList,
									tempDescription,
									tempImpact,
									RiskFactorFunction.getEnum(row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString()),
									tempRecommendation,
									cveList,
									bidList,
									osvdbList,
									tempReferenceLink);
		}

		private DataEntry panel2_rowToDataEntry(DataGridViewRow row){
			DataEntry tempEntry = panel2_getEntryWithoutEntryType(row);
			
			int tempOldId = int.Parse(row.Cells[(int)CellColumnIndex.OLDID].Value.ToString());
			
			DataEntry.EntryType tempEntryType = DataEntry.EntryType.NULL;
			
			foreach (DataGridViewRow tempRow in dataGridView1.Rows) {
				if (tempRow.Cells[(int)CellColumnIndex.ID].Value.ToString() ==
					tempRow.Cells[(int)CellColumnIndex.OLDID].Value.ToString() &&
					tempRow.Cells[(int)CellColumnIndex.OLDID].Value.ToString() == tempOldId.ToString()) {
					tempEntryType = Program.state.form3Record.getEntryType(panel2_getEntryWithoutEntryType(tempRow));
				}
			}
			tempEntry.setEntryType(tempEntryType);
			return tempEntry;
		}

		private String objectToString(Object o) {
			if (o == null) {
				return "";
			}
			return o.ToString();
		}

		private void panel2_selectAll_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in dataGridView1.Rows){
				if (row.Visible) {
					row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
				}
				else {
					row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
				}
			}

			panel2_enableNextButton();
		}
		
		private void panel2_selectNone_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in dataGridView1.Rows) {
				row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
			}

			panel2_enableNextButton();
		}

		private void panel2_selectMerge_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in dataGridView1.Rows) {
				if (row.Visible) {
					if ((bool)row.Cells[(int)CellColumnIndex.MERGED].Value == true) {
						row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
				}
			}

			panel2_enableNextButton();
		}

		private void panel2_selectUpdate_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in dataGridView1.Rows) {
				if (row.Visible) {
					if ((bool)row.Cells[(int)CellColumnIndex.EDITED].Value == true) {
						row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
				}
			}
			panel2_enableNextButton();
		}

		private void panel2_selectReverse_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in dataGridView1.Rows) {
				if (row.Visible) {
					if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value == false) {
						row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
					else {
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}

			panel2_enableNextButton();
		}

		private void panel2_mergeRecord_Click(object sender, EventArgs e) {
			int counter = 0;
			List<int> indexArray = new List<int>();
			List<DataEntry> dataArray = new List<DataEntry>();

			foreach (DataGridViewRow row in dataGridView1.Rows) {
				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value) {
					counter++;
					indexArray.Add(row.Index);
					dataArray.Add(panel2_rowToDataEntry(row));
				}
			}

			this.Enabled = false;
			new Form4(indexArray, dataArray).ShowDialog();
			this.Enabled = true;

			if (Program.state.form4State == State.Form4State.OK) {
				panel2_addRowForMerge(Program.state.form4entry);
				foreach (int index in indexArray) {
					dataGridView1.Rows[index].Cells[(int)CellColumnIndex.SELECTED].Value = false;
				}
				panel2_enableNextButton();
			}
			Program.state.form4State = State.Form4State.NULL;
		}

		private void panel2_updateRecord_Click(object sender, EventArgs e) {
			List<int> indexArray = new List<int>();
			List<DataEntry> dataArray = new List<DataEntry>();

			foreach (DataGridViewRow row in dataGridView1.Rows) {
				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value) {
					indexArray.Add(row.Index);
					dataArray.Add(panel2_rowToDataEntry(row));
				}
			}

			this.Enabled = false;
			new Form4(indexArray, dataArray).ShowDialog();
			this.Enabled = true;

			if (Program.state.form4State == State.Form4State.OK) {
				if ((bool)dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.EDITED].Value) {
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.SELECTED].Value = true;
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.PLUGINNAME].Value = Program.state.form4entry.getPluginName();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.IPLIST].Value = Program.state.form4entry.getIp();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.DESCRIPTION].Value = Program.state.form4entry.getDescription();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.IMPACT].Value = Program.state.form4entry.getImpact();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.RISKFACTOR].Value = RiskFactorFunction.getEnumString(Program.state.form4entry.getRiskFactor());
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.RECOMMENDATION].Value = Program.state.form4entry.getRecommendation();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.CVE].Value = Program.state.form4entry.getCve();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.BID].Value = Program.state.form4entry.getBid();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.OSVDB].Value = Program.state.form4entry.getOsvdb();
					dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.REFERENCELINK].Value = Program.state.form4entry.getReferenceLink();
					Program.state.form3Databaser.guiInsertUpdateRecordToDatabase(Program.state.form4entry, (int)dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.OLDID].Value);
				}
				else {
					panel2_addRowForUpdate(Program.state.form4entry, (int)dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.OLDID].Value);
				}
				dataGridView1.Rows[indexArray[0]].Cells[(int)CellColumnIndex.SELECTED].Value = false;
				panel2_enableNextButton();
			}
			Program.state.form4State = State.Form4State.NULL;
		}

		private String columnIndexToText(int columnIndex) {
			switch (columnIndex) {
				case 3:
					return Program.state.form4entry.getPluginName();
				case 4:
					return Program.state.form4entry.getIp();
				case 5:
					return Program.state.form4entry.getDescription();
				case 6:
					return Program.state.form4entry.getImpact();
				case 8:
					return Program.state.form4entry.getRecommendation();
				case 9:
					return Program.state.form4entry.getCve();
				case 10:
					return Program.state.form4entry.getBid();
				case 11:
					return Program.state.form4entry.getOsvdb();
				case 12:
					return Program.state.form4entry.getReferenceLink();
			}
			return "";
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex != (int)CellColumnIndex.SELECTED &&
				e.ColumnIndex != (int)CellColumnIndex.MERGED &&
				e.ColumnIndex != (int)CellColumnIndex.EDITED &&
				e.ColumnIndex != (int)CellColumnIndex.RISKFACTOR &&
				e.RowIndex != -1) {
				List<int> indexArray = new List<int>();
				List<DataEntry> dataArray = new List<DataEntry>();

				dataArray.Add(panel2_rowToDataEntry(dataGridView1.Rows[e.RowIndex]));

				this.Enabled = false;
				new Form4(indexArray, dataArray, e.ColumnIndex - 3).ShowDialog();
				this.Enabled = true;

				if (Program.state.form4State == State.Form4State.OK) {
					if ((bool)dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.EDITED].Value) {
						dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = columnIndexToText(e.ColumnIndex);
						Program.state.form3Databaser.guiInsertUpdateRecordToDatabase(Program.state.form4entry, (int)dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
					}
					else {
						panel2_addRowForUpdate(Program.state.form4entry, (int)dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
						dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = false;
						dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
					panel2_enableNextButton();
				}
				Program.state.form4State = State.Form4State.NULL;
			}
			else if (e.ColumnIndex == (int)CellColumnIndex.RISKFACTOR) {
				List<int> indexArray = new List<int>();
				List<DataEntry> dataArray = new List<DataEntry>();

				dataArray.Add(panel2_rowToDataEntry(dataGridView1.Rows[e.RowIndex]));

				this.Enabled = false;
				new Form4(indexArray, dataArray, e.ColumnIndex - 3).ShowDialog();
				this.Enabled = true;

				if (Program.state.form4State == State.Form4State.OK) {
					if ((bool)dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.EDITED].Value) {
						dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = columnIndexToText(e.ColumnIndex);
						Program.state.form3Databaser.guiInsertUpdateRecordToDatabase(Program.state.form4entry, (int)dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
					}
					else {
						panel2_addRowForUpdate(Program.state.form4entry, (int)dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
						dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = false;
						dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
					panel2_enableNextButton();
				}
				Program.state.form4State = State.Form4State.NULL;
			}
		}

		private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.Button == System.Windows.Forms.MouseButtons.Left &&
				dataGridView1.SelectedCells.Count != 1) {
				for (int i = 0; i < dataGridView1.SelectedCells.Count; i++) {
					if (dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Visible) {
						if ((bool)dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value) {
							dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = false;
						}
						else {
							dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = true;
						}
					}
				}
				panel2_enableNextButton();
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex != -1 && dataGridView1.SelectedCells.Count == 1 ) {
				if (dataGridView1.Rows[e.RowIndex].Visible) {
					if ((bool)dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value) {
						dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
					else {
						dataGridView1.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
				}
				panel2_enableNextButton();
			}
		}

		private void panel2_checkboxCheckedChangedAction() {
			if (panel2_checkboxHigh.CheckState == CheckState.Checked) {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "High") {
						row.Visible = true;
					}
				}
			}
			else {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "High") {
						row.Visible = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}

			if (panel2_checkboxMedium.CheckState == CheckState.Checked) {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "Medium") {
						row.Visible = true;
					}
				}
			}
			else {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "Medium") {
						row.Visible = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}

			if (panel2_checkboxLow.CheckState == CheckState.Checked) {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "Low") {
						row.Visible = true;
					}
				}
			}
			else {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "Low") {
						row.Visible = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}

			if (panel2_checkboxNone.CheckState == CheckState.Checked) {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "None") {
						row.Visible = true;
					}
				}
			}
			else {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "None") {
						row.Visible = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}

			if (panel2_checkboxOpenPort.CheckState == CheckState.Checked) {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "OpenPort") {
						row.Visible = true;
					}
				}
			}
			else {
				foreach (DataGridViewRow row in dataGridView1.Rows) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "OpenPort") {
						row.Visible = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}
			panel2_enableNextButton();
		}

		private void panel2_checkboxHigh_CheckedChanged(object sender, EventArgs e) {
			panel2_checkboxCheckedChangedAction();
		}

		private void panel2_checkboxMedium_CheckedChanged(object sender, EventArgs e) {
			panel2_checkboxCheckedChangedAction();
		}

		private void panel2_checkboxLow_CheckedChanged(object sender, EventArgs e) {
			panel2_checkboxCheckedChangedAction();
		}

		private void panel2_checkboxNone_CheckedChanged(object sender, EventArgs e) {
			panel2_checkboxCheckedChangedAction();
		}

		private void panel2_checkboxOpenPort_CheckedChanged(object sender, EventArgs e) {
			panel2_checkboxCheckedChangedAction();
		}

		private void panel2_ComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			switch (panel2_ComboBox.SelectedIndex) {
				case 0:
					foreach (DataGridViewRow row in dataGridView1.Rows) {
						if (row.Visible) {
							if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "High") {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
							}
							else {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
							}
						}
					}
					break;
				case 1:
					foreach (DataGridViewRow row in dataGridView1.Rows) {
						if (row.Visible) {
							if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "Medium") {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
							}
							else {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
							}
						}
					}
					break;
				case 2:
					foreach (DataGridViewRow row in dataGridView1.Rows) {
						if (row.Visible) {
							if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "Low") {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
							}
							else {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
							}
						}
					}
					break;
				case 3:
					foreach (DataGridViewRow row in dataGridView1.Rows) {
						if (row.Visible) {
							if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "None") {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
							}
							else {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
							}
						}
					}
					break;
				case 4:
					foreach (DataGridViewRow row in dataGridView1.Rows) {
						if (row.Visible) {
							if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == "OpenPort") {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
							}
							else {
								row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
							}
						}
					}
					break;
			}

			panel2_enableNextButton();
		}

		private void panel2_enableNextButton() {
			int counter = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows) {
				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value == true) {
					counter++;
				}
			}

			if (counter > 0) {
				next.Enabled = true;
			}
			else {
				next.Enabled = false;
			}

			if (counter == 1) {
				panel2_updateRecord.Enabled = true;
			}
			else {
				panel2_updateRecord.Enabled = false;
			}

			if (counter > 1) {
				panel2_mergeRecord.Enabled = true;
			}
			else {
				panel2_mergeRecord.Enabled = false;
			}

			form3Panel2_noOfRowSelected.Text = "No of findings selected: " + counter.ToString();
		}

		private void panel2_saveConfig_Click(object sender, EventArgs e) {
			this.Enabled = false;
			panel2_nextAction();

			// Database Output
			String directory = "";
			if (File.Exists(Program.state.form2Path)) {
				directory = Program.state.form2Path.Substring(0, Program.state.form2Path.LastIndexOf("\\"));
			}
			else if (Directory.Exists(Program.state.form2Path)) {
				directory = Program.state.form2Path;
			}
			CaseDatabaser caseDatabaser = new CaseDatabaser(directory);
			caseDatabaser.output();
			
			// enable
			this.Enabled = true;
			back.Enabled = true;
			panel2_enableNextButton();
			cancel.Enabled = true;
		}

		private void panel2_nextAction() {
			Program.state.form3RecordSelected = new Dictionary<int, bool>();
			Program.state.form3RecordMerged = new Dictionary<int, bool>();
			Program.state.form3RecordEdited = new Dictionary<int, bool>();
			Program.state.form3Id = new Dictionary<int, int>();
			Program.state.form3OldId = new Dictionary<int, int>();

			Program.state.form3Record = new Record.Record();
			Program.state.form3ConfirmedRecord = new Record.Record();

			foreach (DataGridViewRow row in dataGridView1.Rows) {
				Program.state.form3Record.guiAddEntry(panel2_rowToDataEntry(row));

				Program.state.form3RecordSelected[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (bool)row.Cells[(int)CellColumnIndex.SELECTED].Value;
				Program.state.form3RecordMerged[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;
				Program.state.form3RecordEdited[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
				Program.state.form3Id[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (int)row.Cells[(int)CellColumnIndex.ID].Value;
				Program.state.form3OldId[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (int)row.Cells[(int)CellColumnIndex.OLDID].Value;

				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value) {
					Program.state.form3ConfirmedRecord.guiAddEntry(panel2_rowToDataEntry(row));
				}
			}

			if (panel2_checkboxHigh.CheckState == CheckState.Checked) {
				Program.state.form3Panel2showHigh = true;
			}
			else {
				Program.state.form3Panel2showHigh = false;
			}

			if (panel2_checkboxMedium.CheckState == CheckState.Checked) {
				Program.state.form3Panel2showMedium = true;
			}
			else {
				Program.state.form3Panel2showMedium = false;
			}

			if (panel2_checkboxLow.CheckState == CheckState.Checked) {
				Program.state.form3Panel2showLow = true;
			}
			else {
				Program.state.form3Panel2showLow = false;
			}

			if (panel2_checkboxNone.CheckState == CheckState.Checked) {
				Program.state.form3Panel2showNone = true;
			}
			else {
				Program.state.form3Panel2showNone = false;
			}

			if (panel2_checkboxOpenPort.CheckState == CheckState.Checked) {
				Program.state.form3Panel2showOpenPort = true;
			}
			else {
				Program.state.form3Panel2showOpenPort = false;
			}

		}
		#endregion

		#region PANEL3 Functions
		private void panel3_initialize() {
			panel3_outputFilePathGroupBox.Hide();
			panel3_templatePathGroupBox.Hide();
			if (Program.state.form3Panel3State != State.Form3Panel3State.NULL) {
				panel3_outputFilePathGroupBox.Show();

				if (!String.IsNullOrEmpty(panel3_outputFilePath.Text)) {
					panel3_outputFilePath.Text = panel3_outputFilePath.Text.Substring(0, panel3_outputFilePath.Text.LastIndexOf('.'));
					switch (Program.state.form3Panel3State) {
						case State.Form3Panel3State.HTML:
							panel3_outputFilePath.Text += ".html";
							break;
						case State.Form3Panel3State.DOCX:
							panel3_outputFilePath.Text += ".docx";
							break;
						case State.Form3Panel3State.DOCXTEM:
							panel3_outputFilePath.Text += ".docx";
							panel3_templatePathGroupBox.Show();
							break;
						case State.Form3Panel3State.XLSX:
							panel3_outputFilePath.Text += ".xlsx";
							break;
					}
				}
				else if (!String.IsNullOrEmpty(Program.state.form3Panel3OutputPath)) {
						panel3_outputFilePath.Text = Program.state.form3Panel3OutputPath;
					}
				
				switch (Program.state.form3Panel3State) {
					case State.Form3Panel3State.HTML:
						panel3_settingLabel.Text = State.form3Panel3HTMLSelected;
						break;
					case State.Form3Panel3State.DOCX:
						panel3_settingLabel.Text = State.form3Panel3DOCXSelected;
						break;
					case State.Form3Panel3State.DOCXTEM:
						panel3_settingLabel.Text = State.form3Panel3DOCXTEMSelected;
						break;
					case State.Form3Panel3State.XLSX:
						panel3_settingLabel.Text = State.form3Panel3XLSXSelected;
						break;
				}
				
				if (Program.state.form3Panel3State == State.Form3Panel3State.DOCXTEM &&
					!String.IsNullOrEmpty(Program.state.form3Panel3TemplatePath)) {
					panel3_templatePath.Text = Program.state.form3Panel3TemplatePath;
				}
			}

			panel3_enableNextButton();
		}

		private void panel3_enableNextButton() {
			if (Program.state.form3Panel3State != State.Form3Panel3State.NULL) {
				if (!String.IsNullOrEmpty(panel3_outputFilePath.Text)) {
					if (Program.state.form3Panel3State == State.Form3Panel3State.DOCXTEM) {
						if (!String.IsNullOrEmpty(panel3_templatePath.Text)) {
							if (Directory.Exists(panel3_outputFilePath.Text.Substring(0, panel3_outputFilePath.Text.LastIndexOf('\\'))) &&
								Directory.Exists(panel3_templatePath.Text.Substring(0, panel3_templatePath.Text.LastIndexOf('\\')))) {

								// TODO: check the db for storing the case

								next.Enabled = true;
								return;
							}
						}
					}
					else {
						if (Directory.Exists(panel3_outputFilePath.Text.Substring(0, panel3_outputFilePath.Text.LastIndexOf('\\')))) {
							next.Enabled = true;
							return;
						}
					}
				}
			}
			next.Enabled = false;
		}

		private void panel3_html_Click(object sender, EventArgs e) {
			Program.state.form3Panel3State = State.Form3Panel3State.HTML;
			panel3_initialize();
			panel3_outputFilePathGroupBox.Show();
			panel3_templatePathGroupBox.Hide();
		}

		private void panel3_docxDefault_Click(object sender, EventArgs e) {
			Program.state.form3Panel3State = State.Form3Panel3State.DOCX;
			panel3_initialize();
			panel3_outputFilePathGroupBox.Show();
			panel3_templatePathGroupBox.Hide();
		}

		private void panel3_docxFromDocx_Click(object sender, EventArgs e) {
			Program.state.form3Panel3State = State.Form3Panel3State.DOCXTEM;
			panel3_initialize();
			panel3_outputFilePathGroupBox.Show();
			panel3_templatePathGroupBox.Show();
		}

		private void panel3_xlsxDefault_Click(object sender, EventArgs e) {
			Program.state.form3Panel3State = State.Form3Panel3State.XLSX;
			panel3_initialize();
			panel3_outputFilePathGroupBox.Show();
			panel3_templatePathGroupBox.Hide();
		}

		private void panel3_databasePathSaveAs_Click(object sender, EventArgs e) {
			saveFileDialog.Filter = "Report Database|*.db";
			saveFileDialog.ShowDialog();

			saveFileDialog.FileName = "";
			panel3_enableNextButton();
		}

		private void panel3_outputPathSaveAs_Click(object sender, EventArgs e) {
			switch (Program.state.form3Panel3State) {
				case State.Form3Panel3State.HTML:
					saveFileDialog.Filter = "HTML Documents|*.html";
					break;
				case State.Form3Panel3State.DOCX:
				case State.Form3Panel3State.DOCXTEM:
					saveFileDialog.Filter = "Word Documents|*.docx";
					break;
				case State.Form3Panel3State.XLSX:
					saveFileDialog.Filter = "Excel Worksheets|*.xlsx";
					break;
			}
			saveFileDialog.ShowDialog();
			panel3_outputFilePath.Text = saveFileDialog.FileName;
			saveFileDialog.FileName = "";
			panel3_enableNextButton();
		}

		private void panel3_templatePathOpen_Click(object sender, EventArgs e) {
			openFileDialog.Filter = "Word Documents|*.docx";
			openFileDialog.ShowDialog();

			panel3_templatePath.Text = openFileDialog.FileName;
			if (panel3_templatePath.Text == panel3_outputFilePath.Text) {
				panel3_templatePath.Text = "";
				MessageBox.Show("Cannot modify the template word document.");
			}
			panel3_enableNextButton();
		}

		private void panel3_nextAction() {
			Program.state.form3Panel3OutputPath = panel3_outputFilePath.Text;
			if (Program.state.form3Panel3State == State.Form3Panel3State.DOCXTEM) {
				Program.state.form3Panel3TemplatePath = panel3_templatePath.Text;
			}
		}
		#endregion

		#region PANEL4 Functions
		private void panel4_initialize() {
			if (Program.state.form3Panel3State == State.Form3Panel3State.DOCXTEM) {
				Program.state.panel4_dict = new DocxFromDocxTemplateOutputer().getStringNeedReplace(Program.state.form3Panel3TemplatePath);
				panel4_addRow(Program.state.panel4_dict);
			}
		}

		private void panel4_addRow(Dictionary<String, String> dict) {
			foreach (KeyValuePair<String, String> s in dict) {
				int n = panel4_dataGridView.Rows.Add();

				panel4_dataGridView.Rows[n].Cells[0].Value = s.Key;
				panel4_dataGridView.Rows[n].Cells[1].Value = s.Value;
			}
		}

		private void panel4_enableNextbutton() {
			int counter = 0;
			foreach (DataGridViewRow row in panel4_dataGridView.Rows) {
				if (row.Cells[1].Value != null &&
					!String.IsNullOrEmpty(row.Cells[1].Value.ToString())) {
					counter++;
				}
			}
			if (counter == panel4_dataGridView.Rows.Count) {
				next.Enabled = true;
			}
			else {
				next.Enabled = false;
			}
		}

		private void panel4_dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			panel4_enableNextbutton();
		}

		private void panel4_nextAction() {
			foreach (DataGridViewRow row in panel4_dataGridView.Rows) {
				Program.state.panel4_dict[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
			}
		}
		#endregion

		#region PANEL5 Functions
		private void panel5_nextAction() {
			back.Enabled = false;
			next.Enabled = false;
			cancel.Enabled = false;

			// Database Output
			String directory = "";
			if (File.Exists(Program.state.form2Path)) {
				directory =  Program.state.form2Path.Substring(0, Program.state.form2Path.LastIndexOf("\\"));
			}
			else if (Directory.Exists(Program.state.form2Path)){
				directory = Program.state.form2Path;
			}
			CaseDatabaser caseDatabaser = new CaseDatabaser(directory);
			caseDatabaser.output();

			// Report Output
			ReportOutputer reportOutputer = new ReportOutputer();
			switch (Program.state.form3Panel3State) {
				case State.Form3Panel3State.HTML:
					reportOutputer.output(Program.state.form3Panel3OutputPath, ref Program.state.form3ConfirmedRecord);
					break;
				case State.Form3Panel3State.DOCX:
					reportOutputer.output(Program.state.form3Panel3OutputPath, ref Program.state.form3ConfirmedRecord);
					break;
				case State.Form3Panel3State.XLSX:
					reportOutputer.output(Program.state.form3Panel3OutputPath, ref Program.state.form3ConfirmedRecord);
					break;
				case State.Form3Panel3State.DOCXTEM:
					reportOutputer.output(Program.state.form3Panel3OutputPath, Program.state.form3Panel3TemplatePath, ref Program.state.form3ConfirmedRecord, ref Program.state.panel4_dict);
					break;
			}
		}
		#endregion

	}
}
