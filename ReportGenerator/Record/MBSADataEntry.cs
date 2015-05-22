using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record
{

    /// <summary>
    /// This is the MBSADataEntry Class.
    /// It is used to store the DataEntry from MBSA.
    /// </summary>
    class MBSADataEntry : DataEntry
    {
        public string getCheckID() { return checkID; }
        public string getCheckGrade() { return checkGrade; }
        public string getCheckType() { return checkType; }
        public string getCheckCat() { return checkCat; }
        public string getCheckRank() { return checkRank; }
        public string getCheckName() { return checkName; }
        public string getCheckURL1() { return checkURL1; }
        public string getCheckURL2() { return checkURL2; }
        public string getCheckGroupID() { return checkGroupID; }
        public string getCheckGroupName() { return checkGroupName; }
        public string getDetailText() { return detailText; }
        public string getUpdateDataIsInstalled() { return updateDataIsInstalled; }
        public string getUpdateDataRestartRequired() { return updateDataRestartRequired; }
        public string getUpdateDataID() { return updateDataID; }
        public string getUpdateDataGUID() { return updateDataGUID; }
        public string getUpdateDataBulletinID() { return updateDataBulletinID; }
        public string getUpdateDataKBID() { return updateDataKBID; }
        public string getUpdateDataType() { return updateDataType; }
        public string getUpdateDataInformationURL() { return UpdateDataInformationURL; }
        public string getUpdateDataDownloadURL() { return UpdateDataDownloadURL; }


        private string checkID = "";
        private string checkGrade = "";
        private string checkType = "";
        private string checkCat = "";
        private string checkRank = "";
        private string checkName = "";
        private string checkURL1 = "";
        private string checkURL2 = "";
        private string checkGroupID = "";
        private string checkGroupName = "";

        private string detailText = "";

        private string updateDataIsInstalled = "";
        private string updateDataRestartRequired = "";
        private int severity = 1; //updateDataSeverity
        private string updateDataID = "";
        private string updateDataGUID = "";
        private string updateDataBulletinID = "";
        private string updateDataKBID = "";
        private string updateDataType = "";

        private Dictionary<int, String> tableHeader ; 
        private Dictionary<int, MBSARow> tableRowData;
        String tableHeaderString = null; // for output excel
        String tableRowDataString = null;
        String severityString = null;

        private string UpdateDataInformationURL = "";
        private string UpdateDataDownloadURL = "";

        public String getTableHeaderString() {
            if (tableHeaderString != null)
                return tableHeaderString;
            String temp ="";
            if (tableHeader == null)
                return temp;
            foreach (string header in tableHeader.Values)
                temp += header + ", ";
            if (!String.IsNullOrEmpty(temp))
                temp = temp.Substring(0, temp.Length - 2);
            return temp;
        }

        public String getTableRowDataString()
        {
            if (tableRowDataString != null)
                return tableRowDataString;
            String temp = "";
            if (tableRowData == null)
                return temp;
            foreach (MBSARow row in tableRowData.Values)
            {
                String[] col = row.getCol();
                String grade = row.getGrade();
                temp += grade + " ";
                foreach (string colString in col)
                    temp += colString + " ";
                temp = temp.Substring(0, temp.Length-1);
                temp += ", ";
            }

            if (!String.IsNullOrEmpty(temp))
                temp = temp.Substring(0, temp.Length - 2);
            
            return temp;
        }

        /*
         * This is the constructor of MBSADataEntry.
         * (Without referenceLink)
         */
        /// <summary>
        /// This is the constructor of MBSADataEntry.
        /// (Without referenceLink)
        /// </summary>
        /// <param name="pluginName">plugin name of the DataEntry</param>
        /// <param name="ip">host name of the DataEntry</param>
        /// <param name="description">description of the DataEntry</param>
        /// <param name="severity">int represents the risk of the DataEntry</param>
        /// <param name="riskFactor">RiskFactor of the DataEntry</param>
        /// <param name="cveList">cveList of the DataEntry</param>
        /// <param name="bidList">bidList of the DataEntry</param>
        /// <param name="osvdbList">osvdbList of the DataEntry</param>
        public MBSADataEntry(String pluginName,
                             String ip,
                             String description,
                             int severity,
                             RiskFactor riskFactor,
                             List<String> cveList,
                             List<String> bidList,
                             List<String> osvdbList,
                             string fileName,

                             string checkID,
                             string checkGrade,
                             string checkType,
                             string checkCat,
                             string checkRank,
                             string checkName,
                             string checkURL1,
                             string checkURL2,
                             string checkGroupID,
                             string checkGroupName,

                             string detailText,

                             string updateDataIsInstalled,
                             string updateDataRestartRequired,
                             string updateDataID,
                             string updateDataGUID,
                             string updateDataBulletinID,
                             string updateDataKBID,
                             string updateDataType,

                             Dictionary<int, String> tableHeader,
                             Dictionary<int, MBSARow> tableRowData,

                             string UpdateDataInformationURL,
                             string UpdateDataDownloadURL,
                             String referenceLink="")
        { //BulletinURL

            this.severity = severity;
            //if (severity <= 1 && riskFactor == RiskFactor.NULL) {
            //    this.valid = false;
            //    return;
            //}
            //else if (riskFactor == RiskFactor.NULL) {
            this.valid = true;
            //if (riskFactor == RiskFactor.NULL)
            //{
            //    riskFactor = RiskFactorFunction.getEnum(severity);
            //}

            this.pluginName = pluginName;
            ipList.Add(ip);
            this.description = description == null ? "" : description;
            this.impact = "";
            this.recommendation = "";
            this.riskFactor = riskFactor;
            this.valid = true;
            this.cveList = cveList;
            this.bidList = bidList;
            this.osvdbList = osvdbList;
            this.fileName = fileName;

            this.checkID = checkID;
            this.checkGrade = checkGrade;
            this.checkType = checkType;
            this.checkCat = checkCat;
            this.checkRank = checkRank;
            this.checkName = checkName;
            this.checkURL1 = checkURL1;
            this.checkURL2 = checkURL2;
            this.checkGroupID = checkGroupID;
            this.checkGroupName = checkGroupName;

            this.detailText = detailText;

            this.updateDataIsInstalled = updateDataIsInstalled;
            this.updateDataRestartRequired = updateDataRestartRequired;
            this.updateDataID = updateDataID;
            this.updateDataGUID = updateDataGUID;
            this.updateDataBulletinID = updateDataBulletinID;
            this.updateDataKBID = updateDataKBID;
            this.updateDataType = updateDataType;

            this.UpdateDataInformationURL = UpdateDataInformationURL;
            this.UpdateDataDownloadURL = UpdateDataDownloadURL;

            this.type = EntryType.MBSA;
            if (referenceLink != null)
                this.referenceLink = referenceLink;
            else
                this.referenceLink = "";
            this.tableHeader = tableHeader;
            this.tableRowData = tableRowData;
            //this.louise = updateDataKBID;
        }

        /*
         * This is the constructor of MBSADataEntry.
         * (Without referenceLink)
         */
        /// <summary>
        /// This is the constructor of MBSADataEntry for output excel.
        /// (Without referenceLink)
        /// </summary>
        /// <param name="pluginName">plugin name of the DataEntry</param>
        /// <param name="ip">host name of the DataEntry</param>
        /// <param name="description">description of the DataEntry</param>
        /// <param name="severity">int represents the risk of the DataEntry</param>
        /// <param name="riskFactor">RiskFactor of the DataEntry</param>
        /// <param name="cveList">cveList of the DataEntry</param>
        /// <param name="bidList">bidList of the DataEntry</param>
        /// <param name="osvdbList">osvdbList of the DataEntry</param>
        public MBSADataEntry(String pluginName,
                             String ip,
                             String description,
                             String severityString,
                             RiskFactor riskFactor,
                             List<String> cveList,
                             List<String> bidList,
                             List<String> osvdbList,
                             string fileName,

                             string checkID,
                             string checkGrade,
                             string checkType,
                             string checkCat,
                             string checkRank,
                             string checkName,
                             string checkURL1,
                             string checkURL2,
                             string checkGroupID,
                             string checkGroupName,

                             string detailText,

                             string updateDataIsInstalled,
                             string updateDataRestartRequired,
                             string updateDataID,
                             string updateDataGUID,
                             string updateDataBulletinID,
                             string updateDataKBID,
                             string updateDataType,

                             string tableHeaderString,
                             string tableRowDataString,

                             string UpdateDataInformationURL,
                             string UpdateDataDownloadURL,
                             String referenceLink = "")
        { //BulletinURL

            this.severityString = severityString;
            //if (severity <= 1 && riskFactor == RiskFactor.NULL) {
            //    this.valid = false;
            //    return;
            //}
            //else if (riskFactor == RiskFactor.NULL) {
            this.valid = true;
            //if (riskFactor == RiskFactor.NULL)
            //{
            //    riskFactor = RiskFactorFunction.getEnum(severity);
            //}

            this.pluginName = pluginName;
            ipList.Add(ip);
            this.description = description == null ? "" : description;
            this.impact = "";
            this.recommendation = "";
            this.riskFactor = riskFactor;
            this.valid = true;
            this.cveList = cveList;
            this.bidList = bidList;
            this.osvdbList = osvdbList;
            this.fileName = fileName;

            this.checkID = checkID;
            this.checkGrade = checkGrade;
            this.checkType = checkType;
            this.checkCat = checkCat;
            this.checkRank = checkRank;
            this.checkName = checkName;
            this.checkURL1 = checkURL1;
            this.checkURL2 = checkURL2;
            this.checkGroupID = checkGroupID;
            this.checkGroupName = checkGroupName;

            this.detailText = detailText;

            this.updateDataIsInstalled = updateDataIsInstalled;
            this.updateDataRestartRequired = updateDataRestartRequired;
            this.updateDataID = updateDataID;
            this.updateDataGUID = updateDataGUID;
            this.updateDataBulletinID = updateDataBulletinID;
            this.updateDataKBID = updateDataKBID;
            this.updateDataType = updateDataType;

            this.UpdateDataInformationURL = UpdateDataInformationURL;
            this.UpdateDataDownloadURL = UpdateDataDownloadURL;

            this.type = EntryType.MBSA;
            if (referenceLink != null)
                this.referenceLink = referenceLink;
            else
                this.referenceLink = "";
            this.tableHeaderString = tableHeaderString;
            this.tableRowDataString = tableRowDataString;
            //this.louise = updateDataKBID;
        }

        public String getSeverityString()
        {
            if (severityString != null)
                return severityString;
            else
                return getSeverity().ToString();
        }

        public int getSeverity()
        {
            return severity;
        }
    }

    /// <summary>
    /// This is a class to store rows data in MBSA entry.
    /// </summary>
    class MBSARow
    {
        private String[] col;
        private String grade;
        private int colCounter;
        private const int MAXCOL = 4;

        public void setGrade(string grade) { this.grade = grade; }
        public void setCol(string col)
        {
            this.col[colCounter] = col;
            colCounter++;
        }

        public String getGrade() { return grade; }
        public String[] getCol() { return col; }

        public MBSARow()
        {
            colCounter = 0;
            col = new String[MAXCOL];
            grade = "";
        }
    }
}
