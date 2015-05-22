using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;
using ReportGenerator.Record;

namespace ReportGenerator.Database {
	public class CaseDatabaser {
		private String directory = "";
		private String path;
		private SQLiteConnection sqlite_conn;
		private SQLiteCommand sqlite_cmd;
		private SQLiteDataReader sqlite_datareader;

		public CaseDatabaser(String directory) {
			this.directory = directory;
			this.path = directory + "\\" + "RGConfig_" + DateTime.Now.ToString("HHmmss_ddMMyy") + ".db";
		}

		public CaseDatabaser(String directory, String path) {
			this.directory = directory;
			this.path = path;
		}

		public bool loadRGConfigFile() {
			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			#region Form3 Load Data
			#region Form3Panel1 Load Data
			Program.state.form3Paths = new List<string>();
			Program.state.form3PathSelected = new List<bool>();

			// Command
			sqlite_cmd.CommandText = "SELECT * " +
									 "FROM Form3Panel1;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();

			while (sqlite_datareader.Read()) {
				Program.state.form3Paths.Add(sqlite_datareader["path"].ToString());
				Program.state.form3PathSelected.Add(bool.Parse(sqlite_datareader["selected"].ToString()));
			}

			sqlite_datareader.Close();
			#endregion

			#region Form3Panel2 Load Data
			// Command
			sqlite_cmd.CommandText = "SELECT * FROM Form3Panel2DatabasePath;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.form3DatabasePath = sqlite_datareader["path"].ToString();
			}
			sqlite_datareader.Close();

			Program.state.form3Databaser = new Databaser(Program.state.form3DatabasePath);

			Program.state.form3RecordSelected = new Dictionary<int, bool>();
			Program.state.form3RecordMerged = new Dictionary<int, bool>();
			Program.state.form3RecordEdited = new Dictionary<int, bool>();
			Program.state.form3Id = new Dictionary<int, int>();
			Program.state.form3OldId = new Dictionary<int, int>();

			// Command
			sqlite_cmd.CommandText = "SELECT * FROM Form3Panel2DataGridView;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.form3RecordSelected[int.Parse(sqlite_datareader["id"].ToString()) - 1] = bool.Parse(sqlite_datareader["selected"].ToString());
				Program.state.form3RecordMerged[int.Parse(sqlite_datareader["id"].ToString()) - 1] = bool.Parse(sqlite_datareader["merged"].ToString());
				Program.state.form3RecordEdited[int.Parse(sqlite_datareader["id"].ToString()) - 1] = bool.Parse(sqlite_datareader["edited"].ToString());
				Program.state.form3Id[int.Parse(sqlite_datareader["id"].ToString()) - 1] = int.Parse(sqlite_datareader["id"].ToString());
				Program.state.form3OldId[int.Parse(sqlite_datareader["id"].ToString()) - 1] = int.Parse(sqlite_datareader["oldId"].ToString());

				//MessageBox.Show(sqlite_datareader["selected"].ToString() + sqlite_datareader["merged"].ToString() + sqlite_datareader["edited"].ToString() + sqlite_datareader["id"].ToString());
			}
			sqlite_datareader.Close();

