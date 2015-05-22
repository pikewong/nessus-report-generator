using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using ReportGenerator.Record;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

using System.Data.Odbc;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;




namespace ReportGenerator.Database
{
    /*
     * This is the Databaser Class.
     * It is used to handle the store/load to/from sqlite database file.
     */
    public class Databaser
    {

        // Variables
        private String path = null;
        private Record.Record record = null;
        private int originalId = 1;
        private int originalIDForNessusFinding = 1;
        private int finddetailfid = 1;
        private int findingreferencesfid = 1;
        private int rid = 1;

        private SQLiteConnection sqlite_conn;
        private SQLiteCommand sqlite_cmd;

        public FormMessageWithProgressBar formMessageWithProgressBar = null;
        /*
         * This is the contructor of the databaser.
         * It is used to assign the value from the given path.
         */
        public Databaser(String path)
        {
            this.path = path;
        }

        /*
         * This is the contructor of the databaser.
         * It is used to assign the values from the given path and Record.
         */
        public Databaser(String path, ref Record.Record record)
        {
            this.path = path;
            this.record = record;
        }

        public void storeRawRecord()
        {

            #region // Create the Database File
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS NmapRecordRaw(" +
                                     "id INTEGER PRIMARY KEY," +
                                     "pluginName VARCHAR(5000) NOT NULL," +
                                     "ipList VARCHAR(2000) NOT NULL," +
                                     "description VARCHAR(300000) NOT NULL," +
                                     //"impact VARCHAR(3000) NOT NULL," +
                                     "riskfactor VARCHAR(20) NOT NULL," +
                                     //"recommendation VARCHAR(3000) NOT NULL," +
                                     //"bidlist VARCHAR(2000) NOT NULL," +
                                     //"cvelist VARCHAR(2000) NOT NULL," +
                                     //"osvdblist VARCHAR(2000) NOT NULL," +
                                     //"referenceLink VARCHAR(200)," +
                                     "fileName VARCHAR(1000) NOT NULL," +
                                     "entryType VARCHAR(100) NOT NULL," +

                                     "OS VARCHAR(500)," +
                                     "OSDetail VARCHAR(3000)," +
                                     "openPortList VARCHAR(300000)," +
                                     "closedPortList VARCHAR(300000)," +
                                     "filteredPortList VARCHAR(300000)," +
                                     "unknownPortList VARCHAR(300000)" + 
                                     ");";
            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS MBSARecordRaw(" +
                                     "id INTEGER PRIMARY KEY," +
                                     "pluginName VARCHAR(500) NOT NULL," +
                                     "ipList VARCHAR(2000) NOT NULL," +
                                     "description VARCHAR(3000) NOT NULL," +
                                     "impact VARCHAR(3000) NOT NULL," +
                                     "riskfactor VARCHAR(20) NOT NULL," +
                                     "recommendation VARCHAR(3000) NOT NULL," +
                                     "bidlist VARCHAR(2000) NOT NULL," +
                                     "cvelist VARCHAR(2000) NOT NULL," +
                                     "osvdblist VARCHAR(2000) NOT NULL," +
                                     "referenceLink VARCHAR(200) NOT NULL," +
                                     "fileName VARCHAR(1000) NOT NULL," +
                                     "entryType VARCHAR(100) NOT NULL," +
                                     

                                     "checkID VARCHAR(500)," +
                                     "checkGrade VARCHAR(500)," +
                                     "checkType VARCHAR(500)," +
                                     "checkCat VARCHAR(500)," +
                                     "checkRank VARCHAR(500)," +
                                     "checkName VARCHAR(500)," +
                                     "checkURL1 VARCHAR(500)," +
                                     "checkURL2 VARCHAR(500)," +
                                     "checkGroupID VARCHAR(500)," +
                                     "checkGroupName VARCHAR(500)," +
                                     "detailText VARCHAR(10000)," +
                                     "updateDataIsInstalled VARCHAR(500)," +
                                     "updateDataRestartRequired VARCHAR(500)," +
                                     "updateDataID VARCHAR(500)," +
                                     "updateDataGUID VARCHAR(500)," +
                                     "updateDataBulletinID VARCHAR(500)," +
                                     "updateDataKBID VARCHAR(500)," +
                                     "updateDataType VARCHAR(500)," +
                                     "UpdateDataInformationURL VARCHAR(500)," +
                                     "UpdateDataDownloadURL VARCHAR(500)," +
                                     "severity INTEGER," +
                                     "tableHeader VARCHEAR(30000)," +
                                     "tableRowData VARCHAR(30000)" +
                                     ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS NessusRecordRaw(" +
                                     "id INTEGER PRIMARY KEY," +
                                     "pluginName VARCHAR(300000) ," +
                                     "ipList VARCHAR(200000) ," +
                                     "description VARCHAR(300000) ," +
                                     "impact VARCHAR(300000) ," +

                                     "riskfactor VARCHAR(3000) ," +
                                     "recommendation VARCHAR(300000) ," +
                                     "bidlist VARCHAR(300000) ," +
                                     "cvelist VARCHAR(300000) ," +
                                     "osvdblist VARCHAR(300000) , " +
                                     "referenceLink VARCHAR(300000) , " +
                                     "fileName VARCHAR(100000) ," +
                                     "entryType VARCHAR(1000) ," +

                                     "port VARCHAR(30000), " +
                                     "protocol VARCHAR(300000), " +
                                     "svc_name VARCHAR(300000), " +
                                     "pluginFamily VARCHAR(300000), " +
                                     "plugin_publication_date VARCHAR(300000), " +
                                     "plugin_modification_date VARCHAR(300000), " +
                                     "cvss_vector VARCHAR(300000), " +
                                     "cvss_base_score VARCHAR(300000), " +
                                     "plugin_output VARCHAR(1000000), " +
                                     "plugin_version VARCHAR(300000), " +
                                     "see_alsoList VARCHAR(300000)," +
                                     "pluginID VARCHAR(10000)," +
                                     "microSoftID VARCHAR(10000)," +
                                     "severity INTEGER" +
                                     
                                     ");";


            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS AcunetixRecordRaw(" +
                                     "id INTEGER PRIMARY KEY," +
                                     "pluginName VARCHAR(500) NOT NULL," +
                                     "ipList VARCHAR(2000) NOT NULL," +
                                     "description VARCHAR(3000) NOT NULL," +
                                     "impact VARCHAR(3000) NOT NULL," +
                                     "riskfactor VARCHAR(20) NOT NULL," +
                                     "recommendation VARCHAR(3000) NOT NULL," +
                                     "bidlist VARCHAR(2000) NOT NULL," +
                                     "cvelist VARCHAR(2000) NOT NULL," +
                                     "osvdblist VARCHAR(2000) NOT NULL," +
                                     "referenceLink VARCHAR(200)," +
                                     "fileName VARCHAR(1000) NOT NULL," +
                                     "entryType VARCHAR(100) NOT NULL," +

                                     "subDomain VARCHAR(1000) NOT NULL," + 

                                     "moduleName VARCHAR(30000) NOT NULL," +
                                     "isFalsePositive VARCHAR(300) NOT NULL," +
                                     "AOP_SourceFile VARCHAR(30000) NOT NULL," +
                                     "AOP_SourceLine VARCHAR(30000) NOT NULL," +
                                     "AOP_Additional VARCHAR(30000) NOT NULL," +
                                     "detailedInformation VARCHAR(30000) NOT NULL," +
                                     "acunetixType VARCHAR(300) NOT NULL," +
                                     "reference VARCHAR(30000) NOT NULL" +
                                     ");";


            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS AcunetixRecordRawAffectedItem(" +
                                     "id INTEGER NOT NULL," +
                                     "affectedItemSubDirectory VARCHAR(10000) NOT NULL," +
                                     "department VARCHAR(10000) NOT NULL," +
                                     "affectedItem VARCHAR(10000) NOT NULL," +
                                     "affectedItemLink VARCHAR(10000) NOT NULL," + 
                                     "affectedItemDetail VARCHAR(30000) NOT NULL," +
                                     "affectedItemRequest VARCHAR(30000) NOT NULL," +
                                     "affectedItemResponse VARCHAR(30000) NOT NULL" +
                                     ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            //// Command
            //sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS AcunetixReferenceList(" +
            //                         "id INTEGER NOT NULL," +
            //                         "database VARCHAR(30000)," +
            //                         "url VARCHAR(30000)" +
            //                         ");";

            //// Execute non query command
            //sqlite_cmd.ExecuteNonQuery();

            formMessageWithProgressBar = new FormMessageWithProgressBar("Creating Raw Database...", record.getRawCount());
            formMessageWithProgressBar.Show();

            // insert the findings to the database file
            //SQLiteTransaction transaction = sqlite_conn.BeginTransaction();
            insertRecordToRawDatabase(record.getHighRiskRaw());
            insertRecordToRawDatabase(record.getMediumRiskRaw());
            insertRecordToRawDatabase(record.getLowRiskRaw());
            insertRecordToRawDatabase(record.getNoneRiskRaw());
            insertRecordToRawDatabase(record.getOpenPortRaw());
            insertRecordToRawDatabase(record.getCheckNARaw());
            //transaction.Commit();

            formMessageWithProgressBar.Close();

            // Close connection
            sqlite_conn.Close();
            #endregion


        }

        private void insertRecordToRawDatabase(List<DataEntry> risk)
        {

            int i = 0;
           SQLiteTransaction transaction = sqlite_conn.BeginTransaction();
            
            foreach (DataEntry entry in risk)
            {
                if (i++ == 9000)
                {
                    transaction.Commit();
                    i = 0;
                    transaction = sqlite_conn.BeginTransaction();
                }
                //Application.DoEvents();
                insertRecordToRawDatabase(entry);
                //if (formMessageWithProgressBar != null)
                    formMessageWithProgressBar.setFinishedNumber(formMessageWithProgressBar.getFinishedNumber() + 1);
                Application.DoEvents();
            }
            transaction.Commit();

        }

        private void insertRecordToRawDatabase(DataEntry entry)
        {
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
            String entryType = addSlash(entry.getEntryTypeString());
            String fileName = addSlash(entry.getFileName());

            if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.NESSUS) == 0)
            {
                
                String port = addSlash(((NessusDataEntry)entry).getPort());
                String protocol = addSlash(((NessusDataEntry)entry).getProtocol());
                String svc_name = addSlash(((NessusDataEntry)entry).getSvc_name());
                String pluginFamily = addSlash(((NessusDataEntry)entry).getPluginFamily());
                String plugin_publication_date = addSlash(((NessusDataEntry)entry).getPlugin_publication_date());
                String plugin_modification_date = addSlash(((NessusDataEntry)entry).getPlugin_modification_date());
                String cvss_vector = addSlash(((NessusDataEntry)entry).getCvss_vector());
                String cvss_base_score = addSlash(((NessusDataEntry)entry).getCvss_base_score());
                String plugin_output = addSlash(((NessusDataEntry)entry).getPlugin_output());
                String plugin_version = addSlash(((NessusDataEntry)entry).getPlugin_version());
                String see_also = addSlash(((NessusDataEntry)entry).getSee_also());
                String pluginID = addSlash(((NessusDataEntry)entry).getPluginID());
                String microsoftID = addSlash(((NessusDataEntry)entry).getMicrosoftID());
                int severity = ((NessusDataEntry)entry).getSeverity();

                sqlite_cmd.CommandText = "INSERT INTO NessusRecordRaw (" +
                                     "id," +
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
                                     "fileName," + 
                                     "entryType," +
                                     "port," +
                                     "protocol," +
                                     "svc_name," +
                                     "pluginFamily," +
                                     "plugin_publication_date," +
                                     "plugin_modification_date," +
                                     "cvss_vector," +
                                     "cvss_base_score," +
                                     "plugin_output," +
                                     "plugin_version," +
                                     "see_alsoList," +
                                     "pluginID," +
                                     "microSoftID," +
                                     "severity" +
                                     ")" +
                                     "VALUES (" +
                                     "NULL," + 					// pluginId (null means auto increment)
                                     "'"+ pluginName +  "'," +				// pluginName
                                     "'"+ ipList +  "'," +					// ipList
                                     "'"+ description +  "'," +				// description
                                     "'"+ impact +  "'," +					// impact
                                     "'"+ riskFactor +  "'," +				// riskfactor
                                     "'"+ recommendation +  "'," +			// recommendation
                                     "'"+ bidList +  "'," +					// bidlist
                                     "'"+ cveList +  "'," +					// cvelist
                                     "'"+ osvdbList +  "'," +				// osvdblist
                                     "'"+ referenceLink +  "'," +			// referenceLink
                                     "'" + fileName + "'," +	
                                     "'"+ entryType +  "'," +				// entryType
                                     "'"+ port +  "'," +				    // port
                                     "'"+ protocol +  "'," +			    // protocol
                                     "'"+ svc_name +  "'," +                 // svc_name
                                     "'"+ pluginFamily +  "'," +             // pluginFamily
                                     "'"+ plugin_publication_date +  "'," +  // plugin_publication_date
                                     "'"+ plugin_modification_date +  "'," + // plugin_modification_date
                                     "'"+ cvss_vector +  "'," +              // cvss_vector
                                     "'"+ cvss_base_score +  "'," +          // cvss_base_score
                                     "'"+ plugin_output +  "'," +            // plugin_output
                                     "'"+ plugin_version +  "'," +           // plugin_version
                                     "'"+ see_also + "',"+                 // see_alsoList
                                     "'"+ pluginID + "'," +
                                     "'" + microsoftID + "'," +
                                     "'" + severity + "'" +
                                     ");";
                // execute the command
                sqlite_cmd.ExecuteNonQuery();
            }
            else if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.MBSA) == 0)
            {
                int severity = ((MBSADataEntry)entry).getSeverity();
                String checkID = addSlash(((MBSADataEntry)entry).getCheckID()); 
                String checkGrade = addSlash(((MBSADataEntry)entry).getCheckGrade());
                String checkType = addSlash(((MBSADataEntry)entry).getCheckType()); 
                String checkCat = addSlash(((MBSADataEntry)entry).getCheckCat()); 
                String checkRank = addSlash(((MBSADataEntry)entry).getCheckRank()); 
                String checkName = addSlash(((MBSADataEntry)entry).getCheckName()); 
                String checkURL1 = addSlash(((MBSADataEntry)entry).getCheckURL1()); 
                String checkURL2 = addSlash(((MBSADataEntry)entry).getCheckURL2()); 
                String checkGroupID = addSlash(((MBSADataEntry)entry).getCheckGroupID()); 
                String checkGroupName = addSlash(((MBSADataEntry)entry).getCheckGroupName()); 
                String detailText = addSlash(((MBSADataEntry)entry).getDetailText()); 
                String updateDataIsInstalled  = addSlash(((MBSADataEntry)entry).getUpdateDataIsInstalled()); 
                String updateDataRestartRequired = addSlash(((MBSADataEntry)entry).getUpdateDataRestartRequired()); 
                String updateDataID = addSlash(((MBSADataEntry)entry).getUpdateDataID()); 
                String updateDataGUID = addSlash(((MBSADataEntry)entry).getUpdateDataGUID()); 
                String updateDataBulletinID = addSlash(((MBSADataEntry)entry).getUpdateDataBulletinID()); 
                String updateDataKBID = addSlash(((MBSADataEntry)entry).getUpdateDataKBID()); 
                String updateDataType = addSlash(((MBSADataEntry)entry).getUpdateDataType()); 
                String UpdateDataInformationURL = addSlash(((MBSADataEntry)entry).getUpdateDataInformationURL());
                String UpdateDataDownloadURL = addSlash(((MBSADataEntry)entry).getUpdateDataDownloadURL());

                String tableHeader = addSlash(((MBSADataEntry)entry).getTableHeaderString());
                String tableRowData = addSlash(((MBSADataEntry)entry).getTableRowDataString()); 


                sqlite_cmd.CommandText = "INSERT INTO MBSARecordRaw (" +
                                         "id," +
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
                                         "fileName," + 
                                         "entryType," +

                                         "checkID," +
                                         "checkGrade," +
                                         "checkType," +
                                         "checkCat," +
                                         "checkRank," +
                                         "checkName," +
                                         "checkURL1," +
                                         "checkURL2," +
                                         "checkGroupID," +
                                         "checkGroupName," +
                                         "detailText," +
                                         "updateDataIsInstalled," +
                                         "updateDataRestartRequired," +
                                         "updateDataID," +
                                         "updateDataGUID," +
                                         "updateDataBulletinID," +
                                         "updateDataKBID," +
                                         "updateDataType," +
                                         "UpdateDataInformationURL," +
                                         "UpdateDataDownloadURL," +
                                         "severity," +
                                         "tableHeader," +
                                         "tableRowData" +
                                         ")" +
                                         "VALUES (" +
                                         "NULL," +								// pluginId (null means auto increment)
                                         "'"+ pluginName +  "'," +				// pluginName
                                         "'"+ ipList +  "'," +					// ipList
                                         "'"+ description +  "'," +				// description
                                         "'"+ impact +  "'," +					// impact
                                         "'"+ riskFactor +  "'," +				// riskfactor
                                         "'"+ recommendation +  "'," +			// recommendation
                                         "'"+ bidList +  "'," +					// bidlist
                                         "'"+ cveList +  "'," +					// cvelist
                                         "'"+ osvdbList +  "'," +				// osvdblist
                                         "'"+ referenceLink +  "'," +			// referenceLink
                                         "'" + fileName + "'," +	
                                         "'"+ entryType +  "'," +				// entryType
                                         "'"+ checkID +  "'," +
                                         "'"+ checkGrade +  "'," +
                                         "'" + checkType + "'," +
                                         "'"+ checkCat +  "'," +
                                         "'"+ checkRank +  "'," +
                                         "'"+ checkName +  "'," +
                                         "'"+ checkURL1 +  "'," +
                                         "'"+ checkURL2 +  "'," +
                                         "'"+ checkGroupID +  "'," +
                                         "'"+ checkGroupName +  "'," +
                                         "'"+ detailText +  "'," +
                                         "'"+ updateDataIsInstalled +  "'," +
                                         "'"+ updateDataRestartRequired +  "'," +
                                         "'"+ updateDataID +  "'," +
                                         "'"+ updateDataGUID +  "'," +
                                         "'"+ updateDataBulletinID +  "'," +
                                         "'"+ updateDataKBID +  "'," +
                                         "'"+ updateDataType +  "'," +
                                         "'"+ UpdateDataInformationURL +  "'," +
                                         "'"+ UpdateDataDownloadURL +  "'," +
                                         "'"+ severity +  "',"+
                                         "'" + tableHeader + "'," +
                                         "'" + tableRowData + "'" +
                                         ");";
                // execute the command
                sqlite_cmd.ExecuteNonQuery();
            }
            else if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.NMAP) == 0)
            {
                String OS = addSlash(((NmapDataEntry)entry).getOS());
                String OSDetail = addSlash(((NmapDataEntry)entry).getOSDetail());
                String openPortList = addSlash(((NmapDataEntry)entry).getOpenPortListString());
                String closedPortList = addSlash(((NmapDataEntry)entry).getClosedPortListString());
                String filteredPortList = addSlash(((NmapDataEntry)entry).getFilteredPortListString());
                String unknownPortList = addSlash(((NmapDataEntry)entry).getUnknownPortListString());
                sqlite_cmd.CommandText = "INSERT INTO NmapRecordRaw (" +
                                         "id," +
                                         "pluginName," +
                                         "ipList," +
                                         "description," +
                                         //"impact," +
                                         "riskfactor," +
                                         //"recommendation," +
                                         //"bidlist," +
                                         //"cvelist," +
                                         //"osvdblist," +
                                         //"referenceLink," +
                                         "fileName," + 
                                         "entryType," +
                                         "OS," +
                                         "OSDetail," +
                                         "openPortList," +
                                         "closedPortList," +
                                         "filteredPortList," +
                                         "unknownPortList" + 
                                         ")" +
                                         "VALUES (" +
                                         "NULL," +								// pluginId (null means auto increment)
                                         //"'"+ originalId +  "'," +				// originalId
                                         "'"+ pluginName +  "'," +				// pluginName
                                         "'"+ ipList +  "'," +					// ipList
                                         "'"+ description +  "'," +				// description
                                         //"'"+ impact +  "'," +					// impact
                                         "'"+ riskFactor +  "'," +				// riskfactor
                                         //"'"+ recommendation +  "'," +			// recommendation
                                         //"'"+ bidList +  "'," +					// bidlist
                                         //"'"+ cveList +  "'," +					// cvelist
                                         //"'"+ osvdbList +  "'," +				// osvdblist
                                         //"'"+ referenceLink +  "'," +			// referenceLink
                                         "'" + fileName + "'," +	
                                         "'"+ entryType +  "'," +				// entryType
                                         "'"+ OS +  "'," +
                                         "'"+ OSDetail + "',"+
                                         "'" + openPortList + "'," +
                                         "'" + closedPortList + "'," +
                                         "'" + filteredPortList + "'," +
                                         "'" + unknownPortList + "'" + 
                                         ");";
                // execute the command
                sqlite_cmd.ExecuteNonQuery();
            }
            else if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.Acunetix) == 0)
            {
                List<AffectedItem> affectedItemList = ((AcunetixDataEntry)entry).getAffectedItemList();
                String subDomain = addSlash(((AcunetixDataEntry)entry).getSubDomain());
                String moduleName = addSlash(((AcunetixDataEntry)entry).getModuleName());
                String isFalsePositive = addSlash(((AcunetixDataEntry)entry).getIsFalsePositive());
                String AOP_SourceFile = addSlash(((AcunetixDataEntry)entry).getAOP_SourceFile());
                String AOP_SourceLine = addSlash(((AcunetixDataEntry)entry).getAOP_SourceLine());
                String AOP_Additional = addSlash(((AcunetixDataEntry)entry).getAOP_Additional());
                String detailedInformation = addSlash(((AcunetixDataEntry)entry).getDetailedInformation());
                String acunetixType = addSlash(((AcunetixDataEntry)entry).getAcunetixType());
                String reference = addSlash(((AcunetixDataEntry)entry).getAcunetixReferenceListString());
                sqlite_cmd.CommandText = "INSERT INTO AcunetixRecordRaw (" +
                                         "id," +
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
                                         "fileName," +
                                         "entryType," +
                                         "subDomain,"+
                                         "moduleName," +
                                         "isFalsePositive," +
                                         "AOP_SourceFile," +
                                         "AOP_SourceLine," +
                                         "AOP_Additional," +
                                         "detailedInformation," +
                                         "acunetixType," +
                                         "reference" + 
                                         ")" +
                                         "VALUES (" +
                                         "NULL," +								// pluginId (null means auto increment)
                    //"'"+ originalId +  "'," +				// originalId
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
                                         "'" + fileName + "'," +
                                         "'" + entryType + "'," +				// entryType
                                         "'" + subDomain + "'," +
                                         "'" + moduleName + "'," +
                                         "'" + isFalsePositive + "'," +
                                         "'" + AOP_SourceFile + "'," +
                                         "'" + AOP_SourceLine + "'," +
                                         "'" + AOP_Additional + "'," +
                                         "'" + detailedInformation + "'," +
                                         "'" + acunetixType + "'," +
                                         "'" + reference + "'" + 
                                         ");";

                // execute the command
                sqlite_cmd.ExecuteNonQuery();

                //get back ID
                int maxId ;
                sqlite_cmd.CommandText = "SELECT MAX(id) AS maxId FROM AcunetixRecordRaw;";
                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                if (sqlite_datareader.Read()){
                    maxId = int.Parse(sqlite_datareader["maxId"].ToString());
                    sqlite_datareader.Close();

                    foreach(AffectedItem item in affectedItemList)
                    {
                        //// add affected items
                        sqlite_cmd.CommandText = "INSERT INTO AcunetixRecordRawAffectedItem (" +
                                                 "id," +
                                                 "affectedItemSubDirectory," +
                                                 "department," + 
                                                 "affectedItem," +
                                                 "affectedItemLink," +
                                                 "affectedItemDetail," +
                                                 "affectedItemRequest," +
                                                 "affectedItemResponse" +
                                                 ")" +
                                                 "VALUES (" +
                                                 "'" + maxId + "'," +
                                                 "'" + addSlash(item.getSubDirectory()) + "'," +
                                                 "'" + addSlash(item.getDepartment()) + "'," +
                                                 "'" + addSlash(item.getName()) + "'," +
                                                 "'" + addSlash(item.getLink()) + "'," +
                                                 "'" + addSlash(item.getDetail()) + "'," +
                                                 "'" + addSlash(item.getRequest()) + "'," +
                                                 "'" + addSlash(item.getResponse()) + "'" +
                                                 ");";
                        sqlite_cmd.ExecuteNonQuery();
                    }

                    //foreach (AcunetixReference reference in acunetixReferenceList)
                    //{
                    //    //// add affected items
                    //    sqlite_cmd.CommandText = "INSERT INTO AcunetixReferenceList (" +
                    //                             "id," +
                    //                             "database," +
                    //                             "url" +
                    //                             ")" +
                    //                             "VALUES (" +
                    //                             "'" + maxId + "'," +
                    //                             "'" + addSlash(reference.getDatabase()) + "'," +
                    //                             "'" + addSlash(reference.getUrl()) + "'" +
                    //                             ");";
                    //    sqlite_cmd.ExecuteNonQuery();
                    //}
                }
            }

        }

        /*
         * This is the storeRecord method.
         * It is used to store the Record to the file path from this Databaser path.
         */
        public void storeRecord()
        {
            //store raw record

            storeRawRecord();

            if (Program.state.amendmentDatabaser == null)
                Program.state.amendmentDatabaser = new PermanentDatabaser();
            //load Amendment and automatically amend the description/recommendation
            List<Amendment> amendmentList = Program.state.amendmentDatabaser.getAmendmentList();
            List<DataEntry> allEntries = record.getWholeEntries();
            if (amendmentList != null)
                foreach (Amendment amendment in amendmentList)
                    foreach (DataEntry entry in allEntries)
                    {
                        // entryType + plguninName
                        string tempId = entry.getEntryTypeString() + "_" + entry.getPluginName();
                        if (tempId == amendment.getId()) {
                            if (entry.getDescription() == amendment.getOriginalDescription())
                                entry.setDescription(amendment.getEditedDescription());
                            if (entry.getRecommendation() == amendment.getOriginalRecommendation())
                                entry.setRecommendation(amendment.getEditedRecommendation());
                            if (entry.getReferenceLink() == amendment.getOriginalReferenceLink())
                                entry.setReferenceLink(amendment.getEditedReferenceLink());
                        }
                    }

            
            #region // Create the Database File
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
                                     "ipList VARCHAR(2000) NOT NULL," +
                                     "description VARCHAR(3000) NOT NULL," +
                                     "impact VARCHAR(3000) NOT NULL," +
                                     "riskfactor VARCHAR(10) NOT NULL," +
                                     "recommendation VARCHAR(3000) NOT NULL," +
                                     "bidlist VARCHAR(2000) NOT NULL," +
                                     "cvelist VARCHAR(2000) NOT NULL," +
                                     "osvdblist VARCHAR(2000) NOT NULL," +
                                     "referenceLink VARCHAR(200)," +
                                     "revisionNo INTEGER," +
                                     "entryType VARCHAR(10) NOT NULL," +
                                     "louise VARCHAR(500)," +
                                     "pluginVersion VARCHAR(3000)" +
                                     ");";

            //// Command
            //sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS NessusRecord(" +
            //                         "id INTEGER PRIMARY KEY," +
            //                         "originalId INTEGER," +
            //                         "pluginName VARCHAR(500) NOT NULL," +
            //                         "ipList VARCHAR(2000) NOT NULL," +
            //                         "description VARCHAR(3000) NOT NULL," +
            //                         "impact VARCHAR(3000) NOT NULL," +
            //                         "riskfactor VARCHAR(10) NOT NULL," +
            //                         "recommendation VARCHAR(3000) NOT NULL," +
            //                         "bidlist VARCHAR(2000) NOT NULL," +
            //                         "cvelist VARCHAR(2000) NOT NULL," +
            //                         "osvdblist VARCHAR(2000) NOT NULL," +
            //                         "referenceLink VARCHAR(200)," +
            //                         "revisionNo INTEGER," +
            //                         "entryType VARCHAR(10) NOT NULL" +
            //                         ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS IPHostTable(" +
                                     "ip VARCHAR(1000) PRIMARY KEY," +
                                     "hostName VARCHAR(10000)" +
                                     ");";


            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS OpenPortTable(" +
                                     "ip VARCHAR(1000)," +
                                     "type VARCHAR(100)," +
                                     "nmapFilteredPort VARCHAR(100000)," +
                                     "nmapOpenPort VARCHAR(100000)," +
                                     "nessusOpenPort VARCHAR(100000)," +
                                     "resultOpenPort VARCHAR(100000)" +
                                     ");";


            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS NessusFinding(" +
                                     "fid INTEGER PRIMARY KEY," +
                                     "pluginName VARCHAR(500) NOT NULL," +
                                     "description VARCHAR(3000) NOT NULL," +
                                     "impact VARCHAR(3000) NOT NULL," +
                                     "riskfactor VARCHAR(10) NOT NULL," +
                                     "recommendation VARCHAR(3000) NOT NULL," +
                                     "plugin_version VARCHAR(2000) NOT NULL," +
                                     "referenceLink VARCHAR(200)," +
                                     "entryType VARCHAR(10) NOT NULL," +
                                     "revisionNo INTEGER," +
                                     "originalId INTEGER," +
                                     "pluginID" +
                                     ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FindingDetail(" +
                                     "id INTEGER PRIMARY KEY," +
                                     "fid INTEGER," +
                                     "host VARCHAR(2000) NOT NULL," +
                                     "port_with_protocol VARCHAR(3000) NOT NULL," +
                                     "plugin_output VARCHAR(1000000) NOT NULL," +
                                     "undo_marker VARCHAR(100)" +
                                     ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            // Command
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS references1(" +
                                     "rid INTEGER PRIMARY KEY," +
                                     "type VARCHAR(100) NOT NULL," +
                                     "name VARCHAR(300) NOT NULL" +
                                     ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS FindingReferences(" +
                         "id INTEGER PRIMARY KEY," +
                         "fid INTEGER," +
                         "rid INTEGER," +
                         "undo_marker VARCHAR(100)" +
                         ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS ProjectNameAndRemark(" +
                                     "id INTEGER PRIMARY KEY," +
                                     "ProjectName VARCHAR(1000)," +
                                     "Remark VARCHAR(50000)" +
                                     ");";

            // Execute non query command
            sqlite_cmd.ExecuteNonQuery();

            #endregion


            formMessageWithProgressBar = new FormMessageWithProgressBar("Creating NessusFinding Database...", record.getCount());
            formMessageWithProgressBar.Show();


            // insert the findings to the database file
            //SQLiteTransaction transaction = sqlite_conn.BeginTransaction();
            //@@@@@insertRecordToDatabase(record.getHighRisk());
            //@@@@@insertRecordToDatabase(record.getMediumRisk());
            //@@@@@insertRecordToDatabase(record.getLowRisk());
            //@@@@@insertRecordToDatabase(record.getNoneRisk());
            //@@@@@insertRecordToDatabase(record.getOpenPort());


            // insert the findings to the database file(NessusFinding table)

            insertNessusFindingToDatabase(record.getHighRisk());
            insertNessusFindingToDatabase(record.getMediumRisk());
            insertNessusFindingToDatabase(record.getLowRisk());
            insertNessusFindingToDatabase(record.getNoneRisk());
            insertNessusFindingToDatabase(record.getOpenPort());

            formMessageWithProgressBar.Close();


            formMessageWithProgressBar = new FormMessageWithProgressBar("Creating FindingDetail Database...", record.getCount());
            formMessageWithProgressBar.Show();
            
            //// insert the findings to the database file(FindingDetail table)
           
            insertFindingDetailToDatabase(record.getHighRisk());
            insertFindingDetailToDatabase(record.getMediumRisk());
            insertFindingDetailToDatabase(record.getLowRisk());
            insertFindingDetailToDatabase(record.getNoneRisk());
            insertFindingDetailToDatabase(record.getOpenPort());
            formMessageWithProgressBar.Close();

            formMessageWithProgressBar = new FormMessageWithProgressBar("Creating Reference And FindingReference Database...", record.getCount());
            formMessageWithProgressBar.Show();
            insertReferenceAndFindingReferenceToDatabase(record.getHighRisk());
            insertReferenceAndFindingReferenceToDatabase(record.getMediumRisk());
            insertReferenceAndFindingReferenceToDatabase(record.getLowRisk());
            insertReferenceAndFindingReferenceToDatabase(record.getNoneRisk());
            insertReferenceAndFindingReferenceToDatabase(record.getOpenPort());

            insertProjectNameAndRemark();
            formMessageWithProgressBar.Close();

            formMessageWithProgressBar = new FormMessageWithProgressBar("Creating IP Host Table Database...", record.getRiskStats().getRiskStats().Count());
            formMessageWithProgressBar.Show();
            storeIPHostTable(record.getRiskStats().getRiskStats());
            formMessageWithProgressBar.Close();

            formMessageWithProgressBar = new FormMessageWithProgressBar("Creating Open Port Table Database...", record.getOpenPortTableItem().Count());
            formMessageWithProgressBar.Show();
            storeOpenPortTable(record.getOpenPortTableItem());
            formMessageWithProgressBar.Close();
            // transaction.Commit();
            
            

            // Close connection
            sqlite_conn.Close();

            Program.state.panelRecordEdit_isSaveDatabase = true;
        }

        public void storeOpenPortTable(Dictionary<String, ReportGenerator.Record.Record.OpenPortTableItemData> openPortTableItem)
        {
            int transactioncheck = 0;
            SQLiteTransaction transaction = sqlite_conn.BeginTransaction();


            foreach (String ip in openPortTableItem.Keys)
            {
                ReportGenerator.Record.Record.OpenPortTableItemData data = openPortTableItem[ip];
                Dictionary<PortType, List<String>> nessusOpenPortDic = data.getNessusOpenPortDic();
                Dictionary<PortType, List<String>> nmapFilteredPortDic = data.getNmapFilteredPortDic();
                Dictionary<PortType, List<String>> nmapOpenPortDic = data.getNmapOpenPortDic();
                Dictionary<PortType, List<String>> resultOpenPortDic = data.getResultOpenPortDic();

                for (int i = 0; i < 3; i++)
                {
                    String typeString = "";
                    String nmapFilteredPortString = "";
                    String nmapOpenPortString = "";
                    String nessusOpenPortString = "";
                    String resultOpenPortString = "";

                    if ((PortType)i == (PortType.TCP))
                        typeString = "tcp";
                    else if ((PortType)i == (PortType.ICMP))
                        typeString = "icmp";
                    else if ((PortType)i == (PortType.UDP))
                        typeString = "udp";

                    foreach (String port in nessusOpenPortDic[(PortType)i])
                    {
                        nessusOpenPortString += port + " ";
                    }
                    if (!String.IsNullOrEmpty(nessusOpenPortString))
                        nessusOpenPortString = nessusOpenPortString.Substring(0, nessusOpenPortString.Length - 1);

                    foreach (String port in nmapFilteredPortDic[(PortType)i])
                    {
                        nmapFilteredPortString += port + " ";
                    }
                    if (!String.IsNullOrEmpty(nmapFilteredPortString))
                        nmapFilteredPortString = nmapFilteredPortString.Substring(0, nmapFilteredPortString.Length - 1);

                    foreach (String port in nmapOpenPortDic[(PortType)i])
                    {
                        nmapOpenPortString += port + " ";
                    }
                    if (!String.IsNullOrEmpty(nmapOpenPortString))
                        nmapOpenPortString = nmapOpenPortString.Substring(0, nmapOpenPortString.Length - 1);

                    foreach (String port in resultOpenPortDic[(PortType)i])
                    {
                        resultOpenPortString += port + " ";
                    }
                    if (!String.IsNullOrEmpty(resultOpenPortString))
                        resultOpenPortString = resultOpenPortString.Substring(0, resultOpenPortString.Length - 1);

                    sqlite_cmd.CommandText = "INSERT INTO OpenPortTable(ip,type,nmapFilteredPort,nmapOpenPort,nessusOpenPort,resultOpenPort) " +
                                             "VALUES (" +
                                             "'" + ip + "'," +
                                             "'" + typeString + "'," +
                                             "'" + nmapFilteredPortString + "'," +
                                             "'" + nmapOpenPortString + "'," +
                                             "'" + nessusOpenPortString + "'," +
                                             "'" + resultOpenPortString + "' )"; 


                    // execute the command
                    sqlite_cmd.ExecuteNonQuery();
                }
                
                formMessageWithProgressBar.setFinishedNumber(formMessageWithProgressBar.getFinishedNumber() + 1);
                Application.DoEvents();
                if (transactioncheck++ == 9000)
                {
                    transaction.Commit();
                    transactioncheck = 0;
                    transaction = sqlite_conn.BeginTransaction();
                }

            }
            transaction.Commit();

        }

        public void storeIPHostTable(Dictionary<String, Dictionary<RiskFactor, int>> riskStats) {
            //sorting
            List<String> tempList = new List<string>(); 
            foreach (String ip in riskStats.Keys)
            {
                tempList.Add(ip);
            }
            for (int i =0;i< tempList.Count()-1;i++)
                for (int j = i+1; j<tempList.Count();j++)
                {
                    Int64 intI= 0;
                    Int64 intJ = 0;
                    try
                    {
                        String[] stringListI = tempList[i].Split('.');
                        if (stringListI.Count() ==4)
                            intI = int.Parse(stringListI[0]) * 255 * 255 * 255 +
                                   int.Parse(stringListI[1]) * 255 * 255 +
                                   int.Parse(stringListI[2]) * 255 + 
                                   int.Parse(stringListI[3]);
                        String[] stringListJ = tempList[j].Split('.');
                        if (stringListJ.Count() == 4)
                            intJ = int.Parse(stringListJ[0]) * 255 * 255 * 255 +
                                   int.Parse(stringListJ[1]) * 255 * 255 +
                                   int.Parse(stringListJ[2]) * 255 +
                                   int.Parse(stringListJ[3]);
                    } 
                    catch(Exception e)
                    {}

                    if (intI > intJ || (intI == intJ && tempList[i].CompareTo(tempList[j]) >0) )
                    {
                        String tempString = tempList[i];
                        tempList[i] = tempList[j];
                        tempList[j] = tempString;
                    }

                }

            int transactioncheck = 0;
            SQLiteTransaction transaction = sqlite_conn.BeginTransaction();

            foreach(String ip in tempList)
            {
                sqlite_cmd.CommandText = "INSERT INTO IPHostTable(ip,hostName) VALUES (" +
                                         "'" + ip + "'," +
                                         "'' )"; //hostName
                    

                // execute the command
                sqlite_cmd.ExecuteNonQuery();

                if (transactioncheck++ == 9000)
                {
                    transaction.Commit();
                    transactioncheck = 0;
                    transaction = sqlite_conn.BeginTransaction();
                }

                formMessageWithProgressBar.setFinishedNumber(formMessageWithProgressBar.getFinishedNumber() + 1);
                Application.DoEvents();


            }
            transaction.Commit();



        }

        public void updateIPHostTable(Dictionary<String, String> ipHostName)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            foreach (String ip in ipHostName.Keys)
            {
                sqlite_cmd.CommandText = "UPDATE IPHostTable SET"
                                         + " hostName ='" + ipHostName[ip]
                                         + "' WHERE ip= '" + ip + "' ;";
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_conn.Close();

        }
        #region // getBindingSource Method

        public BindingSource getBindingSourceOpenPortTable(string targetCol = null, string keyword = null)
        {
            string query = "SELECT* FROM OpenPortTable";
            if (targetCol != null && keyword != null)
                query += " WHERE " + targetCol + " LIKE '%" + keyword + "%'";
            return getBindingSource(query);
        }
        
        public BindingSource getBindingSourceIPHostTable(string targetCol = null, string keyword = null)
        {
            string query = "SELECT* FROM IPHostTable";
            if (targetCol != null && keyword != null)
                query += " WHERE " + targetCol + " LIKE '%" + keyword + "%'";
            return getBindingSource(query);
        }

        public BindingSource getBindingSourceRawNmap(string targetCol=null, string keyword=null) {
            string query = "SELECT* FROM NmapRecordRaw";
            if (targetCol != null && keyword != null)
                query += " WHERE " + targetCol + " LIKE '%" + keyword + "%'";
            return getBindingSource(query);
        }
        public BindingSource getBindingSourceRawMBSA(string targetCol = null, string keyword = null)
        {
            string query = "SELECT* FROM MBSARecordRaw";
            if (targetCol != null && keyword != null)
                query += " WHERE " + targetCol + " LIKE '%" + keyword + "%'";
            return getBindingSource(query);
        }


        public BindingSource getBindingSourceRawNessus(string targetCol = null, string keyword = null)
        {
            string query = "SELECT* FROM NessusRecordRaw";
            if (targetCol != null && keyword != null)
                query += " WHERE " + targetCol + " LIKE '%" + keyword  + "%'";
            return getBindingSource(query);
        }

        public BindingSource getBindingSourceRawAcunetix(string targetCol = null, string keyword = null)
        {
            string query = "SELECT AcunetixRecordRawAffectedItem.id," +
                           "AcunetixRecordRaw.pluginName,"+
                           "AcunetixRecordRaw.ipList," +
                           "AcunetixRecordRaw.description," +
                           "AcunetixRecordRaw.impact," +
                           "AcunetixRecordRaw.riskfactor," +
                           "AcunetixRecordRaw.recommendation," +
                           "AcunetixRecordRaw.fileName," +
                           "AcunetixRecordRaw.subDomain," +
                           "AcunetixRecordRawAffectedItem.affectedItemSubDirectory," +
                           "AcunetixRecordRawAffectedItem.department," +
                           "AcunetixRecordRawAffectedItem.affectedItem," +
                           "AcunetixRecordRawAffectedItem.affectedItemLink," +
                           "AcunetixRecordRawAffectedItem.affectedItemDetail," +
                           "AcunetixRecordRawAffectedItem.affectedItemRequest," +
                           "AcunetixRecordRawAffectedItem.affectedItemResponse," +
                           "AcunetixRecordRaw.moduleName," +
                           "AcunetixRecordRaw.isFalsePositive," +
                           "AcunetixRecordRaw.AOP_SourceFile," +
                           "AcunetixRecordRaw.AOP_SourceLine," +
                           "AcunetixRecordRaw.AOP_Additional," +
                           "AcunetixRecordRaw.detailedInformation," +
                           "AcunetixRecordRaw.acunetixType," +
                           "AcunetixRecordRaw.reference" +
                           " FROM AcunetixRecordRaw LEFT JOIN AcunetixRecordRawAffectedItem ON AcunetixRecordRaw.id = AcunetixRecordRawAffectedItem.id";
            if (targetCol != null && keyword != null)
                query += " WHERE " + targetCol + " LIKE '%" + keyword + "%'";
            return getBindingSource(query);
        }


        //not used
        public BindingSource getBindingSourceEditedRecord()
        {
            string query = "SELECT * " +
                           "FROM Record AS R " +
                           "WHERE (R.revisionNo = (SELECT MAX(R2.revisionNo) " +
                           "FROM Record AS R2 " +
                           "WHERE R.originalId = R2.originalId)" +
                           ") OR " +
                           "R.revisionNo = 1;";
            return getBindingSource(query);
        }

        private BindingSource getBindingSource(string query)
        {
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
            try
            {
                dataTable.Load(sqlite_datareader);
            }
            catch (System.Data.ConstraintException e)
            {
                DataRow[] test = dataTable.GetErrors();
                Console.WriteLine(e.Message);
            }
            foreach (DataColumn col in dataTable.Columns)
                col.AllowDBNull = true;
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dataTable;
            sqlite_conn.Close();
            return bSource;
        }

        #endregion
        /*
         * This the the getter method.
         * return the Record form the file path from this Databaser path.
         */
        //Table 'Record' is created at this stage
        //public Record.Record getRecord()
        //{
        //    // Create
        //    sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

        //    // Open
        //    sqlite_conn.Open();

        //    // Create command
        //    sqlite_cmd = sqlite_conn.CreateCommand();

        //    Record.Record tempRecord = new Record.Record();
        //    sqlite_cmd.CommandText = "SELECT * " +
        //                             "FROM Record AS R " +
        //                             "WHERE (R.revisionNo = (SELECT MAX(R2.revisionNo) " +
        //                                                    "FROM Record AS R2 " +
        //                                                    "WHERE R.originalId = R2.originalId)" +
        //                                   ") OR " +
        //                             "R.revisionNo = 1;";

        //    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

        //    // read through the results
        //    while (sqlite_datareader.Read())
        //    {
        //        #region // string cve/bid/osvdb to cve/bid/osvdb List
        //        List<String> cveList = sqlite_datareader["cvelist"].ToString().Split(',').ToList<String>();
        //        List<String> bidList = sqlite_datareader["bidlist"].ToString().Split(',').ToList<String>();
        //        List<String> osvdbList = sqlite_datareader["osvdblist"].ToString().Split(',').ToList<String>();

        //        for (int i = 0; i < cveList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in cveList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            cveList[i] = tempString;
        //        }

        //        for (int i = 0; i < bidList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in bidList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            bidList[i] = tempString;
        //        }

        //        for (int i = 0; i < osvdbList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in osvdbList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            osvdbList[i] = tempString;
        //        }
        //        #endregion

        //        tempRecord.guiAddEntry(new GuiDataEntry(sqlite_datareader["pluginName"].ToString(),
        //                                                sqlite_datareader["ipList"].ToString(),
        //                                                sqlite_datareader["description"].ToString(),
        //                                                sqlite_datareader["impact"].ToString(),
        //                                                RiskFactorFunction.getEnum(sqlite_datareader["riskfactor"].ToString()),
        //                                                sqlite_datareader["recommendation"].ToString(),
        //                                                cveList,
        //                                                bidList,
        //                                                osvdbList,
        //                                                sqlite_datareader["referenceLink"].ToString(),
        //                                                sqlite_datareader["entryType"].ToString(),
        //                                                sqlite_datareader["pluginVersion"].ToString()));           //@@@@@
                
            
        //    }

        //    // Close connection
        //    sqlite_conn.Close();
        //    return tempRecord;
        //}

        /*
 * This the the getter method.
 * return the Record form the file path from this Databaser path.
 */

        public Record.Record getRecord()
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            Record.Record tempRecord = new Record.Record();
            List<String> cveListFromreferences = new List<string>();
            List<String> bidListFromreferences = new List<string>();
            List<String> osvdbListFromreferneces = new List<string>();
            List<String> iplistFromFindingDetail = new List<string>();
            List<String> portandprotocolFromFindingDetail = new List<string>();
            String iplist = "";


            sqlite_cmd.CommandText = "SELECT * " +
                         "FROM references1 AS R " +
                         "WHERE (R.rid IN (SELECT rid FROM FindingReferences AS F " +
                                          "WHERE F.fid IN (SELECT fid " +
                                     "FROM NessusFinding AS N " +
                                     "WHERE (N.revisionNo = (SELECT MAX(N2.revisionNo) " +
                                                            "FROM NessusFinding AS N2 " +
                                                            "WHERE N.originalId = N2.originalId)" +
                                           ") OR " +
                                     "N.revisionNo = 1)" +
                                      "));";


            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            // read through the results
            while (sqlite_datareader.Read())
            {
                #region // string cve/bid/osvdb to cve/bid/osvdb List
                //List<String> cveList = sqlite_datareader["cvelist"].ToString().Split(',').ToList<String>();
                //List<String> bidList = sqlite_datareader["bidlist"].ToString().Split(',').ToList<String>();
                //List<String> osvdbList = sqlite_datareader["osvdblist"].ToString().Split(',').ToList<String>();
                                String tempString = "";
                String tempreferencename=sqlite_datareader["name"].ToString();
                foreach (char c in tempreferencename)
                    {
                        if (c != ' ')
                        {
                            tempString += c;
                        }
                    }
                    tempreferencename = tempString;

                switch(sqlite_datareader["type"].ToString())
                {
                    case "BID":
                        {
                            bidListFromreferences.Add(tempreferencename);
                            break;

                        }
                    case "CVE":
                        {
                            cveListFromreferences.Add(tempreferencename);
                            break;

                        }
                    case "OSVDB":
                        {
                            osvdbListFromreferneces.Add(tempreferencename);
                            break;

                        }
                    default:
                        {
                           
                            break;

                        }
                }
                
                #endregion
            }
            sqlite_datareader.Close();
            sqlite_conn.Close();

                

                        // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * " +
                                     "FROM FindingDetail AS F " +
                                     "WHERE (F.fid IN (SELECT fid " +
                                     "FROM NessusFinding AS N " +
                                     "WHERE (N.revisionNo = (SELECT MAX(N2.revisionNo) " +
                                                            "FROM NessusFinding AS N2 " +
                                                            "WHERE N.originalId = N2.originalId)" +
                                           ") OR " +
                                     "N.revisionNo = 1));";


            #region  // To string iplist

            SQLiteDataReader sqlite_datareader1 = sqlite_cmd.ExecuteReader();


            while (sqlite_datareader1.Read())
            {
                
                if (iplistFromFindingDetail.Contains(sqlite_datareader1["host"].ToString()))
                {
                    portandprotocolFromFindingDetail[iplistFromFindingDetail.IndexOf(sqlite_datareader1["host"].ToString())] += (sqlite_datareader1["port_with_protocol"].ToString() );
                }
                else
                {
                    iplistFromFindingDetail.Add(sqlite_datareader1["host"].ToString());
                    portandprotocolFromFindingDetail.Add(sqlite_datareader1["port_with_protocol"].ToString());
 
                }
 
            }


            for (int n = 0; n < iplistFromFindingDetail.Count; n++)
            {
                
                iplist += (iplistFromFindingDetail[n] + " "+ portandprotocolFromFindingDetail[n]+", ");
            }
            if (!String.IsNullOrEmpty(iplist))
            {
                iplist = iplist.Substring(0, iplist.Length - 2);

            }

            sqlite_datareader1.Close();
            sqlite_conn.Close();
            #endregion


            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();



            sqlite_cmd.CommandText = "SELECT * " +
                                     "FROM NessusFinding AS N " +
                                      "WHERE (N.revisionNo = (SELECT MAX(N2.revisionNo) " +
                                                              "FROM NessusFinding AS N2 " +
                                                               "WHERE N.originalId = N2.originalId)" +
                                              ") OR " +
                                              "N.revisionNo = 1;";

            SQLiteDataReader sqlite_datareader2 = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader2.Read())
            {
                                
                tempRecord.guiAddEntry(new GuiDataEntry(sqlite_datareader2["pluginName"].ToString(),
                                                        iplist,
                                                        sqlite_datareader2["description"].ToString(),
                                                        sqlite_datareader2["impact"].ToString(),
                                                        RiskFactorFunction.getEnum(sqlite_datareader2["riskfactor"].ToString()),
                                                        sqlite_datareader2["recommendation"].ToString(),
                                                        cveListFromreferences,
                                                        bidListFromreferences,
                                                        osvdbListFromreferneces,
                                                        sqlite_datareader2["referenceLink"].ToString(),
                                                        sqlite_datareader2["entryType"].ToString(),
                                                        sqlite_datareader2["plugin_version"].ToString(),
                                                        sqlite_datareader2["pluginID"].ToString()));           //@@@@@


            }
            sqlite_datareader2.Close();

            // Close connection
            sqlite_conn.Close();


            return tempRecord;
        }


        /*
         * Swap position of record row
         */
        public void swapRecord(int dbid1,int dbid2)
        {
            DataEntry entry1 = getEntryFromDatabaseId(dbid1);
            DataEntry entry2 = getEntryFromDatabaseId(dbid2);
            //@@@@@guiUpdateUpdateRecordToDatabase(entry1, dbid2);
            //@@@@@guiUpdateUpdateRecordToDatabase(entry2, dbid1);
            guiUpdateUpdateNessusFindingToDatabase(entry1, dbid2);
            guiUpdateUpdateNessusFindingToDatabase(entry2, dbid1);
            guiUpdateswapFindingDetailToDatabase(dbid1, dbid2);
            guiUpdateswapFindingReferencesToDatabase(dbid1, dbid2);

        }

        ///*
        // * This is the getter method.
        // * return the DataEntry from the file according to the databaseId
        // * Load from RECORD database.
        // */
        //public DataEntry getEntryFromDatabaseId(int databaseId)
        //{
        //    // Create
        //    sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

        //    // Open
        //    sqlite_conn.Open();

        //    // Create command
        //    sqlite_cmd = sqlite_conn.CreateCommand();

        //    sqlite_cmd.CommandText = "SELECT * " +
        //                             "FROM Record " +
        //                             "WHERE id=" +
        //                             databaseId.ToString() +
        //                             ";";

        //    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

        //    DataEntry tempEntry = null;

        //    // read through the results
        //    while (sqlite_datareader.Read())
        //    {
        //        #region  // string cve/bid/osvdb to cve/bid/osvdb List

        //        List<String> cveList = sqlite_datareader["cvelist"].ToString().Split(',').ToList<String>();
        //        List<String> bidList = sqlite_datareader["bidlist"].ToString().Split(',').ToList<String>();
        //        List<String> osvdbList = sqlite_datareader["osvdblist"].ToString().Split(',').ToList<String>();

        //        for (int i = 0; i < cveList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in cveList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            cveList[i] = tempString;
        //        }

        //        for (int i = 0; i < bidList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in bidList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            bidList[i] = tempString;
        //        }

        //        for (int i = 0; i < osvdbList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in osvdbList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            osvdbList[i] = tempString;
        //        }
        //        #endregion

        //        tempEntry = new GuiDataEntry(sqlite_datareader["pluginName"].ToString(),
        //                                     sqlite_datareader["ipList"].ToString(),
        //                                     sqlite_datareader["description"].ToString(),
        //                                     sqlite_datareader["impact"].ToString(),
        //                                     RiskFactorFunction.getEnum(sqlite_datareader["riskfactor"].ToString()),
        //                                     sqlite_datareader["recommendation"].ToString(),
        //                                     cveList,
        //                                     bidList,
        //                                     osvdbList,
        //                                     sqlite_datareader["referenceLink"].ToString(),
        //                                     sqlite_datareader["entryType"].ToString(),
        //                                     sqlite_datareader["pluginVersion"].ToString());  //@@@@@

        //    }
        //    sqlite_datareader.Close();

        //    // Close connection
        //    sqlite_conn.Close();

        //    return tempEntry;
        //}

        /*
         * This is the getter method.
         * return the DataEntry from the file according to the databaseId
         * Load from the four database--NessusFinding,Finding Detail,reference1,FindingReferences.
         */
        public DataEntry getEntryFromDatabaseId(int databaseId)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * " +
                                     "FROM references1 AS R " +
                                     "WHERE (R.rid IN (SELECT rid FROM FindingReferences AS F " +
                                                      "WHERE F.fid = '" + databaseId + "'));";


            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            DataEntry tempEntry = null;
            List<String> cveListFromreferences =new List<string>();
            List<String> bidListFromreferences=new List<string>();
            List<String> osvdbListFromreferneces=new List<string>();
            List<String> iplistFromFindingDetail = new List<string>();
            List<String> portandprotocolFromFindingDetail = new List<string>();
            String iplist="";
            // read through the results
            while (sqlite_datareader.Read())
            {
                #region  // string cve/bid/osvdb to cve/bid/osvdb List

              
                //List<String> cveList = sqlite_datareader["cvelist"].ToString().Split(',').ToList<String>();
                //List<String> bidList = sqlite_datareader["bidlist"].ToString().Split(',').ToList<String>();
                //List<String> osvdbList = sqlite_datareader["osvdblist"].ToString().Split(',').ToList<String>();
                
                //String tempString = "";
                String tempreferencename=sqlite_datareader["name"].ToString();
                //foreach (char c in tempreferencename)
                //    {
                //        if (c != ' ')
                //        {
                //            tempString += c;
                //        }
                //    }
                tempreferencename = tempreferencename.Replace(" ", "");
                    //tempreferencename = tempString;

                switch(sqlite_datareader["type"].ToString())
                {
                    case "BID":
                        {
                            bidListFromreferences.Add(tempreferencename);
                            break;

                        }
                    case "CVE":
                        {
                            cveListFromreferences.Add(tempreferencename);
                            break;

                        }
                    case "OSVDB":
                        {
                            osvdbListFromreferneces.Add(tempreferencename);
                            break;

                        }
                    default:
                        {
                           
                            break;

                        }
                }
                
                #endregion
            }
            sqlite_datareader.Close();
            sqlite_conn.Close();






            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * " +
                                     "FROM FindingDetail AS F " +
                                     "WHERE (F.fid = '" + databaseId + "');";


            #region  // To string iplist

            SQLiteDataReader sqlite_datareader1 = sqlite_cmd.ExecuteReader();


            while (sqlite_datareader1.Read())
            {
                
                if (iplistFromFindingDetail.Contains(sqlite_datareader1["host"].ToString()))
                {
                    portandprotocolFromFindingDetail[iplistFromFindingDetail.IndexOf(sqlite_datareader1["host"].ToString())] +=   sqlite_datareader1["port_with_protocol"].ToString();
                }
                else
                {
                    iplistFromFindingDetail.Add(sqlite_datareader1["host"].ToString());
                    portandprotocolFromFindingDetail.Add(sqlite_datareader1["port_with_protocol"].ToString());
 
                }
 
            }


            for (int n = 0; n < iplistFromFindingDetail.Count; n++)
            {
                
                iplist += (iplistFromFindingDetail[n] + " " +portandprotocolFromFindingDetail[n]+" , ");
            }
            if (!String.IsNullOrEmpty(iplist))
            {
                iplist = iplist.Substring(0, iplist.Length - 2);

            }

            sqlite_datareader1.Close();
            sqlite_conn.Close();
            #endregion



            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            

            sqlite_cmd.CommandText = "SELECT * " +
                         "FROM NessusFinding " +
                         "WHERE (fid = '" + databaseId + "');";
            SQLiteDataReader sqlite_datareader2 = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader2.Read())
            {
                tempEntry = new GuiDataEntry(sqlite_datareader2["pluginName"].ToString(),
                                             iplist,
                                             sqlite_datareader2["description"].ToString(),
                                             sqlite_datareader2["impact"].ToString(),
                                             RiskFactorFunction.getEnum(sqlite_datareader2["riskfactor"].ToString()),
                                             sqlite_datareader2["recommendation"].ToString(),
                                             cveListFromreferences,
                                             bidListFromreferences,
                                             osvdbListFromreferneces,
                                             sqlite_datareader2["referenceLink"].ToString(),
                                             sqlite_datareader2["entryType"].ToString(),
                                             sqlite_datareader2["plugin_version"].ToString(),
                                             sqlite_datareader2["pluginID"].ToString());  //@@@@@
            }

            
            sqlite_datareader2.Close();

            // Close connection
            sqlite_conn.Close();

            return tempEntry;
        }



        /*
         * This is the guiInsertRecordToDatabase method.
         */
        //revision number assume to be 1
        //public void guiInsertRecordToDatabase(DataEntry entry,int id)
        //{
        //    // Create
        //    sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

        //    // Open
        //    sqlite_conn.Open();

        //    // Create command
        //    sqlite_cmd = sqlite_conn.CreateCommand();

        //    String pluginName = addSlash(entry.getPluginName());
        //    String ipList = addSlash(entry.getIp());
        //    String description = addSlash(entry.getDescription());
        //    String impact = addSlash(entry.getImpact());
        //    String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
        //    String recommendation = addSlash(entry.getRecommendation());
        //    String bidList = addSlash(entry.getBid());
        //    String cveList = addSlash(entry.getCve());
        //    String osvdbList = addSlash(entry.getOsvdb());
        //    String referenceLink = addSlash(entry.getReferenceLink());
        //    String entryType = addSlash(entry.getEntryTypeString());

        //    String pluginversion = addSlash(entry.getpluginversion());

        //    //sqlite_cmd.CommandText = "SELECT MAX(id) " +
        //    //                         "FROM Record";

        //    //SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
        //    //int databaseId = -1;
        //    //while (sqlite_datareader.Read())
        //    //{
        //    //    if (databaseId < int.Parse(sqlite_datareader["MAX(id)"].ToString()))
        //    //    {
        //    //        databaseId = int.Parse(sqlite_datareader["MAX(id)"].ToString());
        //    //    }
        //    //}
        //    //sqlite_datareader.Close();
        //    //databaseId++;

        //    sqlite_cmd.CommandText = "INSERT INTO Record (" +
        //                             "id," +
        //                             "originalId," +
        //                             "pluginName," +
        //                             "ipList," +
        //                             "description," +
        //                             "impact," +
        //                             "riskfactor," +
        //                             "recommendation," +
        //                             "bidlist," +
        //                             "cvelist," +
        //                             "osvdblist," +
        //                             "referenceLink," +
        //                             "revisionNo," +
        //                             "entryType," +
        //                             "louise," +
        //                             "pluginVersion" +
        //                             ")" +
        //                             "VALUES (" +
        //                             "'" + id + "'," +								// pluginId (null means auto increment)
        //                             "'" + originalId + "'," +				// originalId
        //                             "'" + pluginName + "'," +				// pluginName
        //                             "'" + ipList + "'," +					// ipList
        //                             "'" + description + "'," +				// description
        //                             "'" + impact + "'," +					// impact
        //                             "'" + riskFactor + "'," +				// riskfactor
        //                             "'" + recommendation + "'," +			// recommendation
        //                             "'" + bidList + "'," +					// bidlist
        //                             "'" + cveList + "'," +					// cvelist
        //                             "'" + osvdbList + "'," +				// osvdblist
        //                             "'" + referenceLink + "'," +			// referenceLink
        //                             "'1'," +								// revisionNo
        //                             "'" + entryType + "'," +				// entryType
        //                             "'" + louise + "',"+
        //                             "'" + pluginversion + "'" +
        //                             ");";
        //    originalId++;

        //    // Execute the command
        //    sqlite_cmd.ExecuteNonQuery();

        //    // Close connection
        //    sqlite_conn.Close();

        //}

        ///*
        // * This is the guiInsertMergeRecordToDatabase method.
        // * return the databaseId after storing the given entry to the database file.
        // */
        //public int guiInsertMergeRecordToDatabase(DataEntry entry)
        //{
        //    // Create
        //    sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

        //    // Open
        //    sqlite_conn.Open();

        //    // Create command
        //    sqlite_cmd = sqlite_conn.CreateCommand();

        //    String pluginName = addSlash(entry.getPluginName());
        //    String ipList = addSlash(entry.getIp());
        //    String description = addSlash(entry.getDescription());
        //    String impact = addSlash(entry.getImpact());
        //    String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
        //    String recommendation = addSlash(entry.getRecommendation());
        //    String bidList = addSlash(entry.getBid());
        //    String cveList = addSlash(entry.getCve());
        //    String osvdbList = addSlash(entry.getOsvdb());
        //    String referenceLink = addSlash(entry.getReferenceLink());
        //    String entryType = addSlash(entry.getEntryTypeString());

        //    sqlite_cmd.CommandText = "SELECT MAX(id) " +
        //                             "FROM Record";

        //    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
        //    int databaseId = -1;
        //    while (sqlite_datareader.Read())
        //    {
        //        if (databaseId < int.Parse(sqlite_datareader["MAX(id)"].ToString()))
        //        {
        //            databaseId = int.Parse(sqlite_datareader["MAX(id)"].ToString());
        //        }
        //    }
        //    sqlite_datareader.Close();
        //    databaseId++;

        //    sqlite_cmd.CommandText = "INSERT INTO Record (" +
        //                             "id," +
        //                             "originalId," +
        //                             "pluginName," +
        //                             "ipList," +
        //                             "description," +
        //                             "impact," +
        //                             "riskfactor," +
        //                             "recommendation," +
        //                             "bidlist," +
        //                             "cvelist," +
        //                             "osvdblist," +
        //                             "referenceLink," +
        //                             "revisionNo," +
        //                             "entryType" +
        //                             ")" +
        //                             "VALUES (" +
        //                             "NULL," +								// pluginId (null means auto increment)
        //                             "'" + originalId +  "'," +				// originalId
        //                             "'" + pluginName +  "'," +				// pluginName
        //                             "'"+ ipList +  "'," +					// ipList
        //                             "'"+ description +  "'," +				// description
        //                             "'"+ impact +  "'," +					// impact
        //                             "'"+ riskFactor +  "'," +				// riskfactor
        //                             "'"+ recommendation +  "'," +			// recommendation
        //                             "'"+ bidList +  "'," +					// bidlist
        //                             "'"+ cveList +  "'," +					// cvelist
        //                             "'"+ osvdbList +  "'," +				// osvdblist
        //                             "'"+ referenceLink +  "'," +			// referenceLink
        //                             "'1'," +								// revisionNo
        //                             "'"+ entryType + "'"+				// entryType
        //                             ");";
        //    originalId++;

        //    // Execute the command
        //    sqlite_cmd.ExecuteNonQuery();

        //    // Close connection
        //    sqlite_conn.Close();

        //    return databaseId;
        //}

        /*
         * This is the guiInsertUpdateRecordToDatabase method.
         * return the databaseId after storing the given entry to the database file.
         */
        //public int guiInsertUpdateRecordToDatabase(DataEntry entry, int oldId)
        //{
        //    int revisionNo = getRevisionNo(oldId);

        //    // Create
        //    sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

        //    // Open
        //    sqlite_conn.Open();

        //    // Create command
        //    sqlite_cmd = sqlite_conn.CreateCommand();

        //    String pluginName = addSlash(entry.getPluginName());
        //    String ipList = addSlash(entry.getIp());
        //    String description = addSlash(entry.getDescription());
        //    String impact = addSlash(entry.getImpact());
        //    String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
        //    String recommendation = addSlash(entry.getRecommendation());
        //    String bidList = addSlash(entry.getBid());
        //    String cveList = addSlash(entry.getCve());
        //    String osvdbList = addSlash(entry.getOsvdb());
        //    String referenceLink = addSlash(entry.getReferenceLink());
        //    String entryType = addSlash(entry.getEntryTypeString());

        //    sqlite_cmd.CommandText = "SELECT MAX(id) " +
        //                             "FROM Record";

        //    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
        //    int databaseId = -1;
        //    while (sqlite_datareader.Read())
        //    {
        //        if (databaseId < int.Parse(sqlite_datareader["MAX(id)"].ToString()))
        //        {
        //            databaseId = int.Parse(sqlite_datareader["MAX(id)"].ToString());
        //        }
        //    }
        //    sqlite_datareader.Close();
        //    databaseId++;

        //    sqlite_cmd.CommandText = "INSERT INTO Record (" +
        //                             "id," +
        //                             "originalId," +
        //                             "pluginName," +
        //                             "ipList," +
        //                             "description," +
        //                             "impact," +
        //                             "riskfactor," +
        //                             "recommendation," +
        //                             "bidlist," +
        //                             "cvelist," +
        //                             "osvdblist," +
        //                             "referenceLink," +
        //                             "revisionNo," +
        //                             "entryType" +
        //                             ")" +
        //                             "VALUES (" +
        //                             "NULL," +								// pluginId (null means auto increment)
        //                             "'"+ oldId +  "'," +					// originalId
        //                             "'"+ pluginName +  "'," +				// pluginName
        //                             "'"+ ipList +  "'," +					// ipList
        //                             "'"+ description +  "'," +				// description
        //                             "'"+ impact +  "'," +					// impact
        //                             "'"+ riskFactor +  "'," +				// riskfactor
        //                             "'"+ recommendation +  "'," +			// recommendation
        //                             "'"+ bidList +  "'," +					// bidlist
        //                             "'"+ cveList +  "'," +					// cvelist
        //                             "'"+ osvdbList +  "'," +				// osvdblist
        //                             "'"+ referenceLink +  "'," +			// referenceLink
        //                             "'"+ revisionNo +  "'," +				// revisionNo
        //                             "'"+ entryType + "'"+				// entryType
        //                             ");";

        //    // Execute the command
        //    sqlite_cmd.ExecuteNonQuery();

        //    // Close connection
        //    sqlite_conn.Close();

        //    return databaseId;
        //}

        public void guiUpdateUpdateRecordToDatabase(DataEntry entry, int oldId)
        {
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
            String entryType = addSlash(entry.getEntryTypeString());

            sqlite_cmd.CommandText = "Update Record SET " +
                                     "pluginName = '" + pluginName + "'," +
                                     "ipList = '" + ipList + "'," +
                                     "description = '" + description + "'," +
                                     "impact = '" + impact + "'," +
                                     "riskfactor = '" + riskFactor +
                                     "',recommendation = '" + recommendation+
                                     "',bidlist = '" + bidList+
                                     "',cvelist = '" + cveList+
                                     "',osvdblist = '" + osvdbList+
                                     "',referenceLink = '" + referenceLink+
                                     "',revisionNo = '" + revisionNo+
                                     "',entryType = '" + entryType+
                                     "' WHERE id = '" + oldId + "'";

            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            // Close connection
            sqlite_conn.Close();
        }


        public void guiUpdateUpdateNessusFindingToDatabase(DataEntry entry, int oldId)
        {
            int revisionNo = getRevisionNoForNessusFinding(oldId);

            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            String pluginName = addSlash(entry.getPluginName());
            String description = addSlash(entry.getDescription());
            String impact = addSlash(entry.getImpact());
            String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
            String recommendation = addSlash(entry.getRecommendation());
            String pluginversion = addSlash(entry.getpluginversion());
            String referenceLink = addSlash(entry.getReferenceLink());
            String entryType = addSlash(entry.getEntryTypeString());
            String pluginID = addSlash(entry.getpluginID());

            sqlite_cmd.CommandText = "Update NessusFinding SET " +
                                     "pluginName = '" + pluginName + "'," +
                                     "description = '" + description + "'," +
                                     "impact = '" + impact + "'," +
                                     "riskfactor = '" + riskFactor +
                                     "',recommendation = '" + recommendation +
                                     "',plugin_version = '" + pluginversion +
                                     "',referenceLink = '" + referenceLink +
                                     "',entryType = '" + entryType +
                                     "',revisionNo ='" + revisionNo +
                                     "',pluginID ='" + pluginID +
                                     "' WHERE fid = '" + oldId + "'";

            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            // Close connection
            sqlite_conn.Close();
        }

        public void guideleteNessusFindingEntry(int dbid)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "DELETE FROM NessusFinding WHERE fid = '" + dbid + "'";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void guiInsertNessusFindingToDatabase(DataEntry entry, int id)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            String pluginName = addSlash(entry.getPluginName());
            String description = addSlash(entry.getDescription());
            String impact = addSlash(entry.getImpact());
            String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
            String recommendation = addSlash(entry.getRecommendation());
            String pluginversion = addSlash(entry.getpluginversion());
            String referenceLink = addSlash(entry.getReferenceLink());
            String entryType = addSlash(entry.getEntryTypeString());
            String pluginID = addSlash(entry.getpluginID());
            
            sqlite_cmd.CommandText = "INSERT INTO NessusFinding (" +
                                     "fid," +
                                     "pluginName," +
                                     "description," +
                                     "impact," +
                                     "riskfactor," +
                                     "recommendation," +
                                     "plugin_version," +
                                     "referenceLink," +
                                     "entryType," +
                                     "revisionNo," +
                                     "originalId," +
                                     "pluginID" +
                                     ")" +
                                     "VALUES (" +
                                     "'" + id + "'," +								// pluginId (null means auto increment)
                                     "'" + pluginName + "'," +				// pluginName
                                     "'" + description + "'," +				// description
                                     "'" + impact + "'," +					// impact
                                     "'" + riskFactor + "'," +				// riskfactor
                                     "'" + recommendation + "'," +			// recommendation
                                     "'" + pluginversion + "'," +			// pluginversion
                                     "'" + referenceLink + "'," +			// referenceLink
                                     "'" + entryType + "'," +				// entryType
                                     "'1'," +
                                     "'" + originalIDForNessusFinding +"'," +
                                     "'" + pluginID + "'" +
                                     ");";

            originalIDForNessusFinding++;
            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            // Close connection
            sqlite_conn.Close();

        }

        public void guiUpdateMergeFindingDetailToDatabase(int id, int mergeid, int counting)
        {


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            if (counting == 0)
            {
                sqlite_cmd.CommandText = "Update FindingDetail SET undo_marker=''";

                // Execute the command
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_cmd.CommandText = "Update FindingDetail SET " +
                                     "fid = '" + id + "',undo_marker='"+counting+"'" +
                                     " WHERE fid = '" + mergeid + "'";

            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            // Close connection
            sqlite_conn.Close();
        }

        public void guiUpdatedeleteFindingDetailEntry(int dbid,int counting)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            if (counting == 0)
            {
                sqlite_cmd.CommandText = "Update FindingDetail SET undo_marker=''";

                sqlite_cmd.ExecuteNonQuery();
            }

            sqlite_cmd.CommandText = "Update FindingDetail SET " +
                                     "fid = '0', undo_marker='"+counting+"' WHERE fid = '" + dbid + "'";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void guiUpdateswapFindingDetailToDatabase(int id1, int id2)
        {


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "Update FindingDetail SET " +
                                     "fid = '" + id1 + "*" +
                                     "' WHERE fid = '" + id2 + "'";

            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Update FindingDetail SET " +
                         "fid = '" + id2 +
                         "' WHERE fid = '" + id1 + "'";


            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Update FindingDetail SET " +
             "fid = '" + id1 +
             "' WHERE fid = '" + id1 + "*"+"'";


            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            // Close connection
            sqlite_conn.Close();
        }

        public void guiUpdateUndoFindingDetailToDatabase(int dbid,int counting)
        {


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();


            
                sqlite_cmd.CommandText = "Update FindingDetail SET " +
                                           "fid = '" + dbid +
                                           "' WHERE undo_marker  = '"+counting+"'";

                // Execute the command
                sqlite_cmd.ExecuteNonQuery();


            
            // Close connection
            sqlite_conn.Close();
        }

        public void guiUpdateMergeFindingReferenceToDatabase(int id, int mergeid, int counting)
        {


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            if (counting == 0)
            {
                sqlite_cmd.CommandText = "Update FindingReferences SET undo_marker=''";

                // Execute the command
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_cmd.CommandText = "Update FindingReferences SET " +
                                     "fid = '" + id + "',undo_marker='" + counting + "'" +
                                     " WHERE fid = '" + mergeid + "'";

            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            // Close connection
            sqlite_conn.Close();
        }

        public void guiUpdatedeleteFindingReferenceEntry(int dbid, int counting)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            if (counting == 0)
            {
                sqlite_cmd.CommandText = "Update FindingReferences SET undo_marker=''";

                sqlite_cmd.ExecuteNonQuery();
            }

            sqlite_cmd.CommandText = "Update FindingReferences SET " +
                                     "fid = '0', undo_marker='" + counting + "' WHERE fid = '" + dbid + "'";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void guiUpdateswapFindingReferencesToDatabase(int id1, int id2)
        {


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "Update FindingReferences SET " +
                                     "fid = '" + id1 + "*" +
                                     "' WHERE fid = '" + id2 + "'";

            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Update FindingReferences SET " +
                         "fid = '" + id2 +
                         "' WHERE fid = '" + id1 + "'";


            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "Update FindingReferences SET " +
             "fid = '" + id1 +
             "' WHERE fid = '" + id1 + "*" + "'";


            // Execute the command
            sqlite_cmd.ExecuteNonQuery();

            // Close connection
            sqlite_conn.Close();
        }

        public void guiUpdateUndoFindingReferencesToDatabase(int dbid, int counting)
        {


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();



            sqlite_cmd.CommandText = "Update FindingReferences SET " +
                                       "fid = '" + dbid +
                                       "' WHERE undo_marker  = '" + counting + "'";

            // Execute the command
            sqlite_cmd.ExecuteNonQuery();



            // Close connection
            sqlite_conn.Close();
        }

        ////get DBID from entry name and ip
        //public int getDBID(DataEntry entry)
        //{
        //    int id = -1;

        //    // Create
        //    sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

        //    // Open
        //    sqlite_conn.Open();

        //    // Create command
        //    sqlite_cmd = sqlite_conn.CreateCommand();

        //    sqlite_cmd.CommandText = "SELECT id " +
        //                             "FROM Record WHERE pluginName = '" + entry.getPluginName() +
        //                             "' AND ipList LIKE '%" + entry.getIp() + "%'";




        //    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

        //    // read through the results
        //    while (sqlite_datareader.Read())
        //        id = int.Parse(sqlite_datareader["id"].ToString());

        //    // Close connection
        //    sqlite_conn.Close();

        //    return id;
        //}


        //get DBID from entry name and ip
        public int getDBID(DataEntry entry)
        {
            int id = -1;
            bool exitornot;
            List<int> tempfidlist = new List<int>();
            Dictionary<int, List<String>> temphostlist = new Dictionary<int, List<String>>();
            Dictionary<int, List<String>> tempportlist = new Dictionary<int, List<String>>();


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT fid " +
                                     "FROM NessusFinding WHERE pluginName = '" + entry.getPluginName() +"'";




            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            // read through the results
            while (sqlite_datareader.Read())
                tempfidlist.Add(int.Parse(sqlite_datareader["fid"].ToString()));

            sqlite_datareader.Close();
            // Close connection
            sqlite_conn.Close();


            sqlite_conn.Open();

            foreach (int i in tempfidlist)
            {

                List<String> iplistFromFindingDetail = new List<String>();
                List<String> portandprotocolFromFindingDetail = new List<string>();

                sqlite_cmd.CommandText = "SELECT * " +
                    "FROM FindingDetail WHERE fid ='" + i + "';";


                SQLiteDataReader sqlite_datareader2 = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader2.Read())
                {

                    iplistFromFindingDetail.Add(sqlite_datareader2["host"].ToString());
                    portandprotocolFromFindingDetail.Add(sqlite_datareader2["port_with_protocol"].ToString());


                }



                temphostlist.Add(i, iplistFromFindingDetail);
                tempportlist.Add(i, portandprotocolFromFindingDetail);

                sqlite_datareader2.Close();
            }


            // Close connection
            sqlite_conn.Close();


            foreach (int i in tempfidlist)
            {
                exitornot=true;
                for (int n = 0; n < entry.gethostlist().Count; n++)
                {
                    if ((temphostlist[i].Contains(entry.gethostlist()[n])) && (tempportlist[i].Contains(entry.getport_with_protocollist()[n])))
                        continue;
                    else
                        exitornot = false;

                }
                if (!exitornot)
                {
                    id = i;
                    break;
                }
            }



            return id;
        }




        /*
         * This is the insertRecordToDatabase method.
         * It is used to store the record for each HIGH/MEDIUM/LOW/NONE/OPENPORT
         * risk dictionary to the database file.
         */
        private void insertRecordToDatabase(Dictionary<int, DataEntry> risk)
        {
          
         

            foreach (KeyValuePair<int, DataEntry> entry in risk)
            {

                //@@@@@insertRecordToDatabase(entry.Value);
                formMessageWithProgressBar.setFinishedNumber(formMessageWithProgressBar.getFinishedNumber() + 1);
                Application.DoEvents();
            }

          
        }

        /*
         * This is the insertRecordToDatabase method.
         * It is used to store the given entry to the database file.
         */
        //private void insertRecordToDatabase(DataEntry entry)
        //{
            
        //    String pluginName = addSlash(entry.getPluginName());
        //    String ipList = addSlash(entry.getIp());
        //    String description = addSlash(entry.getDescription());
        //    String impact = addSlash(entry.getImpact());
        //    String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
        //    String recommendation = addSlash(entry.getRecommendation());
        //    String bidList = addSlash(entry.getBid());
        //    String cveList = addSlash(entry.getCve());
        //    String osvdbList = addSlash(entry.getOsvdb());
        //    String referenceLink = addSlash(entry.getReferenceLink());
        //    String entryType = addSlash(entry.getEntryTypeString());
            
        //    String louise = addSlash(entry.getlouise());            //@@@@@
        //    String pluginversion = addSlash(entry.getpluginversion());
        //    //String louise = addSlash(((NmapDataEntry)entry).getOS());
            


        //    sqlite_cmd.CommandText = "INSERT INTO Record (" +
        //                             "id," +
        //                             "originalId," +
        //                             "pluginName," +
        //                             "ipList," +
        //                             "description," +
        //                             "impact," +
        //                             "riskfactor," +
        //                             "recommendation," +
        //                             "bidlist," +
        //                             "cvelist," +
        //                             "osvdblist," +
        //                             "referenceLink," +
        //                             "revisionNo," +
        //                             "entryType," +
        //                             "louise,"+
        //                             "pluginVersion" +
        //                             ")" +
        //                             "VALUES (" +
        //                             "NULL," +								// pluginId (null means auto increment)
        //                             "'"+ originalId +  "'," +				// originalId
        //                             "'"+ pluginName +  "'," +				// pluginName
        //                             "'"+ ipList +  "'," +					// ipList
        //                             "'"+ description +  "'," +				// description
        //                             "'"+ impact +  "'," +					// impact
        //                             "'"+ riskFactor +  "'," +				// riskfactor
        //                             "'"+ recommendation +  "'," +			// recommendation
        //                             "'"+ bidList +  "'," +					// bidlist
        //                             "'"+ cveList +  "'," +					// cvelist
        //                             "'"+ osvdbList +  "'," +				// osvdblist
        //                             "'"+ referenceLink +  "'," +			// referenceLink
        //                             "'"+ "1" +  "'," +						// revisionNo
        //                             "'"+ entryType + "',"+				    // entryType
        //                             "'" + louise + "'," +                  // @@@@@trying to add new column to the table 'record'
        //                             "'"+ pluginversion+"'" +               //pluginversion
        //                             ");";

        //    originalId++;

        //    // execute the command
        //    sqlite_cmd.ExecuteNonQuery();

        //}


         /* 
          * This is the insertNessusFindingToDatabase method.
          * It is used to store the record for each HIGH/MEDIUM/LOW/NONE/OPENPORT
          * risk dictionary to the database file.
          */
        private void insertNessusFindingToDatabase(Dictionary<int, DataEntry> risk)
        {
            int i=0;
            SQLiteTransaction transaction = sqlite_conn.BeginTransaction();

            foreach (KeyValuePair<int, DataEntry> entry in risk)
            {

                insertNessusFinding(entry.Value);
                formMessageWithProgressBar.setFinishedNumber(formMessageWithProgressBar.getFinishedNumber() + 1);
                Application.DoEvents();
                if (i++ == 9000)
                {
                    transaction.Commit();
                    i = 0;
                    transaction = sqlite_conn.BeginTransaction();
                }

            }

            transaction.Commit();

        }

        /*
         * This is the insertNessusFinding method.
         * It is used to store the given entry to the database file.
         */
        private void insertNessusFinding(DataEntry entry)
        {

            String pluginName = addSlash(entry.getPluginName());
            String description = addSlash(entry.getDescription());
            String impact = addSlash(entry.getImpact());
            String riskFactor = addSlash(RiskFactorFunction.getEnumString(entry.getRiskFactor()));
            String recommendation = addSlash(entry.getRecommendation());
            String plugin_version = addSlash(entry.getpluginversion());
            String referenceLink = addSlash(entry.getReferenceLink());
            String entryType = addSlash(entry.getEntryTypeString());
            String pluginID = addSlash(entry.getpluginID());

            sqlite_cmd.CommandText = "INSERT INTO NessusFinding(" +
                                     "fid," +
                                     "pluginName," +
                                     "description," +
                                     "impact," +
                                     "riskfactor," +
                                     "recommendation," +
                                     "plugin_version," +
                                     "referenceLink," +
                                     "entryType," +
                                     "revisionNo," +
                                     "originalId," +
                                     "pluginID" +
                                     ")" +
                                     "VALUES (" +
                                     "NULL," +								// pluginId (null means auto increment)
                                     "'" + pluginName + "'," +				// pluginName
                                     "'" + description + "'," +				// description
                                     "'" + impact + "'," +					// impact
                                     "'" + riskFactor + "'," +				// riskfactor
                                     "'" + recommendation + "'," +			// recommendation
                                     "'" + plugin_version + "'," +			// plugin_version
                                     "'" + referenceLink + "'," +			// referenceLink
                                     "'" + entryType + "'," +				    // entryType
                                     "'" + "1" + "'," +						// revisionNo
                                     "'" + originalIDForNessusFinding+"',"+
                                     "'" + pluginID + "'" +
                                     ");";

            originalIDForNessusFinding++;

            // execute the command
            sqlite_cmd.ExecuteNonQuery();

        }


        /*
         * This is the insertFindingDetailToDatabase method.
         * It is used to store the finding detail for each HIGH/MEDIUM/LOW/NONE/OPENPORT
         * risk dictionary to the database file.
         */
        private void insertFindingDetailToDatabase(Dictionary<int, DataEntry> risk)
        {

            SQLiteTransaction transaction = sqlite_conn.BeginTransaction();

            foreach (KeyValuePair<int, DataEntry> entry in risk)
            {
                int i = 0;

                insertFindingDetailToDatabase(entry.Value);
                formMessageWithProgressBar.setFinishedNumber(formMessageWithProgressBar.getFinishedNumber() + 1);
                Application.DoEvents();
                if (i++ == 9000)
                {
                    transaction.Commit();
                    i = 0;
                    transaction = sqlite_conn.BeginTransaction();
                }
            }

            transaction.Commit();

        }


        /*
         * This is the insertFindingDetailToDatabase method.
         * It is used to store the given Finding detail to the database file.
         */
        private void insertFindingDetailToDatabase(DataEntry entry)
        {

            entry.sortForFindingDetail2();
            List<String> hostList = entry.gethostlist();
            List<String> port_with_protocolList = entry.getport_with_protocollist();
            List<String> plugin_outeputList = entry.getpluginoutputlist();

            for (int n=0; n < hostList.Count();n++ )
            {
                //testing = addSlash(pluginoutput_todatabase);
                //System.Windows.Forms.MessageBox.Show(pluginoutput_todatabase);
                //port_with_protocol_todatabase = port_with_protocolList[counting];
                // pluginoutput_todatabase = plugin_outeputList[counting];

                sqlite_cmd.CommandText = "INSERT INTO FindingDetail (" +
                                         "id," +
                                         "fid," +
                                         "host," +
                                         "port_with_protocol," +
                                         "plugin_output" +
                                         ")" +
                                         "VALUES (" +
                                         "NULL," +								// pluginId (null means auto increment)
                                         "'" + finddetailfid + "'," +				//fid
                                         "'" + addSlash(hostList[n]) + "'," +				// host
                                         "'" + addSlash(port_with_protocolList[n]) + " '," +		// port and protocol
                                         "'" + addSlash(plugin_outeputList[n]) + "'" +               // plugin output
                                         ");";
                // execute the command
                sqlite_cmd.ExecuteNonQuery();

                
            }
            finddetailfid++;




        }

        /*
 * This is the insertReferenceAndFindingReferenceToDatabase method.
 * It is used to store the finding detail for each HIGH/MEDIUM/LOW/NONE/OPENPORT
 * risk dictionary to the database file.
 */
        private void insertReferenceAndFindingReferenceToDatabase(Dictionary<int, DataEntry> risk)
        {
            int i = 0;

            SQLiteTransaction transaction = sqlite_conn.BeginTransaction();

            foreach (KeyValuePair<int, DataEntry> entry in risk)
            {


                insertReferenceAndFindingReferenceToDatabase(entry.Value);

                formMessageWithProgressBar.setFinishedNumber(formMessageWithProgressBar.getFinishedNumber() + 1);
                Application.DoEvents();

                if (i++ == 9000)
                {
                    transaction.Commit();
                    i = 0;
                    transaction = sqlite_conn.BeginTransaction();
                }
            }
            transaction.Commit();

        }


        private void insertReferenceAndFindingReferenceToDatabase(DataEntry entry)
        {


            List<String> bidlist = entry.getBidList();
            List<String> cvelist = entry.getCveList();
            List<String> osvdblist = entry.getOsvdbList();

            if (bidlist != null && bidlist.Count != 0)
            {
                foreach (String bid in bidlist)
                //for (int n = 0; n < bidlist.Count(); n++)
                {
                    sqlite_cmd.CommandText = "SELECT rid FROM references1 " +
                                             "WHERE name='" + bid + "'" +
                                             ";";
                    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

                    if (sqlite_datareader.Read())
                    {
                        String ridfound = sqlite_datareader["rid"].ToString();
                        sqlite_datareader.Close();
                        sqlite_cmd.CommandText = "INSERT INTO FindingReferences (" +
                                                 "id," +
                                                 "fid," +
                                                 "rid" +
                                                 ")" +
                                                "VALUES (" +
                                                "NULL," +
                                                "'" + findingreferencesfid + "'," +
                                                "'" + ridfound + "'" +
                                                ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sqlite_datareader.Close();
                        sqlite_cmd.CommandText = "INSERT INTO references1 (" +
                                                 "rid," +
                                                 "type," +
                                                 "name" +
                                                 ")" +
                                                 "VALUES (" +
                                                 "NULL," +
                                                 "'BID'," +
                                                 "'" + bid + "'" +
                                                 ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO FindingReferences (" +
                                                 "id," +
                                                 "fid," +
                                                 "rid" +
                                                 ")" +
                                                 "VALUES (" +
                                                 "NULL," +
                                                 "'" + findingreferencesfid + "'," +
                                                 "'" + rid + "'" +
                                                 ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();

                        rid++;

                    }

                }
            }

            if (cvelist != null && cvelist.Count != 0)
            {
                foreach (String cve in cvelist)
                //for (int n = 0; n < bidlist.Count(); n++)
                {
                    sqlite_cmd.CommandText = "SELECT rid FROM references1 " +
                                             "WHERE name='" + cve + "'" +
                                             ";";
                    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

                    if (sqlite_datareader.Read())
                    {
                        String ridfound = sqlite_datareader["rid"].ToString();
                        sqlite_datareader.Close();
                        sqlite_cmd.CommandText = "INSERT INTO FindingReferences (" +
                                                 "id," +
                                                 "fid," +
                                                 "rid" +
                                                 ")" +
                                                "VALUES (" +
                                                "NULL," +
                                                "'" + findingreferencesfid + "'," +
                                                "'" + ridfound + "'" +
                                                ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sqlite_datareader.Close();
                        sqlite_cmd.CommandText = "INSERT INTO references1 (" +
                                                 "rid," +
                                                 "type," +
                                                 "name" +
                                                 ")" +
                                                 "VALUES (" +
                                                 "NULL," +
                                                 "'CVE'," +
                                                 "'" + cve + "'" +
                                                 ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO FindingReferences (" +
                                                 "id," +
                                                 "fid," +
                                                 "rid" +
                                                 ")" +
                                                 "VALUES (" +
                                                 "NULL," +
                                                 "'" + findingreferencesfid + "'," +
                                                 "'" + rid + "'" +
                                                 ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();

                        rid++;

                    }

                }
            }

            if (osvdblist != null && osvdblist.Count != 0)
            {
                foreach (String osvdb in osvdblist)
                //for (int n = 0; n < bidlist.Count(); n++)
                {
                    sqlite_cmd.CommandText = "SELECT rid FROM references1 " +
                                             "WHERE name='" + osvdb.Replace("OSVDB:", "") + "'" +
                                             ";";
                    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

                    if (sqlite_datareader.Read())
                    {
                        String ridfound = sqlite_datareader["rid"].ToString();
                        sqlite_datareader.Close();

                        sqlite_cmd.CommandText = "INSERT INTO FindingReferences (" +
                                                 "id," +
                                                 "fid," +
                                                 "rid" +
                                                 ")" +
                                                "VALUES (" +
                                                "NULL," +
                                                "'" + findingreferencesfid + "'," +
                                                "'" + ridfound + "'" +
                                                ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sqlite_datareader.Close();
                        sqlite_cmd.CommandText = "INSERT INTO references1 (" +
                                                 "rid," +
                                                 "type," +
                                                 "name" +
                                                 ")" +
                                                 "VALUES (" +
                                                 "NULL," +
                                                 "'OSVDB'," +
                                                 "'" + osvdb.Replace("OSVDB:", "") + "'" +
                                                 ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO FindingReferences (" +
                                                 "id," +
                                                 "fid," +
                                                 "rid" +
                                                 ")" +
                                                 "VALUES (" +
                                                 "NULL," +
                                                 "'" + findingreferencesfid + "'," +
                                                 "'" + rid + "'" +
                                                 ");";
                        // execute the command
                        sqlite_cmd.ExecuteNonQuery();

                        rid++;

                    }

                }
            }

            findingreferencesfid++;




        }


        /*
       * This is the insertProjectNameAndRemark method.
       * It is used to store the Project Name and Remark to the database file.
       */
        private void insertProjectNameAndRemark()
        {

            sqlite_cmd.CommandText = "INSERT INTO ProjectNameAndRemark (" +
                                         "id," +
                                         "ProjectName," +
                                         "Remark" +
                                         ")" +
                                         "VALUES (" +
                                         "NULL," +								// pluginId (null means auto increment)
                                         "'" + Program.state.ProjectName + "'," +				
                                         "'" + Program.state.Remark + "'" +				
                                        ");";
                // execute the command
                sqlite_cmd.ExecuteNonQuery();

        }




        public void insertOpenPortToDatabase(List<DataEntry> entryList)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();
            
            //@@@@@
           
            SQLiteTransaction transaction = sqlite_conn.BeginTransaction();

            foreach (DataEntry entry in entryList)
            {

                //@@@@@insertRecordToDatabase(entry);
                insertNessusFinding(entry);
                insertFindingDetailToDatabase(entry);
            }

            transaction.Commit();

            // Close connection
            sqlite_conn.Close();
        }
        /*
         * This is the getRevisionNo method.
         * It is used to get the (latest revisionNo + 1) according to the given oldId.
         * return a revisionNo for storing a new entry to the database file.
         */
        private int getRevisionNo(int oldId)
        {
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
            while (sqlite_datareader.Read())
            {
                if (revisionNo < int.Parse(sqlite_datareader["revisionNo"].ToString()))
                {
                    revisionNo = int.Parse(sqlite_datareader["revisionNo"].ToString());
                }
            }
            sqlite_datareader.Close();
            revisionNo++;

            // Close connection
            sqlite_conn.Close();

            return revisionNo;
        }

        private int getRevisionNoForNessusFinding(int oldId)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT revisionNo " +
                                     "FROM NessusFinding " +
                                     "WHERE originalId=" + oldId.ToString() + ";";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            int revisionNo = -1;
            while (sqlite_datareader.Read())
            {
                if (revisionNo < int.Parse(sqlite_datareader["revisionNo"].ToString()))
                {
                    revisionNo = int.Parse(sqlite_datareader["revisionNo"].ToString());
                }
            }
            sqlite_datareader.Close();
            revisionNo++;

            // Close connection
            sqlite_conn.Close();

            return revisionNo;
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

        public void deleteEditedRecordEntry(int dbid)
        {
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "DELETE FROM RECORD WHERE id = '" + dbid + "'";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

                /*
          * This is the getter method.
          * return all DataEntry from the file
          */
        //@@@@@this seem like is not used in .Didn't enter when going from rawdatagrid to record datagrid
        //public List<DataEntry> getEntryFromDatabaseId()
        //{
        //    List<DataEntry> tempEntryList = new List<DataEntry>();

        //    // Create
        //    sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

        //    // Open
        //    sqlite_conn.Open();

        //    // Create command
        //    sqlite_cmd = sqlite_conn.CreateCommand();

        //    sqlite_cmd.CommandText = "SELECT * " +
        //                             "FROM Record ";

        //    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

        //    DataEntry tempEntry = null;

        //    // read through the results
        //    while (sqlite_datareader.Read())
        //    {
        //        #region // string cve/bid/osvdb to cve/bid/osvdb List
        //        List<String> cveList = sqlite_datareader["cvelist"].ToString().Split(',').ToList<String>();
        //        List<String> bidList = sqlite_datareader["bidlist"].ToString().Split(',').ToList<String>();
        //        List<String> osvdbList = sqlite_datareader["osvdblist"].ToString().Split(',').ToList<String>();

        //        for (int i = 0; i < cveList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in cveList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            cveList[i] = tempString;
        //        }

        //        for (int i = 0; i < bidList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in bidList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            bidList[i] = tempString;
        //        }

        //        for (int i = 0; i < osvdbList.Count; i++)
        //        {
        //            String tempString = "";
        //            foreach (char c in osvdbList[i])
        //            {
        //                if (c != ' ')
        //                {
        //                    tempString += c;
        //                }
        //            }
        //            osvdbList[i] = tempString;
        //        }
        //        #endregion

        //        tempEntry = new GuiDataEntry(sqlite_datareader["pluginName"].ToString(),
        //                                     sqlite_datareader["ipList"].ToString(),
        //                                     sqlite_datareader["description"].ToString(),
        //                                     sqlite_datareader["impact"].ToString(),
        //                                     RiskFactorFunction.getEnum(sqlite_datareader["riskfactor"].ToString()),
        //                                     sqlite_datareader["recommendation"].ToString(),
        //                                     cveList,
        //                                     bidList,
        //                                     osvdbList,
        //                                     sqlite_datareader["referenceLink"].ToString(),
        //                                     sqlite_datareader["entryType"].ToString(),
        //                                     sqlite_datareader["pluginVersion "].ToString());           //@@@@@

        //        tempEntryList.Add(tempEntry);
        //    }
        //    sqlite_datareader.Close();

        //    // Close connection
        //    sqlite_conn.Close();

        //    return tempEntryList;
        //}
        


        public Dictionary<DataEntry.EntryType, List<string>> getFileNamesFRomRawDatabase()
        {
            Dictionary<DataEntry.EntryType, List<string>> fileNameRaw = new Dictionary<DataEntry.EntryType, List<string>>();

            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();
            SQLiteDataReader sqlite_datareader;

            sqlite_cmd.CommandText = "SELECT fileName " +
                                     "FROM NessusRecordRaw ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // read through the results
            while (sqlite_datareader.Read())
            {
                string fileName = sqlite_datareader["fileName"].ToString();
                if (!fileNameRaw.ContainsKey(DataEntry.EntryType.NESSUS))
                    fileNameRaw.Add(DataEntry.EntryType.NESSUS, new List<string>());
                if (!fileNameRaw[DataEntry.EntryType.NESSUS].Contains(fileName))
                    fileNameRaw[DataEntry.EntryType.NESSUS].Add(fileName);
            }
            sqlite_datareader.Close();

            sqlite_cmd.CommandText = "SELECT fileName " +
                         "FROM MBSARecordRaw ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // read through the results
            while (sqlite_datareader.Read())
            {
                string fileName = sqlite_datareader["fileName"].ToString();
                if (!fileNameRaw.ContainsKey(DataEntry.EntryType.MBSA))
                    fileNameRaw.Add(DataEntry.EntryType.MBSA, new List<string>());
                if (!fileNameRaw[DataEntry.EntryType.MBSA].Contains(fileName))
                    fileNameRaw[DataEntry.EntryType.MBSA].Add(fileName);
            }
            sqlite_datareader.Close();

            sqlite_cmd.CommandText = "SELECT fileName " +
                         "FROM NmapRecordRaw ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // read through the results
            while (sqlite_datareader.Read())
            {
                string fileName = sqlite_datareader["fileName"].ToString();
                if (!fileNameRaw.ContainsKey(DataEntry.EntryType.NMAP))
                    fileNameRaw.Add(DataEntry.EntryType.NMAP, new List<string>());
                if (!fileNameRaw[DataEntry.EntryType.NMAP].Contains(fileName))
                    fileNameRaw[DataEntry.EntryType.NMAP].Add(fileName);
            }
            sqlite_datareader.Close();

            sqlite_cmd.CommandText = "SELECT fileName " +
                                     "FROM AcunetixRecordRaw ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // read through the results
            while (sqlite_datareader.Read())
            {
                string fileName = sqlite_datareader["fileName"].ToString();
                if (!fileNameRaw.ContainsKey(DataEntry.EntryType.Acunetix))
                    fileNameRaw.Add(DataEntry.EntryType.Acunetix, new List<string>());
                if (!fileNameRaw[DataEntry.EntryType.Acunetix].Contains(fileName))
                    fileNameRaw[DataEntry.EntryType.Acunetix].Add(fileName);
            }
            sqlite_datareader.Close();

            // Close connection
            sqlite_conn.Close();

            return fileNameRaw;
        }

        public Dictionary<String, String> getIpHost()
        {
            Dictionary<String, String> ipHost = new Dictionary<string, string>();

            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();
            SQLiteDataReader sqlite_datareader;

            sqlite_cmd.CommandText = "SELECT * " +
                                     "FROM IPHostTable ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // read through the results
            while (sqlite_datareader.Read())
            {
                ipHost.Add(sqlite_datareader["ip"].ToString(),sqlite_datareader["hostName"].ToString());
            }
            sqlite_datareader.Close();

            // Close connection
            sqlite_conn.Close();
            return ipHost;
        }


        public void FromRawDatabaseToExcel(SheetData sheetData)
        {
            int count = 0;
            
            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT pluginName,ipList,description,plugin_output " +
                                     "FROM NessusRecordRaw";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();



            DataTable dataTable = new DataTable();
            dataTable.Load(sqlite_datareader);


            foreach (DataRow row in dataTable.Rows)
            {

                Row rowdata = new Row();
                foreach (DataColumn column in dataTable.Columns)
                {

                    //Since the limit of character of a cell in Excel is around 32767,
                    //The following is doing the checking 
                    //if it exceed, the exceeded words will be pushed to the next cell
                    if (row[column].ToString().Length < 32767)
                    {
                        rowdata.Append(new Cell()
                        {
                            DataType = new EnumValue<CellValues>(CellValues.String),
                            CellValue = new CellValue()
                            {
                                Text = row[column].ToString()

                            }
                        });
                    }
                    else
                    {
                        for (int n = 0; n < ((row[column].ToString().Length) / 32767); n++, count = n)
                        {
                            rowdata.Append(new Cell()
                            {
                                DataType = new EnumValue<CellValues>(CellValues.String),
                                CellValue = new CellValue()
                                {
                                    Text = row[column].ToString().Substring(32767 * n, 32767)

                                }
                            });


                        }

                        rowdata.Append(new Cell()
                        {
                            DataType = new EnumValue<CellValues>(CellValues.String),
                            CellValue = new CellValue()
                            {
                                Text = row[column].ToString().Substring(32767 * count)

                            }
                        });

                        count = 0;

                    }

                }
                sheetData.Append(rowdata);
            }




        }


        // Export pluginoutput in text file group by pluginoutput
        public void GetPluginOutputToTxtGroupByPluginID(String FolderName)
        {
            Dictionary<String, int> FindingNum = new Dictionary<string, int>();


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT F.fid,count(*) AS num_count FROM FindingDetail AS F GROUP BY F.fid ORDER BY F.fid";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                FindingNum.Add(sqlite_datareader["fid"].ToString(), Int32.Parse(sqlite_datareader["num_count"].ToString()));

            }
            sqlite_datareader.Close();



            sqlite_cmd.CommandText = "SELECT N.pluginName,N.pluginID,F.host,F.port_with_protocol,F.plugin_output,F.fid " +
                                     "FROM NessusFinding AS N, FindingDetail AS F " +
                                     "WHERE (F.fid = N.fid) ORDER BY F.fid";

            SQLiteDataReader sqlite_datareader1 = sqlite_cmd.ExecuteReader();


            List<String> PlugInIDIndex = new List<string>();
            List<String> PlugInNameIndex = new List<string>();


            while (sqlite_datareader1.Read())
            {

                if (sqlite_datareader1["pluginID"].ToString() == "")
                    continue;
                StreamWriter file1 = new StreamWriter(FolderName + sqlite_datareader1["pluginID"].ToString() + ".txt");
                int n = FindingNum[sqlite_datareader1["fid"].ToString()];
                PlugInIDIndex.Add(sqlite_datareader1["pluginID"].ToString());
                PlugInNameIndex.Add(sqlite_datareader1["pluginName"].ToString());



                do
                {


                    file1.WriteLine(sqlite_datareader1["host"].ToString() + "    " + sqlite_datareader1["port_with_protocol"].ToString());
                    file1.WriteLine("-----------------------------------------------------------------------------------------");
                    file1.WriteLine(sqlite_datareader1["plugin_output"].ToString());
                    file1.WriteLine("");
                    file1.WriteLine("=========================================================================================");
                    file1.WriteLine("");
                    n--;

                    if (n != 0)
                    {
                        sqlite_datareader1.Read();
                    }
                } while (n != 0);

                file1.Close();
            }
            StreamWriter file = new StreamWriter(FolderName + "index.txt");
            for (int n = 0; n < PlugInIDIndex.Count(); n++)
            {
                file.WriteLine(PlugInIDIndex[n] + "\t" + PlugInNameIndex[n]);
            }
            file.Close();


            sqlite_conn.Close();

 
        }

        //Export pluginoutput in text file group by host name
        public void GetPluginOutputToTxtGroupByHost(String FolderName)
        {
            Dictionary<String, int> HostNum = new Dictionary<string, int>();


            // Create
            sqlite_conn = new SQLiteConnection("Data source=" + path + ";Version=3;New=True;Compress=True;");

            // Open
            sqlite_conn.Open();

            // Create command
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT F.host,count(*) AS hostnum_count FROM FindingDetail AS F GROUP BY F.host ORDER BY F.host";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                HostNum.Add(sqlite_datareader["host"].ToString(), Int32.Parse(sqlite_datareader["hostnum_count"].ToString()));

            }
            sqlite_datareader.Close();


            sqlite_cmd.CommandText = "SELECT F.host,F.port_with_protocol,N.pluginName,N.pluginID,F.plugin_output " +
                                     "FROM NessusFinding AS N ,FindingDetail AS F " +
                                     "WHERE F.fid=N.fid ORDER BY F.host";

            SQLiteDataReader sqlite_datareader1 = sqlite_cmd.ExecuteReader();





            while (sqlite_datareader1.Read())
            {
                //count++;
                if (sqlite_datareader1["host"].ToString() == "")
                    continue;



                StreamWriter file1 = new StreamWriter(FolderName + sqlite_datareader1["host"].ToString() + ".txt");
                int n = HostNum[sqlite_datareader1["host"].ToString()];



                do
                {
                    file1.WriteLine(sqlite_datareader1["port_with_protocol"].ToString());
                    file1.WriteLine(sqlite_datareader1["pluginID"].ToString() + "    " + sqlite_datareader1["pluginName"].ToString());
                    file1.WriteLine("-----------------------------------------------------------------------------------------");
                    file1.WriteLine(sqlite_datareader1["plugin_output"].ToString());
                    file1.WriteLine("");
                    file1.WriteLine("=========================================================================================");
                    file1.WriteLine("");
                    n--;

                    if (n != 0)
                    {
                        sqlite_datareader1.Read();
                    }
                } while (n != 0);

                file1.Close();
            }



            sqlite_conn.Close();
        }
    
    
    }



}
