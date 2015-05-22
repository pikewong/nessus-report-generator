using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;
using ReportGenerator.Record;

namespace ReportGenerator.Database {
	/*
	 * This is the CaseDatabaser Class.
	 * It is used to handle the save/load to/from the config file.
	 */
	public class CaseDatabaser {

		// Variables
		private String directory = "";
		private String path;
		private SQLiteConnection sqlite_conn;
		private SQLiteCommand sqlite_cmd;
		private SQLiteDataReader sqlite_datareader;

		/*
		 * This is the constructor of CaseDatabaser.
		 * It is used to assign the value of directory to the CaseDatabaser object.
		 */
		public CaseDatabaser(String directory) {
			this.directory = directory;
			this.path = directory + "\\" + Program.state.ProjectName+"-"+"RGConfig_" + DateTime.Now.ToString("HHmmss_ddMMyy") + ".db";
		}

		/*
		 * This is the constructor of CaseDatabaser.
		 * It is used to assign the values of directory and also the path to the CaseDatabaser object.
		 */
		public CaseDatabaser(String directory, String path) {
			this.directory = directory;
			this.path = path;
		}

		/*
		 * This is the getter method.
		 * It is used to get the path of this CaseDatabaser object.
		 */
		public String getPath() {
			return this.path;
		}

		/*
		 * This is the loadRGConfigFile method.
		 * It is used to load the Report Generator Config File.
		 * return true if successfully load the config file.
		 */
		public bool loadRGConfigFile() {
			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			#region // FormMain Load Data
			#region // FormMain PanelFileInput Load Data
			Program.state.formMainInputPaths = new List<string>();
			Program.state.formMainInputPathSelected = new List<bool>();

			// Command
			sqlite_cmd.CommandText = "SELECT * " +
									 "FROM FormMainPanelFileInput;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();

			while (sqlite_datareader.Read()) {
				Program.state.formMainInputPaths.Add(sqlite_datareader["path"].ToString());
				Program.state.formMainInputPathSelected.Add(bool.Parse(sqlite_datareader["selected"].ToString()));
			}

			sqlite_datareader.Close();
			#endregion

            #region // FormMain FormChoosePermanentDatabasePath Load Data

			// Command
			sqlite_cmd.CommandText = "SELECT path " +
                                     "FROM FormChoosePermanentDatabasePath;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();

			while (sqlite_datareader.Read()) {
                Program.state.amendmentDatabaserDefaultPath = (sqlite_datareader["path"].ToString());
			}

			sqlite_datareader.Close();
			#endregion
            
			#region // FormMain PanelRecordEdit Load Data
			// Command
			sqlite_cmd.CommandText = "SELECT * FROM FormMainPanelRecordEdit;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.panelRecordEdit_DatabasePath = sqlite_datareader["path"].ToString();
			}
			sqlite_datareader.Close();

			Program.state.panelRecordEdit_recordDatabaser = new Databaser(Program.state.panelRecordEdit_DatabasePath);

			Program.state.panelRecordEdit_RecordSelected = new Dictionary<int, bool>();
			Program.state.panelRecordEdit_RecordMerged = new Dictionary<int, bool>();
			Program.state.panelRecordEdit_RecordEdited = new Dictionary<int, bool>();
			Program.state.dataGridView_Id = new Dictionary<int, int>();
			Program.state.dataGridView_OldId = new Dictionary<int, int>();
			Program.state.dataGridView_DatabaseId = new Dictionary<int, int>();

			// Command
			sqlite_cmd.CommandText = "SELECT * FROM FormMainPanelRecordEditDataGridView;";

			int counter = 0;
			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.panelRecordEdit_RecordSelected[counter] = bool.Parse(sqlite_datareader["selected"].ToString());
				Program.state.panelRecordEdit_RecordMerged[counter] = bool.Parse(sqlite_datareader["merged"].ToString());
				Program.state.panelRecordEdit_RecordEdited[counter] = bool.Parse(sqlite_datareader["edited"].ToString());
				Program.state.dataGridView_Id[counter] = int.Parse(sqlite_datareader["id"].ToString());
				Program.state.dataGridView_OldId[counter] = int.Parse(sqlite_datareader["oldId"].ToString());
				Program.state.dataGridView_DatabaseId[counter] = int.Parse(sqlite_datareader["databaseId"].ToString());
				counter++;
			}
			sqlite_datareader.Close();

