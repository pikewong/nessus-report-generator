using System;
using System.Xml;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportGenerator.ReportInput.InputParser
{

    /// <summary>
    /// This is the MBSAParser Class extends XmlParser.
    /// It is used to parse MBSA file and get useful data.
    /// </summary>
    class MBSAParser : XmlParser
    {

        #region // MBSA Parser Variables
        // Grade Lookup
        private String[] scoreLookup = {"",				// Check Not Performed
										"Medium",		// Unable to scan
										"High",			// Check failed (critical)
										"Low",			// Check failed (non-critical)
										"None",			// Best Practice
										"",				// Check passed
										"None",			// Check not performed
										"None",			// Additional Information
										""};			// Not approved

        // Severity Lookup
        private String[] severityLookup = {"None",		// nothing
										   "Low",		// Low
										   "Moderate",	// Moderate
										   "Important",	// Important
										   "Critical"};	// Critical

        private Dictionary<int, String> tableHeader = new Dictionary<int, string>(); // To make description
        private Dictionary<int, String> tableRow = new Dictionary<int, string>(); // To make description
        private int tableColCounter = 0;
        private bool isTableHeader = true;
        private String tempTableString = "";
        private String tempType = "";
        //private int tempCounter = 0;


        private int tableRowDataCounter = 0;
        private Dictionary<int, MBSARow> tableRowData = new Dictionary<int, MBSARow>();


        private string tempCheckID = "";
        private string tempCheckGrade = "";
        private string tempCheckType = "";
        private string tempCheckCat = "";
        private string tempCheckRank = "";
        private string tempCheckName = "";
        private string tempCheckURL1 = "";
        private string tempCheckURL2 = "";
        private string tempCheckGroupID = "";
        private string tempCheckGroupName = "";

        private string tempDetailText = "";

        private string tempUpdateDataIsInstalled = "";
        private string tempUpdateDataRestartRequired = "";
        private int tempUpdateDataSeverity = -1;
        private string tempUpdateDataID = "";
        private string tempUpdateDataGUID = "";
        private string tempUpdateDataBulletinID = "";
        private string tempUpdateDataKBID = "";
        private string tempUpdateDataType = "";

        private string tempUpdateDataInformationURL = "";
        private string tempUpdateDataDownloadURL = "";


        #endregion

        /// <summary>
        /// This is the startTag method.
        /// It is used to handle the start tag/self closed tag from the XML file.
        /// </summary>
        /// <param name="tag">xml start tag name</param>
        /// <param name="attributes">xml tag's attributes</param>
        protected override void startTag(string tag, Dictionary<string, string> attributes)
        {

            if (tag.CompareTo("SecScan") == 0)
            {
                this.tempIpList = attributes["IP"];
                elementStack.Push(tag);
            }
            else if (tag.CompareTo("Check") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("SecScan") == 0)
                {
                    if (attributes.ContainsKey("Grade") && attributes.ContainsKey("Name"))
                    {
                        tempCheckGrade = attributes["Grade"];
                        this.tempRiskFactor = RiskFactorFunction.getEnum(scoreLookup[int.Parse(attributes["Grade"])]);

                        this.tempPluginName = attributes["Name"];
                        this.tempCheckName = attributes["Name"];
                        elementStack.Push(tag);
                        if (this.tempRiskFactor != RiskFactor.NULL && this.tempRiskFactor != RiskFactor.NA)
                        {

                        }
                        else
                        {
                            this.tempRiskFactor = RiskFactor.NULL;
                        }
                    }
                    if (attributes.ContainsKey("ID"))
                        this.tempCheckID = attributes["ID"];
                    if (attributes.ContainsKey("Type"))
                        this.tempCheckType = attributes["Type"];
                    if (attributes.ContainsKey("Cat"))
                        this.tempCheckCat = attributes["Cat"];
                    if (attributes.ContainsKey("Rank"))
                        this.tempCheckRank = attributes["Rank"];
                    //if (attributes.ContainsKey("Name"))
                    //    this.tempCheckID = attributes["Name"];
                    if (attributes.ContainsKey("URL1"))
                        this.tempCheckURL1 = attributes["URL1"];
                    if (attributes.ContainsKey("URL2"))
                        this.tempCheckURL2 = attributes["URL2"];
                    if (attributes.ContainsKey("GroupID"))
                        this.tempCheckGroupID = attributes["GroupID"];
                    if (attributes.ContainsKey("GroupName"))
                        this.tempCheckGroupName = attributes["GroupName"];
                }
            }
            else if (tag.CompareTo("Advice") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("Check") == 0)
                {
                    elementStack.Push(tag);
                }
            }
            else if (tag.CompareTo("Detail") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("Check") == 0)
                {
                    //if (attributes.ContainsKey("text"))
                    //    tempDetailText = attributes["text"];
                    elementStack.Push(tag);
                }
            }
            else if (tag.CompareTo("UpdateData") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("Detail") == 0)
                {

                    if (attributes.ContainsKey("IsInstalled") &&
                        attributes.ContainsKey("RestartRequired") &&
                        attributes.ContainsKey("Severity"))
                    {

                        this.tempRiskFactor = RiskFactor.NULL;
                        elementStack.Push(tag);

                        if (attributes["IsInstalled"] == "false" ||
                            attributes["RestartRequired"] == "true")
                        {
                            this.tempUpdateDataIsInstalled = attributes["IsInstalled"];
                            this.tempUpdateDataRestartRequired = attributes["RestartRequired"];
                            this.tempUpdateDataSeverity = int.Parse(attributes["Severity"]);

                            this.tempRiskFactor = RiskFactorFunction.getEnum(severityLookup[int.Parse(attributes["Severity"])]);

                            if (tempRiskFactor != RiskFactor.NA)
                            {
                                tempPluginId = attributes["ID"];

                                //if (String.IsNullOrEmpty(tempPluginName)) {
                                //    tempPluginName = tempPluginId;
                                //}
                                //else {
                                //    tempPluginName = tempPluginId;
                                //}
                                tempPluginName = tempPluginId;
                                if (attributes["IsInstalled"] == "false")
                                {
                                    tempDescription = "The software update was not installed.";
                                }
                                else
                                {
                                    tempDescription = "Installation of the software update was not completed. You must restart your computer to finish the installation";
                                }
                            }
                        }
                    }

                    if (attributes.ContainsKey("ID"))
                        this.tempUpdateDataID = attributes["ID"];
                    if (attributes.ContainsKey("GUID"))
                        this.tempUpdateDataGUID = attributes["GUID"];
                    if (attributes.ContainsKey("BulletinID"))
                        this.tempUpdateDataBulletinID = attributes["BulletinID"];
                    if (attributes.ContainsKey("KBID"))
                        this.tempUpdateDataKBID = attributes["KBID"];
                    if (attributes.ContainsKey("Type"))
                        this.tempUpdateDataType = attributes["Type"];
                }
            }
            else if (tag.CompareTo("Title") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("UpdateData") == 0)
                {
                    elementStack.Push(tag);
                }
            }
            else if (tag.CompareTo("References") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("UpdateData") == 0)
                {
                    elementStack.Push(tag);
                }
            }
            else if (tag.CompareTo("BulletinURL") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("References") == 0)
                {
                    elementStack.Push(tag);
                }
            }
            else if (tag.CompareTo("Head") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("Detail") == 0)
                {
                    tableHeader = new Dictionary<int, string>();
                    tableColCounter = 0;
                    isTableHeader = true;
                    elementStack.Push(tag);
                }
            }
            else if (tag.CompareTo("Row") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("Detail") == 0)
                {

                    if (attributes.ContainsKey("Grade"))
                    {
                        //RiskFactor tempRF = RiskFactorFunction.getEnum(scoreLookup[int.Parse(attributes["Grade"])]);

                        //if (tempRiskFactor != RiskFactor.NULL &&
                        //    tempRiskFactor != RiskFactor.NA) {

                        //this.tempRiskFactor = tempRF;tableColCounter = 0;
                        if (tableRowData == null)
                            tableRowData = new Dictionary<int, MBSARow>();
                        tableRowDataCounter++;
                        tableRowData[tableRowDataCounter] = new MBSARow();
                        tableRowData[tableRowDataCounter].setGrade(attributes["Grade"]);

                        tableColCounter = 0;
                        isTableHeader = false;
                        elementStack.Push(tag);
                        //}
                    }
                }
            }
            else if (tag.CompareTo("Col") == 0)
            {
                if (elementStack.Count != 0 &&
                    //tempRiskFactor != RiskFactor.NULL &&
                    //tempRiskFactor != RiskFactor.NA &&
                   (elementStack.Peek().CompareTo("Row") == 0 ||
                    elementStack.Peek().CompareTo("Head") == 0))
                {

                    string tempTag = elementStack.Pop();
                    if (elementStack.Peek().CompareTo("Detail") == 0)
                    {
                        elementStack.Push(tempTag);
                        elementStack.Push(tag);
                    }
                    else
                    {
                        elementStack.Push(tempTag);
                    }
                }
            }
            else if (tag.CompareTo("SETTINGS") == 0)
            {
                elementStack.Push(tag);
            }
            else if (tag.CompareTo("OtherIDs") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("UpdateData") == 0)
                {

                    //Console.WriteLine(tag);
                    elementStack.Push(tag);
                }
            }
            else if (tag.CompareTo("OtherID") == 0)
            {
                if (elementStack.Count != 0 &&
                    elementStack.Peek().CompareTo("OtherIDs") == 0)
                {

                    if (attributes.ContainsKey("Type"))
                    {

                        switch (attributes["Type"])
                        {
                            case "CVE":
                                tempType = "CVE";
                                //Console.WriteLine(tag);
                                elementStack.Push(tag);
                                break;
                            case "BID":
                                tempType = "BID";
                                //Console.WriteLine(tag);
                                elementStack.Push(tag);
                                break;
                            case "OSVDB":
                                tempType = "OSVDB";
                                //Console.WriteLine(tag);
                                elementStack.Push(tag);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// This is the pushContent method.
        /// It is used to handle the content between start tag and end tag from the XML file.
        /// </summary>
        /// <param name="content">the content between start tag an end tag from the XML file</param>
        protected override void pushContent(string content)
        {
            if (elementStack.Count != 0)
            {
                if (elementStack.Peek().CompareTo("Advice") == 0)
                {
                    tempDescription += content;
                }
                else if (elementStack.Peek().CompareTo("Title") == 0)
                {
                    if (String.IsNullOrEmpty(tempPluginName))
                    {
                        tempPluginName += content;
                    }
                    else
                    {
                        tempPluginName += " " + content;
                    }
                }
                else if (elementStack.Peek().CompareTo("BulletinURL") == 0)
                {
                    tempReferenceLink += content;
                }
                else if (elementStack.Peek().CompareTo("InformationURL") == 0)
                {
                    tempUpdateDataInformationURL += content;
                }
                else if (elementStack.Peek().CompareTo("DownloadURL") == 0)
                {
                    tempUpdateDataDownloadURL += content;
                }
                else if (elementStack.Peek().CompareTo("Col") == 0)
                {
                    if (isTableHeader)
                    {
                        tableHeader[tableColCounter] = content;
                        tableColCounter++;
                    }
                    else
                    {
                        tableRowData[tableRowDataCounter].setCol(content);
                        tableRow[tableColCounter] = content;
                        tableColCounter++;
                    }
                }
                else if (elementStack.Peek().CompareTo("OtherID") == 0)
                {
                    if (!String.IsNullOrEmpty(tempType))
                    {
                        switch (tempType)
                        {
                            case "CVE":
                                tempCveList.Add(content);
                                break;
                            case "BID":
                                tempBidList.Add(content);
                                break;
                            case "OSVDB":
                                tempOsvdbList.Add(content);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This is the endTag method.
        /// It is used to handle the end tag from the XML file.
        /// </summary>
        /// <param name="tag">xml end tag name</param>
        protected override void endTag(string tag)
        {

            if (elementStack.Count != 0)
            {
                if ((tag.CompareTo("Check") == 0 && elementStack.Peek().CompareTo("Check") == 0) ||
                    (tag.CompareTo("UpdateData") == 0 && elementStack.Peek().CompareTo("UpdateData") == 0))
                {
                    if (tempPluginName == "")
                    {
                        elementStack.Pop();
                        initialize();
                        return;
                    }
                    elementStack.Pop();

                    //if (this.tempRiskFactor == RiskFactor.NULL || this.tempRiskFactor == RiskFactor.NA) {
                    //    initialize();
                    //    return;
                    //}

                    if (!String.IsNullOrEmpty(tempTableString))
                    {
                        while (tempTableString[tempTableString.Length - 1] == '\n')
                        {
                            tempTableString = tempTableString.Substring(0, tempTableString.Length - 1);
                        }
                        tempDescription += "\nTable: \n" + tempTableString;
                    }

                    MBSADataEntry entry = null;
                    //if (String.IsNullOrEmpty(tempReferenceLink)) {
                    entry = new MBSADataEntry(tempPluginName,
                                              tempIpList,
                                              tempDescription,
                                              tempUpdateDataSeverity,
                                              this.tempRiskFactor,
                                              tempCveList,
                                              tempBidList,
                                              tempOsvdbList,
                                              tempFileName,

                                              tempCheckID,
                                              tempCheckGrade,
                                              tempCheckType,
                                              tempCheckCat,
                                              tempCheckRank,
                                              tempCheckName,
                                              tempCheckURL1,
                                              tempCheckURL2,
                                              tempCheckGroupID,
                                              tempCheckGroupName,

                                              tempDetailText,

                                              tempUpdateDataIsInstalled,
                                              tempUpdateDataRestartRequired,
                                              tempUpdateDataID,
                                              tempUpdateDataGUID,
                                              tempUpdateDataBulletinID,
                                              tempUpdateDataKBID,
                                              tempUpdateDataType,

                                              tableHeader,
                                              tableRowData,

                                              tempUpdateDataInformationURL,
                                              tempUpdateDataDownloadURL,
                                              tempReferenceLink);

                    //else {
                    //    entry = new MBSADataEntry(tempPluginName,
                    //                              tempIpList,
                    //                              tempDescription,
                    //                              tempUpdateDataSeverity,
                    //                              this.tempRiskFactor,
                    //                              tempReferenceLink,
                    //                              tempCveList,
                    //                              tempBidList,
                    //                              tempOsvdbList);
                    //}

                    if (entry.isValid())
                    {
                        tempRecord.mbsaAddEntry(entry);
                        //tempCounter++;
                        //String tempString = "";
                        //tempString += "pluginName: " + tempPluginName + "\n";
                        //tempString += "hostName: " + hostName + "\n";
                        //tempString += "description: " + description + "\n";
                        //tempString += "riskFactor: " + RiskFactorFunction.getEnumString(this.defaultRiskFactor) + "\n";
                        //tempString += "referenceLink: " + tempReferenceLink + "\n";
                        //tempString += "cveList: " + entry.getCve() + "\n";
                        //tempString += "bidList: " + entry.getBid() + "\n";
                        //tempString += "osvdbList: " + entry.getOsvdb() + "\n";
                        //tempString += "\n" + "\n";
                        //MessageBox.Show(tempCounter.ToString() + "\n" + tempString);
                    }
                    initialize();
                }
                else if (tag.CompareTo("Detail") == 0 &&
                         elementStack.Peek().CompareTo("Detail") == 0)
                {
                    //tableHeader.Clear();
                    elementStack.Pop();
                }
                else if (tag.CompareTo("Head") == 0 &&
                         elementStack.Peek().CompareTo("Head") == 0)
                {
                    if (tableHeader.Count != 0)
                    {
                        for (int i = 0; i < tableHeader.Count; i++)
                        {
                            if (i != 0)
                            {
                                tempTableString += ",\t";
                            }
                            tempTableString += tableHeader[i];
                        }
                        tempTableString += "\n";
                    }
                    elementStack.Pop();
                    //tableHeader.Clear();   //clear at end of an entry
                }
                else if (tag.CompareTo("Row") == 0 &&
                         elementStack.Peek().CompareTo("Row") == 0)
                {
                    elementStack.Pop();
                    for (int i = 0; i < tableRow.Count; i++)
                    {
                        if (i != 0)
                        {
                            tempTableString += ",\t";
                        }
                        tempTableString += tableRow[i];
                    }
                    tempTableString += "\n";
                    tableRow.Clear();


                }
                else if (elementStack.Peek().CompareTo(tag) == 0)
                {
                    elementStack.Pop();
                }
            }
        }

        /// <summary>
        /// This is the initialize method.
        /// It is used to initialize all variables in this parser after a DataEntry is stored
        /// to the Record.
        /// </summary>
        private void initialize()
        {
            this.tempRiskFactor = RiskFactor.NULL;
            tempPluginName = "";
            tempDescription = "";
            tempReferenceLink = "";
            tableRow.Clear();
            tableColCounter = 0;
            isTableHeader = true;
            tempTableString = "";
            tempCveList = new List<string>();
            tempBidList = new List<string>();
            tempOsvdbList = new List<string>();
            tempType = "";
            tempCheckID = "";
            tempCheckType = "";
            tempCheckCat = "";
            tempCheckGrade = "";
            tempCheckRank = "";
            tempCheckName = "";
            tempCheckURL1 = "";
            tempCheckURL2 = "";
            tempCheckGroupID = "";
            tempCheckGroupName = "";

            tempDetailText = "";

            tempUpdateDataIsInstalled = "";
            tempUpdateDataRestartRequired = "";
            tempUpdateDataSeverity = -1;
            tempUpdateDataID = "";
            tempUpdateDataGUID = "";
            tempUpdateDataBulletinID = "";
            tempUpdateDataKBID = "";
            tempUpdateDataType = "";

            tempUpdateDataInformationURL = "";
            tempUpdateDataDownloadURL = "";

            tableRowData = null;
            tableRowDataCounter = 0;

            tableHeader = null;
        }
    }
}
