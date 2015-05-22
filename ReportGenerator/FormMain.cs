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
using System.Threading;

using DataGridViewAutoFilter;
using System.Data.Odbc;
using System.Data.SQLite;

using System.Text.RegularExpressions;

namespace ReportGenerator {

	/// <summary>
	/// This is the FormMain Class extends Form.
	/// This is the main form through the Report Generator.
	/// </summary>
	public partial class FormMain : Form {

		/// <summary>
		/// This is the enum Panel.
		/// It is used to determine which panel is required to display.
		/// </summary>
		private enum Panel {
			FILEINPUT,
			RECORDEDIT,
			OUTPUTSELECT,
			TEMPLATESTRINGEDIT,
			LAST,
            RAWVIEW
		};

		/// <summary>
		/// This is the PanelString Class.
		/// It is used to display the text on top of the Report Generator.
		/// </summary>
		private static class PanelString {
			public static String one = "1. Import report(s)";
			public static String two = "2. Edit report field(s)";
			public static String three = "3. Output Selection";
			public static String four = "4. Template String Replace";
			public static String five = "5. Output Panel";
			public static String none = "";
		};

		/// <summary>
		/// This is the enum CellColumnIndex.
		/// It is used to recognize the index of the datagridview.
		/// </summary>
		private enum CellColumnIndex : int {
            ID = 0,
			SELECTED = 1,
			MERGED = 2,
			EDITED = 3,
			PLUGINNAME = 4,
			IPLIST = 5,
			DESCRIPTION =6,
			IMPACT = 7,
			RISKFACTOR = 8,
			RECOMMENDATION = 9,
			CVE = 10,
			BID = 11,
			OSVDB = 12,
			REFERENCELINK = 13,
			
			OLDID = 14,
			ENTRYTYPE = 15,
			DBID = 16,
            
            PLUGINVERSION=17,
            //FINDINGDETAILPOSITION=19
            PLUGINID=18,

		}
        
        //const int FILTERMAXCOL=17;
		// Variables
		Panel panel;
        //Filter filter;
        //bool panelRawView_initialized = false;

		/// <summary>
		/// This is the constructor of FormMain.
		/// </summary>
		public FormMain() {
			panel = Panel.FILEINPUT;
			InitializeComponent();
			this.KeyPreview = true;
            Program.state.amendmentDatabaserDefaultPath = Directory.GetCurrentDirectory() + "\\AmendmentDatabase.db";
           // this.Hide()
            //if (Program.state.amendmentDatabaser == null)
            //    Program.state.amendmentDatabaser = new PermanentDatabaser();
			switch (Program.state.formStartState) {
				case State.FormStartState.CREATE:
					panelFileInputShow();
					break;
				case State.FormStartState.OPEN:
					String directory = Program.state.formCaseCreateAndOpenPath.Substring(0, Program.state.formCaseCreateAndOpenPath.LastIndexOf('\\'));
					CaseDatabaser caseDatabaser = new CaseDatabaser(directory, Program.state.formCaseCreateAndOpenPath);
					if (caseDatabaser.loadRGConfigFile()) {
						panelEditRecordShow();
					}
					else {
						MessageBox.Show("Error in getting results from the database, please select the proper data files.");
						this.Hide();
						new FormCaseCreateAndOpen().ShowDialog();
						this.Close();
					}
					break;
			}
		}

		#region // PANEL Movement
		
		/// <summary>
		/// This is the buttonNext_Click method.
		/// It is used to handle the click event on button buttonNext.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonNext_Click(object sender, EventArgs e) {
			switch (panel) {
				case Panel.FILEINPUT:
					panelFileInput_nextAction();
					panelRawViewShow();
                    
					break;
                case Panel.RAWVIEW:
                    panelRawView_nextAction();
                    panelEditRecordShow();
                    break;
				case Panel.RECORDEDIT:
					panelRecordEdit_nextAction();
					panelOutputSelectShow();
					break;
				case Panel.OUTPUTSELECT:
					panelOutputSelect_nextAction();
					if (Program.state.panelOutputSelect_State == State.PanelOutputSelectState.DOCXTEM) {
						panelTemplateStringEditShow();
					}
					else {
						panelLastShow();
					}
					break;
				case Panel.TEMPLATESTRINGEDIT:
					panelTemplateStringEdit_nextAction();
					panelLastShow();

					break;
				case Panel.LAST:
					panelLast_nextAction();
                    this.Hide();
                    Program.state.initialize();
                    new FormStart().ShowDialog();
                    this.Close();
					break;
			}
		}

