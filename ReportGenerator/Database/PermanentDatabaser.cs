using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using ReportGenerator.Record;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace ReportGenerator.Database
{
    /// <summary>
    /// This is the permanent databaser to store/get replace description/recommendation information.
    /// </summary>
    public class PermanentDatabaser {
        private SQLiteConnection sqlite_conn;
        private SQLiteCommand sqlite_cmd;
        private string path = null;
        public PermanentDatabaser(string _path = null) {
            path = _path;
            if (path== null || path == "")
                //get default current .exe directory
                path = Program.state.amendmentDatabaserDefaultPath;

            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Amendment(" +
                                     "id VARCHAR(5000) PRIMARY KEY," +
                                     "entryType VARCHAR(30) NOT NULL," +
                                     "originalDescription VARCHAR(30000) NULL," +
                                     "editedDescription VARCHAR(30000) NULL," +
                                     "originalRecommendation VARCHAR(30000) NULL," +
                                     "editedRecommendation VARCHAR(30000) NULL," + 
                                     "originalReferenceLink VARCHAR(30000) NULL," +
                                     "editedReferenceLink VARCHAR(30000) NULL" +
                                     ");";
            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
            
        }

        public void storeAmendment(Amendment amendment)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            //to check the id existing or not
            sqlite_cmd.CommandText = "SELECT * FROM Amendment WHERE id = '" + amendment.getId() + "';";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            if (sqlite_datareader.Read())
            {
                sqlite_datareader.Close();
                if (amendment.getOriginalDescription() != null && amendment.getEditedDescription() != null)
                    sqlite_cmd.CommandText = "UPDATE Amendment SET"
                                             + " originalDescription = '" + amendment.getOriginalDescription()
                                             + "', editedDescription ='" + amendment.getEditedDescription() +"'"
                                             + " WHERE id= '"+amendment.getId() + "' ;";
                if (amendment.getOriginalRecommendation() != null && amendment.getEditedRecommendation() != null)
                    sqlite_cmd.CommandText = "UPDATE Amendment SET"
                                             + " originalRecommendation = '" + amendment.getOriginalRecommendation()
                                             + "', editedRecommendation ='" + amendment.getEditedRecommendation() + "'"
                                             + " WHERE id= '" + amendment.getId() + "' ;";
                if (amendment.getOriginalReferenceLink() != null && amendment.getEditedReferenceLink() != null)
                    sqlite_cmd.CommandText = "UPDATE Amendment SET"
                                             + " originalReferenceLink = '" + amendment.getOriginalReferenceLink()
                                             + "', editedReferenceLink ='" + amendment.getEditedReferenceLink() + "'"
                                             + " WHERE id= '" + amendment.getId() + "' ;";
                //else
                //    sqlite_cmd.CommandText = "UPDATE Amendment SET"
                //                             + " originalDescription = '" + amendment.getOriginalDescription()
                //                             + "', editedDescription ='" + amendment.getEditedDescription()
                //                             + "', originalRecommendation = '" + amendment.getOriginalRecommendation()
                //                             + "', editedRecommendation ='" + amendment.getEditedRecommendation() + "'"
                //                             + " WHERE id= '" + amendment.getId() + "' ;";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_conn.Close();
                return;
            }
            sqlite_datareader.Close();


            sqlite_cmd.CommandText = "INSERT INTO Amendment (" +
                                     "id," +
                                     "entryType," +
                                     "originalDescription," +
                                     "editedDescription," +
                                     "originalRecommendation," +
                                     "editedRecommendation," +
                                     "originalReferenceLink," + 
                                     "editedReferenceLink" +
                                     ")" +
                                     "VALUES (" +
                                     "'" + addSlash(amendment.getId()) + "'," +				// pluginName
                                     "'" + addSlash(amendment.getEntryType()) + "'," +					// ipList
                                     "'" + addSlash(amendment.getOriginalDescription()) + "'," +				// description
                                     "'" + addSlash(amendment.getEditedDescription()) + "'," +					// impact
                                     "'" + addSlash(amendment.getOriginalRecommendation()) + "'," +				// riskfactor
                                     "'" + addSlash(amendment.getEditedRecommendation()) + "'," +
                                     "'" + addSlash(amendment.getOriginalReferenceLink()) + "'," +
                                     "'" + addSlash(amendment.getEditedReferenceLink()) + "'" +
                                     ");";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public List<Amendment> getAmendmentList() {
            List<Amendment> amendmentList = new List<Amendment>();

            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM Amendment;";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Amendment tempAmendment = new Amendment(sqlite_datareader["id"].ToString(),
                                                        sqlite_datareader["entryType"].ToString(),
                                                        sqlite_datareader["originalDescription"].ToString(),
                                                        sqlite_datareader["editedDescription"].ToString(),
                                                        sqlite_datareader["originalRecommendation"].ToString(),
                                                        sqlite_datareader["editedRecommendation"].ToString(),
                                                        sqlite_datareader["originalReferenceLink"].ToString(),
                                                        sqlite_datareader["editedReferenceLink"].ToString());
                amendmentList.Add(tempAmendment);
            
            }
            sqlite_datareader.Close();

            sqlite_conn.Close();

            return amendmentList;
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

        public BindingSource getBindingSource(string targetCol = null, string keyword = null)
        {
            string query = "SELECT* FROM Amendment";
            //if (targetCol != null && keyword != null)
            //    query += " WHERE " + targetCol + " LIKE '%" + keyword + "%'";


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            Record.Record tempRecord = new Record.Record();
            sqlite_cmd.CommandText = query;

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlite_datareader);
            foreach (DataColumn col in dataTable.Columns)
                col.AllowDBNull = true;
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dataTable;
            sqlite_conn.Close();
            return bSource;
        }

        public void deleteAllRows() 
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "DELETE FROM Amendment";

            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();

        }
    }
}