			// Command
			sqlite_cmd.CommandText = "SELECT * FROM Form3Panel2ShowSelected;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.form3Panel2showHigh = bool.Parse(sqlite_datareader["high"].ToString());
				Program.state.form3Panel2showMedium = bool.Parse(sqlite_datareader["medium"].ToString());
				Program.state.form3Panel2showLow = bool.Parse(sqlite_datareader["low"].ToString());
				Program.state.form3Panel2showNone = bool.Parse(sqlite_datareader["none"].ToString());
				Program.state.form3Panel2showOpenPort = bool.Parse(sqlite_datareader["openPort"].ToString());
			}
			sqlite_datareader.Close();
			#endregion

			#region Form3Panel3 Load Data
			// Command
			sqlite_cmd.CommandText = "SELECT * " +
									 "FROM Form3Panel3;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				switch (sqlite_datareader["state"].ToString()) {
					case "HTML":
						Program.state.form3Panel3State = State.Form3Panel3State.HTML;
						break;
					case "DOCX":
						Program.state.form3Panel3State = State.Form3Panel3State.DOCX;
						break;
					case "DOCXTEM":
						Program.state.form3Panel3State = State.Form3Panel3State.DOCXTEM;
						break;
					case "XLSX":
						Program.state.form3Panel3State = State.Form3Panel3State.XLSX;
						break;
				}

				Program.state.form3Panel3OutputPath = sqlite_datareader["outputPath"].ToString();
				Program.state.form3Panel3TemplatePath = sqlite_datareader["templatePath"].ToString();
			}
			sqlite_datareader.Close();
			#endregion

			#region Form3Panel4 Load Data
			Program.state.panel4_dict = new Dictionary<string, string>();

			// Command
			sqlite_cmd.CommandText = "SELECT * " +
									 "FROM Form3Panel4;";

			// Execute non query command
			sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				Program.state.panel4_dict[sqlite_datareader["key"].ToString()] = sqlite_datareader["value"].ToString();
			}
			sqlite_datareader.Close();
			#endregion
			#endregion

			#region Load Record
			Program.state.form3Record = Program.state.form3Databaser.getRecord();
			List<DataEntry> record = new List<DataEntry>();

			foreach (KeyValuePair<int, DataEntry> entry in Program.state.form3Record.getHighRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.form3Record.getMediumRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.form3Record.getLowRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.form3Record.getNoneRisk()) {
				record.Add(entry.Value);
			}
			foreach (KeyValuePair<int, DataEntry> entry in Program.state.form3Record.getOpenPort()) {
				record.Add(entry.Value);
			}

			Program.state.form3ConfirmedRecord = new Record.Record();
			for (int i = 0; i < Program.state.form3RecordSelected.Count; i++){
				if (Program.state.form3RecordSelected[i]){
					Program.state.form3ConfirmedRecord.guiAddEntry(record[i]);
				}
			}
			#endregion

			return true;
		}

		public void output() {
			createRGConfigFile();

			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			#region Form3 Insert Data

			#region Form3 Panel1 Insert Data
			for (int i = 0; i < Program.state.form3Paths.Count; i++) {
				int selected = (Program.state.form3PathSelected[i]) ? 1 : 0;
				// Command
				sqlite_cmd.CommandText = "INSERT INTO Form3Panel1 (" +
										 "path," +
										 "selected) " +
										 "VALUES (" +
										 "'" + Program.state.form3Paths[i] + "', " +
										 selected.ToString() +
										 ");";

				// Execute non query command
				sqlite_cmd.ExecuteNonQuery();
			}
			#endregion

			#region Form3 Panel2 Insert Data
			// Command
			sqlite_cmd.CommandText = "INSERT INTO Form3Panel2DataBasePath (" +
									 "path) " +
									 "VALUES (" +
									 "'" + Program.state.form3DatabasePath + "'" + 
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();

			int a = Program.state.form3RecordSelected[0] ? 1 : 0;

			for (int i = 0; i < Program.state.form3Id.Count; i++) {
				String selected = (Program.state.form3RecordSelected[i]) ? "1" : "0";
				String merged = (Program.state.form3RecordMerged[i]) ? "1" : "0";
				String edited = (Program.state.form3RecordEdited[i]) ? "1" : "0";

				// Command
				sqlite_cmd.CommandText = "INSERT INTO Form3Panel2DataGridView (" +
										 "selected, " +
										 "merged, " +
										 "edited, " +
										 "id, " +
										 "oldId) " +
										 "VALUES (" +
										 "'" + selected + "', " + 
										 "'" + merged + "', " + 
										 "'" + edited + "', " + 
										 "'" + Program.state.form3Id[i].ToString() + "', " +
										 "'" + Program.state.form3OldId[i].ToString() + "'" +
										 ");";

				// Execute non query command
				sqlite_cmd.ExecuteNonQuery();
			}

			// Command
			sqlite_cmd.CommandText = "INSERT INTO Form3Panel2ShowSelected (" +
									 "high, " +
									 "medium, " +
									 "low, " +
									 "none, " +
									 "openPort) " +
									 "VALUES (" +
									 "'" + (Program.state.form3Panel2showHigh? "1" : "0") + "', " +
									 "'" + (Program.state.form3Panel2showMedium? "1" : "0") + "', " +
									 "'" + (Program.state.form3Panel2showLow? "1" : "0") + "', " +
									 "'" + (Program.state.form3Panel2showNone? "1" : "0") + "', " +
									 "'" + (Program.state.form3Panel2showOpenPort ? "1" : "0") + "'" +
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region Form3 Panel3 Insert Data
			// Command
			sqlite_cmd.CommandText = "INSERT INTO Form3Panel3 (" +
									 "state, " +
									 "outputPath, " +
									 "templatePath) " +
									 "VALUES (" +
									 "'" + Program.state.form3Panel3State.ToString() + "', " +
									 "'" + Program.state.form3Panel3OutputPath + "', " +
									 "'" + Program.state.form3Panel3TemplatePath + "'" +
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region Form3 Panel4 Insert Data
			if (Program.state.panel4_dict != null && Program.state.panel4_dict.Count != 0) {
				foreach (KeyValuePair<String, String> d in Program.state.panel4_dict) {
					if (!String.IsNullOrEmpty(d.Key) && !String.IsNullOrEmpty(d.Value)){
						// Command
						sqlite_cmd.CommandText = "INSERT INTO Form3Panel4 (" +
												 "key, " +
												 "value) " +
												 "VALUES (" +
												 d.Key + ", " +
												 d.Value +
												 ");";

						// Execute non query command
						sqlite_cmd.ExecuteNonQuery();
					}
				}
			}
			#endregion

			#region Form3 Panel5 Insert Data
			#endregion

			#endregion
		}

		private void createRGConfigFile() {
			this.path = directory + "\\" + "RGConfig_" + DateTime.Now.ToString("HHmmss_ddMMyy") + ".db";

			String connectionString = "Data source=" + path + ";Version=3;New=True;Compress=True;";

			// Create
			sqlite_conn = new SQLiteConnection(connectionString);

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			#region Form3 Database

			#region Form3 Panel1 Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Form3Panel1(" +
									 "path VARCHAR(200) PRIMARY KEY," +
									 "selected BOOLEAN DEFAULT 0);";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region Form3 Panel2 Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Form3Panel2DatabasePath(" +
									 "path VARCHAR(200));";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();

			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Form3Panel2DataGridView(" +
									 "selected BOOLEAN DEFAULT 0," +
									 "merged BOOLEAN DEFAULT 0," +
									 "edited BOOLEAN DEFAULT 0," +
									 "id INTEGER DEFAULT 0," +
									 "oldId INTEGER DEFAULT 0);";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();

			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Form3Panel2ShowSelected(" +
									 "high BOOLEAN DEFAULT 0," +
									 "medium BOOLEAN DEFAULT 0," +
									 "low BOOLEAN DEFAULT 0," +
									 "none BOOLEAN DEFAULT 0," +
									 "openPort BOOLEAN DEFAULT 0);";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region Form3 Panel3 Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Form3Panel3(" +
									 "state VARCHAR(10)," +
									 "outputPath VARCHAR(200)," +
									 "templatePath VARCHAR(200));";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region Form3 Panel4 Database
			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Form3Panel4(" +
									 "key VARCHAR(200) PRIMARY KEY," +
									 "value VARCHAR(200));";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();
			#endregion

			#region Form3 Panel5 Database
			#endregion

			#endregion

			// Close connection
			sqlite_conn.Close();
		}

	}
}