		/// <summary>
		/// This is the buttonBack_Click method.
		/// It is used to handle the click event on button buttonBack.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonBack_Click(object sender, EventArgs e) {
			switch (panel) {
				case Panel.FILEINPUT:
					this.Hide();
					Program.state.initialize();
					new FormCaseCreateAndOpen().ShowDialog();
					this.Close();
					break;
                case Panel.RAWVIEW:
                    panelRawView_backAction();
					panelFileInputShow();
					break;
				case Panel.RECORDEDIT:
					panelRawViewShow();
					break;
				case Panel.OUTPUTSELECT:
					panelEditRecordShow();
					break;
				case Panel.TEMPLATESTRINGEDIT:
					panelOutputSelectShow();
					break;
				case Panel.LAST:
					if (Program.state.panelOutputSelect_State == State.PanelOutputSelectState.DOCXTEM) {
						panelTemplateStringEditShow();
					}
					else {
						panelOutputSelectShow();
					}
					break;
			}
		}

		/// <summary>
		/// This is the buttonCancel_Click method.
		/// It is used to handle the click event on button buttonCancel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// This is the panelFileInputShow method.
		/// It is used to show the panel for File Input.
		/// </summary>
		private void panelFileInputShow() {
            panelRawView.Hide();
			panelRecordEdit.Hide();
			formMainBottomPanel.Hide();
			panelOutputSelect.Hide();
			panelTemplateStringEdit.Hide();
			panelLast.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.none;
			three.Text = PanelString.none;
			four.Text = PanelString.none;
			five.Text = PanelString.none;

			buttonNext.Text = "Next >";
			buttonNext.Enabled = false;
			panelFileInput_initialize();
			panelFileInput.Show();

			panel = Panel.FILEINPUT;
		}

        /// <summary>
        /// This is the panelFileInputShow method.
        /// It is used to show the panel for File Input.
        /// </summary>
        private void panelRawViewShow()
        {
            panelFileInput.Hide();
            panelRecordEdit.Hide();
            //formMainBottomPanel.Hide();
            panelOutputSelect.Hide();
            panelTemplateStringEdit.Hide();
            panelLast.Hide();

            one.Text = PanelString.one;
            two.Text = PanelString.two;
            three.Text = PanelString.none;
            four.Text = PanelString.none;
            five.Text = PanelString.none;

            buttonNext.Text = "Next >";
            buttonNext.Enabled = true;
            panelRawView_initialize();
            panelRawView.Show();
            formMainBottomPanel.Show();
            panel = Panel.RAWVIEW;
        }

		/// <summary>
		/// This is the panelEditRecordShow method.
		/// It is used to show the panel for editing the Record.
		/// </summary>
		private void panelEditRecordShow() {
			panelFileInput.Hide();
            panelRawView.Hide();
			panelOutputSelect.Hide();
			panelTemplateStringEdit.Hide();
			panelLast.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.none;
			four.Text = PanelString.none;
			five.Text = PanelString.none;

			buttonNext.Text = "Next >";
			buttonNext.Enabled = false;
			panelRecordEdit.Show();
			formMainBottomPanel.Show();
			panelRecordEdit_initialize();

			panel = Panel.RECORDEDIT;
		}

		/// <summary>
		/// This is the panelOutputSelectShow method.
		/// It is used to show the panel for output election.
		/// </summary>
		private void panelOutputSelectShow() {
			panelFileInput.Hide();
            panelRawView.Hide();
			panelRecordEdit.Hide();
			formMainBottomPanel.Hide();
			panelTemplateStringEdit.Hide();
			panelLast.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.three;
			four.Text = PanelString.none;
			five.Text = PanelString.none;

			buttonNext.Text = "Next >";
			buttonNext.Enabled = false;
			panelOutputSelect_initialize();
			panelOutputSelect.Show();

			panel = Panel.OUTPUTSELECT;
		}

		/// <summary>
		/// This is the panelTemplateStringEditShow method.
		/// It is used to show the panel for template string edition.
		/// </summary>
		private void panelTemplateStringEditShow() {
			panelFileInput.Hide();
            panelRawView.Hide();
			panelRecordEdit.Hide();
			formMainBottomPanel.Hide();
			panelOutputSelect.Hide();
			panelLast.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.three;
			four.Text = PanelString.four;
			five.Text = PanelString.none;

			buttonNext.Text = "Next >";
			buttonNext.Enabled = false;
			panelTemplateStringEdit_initialize();
			panelTemplateStringEdit.Show();

			panel = Panel.TEMPLATESTRINGEDIT;
		}

		/// <summary>
		/// This is the panelLastShow method.
		/// It is used to show the panel for click finish button and 
		/// generator the report.
		/// </summary>
		private void panelLastShow() {
			panelFileInput.Hide();
            panelRawView.Hide();
			panelRecordEdit.Hide();
			formMainBottomPanel.Hide();
			panelOutputSelect.Hide();
			panelTemplateStringEdit.Hide();

			one.Text = PanelString.one;
			two.Text = PanelString.two;
			three.Text = PanelString.three;
			if (Program.state.panelOutputSelect_State == State.PanelOutputSelectState.DOCXTEM) {
				four.Text = PanelString.four;
				five.Text = PanelString.five;
			}
			else {
				four.Text = "4. Output Panel";
			}

			buttonNext.Text = "Finish";
			panelLast.Show();

			panel = Panel.LAST;
		}
		#endregion

		#region // PANEL FILE INPUT Functions
		
		/// <summary>
		/// This is the panelFileInput_initialize method.
		/// It is used to initialize the panel panelFileInput whether
		/// the panel display to user.
		/// </summary>
		private void panelFileInput_initialize() {
			panelFileInput_checkedListBox.Items.Clear();
			if (Program.state.formMainInputPathSelected != null) {
				for (int i = 0; i < Program.state.formMainInputPathSelected.Count; i++) {
					panelFileInput_checkedListBox.Items.Add(Program.state.formMainInputPaths[i], Program.state.formMainInputPathSelected[i]);
				}
                panelFileInput_updateTreeView();
			}



			panelFileInput_enableNextButton();
		}

        private void panelFileInput_updateTreeView()
        {
            panelFileInput_treeViewFileName.BeginUpdate();
            panelFileInput_treeViewFileName.Nodes.Clear();
            Dictionary<DataEntry.EntryType, List<String>> fileNameRaw = new Dictionary<DataEntry.EntryType, List<string>>();
            for (int j = 0; j < panelFileInput_checkedListBox.Items.Count; j++)
            {
                if (panelFileInput_checkedListBox.GetItemChecked(j))
                {
                    string path = panelFileInput_checkedListBox.Items[j].ToString();
                    string fileName = path.Substring(path.LastIndexOf('\\') + 1);
                    String fileType = path.Substring(path.LastIndexOf(".") + 1);
                    switch (fileType)
                    {
                        case "nessus":
                            if (!fileNameRaw.ContainsKey(DataEntry.EntryType.NESSUS))
                                fileNameRaw.Add(DataEntry.EntryType.NESSUS,new List<string>());
                            if (!fileNameRaw[DataEntry.EntryType.NESSUS].Contains(fileName))
                                fileNameRaw[DataEntry.EntryType.NESSUS].Add(fileName);
                            break;
                        case "mbsa":
                            if (!fileNameRaw.ContainsKey(DataEntry.EntryType.MBSA))
                                fileNameRaw.Add(DataEntry.EntryType.MBSA,new List<string>());
                            if (!fileNameRaw[DataEntry.EntryType.MBSA].Contains(fileName))
                                fileNameRaw[DataEntry.EntryType.MBSA].Add(fileName);
                            break;
                        case "xml":
                            NmapParser tempNmapParser = new NmapParser();
                            if (NmapParser.isNmapXmlFile(path))
                            {
                                if (!fileNameRaw.ContainsKey(DataEntry.EntryType.NMAP))
                                    fileNameRaw.Add(DataEntry.EntryType.NMAP, new List<string>());
                                if (!fileNameRaw[DataEntry.EntryType.NMAP].Contains(fileName))
                                    fileNameRaw[DataEntry.EntryType.NMAP].Add(fileName);
                            }
                            else
                            {
                                if (!fileNameRaw.ContainsKey(DataEntry.EntryType.Acunetix))
                                    fileNameRaw.Add(DataEntry.EntryType.Acunetix,new List<string>());
                                if (!fileNameRaw[DataEntry.EntryType.Acunetix].Contains(fileName))
                                    fileNameRaw[DataEntry.EntryType.Acunetix].Add(fileName);
                            }
                            break;
                        case "txt":
                            if (NmapTxtParser.isNmapTxtFile(path))
                            {
                                if (!fileNameRaw.ContainsKey(DataEntry.EntryType.NMAP))
                                    fileNameRaw.Add(DataEntry.EntryType.NMAP, new List<string>());
                                if (!fileNameRaw[DataEntry.EntryType.NMAP].Contains(fileName))
                                    fileNameRaw[DataEntry.EntryType.NMAP].Add(fileName);
                            }
                            break;
                        case "html":
                            if (!fileNameRaw.ContainsKey(DataEntry.EntryType.Acunetix))
                                fileNameRaw.Add(DataEntry.EntryType.Acunetix,new List<string>());
                            if (!fileNameRaw[DataEntry.EntryType.Acunetix].Contains(fileName))
                                fileNameRaw[DataEntry.EntryType.Acunetix].Add(fileName);
                            break;
                        default:
                            break;
                    }
                }
            }

            int i = -1;
            foreach (DataEntry.EntryType entryType in fileNameRaw.Keys)
            {
                i++;
                String entryTypeString = DataEntry.getEntryTypeString(entryType);
                panelFileInput_treeViewFileName.Nodes.Add(new TreeNode(entryTypeString));
                foreach (String fileName in fileNameRaw[entryType])
                    panelFileInput_treeViewFileName.Nodes[i].Nodes.Add(new TreeNode(fileName));
            }
            panelFileInput_treeViewFileName.ExpandAll();
            panelFileInput_treeViewFileName.EndUpdate();
        }

		/// <summary>
		/// This is the panelFileInput_enableNextButton method.
		/// It is used to check the current status to enable the button
		/// buttonNext or not.
		/// </summary>
		private void panelFileInput_enableNextButton() {
            panelFileInput_updateTreeView();
			int counter = 0;
			for (int i = 0; i < panelFileInput_checkedListBox.Items.Count; i++) {
				if (panelFileInput_checkedListBox.GetItemChecked(i)) {
					counter++;
				}
			}

			// only enable the button buttonNext when there is at least one file selected
			buttonNext.Enabled = counter == 0 ? false : true;
		}

		/// <summary>
		/// This is the panelFileInput_buttonImportFolder_Click method.
		/// It is used to handle the click event on button panelFileInput_buttonImportFolder.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_buttonImportFolder_Click(object sender, EventArgs e) {

            //folderBrowserDialog.ShowDialog();
            //String folderPath = folderBrowserDialog.SelectedPath;

            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog folderOpenDialog = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            folderOpenDialog.IsFolderPicker = true;
            folderOpenDialog.Multiselect = true;

            if (!(folderOpenDialog.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok))
            {
                return;
            }

            // folder multiple select testing         
            foreach (string fname in folderOpenDialog.FileNames)
            {
                string folderPath = fname ;

			    if (!String.IsNullOrEmpty(folderPath)) {
                    FormMessage tempMessage = new FormMessage("Loading files...");
                    tempMessage.Show();

				    // import Nessus files (validation of nessus file may needed, only
				    // nessus v2 can be parsed.
				    String[] paths = Directory.GetFiles(folderPath, "*.nessus", SearchOption.AllDirectories);
				    foreach (String path in paths) {
					    if (!panelFileInput_checkedListBox.Items.Contains(path)) {
						    panelFileInput_checkedListBox.Items.Add(path, true);
					    }
				    }

				    // import MBSA files (validation of mbsa file may required,
				    // currently all path ended with .mbsa are considered as mbsa files
				    paths = Directory.GetFiles(folderPath, "*.mbsa", SearchOption.AllDirectories);
				    foreach (String path in paths) {
					    if (!panelFileInput_checkedListBox.Items.Contains(path)) {
						    panelFileInput_checkedListBox.Items.Add(path, true);
					    }
				    }

				    // import nessus nmap/Acunetix xml files
				    paths = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);
				    foreach (String path in paths) {
					    if (!panelFileInput_checkedListBox.Items.Contains(path)) {
						    if (NmapParser.isNmapXmlFile(path)) {
							    panelFileInput_checkedListBox.Items.Add(path, true);
						    }
                            else
                                panelFileInput_checkedListBox.Items.Add(path, true);
					    }
				    }

				    // import nmap text files
				    paths = Directory.GetFiles(folderPath, "*.txt", SearchOption.AllDirectories);
				    foreach (String path in paths) {
					    if (!panelFileInput_checkedListBox.Items.Contains(path)) {
                            if (NmapTxtParser.isNmapTxtFile(path))
                            {
                                panelFileInput_checkedListBox.Items.Add(path, true);
                            }
					    }
				    }

                    // import Acunetix html files
                    paths = Directory.GetFiles(folderPath, "*.html", SearchOption.AllDirectories);
                    foreach (String path in paths)
                    {
                        if (!panelFileInput_checkedListBox.Items.Contains(path))
                        {
                                panelFileInput_checkedListBox.Items.Add(path, true);
                        }
                    }
                    tempMessage.Close();
			    }
            }

			panelFileInput_enableNextButton();
		}

		/// <summary>
		/// This is the panelFileInput_buttonImportFile_Click method.
		/// It is used to handle the click event on button panelFileInput_buttonImportFile.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_buttonImportFile_Click(object sender, EventArgs e) {
            openFileDialog.Filter = "All Files (.*)|*.*|Acunetix Report (.html)|*.html|MBSA Report (.mbsa)|*.mbsa|Nessus Report(.nessus)|*.nessus|Nmap Report/Acunetix Report (.xml)|*.xml|Nmap Text Report (.txt)|*.txt";
			openFileDialog.Multiselect = true;
			openFileDialog.ShowDialog();
            string[] paths  = openFileDialog.FileNames;
            foreach (string path in paths)
                if (!String.IsNullOrEmpty(path) && !panelFileInput_checkedListBox.Items.Contains(path)) 
                     panelFileInput_checkedListBox.Items.Add(path, true);
            
            //String path = openFileDialog.FileName;
            //if (!String.IsNullOrEmpty(path) && !panelFileInput_checkedListBox.Items.Contains(path)) {
            //    panelFileInput_checkedListBox.Items.Add(path, true);
            //}

			panelFileInput_enableNextButton();
		}

		/// <summary>
		/// This is the panelFileInput_buttonSelectAll_Click method.
		/// It is used to handle the click event on button panelFileInput_buttonSelectAll.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_buttonSelectAll_Click(object sender, EventArgs e) {
			for (int i = 0; i < panelFileInput_checkedListBox.Items.Count; i++) {
				panelFileInput_checkedListBox.SetItemChecked(i, true);
			}

			if (panelFileInput_checkedListBox.Items.Count > 0) {
				buttonNext.Enabled = true;
			}
		}

		/// <summary>
		/// This is the panelFileInput_buttonSelectNone_Click method.
		/// It is used to handle the click event on button panelFileInput_buttonSelectNone.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_buttonSelectNone_Click(object sender, EventArgs e) {
			for (int i = 0; i < panelFileInput_checkedListBox.Items.Count; i++) {
				panelFileInput_checkedListBox.SetItemChecked(i, false);
			}

			buttonNext.Enabled = false;
		}

		/// <summary>
		/// This is the panelFileInput_buttonReverse_Click method.
		/// It is used to handle the click event on button panelFileInput_buttonReverse.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_buttonReverse_Click(object sender, EventArgs e) {
			for (int i = 0; i < panelFileInput_checkedListBox.Items.Count; i++) {
				if (panelFileInput_checkedListBox.GetItemChecked(i)) {
					panelFileInput_checkedListBox.SetItemChecked(i, false);
				}
				else {
					panelFileInput_checkedListBox.SetItemChecked(i, true);
				}
			}

			panelFileInput_enableNextButton();
		}

		/// <summary>
		/// This is the panelFileInput_buttonClear_Click method.
		/// It is used to handle the click event on button panelFileInput_buttonClear.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_buttonClear_Click(object sender, EventArgs e) {
			for (int i = 0; i < panelFileInput_checkedListBox.Items.Count; i++) {
				if (i >= 0 && panelFileInput_checkedListBox.GetItemChecked(i)) {
					panelFileInput_checkedListBox.Items.Remove(panelFileInput_checkedListBox.Items[i]);
					i--;
				}
			}
			panelFileInput_enableNextButton();
		}

		/// <summary>
		/// This is the panelFileInput_checkedListBox_Click method.
		/// It is used to handle the click event on checkedListBox
		/// panelFileInput_checkedListBox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_checkedListBox_Click(object sender, EventArgs e) {
			panelFileInput_enableNextButton();
		}

		/// <summary>
		/// This is the panelFileInput_checkedListBox_SelectedIndexChanged method.
		/// It is used to handle the selected index change event of checkedListBox
		/// panelFileInput_checkedListBox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_checkedListBox_SelectedIndexChanged(object sender, EventArgs e) {
			panelFileInput_enableNextButton();
		}

		/// <summary>
		/// This is the panelFileInput_checkedListBox_KeyPress method.
		/// It is used to handle the key press event of checkedListBox
		/// panelFileInput_checkedListBox. (here, pressing space would change 
		/// the checked state of file path
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelFileInput_checkedListBox_KeyPress(object sender, KeyPressEventArgs e) {
			panelFileInput_enableNextButton();
		}

		/// <summary>
		/// This is the panelFileInput_nextAction method.
		/// It is used to process the action when button buttonNext is clicked.
		/// </summary>
		private void panelFileInput_nextAction() {
            //use to check any changes
            string tempOldPermanentDatabasePath = Program.state.amendmentDatabaserDefaultPath;

            // set permanent database path
            new FormChoosePermanentDatabasePath().ShowDialog();

			List<String> tempPaths = new List<String>();
			List<bool> tempPathSelected = new List<bool>();
			List<String> tempSelectedPath = new List<String>();
			
			// store the current filepaths and boolean value of each
			// path selected or not
           
			for (int i = 0; i < panelFileInput_checkedListBox.Items.Count; i++) {
				tempPaths.Add(new String(panelFileInput_checkedListBox.Items[i].ToString().ToCharArray()));
				tempPathSelected.Add(panelFileInput_checkedListBox.GetItemChecked(i));
				if (panelFileInput_checkedListBox.GetItemChecked(i)) {
					tempSelectedPath.Add(new String(panelFileInput_checkedListBox.Items[i].ToString().ToCharArray()));
				}
			}

			// compared with the old values (if exists)
			if (!(Program.state.formMainInputPaths == null || Program.state.formMainInputPaths.Count == 0)) {
				List<String> tempSelectedPath2 = new List<String>();
				for (int i = 0; i < Program.state.formMainInputPaths.Count; i++) {
					if (Program.state.formMainInputPathSelected[i]) {
						tempSelectedPath2.Add(Program.state.formMainInputPaths[i]);
					}
				}

				bool unchange = true;
				for (int i = 0; i < tempSelectedPath2.Count; i++) {
					if (!tempSelectedPath.Contains(tempSelectedPath2[i])) {
						unchange = false;
						break;
					}
				}

                for (int i = 0; i < tempSelectedPath.Count; i++)
                {
                    if (!tempSelectedPath2.Contains(tempSelectedPath[i]))
                    {
                        unchange = false;
                        break;
                    }
                }

                //check amendent database path changed or not
                if (tempOldPermanentDatabasePath.CompareTo(Program.state.amendmentDatabaserDefaultPath)!=0)
                    unchange = false;

				// if selected path remains unchanged, do nothing
				// otherwise create another database file on next panel initialization
				if (!unchange || tempSelectedPath2.Count != tempSelectedPath.Count) {
					if (File.Exists(Program.state.panelRecordEdit_DatabasePath)) {
						File.Delete(Program.state.panelRecordEdit_DatabasePath);
					}
					Program.state.panelRecordEdit_DatabasePath = "";
					Program.state.panelRecordEdit_RecordSelected = null;
				}
			}

			Program.state.formMainInputPaths = tempPaths;
			Program.state.formMainInputPathSelected = tempPathSelected;



            storeRecordToDataBase();
		}

        private void storeRecordToDataBase(){
            // get records from previous selected paths if
            // the database path doesn't exist
            if (String.IsNullOrEmpty(Program.state.panelRecordEdit_DatabasePath))
            {
                List<String> tempPaths = new List<string>();
                for (int i = 0; i < Program.state.formMainInputPaths.Count; i++)
                {
                    if (Program.state.formMainInputPathSelected[i])
                    {
                        tempPaths.Add(Program.state.formMainInputPaths[i]);
                    }
                }

                // get Data
                Program.state.panelRecordEdit_record = new ReportInputer().getData(tempPaths);
                foreach (ReportGenerator.Record.Record.OpenPortTableItemData data in Program.state.panelRecordEdit_record.getOpenPortTableItem().Values)
                    data.makeResultOpenPort();

                Program.state.fileNames = Program.state.panelRecordEdit_record.getFileNameRaw();

                String directory = "";
                if (File.Exists(Program.state.formCaseCreateAndOpenPath))
                {
                    directory = Program.state.formCaseCreateAndOpenPath.Substring(0, Program.state.formCaseCreateAndOpenPath.LastIndexOf("\\"));
                }
                else if (Directory.Exists(Program.state.formCaseCreateAndOpenPath))
                {
                    directory = Program.state.formCaseCreateAndOpenPath;
                }

                Program.state.panelRecordEdit_DatabasePath = directory + "\\"+Program.state.ProjectName+"-"+"Data" + DateTime.Now.ToString("HHmmss_ddMMyy") + ".db";
                Program.state.panelRecordEdit_recordDatabaser = new Databaser(Program.state.panelRecordEdit_DatabasePath, ref Program.state.panelRecordEdit_record);

                // action to save the database
                Program.state.panelRecordEdit_isSaveDatabase = false;

                Program.state.panelRecordEdit_recordDatabaser.storeRecord();
                //ThreadStart thread_delegate = new ThreadStart(Program.state.panelRecordEdit_recordDatabaser.storeRecord);
                //Thread t = new Thread(thread_delegate);
                //t.Start();

                //this.Enabled = false;
                ////FormMessage tempMessage = new FormMessage("Creating Database...");
                ////tempMessage.ShowDialog();


                //while (!Program.state.panelRecordEdit_isSaveDatabase)
                //{
                //    Application.DoEvents();
                //    Thread.Sleep(0);
                //}
                this.Enabled = true;
                this.TopMost = true;
                this.TopMost = false;
                //Program.state.formMessageWithProgressBar.Close();
                //tempMessage.Close();

                //Program.state.form3Databaser.storeRecord(ref Program.state.form3Record);

            }
            else
            {
                Program.state.panelRecordEdit_record = Program.state.panelRecordEdit_recordDatabaser.getRecord();
                Program.state.panelRecordEdit_isSaveDatabase = true;
            }
            /* @@@@@
            while (!Program.state.panelRecordEdit_isSaveDatabase)
            {
            }
            */
        }
		#endregion

        #region // PANEL RAW VIEW Functions

        private void panelRawView_backAction()
        {
            panelRawView_dataGridViewMBSA.Hide();
            panelRawView_dataGridViewNmap.Hide();
            panelRawView_dataGridViewNessus.Hide();
            panelRawView_dataGridViewAcunetix.Hide();
            panelRawView_tabControl.Hide();
            panelRawView_tableLayoutPanel.Hide();
        }

        private void panelRawView_nextAction()
        {
            panelRawView_dataGridViewMBSA.Hide();
            panelRawView_dataGridViewNmap.Hide();
            panelRawView_dataGridViewNessus.Hide();
            panelRawView_dataGridViewAcunetix.Hide();
            panelRawView_tabControl.Hide();
            panelRawView_tableLayoutPanel.Hide();
        }

        private void panelRawView_initialize()
        {
                panelRawView_dataGridViewMBSA.BindingContextChanged += new EventHandler(panelRawView_dataGridViewMBSA_BindingContextChanged);
                panelRawView_dataGridViewNmap.BindingContextChanged += new EventHandler(panelRawView_dataGridViewNmap_BindingContextChanged);
                panelRawView_dataGridViewNessus.BindingContextChanged += new EventHandler(panelRawView_dataGridViewNessus_BindingContextChanged);
                panelRawView_dataGridViewAcunetix.BindingContextChanged += new EventHandler(panelRawView_dataGridViewAcunetix_BindingContextChanged);
                //           panelRawView_dataGridViewMBSA.SortCompare += new DataGridViewSortCompareEventHandler(panelRawView_dataGridViewMBSA_SortCompare);

                panelRawView_dataGridViewNessus.Enabled = false;
                panelRawView_dataGridViewMBSA.Enabled = false;
                panelRawView_dataGridViewNmap.Enabled = false;
                panelRawView_dataGridViewAcunetix.Enabled = false;

                panelRawView_dataGridViewNessus.SuspendLayout();
                panelRawView_dataGridViewMBSA.SuspendLayout();
                panelRawView_dataGridViewNmap.SuspendLayout();
                panelRawView_dataGridViewAcunetix.SuspendLayout();

                panelRawView_dataGridViewMBSA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                panelRawView_dataGridViewNmap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                panelRawView_dataGridViewNessus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                panelRawView_dataGridViewAcunetix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                panelRawView_dataGridViewMBSA.DoubleBuffered(true);
                panelRawView_dataGridViewNmap.DoubleBuffered(true);
                panelRawView_dataGridViewNessus.DoubleBuffered(true);
                panelRawView_dataGridViewAcunetix.DoubleBuffered(true);

                panelRawView_dataGridViewMBSA.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                panelRawView_dataGridViewNmap.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                panelRawView_dataGridViewNessus.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                panelRawView_dataGridViewAcunetix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                
                panelRawView_dataGridViewMBSA.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawMBSA();
                panelRawView_dataGridViewNmap.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawNmap();
                panelRawView_dataGridViewNessus.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawNessus();
                panelRawView_dataGridViewAcunetix.DataSource =  Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawAcunetix();

                panelRawView_dataGridViewNessus.ResumeLayout();
                panelRawView_dataGridViewMBSA.ResumeLayout();
                panelRawView_dataGridViewNmap.ResumeLayout();
                panelRawView_dataGridViewAcunetix.ResumeLayout();

                panelRawView_dataGridViewNessus.Enabled = true;
                panelRawView_dataGridViewMBSA.Enabled = true;
                panelRawView_dataGridViewNmap.Enabled = true;
                panelRawView_dataGridViewAcunetix.Enabled = true;

                //panelRawView_dataGridViewMBSA.Columns[(int)CellColumnIndex.RISKFACTOR - 3].SortMode = DataGridViewColumnSortMode.Automatic;
                //panelRawView_dataGridViewNmap.Columns[(int)CellColumnIndex.RISKFACTOR - 3].SortMode = DataGridViewColumnSortMode.Automatic;
                //panelRawView_dataGridViewNessus.Columns[(int)CellColumnIndex.RISKFACTOR - 3].SortMode = DataGridViewColumnSortMode.Automatic;

                panelRawView_treeViewFileName.BeginUpdate();
                panelRawView_treeViewFileName.Nodes.Clear();
                Dictionary<DataEntry.EntryType, List<String>> fileNameRaw = Program.state.fileNames;
                int i = -1;
                foreach (DataEntry.EntryType entryType in fileNameRaw.Keys)
                {
                    i++;
                    String entryTypeString = DataEntry.getEntryTypeString(entryType);
                    panelRawView_treeViewFileName.Nodes.Add(new TreeNode(entryTypeString));
                    foreach (String fileName in fileNameRaw[entryType])
                        panelRawView_treeViewFileName.Nodes[i].Nodes.Add(new TreeNode(fileName));
                }
                panelRawView_treeViewFileName.ExpandAll();
                panelRawView_treeViewFileName.EndUpdate();
            

            panelRawView_dataGridViewMBSA.Show();
            panelRawView_dataGridViewNmap.Show();
            panelRawView_dataGridViewNessus.Show();
            panelRawView_dataGridViewAcunetix.Show();
            panelRawView_tabControl.Show();
            panelRawView_tableLayoutPanel.Show();
            panelRawView_comboBoxFilter.SelectedIndex = 0;
            panelRawVIew_enableNextButton();
        }

        /// <summary>
        /// This is the panelFileInput_enableNextButton method.
        /// It is used to check the current status to enable the button
        /// buttonNext or not.
        /// </summary>
        private void panelRawVIew_enableNextButton()
        {
            buttonNext.Enabled = true;
        }
        #endregion

        #region // PANEL RECORD EDIT Functions

        /// <summary>
		/// This is the panelFileInput_initialize method.
		/// It is used to initialize the panel panelFileInput whenever
		/// this panel display to user.
		/// </summary>
		private void panelRecordEdit_initialize() {
            if (Program.state.panelRecordEdit_RecordSelected == null)
            {
                new FormOpenPortTable().ShowDialog();
                removeDuplicate();
                Program.state.panelRecordEdit_record = Program.state.panelRecordEdit_recordDatabaser.getRecord();
            }
            panelRecordEdit_comboBoxFilter.SelectedIndex = 0;
            panelRecordEdit_comboBoxFilterMode.SelectedIndex = 0;
            panelRecordEdit_comboBoxBottom.SelectedIndex = 0;
            panelRecordEdit_comboBoxCase.SelectedIndex = 0;
			// clear the record shown on dataGridView
			panelRecordEdit_dataGridView.Rows.Clear();

            //filter = new Filter(FILTERMAXCOL);
			// fill id, oldid and database id on the dataGridView

            panelRecordEdit_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            panelRecordEdit_dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            panelRecordEdit_dataGridView.DoubleBuffered(true);
			// fill other cell value on the dataGridView
            panelRecordEdit_dataGridView.Enabled = false;
            panelRecordEdit_dataGridView.SuspendLayout();
			panelRecordEdit_fillDataGridView();
            panelRecordEdit_dataGridView_reloadBackgroundColor();
            panelRecordEdit_dataGridView.ResumeLayout();
            panelRecordEdit_dataGridView.Enabled = true;
			#region // show Findings referenced to CheckBox State
			if (Program.state.panelRecordEdit_showHigh) {
				panelRecordEdit_checkboxHigh.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxHigh.CheckState = CheckState.Unchecked;
			}

			if (Program.state.panelRecordEdit_showMedium) {
				panelRecordEdit_checkboxMedium.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxMedium.CheckState = CheckState.Unchecked;
			}

			if (Program.state.panelRecordEdit_showLow) {
				panelRecordEdit_checkboxLow.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxLow.CheckState = CheckState.Unchecked;
			}

			if (Program.state.panelRecordEdit_showNone) {
				panelRecordEdit_checkboxNone.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxNone.CheckState = CheckState.Unchecked;
			}

			if (Program.state.panelRecordEdit_showOpenPort) {
				panelRecordEdit_checkboxOpenPort.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxOpenPort.CheckState = CheckState.Unchecked;
			}

			if (Program.state.panelRecordEdit_showNessus) {
				panelRecordEdit_checkboxNessus.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxNessus.CheckState = CheckState.Unchecked;
			}

			if (Program.state.panelRecordEdit_showMbsa) {
				panelRecordEdit_checkboxMbsa.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxMbsa.CheckState = CheckState.Unchecked;
			}

			if (Program.state.panelRecordEdit_showNmap) {
				panelRecordEdit_checkboxNmap.CheckState = CheckState.Checked;
			}
			else {
				panelRecordEdit_checkboxNmap.CheckState = CheckState.Unchecked;
			}
			#endregion

			panelRecordEdit_checkboxCheckedChangedAction();
			panelRecordEdit_checkboxTypeCheckedChangedAction();
			
			// save config first
			if (Program.state.panelRecordEdit_RecordSelected == null) {
				saveConfig();

				while (!Program.state.panelRecordEdit_isSaveConfig) {
				}
			}

            //panelRecordEdit_dataGridView_reloadBackgroundColor();
			// check enable next button
			panelRecordEdit_enableNextButton();

            //DataTable data = new DataTable();
            //data.CreateDataReader
            //data.ReadXml(@"..\..\..\..\..\TestData.xml");
            //BindingSource dataSource = new BindingSource(data, null);
            //panelRecordEdit_dataGridView.DataSource = dataSource;
            //trial
            // Create
            //OdbcConnection conn = new OdbcConnection("Data source=" + Program.state.panelRecordEdit_DatabasePath + ";Version=3;New=True;Compress=True;");

            //// Open
            //OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter();
            //odbcDataAdapter.SelectCommand = new OdbcCommand("Select * from Record;", conn);
            //DataTable dataTable = new DataTable();
            //odbcDataAdapter.Fill(dataTable);

            ////odbcDataAdapter.FillSchema(dataTable, SchemaType.Source);

            ////OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(odbcDataAdapter);


            //BindingSource bSource = new BindingSource();
            //bSource.DataSource = dataTable;
            //panelRecordEdit_dataGridView.DataSource = bSource;


//            panelRecordEdit_dataGridView.BindingContextChanged += new
//EventHandler(panelRecordEdit_dataGridView_BindingContextChanged);

//            panelRecordEdit_dataGridView.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceEditedRecord();
//            for (int n = 0; n < panelRecordEdit_dataGridView.RowCount; n++)
//            {
//                panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = false;
//                //hard code
//                panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DBID].Value = int.Parse(panelRecordEdit_objectToString(panelRecordEdit_dataGridView.Rows[n].Cells[17].Value));
//            }
		}

		/// <summary>
		/// This is the panelRecordEdit_fillCellValue method.
		/// It is used to fill the dataGridView with given values.
		/// </summary>
		/// <param name="n">row index of the dataGridView</param>
		/// <param name="selected">boolean value determined the row is selected or not</param>
		/// <param name="merged">boolean value determined the row is merged or not</param>
		/// <param name="edited">boolean value determined the row is edite or not</param>
		/// <param name="pluginName">pluginName of that row</param>
		/// <param name="ipList">ipList of that row</param>
		/// <param name="description">description of that row</param>
		/// <param name="impact">impact of that row</param>
		/// <param name="riskFactor">RiskFactor of that row</param>
		/// <param name="recommendation">recommendation of that row</param>
		/// <param name="cveList">cveList of that row</param>
		/// <param name="bidList">bidList of that tow</param>
		/// <param name="osvdbList">osvdbList of that row</param>
		/// <param name="referenceLink">referenceLink of that row</param>
		/// <param name="entryType">EntryType of that row</param>
		private void panelRecordEdit_fillCellValue(int n,
												   Object selected, 
												   Object merged,
												   Object edited,
												   Object pluginName,
												   Object ipList,
												   Object description,
												   Object impact,
                                                   RiskFactor riskFactor,
												   Object recommendation,
												   Object cveList,
												   Object bidList,
												   Object osvdbList,
												   Object referenceLink,
												   Object entryType,
                                                   
                                                   Object pluginversion,
                                                   Object pluginID)           //@@@@@
        {
            if (selected != null)
			    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = selected;
			if (merge != null)
                panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.MERGED].Value = merged;
			if (edited !=null)
                panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.EDITED].Value = edited;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.PLUGINNAME].Value = pluginName;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.IPLIST].Value = ipList;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DESCRIPTION].Value = description;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.IMPACT].Value = impact;
            panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.PLUGINVERSION].Value = pluginversion;
            panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.PLUGINID].Value = pluginID;

            if (riskFactor == RiskFactor.OPEN)
            {
                panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.RISKFACTOR].Value = "OpenPort";
            }
            else
            {
                panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.RISKFACTOR].Value = RiskFactorFunction.getEnumString(riskFactor);
            }
            //panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.RISKFACTOR].Value = RiskFactorString;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.RECOMMENDATION].Value = recommendation;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.CVE].Value = cveList;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.BID].Value = bidList;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.OSVDB].Value = osvdbList;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.REFERENCELINK].Value = referenceLink;
			panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.ENTRYTYPE].Value = entryType;



        }

		/// <summary>
		/// This is the panelRecordEdit_fillDataGridView method.
		/// It is used to fill the whole dataGridView.
		/// </summary>
		private void panelRecordEdit_fillDataGridView() {
            //List<DataEntry> entryList = Program.state.panelRecordEdit_recordDatabaser.getEntryFromDatabaseId();

            //foreach (DataEntry entry in entryList)
            //{
            //    int n = panelRecordEdit_dataGridView.Rows.Add();

            //    bool selected = false;
            //    bool merged = false;
            //    bool edited = false;

            //    if (Program.state.panelRecordEdit_RecordSelected != null)
            //    {
            //        selected = Program.state.panelRecordEdit_RecordSelected[n];
            //        merged = Program.state.panelRecordEdit_RecordMerged[n];
            //        edited = Program.state.panelRecordEdit_RecordEdited[n];
            //    }

            //    string name = entry.getPluginName();
            //    string ip = entry.getIp();
            //    string description = entry.getDescription();
            //    string impact = entry.getImpact();
            //    //string riskFactorString = "";
            //    RiskFactor riskFactor = entry.getRiskFactor();
            //    //if (riskFactor == RiskFactor.OPEN) 
            //    //    riskFactorString = "OpenPort";
            //    //else 
            //    //    riskFactorString = RiskFactorFunction.getEnumString(riskFactor);
            //    string recommendation = entry.getRecommendation();
            //    string cve = entry.getCve();
            //    string bid = entry.getBid();
            //    string osvdb = entry.getOsvdb();
            //    string referenceLink = entry.getReferenceLink();
            //    string type = entry.getEntryTypeString();
            //    panelRecordEdit_fillCellValue(n,
            //                                  selected,
            //                                  merged,
            //                                  edited,
            //                                  name,
            //                                  ip,
            //                                  description,
            //                                  impact,
            //                                  riskFactor,
            //                                  recommendation,
            //                                  cve,
            //                                  bid,
            //                                  osvdb,
            //                                  referenceLink,
            //                                  type);
            //}


            if (Program.state.panelRecordEdit_RecordSelected != null)
            {
                foreach (int key in Program.state.panelRecordEdit_RecordSelected.Keys)
                {
                    int n = panelRecordEdit_dataGridView.Rows.Add();
                    
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = Program.state.panelRecordEdit_RecordSelected[key];
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.MERGED].Value = Program.state.panelRecordEdit_RecordMerged[key];
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.EDITED].Value = Program.state.panelRecordEdit_RecordEdited[key];
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.ID].Value = Program.state.dataGridView_Id[key];
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.OLDID].Value = Program.state.dataGridView_OldId[key];
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DBID].Value = Program.state.dataGridView_DatabaseId[key];
                }
                //for (int i = 0; i < Program.state.panelRecordEdit_RecordSelected.Count; i++)
                //{
                //    int n = panelRecordEdit_dataGridView.Rows.Add();

                //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = Program.state.panelRecordEdit_RecordSelected[n];
                //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.MERGED].Value = Program.state.panelRecordEdit_RecordMerged[n];
                //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.EDITED].Value = Program.state.panelRecordEdit_RecordEdited[n];
                //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.ID].Value = Program.state.dataGridView_Id[n];
                //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.OLDID].Value = Program.state.dataGridView_OldId[n];
                //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DBID].Value = Program.state.dataGridView_DatabaseId[n];
                //}
            }
            else
            {
                for (int i = 0; i < Program.state.panelRecordEdit_record.getCount(); i++)
                {
                    int n = panelRecordEdit_dataGridView.Rows.Add(); //n=number of row in the data grid
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.MERGED].Value = false;
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.EDITED].Value = false;
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.ID].Value = n + 1;
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.OLDID].Value = n + 1;
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DBID].Value = n + 1;
                }
            }


			for (int n = 0; n < panelRecordEdit_dataGridView.Rows.Count; n++){
				DataEntry entry = Program.state.panelRecordEdit_recordDatabaser.getEntryFromDatabaseId(int.Parse(panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DBID].Value.ToString()));


                
                if (entry == null)
                {
                    //panelRecordEdit_dataGridView.Rows.RemoveAt(n);
                    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                    panelRecordEdit_dataGridView.Rows[n].Visible = false;
                    if (Program.state.panelRecordEdit_RecordSelected!= null)
                        Program.state.panelRecordEdit_RecordSelected[n] = false;
                    //n--;
                    continue;
                }
				bool selected = false;
				bool merged = false;
				bool edited = false;

				if (Program.state.panelRecordEdit_RecordSelected != null) {
					selected = Program.state.panelRecordEdit_RecordSelected[n];
					merged = Program.state.panelRecordEdit_RecordMerged[n];
					edited = Program.state.panelRecordEdit_RecordEdited[n];
				}

                string name = entry.getPluginName();
                string ip = entry.getIp();
                string description = entry.getDescription();
                string impact = entry.getImpact();
                //string riskFactorString = "";
                RiskFactor riskFactor = entry.getRiskFactor();
                //if (riskFactor == RiskFactor.OPEN) 
                //    riskFactorString = "OpenPort";
                //else 
                //    riskFactorString = RiskFactorFunction.getEnumString(riskFactor);
                string recommendation = entry.getRecommendation();
                string cve = entry.getCve();
                string bid = entry.getBid();
                
                string osvdb = entry.getOsvdb();
                string referenceLink = entry.getReferenceLink();
                string type = entry.getEntryTypeString();

                string pluginversion = entry.getpluginversion();
                string pluginID = entry.getpluginID();

				panelRecordEdit_fillCellValue(n,
											  selected,
											  merged,
											  edited,
											  name,
											  ip,
											  description,
											  impact,
											  riskFactor,
											  recommendation,
											  cve,
											  bid,
											  osvdb,
											  referenceLink,
											  type,
                                              pluginversion,
                                              pluginID);                //@@@@@

                ////fill filter
                //int id = int.Parse(panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.ID].Value.ToString());
                //if (selected)
                //    filter.addData((int)CellColumnIndex.SELECTED, "selected", id);
                //else
                //    filter.addData((int)CellColumnIndex.SELECTED, "unselected", id);
                //if (merged)
                //    filter.addData((int)CellColumnIndex.MERGED, "merged", id);
                //else
                //    filter.addData((int)CellColumnIndex.MERGED, "unmerged", id);
                //if (edited)
                //   filter.addData((int)CellColumnIndex.EDITED, "edited", id);
                //else
                //   filter.addData((int)CellColumnIndex.EDITED, "unedited", id);
                //filter.addData((int)CellColumnIndex.PLUGINNAME, name, id);
                //filter.addData((int)CellColumnIndex.IPLIST, ip, id);
                //filter.addData((int)CellColumnIndex.DESCRIPTION, description, id);
                //filter.addData((int)CellColumnIndex.IMPACT, impact, id);
                //filter.addData((int)CellColumnIndex.RISKFACTOR, riskFactorString, id);
                //filter.addData((int)CellColumnIndex.RECOMMENDATION, recommendation, id);
                //filter.addData((int)CellColumnIndex.CVE, cve, id);
                //filter.addData((int)CellColumnIndex.BID, bid, id);
                //filter.addData((int)CellColumnIndex.OSVDB, osvdb, id);
                //filter.addData((int)CellColumnIndex.REFERENCELINK, referenceLink, id);
                //filter.addData((int)CellColumnIndex.ENTRYTYPE, type, id);
			}
		}

		/// <summary>
		/// This is the panelRecordEdit_addRowForMerge method.
		/// It is used to add a row on dataGridView with given DataEntry.
		/// </summary>
		/// <param name="entry">DataEntry append to the dataGridView</param>
        //private void panelRecordEdit_addRowForMerge(DataEntry entry) {
        //    int n = panelRecordEdit_dataGridView.Rows.Add();

        //    panelRecordEdit_fillCellValue(n,
        //                         false,
        //                         true,
        //                         false,
        //                         entry.getPluginName(),
        //                         entry.getIp(),
        //                         entry.getDescription(),
        //                         entry.getImpact(),
        //                         entry.getRiskFactor(),
        //                         entry.getRecommendation(),
        //                         entry.getCve(),
        //                         entry.getBid(),
        //                         entry.getOsvdb(),
        //                         entry.getReferenceLink(),
        //                         entry.getEntryTypeString());

        //    // here, set new id and oldid on merge (as new finding)
        //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.ID].Value = n + 1;
        //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.OLDID].Value = n + 1;

        //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DBID].Value = 
        //        Program.state.panelRecordEdit_recordDatabaser.guiInsertMergeRecordToDatabase(entry);
        //    panelRecordEdit_dataGridView_reloadBackgroundColor();
        //}

        ///// <summary>
        ///// This is the panelRecordEdit_addRowForUpdate method.
        ///// It is used to add a row on dataGridView with given DataEntry and
        ///// oldId for reference.
        ///// </summary>
        ///// <param name="entry">DataEntry append to the dataGridView</param>
        ///// <param name="oldId">integer value represents the reference to each row id</param>
        //private void panelRecordEdit_addRowForUpdate(DataEntry entry, int oldId)
        //{
        //    int n = panelRecordEdit_dataGridView.Rows.Add();

        //    panelRecordEdit_fillCellValue(n,
        //                                  false,
        //                                  false,
        //                                  true,
        //                                  entry.getPluginName(),
        //                                  entry.getIp(),
        //                                  entry.getDescription(),
        //                                  entry.getImpact(),
        //                                  entry.getRiskFactor(),
        //                                  entry.getRecommendation(),
        //                                  entry.getCve(),
        //                                  entry.getBid(),
        //                                  entry.getOsvdb(),
        //                                  entry.getReferenceLink(),
        //                                  entry.getEntryTypeString());
        //    panelRecordEdit_dataGridView.Rows[n].Visible = true;
        //    // here, set id to new and oldId from given oldId
        //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.ID].Value = n + 1;
        //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.OLDID].Value = oldId;

        //    panelRecordEdit_dataGridView.Rows[n].Cells[(int)CellColumnIndex.DBID].Value =
        //        Program.state.panelRecordEdit_recordDatabaser.guiInsertUpdateRecordToDatabase(entry, oldId);
        //    panelRecordEdit_dataGridView_reloadBackgroundColor();
        //}

		/// <summary>
		/// This is the panelRecordEdit_rowToDataEntry method.
		/// </summary>
		/// <param name="row">DataGridViewRow that being transformed to DataEntry</param>
		/// <returns>DataEntry of given row from dataGridView.</returns>
		private DataEntry panelRecordEdit_rowToDataEntry(DataGridViewRow row) {
            //int id = int.Parse(panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.DBID].Value));
            //return Program.state.panelRecordEdit_recordDatabaser.getEntryFromDatabaseId(id);

            String tempPluginName = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.PLUGINNAME].Value);
            String tempIpList = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.IPLIST].Value);
            String tempDescription = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.DESCRIPTION].Value);
            String tempImpact = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.IMPACT].Value);
            String tempRecommendation = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.RECOMMENDATION].Value);
            String tempReferenceLink = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.REFERENCELINK].Value);
            String tempEntryType = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.ENTRYTYPE].Value);

            String temppluginversion = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.PLUGINVERSION].Value);         //@@@@@
            String temppluginID = panelRecordEdit_objectToString(row.Cells[(int)CellColumnIndex.PLUGINID].Value);         //@@@@@



            #region // CVE/BID/OSVDB String to CVE/BID/OSVDB List
            List<String> cveList = row.Cells[(int)CellColumnIndex.CVE].Value.ToString().Split(',').ToList<String>();
            List<String> bidList = row.Cells[(int)CellColumnIndex.BID].Value.ToString().Split(',').ToList<String>();
            List<String> osvdbList = row.Cells[(int)CellColumnIndex.OSVDB].Value.ToString().Split(',').ToList<String>();

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


            return new GuiDataEntry(tempPluginName,
                                    tempIpList,
                                    tempDescription,
                                    tempImpact,
                                    RiskFactorFunction.getEnum(row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString()),
                                    tempRecommendation,
                                    cveList,
                                    bidList,
                                    osvdbList,
                                    tempReferenceLink,
                                    tempEntryType,
                                    temppluginversion,
                                    temppluginID);          //@@@@@
		}

		/// <summary>
		/// This is the panelRecordEdit_objectToString method.
		/// return string of given object.
		/// </summary>
		/// <param name="o">the object being transformed to string.</param>
		/// <returns>string from the object o.</returns>
		private String panelRecordEdit_objectToString(Object o) {
			if (o == null) {
				return "";
			}
			return o.ToString();
		}

		/// <summary>
		/// This is the panelRecordEdit_buttonSelectAll_Click method.
		/// It is used to handle the click event on button panelRecordEdit_buttonSelectAll.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_buttonSelectAll_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				if (row.Visible) {
                    //DataGridViewCell cell = row.Cells[(int)CellColumnIndex.SELECTED];
					row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
					row.Selected = true;
				}
				else {
					row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					row.Selected = false;
				}
			}

			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_buttonSelectNone_Click method.
		/// It is used to handle the click event on button panelRecordEdit_buttonSelectNone.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_buttonSelectNone_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
				row.Selected = false;
			}

            panelRecordEdit_comboBoxBottom.SelectedIndex = 0;

			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_buttonSelectMerge_Click method.
		/// It is used to handle the click event on button panelRecordEdit_buttonSelectMerge.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_buttonSelectMerge_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				if (row.Visible) {
					if ((bool)row.Cells[(int)CellColumnIndex.MERGED].Value == true) {
						row.Selected = true;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
                       
					}
					else {
						row.Selected = false;
                        
					}
				}
			}

			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_buttonSelectUpdate_Click method.
		/// It is used to handle the click event on button panelRecordEdit_buttonSelectUpdate.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_buttonSelectUpdate_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				if (row.Visible) {
					if ((bool)row.Cells[(int)CellColumnIndex.EDITED].Value == true) {
						row.Selected = true;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
					else {
						row.Selected = false;
					}
				}
			}

			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_buttonSelectReverse_Click method.
		/// It is used to handle the click event on button panelRecordEdit_buttonSelectReverse.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_buttonSelectReverse_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				if (row.Visible) {
					if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value == false) {
						row.Selected = true;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
					else {
						row.Selected = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}

			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_buttonMergeRecord_Click method.
		/// It is used to handle the click event on button panelRecordEdit_buttonMergeRecord.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_buttonMergeRecord_Click(object sender, EventArgs e) {
			int counter = 0;
			List<int> indexArray = new List<int>();
			List<DataEntry> dataArray = new List<DataEntry>();

            Dictionary<int, DataEntry> undoList = new Dictionary<int, DataEntry>();
            Dictionary<int, bool> undoEdited = new Dictionary<int, bool>();
            Dictionary<int, bool> undoMegered = new Dictionary<int, bool>();

			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value) {
					counter++;
					indexArray.Add(row.Index);
					dataArray.Add(panelRecordEdit_rowToDataEntry(row));
                    

                    int dbid = int.Parse(row.Cells[(int)CellColumnIndex.DBID].Value.ToString());
                    undoEdited[dbid] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
                    undoMegered[dbid] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;    
                    undoList[dbid] = panelRecordEdit_rowToDataEntry(row);
				}
			}

			this.Enabled = false;
            if(counter > 0)
			    new FormEditFinding(indexArray, dataArray).ShowDialog();

			this.Enabled = true;
            this.TopMost = true;
            this.TopMost = false;

			// if button "OK" is clicked, a finding should be append to the
			// dataGridView
            

			if (Program.state.formEditFindingState == State.FormEditFindingState.OK) {
				//panelRecordEdit_addRowForMerge(Program.state.formEditFindingEntry);
                panelRecordEdit_deleteRowForMerge(Program.state.formEditFindingEntry, indexArray);
                //foreach (int index in indexArray) {
                //    panelRecordEdit_dataGridView.Rows[index].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                //}
				panelRecordEdit_checkboxCheckedChangedAction();
				panelRecordEdit_checkboxTypeCheckedChangedAction();
				panelRecordEdit_enableNextButton();



                Program.state.panelRecordEdit_undoEdited = undoEdited;
                Program.state.panelRecordEdit_undoMegered = undoMegered;
                Program.state.panelRecordEdit_undoDataEntryList = undoList;
                panelRecordEdit_buttonUndo.Enabled = true;
                panelRecordEdit_dataGridView_reloadBackgroundColor();
			}

			Program.state.formEditFindingState = State.FormEditFindingState.NULL;
		}

        private void panelRecordEdit_deleteRowForMerge(DataEntry entry, List<int> indexArray)
        {
            int rowIndex = indexArray.First();
            
            panelRecordEdit_fillCellValue(rowIndex,
                              false,
                              true,
                              false,
                              entry.getPluginName(),
                              entry.getIp(),
                              entry.getDescription(),
                              entry.getImpact(),
                              entry.getRiskFactor(),
                              entry.getRecommendation(),
                              entry.getCve(),
                              entry.getBid(),
                              entry.getOsvdb(),
                              entry.getReferenceLink(),
                              entry.getEntryTypeString(),
                              entry.getpluginversion(),
                              entry.getpluginID());           //@@@@@
            int firstRowDbid = int.Parse(panelRecordEdit_dataGridView.Rows[rowIndex].Cells[(int)CellColumnIndex.DBID].Value.ToString());
            //@@@@@Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateRecordToDatabase(entry, firstRowDbid);
            Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateNessusFindingToDatabase(entry, firstRowDbid);
            indexArray.RemoveAt(0);
            int counting_for_FindingDetail = 0;
            foreach (int i in indexArray)
            {


                int dbid = int.Parse(panelRecordEdit_dataGridView.Rows[i].Cells[(int)CellColumnIndex.DBID].Value.ToString());
                //@@@@@Program.state.panelRecordEdit_recordDatabaser.deleteEditedRecordEntry(dbid);
                Program.state.panelRecordEdit_recordDatabaser.guideleteNessusFindingEntry(dbid);
                Program.state.panelRecordEdit_recordDatabaser.guiUpdateMergeFindingDetailToDatabase(firstRowDbid, dbid, counting_for_FindingDetail);
                Program.state.panelRecordEdit_recordDatabaser.guiUpdateMergeFindingReferenceToDatabase(firstRowDbid, dbid, counting_for_FindingDetail);

                panelRecordEdit_dataGridView.Rows[i].Cells[(int)CellColumnIndex.PLUGINNAME].Value = null;
                panelRecordEdit_dataGridView.Rows[i].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                panelRecordEdit_dataGridView.Rows[i].Visible = false;
                Program.state.panelRecordEdit_RecordSelected[i] = false;
                counting_for_FindingDetail++;
            }
        }

		/// <summary>
		/// This is the panelRecordEdit_buttonUpdateRecordFromEditedEntryAction method.
		/// It is used to update the DataEntry shown on dataGridView with given rowIndex.
		/// </summary>
		/// <param name="rowIndex">the row index on dataGridView that needs update</param>
		private void panelRecordEdit_buttonUpdateRecordFromEditedEntryAction(int rowIndex) {
			DataEntry entry = Program.state.formEditFindingEntry;

			panelRecordEdit_fillCellValue(rowIndex,
										  true,
										  (bool)panelRecordEdit_dataGridView.Rows[rowIndex].Cells[(int)CellColumnIndex.MERGED].Value,
										  true,
										  entry.getPluginName(),
										  entry.getIp(),
										  entry.getDescription(),
										  entry.getImpact(),
										  entry.getRiskFactor(),
										  entry.getRecommendation(),
										  entry.getCve(),
										  entry.getBid(),
										  entry.getOsvdb(),
										  entry.getReferenceLink(),
										  entry.getEntryTypeString(),
                                          entry.getpluginversion(),
                                          entry.getpluginID());          //@@@@@

            //panelRecordEdit_dataGridView.Rows[rowIndex].Cells[(int)CellColumnIndex.DBID].Value =
				//@@@@@Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateRecordToDatabase(Program.state.formEditFindingEntry,
            //@@@@@															 (int)panelRecordEdit_dataGridView.Rows[rowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
                Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateNessusFindingToDatabase(Program.state.formEditFindingEntry,
																			 (int)panelRecordEdit_dataGridView.Rows[rowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
            panelRecordEdit_dataGridView_reloadBackgroundColor();
        }

		/// <summary>
		/// This is the panelRecordEdit_buttonUpdateRecord_Click method.
		/// It is used to handle the click event on button panelRecordEdit_buttonUpdateRecord.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_buttonUpdateRecord_Click(object sender, EventArgs e) {
			List<int> indexArray = new List<int>();
			List<DataEntry> dataArray = new List<DataEntry>();
            Dictionary<int, DataEntry> undoList = new Dictionary<int, DataEntry>();
            Dictionary<int, bool> undoEdited = new Dictionary<int, bool>();
            Dictionary<int, bool> undoMegered = new Dictionary<int, bool>();

            foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value) {
					indexArray.Add(row.Index);
                    int dbid = int.Parse(row.Cells[(int)CellColumnIndex.DBID].Value.ToString());
                    undoEdited[dbid] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
                    undoMegered[dbid] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;
                    undoList[dbid] = panelRecordEdit_rowToDataEntry(row);
					dataArray.Add(panelRecordEdit_rowToDataEntry(row));
				}
			}

			this.Enabled = false;
			new FormEditFinding(indexArray, dataArray).ShowDialog();
			this.Enabled = true;
            this.TopMost = true;
            this.TopMost = false;

			// if button "OK" clicked, check if the current row is already a edited findings or not,
			// if not, a finding should be append to the dataGridView
			if (Program.state.formEditFindingState == State.FormEditFindingState.OK) {
                //if ((bool)panelRecordEdit_dataGridView.Rows[indexArray[0]].Cells[(int)CellColumnIndex.EDITED].Value) {
					panelRecordEdit_buttonUpdateRecordFromEditedEntryAction(indexArray[0]);
                //}
                //else {
                //    panelRecordEdit_addRowForUpdate(Program.state.formEditFindingEntry, (int)panelRecordEdit_dataGridView.Rows[indexArray[0]].Cells[(int)CellColumnIndex.OLDID].Value);
                //}
                //panelRecordEdit_dataGridView.Rows[indexArray[0]].Cells[(int)CellColumnIndex.SELECTED].Value = false;

				panelRecordEdit_checkboxCheckedChangedAction();
				panelRecordEdit_checkboxTypeCheckedChangedAction();
				panelRecordEdit_enableNextButton();



                Program.state.panelRecordEdit_undoEdited = undoEdited;
                Program.state.panelRecordEdit_undoMegered = undoMegered;
                Program.state.panelRecordEdit_undoDataEntryList = undoList;
                panelRecordEdit_buttonUndo.Enabled = true;
			}
			Program.state.formEditFindingState = State.FormEditFindingState.NULL;
		}

		/// <summary>
		/// This is the panelRecordEdit_columnIndexToText method.
		/// It is used to get the useful data after merge/update a DataEntry according
		/// to given columnIndex.
		/// </summary>
		/// <param name="columnIndex">the columnIndex of the dataGridView</param>
		/// <returns>a string from the edited finding (after user edition from another form)
		/// by the user with reference to columnIndex</returns>
		private String panelRecordEdit_columnIndexToText(int columnIndex) {
			switch (columnIndex) {
				case (int)CellColumnIndex.PLUGINNAME:
					return Program.state.formEditFindingEntry.getPluginName();
				case (int)CellColumnIndex.IPLIST:
					return Program.state.formEditFindingEntry.getIp();
				case (int)CellColumnIndex.DESCRIPTION:
					return Program.state.formEditFindingEntry.getDescription();
				case (int)CellColumnIndex.IMPACT:
					return Program.state.formEditFindingEntry.getImpact();
				case (int)CellColumnIndex.RECOMMENDATION:
					return Program.state.formEditFindingEntry.getRecommendation();
				case (int)CellColumnIndex.CVE:
					return Program.state.formEditFindingEntry.getCve();
				case (int)CellColumnIndex.BID:
					return Program.state.formEditFindingEntry.getBid();
				case (int)CellColumnIndex.OSVDB:
					return Program.state.formEditFindingEntry.getOsvdb();
				case (int)CellColumnIndex.REFERENCELINK:
					return Program.state.formEditFindingEntry.getReferenceLink();
			}
			return "";
		}

		/// <summary>
		/// This is the dataGridView_CellDoubleClick method.
		/// It is used to handle the double click event on dataGridView.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			#region // Mouse Double Click on DataGridView on Cell Column Action (Except SELECTED/MERGED/EDITED/RISKFACTOR/ID/OLDID/ENTRYTYPE)
			if (e.ColumnIndex != (int)CellColumnIndex.SELECTED &&
				e.ColumnIndex != (int)CellColumnIndex.MERGED &&
				e.ColumnIndex != (int)CellColumnIndex.EDITED &&
				e.ColumnIndex != (int)CellColumnIndex.RISKFACTOR &&
				e.ColumnIndex != (int)CellColumnIndex.ID &&
				e.ColumnIndex != (int)CellColumnIndex.OLDID &&
				e.ColumnIndex != (int)CellColumnIndex.ENTRYTYPE &&
				e.RowIndex != -1) {
				List<int> indexArray = new List<int>();
				List<DataEntry> dataArray = new List<DataEntry>();

                Dictionary<int, DataEntry> undoList = new Dictionary<int, DataEntry>();
                Dictionary<int, bool> undoEdited = new Dictionary<int, bool>();
                Dictionary<int, bool> undoMegered = new Dictionary<int, bool>();
                
                DataGridViewRow row = panelRecordEdit_dataGridView.Rows[e.RowIndex];
				dataArray.Add(panelRecordEdit_rowToDataEntry(row));

                int dbid = int.Parse(row.Cells[(int)CellColumnIndex.DBID].Value.ToString());
                undoEdited[dbid] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
                undoMegered[dbid] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;
                undoList[dbid] = panelRecordEdit_rowToDataEntry(row);
				this.Enabled = false;
				
                new FormEditFinding(indexArray, dataArray, e.ColumnIndex - 4).ShowDialog();

				this.Enabled = true;
                this.TopMost = true;
                this.TopMost = false;

				// here, like action taken on update record button click
                if (Program.state.formEditFindingState == State.FormEditFindingState.OK || Program.state.formEditFindingStringState == State.FormEditFindingStringState.APPLYTOALL)
                {
                    //if ((bool)panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.EDITED].Value) {
                    //    panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = panelRecordEdit_columnIndexToText(e.ColumnIndex);

                    //    //panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.DBID].Value = 
                    //        Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateRecordToDatabase(Program.state.formEditFindingEntry, (int)panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
                    //}
                    //else {
                    //    panelRecordEdit_addRowForUpdate(Program.state.formEditFindingEntry, (int)panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
						
                    //    //panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                    //    //panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.Rows.Count - 1].Cells[(int)CellColumnIndex.SELECTED].Value = true;
                    //}
                    panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = panelRecordEdit_columnIndexToText(e.ColumnIndex);
                    //@@@@@Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateRecordToDatabase(Program.state.formEditFindingEntry, (int)panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateNessusFindingToDatabase(Program.state.formEditFindingEntry, (int)panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.OLDID].Value);
                 
                    //apply to all
                    if (Program.state.formEditFindingStringState == State.FormEditFindingStringState.APPLYTOALL)
                    {
                        if (e.ColumnIndex == (int)CellColumnIndex.DESCRIPTION)
                            Program.state.amendmentDatabaser.storeAmendment(new Amendment(panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString() +
                                        "_" + panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.PLUGINNAME].Value.ToString(),
                                        panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString(),
                                        panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.DESCRIPTION].Value.ToString(),
                                        Program.state.formEditFindingString_stringText,
                                        null,
                                        null,
                                        null,
                                        null));
                        else if (e.ColumnIndex == (int)CellColumnIndex.RECOMMENDATION)
                            Program.state.amendmentDatabaser.storeAmendment(new Amendment(panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString() +
                                        "_" + panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.PLUGINNAME].Value.ToString(),
                                        panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString(),
                                        null,
                                        null,
                                        panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.RECOMMENDATION].Value.ToString(),
                                        Program.state.formEditFindingString_stringText,
                                        null,
                                        null));
                        else if (e.ColumnIndex == (int)CellColumnIndex.REFERENCELINK)
                            Program.state.amendmentDatabaser.storeAmendment(new Amendment(panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString() +
                                        "_" + panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.PLUGINNAME].Value.ToString(),
                                        panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString(),
                                        null,
                                        null,
                                        null,
                                        null,
                                        panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.REFERENCELINK].Value.ToString(),
                                        Program.state.formEditFindingString_stringText));

                    }  
                    panelRecordEdit_checkboxCheckedChangedAction();
                    panelRecordEdit_checkboxTypeCheckedChangedAction();
                    panelRecordEdit_enableNextButton();

                    Program.state.panelRecordEdit_undoEdited = undoEdited;
                    Program.state.panelRecordEdit_undoMegered = undoMegered;
                    Program.state.panelRecordEdit_undoDataEntryList = undoList;
                    panelRecordEdit_buttonUndo.Enabled = true;
				}
				Program.state.formEditFindingState = State.FormEditFindingState.NULL;
			}
			#endregion

			#region // Mouse Double Click on DataGridView on Cell Column Action (Include RISKFACTOR/ENTRYTYPE)
			else if ((e.ColumnIndex == (int)CellColumnIndex.RISKFACTOR ||
					 e.ColumnIndex == (int)CellColumnIndex.ENTRYTYPE) &&
					 e.RowIndex != -1) {
				List<int> indexArray = new List<int>();
				List<DataEntry> dataArray = new List<DataEntry>();

                Dictionary<int, DataEntry> undoList = new Dictionary<int, DataEntry>();
                Dictionary<int, bool> undoEdited = new Dictionary<int, bool>();
                Dictionary<int, bool> undoMegered = new Dictionary<int, bool>();

				indexArray.Add(panelRecordEdit_dataGridView.CurrentCell.RowIndex);
                DataGridViewRow row = panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.CurrentCell.RowIndex];
				dataArray.Add(panelRecordEdit_rowToDataEntry(row));

                int dbid = int.Parse(row.Cells[(int)CellColumnIndex.DBID].Value.ToString());
                undoEdited[dbid] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
                undoMegered[dbid] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;
                undoList[dbid] = panelRecordEdit_rowToDataEntry(row);

				this.Enabled = false;
				new FormEditFinding(indexArray, dataArray).ShowDialog();
				this.Enabled = true;
                this.TopMost = true;
                this.TopMost = false;

				// here, action like update button click
				if (Program.state.formEditFindingState == State.FormEditFindingState.OK) {
                    //if ((bool)panelRecordEdit_dataGridView.Rows[indexArray[0]].Cells[(int)CellColumnIndex.EDITED].Value) {
                    //    panelRecordEdit_buttonUpdateRecordFromEditedEntryAction(indexArray[0]);
                    //}
                    //else {
                    //    panelRecordEdit_addRowForUpdate(Program.state.formEditFindingEntry, (int)panelRecordEdit_dataGridView.Rows[indexArray[0]].Cells[(int)CellColumnIndex.OLDID].Value);
                    //}
                    //panelRecordEdit_dataGridView.Rows[indexArray[0]].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                    panelRecordEdit_buttonUpdateRecordFromEditedEntryAction(indexArray[0]);

					panelRecordEdit_checkboxCheckedChangedAction();
					panelRecordEdit_checkboxTypeCheckedChangedAction();
					panelRecordEdit_enableNextButton();

                    Program.state.panelRecordEdit_undoEdited = undoEdited;
                    Program.state.panelRecordEdit_undoMegered = undoMegered;
                    Program.state.panelRecordEdit_undoDataEntryList = undoList;
                    panelRecordEdit_buttonUndo.Enabled = true;
				}
				Program.state.formEditFindingState = State.FormEditFindingState.NULL;
			}
			#endregion
		}

		/// <summary>
		/// This is the dataGridView_CellMouseUp method.
		/// It is used to handle the mouse up event on dataGridView.
		/// Here, multiselect rows features implements by cell mouse up event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.Button == System.Windows.Forms.MouseButtons.Left &&
				e.RowIndex != -1 &&
				panelRecordEdit_dataGridView.SelectedRows.Count != 1) {

                bool allSelected = true;
                for (int i = 0; i < panelRecordEdit_dataGridView.SelectedRows.Count; i++)
                {
                    if (panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Visible)
                    {
                        if (!(bool)panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Cells[(int)CellColumnIndex.SELECTED].Value) 
                            allSelected = false;
                    }
                }

                if (allSelected)
                    for (int i = 0; i < panelRecordEdit_dataGridView.SelectedRows.Count; i++)
                    {
                        if (panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Visible)
                        {
                            panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                        }
                    }
                else
				    for (int i = 0; i < panelRecordEdit_dataGridView.SelectedRows.Count; i++) {
					    if (panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Visible) {
                            //if ((bool)panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Cells[(int)CellColumnIndex.SELECTED].Value) {
                            //    panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                            //}
                            //else {
							    panelRecordEdit_dataGridView.Rows[panelRecordEdit_dataGridView.SelectedRows[i].Index].Cells[(int)CellColumnIndex.SELECTED].Value = true;
                            //}
					    }
				    }
				panelRecordEdit_enableNextButton();
			}
		}

		/// <summary>
		/// This is the dataGridView_CellClick method.
		/// It is used to handle the cell click event on dataGridView.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex != -1 && panelRecordEdit_dataGridView.SelectedRows.Count == 1) {
				if (panelRecordEdit_dataGridView.Rows[e.RowIndex].Visible) {
					if ((bool)panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value) {
						panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
					else {
						panelRecordEdit_dataGridView.Rows[e.RowIndex].Cells[(int)CellColumnIndex.SELECTED].Value = true;
					}
				}
				panelRecordEdit_enableNextButton();
			}
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxCheckedChangedAction method.
		/// It is used to handle the checked change event on checkboxs to show
		/// one type of HIGH/MEDIUM/LOW/NONE/OPENPORT findings.
		/// </summary>
		/// <param name="visible">determine the finding is visible or not</param>
		/// <param name="riskFactor">determine which type of findings needs changes 
		/// to it's visibility on dataGridView</param>
		private void panelRecordEdit_checkboxCheckedChangedAction(bool visible, String riskFactor) {
			if (visible) {
				foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
                    if (row.Cells[(int)CellColumnIndex.PLUGINNAME].Value == null)
                        continue;
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == riskFactor) {

						bool toVisible = false;
						switch (DataEntry.stringToEntryType(row.Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString())) {
							case DataEntry.EntryType.NESSUS:
								if (panelRecordEdit_checkboxNessus.CheckState == CheckState.Checked) {
									toVisible = true;
								}
								break;
							case DataEntry.EntryType.MBSA:
								if (panelRecordEdit_checkboxMbsa.CheckState == CheckState.Checked) {
									toVisible = true;
								}
								break;
							case DataEntry.EntryType.NMAP:
								if (panelRecordEdit_checkboxNmap.CheckState == CheckState.Checked) {
									toVisible = true;
								}
								break;
                            case DataEntry.EntryType.Acunetix:
							    toVisible = true;

								break;
                            case DataEntry.EntryType.MBSA_NESSUS:
                                toVisible = true;

                                break;
						}

						row.Visible = toVisible;
					}
				}
			}
			else {
				foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
                    if (row.Cells[(int)CellColumnIndex.PLUGINNAME].Value == null)
                        continue;
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == riskFactor) {
						row.Visible = false;
						row.Selected = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxCheckedChangedAction method.
		/// It is used to handle the checked change event on checkboxs to show
		/// HIGH/MEDIUM/LOW/NONE/OPENPORT findings.
		/// </summary>
		private void panelRecordEdit_checkboxCheckedChangedAction() {
			panelRecordEdit_checkboxCheckedChangedAction(panelRecordEdit_checkboxHigh.CheckState == CheckState.Checked, "High");
			panelRecordEdit_checkboxCheckedChangedAction(panelRecordEdit_checkboxMedium.CheckState == CheckState.Checked, "Medium");
			panelRecordEdit_checkboxCheckedChangedAction(panelRecordEdit_checkboxLow.CheckState == CheckState.Checked, "Low");
            panelRecordEdit_checkboxCheckedChangedAction(panelRecordEdit_checkboxNone.CheckState == CheckState.Checked, "None");
			panelRecordEdit_checkboxCheckedChangedAction(panelRecordEdit_checkboxOpenPort.CheckState == CheckState.Checked, "OpenPort");


			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxHigh_CheckedChanged method.
		/// It is used to handle the checked change event on checkbox
		/// panelRecordEdit_checkboxHigh.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxHigh_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxMedium_CheckedChanged method.
		/// It is used to handle the checked change event on checkbox
		/// panelRecordEdit_checkboxMedium.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxMedium_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxLow_CheckedChanged method.
		/// It is used to handle the checked change event on checkbox
		/// panelRecordEdit_checkboxLow.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxLow_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxNone_CheckedChanged method.
		/// It is used to handle the checked change event on checkbox
		/// panelRecordEdit_checkboxNone.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxNone_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxOpenPort_CheckedChanged method.
		/// It is used to handle the checked change event on checkbox
		/// panelRecordEdit_checkboxOpenPort.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxOpenPort_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxTypeCheckedChangedAction method.
		/// It is used to handle the checked change event on checkboxs to show
		/// one type of NESSUS/MBSA/NMAP findings.
		/// </summary>
		/// <param name="visible">determine the finding is visible or not</param>
		/// <param name="entryType">determine which type of findings needs
		/// changes to it's visibility on dataGridView</param>
		private void panelRecordEdit_checkboxTypeCheckedChangedAction(bool visible, String entryType) {
			if (visible) {
				foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
                    if (row.Cells[(int)CellColumnIndex.PLUGINNAME].Value == null)
                        continue;
					if (row.Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString() == entryType) {

						bool toVisible = false;

						switch (RiskFactorFunction.getEnum(row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString())){
							case RiskFactor.HIGH:
								if (panelRecordEdit_checkboxHigh.CheckState == CheckState.Checked){
									toVisible = true;
								}
								break;
							case RiskFactor.MEDIUM:
								if (panelRecordEdit_checkboxMedium.CheckState == CheckState.Checked){
									toVisible = true;
								}
								break;
							case RiskFactor.LOW:
								if (panelRecordEdit_checkboxLow.CheckState == CheckState.Checked){
									toVisible = true;
								}
								break;
							case RiskFactor.NONE:
								if (panelRecordEdit_checkboxNone.CheckState == CheckState.Checked){
									toVisible = true;
								}
								break;
							case RiskFactor.OPEN:
								if (panelRecordEdit_checkboxOpenPort.CheckState == CheckState.Checked){
									toVisible = true;
								}
								break;
						}

						row.Visible = toVisible;
					}
				}
			}
			else {
				foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
                    if (row.Cells[(int)CellColumnIndex.PLUGINNAME].Value == null)
                        continue;
					if (row.Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString() == entryType) {
						row.Visible = false;
						row.Selected = false;
						row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
					}
				}
			}
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxTypeCheckedChangedAction method.
		/// It is used to handle the checked change event on checkboxs to show
		/// NESSUS/MBSA/NMAP findings.
		/// </summary>
		private void panelRecordEdit_checkboxTypeCheckedChangedAction() {
			panelRecordEdit_checkboxTypeCheckedChangedAction(panelRecordEdit_checkboxNessus.CheckState == CheckState.Checked, "NESSUS");
			panelRecordEdit_checkboxTypeCheckedChangedAction(panelRecordEdit_checkboxMbsa.CheckState == CheckState.Checked, "MBSA");
			panelRecordEdit_checkboxTypeCheckedChangedAction(panelRecordEdit_checkboxNmap.CheckState == CheckState.Checked, "NMAP");

			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxNessus_CheckedChanged method.
		/// It is used to handle the checked change event on panelRecordEdit_checkboxNessus.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxNessus_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxTypeCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxMbsa_CheckedChanged method.
		/// It is used to handle the checked change event on panelRecordEdit_checkboxMbsa.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxMbsa_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxTypeCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_checkboxNmap_CheckedChanged method.
		/// It is used to handle the checked change event on panelRecordEdit_checkboxNmap.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_checkboxNmap_CheckedChanged(object sender, EventArgs e) {
			panelRecordEdit_checkboxTypeCheckedChangedAction();
		}

		/// <summary>
		/// This is the panelRecordEdit_ComboBox_SelectedIndexChanged method.
		/// It is used to handle the selected index change event on panelRecordEdit_ComboBox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_ComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (panelRecordEdit_comboBoxBottom.SelectedIndex == 0)
                return;

            String[] riskFactorString = { "Select Risk", "High", "Medium", "Low", "None", "OpenPort" };



			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
				if (row.Visible) {
					if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString() == riskFactorString[panelRecordEdit_comboBoxBottom.SelectedIndex]) {
						row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
						row.Selected = true;
					}
                    //else {
                    //    row.Cells[(int)CellColumnIndex.SELECTED].Value = false;
                    //    row.Selected = false;
                    //}
				}
			}
            panelRecordEdit_comboBoxBottom.SelectedIndex = 0;
			panelRecordEdit_enableNextButton();
		}

		/// <summary>
		/// This is the panelRecordEdit_enableNextButton method.
		/// It is used to enable/disable button buttonNext with status on dataGridView.
		/// </summary>
		private void panelRecordEdit_enableNextButton() {
			int counter = 0;
			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
                if (row.Cells[(int)CellColumnIndex.PLUGINNAME].Value == null)
                    continue;
				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value == true) {
					counter++;
				}
			}

			// here, selected at least one finding from whole records would
			// enable the buttonNext button
			buttonNext.Enabled = counter > 0 ? true : false;

            panelRecordEdit_buttonUp.Enabled = counter == 1 ? true : false;
            panelRecordEdit_buttonDown.Enabled = counter == 1 ? true : false;
			// update other buttons too
			panelRecordEdit_buttonUpdateRecord.Enabled = counter == 1 ? true : false;
            panelRecordEdit_buttonMergeRecord.Enabled = counter > 1 ? true : false;
            panelRecordEdit_buttonDeleteRecord.Enabled = counter >= 1 ? true : false;
			// set text of the label
			panelRecordEdit_labelNoOfRowSelected.Text = "No of findings selected: " + counter.ToString();
		}

		/// <summary>
		/// This is the panelRecordEdit_saveConfig_Click method.
		/// It is used to handle the click event on button panelRecordEdit_saveConfig.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelRecordEdit_saveConfig_Click(object sender, EventArgs e) {
			saveConfig();
		}

		/// <summary>
		/// This is the panelRecordEdit_nextAction.
		/// It is used to process the action when button buttonNext is clicked.
		/// </summary>
		private void panelRecordEdit_nextAction() {
			Program.state.panelRecordEdit_RecordSelected = new Dictionary<int, bool>();
			Program.state.panelRecordEdit_RecordMerged = new Dictionary<int, bool>();
			Program.state.panelRecordEdit_RecordEdited = new Dictionary<int, bool>();
			Program.state.dataGridView_Id = new Dictionary<int, int>();
			Program.state.dataGridView_OldId = new Dictionary<int, int>();
			Program.state.dataGridView_DatabaseId = new Dictionary<int, int>();

			Record.Record tempRecord = new Record.Record();
			Program.state.panelRecordEdit_ConfirmedRecord = new Record.Record();

			// store the selected/merged/edited state
			// together with the values of id/oldid/databaseid
			foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
		        Program.state.panelRecordEdit_RecordSelected[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (bool)row.Cells[(int)CellColumnIndex.SELECTED].Value;
                Program.state.panelRecordEdit_RecordMerged[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;
                Program.state.panelRecordEdit_RecordEdited[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
				Program.state.dataGridView_Id[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (int)row.Cells[(int)CellColumnIndex.ID].Value;
				Program.state.dataGridView_OldId[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (int)row.Cells[(int)CellColumnIndex.OLDID].Value;
				Program.state.dataGridView_DatabaseId[(int)row.Cells[(int)CellColumnIndex.ID].Value - 1] = (int)row.Cells[(int)CellColumnIndex.DBID].Value;
                

                if (row.Cells[(int)CellColumnIndex.PLUGINNAME].Value == null)
                    continue;
                tempRecord.guiAddEntry(panelRecordEdit_rowToDataEntry(row));

				if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value) {
					Program.state.panelRecordEdit_ConfirmedRecord.guiAddEntry(panelRecordEdit_rowToDataEntry(row));
				}
			}
			Program.state.panelRecordEdit_record = tempRecord;

			// store the values of the checkbox at the bottom of the panel
			Program.state.panelRecordEdit_showHigh = (panelRecordEdit_checkboxHigh.CheckState == CheckState.Checked);
			Program.state.panelRecordEdit_showMedium = (panelRecordEdit_checkboxMedium.CheckState == CheckState.Checked);
			Program.state.panelRecordEdit_showLow = (panelRecordEdit_checkboxLow.CheckState == CheckState.Checked);
			Program.state.panelRecordEdit_showNone = (panelRecordEdit_checkboxNone.CheckState == CheckState.Checked);
			Program.state.panelRecordEdit_showOpenPort = (panelRecordEdit_checkboxOpenPort.CheckState == CheckState.Checked);
			Program.state.panelRecordEdit_showNessus = (panelRecordEdit_checkboxNessus.CheckState == CheckState.Checked);
			Program.state.panelRecordEdit_showMbsa = (panelRecordEdit_checkboxMbsa.CheckState == CheckState.Checked);
			Program.state.panelRecordEdit_showNmap = (panelRecordEdit_checkboxNmap.CheckState == CheckState.Checked);
		}
		#endregion

		#region // PANEL OUTPUT SELECT Functions

		/// <summary>
		/// This is the panelOutputSelect_initialize method.
		/// It is used to initialize the panel panelOutputSelect whenever
		/// this panel display to user.
		/// </summary>
		private void panelOutputSelect_initialize() {
			panelOutputSelect_groupBoxOutputFilePath.Hide();
			panelOutputSelect_groupBoxTemplatePath.Hide();
			panelOutputSelect_groupBoxOtherSettings.Hide();

			if (Program.state.panelOutputSelect_State != State.PanelOutputSelectState.NULL) {
				panelOutputSelect_groupBoxOutputFilePath.Show();

				// if another output format button selected
				// the displayed filepath will changed from ".xxx" to another
				if (!String.IsNullOrEmpty(panelOutputSelect_textBoxOutputFilePath.Text)) {
					panelOutputSelect_textBoxOutputFilePath.Text = panelOutputSelect_textBoxOutputFilePath.Text.Substring(0, panelOutputSelect_textBoxOutputFilePath.Text.LastIndexOf('.'));
					switch (Program.state.panelOutputSelect_State) {
						case State.PanelOutputSelectState.HTML:
							panelOutputSelect_textBoxOutputFilePath.Text += ".html";
							break;
						case State.PanelOutputSelectState.DOCX:
							panelOutputSelect_textBoxOutputFilePath.Text += ".docx";
							break;
						case State.PanelOutputSelectState.DOCXTEM:
							panelOutputSelect_textBoxOutputFilePath.Text += ".docx";
							panelOutputSelect_groupBoxTemplatePath.Show();
							break;
						case State.PanelOutputSelectState.XLSX:
							panelOutputSelect_textBoxOutputFilePath.Text += ".xlsx";
							break;
					}
				}
				else if (!String.IsNullOrEmpty(Program.state.panelOutputSelect_OutputPath)) {
					panelOutputSelect_textBoxOutputFilePath.Text = Program.state.panelOutputSelect_OutputPath;
				}

				// here, change the label text and also display/hide the groupbox of templatepath
				switch (Program.state.panelOutputSelect_State) {
					case State.PanelOutputSelectState.HTML:
						panelOutputSelect_labelRightTopText.Text = State.panelOutputSelect_HTMLSelected;
						break;
					case State.PanelOutputSelectState.DOCX:
						panelOutputSelect_labelRightTopText.Text = State.panelOutputSelect_DOCXSelected;
						break;
					case State.PanelOutputSelectState.DOCXTEM:
						panelOutputSelect_labelRightTopText.Text = State.panelOutputSelect_DOCXTEMSelected;
						panelOutputSelect_groupBoxTemplatePath.Show();
						break;
					case State.PanelOutputSelectState.XLSX:
						panelOutputSelect_labelRightTopText.Text = State.panelOutputSelect_XLSXSelected;
						break;
				}
				panelOutputSelect_groupBoxOtherSettings.Show();

				// loaded the checked state of the hotfix checkbox
				if (Program.state.panelOutputSelect_isOutputHotfix) {
					panelOutputSelect_checkboxHotfixOutput.CheckState = CheckState.Checked;
				}
				else {
					panelOutputSelect_checkboxHotfixOutput.CheckState = CheckState.Unchecked;
				}

				// loaded the checked state of the openport checkbox
				if (Program.state.panelOutputSelect_isOutputOpenPort) {
					panelOutputSelect_checkboxOpenPortOutput.CheckState = CheckState.Checked;
				}
				else {
					panelOutputSelect_checkboxOpenPortOutput.CheckState = CheckState.Unchecked;
				}

                // loaded the checked state of the iphost checkbox
                if (Program.state.panelOutputSelect_isOutputIpHost)
                {
                    panelOutputSelect_checkboxIpHostOutput.CheckState = CheckState.Checked;
                }
                else
                {
                    panelOutputSelect_checkboxIpHostOutput.CheckState = CheckState.Unchecked;
                }

                // loaded the checked state of the Exportpluginoutput checkbox
                if (Program.state.panelOutputSelect_isOutputPluginOutput)
                {
                    panelOutputSelect_checkboxExportPluginOutput.CheckState = CheckState.Checked;
                }
                else
                {
                    panelOutputSelect_checkboxExportPluginOutput.CheckState = CheckState.Unchecked;
                }

				if (Program.state.panelOutputSelect_State == State.PanelOutputSelectState.DOCXTEM &&
					!String.IsNullOrEmpty(Program.state.panelOutputSelect_TemplatePath)) {
					panelOutputSelect_textBoxTemplatePath.Text = Program.state.panelOutputSelect_TemplatePath;
				}
			}

			panelOutputSelect_enableNextButton();
		}

		/// <summary>
		/// This is the panelOutputSelect_enableNextButton method.
		/// It is used to check the current status to enable the button
		/// buttonNext or not.
		/// </summary>
		private void panelOutputSelect_enableNextButton() {

			// here, only all paths filled on appeared textBox would enable the
			// button buttonNext (enable the next action)
			if (Program.state.panelOutputSelect_State != State.PanelOutputSelectState.NULL) {
				if (!String.IsNullOrEmpty(panelOutputSelect_textBoxOutputFilePath.Text)) {
					if (Program.state.panelOutputSelect_State == State.PanelOutputSelectState.DOCXTEM) {
						if (!String.IsNullOrEmpty(panelOutputSelect_textBoxTemplatePath.Text)) {
							if (Directory.Exists(panelOutputSelect_textBoxOutputFilePath.Text.Substring(0, panelOutputSelect_textBoxOutputFilePath.Text.LastIndexOf('\\'))) &&
								Directory.Exists(panelOutputSelect_textBoxTemplatePath.Text.Substring(0, panelOutputSelect_textBoxTemplatePath.Text.LastIndexOf('\\')))) {
								buttonNext.Enabled = true;
								return;
							}
						}
					}
					else {
						if (Directory.Exists(panelOutputSelect_textBoxOutputFilePath.Text.Substring(0, panelOutputSelect_textBoxOutputFilePath.Text.LastIndexOf('\\')))) {
							buttonNext.Enabled = true;
							return;
						}
					}
				}
			}
			buttonNext.Enabled = false;
		}

		/// <summary>
		/// This is the panelOutputSelect_buttonHtml_Click method.
		/// It is used to handle the click event on button panelOutputSelect_buttonHtml.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_buttonHtml_Click(object sender, EventArgs e) {
			Program.state.panelOutputSelect_State = State.PanelOutputSelectState.HTML;
			panelOutputSelect_initialize();
			panelOutputSelect_groupBoxOutputFilePath.Show();
			panelOutputSelect_groupBoxTemplatePath.Hide();
		}

		/// <summary>
		/// This is the panelOutputSelect_buttonDocxDefault_Click method.
		/// It is used to handle the click event on button panelOutputSelect_buttonDocxDefault.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_buttonDocxDefault_Click(object sender, EventArgs e) {
			Program.state.panelOutputSelect_State = State.PanelOutputSelectState.DOCX;
			panelOutputSelect_initialize();
			panelOutputSelect_groupBoxOutputFilePath.Show();
			panelOutputSelect_groupBoxTemplatePath.Hide();
		}

		/// <summary>
		/// This is the panelOutputSelect_buttonDocxFromDocx_Click method.
		/// It is used to handle the click event on button panelOutputSelect_buttonDocxFromDocx.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_buttonDocxFromDocx_Click(object sender, EventArgs e) {
			Program.state.panelOutputSelect_State = State.PanelOutputSelectState.DOCXTEM;
			panelOutputSelect_initialize();
			panelOutputSelect_groupBoxOutputFilePath.Show();
			panelOutputSelect_groupBoxTemplatePath.Show();
		}

		/// <summary>
		/// This is the panelOutputSelect_buttonXlsxDefault_Click method.
		/// It is used to handle the click event on button panelOutputSelect_buttonXlsxDefault.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_buttonXlsxDefault_Click(object sender, EventArgs e) {
			Program.state.panelOutputSelect_State = State.PanelOutputSelectState.XLSX;
			panelOutputSelect_initialize();
			panelOutputSelect_groupBoxOutputFilePath.Show();
			panelOutputSelect_groupBoxTemplatePath.Hide();
		}

		/// <summary>
		/// This is the panelOutputSelect_buttonOutputPathSaveAs_Click method.
		/// It is used to handle the click event on button panelOutputSelect_buttonOutputPathSaveAs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_buttonOutputPathSaveAs_Click(object sender, EventArgs e) {
			switch (Program.state.panelOutputSelect_State) {
				case State.PanelOutputSelectState.HTML:
					saveFileDialog.Filter = "HTML Documents|*.html";
					break;
				case State.PanelOutputSelectState.DOCX:
				case State.PanelOutputSelectState.DOCXTEM:
					saveFileDialog.Filter = "Word Documents|*.docx";
					break;
				case State.PanelOutputSelectState.XLSX:
					saveFileDialog.Filter = "Excel Worksheets|*.xlsx";
					break;
			}
			saveFileDialog.ShowDialog();
			panelOutputSelect_textBoxOutputFilePath.Text = saveFileDialog.FileName;
			saveFileDialog.FileName = "";
			panelOutputSelect_enableNextButton();
		}

		/// <summary>
		/// This is the panelOutputSelect_buttonTemplatePathOpen_Click method.
		/// It is used to handle the click event on button panelOutputSelect_buttonTemplatePathOpen
		/// and also the click event on textBox panelOutputSelect_textBoxTemplatePath.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_buttonTemplatePathOpen_Click(object sender, EventArgs e) {
			openFileDialog.Filter = "Word Documents|*.docx";
			openFileDialog.ShowDialog();

			panelOutputSelect_textBoxTemplatePath.Text = openFileDialog.FileName;
			if (panelOutputSelect_textBoxTemplatePath.Text == panelOutputSelect_textBoxOutputFilePath.Text) {
				panelOutputSelect_textBoxTemplatePath.Text = "";
				MessageBox.Show("Cannot modify the template word document.");
			}
			panelOutputSelect_enableNextButton();
		}

		/// <summary>
		/// This is the panelOutputSelect_checkboxHotfixOutput_CheckedChanged method.
		/// It is used to handle the checked change event on checkbox panelOutputSelect_checkboxHotfixOutput.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_checkboxHotfixOutput_CheckedChanged(object sender, EventArgs e) {
			Program.state.panelOutputSelect_isOutputHotfix = panelOutputSelect_checkboxHotfixOutput.CheckState == CheckState.Checked;
		}

		/// <summary>
		/// This is the panelOutputSelect_checkboxOpenPortOutput_CheckedChanged method.
		/// It is used to handle the checked change event on checkbox panelOutputSelect_checkboxOpenPortOutput.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOutputSelect_checkboxOpenPortOutput_CheckedChanged(object sender, EventArgs e) {
			Program.state.panelOutputSelect_isOutputOpenPort = panelOutputSelect_checkboxOpenPortOutput.CheckState == CheckState.Checked;
		}

		/// <summary>
		/// This is the panelOutputSelect_nextAction method.
		/// It is used to process the action when button buttonNext is clicked.
		/// </summary>
		private void panelOutputSelect_nextAction() {
			// store the output/template paths, and the checkedBox checked state
			Program.state.panelOutputSelect_OutputPath = panelOutputSelect_textBoxOutputFilePath.Text;
			if (Program.state.panelOutputSelect_State == State.PanelOutputSelectState.DOCXTEM) {
				Program.state.panelOutputSelect_TemplatePath = panelOutputSelect_textBoxTemplatePath.Text;
			}
			Program.state.panelOutputSelect_isOutputHotfix = panelOutputSelect_checkboxHotfixOutput.CheckState == CheckState.Checked;
			Program.state.panelOutputSelect_isOutputOpenPort = panelOutputSelect_checkboxOpenPortOutput.CheckState == CheckState.Checked;
            Program.state.panelOutputSelect_isOutputIpHost = panelOutputSelect_checkboxIpHostOutput.CheckState == CheckState.Checked;
            Program.state.panelOutputSelect_isOutputPluginOutput = panelOutputSelect_checkboxExportPluginOutput.CheckState == CheckState.Checked;
		}
		#endregion

		#region // PANEL TEMPLATE STRING EDIT Functions

		/// <summary>
		/// This is the panelTemplateStringEdit_initialize method.
		/// It is used to initialize the panel panelTemplateStringEdit whenever
		/// this panel display to user.
		/// </summary>
		private void panelTemplateStringEdit_initialize() {
			panelTemplateStringEdit_dataGridView.Rows.Clear();
			panelTemplateStringEdit_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			panelTemplateStringEdit_dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

			if (Program.state.panelOutputSelect_State == State.PanelOutputSelectState.DOCXTEM) {

				if (Program.state.panelTemplateStringEdit_dict == null ||
					Program.state.panelTemplateStringEdit_dict.Count == 0) {

					try {
						Program.state.panelTemplateStringEdit_dict = new DocxFromDocxTemplateOutputer().getStringNeedReplace(Program.state.panelOutputSelect_TemplatePath);
					}
					catch (Exception e) {
						// most likely the template file being opened
						MessageBox.Show(e.StackTrace);
					}
				}

				// display the dictionary on the dataGridView
				panelTemplateStringEdit_addRow(Program.state.panelTemplateStringEdit_dict);
			}

			panelTemplateStringEdit_enableNextbutton();
		}

		/// <summary>
		/// This is the panelTemplateStringEdit_addRow method.
		/// It is used to add a row on the dataGridView of panelTemplateStringEdit 
		/// from given dict.
		/// </summary>
		/// <param name="dict">dictionary of string needes to replace to shown on dataGridView</param>
		private void panelTemplateStringEdit_addRow(Dictionary<String, String> dict) {
			foreach (KeyValuePair<String, String> s in dict) {
				int n = panelTemplateStringEdit_dataGridView.Rows.Add();

				panelTemplateStringEdit_dataGridView.Rows[n].Cells[0].Value = s.Key;

				if (!String.IsNullOrEmpty(s.Value) && s.Key != s.Value) {
					panelTemplateStringEdit_dataGridView.Rows[n].Cells[1].Value = s.Value;
				}
				else {
					panelTemplateStringEdit_dataGridView.Rows[n].Cells[1].Value = "";
				}
			}
		}

		/// <summary>
		/// This is the panelTemplateStringEdit_dataGridView_CellDoubleClick method.
		/// It is used to handle the double click event on cell of dataGridView of 
		/// panelTemplateStringEdit.
		/// Here, double click would show another form and allow editing
		/// the replaced string.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelTemplateStringEdit_dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex != -1 && e.ColumnIndex == 1) {

				String oldString = panelTemplateStringEdit_dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
				String newString = "";

				if (panelTemplateStringEdit_dataGridView.Rows[e.RowIndex].Cells[1].Value != null) {
					newString = panelTemplateStringEdit_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
				}

				new FormEditTemplateString(oldString, newString).ShowDialog();

				if (Program.state.formEditTemplateStringState == State.FormEditTemplateStringState.OK) {
					panelTemplateStringEdit_dataGridView.Rows[e.RowIndex].Cells[1].Value = Program.state.formEditTemplateString_stringText;
					panelTemplateStringEdit_dataGridView.AutoResizeRow(e.RowIndex);
				}
			}

			panelTemplateStringEdit_enableNextbutton();
		}

		/// <summary>
		/// This is the panelTemplateStringEdit_enableNextbutton method.
		/// It is used to check the current status to enable the button
		/// buttonNext or not.
		/// </summary>
		private void panelTemplateStringEdit_enableNextbutton() {
			// here, always enabled the button buttonNext
			buttonNext.Enabled = true;
		}

		/// <summary>
		/// This is the panelTemplateStringEdit_nextAction method.
		/// It is used to process the action when button buttonNext is clicked.
		/// </summary>
		private void panelTemplateStringEdit_nextAction() {
			Program.state.panelTemplateStringEdit_dict = new Dictionary<String, String>();
			foreach (DataGridViewRow row in panelTemplateStringEdit_dataGridView.Rows) {
				if (row.Cells[1].Value != null && !String.IsNullOrEmpty(row.Cells[1].Value.ToString())) {
					Program.state.panelTemplateStringEdit_dict[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
				}
				else {
					if (row.Cells[0].Value != null) {
						Program.state.panelTemplateStringEdit_dict[row.Cells[0].Value.ToString()] = row.Cells[0].Value.ToString();
					}
					else {
						Program.state.panelTemplateStringEdit_dict[row.Cells[0].Value.ToString()] = "";
					}
				}
			}
		}
		#endregion

		#region // PANEL LAST Functions

		/// <summary>
		/// This is the panelLast_nextAction method.
		/// It is used to process the action when button buttonNext is clicked.
		/// (here buttonNext becomes a finish button.
		/// </summary>
		private void panelLast_nextAction() {
			buttonBack.Enabled = false;
			buttonNext.Enabled = false;
			buttonCancel.Enabled = false;

            Program.state.isinpanelLast=true;
            if (!string.IsNullOrEmpty(Program.state.TextFileLocation))
            Read_Host_From_text_File(Program.state.TextFileLocation);
			// Database Output
			saveConfig();

			// Report Output
			ReportOutputer reportOutputer = new ReportOutputer();
			switch (Program.state.panelOutputSelect_State) {
				case State.PanelOutputSelectState.HTML:
					reportOutputer.output(Program.state.panelOutputSelect_OutputPath, ref Program.state.panelRecordEdit_ConfirmedRecord);
					break;
				case State.PanelOutputSelectState.DOCX:
					reportOutputer.output(Program.state.panelOutputSelect_OutputPath, ref Program.state.panelRecordEdit_ConfirmedRecord);
					break;
				case State.PanelOutputSelectState.XLSX:
					reportOutputer.output(Program.state.panelOutputSelect_OutputPath, ref Program.state.panelRecordEdit_ConfirmedRecord);
                    if (Program.state.panelOutputSelect_isOutputPluginOutput)
                    {
                        new TxtOutputFormat().ExportPluginOutput();
                    }
                    break;
				case State.PanelOutputSelectState.DOCXTEM:
					reportOutputer.output(Program.state.panelOutputSelect_OutputPath, Program.state.panelOutputSelect_TemplatePath, ref Program.state.panelRecordEdit_ConfirmedRecord, ref Program.state.panelTemplateStringEdit_dict);
					break;
			}
            MessageBox.Show("Report Generated", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Program.state.ForbiddenHost.Clear();
            Program.state.isinpanelLast = false;
		}
		#endregion

		#region // shared functions

		/// <summary>
		/// This is the FormMain_KeyDown method.
		/// It is used to trigger the Ctrl-S event to save the database config.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_KeyDown(object sender, KeyEventArgs e) {
			if (panel != Panel.FILEINPUT) {
				if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) {
					saveConfig();
				}
			}
		}

		/// <summary>
		/// This is the saveConfig method.
		/// It is used to handle the form features during the output of the database config
		/// and also output the config file.
		/// </summary>
		private void saveConfig() {
			Program.state.panelRecordEdit_isSaveConfig = false;

			this.Enabled = false;
			panelRecordEdit_nextAction();

			// Database Output
			caseDatabaseOutput();

			// enable
			this.Enabled = true;
            this.TopMost = true;
            this.TopMost = false;
			buttonBack.Enabled = true;
			panelRecordEdit_enableNextButton();
			buttonCancel.Enabled = true;

			Program.state.panelRecordEdit_isSaveConfig = true;
		}

		/// <summary>
		/// This is the caseDatabaseOutput method.
		/// It is used to output the database config file out.
		/// </summary>
		private void caseDatabaseOutput() {
			String directory = "";
			String messageText = "Creating Config...";

			if (File.Exists(Program.state.formCaseCreateAndOpenPath)) {
				File.Delete(Program.state.formCaseCreateAndOpenPath);
				directory = Program.state.formCaseCreateAndOpenPath.Substring(0, Program.state.formCaseCreateAndOpenPath.LastIndexOf("\\"));

				messageText = "Saving Config...";
			}
			else if (Directory.Exists(Program.state.formCaseCreateAndOpenPath)) {
				directory = Program.state.formCaseCreateAndOpenPath;
			}

			CaseDatabaser caseDatabaser = new CaseDatabaser(directory);

			Program.state.panelRecordEdit_isSaveConfig = false;

			//caseDatabaser.output();
			ThreadStart thread_delegate = new ThreadStart(caseDatabaser.output);
			Thread t = new Thread(thread_delegate);
			t.Start();

            FormMessage tempMessage = new FormMessage(messageText);
            tempMessage.Show(); 
            while (!Program.state.panelRecordEdit_isSaveConfig)
            {
                Application.DoEvents();
                Thread.Sleep(0);
            }
			tempMessage.Close();

			Program.state.formCaseCreateAndOpenPath = caseDatabaser.getPath();
		}

		#endregion

        #region // Filter functions
        private void panelRecordEdit_buttonFilter_Click(object sender, EventArgs e)
        {
            //String[] colString = { "Plugin Name", "Host Affected", "Description", "Impact", "Recommendation", "CVE", "BID", "OSVDB", "Reference Link" };
            // For show all
            if (panelRecordEdit_textBoxKeyWord.Text == "" )
            {
                foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows)
                {
                    if (row.Cells[(int)CellColumnIndex.PLUGINNAME].Value != null)
                        row.Visible = true;
                }
                return;
            }
            
            int tempIndex = panelRecordEdit_comboBoxFilter.SelectedIndex + 4;

            //caseSensitive
            bool caseSensitive = false;
            String filterWord = panelRecordEdit_textBoxKeyWord.Text;
            if (panelRecordEdit_comboBoxCase.SelectedIndex == 0)
            {
                caseSensitive = false;
                filterWord = filterWord.ToLower();
            }
            else if (panelRecordEdit_comboBoxCase.SelectedIndex == 1)
                caseSensitive = true;

            if (panelRecordEdit_comboBoxFilterMode.SelectedIndex == 0)
                //partial word
                foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows)
                {
                    if (row.Visible && row.Cells[(int)CellColumnIndex.PLUGINNAME].Value != null)
                    {
                        if (row.Cells[tempIndex].Value == null)
                            continue;
                        String rowString = row.Cells[tempIndex].Value.ToString() ;

                        if (!caseSensitive)
                        {
                            rowString = rowString.ToLower();
                        }

                        if (rowString.Contains(filterWord))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }          
            else if  (panelRecordEdit_comboBoxFilterMode.SelectedIndex == 1)
                //exact match
                foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows)
                {
                    if (row.Visible && row.Cells[(int)CellColumnIndex.PLUGINNAME].Value != null)
                    {
                        if (row.Cells[tempIndex].Value == null)
                            continue;
                        String rowString = row.Cells[tempIndex].Value.ToString();

                        if (!caseSensitive)
                        {
                            rowString = rowString.ToLower();
                        }

                        if (rowString == filterWord)
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            panelRecordEdit_textBoxKeyWord.Text = "";     
        }

        private void panelRawView_buttonShowAll_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in panelRawView_dataGridViewNessus.Rows)
            //    row.Visible = true;
            //foreach (DataGridViewRow row in panelRawView_dataGridViewNmap.Rows)
            //    row.Visible = true;
            //foreach (DataGridViewRow row in panelRawView_dataGridViewMBSA.Rows)
            //    row.Visible = true;

            panelRawView_dataGridViewMBSA.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawMBSA();
            panelRawView_dataGridViewNmap.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawNmap();
            panelRawView_dataGridViewNessus.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawNessus();
            panelRawView_dataGridViewAcunetix.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawAcunetix(); 
        }

        private void panelRawView_buttonFilter_Click(object sender, EventArgs e)
        {
            //String[] colString = { "Plugin Name", "Host Affected", "Description", "Impact", "Recommendation", "CVE", "BID", "OSVDB", "Reference Link" };
            
            // assume first col is id so skip it +1
            int tempIndex = panelRawView_comboBoxFilter.SelectedIndex + 1;
            string keyword = panelRawView_textBoxKeyword.Text;

            if (panelRawView_tabControl.SelectedIndex == 3)
            {
                string targetCol = panelRawView_dataGridViewAcunetix.Columns[tempIndex].Name.ToString();
                panelRawView_dataGridViewAcunetix.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawAcunetix(targetCol, keyword);
            }
            else if (panelRawView_tabControl.SelectedIndex == 0)
            {
                string targetCol = panelRawView_dataGridViewNmap.Columns[tempIndex].Name.ToString();
                panelRawView_dataGridViewNmap.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawNmap(targetCol, keyword);
            }
            else if (panelRawView_tabControl.SelectedIndex == 1)
            {
                string targetCol = panelRawView_dataGridViewNessus.Columns[tempIndex].Name.ToString();
                panelRawView_dataGridViewNessus.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawNessus(targetCol, keyword);

            }
            else if (panelRawView_tabControl.SelectedIndex == 2)
            {
                string targetCol = panelRawView_dataGridViewMBSA.Columns[tempIndex].Name.ToString();
                panelRawView_dataGridViewMBSA.DataSource = Program.state.panelRecordEdit_recordDatabaser.getBindingSourceRawMBSA(targetCol, keyword);

            }
            //foreach (DataGridViewRow row in panelRawView_dataGridViewNessus.Rows)
            //{
            //    if (row.Visible)
            //    {
            //        if (row.Cells[tempIndex].Value == null)
            //            continue;
            //        //BindingSource temp = new BindingSource(panelRawView_dataGridViewNessus.DataSource);

            //        if (row.Cells[tempIndex].Value.ToString().Contains(panelRawView_textBoxKeyword.Text))
            //        {
            //            row.Visible = true;
            //        }
            //        else
            //        {
            //            if (row.Index == 0)
            //            {
            //                Program.state.panelRecordEdit_recordDatabaser.rawNessusBindingSource.Position = -1;


            //            }
            //            row.Visible = false;
            //        }
            //    }
            //}
            //foreach (DataGridViewRow row in panelRawView_dataGridViewNmap.Rows)
            //{
            //    if (row.Visible)
            //    {
            //        if (row.Cells[tempIndex].Value==null)
            //            continue;
            //        if (row.Cells[tempIndex].Value.ToString().Contains(panelRawView_textBoxKeyword.Text))
            //        {
            //            row.Visible = true;
            //        }
            //        else
            //        {
            //            row.Visible = false;
            //        }
            //    }
            //}
            //foreach (DataGridViewRow row in panelRawView_dataGridViewMBSA.Rows)
            //{
            //    if (row.Visible)
            //    {
            //        if (row.Cells[tempIndex].Value == null)
            //            continue;
            //        if (row.Cells[tempIndex].Value.ToString().Contains(panelRawView_textBoxKeyword.Text))
            //        {
            //            row.Visible = true;
            //        }
            //        else
            //        {
            //            row.Visible = false;
            //        }
            //    }
            //}  
        }
        //// Configures the autogenerated columns, replacing their header
        //// cells with AutoFilter header cells. 
        //private void panelRecordEdit_dataGridView_BindingContextChanged(object sender, EventArgs e)
        //{
        //    //// Continue only if the data source has been set.
        //    if (panelRecordEdit_dataGridView.DataSource == null)
        //    {
        //        return;
        //    }

        //    // Add the AutoFilter header cell to each column.
        //    foreach (DataGridViewColumn col in panelRecordEdit_dataGridView.Columns)
        //    {
        //        col.HeaderCell = new
        //            DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
        //    }
        //    //panelRecordEdit_dataGridView.Columns[19].HeaderCell = new
        //    //        DataGridViewAutoFilterColumnHeaderCell(panelRecordEdit_dataGridView.Columns[19].HeaderCell);
        //    // Resize the columns to fit their contents.
        //    panelRecordEdit_dataGridView.AutoResizeColumns();
        //}


        private void panelRawView_dataGridViewNessus_BindingContextChanged(object sender, EventArgs e)
        {
            // Continue only if the data source has been set.
            if (panelRawView_dataGridViewNessus.DataSource == null){
                return;
            }
            // Add the AutoFilter header cell to each column.
            foreach (DataGridViewColumn col in panelRawView_dataGridViewNessus.Columns)
            {
                col.HeaderCell = new
                    DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
            }

            panelRawView_dataGridViewNessus.AutoResizeColumns();
        }

        private void panelRawView_dataGridViewAcunetix_BindingContextChanged(object sender, EventArgs e)
        {
            // Continue only if the data source has been set.
            if (panelRawView_dataGridViewAcunetix.DataSource == null)
            {
                return;
            }
            // Add the AutoFilter header cell to each column.
            foreach (DataGridViewColumn col in panelRawView_dataGridViewAcunetix.Columns)
            {
                col.HeaderCell = new
                    DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
            }

            panelRawView_dataGridViewAcunetix.AutoResizeColumns();
        }
        
        private void panelRawView_dataGridViewNmap_BindingContextChanged(object sender, EventArgs e)
        {
            // Continue only if the data source has been set.
            if (panelRawView_dataGridViewNmap.DataSource == null)
            {
                return;
            }
            // Add the AutoFilter header cell to each column.
            foreach (DataGridViewColumn col in panelRawView_dataGridViewNmap.Columns)
            {
                col.HeaderCell = new
                    DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
            }

            panelRawView_dataGridViewNmap.AutoResizeColumns();
        }

        private void panelRawView_dataGridViewMBSA_BindingContextChanged(object sender, EventArgs e)
        {
            // Continue only if the data source has been set.
            if (panelRawView_dataGridViewMBSA.DataSource == null)
            {
                return;
            }
            // Add the AutoFilter header cell to each column.
            foreach (DataGridViewColumn col in panelRawView_dataGridViewMBSA.Columns)
            {
                col.HeaderCell = new
                    DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
                
            }

            panelRawView_dataGridViewMBSA.AutoResizeColumns();

        }

        #endregion

        #region // Sort functions
        private void panelRecordEdit_dataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.Handled = false;
            if (e.CellValue1 == null)
            {
                e.SortResult = -1;
                e.Handled = true;
                return;
            }
            else if (e.CellValue2 == null)
            {
                e.SortResult = 1;
                e.Handled = true;
                return;
            }

            else if (e.CellValue2 == null)
            if (e.Column.Name == "riskLevel")
            {
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskLevel"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskLevel"].Value.ToString() == "Low")
                {
                    e.SortResult = -1;
                    e.Handled = true;

                }
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskLevel"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskLevel"].Value.ToString() == "Low")
                {
                    e.SortResult = 1;
                    e.Handled = true;

                }
            }
            if (e.Column.Name == "id")
            {
                if (int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["id"].Value.ToString()) <
                    int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["id"].Value.ToString() ))
                {
                    e.SortResult = -1;
                    e.Handled = true;

                }
                if (int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["id"].Value.ToString()) >=
                    int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["id"].Value.ToString()))
                {
                    e.SortResult = 1;
                    e.Handled = true;

                }
            }

            if (e.Handled != true)
            {
                // Try to sort based on the cells in the current column.
                e.SortResult = System.String.Compare(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
                e.Handled = true;
            }

            //sort by id when draw
            if (e.SortResult == 0 && e.Column.Name != "id")
            {
                if (int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["id"].Value.ToString()) <
                int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["id"].Value.ToString()))
                {
                    e.SortResult = -1;
                    e.Handled = true;

                }
                if (int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["id"].Value.ToString()) >=
                    int.Parse(panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["id"].Value.ToString()))
                {
                    e.SortResult = 1;
                    e.Handled = true;

                }
            }
        }
        private void panelRawView_dataGridViewNessus_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "riskfactor")
            {
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskfactor"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskfactor"].Value.ToString() == "Low")
                {
                    e.SortResult = -1;
                    e.Handled = true;
                    return;
                }
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskfactor"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskfactor"].Value.ToString() == "Low")
                {
                    e.SortResult = 1;
                    e.Handled = true;
                    return;
                }
            }

            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());
            e.Handled = true;

        }
        private void panelRawView_dataGridViewNmap_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "riskfactor")
            {
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskfactor"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskfactor"].Value.ToString() == "Low")
                {
                    e.SortResult = -1;
                    e.Handled = true;
                    return;
                }
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskfactor"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskfactor"].Value.ToString() == "Low")
                {
                    e.SortResult = 1;
                    e.Handled = true;
                    return;
                }
            }

            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());
            e.Handled = true;

        }

        private void panelRawView_dataGridViewMBSA_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            // If the cells are equal, sort based on the ID column.
            if (e.Column.Name == "riskfactor")
            {
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskfactor"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskfactor"].Value.ToString() == "Low")
                {
                    e.SortResult = -1;
                    e.Handled = true;
                    return;
                }
                if (panelRecordEdit_dataGridView.Rows[e.RowIndex2].Cells["riskfactor"].Value.ToString() == "Medium"
                    && panelRecordEdit_dataGridView.Rows[e.RowIndex1].Cells["riskfactor"].Value.ToString() == "Low")
                {
                    e.SortResult = 1;
                    e.Handled = true;
                    return;
                }
            }

            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());
            e.Handled = true;
        }
        #endregion

        private void panelRecordEdit_dataGridView_reloadBackgroundColor()
        {
            panelRecordEdit_dataGridView.SuspendLayout();
            Color highColor = Color.FromKnownColor(KnownColor.Red);
            Color lowColor = Color.FromKnownColor(KnownColor.LightBlue);
            Color mediumColor = Color.FromKnownColor(KnownColor.Yellow);
            Color noneColor = Color.FromKnownColor(KnownColor.Gray);
            Color openColor = Color.FromKnownColor(KnownColor.LightGreen);
            foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows)
            {
                if (row.Cells[(int)CellColumnIndex.RISKFACTOR].Value == null)
                    continue;
                RiskFactor riskFactor = RiskFactorFunction.getEnum(row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString());
                if (riskFactor == RiskFactor.HIGH)
                    row.DefaultCellStyle.BackColor = highColor;
                else if (riskFactor == RiskFactor.LOW)
                    row.DefaultCellStyle.BackColor = lowColor;
                else if (riskFactor == RiskFactor.MEDIUM)
                    row.DefaultCellStyle.BackColor = mediumColor;
                else if (riskFactor == RiskFactor.NONE)
                    row.DefaultCellStyle.BackColor = noneColor;
                else if (riskFactor == RiskFactor.OPEN)
                    row.DefaultCellStyle.BackColor = openColor ;
                row.ReadOnly = true;
            }
            panelRecordEdit_checkboxHigh.BackColor = highColor;
            panelRecordEdit_checkboxLow.BackColor = lowColor;
            panelRecordEdit_checkboxMedium.BackColor = mediumColor;
            panelRecordEdit_checkboxNone.BackColor = noneColor;
            panelRecordEdit_checkboxOpenPort.BackColor = openColor;
            panelRecordEdit_dataGridView.ResumeLayout();
        }

        private void panelRecordEdit_buttonPermanentDataBase_Click(object sender, EventArgs e)
        {
            //this.Enabled= false;
            new FormPermanentDatabase().ShowDialog();
            //this.Enabled = true;
        }

        private void panelRecordEdit_buttonIPHostTable_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            new IPHostTable().ShowDialog();
            //this.Enabled = true;
        }

        private void panelRecordEdit_buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            Dictionary<int, DataEntry> undoList = new Dictionary<int, DataEntry>();
            Dictionary<int, bool> undoEdited = new Dictionary<int, bool>();
            Dictionary<int, bool> undoMegered = new Dictionary<int,bool>();


            int counting_for_FindingDetail = 0;

            for (int i = 0; i < panelRecordEdit_dataGridView.Rows.Count;i++ )
            {
                DataGridViewRow row = panelRecordEdit_dataGridView.Rows[i];
                if (row.Cells[(int)CellColumnIndex.SELECTED]!=null && (bool)row.Cells[(int)CellColumnIndex.SELECTED].Value)
                {
                    //panelRecordEdit_dataGridView.Rows.Remove(row);
                    //i--;
                    int dbid = int.Parse(row.Cells[(int)CellColumnIndex.DBID].Value.ToString());
                    undoList[dbid] = panelRecordEdit_rowToDataEntry(row);
                    undoEdited[dbid] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
                    undoMegered[dbid] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;

                    //@@@@@Program.state.panelRecordEdit_recordDatabaser.deleteEditedRecordEntry(dbid);
                    Program.state.panelRecordEdit_recordDatabaser.guideleteNessusFindingEntry(dbid);
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdatedeleteFindingDetailEntry(dbid, counting_for_FindingDetail);
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdatedeleteFindingReferenceEntry(dbid, counting_for_FindingDetail);
                    panelRecordEdit_dataGridView.Rows[i].Cells[(int)CellColumnIndex.PLUGINNAME].Value = null;
                    panelRecordEdit_dataGridView.Rows[i].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                    panelRecordEdit_dataGridView.Rows[i].Visible = false;
                    Program.state.panelRecordEdit_RecordSelected[i] = false;
                    counting_for_FindingDetail++;
                }
            }
            //panelRecordEdit_dataGridView.Rows.Clear();
            //// fill other cell value on the dataGridView
            //panelRecordEdit_fillDataGridView();
            //panelRecordEdit_dataGridView_reloadBackgroundColor();
            Program.state.panelRecordEdit_undoDataEntryList = undoList;
            Program.state.panelRecordEdit_undoEdited = undoEdited;
            Program.state.panelRecordEdit_undoMegered = undoMegered;            
            
            panelRecordEdit_buttonUndo.Enabled = true;
            panelRecordEdit_enableNextButton();
        }

        #region // Acunetix Raw Excel Output
        private enum AcunetixRawCellColumnIndex : int
        {
            ID = 0,
            PLUGINNAME = 1,
            IPLIST = 2,
            DESCRIPTION = 3,
            IMPACT = 4,
            RISKFACTOR =5,
            RECOMMENDATION = 6,
            FILENAME = 7,
            SUBDOMAIN = 8,
            SUBDIRECTORY = 9,
            DEPARTMENT = 10,
            AFFECTEDITEM = 11,
            AFFECTEDITEMLINK = 12,
            AFFECTEDITEMDETAIL = 13,
            REQUEST = 14,
            RESPONSE = 15,
            MODULENAME = 16,
            ISFALSEPOSITIVE = 17,
            AOP_SOURCEFILE = 18,
            AOP_SOURCELINE = 19,
            AOP_ADDITIONAL = 20 ,
            DETAILEDINFORMATION = 21,
            ACUNETIXTYPE = 22,
            REFERENCE = 23,
        }
        private enum NmapRawCellColumnIndex : int
        {
            ID = 0,
            PLUGINNAME = 1,
            IPLIST = 2,
            DESCRIPTION = 3,
            RISKFACTOR = 4,
            FILENAME = 5,
            ENTRYTYPE = 6,
            OS = 7,
            OSDETAIL = 8,
            OPENPORTLIST = 9,
            CLOSEDPORTLIST = 10,
            FILTERPORTLIST = 11,
            UNKNOWNPORTLIST = 12
        }
        private enum NessusRawCellColumnIndex : int
        {
            ID = 0,
            PLUGINNAME = 1,
            IPLIST = 2,
            DESCRIPTION = 3,
            IMPACT = 4,
            RISKFACTOR = 5,
            RECOMMENDATION = 6,
            BIDLIST = 7,
            CVELIST = 8,
            OSVDBLIST = 9,
            REFERENCELINK = 10,
            FILENAME = 11,
            ENTRYTYPE = 12,
            PORT = 13,
            PROTOCOL = 14,
            SVC_NAME = 15,
            PLUGINFAMILY = 16,
            PLUGIN_PUBLICATION_DATE = 17,
            PLUGIN_MODIFICATION_DATE = 18,
            CVSS_VECTOR = 19,
            CVSS_BASE_SCORE = 20,
            PLUGIN_OUTPUT = 21,
            PLUGIN_VERSION = 22,
            SEE_ALSOLIST = 23,
            PLUGINID = 24,
            MICROSOFTID = 25,
            SEVERITY = 26
        }
        private enum MBSARawCellColumnIndex : int
        {
            ID = 0,
            PLUGINNAME = 1,
            IPLIST = 2,
            DESCRIPTION = 3,
            IMPACT = 4,
            RISKFACTOR = 5,
            RECOMMENDATION = 6,
            BIDLIST = 7,
            CVELIST = 8,
            OSVDBLIST = 9,
            REFERENCELINK = 10,
            FILENAME = 11,
            ENTRYTYPE = 12,
            CHECKID = 13,
            CHECKGRADE = 14,
            CHECKTYPE = 15,
            CHECKCAT = 16,
            CHECKRANK = 17,
            CHECKNAME = 18,
            CHECKURL1 = 19,
            CHECKURL2 = 20,
            CHECKGROUPID = 21,
            CHECKGROUPNAME = 22,
            DETAILTEXT = 23,
            UPDATEDATAISINSTALLED = 24,
            UPDATEDATARESTARTREQUIRED = 25,
            UPDATEDATAID = 26,
            UPDATEDATABULLETINID = 27,
            UPDATEDATAGUID = 28,
            UPDATEDATAKBID = 29,
            UPDATEDATATYPE = 30,
            UPDATEDATAINFORMATIONURL = 31,
            UPDATEDATADOWNLOADURL = 32,
            SEVERITY = 33,
            TABLEHEADER = 34,
            TABLEROWDATA = 35
        }
        private void buttonGenExcel_Click(object sender, EventArgs e)
        {
            saveFileDialogExcel.Filter = "Excel File (.xlsx)|*.xlsx";
            saveFileDialogExcel.DefaultExt = "xlsx";
            this.Enabled = false;
            saveFileDialogExcel.ShowDialog();
            this.Enabled = true;
        }

        private void buttonGenExcelSelected_Click(object sender, EventArgs e)
        {
            saveFileDialogExcelSelected.Filter = "Excel File (.xlsx)|*.xlsx";
            saveFileDialogExcelSelected.DefaultExt = "xlsx";
            this.Enabled = false;
            saveFileDialogExcelSelected.ShowDialog();
            this.Enabled = true;
        }

        private void saveFileDialogExcel_FileOk(object sender, CancelEventArgs e)
        {
            //set to output excel format
            Program.state.panelRecordEdit_record.setIsOutputRecord(true);
            DataEntry.EntryType outputEntryType = 0;

            if (panelRawView_tabControl.SelectedIndex==3){ //acunetix
                outputEntryType = DataEntry.EntryType.Acunetix;
            }
            else if (panelRawView_tabControl.SelectedIndex==0) //nmap
            {
                outputEntryType = DataEntry.EntryType.NMAP;            
            }
            else if (panelRawView_tabControl.SelectedIndex==1) //nessus
            {
                outputEntryType = DataEntry.EntryType.NESSUS;
            }
            else if (panelRawView_tabControl.SelectedIndex == 2) //mbsa
            {
                outputEntryType = DataEntry.EntryType.MBSA;
            }
            Program.state.panelRecordEdit_record.setOutputEntryType(outputEntryType);
            new XlsxOutputFormater().output(saveFileDialogExcel.FileName, ref Program.state.panelRecordEdit_record);
            Program.state.panelRecordEdit_record.setIsOutputRecord(false);
        }

        private void saveFileDialogExcelSelected_FileOk(object sender, CancelEventArgs e)
        {
            Record.Record outputRecord = new Record.Record();
            DataEntry.EntryType outputEntryType = 0;

            if (panelRawView_tabControl.SelectedIndex == 3)
            { //acunetix
                outputEntryType = DataEntry.EntryType.Acunetix;

                foreach (DataGridViewRow row in panelRawView_dataGridViewAcunetix.Rows)
                {
                    bool selected = false;
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Selected)
                        {
                            selected = true;
                            break;
                        }

                    if (selected)
                    {
                        String pluginName = "";
                        String ipList = "";
                        String description = "";
                        String impact = "";
                        RiskFactor riskFactor = RiskFactor.NULL;
                        String recommendation = "";
                        String fileName = "";
                        AffectedItem item = new AffectedItem();
                        List<AffectedItem> affectedItemList = new List<AffectedItem>();
                        String subDomain = "";


                        String moduleName = "";
                        String isFalsePositive = "";
                        String AOP_SourceFile = "";
                        String AOP_SourceLine = "";
                        String AOP_Additional = "";
                        String detailedInformation = "";
                        String acunetixType = "";
                        //List<AcunetixReference> acunetixReferenceList = new List<AcunetixReference>();
                        String acunetixReferenceString = "";

                        if (row.Cells[(int)AcunetixRawCellColumnIndex.MODULENAME].Selected)
                            moduleName = row.Cells[(int)AcunetixRawCellColumnIndex.MODULENAME].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.ISFALSEPOSITIVE].Selected)
                            isFalsePositive = row.Cells[(int)AcunetixRawCellColumnIndex.ISFALSEPOSITIVE].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.AOP_SOURCEFILE].Selected)
                            AOP_SourceFile = row.Cells[(int)AcunetixRawCellColumnIndex.AOP_SOURCEFILE].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.AOP_SOURCELINE].Selected)
                            AOP_SourceLine = row.Cells[(int)AcunetixRawCellColumnIndex.AOP_SOURCELINE].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.AOP_ADDITIONAL].Selected)
                            AOP_Additional = row.Cells[(int)AcunetixRawCellColumnIndex.AOP_ADDITIONAL].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.DETAILEDINFORMATION].Selected)
                            detailedInformation = row.Cells[(int)AcunetixRawCellColumnIndex.DETAILEDINFORMATION].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.ACUNETIXTYPE].Selected)
                            acunetixType = row.Cells[(int)AcunetixRawCellColumnIndex.ACUNETIXTYPE].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.AFFECTEDITEMLINK].Selected)
                            item.setLink(row.Cells[(int)AcunetixRawCellColumnIndex.AFFECTEDITEMLINK].Value.ToString());

                        if (row.Cells[(int)AcunetixRawCellColumnIndex.PLUGINNAME].Selected)
                            pluginName = row.Cells[(int)AcunetixRawCellColumnIndex.PLUGINNAME].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.IPLIST].Selected)
                            ipList = row.Cells[(int)AcunetixRawCellColumnIndex.IPLIST].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.DESCRIPTION].Selected)
                            description = row.Cells[(int)AcunetixRawCellColumnIndex.DESCRIPTION].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.IMPACT].Selected)
                            impact = row.Cells[(int)AcunetixRawCellColumnIndex.IMPACT].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.RISKFACTOR].Selected)
                            riskFactor = RiskFactorFunction.getEnum(row.Cells[(int)AcunetixRawCellColumnIndex.RISKFACTOR].Value.ToString());
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.RECOMMENDATION].Selected)
                            recommendation = row.Cells[(int)AcunetixRawCellColumnIndex.RECOMMENDATION].Value.ToString();
                        //if (row.Cells[(int)AcunetixRawCellColumnIndex.CVELIST].Selected)
                        //    cveList = row.Cells[(int)AcunetixRawCellColumnIndex.CVELIST].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.FILENAME].Selected)
                            fileName = row.Cells[(int)AcunetixRawCellColumnIndex.FILENAME].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.SUBDOMAIN].Selected)
                            subDomain = row.Cells[(int)AcunetixRawCellColumnIndex.SUBDOMAIN].Value.ToString();
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.SUBDIRECTORY].Selected)
                            item.setSubDirectory(row.Cells[(int)AcunetixRawCellColumnIndex.SUBDIRECTORY].Value.ToString());
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.DEPARTMENT].Selected)
                            item.setDepartment(row.Cells[(int)AcunetixRawCellColumnIndex.DEPARTMENT].Value.ToString());
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.AFFECTEDITEM].Selected)
                            item.setName(row.Cells[(int)AcunetixRawCellColumnIndex.AFFECTEDITEM].Value.ToString());
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.AFFECTEDITEMDETAIL].Selected)
                            item.addDetail(row.Cells[(int)AcunetixRawCellColumnIndex.AFFECTEDITEMDETAIL].Value.ToString());
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.REQUEST].Selected)
                            item.addRequest(row.Cells[(int)AcunetixRawCellColumnIndex.REQUEST].Value.ToString());
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.RESPONSE].Selected)
                            item.addResponse(row.Cells[(int)AcunetixRawCellColumnIndex.RESPONSE].Value.ToString());
                        if (row.Cells[(int)AcunetixRawCellColumnIndex.REFERENCE].Selected)
                        {
                            //String referenceListString = row.Cells[(int)AcunetixRawCellColumnIndex.REFERENCE].Value.ToString();
                            //String[] referenceArrary = referenceListString.Split(',');
                            //foreach (String reference in referenceArrary)
                            //{
                            //    String[] temp = reference.Split(' ');                          
                            //    acunetixReferenceList.Add(new AcunetixReference(temp[0],temp[1]));
                            //}
                            acunetixReferenceString = row.Cells[(int)AcunetixRawCellColumnIndex.REFERENCE].Value.ToString();
                        }

                        affectedItemList.Add(item);

                        AcunetixDataEntry entry = new AcunetixDataEntry(pluginName,
                                                                        ipList,
                                                                        description,
                                                                        impact,
                                                                        riskFactor,
                                                                        recommendation,
                                                                        fileName,
                                                                        affectedItemList,
                                                                        moduleName,
                                                                        isFalsePositive,
                                                                        AOP_SourceFile,
                                                                        AOP_SourceLine,
                                                                        AOP_Additional,
                                                                        detailedInformation,
                                                                        acunetixType,
                                                                        null,
                                                                        true);
                        entry.setsubDomain(subDomain);
                        entry.setAcunetixReferenceString(acunetixReferenceString);
                        outputRecord.acunetixAddEntry(entry);
                    }
                }
            }
            else if (panelRawView_tabControl.SelectedIndex == 0) //nmap
            {
                outputEntryType = DataEntry.EntryType.NMAP;

                foreach (DataGridViewRow row in panelRawView_dataGridViewNmap.Rows)
                {
                    bool selected = false;
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Selected)
                        {
                            selected = true;
                            break;
                        }

                    if (selected)
                    {
                        String pluginName = "";
                        String ipList = "";
                        String description = "";
                        RiskFactor riskFactor = RiskFactor.NULL;
                        String fileName = "";
                        String os = "";
                        String osDetail = "";
                        String closedPort = "";
                        String filteredPort = "";
                        String unknownPort = "";
                        String openPort = "";
                        if (row.Cells[(int)NmapRawCellColumnIndex.PLUGINNAME].Selected)
                            pluginName = row.Cells[(int)NmapRawCellColumnIndex.PLUGINNAME].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.IPLIST].Selected)
                            ipList = row.Cells[(int)NmapRawCellColumnIndex.IPLIST].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.DESCRIPTION].Selected)
                            description = row.Cells[(int)NmapRawCellColumnIndex.DESCRIPTION].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.RISKFACTOR].Selected)
                            riskFactor = RiskFactorFunction.getEnum(row.Cells[(int)NmapRawCellColumnIndex.RISKFACTOR].Value.ToString());
                        if (row.Cells[(int)NmapRawCellColumnIndex.FILENAME].Selected)
                            fileName = row.Cells[(int)NmapRawCellColumnIndex.FILENAME].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.OS].Selected)
                            os = row.Cells[(int)NmapRawCellColumnIndex.OS].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.OSDETAIL].Selected)
                            osDetail = row.Cells[(int)NmapRawCellColumnIndex.OSDETAIL].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.CLOSEDPORTLIST].Selected)
                            closedPort = row.Cells[(int)NmapRawCellColumnIndex.CLOSEDPORTLIST].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.FILTERPORTLIST].Selected)
                            filteredPort = row.Cells[(int)NmapRawCellColumnIndex.FILTERPORTLIST].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.UNKNOWNPORTLIST].Selected)
                            unknownPort = row.Cells[(int)NmapRawCellColumnIndex.UNKNOWNPORTLIST].Value.ToString();
                        if (row.Cells[(int)NmapRawCellColumnIndex.OPENPORTLIST].Selected)
                            openPort = row.Cells[(int)NmapRawCellColumnIndex.OPENPORTLIST].Value.ToString();
                        NmapDataEntry entry = new NmapDataEntry(pluginName,
                                                                        ipList,
                                                                        description,
                                                                        riskFactor,
                                                                        fileName,
                                                                        openPort.Split(' ').ToList(),
                                                                        filteredPort.Split(' ').ToList(),
                                                                        closedPort.Split(' ').ToList(),
                                                                        unknownPort.Split(' ').ToList(),
                                                                        os,
                                                                        osDetail);

                        outputRecord.nmapAddEntry(entry);
                    }
                }
            }
            else if (panelRawView_tabControl.SelectedIndex == 1) //nessus
            {
                outputEntryType = DataEntry.EntryType.NESSUS;
                foreach (DataGridViewRow row in panelRawView_dataGridViewNessus.Rows)
                {
                    bool selected = false;
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Selected)
                        {
                            selected = true;
                            break;
                        }

                    if (selected)
                    {
                        String pluginName = "";
                        String ipList = "";
                        String description = "";
                        String impact = "";
                        RiskFactor riskFactor = RiskFactor.NULL;
                        String recommendation = "";
                        String fileName = "";

                        String severityString = "";
                        String cve = "";
                        String bid = "";
                        String osvdb = "";
                        String port = "";
                        String protocol = "";
                        String svc_name = "";
                        String pluginFamily = "";
                        String plugin_publication_date = "";
                        String plugin_modification_date = "";
                        String cvss_vector = "";
                        String cvss_base_score = "";
                        String plugin_output = "";
                        String plugin_version = "";
                        String see_also = "";
                        String pluginId = "";
                        String microsoftID = "";
                        String referenceLink = "";

                        if (row.Cells[(int)NessusRawCellColumnIndex.PLUGINNAME].Selected)
                            pluginName = row.Cells[(int)NessusRawCellColumnIndex.PLUGINNAME].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.IPLIST].Selected)
                            ipList = row.Cells[(int)NessusRawCellColumnIndex.IPLIST].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.DESCRIPTION].Selected)
                            description = row.Cells[(int)NessusRawCellColumnIndex.DESCRIPTION].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.IMPACT].Selected)
                            impact = row.Cells[(int)NessusRawCellColumnIndex.IMPACT].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.RISKFACTOR].Selected)
                            riskFactor = RiskFactorFunction.getEnum(row.Cells[(int)NessusRawCellColumnIndex.RISKFACTOR].Value.ToString());
                        if (row.Cells[(int)NessusRawCellColumnIndex.RECOMMENDATION].Selected)
                            recommendation = row.Cells[(int)NessusRawCellColumnIndex.RECOMMENDATION].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.FILENAME].Selected)
                            fileName = row.Cells[(int)NessusRawCellColumnIndex.FILENAME].Value.ToString();

                        if (row.Cells[(int)NessusRawCellColumnIndex.SEVERITY].Selected)
                            severityString = (row.Cells[(int)NessusRawCellColumnIndex.SEVERITY].Value).ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.CVELIST].Selected)
                            cve = row.Cells[(int)NessusRawCellColumnIndex.CVELIST].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.BIDLIST].Selected)
                            bid = row.Cells[(int)NessusRawCellColumnIndex.BIDLIST].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.OSVDBLIST].Selected)
                            osvdb = row.Cells[(int)NessusRawCellColumnIndex.OSVDBLIST].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PORT].Selected)
                            port = row.Cells[(int)NessusRawCellColumnIndex.PORT].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PROTOCOL].Selected)
                            protocol = row.Cells[(int)NessusRawCellColumnIndex.PROTOCOL].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.SVC_NAME].Selected)
                            svc_name = row.Cells[(int)NessusRawCellColumnIndex.SVC_NAME].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PLUGINFAMILY].Selected)
                            pluginFamily = row.Cells[(int)NessusRawCellColumnIndex.PLUGINFAMILY].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_PUBLICATION_DATE].Selected)
                            plugin_publication_date = row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_PUBLICATION_DATE].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_MODIFICATION_DATE].Selected)
                            plugin_modification_date = row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_MODIFICATION_DATE].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.CVSS_VECTOR].Selected)
                            cvss_vector = row.Cells[(int)NessusRawCellColumnIndex.CVSS_VECTOR].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.CVSS_BASE_SCORE].Selected)
                            cvss_base_score = row.Cells[(int)NessusRawCellColumnIndex.CVSS_BASE_SCORE].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_OUTPUT].Selected)
                            plugin_output = row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_OUTPUT].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_VERSION].Selected)
                            plugin_version = row.Cells[(int)NessusRawCellColumnIndex.PLUGIN_VERSION].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.SEE_ALSOLIST].Selected)
                            see_also = row.Cells[(int)NessusRawCellColumnIndex.SEE_ALSOLIST].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.PLUGINID].Selected)
                            pluginId = row.Cells[(int)NessusRawCellColumnIndex.PLUGINID].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.MICROSOFTID].Selected)
                            microsoftID = row.Cells[(int)NessusRawCellColumnIndex.MICROSOFTID].Value.ToString();
                        if (row.Cells[(int)NessusRawCellColumnIndex.REFERENCELINK].Selected)
                            referenceLink = row.Cells[(int)NessusRawCellColumnIndex.REFERENCELINK].Value.ToString();

                        NessusDataEntry entry = new NessusDataEntry(pluginName,
												                    ipList,
												                    description,
												                    impact,
												                    severityString,
												                    riskFactor,
												                    recommendation,
												                    cve.Split(", ".ToCharArray()).ToList(),
												                    bid.Split(", ".ToCharArray()).ToList(),
                                                                    osvdb.Split(", ".ToCharArray()).ToList(),
                                                                    fileName,
                                                                    port,
                                                                    protocol,
                                                                    svc_name,
                                                                    pluginFamily,
                                                                    plugin_publication_date,
                                                                    plugin_modification_date,
                                                                    cvss_vector,
                                                                    cvss_base_score,
                                                                    plugin_output,
                                                                    plugin_version,
                                                                    see_also.Split(", ".ToCharArray()).ToList(),
                                                                    pluginId,
                                                                    microsoftID,
                                                                    referenceLink);


                        outputRecord.nessusAddRawEntry(entry);
                    }
                }
            }
            else if (panelRawView_tabControl.SelectedIndex == 2) //mbsa
            {
                outputEntryType = DataEntry.EntryType.MBSA;
                foreach (DataGridViewRow row in panelRawView_dataGridViewMBSA.Rows)
                {
                    bool selected = false;
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Selected)
                        {
                            selected = true;
                            break;
                        }

                    if (selected)
                    {
                        String pluginName = "";
                        String ipList = "";
                        String description = "";
                        String impact = "";
                        RiskFactor riskFactor = RiskFactor.NULL;
                        String recommendation = "";
                        String fileName = "";
                        String referenceLink = "";

                        String cve = "";
                        String bid = "";
                        String osvdb = "";

                        string checkID = "";
                        string checkGrade = "";
                        string checkType = "";
                        string checkCat = "";
                        string checkRank = "";
                        string checkName = "";
                        string checkURL1 = "";
                        string checkURL2 = "";
                        string checkGroupID = "";
                        string checkGroupName = "";

                        string detailText = "";

                        string updateDataIsInstalled = "";
                        string updateDataRestartRequired = "";

                        string severityString = "";
                        string updateDataID = "";
                        string updateDataGUID = "";
                        string updateDataBulletinID = "";
                        string updateDataKBID = "";
                        string updateDataType = "";

                        string updateDataInformationURL = "";
                        string updateDataDownloadURL = "";

                        string tableHeaderString = null; 
                        string tableRowDataString = null;


                        if (row.Cells[(int)MBSARawCellColumnIndex.PLUGINNAME].Selected)
                            pluginName = row.Cells[(int)MBSARawCellColumnIndex.PLUGINNAME].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.IPLIST].Selected)
                            ipList = row.Cells[(int)MBSARawCellColumnIndex.IPLIST].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.DESCRIPTION].Selected)
                            description = row.Cells[(int)MBSARawCellColumnIndex.DESCRIPTION].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.IMPACT].Selected)
                            impact = row.Cells[(int)MBSARawCellColumnIndex.IMPACT].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.RISKFACTOR].Selected)
                            riskFactor = RiskFactorFunction.getEnum(row.Cells[(int)MBSARawCellColumnIndex.RISKFACTOR].Value.ToString());
                        if (row.Cells[(int)MBSARawCellColumnIndex.RECOMMENDATION].Selected)
                            recommendation = row.Cells[(int)MBSARawCellColumnIndex.RECOMMENDATION].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.FILENAME].Selected)
                            fileName = row.Cells[(int)MBSARawCellColumnIndex.FILENAME].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.SEVERITY].Selected)
                        {

                            severityString = row.Cells[(int)MBSARawCellColumnIndex.SEVERITY].Value.ToString();
                        }
                        if (row.Cells[(int)MBSARawCellColumnIndex.CVELIST].Selected)
                            cve = row.Cells[(int)MBSARawCellColumnIndex.CVELIST].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.BIDLIST].Selected)
                            bid = row.Cells[(int)MBSARawCellColumnIndex.BIDLIST].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.OSVDBLIST].Selected)
                            osvdb = row.Cells[(int)MBSARawCellColumnIndex.OSVDBLIST].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.REFERENCELINK].Selected)
                            referenceLink = row.Cells[(int)MBSARawCellColumnIndex.REFERENCELINK].Value.ToString();

                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKID].Selected)
                            checkID = row.Cells[(int)MBSARawCellColumnIndex.CHECKID].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKGRADE].Selected)
                            checkGrade = row.Cells[(int)MBSARawCellColumnIndex.CHECKGRADE].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKTYPE].Selected)
                            checkType = row.Cells[(int)MBSARawCellColumnIndex.CHECKTYPE].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKCAT].Selected)
                            checkCat = row.Cells[(int)MBSARawCellColumnIndex.CHECKCAT].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKRANK].Selected)
                            checkRank = row.Cells[(int)MBSARawCellColumnIndex.CHECKRANK].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKNAME].Selected)
                            checkName = row.Cells[(int)MBSARawCellColumnIndex.CHECKNAME].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKURL1].Selected)
                            checkURL1 = row.Cells[(int)MBSARawCellColumnIndex.CHECKURL1].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKURL2].Selected)
                            checkURL2 = row.Cells[(int)MBSARawCellColumnIndex.CHECKURL2].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKGROUPID].Selected)
                            checkGroupID = row.Cells[(int)MBSARawCellColumnIndex.CHECKGROUPID].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.CHECKGROUPNAME].Selected)
                            checkGroupName = row.Cells[(int)MBSARawCellColumnIndex.CHECKGROUPNAME].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.DETAILTEXT].Selected)
                            detailText = row.Cells[(int)MBSARawCellColumnIndex.DETAILTEXT].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAISINSTALLED].Selected)
                            updateDataIsInstalled = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAISINSTALLED].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATARESTARTREQUIRED].Selected)
                            updateDataRestartRequired = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATARESTARTREQUIRED].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAID].Selected)
                            updateDataID = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAID].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAGUID].Selected)
                            updateDataGUID = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAGUID].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATABULLETINID].Selected)
                            updateDataBulletinID = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATABULLETINID].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAKBID].Selected)
                            updateDataKBID = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAKBID].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATATYPE].Selected)
                            updateDataType = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATATYPE].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.TABLEHEADER].Selected)
                        {
                            tableHeaderString = row.Cells[(int)MBSARawCellColumnIndex.TABLEHEADER].Value.ToString();
                        }
                        if (row.Cells[(int)MBSARawCellColumnIndex.TABLEROWDATA].Selected)
                        {
                            tableRowDataString = row.Cells[(int)MBSARawCellColumnIndex.TABLEROWDATA].Value.ToString();
                        }
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAINFORMATIONURL].Selected)
                            updateDataInformationURL = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATAINFORMATIONURL].Value.ToString();
                        if (row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATADOWNLOADURL].Selected)
                            updateDataDownloadURL = row.Cells[(int)MBSARawCellColumnIndex.UPDATEDATADOWNLOADURL].Value.ToString();


                        MBSADataEntry entry = new MBSADataEntry(pluginName,
                                                                    ipList,
                                                                    description,
                                                                    severityString,
                                                                    riskFactor,
                                                                    cve.Split(", ".ToCharArray()).ToList(),
                                                                    bid.Split(", ".ToCharArray()).ToList(),
                                                                    osvdb.Split(", ".ToCharArray()).ToList(),
                                                                    fileName,
                                                                    checkID,
                                                                    checkGrade,
                                                                    checkType,
                                                                    checkCat,
                                                                    checkRank,
                                                                    checkName,
                                                                    checkURL1,
                                                                    checkURL2,
                                                                    checkGroupID,
                                                                    checkGroupName,
                                                                    detailText,
                                                                    updateDataIsInstalled,
                                                                    updateDataRestartRequired,
                                                                    updateDataID,
                                                                    updateDataGUID,
                                                                    updateDataBulletinID,
                                                                    updateDataKBID,
                                                                    updateDataType,
                                                                    tableHeaderString,
                                                                    tableRowDataString,
                                                                    updateDataInformationURL,
                                                                    updateDataDownloadURL,
                                                                    referenceLink);

                        outputRecord.mbsaAddEntry(entry);
                    }
                }
            }

            outputRecord.setIsOutputRecord(true);
            outputRecord.setOutputEntryType(outputEntryType);
            new XlsxOutputFormater().output(saveFileDialogExcelSelected.FileName, ref outputRecord);

        }
        #endregion

        private void removeDuplicate()
        {
            Dictionary<String, List<DataEntry>> duplicateRecord = new Dictionary<string, List<DataEntry>>();

            List<DataEntry> mbsaEntries = Program.state.panelRecordEdit_record.getRawMBSAEnties();
            List<DataEntry> nessusEntries = Program.state.panelRecordEdit_record.getRawNessusEnties();
            foreach (NessusDataEntry nessusEntry in nessusEntries)
            {
                String nessusMicrosoftID = nessusEntry.getMicrosoftID();
                String nessusIp= nessusEntry.getIp();  //only 1 ip because from raw record
                if (nessusMicrosoftID != "")
                    foreach (MBSADataEntry mbsaEntry in mbsaEntries)
                    {
                        String mbsaIp = mbsaEntry.getIp();
                        if ( mbsaIp == nessusIp){
                            String mbsaMicrosoftID = mbsaEntry.getUpdateDataID();
                            if (mbsaMicrosoftID == nessusMicrosoftID)
                            {
                                String key = mbsaMicrosoftID + "@" + mbsaIp;
                                if (duplicateRecord.ContainsKey(key))
                                {
                                    // expect not to be called
                                    duplicateRecord[key].Add(nessusEntry);
                                    duplicateRecord[key].Add(mbsaEntry);
                                }
                                else
                                {
                                    List<DataEntry> tempList = new List<DataEntry>();
                                    tempList.Add(nessusEntry);
                                    tempList.Add(mbsaEntry);
                                    duplicateRecord.Add(key, tempList);
                                    //break;
                                }
                            }

                        }
                    }
            }
            if (duplicateRecord.Count>0)
                new FormRemoveDuplicate(duplicateRecord).ShowDialog();
                
        }

        private void panelRawView_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panelRawView_tabControl.SelectedIndex==3){
                panelRawView_comboBoxFilter.Items.Clear();
                panelRawView_comboBoxFilter.Items.Add("Plugin Name");
                panelRawView_comboBoxFilter.Items.Add("Host Affected");
                panelRawView_comboBoxFilter.Items.Add("Description");
                panelRawView_comboBoxFilter.Items.Add("Impact");
                panelRawView_comboBoxFilter.Items.Add("Risk Level");
                panelRawView_comboBoxFilter.Items.Add("Recommendation");
                panelRawView_comboBoxFilter.Items.Add("fileName");
                panelRawView_comboBoxFilter.Items.Add("subDomain");
                panelRawView_comboBoxFilter.Items.Add("affectedItemSubDirectory");
                panelRawView_comboBoxFilter.Items.Add("department");
                panelRawView_comboBoxFilter.Items.Add("affectedItem");
                panelRawView_comboBoxFilter.Items.Add("affectedItemLink");
                panelRawView_comboBoxFilter.Items.Add("affectedItemDetail");
                panelRawView_comboBoxFilter.Items.Add("affectedItemRequest");
                panelRawView_comboBoxFilter.Items.Add("affectedItemResponse");
                panelRawView_comboBoxFilter.Items.Add("moduleName");
                panelRawView_comboBoxFilter.Items.Add("isFalsePositive");
                panelRawView_comboBoxFilter.Items.Add("AOP_SourceFile");
                panelRawView_comboBoxFilter.Items.Add("AOP_SourceLine");
                panelRawView_comboBoxFilter.Items.Add("AOP_Additional");
                panelRawView_comboBoxFilter.Items.Add("detailedInformation");
                panelRawView_comboBoxFilter.Items.Add("acunetixType");
                panelRawView_comboBoxFilter.Items.Add("Reference");
                panelRawView_comboBoxFilter.SelectedIndex = 0;
            }
            else if (panelRawView_tabControl.SelectedIndex==0) //nmap
            {
                panelRawView_comboBoxFilter.Items.Clear();
                panelRawView_comboBoxFilter.Items.Add("Plugin Name");
                panelRawView_comboBoxFilter.Items.Add("Host Affected");
                panelRawView_comboBoxFilter.Items.Add("Description");
                panelRawView_comboBoxFilter.Items.Add("Impact");
                panelRawView_comboBoxFilter.Items.Add("Risk Level");
                panelRawView_comboBoxFilter.Items.Add("Recommendation");
                panelRawView_comboBoxFilter.Items.Add("CVE");
                panelRawView_comboBoxFilter.Items.Add("BID");
                panelRawView_comboBoxFilter.Items.Add("OSVDB");
                panelRawView_comboBoxFilter.Items.Add("Reference Link");
                panelRawView_comboBoxFilter.Items.Add("File Name");
                panelRawView_comboBoxFilter.Items.Add("Entry Type");
                panelRawView_comboBoxFilter.Items.Add("OS");
                panelRawView_comboBoxFilter.Items.Add("OSDetail");
                panelRawView_comboBoxFilter.Items.Add("openPortList");
                panelRawView_comboBoxFilter.SelectedIndex = 0;
            }
            else if (panelRawView_tabControl.SelectedIndex==1) //nessus
            {
                panelRawView_comboBoxFilter.Items.Clear();
                panelRawView_comboBoxFilter.Items.Add("Plugin Name");
                panelRawView_comboBoxFilter.Items.Add("Host Affected");
                panelRawView_comboBoxFilter.Items.Add("Description");
                panelRawView_comboBoxFilter.Items.Add("Impact");
                panelRawView_comboBoxFilter.Items.Add("Risk Level");
                panelRawView_comboBoxFilter.Items.Add("Recommendation");
                panelRawView_comboBoxFilter.Items.Add("CVE");
                panelRawView_comboBoxFilter.Items.Add("BID");
                panelRawView_comboBoxFilter.Items.Add("OSVDB");
                panelRawView_comboBoxFilter.Items.Add("Reference Link");
                panelRawView_comboBoxFilter.Items.Add("File Name");
                panelRawView_comboBoxFilter.Items.Add("Entry Type");
                panelRawView_comboBoxFilter.Items.Add("port");
                panelRawView_comboBoxFilter.Items.Add("protocol");
                panelRawView_comboBoxFilter.Items.Add("svc_name");
                panelRawView_comboBoxFilter.Items.Add("pluginFamily");
                panelRawView_comboBoxFilter.Items.Add("plugin_publication_date");
                panelRawView_comboBoxFilter.Items.Add("plugin_modification_date");
                panelRawView_comboBoxFilter.Items.Add("cvss_vector");
                panelRawView_comboBoxFilter.Items.Add("cvss_base_score");
                panelRawView_comboBoxFilter.Items.Add("plugin_output");
                panelRawView_comboBoxFilter.Items.Add("plugin_version");
                panelRawView_comboBoxFilter.Items.Add("see_alsoList");
                panelRawView_comboBoxFilter.Items.Add("pluginID");
                panelRawView_comboBoxFilter.Items.Add("microSoftID");
                panelRawView_comboBoxFilter.Items.Add("severity");
                panelRawView_comboBoxFilter.SelectedIndex = 0;
            }
            else if (panelRawView_tabControl.SelectedIndex==2) //mbsa
            {
                panelRawView_comboBoxFilter.Items.Clear();
                panelRawView_comboBoxFilter.Items.Add("Plugin Name");
                panelRawView_comboBoxFilter.Items.Add("Host Affected");
                panelRawView_comboBoxFilter.Items.Add("Description");
                panelRawView_comboBoxFilter.Items.Add("Impact");
                panelRawView_comboBoxFilter.Items.Add("Risk Level");
                panelRawView_comboBoxFilter.Items.Add("Recommendation");
                panelRawView_comboBoxFilter.Items.Add("CVE");
                panelRawView_comboBoxFilter.Items.Add("BID");
                panelRawView_comboBoxFilter.Items.Add("OSVDB");
                panelRawView_comboBoxFilter.Items.Add("Reference Link");
                panelRawView_comboBoxFilter.Items.Add("File Name");
                panelRawView_comboBoxFilter.Items.Add("Entry Type");
                panelRawView_comboBoxFilter.Items.Add("checkID");
                panelRawView_comboBoxFilter.Items.Add("checkGrade");
                panelRawView_comboBoxFilter.Items.Add("checkCat");
                panelRawView_comboBoxFilter.Items.Add("checkRank");
                panelRawView_comboBoxFilter.Items.Add("checkName");
                panelRawView_comboBoxFilter.Items.Add("checkURL1");
                panelRawView_comboBoxFilter.Items.Add("checkURL2");
                panelRawView_comboBoxFilter.Items.Add("checkGroupID");
                panelRawView_comboBoxFilter.Items.Add("checkGroupName");
                panelRawView_comboBoxFilter.Items.Add("detailText");
                panelRawView_comboBoxFilter.Items.Add("updateDataIsInstalled");
                panelRawView_comboBoxFilter.Items.Add("updateDataRestartRequired");
                panelRawView_comboBoxFilter.Items.Add("updateDataID");
                panelRawView_comboBoxFilter.Items.Add("updateDataGUID");
                panelRawView_comboBoxFilter.Items.Add("updateDataBulletinID");
                panelRawView_comboBoxFilter.Items.Add("updateDataKBID");
                panelRawView_comboBoxFilter.Items.Add("updateDataType");
                panelRawView_comboBoxFilter.Items.Add("UpdateDataInformationURL");
                panelRawView_comboBoxFilter.Items.Add("UpdateDataDownloadURL");
                panelRawView_comboBoxFilter.Items.Add("severity");
                panelRawView_comboBoxFilter.Items.Add("tableHeader");
                panelRawView_comboBoxFilter.Items.Add("tableRowData");

                panelRawView_comboBoxFilter.SelectedIndex = 0;
            }
        }

        private void panelFileInput_checkedListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            panelFileInput_updateTreeView();
        }

        private void panelRecordEdit_buttonUndo_Click(object sender, EventArgs e)
        {
            panelRecordEdit_buttonUndo.Enabled = false;

            Dictionary<int, DataEntry> undoList = Program.state.panelRecordEdit_undoDataEntryList;
            if (undoList == null || undoList.Keys.Count == 0)
                return;

            int counting_for_FindingDetail = 0;
            
            foreach (KeyValuePair<int,DataEntry> pair in undoList)
            {
                int id = pair.Key;
                DataEntry entry = pair.Value;


                DataEntry oldEntry = Program.state.panelRecordEdit_recordDatabaser.getEntryFromDatabaseId(id);
                if (oldEntry != null)
                {
                    //@@@@@Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateRecordToDatabase(entry, id);
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdateUpdateNessusFindingToDatabase(entry, id);

                }
                else
                {
                    //@@@@@Program.state.panelRecordEdit_recordDatabaser.guiInsertRecordToDatabase(entry, id);
                    Program.state.panelRecordEdit_recordDatabaser.guiInsertNessusFindingToDatabase(entry, id);
                    
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdateUndoFindingDetailToDatabase(id, counting_for_FindingDetail);
                    Program.state.panelRecordEdit_recordDatabaser.guiUpdateUndoFindingReferencesToDatabase(id, counting_for_FindingDetail);


                    counting_for_FindingDetail++;
                }
                    

                string name = entry.getPluginName();
                string ip = entry.getIp();
                string description = entry.getDescription();
                string impact = entry.getImpact();
                //string riskFactorString = "";
                RiskFactor riskFactor = entry.getRiskFactor();
                //if (riskFactor == RiskFactor.OPEN) 
                //    riskFactorString = "OpenPort";
                //else 
                //    riskFactorString = RiskFactorFunction.getEnumString(riskFactor);
                string recommendation = entry.getRecommendation();
                string cve = entry.getCve();
                string bid = entry.getBid();
                string osvdb = entry.getOsvdb();
                string referenceLink = entry.getReferenceLink();
                string type = entry.getEntryTypeString();


                panelRecordEdit_fillCellValue(id-1,
                                              false,
                                              Program.state.panelRecordEdit_undoMegered[id],
                                              Program.state.panelRecordEdit_undoEdited[id],
                                              name,
                                              ip,
                                              description,
                                              impact,
                                              riskFactor,
                                              recommendation,
                                              cve,
                                              bid,
                                              osvdb,
                                              referenceLink,
                                              type,
                                              entry.getpluginversion(),
                                              entry.getpluginID());           //@@@@@
                panelRecordEdit_dataGridView.Rows[id-1].Visible = true;

            }



            Program.state.panelRecordEdit_undoDataEntryList = null;
            Program.state.panelRecordEdit_undoEdited = null;
            Program.state.panelRecordEdit_undoMegered = null;

            panelRecordEdit_dataGridView.SuspendLayout();
            panelRecordEdit_dataGridView_reloadBackgroundColor();
            panelRecordEdit_dataGridView.ResumeLayout();

            panelRecordEdit_enableNextButton();
        }

        private void panelRecordEdit_buttonUp_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows)
            {
                if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value == true)
                {
                    DataGridViewRow row2 =null;
                    for (int i = row.Index-1;i >=0;i--)
                        if (panelRecordEdit_dataGridView.Rows[i].Visible == true)
                        {
                            row2 = panelRecordEdit_dataGridView.Rows[i];
                            break;
                        }

                    // no top row
                    if (row2 == null)
                        return;

                    panelRecordEdit_swapRow(row, row2);
                    panelRecordEdit_dataGridView_reloadBackgroundColor();
                    break;
                }
            }
        }

        private void panelRecordEdit_buttonDown_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows)
            {
                if ((bool)row.Cells[(int)CellColumnIndex.SELECTED].Value == true)
                {
                    DataGridViewRow row2 = null;
                    for (int i = row.Index + 1; i < panelRecordEdit_dataGridView.Rows.Count; i++)
                        if (panelRecordEdit_dataGridView.Rows[i].Visible == true)
                        {
                            row2 = panelRecordEdit_dataGridView.Rows[i];
                            break;
                        }

                    // no bot row
                    if (row2 == null)
                        return;

                    panelRecordEdit_swapRow(row, row2);
                    panelRecordEdit_dataGridView_reloadBackgroundColor();
                    break;
                }
            }
        }

        private void panelRecordEdit_swapRow(DataGridViewRow row, DataGridViewRow row2)
        {
            int dbid1 = (int)row.Cells[(int)CellColumnIndex.DBID].Value;
            int dbid2 = (int)row2.Cells[(int)CellColumnIndex.DBID].Value;
            Program.state.panelRecordEdit_recordDatabaser.swapRecord(dbid1, dbid2);

            //Swap

            int temp = (int)row2.Cells[(int)CellColumnIndex.OLDID].Value;
            row.Cells[(int)CellColumnIndex.OLDID].Value = row2.Cells[(int)CellColumnIndex.OLDID].Value;
            row2.Cells[(int)CellColumnIndex.OLDID].Value = temp;

            bool merge = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;
            bool edit = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
            string name = row.Cells[(int)CellColumnIndex.PLUGINNAME].Value.ToString();
            string ip = row.Cells[(int)CellColumnIndex.IPLIST].Value.ToString();
            string description = row.Cells[(int)CellColumnIndex.DESCRIPTION].Value.ToString();
            string impact = row.Cells[(int)CellColumnIndex.IMPACT].Value.ToString();
            RiskFactor riskFactor = RiskFactorFunction.getEnum(row.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString());
            string recommendation = row.Cells[(int)CellColumnIndex.RECOMMENDATION].Value.ToString();
            string cve = row.Cells[(int)CellColumnIndex.CVE].Value.ToString();
            string bid = row.Cells[(int)CellColumnIndex.BID].Value.ToString();
            string osvdb = row.Cells[(int)CellColumnIndex.OSVDB].Value.ToString();
            string referenceLink = row.Cells[(int)CellColumnIndex.REFERENCELINK].Value.ToString();
            string type = row.Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString();

            string pluginversion = row.Cells[(int)CellColumnIndex.PLUGINVERSION].Value.ToString();
            string pluginID = row.Cells[(int)CellColumnIndex.PLUGINID].Value.ToString();

            panelRecordEdit_fillCellValue(row.Index,
                                          false,
                                          (bool)row2.Cells[(int)CellColumnIndex.MERGED].Value,
                                          (bool)row2.Cells[(int)CellColumnIndex.EDITED].Value,
                                          row2.Cells[(int)CellColumnIndex.PLUGINNAME].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.IPLIST].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.DESCRIPTION].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.IMPACT].Value.ToString(),
                                          RiskFactorFunction.getEnum(row2.Cells[(int)CellColumnIndex.RISKFACTOR].Value.ToString()),
                                          row2.Cells[(int)CellColumnIndex.RECOMMENDATION].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.CVE].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.BID].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.OSVDB].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.REFERENCELINK].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.ENTRYTYPE].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.PLUGINVERSION].Value.ToString(),
                                          row2.Cells[(int)CellColumnIndex.PLUGINID].Value.ToString());            //@@@@@


            panelRecordEdit_fillCellValue(row2.Index,
                                          true,
                                          merge,
                                          edit,
                                          name,
                                          ip,
                                          description,
                                          impact,
                                          riskFactor,
                                          recommendation,
                                          cve,
                                          bid,
                                          osvdb,
                                          referenceLink,
                                          type,
                                          pluginversion,
                                          pluginID);          //@@@@@
        }

        private void panelRecordEdit_buttonCreateExcel_Click(object sender, EventArgs e)
        {

            saveFileDialogCreateExcelInPanelRecordEdit.Filter = "Excel Worksheets|*.xlsx"; ;
            saveFileDialogCreateExcelInPanelRecordEdit.ShowDialog();
            string path = saveFileDialogCreateExcelInPanelRecordEdit.FileName;
            saveFileDialogCreateExcelInPanelRecordEdit.FileName = "";

            if (path != "")
            {
                new XlsxOutputFormater().PuttingRawDataIntoExcelInPanelRecordEdit(path);
                System.Windows.Forms.MessageBox.Show("Done");
            }

        }

        private void panelRecordEdit_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelOutputSelect_checkboxExportPluginOutput_CheckedChanged(object sender, EventArgs e)
        {
            Program.state.panelOutputSelect_isOutputPluginOutput = panelOutputSelect_checkboxExportPluginOutput.CheckState == CheckState.Checked;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panelOutputSelect_buttonTextFileBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogTextFileBrowse.Filter = "Text File (.txt)|*.txt";
            openFileDialogTextFileBrowse.Multiselect = false;
            openFileDialogTextFileBrowse.ShowDialog();
            panelOutputSelect_textBoxTextFileBrowse.Text = openFileDialogTextFileBrowse.FileName;
            Program.state.TextFileLocation = openFileDialogTextFileBrowse.FileName;
        }

        private void Read_Host_From_text_File(string path)
        {
            string String_Read_From_Text_File = null;
            StreamReader Read_file = new StreamReader(path);
            while ((String_Read_From_Text_File = Read_file.ReadLine()) != null)
            {
                Program.state.ForbiddenHost.Add(String_Read_From_Text_File);
            }
            Read_file.Close();



        }

        private void panelFileInput_checkedListBox_Click_1(object sender, EventArgs e)
        {

            
 
                   buttonNext.Enabled = true;
                   
        }


        /*
         * <summary>
         * This is the panelRecordEdit_buttonExtractMSPatches_Click method.
         * This is used to handle the click event on button panelRecordEdit_buttonExtractMSPatches.
         * 
         * It will
         * 1. Output all the Missing Patches in Excel Format
         * 2. Select all the output items in the panel for deletion
         * </summary>
         * 
         * 
         * <TODO>
         * Handle the search case when some of the items have been merged
         * </TODO>
         * <param name="sender"></param>
         * <param name="e"></param>
         * 
         * */
        private void panelRecordEdit_buttonExtractMSPatches_Click(object sender, EventArgs e) {

            // For extracting the Patches
            string bulletin = null;
            string patches = null;
            string hostAffected = null;
            InteropExcel excel = new InteropExcel();

            // Regular expression for missing patches
            string[] regType = { @"MS\s?\d+\-\d+(\s+)?:?\s+", @"MS\s?KB\d+(\s+)?:?\s+", @"MS\s?\d+(\s+)?:?\s+", @"MS\s+Security\s+Advisory\s+\d+(\s+)?:?\s+" };
            string[] regBulletin = { @"MS\s?\d+\-\d+", @"MS\s?KB\d+", @"MS\s?\d+", @"MS\s+Security\s+Advisory\s+\d+" };
            int type = -1;

            MatchCollection bulletinMatch = null;

            foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
                // Reset the selected value
                row.Cells[(int)CellColumnIndex.SELECTED].Value = false;

                string findingPluginName = (string)row.Cells[(int)CellColumnIndex.PLUGINNAME].Value;
                if (findingPluginName == null) continue;

                for (int i = 0; i < regType.Length; i++) {
                    bulletinMatch = Regex.Matches(findingPluginName, regType[i]);
                    if (bulletinMatch.Count > 0) {
                        type = i;
                        MatchCollection workingMatch = Regex.Matches(bulletinMatch[0].Value, regBulletin[type]);
                        bulletin = workingMatch[0].Value.Trim();
                        patches = findingPluginName.Substring(bulletinMatch[0].Value.Length, findingPluginName.Length - bulletinMatch[0].Value.Length);
                        hostAffected = (string)row.Cells[(int)CellColumnIndex.IPLIST].Value;
                        hostAffected = Regex.Replace(hostAffected, @"\s\(.*?\)", @"");
                        if(row.Visible == true)
                            row.Cells[(int)CellColumnIndex.SELECTED].Value = true;

                        excel.addPatchRecord(bulletin, patches, hostAffected);
                        break;
                    }
                }
            }
            excel.SaveWorkbook();
            
            //Enable delete and merge record buttton
            panelRecordEdit_buttonDeleteRecord.Enabled = true;
            panelRecordEdit_buttonMergeRecord.Enabled = true;
        }

        private void panelRecordEdit_buttonMultiVulnSuggestion_Click(object sender, EventArgs e) {
            int counter = 0;
            List<int> indexArray = new List<int>();
            List<DataEntry> dataArray = new List<DataEntry>();

            Dictionary<int, DataEntry> undoList = new Dictionary<int, DataEntry>();
            Dictionary<int, bool> undoEdited = new Dictionary<int, bool>();
            Dictionary<int, bool> undoMegered = new Dictionary<int, bool>();

            string MultiVulnListpath = Directory.GetCurrentDirectory() + "\\MultiVulList.txt";

            string[] applicationList = System.IO.File.ReadAllLines(MultiVulnListpath);
            for (int i = 0; i < applicationList.Length; i++) {
                applicationList[i] = "^" + applicationList[i];
            }

            MatchCollection applicationMatch = null;

            for (int i = 0; i < applicationList.Length; i++) {
                indexArray.Clear();
                dataArray.Clear();
                counter = 0;
                foreach (DataGridViewRow row in panelRecordEdit_dataGridView.Rows) {
                    row.Cells[(int)CellColumnIndex.SELECTED].Value = false;

                    string findingPluginName = (string)row.Cells[(int)CellColumnIndex.PLUGINNAME].Value;
                    if (findingPluginName == null) continue;
                    applicationMatch = Regex.Matches(findingPluginName, applicationList[i]);
                        if (applicationMatch.Count > 0) {
                            if (row.Visible == true) {
                                row.Cells[(int)CellColumnIndex.SELECTED].Value = true;
                                
                                counter++;
                                indexArray.Add(row.Index);
                                dataArray.Add(panelRecordEdit_rowToDataEntry(row));
    
                                int dbid = int.Parse(row.Cells[(int)CellColumnIndex.DBID].Value.ToString());
                                undoEdited[dbid] = (bool)row.Cells[(int)CellColumnIndex.EDITED].Value;
                                undoMegered[dbid] = (bool)row.Cells[(int)CellColumnIndex.MERGED].Value;
                                undoList[dbid] = panelRecordEdit_rowToDataEntry(row);
                            }
                        }
                }
                this.Enabled = false;
                if (counter > 0)
                    new FormEditFinding(indexArray, dataArray).ShowDialog();

                this.Enabled = true;
                this.TopMost = true;
                this.TopMost = false;

                // if button "OK" is clicked, a finding should be append to the
                // dataGridView


                if (Program.state.formEditFindingState == State.FormEditFindingState.OK) {
                    //panelRecordEdit_addRowForMerge(Program.state.formEditFindingEntry);
                    panelRecordEdit_deleteRowForMerge(Program.state.formEditFindingEntry, indexArray);
                    //foreach (int index in indexArray) {
                    //    panelRecordEdit_dataGridView.Rows[index].Cells[(int)CellColumnIndex.SELECTED].Value = false;
                    //}
                    panelRecordEdit_checkboxCheckedChangedAction();
                    panelRecordEdit_checkboxTypeCheckedChangedAction();
                    panelRecordEdit_enableNextButton();



                    Program.state.panelRecordEdit_undoEdited = undoEdited;
                    Program.state.panelRecordEdit_undoMegered = undoMegered;
                    Program.state.panelRecordEdit_undoDataEntryList = undoList;
                    panelRecordEdit_buttonUndo.Enabled = true;
                    panelRecordEdit_dataGridView_reloadBackgroundColor();
                }

                Program.state.formEditFindingState = State.FormEditFindingState.NULL;

            }
        }

        private void panelOutputSelect_buttonXlsxNessus_Click(object sender, EventArgs e) {
            Program.state.panelOutputSelect_State = State.PanelOutputSelectState.XLSX;
            panelOutputSelect_initialize();
            panelOutputSelect_groupBoxOutputFilePath.Show();
            panelOutputSelect_groupBoxTemplatePath.Hide();
        }

    }

}