			// Command
			sqlite_cmd.CommandText = "SELECT * FROM FormMainPanelRecordEditShowSelected;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.panelRecordEdit_showHigh = bool.Parse(sqlite_datareader["high"].ToString());
				Program.state.panelRecordEdit_showMedium = bool.Parse(sqlite_datareader["medium"].ToString());
				Program.state.panelRecordEdit_showLow = bool.Parse(sqlite_datareader["low"].ToString());
				Program.state.panelRecordEdit_showNone = bool.Parse(sqlite_datareader["none"].ToString());
				Program.state.panelRecordEdit_showOpenPort = bool.Parse(sqlite_datareader["openPort"].ToString());
				Program.state.panelRecordEdit_showNessus = bool.Parse(sqlite_datareader["nessus"].ToString());
				Program.state.panelRecordEdit_showMbsa = bool.Parse(sqlite_datareader["mbsa"].ToString());
				Program.state.panelRecordEdit_showNmap = bool.Parse(sqlite_datareader["nmap"].ToString());
			}
			sqlite_datareader.Close();
			#endregion

			#region // FormMain PanelOutputSelect Load Data
			// Command
			sqlite_cmd.CommandText = "SELECT * " +
									 "FROM FormMainPanelOutputSelect;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				switch (sqlite_datareader["state"].ToString()) {
					case "HTML":
						Program.state.panelOutputSelect_State = State.PanelOutputSelectState.HTML;
						break;
					case "DOCX":
						Program.state.panelOutputSelect_State = State.PanelOutputSelectState.DOCX;
						break;
					case "DOCXTEM":
						Program.state.panelOutputSelect_State = State.PanelOutputSelectState.DOCXTEM;
						break;
					case "XLSX":
						Program.state.panelOutputSelect_State = State.PanelOutputSelectState.XLSX;
						break;
				}

				Program.state.panelOutputSelect_OutputPath = sqlite_datareader["outputPath"].ToString();
				Program.state.panelOutputSelect_TemplatePath = sqlite_datareader["templatePath"].ToString();
				Program.state.panelOutputSelect_isOutputHotfix = bool.Parse(sqlite_datareader["hotfixOutput"].ToString());
				Program.state.panelOutputSelect_isOutputOpenPort = bool.Parse(sqlite_datareader["openPortOutput"].ToString());
                Program.state.panelOutputSelect_isOutputIpHost = bool.Parse(sqlite_datareader["ipHostOutput"].ToString());
			}
			sqlite_datareader.Close();
			#endregion

			#region // FormMain PanelTemplateStringEdit Load Data
			Program.state.panelTemplateStringEdit_dict = new Dictionary<string, string>();

			// Command
			sqlite_cmd.CommandText = "SELECT * " +
									 "FROM FormMainPanelTemplateStringEdit;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.panelTemplateStringEdit_dict[sqlite_datareader["key"].ToString()] = sqlite_datareader["value"].ToString();
			}
			sqlite_datareader.Close();
			#endregion

			#region FormMain PanelLast Load Data
			#endregion
			#endregion

			#region // Load Record
			Program.state.panelRecordEdit_record = Program.state.panelRecordEdit_recordDatabaser.getRecord();
            Program.state.fileNames = Program.state.panelRecordEdit_recordDatabaser.getFileNamesFRomRawDatabase();

			List<DataEntry> record = new List<DataEntry>();

			foreach (KeyValuePair<int, DataEntry> entry in Program.state.panelRecordEdit_record.getHighRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.panelRecordEdit_record.getMediumRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.panelRecordEdit_record.getLowRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.panelRecordEdit_record.getNoneRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.panelRecordEdit_record.getOpenPort()) {
				record.Add(entry.Value);
			}

			Program.state.panelRecordEdit_ConfirmedRecord = new Record.Record();
            //for (int i = 0; i < Program.state.panelRecordEdit_RecordSelected.Count; i++){
            //    if (Program.state.panelRecordEdit_RecordSelected[i]){
            //        Program.state.panelRecordEdit_ConfirmedRecord.guiAddEntry(record[i]);
            //    }
            //}
			#endregion
			
			// Close connection
			sqlite_conn.Close();

			return true;
		}

		/*
		 * This is the output method.
		 * It is used to save the Report Generator Config.
		 */
		public void output() {
			// create the RG Config file
			createRGConfigFile();

			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			#region // FormMain Insert Data

			#region // FormMain PanelFileInput Insert Data



			for (int i = 0; i < Program.state.formMainInputPaths.Count; i++) {
				int selected = (Program.state.formMainInputPathSelected[i]) ? 1 : 0;
				// Command
				sqlite_cmd.CommandText = "INSERT INTO FormMainPanelFileInput (" +
										 "path," +
										 "selected) " +
										 "VALUES (" +
										 "'" + addSlash(Program.state.formMainInputPaths[i]) + "', " +
										 selected.ToString() +
										 ");";

				// Execute non query command
				sqlite_cmd.ExecuteNonQuery();
			}
			#endregion

            #region // FormMain FormChoosePermanentDatabasePath Insert Data
			// Command
            sqlite_cmd.CommandText = "INSERT INTO FormChoosePermanentDatabasePath (" +
									  "path) " +
                                      "VALUES (" +
									  "'" + addSlash(Program.state.amendmentDatabaserDefaultPath) + "' " +
									  ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion
            
			#region // FormMain PanelRecordEdit Insert Data
			// Command
			sqlite_cmd.CommandText = "INSERT INTO FormMainPanelRecordEdit (" +
									 "path) " +
									 "VALUES (" +
									 "'" + addSlash(Program.state.panelRecordEdit_DatabasePath) + "'" + 
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();

			//int a = Program.state.panelRecordEdit_RecordSelected[0] ? 1 : 0;
            int transactioncount = 0;
            SQLiteTransaction transaction = sqlite_conn.BeginTransaction();

			for (int i = 0; i < Program.state.dataGridView_Id.Count; i++) {



				String selected = (Program.state.panelRecordEdit_RecordSelected[i]) ? "1" : "0";
				String merged = (Program.state.panelRecordEdit_RecordMerged[i]) ? "1" : "0";
				String edited = (Program.state.panelRecordEdit_RecordEdited[i]) ? "1" : "0";

				// Command
				sqlite_cmd.CommandText = "INSERT INTO FormMainPanelRecordEditDataGridView (" +
										 "selected, " +
										 "merged, " +
										 "edited, " +
										 "id, " +
										 "oldId, " +
										 "databaseId" +
										 ") " +
										 "VALUES (" +
										 "'" + selected + "', " + 
										 "'" + merged + "', " + 
										 "'" + edited + "', " + 
										 "'" + Program.state.dataGridView_Id[i].ToString() + "', " +
										 "'" + Program.state.dataGridView_OldId[i].ToString() + "', " +
										 "'" + Program.state.dataGridView_DatabaseId[i].ToString() + "'" +
										 ");";

				// Execute non query command
				sqlite_cmd.ExecuteNonQuery();

                if (transactioncount++ == 9000)
                {
                    transaction.Commit();
                    transactioncount = 0;
                    transaction = sqlite_conn.BeginTransaction();
                }

			}
            transaction.Commit();

			// Command
			sqlite_cmd.CommandText = "INSERT INTO FormMainPanelRecordEditShowSelected (" +
									 "high, " +
									 "medium, " +
									 "low, " +
									 "none, " +
									 "openPort, " + 
									 "nessus, " +
									 "mbsa, " +
									 "nmap" +
									 ") " +
									 "VALUES (" +
									 "'" + (Program.state.panelRecordEdit_showHigh? "1" : "0") + "', " +
									 "'" + (Program.state.panelRecordEdit_showMedium? "1" : "0") + "', " +
									 "'" + (Program.state.panelRecordEdit_showLow? "1" : "0") + "', " +
									 "'" + (Program.state.panelRecordEdit_showNone? "1" : "0") + "', " +
									 "'" + (Program.state.panelRecordEdit_showOpenPort ? "1" : "0") + "'," +
									 "'" + (Program.state.panelRecordEdit_showNessus ? "1" : "0") + "'," +
									 "'" + (Program.state.panelRecordEdit_showMbsa ? "1" : "0") + "'," +
									 "'" + (Program.state.panelRecordEdit_showNmap ? "1" : "0") + "'" +
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region // FormMain PanelOutputSelect Insert Data
			// Command
			sqlite_cmd.CommandText = "INSERT INTO FormMainPanelOutputSelect (" +
									 "state, " +
									 "outputPath, " +
									 "templatePath, " +
									 "hotfixOutput, " +
									 "openPortOutput," +
                                     "ipHostOutput" +
									 ") " +
									 "VALUES (" +
									 "'" + addSlash(Program.state.panelOutputSelect_State.ToString()) + "', " +
									 "'" + addSlash(Program.state.panelOutputSelect_OutputPath) + "', " +
									 "'" + addSlash(Program.state.panelOutputSelect_TemplatePath) + "', " +
									 "'" + (Program.state.panelOutputSelect_isOutputHotfix ? "1" : "0") + "', " +
                                     "'" + (Program.state.panelOutputSelect_isOutputOpenPort ? "1" : "0") + "', " +
									 "'" + (Program.state.panelOutputSelect_isOutputIpHost ? "1" : "0") + "'" +

									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region // FormMain PanelTemplateStringEdit Insert Data
			if (Program.state.panelTemplateStringEdit_dict != null && Program.state.panelTemplateStringEdit_dict.Count != 0) {
				foreach (KeyValuePair<String, String> d in Program.state.panelTemplateStringEdit_dict) {
					if (!String.IsNullOrEmpty(d.Key) && !String.IsNullOrEmpty(d.Value)){
						// Command
						sqlite_cmd.CommandText = "INSERT INTO FormMainPanelTemplateStringEdit (" +
												 "key, " +
												 "value) " +
												 "VALUES (" +
												 "'" + addSlash(d.Key) + "', " +
												 "'" + addSlash(d.Value) + "'" +
												 ");";

						// Execute non query command
						sqlite_cmd.ExecuteNonQuery();
					}
				}
			}
			#endregion

			#region FormMain PanelLast Insert Data
			#endregion

			#endregion

			// Close connection
			sqlite_conn.Close();


			Program.state.panelRecordEdit_isSaveConfig = true;
		}

		/*
		 * This is the createRGConfigFile method.
		 * It is used to create the Report Genetator Config database file.
		 */
		private void createRGConfigFile() {
			path = directory + "\\" +Program.state.ProjectName+"-"+ "RGConfig_" + DateTime.Now.ToString("HHmmss_ddMMyy") + ".db";

			Program.state.formCaseCreateAndOpenPath = path;

			String connectionString = "Data source=" + path + ";Version=3;New=True;Compress=True;";

			// Create
			sqlite_conn = new SQLiteConnection(connectionString);

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			#region // FormMain Database

			#region // FormMain PanelFileInput Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FormMainPanelFileInput(" +
									 "path VARCHAR(2000) PRIMARY KEY," +
									 "selected BOOLEAN DEFAULT 0);";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

            #region // FormChoosePermanentDatabasePath Database
            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FormChoosePermanentDatabasePath(" +
                                     "path VARCHAR(2000))";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();
            #endregion

			#region // FormMain PanelRecordEdit Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FormMainPanelRecordEdit(" +
									 "path VARCHAR(200));";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();

			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FormMainPanelRecordEditDataGridView(" +
									 "selected BOOLEAN DEFAULT 0," +
									 "merged BOOLEAN DEFAULT 0," +
									 "edited BOOLEAN DEFAULT 0," +
									 "id INTEGER DEFAULT 0," +
									 "oldId INTEGER DEFAULT 0," + 
									 "databaseId INTEGER DEFAULT 0" +
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();

			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FormMainPanelRecordEditShowSelected(" +
									 "high BOOLEAN DEFAULT 0," +
									 "medium BOOLEAN DEFAULT 0," +
									 "low BOOLEAN DEFAULT 0," +
									 "none BOOLEAN DEFAULT 0," +
									 "openPort BOOLEAN DEFAULT 0," + 
									 "nessus BOOLEAN DEFAULT 0," +
									 "mbsa BOOLEAN DEFAULT 0," +
									 "nmap BOOLEAN DEFAULT 0" +
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region // FormMain PanelOutputSelect Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FormMainPanelOutputSelect(" +
									 "state VARCHAR(10)," +
									 "outputPath VARCHAR(200)," +
									 "templatePath VARCHAR(200)," + 
									 "hotfixOutput BOOLEAN DEFAULT 0," +
									 "openPortOutput BOOLEAN DEFAULT 0," +
                                     "ipHostOutput BOOLEAN DEFAULT 0" +
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region // FormMain PanelTemplateStringEdit Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FormMainPanelTemplateStringEdit(" +
									 "key VARCHAR(200) PRIMARY KEY," +
									 "value VARCHAR(200));";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region // FormMain PanelLast Database
			#endregion

			#endregion

			// Close connection
			sqlite_conn.Close();
		}
		
		/*
		 * This is the addSlash method.
		 * It is used to add "'" for the string to prevent errors storing to the database.
		 */
        private String addSlash(String s)
        {
            if (String.IsNullOrEmpty(s))
                return "";

            s = s.Replace("'", "''");

            return s;
        }

	}
}
