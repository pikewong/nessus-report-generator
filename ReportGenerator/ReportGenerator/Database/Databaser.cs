using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using ReportGenerator.Record;

namespace ReportGenerator.Database {
	public class Databaser {
		private String path = null;
		private Record.Record record = null;
		private int originalId = 1;

		private SQLiteConnection sqlite_conn;
		private SQLiteCommand sqlite_cmd;

		public Databaser(String path) {
			this.path = path;
		}

		public Databaser(String path, ref Record.Record record) {
			this.path = path;
			this.record = record;

			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			// Command
			sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Record(" +
									 "id INTEGER PRIMARY KEY," +
									 "originalId INTEGER," +
									 "pluginName VARCHAR(500) NOT NULL," +
									 "ipList VARCHAR(1000) NOT NULL," +
									 "description VARCHAR(1000) NOT NULL," +
									 "impact VARCHAR(2000) NOT NULL," +
									 "riskfactor VARCHAR(10) NOT NULL," +
									 "recommendation VARCHAR(2000) NOT NULL," +
									 "bidlist VARCHAR(2000) NOT NULL," +
									 "cvelist VARCHAR(2000) NOT NULL," +
									 "osvdblist VARCHAR(2000) NOT NULL," +
									 "referenceLink VARCHAR(200)," +
									 "revisionNo INTEGER" +
									 ");";

			// Execute non query command
			sqlite_cmd.ExecuteNonQuery();

			insertRecordToDatabase(record.getHighRisk());
			insertRecordToDatabase(record.getMediumRisk());
			insertRecordToDatabase(record.getLowRisk());
			insertRecordToDatabase(record.getNoneRisk());
			insertRecordToDatabase(record.getOpenPort());

			sqlite_conn.Close();
		}

		public Record.Record getRecord() {
			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			Record.Record tempRecord = new Record.Record();
			sqlite_cmd.CommandText = "SELECT * " +
									 "FROM Record AS R " +
									 "WHERE (R.revisionNo = (SELECT MAX(R2.revisionNo) " +
														    "FROM Record AS R2 " +
														    "WHERE R.originalId = R2.originalId)" + 
										   ") OR " + 
									 "R.revisionNo = 1;";

			SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
			while (sqlite_datareader.Read()) {
				// get the content of the text field
				List<String> cveList = sqlite_datareader["cvelist"].ToString().Split(',').ToList<String>();
				List<String> bidList = sqlite_datareader["bidlist"].ToString().Split(',').ToList<String>();
				List<String> osvdbList = sqlite_datareader["osvdblist"].ToString().Split(',').ToList<String>();

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

				tempRecord.guiAddEntry(new NessusDataEntry(sqlite_datareader["pluginName"].ToString(),
														   sqlite_datareader["ipList"].ToString(),
														   sqlite_datareader["description"].ToString(),
														   sqlite_datareader["impact"].ToString(),
														   (int)RiskFactorFunction.getEnum(sqlite_datareader["riskfactor"].ToString()),
														   RiskFactorFunction.getEnum(sqlite_datareader["riskfactor"].ToString()),
														   sqlite_datareader["recommendation"].ToString(),
														   cveList,
														   bidList,
														   osvdbList,
														   sqlite_datareader["referenceLink"].ToString()));
			}

			sqlite_conn.Close();
			return tempRecord;
		}

		public void guiInsertMergeRecordToDatabase(DataEntry entry) {
			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			String pluginName = addSlash(entry.getPluginName());
			String ipList = addSlash(entry.getIp());
			String description = addSlash(entry.getDescription());
			String impact = addSlash(entry.getImpact());
			String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
			String recommendation = addSlash(entry.getRecommendation());
			String bidList = addSlash(entry.getBid());
			String cveList = addSlash(entry.getCve());
			String osvdbList = addSlash(entry.getOsvdb());
			String referenceLink = addSlash(entry.getReferenceLink());

			sqlite_cmd.CommandText = "INSERT INTO Record (" +
									 "id," +
									 "originalId," +
									 "pluginName," +
									 "ipList," +
									 "description," +
									 "impact," +
									 "riskfactor," +
									 "recommendation," +
									 "bidlist," +
									 "cvelist," +
									 "osvdblist," +
									 "referenceLink," +
									 "revisionNo" +
									 ")" +
									 "VALUES (" +
									 "NULL," +								// pluginId (null means auto increment)
									 "'" + originalId + "'," +				// originalId
									 "'" + pluginName + "'," +				// pluginName
									 "'" + ipList + "'," +					// ipList
									 "'" + description + "'," +				// description
									 "'" + impact + "'," +					// impact
									 "'" + riskFactor + "'," +				// riskfactor
									 "'" + recommendation + "'," +			// recommendation
									 "'" + bidList + "'," +					// bidlist
									 "'" + cveList + "'," +					// cvelist
									 "'" + osvdbList + "'," +				// osvdblist
									 "'" + referenceLink + "'," +			// referenceLink
									 "'1'" +								// revisionNo
									 ");";
			originalId++;

			// execute the command
			sqlite_cmd.ExecuteNonQuery();

			sqlite_conn.Close();
		}

		public void guiInsertUpdateRecordToDatabase(DataEntry entry, int oldId) {
			int revisionNo = getRevisionNo(oldId);

			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			String pluginName = addSlash(entry.getPluginName());
			String ipList = addSlash(entry.getIp());
			String description = addSlash(entry.getDescription());
			String impact = addSlash(entry.getImpact());
			String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
			String recommendation = addSlash(entry.getRecommendation());
			String bidList = addSlash(entry.getBid());
			String cveList = addSlash(entry.getCve());
			String osvdbList = addSlash(entry.getOsvdb());
			String referenceLink = addSlash(entry.getReferenceLink());

			sqlite_cmd.CommandText = "INSERT INTO Record (" +
									 "id," +
									 "originalId," +
									 "pluginName," +
									 "ipList," +
									 "description," +
									 "impact," +
									 "riskfactor," +
									 "recommendation," +
									 "bidlist," +
									 "cvelist," +
									 "osvdblist," +
									 "referenceLink," +
									 "revisionNo" +
									 ")" +
									 "VALUES (" +
									 "NULL," +								// pluginId (null means auto increment)
									 "'" + oldId + "'," +					// originalId
									 "'" + pluginName + "'," +				// pluginName
									 "'" + ipList + "'," +					// ipList
									 "'" + description + "'," +				// description
									 "'" + impact + "'," +					// impact
									 "'" + riskFactor + "'," +				// riskfactor
									 "'" + recommendation + "'," +			// recommendation
									 "'" + bidList + "'," +					// bidlist
									 "'" + cveList + "'," +					// cvelist
									 "'" + osvdbList + "'," +				// osvdblist
									 "'" + referenceLink + "'," +			// referenceLink
									 "'" + revisionNo + "'" +								// revisionNo
									 ");";

			// execute the command
			sqlite_cmd.ExecuteNonQuery();

			sqlite_conn.Close();
		}

		private void insertRecordToDatabase(Dictionary<int, DataEntry> risk) {
			foreach (KeyValuePair<int, DataEntry> entry in risk) {
				insertRecordToDatabase(entry.Value);
			}
		}

		private void insertRecordToDatabase(DataEntry entry) {
			String pluginName = addSlash(entry.getPluginName());
			String ipList = addSlash(entry.getIp());
			String description = addSlash(entry.getDescription());
			String impact = addSlash(entry.getImpact());
			String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
			String recommendation = addSlash(entry.getRecommendation());
			String bidList = addSlash(entry.getBid());
			String cveList = addSlash(entry.getCve());
			String osvdbList = addSlash(entry.getOsvdb());
			String referenceLink = addSlash(entry.getReferenceLink());

			sqlite_cmd.CommandText = "INSERT INTO Record (" +
									 "id," +
									 "originalId," +
									 "pluginName," +
									 "ipList," +
									 "description," +
									 "impact," +
									 "riskfactor," +
									 "recommendation," +
									 "bidlist," +
									 "cvelist," +
									 "osvdblist," +
									 "revisionNo"+
									 ")" +
									 "VALUES (" +
									 "NULL," +								// pluginId (null means auto increment)
									 "'" + originalId + "'," +				// originalId
									 "'" + pluginName + "'," +				// pluginName
									 "'" + ipList + "'," +					// ipList
									 "'" + description + "'," +				// description
									 "'" + impact + "'," +					// impact
									 "'" + riskFactor + "'," +				// riskfactor
									 "'" + recommendation + "'," +			// recommendation
									 "'" + bidList + "'," +					// bidlist
									 "'" + cveList + "'," +					// cvelist
									 "'" + osvdbList + "'," +				// osvdblist
									 "'" + "1" + "'" +						// revisionNo
									 ");";

			originalId++;

			// execute the command
			sqlite_cmd.ExecuteNonQuery();
		}

		private int getRevisionNo(int oldId) {
			// Create
			sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

			// Open
			sqlite_conn.Open();

			// Create command
			sqlite_cmd = sqlite_conn.CreateCommand();

			sqlite_cmd.CommandText = "SELECT revisionNo " +
									 "FROM Record " +
									 "WHERE originalId=" + oldId.ToString() + ";";
			SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
			int revisionNo = -1;
			while (sqlite_datareader.Read()) {
				if (revisionNo < int.Parse(sqlite_datareader["revisionNo"].ToString())) {
					revisionNo = int.Parse(sqlite_datareader["revisionNo"].ToString());
				}
			}
			sqlite_datareader.Close();
			revisionNo++;

			sqlite_conn.Close();
			return revisionNo;
		}

		private String addSlash(String s) {
			if (String.IsNullOrEmpty(s))
				return "";
			String tempString = "";
			foreach (char c in s) {
				if (c == '\'') {
					tempString += "\'\'";
				}
				else {
					tempString += c;
				}
			}
			return tempString;
		}

	}
}
