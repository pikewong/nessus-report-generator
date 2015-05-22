using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using ReportGenerator.Record;
using System.Windows.Forms;


namespace ReportGenerator.ReportOutput.OutputFormatter {
	
	/// <summary>
	/// This is the XlsxOutputFormater Class.
	/// It is used to create the xlsx report output.
	/// </summary>
	class XlsxOutputFormater : OutputDefault{

		// Variables
		private Record.Record record = null;

		/// <summary>
		/// This is the output method.
		/// It is used to output the file from given path and also given Record.
		/// </summary>
		/// <param name="path">the file path for output</param>
		/// <param name="record">the Record for output</param>
        public override void output(string path, ref Record.Record record)
        {
			this.record = record;

            bool isRawRecordOuput = record.getIsOutputRecord();
            Record.DataEntry.EntryType outputEntryType = record.getOutputEntryType();
			// Create a Wordprocessing document.
			using (SpreadsheetDocument package = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook)) {

				#region // print HIGH/MEDIUM/LOW/NONE Findings
				// Add a new workbook part
				WorkbookPart wbPart = package.AddWorkbookPart();
				wbPart.Workbook = new Workbook();

				// Add a new worksheet part
				WorksheetPart wsPart = package.WorkbookPart.AddNewPart<WorksheetPart>();
				
				//Create the Spreadsheet DOM
				Worksheet worksheet = new Worksheet();
				
				SheetData sheetData = new SheetData();
                if (!isRawRecordOuput)
                {
                    String[] stringArray = {"Plugin Name",
										"Hosts Affected",
										"Description",
									    "Impact",
									    "Risk Level",
									    "Recommendations",
									    "Reference (CVE)",
									    "Reference (BID)",
									    "Reference (OSVDB)",
									    "Reference Link"};
                    sheetData.Append(buildRow(stringArray));
                }
                else
                {
                    if (outputEntryType == DataEntry.EntryType.Acunetix)
                    {
                        String[] stringArray = {"Plugin Name",
										    "Hosts Affected",
										    "Description",
									        "Impact",
									        "Risk Level",
									        "Recommendations",
                                            "File Name",
                                            "SubDomain",
                                            "SubDirectory",
                                            "Department",
                                            "Affected Item ",
                                            "Affected Item Link",
                                            "Affected Item Detail",
                                            "Affected Item Request",
                                            "Affected Item Response",
                                            "ModuleName",
                                            "IsFalsePositive" ,
                                            "AOP_SourceFile" ,
                                            "AOP_SourceLine" ,
                                            "AOP_Additional" ,
                                            "DetailedInformation",
                                            "AcunetixType" ,
                                            "Reference"
                                            };
                        sheetData.Append(buildRow(stringArray));
                    }
                    else if (outputEntryType == DataEntry.EntryType.NMAP){
                        String[] stringArray = {"Plugin Name",
										    "Hosts Affected",
										    "Description",
									        "Risk Level",
                                            "File Name",
                                            "entryType" ,

                                            "OS" ,
                                            "OSDetail" ,
                                            "openPortList" ,
                                            "closedPortList" ,
                                            "filteredPortList" ,
                                            "unknownPortList" 
                                            };
                        sheetData.Append(buildRow(stringArray));
                    }
                    else if (outputEntryType == DataEntry.EntryType.MBSA)
                    {
                        String[] stringArray = {"Plugin Name",
										"Hosts Affected",
										"Description",
									    "Impact",
									    "Risk Level",
									    "Recommendations",
                                         "bidlist" ,
                                         "cvelist" ,
                                         "osvdblist" ,
                                         "referenceLink" ,
                                         "fileName" ,
                                         "entryType" ,
                                     

                                         "checkID" ,
                                         "checkGrade" ,
                                         "checkType",
                                         "checkCat" ,
                                         "checkRank" ,
                                         "checkName" ,
                                         "checkURL1" ,
                                         "checkURL2" ,
                                         "checkGroupID" ,
                                         "checkGroupName" ,
                                         "detailText" ,
                                         "updateDataIsInstalled" ,
                                         "updateDataRestartRequired" ,
                                         "updateDataID" ,
                                         "updateDataGUID" ,
                                         "updateDataBulletinID" ,
                                         "updateDataKBID" ,
                                         "updateDataType" ,
                                         "UpdateDataInformationURL" ,
                                         "UpdateDataDownloadURL" ,
                                         "severity" ,
                                         "tableHeader" ,
                                         "tableRowData" 
                                        };
                        sheetData.Append(buildRow(stringArray));
                    }
                    else if (outputEntryType == DataEntry.EntryType.NESSUS)
                    {
                        String[] stringArray = {"Plugin Name",
										    "Hosts Affected",
										    "Description",
									        "Impact",
									        "Risk Level",
									        "Recommendations",
                                            "bidlist" ,
                                             "cvelist" ,
                                             "osvdblist" ,
                                             "referenceLink" ,
                                             "fileName" ,
                                             "entryType" ,

                                             "port" ,
                                             "protocol" ,
                                             "svc_name" ,
                                             "pluginFamily" ,
                                             "plugin_publication_date" ,
                                             "plugin_modification_date" ,
                                             "cvss_vector" ,
                                             "cvss_base_score " ,
                                             "plugin_output" ,
                                             "plugin_version " ,
                                             "see_alsoList" ,
                                             "pluginID" ,
                                             "microSoftID" ,
                                             "severity"
                                            };
                        sheetData.Append(buildRow(stringArray));
                    }
                }
				worksheet.Append(sheetData);

                if (!isRawRecordOuput)
                {
                    printHighRisk(sheetData);
                    printMediumRisk(sheetData);
                    printLowRisk(sheetData);
                    printNoneRisk(sheetData);

                #endregion

                    #region // print Missing Hotfix Findings
                    if (Program.state.panelOutputSelect_isOutputHotfix)
                    {
                        printHotfix(sheetData);
                    }
                    #endregion

                    #region // print Open Port Findings
                    if (Program.state.panelOutputSelect_isOutputOpenPort)
                    {
                        printOpenPort(sheetData);
                    }
                    #endregion
                }
                else
                {
                    if (outputEntryType == DataEntry.EntryType.Acunetix)
                        printAcunetixExcel(sheetData);
                    else if (outputEntryType==DataEntry.EntryType.NMAP)
                        printNmapExcel(sheetData);
                    else if (outputEntryType==DataEntry.EntryType.NESSUS)
                        printNessusExcel(sheetData);
                    else if (outputEntryType==DataEntry.EntryType.MBSA)
                        printMbsaExcel(sheetData);
                }
				wsPart.Worksheet = worksheet;

				// Save changes to the spreadsheet part
				wsPart.Worksheet.Save();

				// create the worksheet to workbook relation
				wbPart.Workbook.AppendChild(new Sheets());
				wbPart.Workbook.GetFirstChild<Sheets>().AppendChild(new Sheet() {
					Id = wbPart.GetIdOfPart(wsPart),
					SheetId = 1,
					Name = "Findings"
				});
				wbPart.Workbook.Save();
			}
		}

        public void printAcunetixExcel(SheetData sheetData)
        {
            foreach (DataEntry entry in record.getWholeRawEntriesWithNA())
            {
                if (entry.getEntryType() == DataEntry.EntryType.Acunetix)
                {
                    List<AffectedItem> affectedItemList = ((AcunetixDataEntry)entry).getAffectedItemList();
                    foreach (AffectedItem item in affectedItemList)
                        sheetData.Append(buildRow(buildAcunetixStringArray(entry, entry.getRiskFactor(), item)));
                }
            }
        }
        public void printNmapExcel(SheetData sheetData)
        {
            foreach (DataEntry entry in record.getWholeRawEntriesWithNA())
            {
                if (entry.getEntryType() == DataEntry.EntryType.NMAP)
                {     
                    sheetData.Append(buildRow(buildNmapStringArray(entry)));
                }
            }
        }
        public void printNessusExcel(SheetData sheetData)
        {
            foreach (DataEntry entry in record.getWholeRawEntriesWithNA())
            {
                if (entry.getEntryType() == DataEntry.EntryType.NESSUS)
                {
                    sheetData.Append(buildRow(buildNessusStringArray(entry)));
                }
            }
        }
        public void printMbsaExcel(SheetData sheetData)
        {
            foreach (DataEntry entry in record.getWholeRawEntriesWithNA())
            {
                if (entry.getEntryType() == DataEntry.EntryType.MBSA)
                {
                    sheetData.Append(buildRow(buildMbsaStringArray(entry)));
                }
            }
        }
		/// <summary>
		/// This is the printHighRisk method.
		/// It is used to output the high risk findings.
		/// </summary>
		/// <param name="sheetData">the location where the data should append to</param>
		public void printHighRisk(SheetData sheetData) {
			foreach (DataEntry entry in record.getHighRiskEntriesWithoutHotfix()) {
                if (entry.getIp().Replace(" ", "") != "")
                    sheetData.Append(buildRow(buildStringArray(entry, RiskFactor.HIGH)));
                else
                    continue;
			}
		}

		/// <summary>
		/// This is the printMediumRisk method.
		/// It is used to output the medium risk findings.
		/// </summary>
		/// <param name="sheetData">the location where the data should append to</param>
		public void printMediumRisk(SheetData sheetData) {
			foreach (DataEntry entry in record.getMediumRiskEntriesWithoutHotfix()) {
                if (entry.getIp().Replace(" ", "") != "")
                    sheetData.Append(buildRow(buildStringArray(entry, RiskFactor.MEDIUM)));
                else
                    continue;
			}
		}

		/// <summary>
		/// This is the printLowRisk method.
		/// It is used to output the low risk findings.
		/// </summary>
		/// <param name="sheetData">the location where the data should append to</param>
		public void printLowRisk(SheetData sheetData) {
			foreach (DataEntry entry in record.getLowRiskEntriesWithoutHotfix()) {
                if (entry.getIp().Replace(" ", "") != "")
                    sheetData.Append(buildRow(buildStringArray(entry, RiskFactor.LOW)));
                else
                    continue;
			}
		}

		/// <summary>
		/// This is the printNoneRisk method.
		/// It is used to output the none risk (AOI (Area of Improvement)) findings.
		/// </summary>
		/// <param name="sheetData">the location where the data should append to</param>
		public void printNoneRisk(SheetData sheetData) {
			foreach (DataEntry entry in record.getNoneRiskEntriesWithoutHotfix()) {
                if (entry.getIp().Replace(" ", "") != "")
                    sheetData.Append(buildRow(buildStringArray(entry, RiskFactor.NONE)));
                else
                    continue;
			}
		}

		/// <summary>
		/// This is the printHotfix method.
		/// It is used to output the missing hotfix findings.
		/// </summary>
		/// <param name="sheetData">the location where the data should append to</param>
		public void printHotfix(SheetData sheetData) {
			List<DataEntry> tempEntries = new Hotfix(record).getHotfixList();
			foreach (DataEntry entry in tempEntries) {
                if (entry.getIp().Replace(" ", "") != "")
                    sheetData.Append(buildRow(buildStringArray(entry, entry.getRiskFactor())));
                else
                    continue;
			}
		}

		/// <summary>
		/// This is the printOpenPort method.
		/// It is used to output the open port findings.
		/// </summary>
		/// <param name="sheetData">the location where the data should append to</param>
		public void printOpenPort(SheetData sheetData) {
			foreach (DataEntry entry in record.getOpenPort().Values) {
                if (entry.getIp().Replace(" ", "") != "")
                    sheetData.Append(buildRow(new String[] { "Open Port Findings", 
														 entry.getIp(),
														 entry.getDescription() }));
                else
                    continue;
			}
		}

		/// <summary>
		/// This is the buildRow method.
		/// It is used to build a Row and ready to append to the SheetData from
		/// given string array.
		/// </summary>
		/// <param name="stringArray">the string array being transformed to a xlsx row</param>
		/// <returns>a xlsx row being append to the xlsx sheet</returns>
		private Row buildRow(String[] stringArray) {
			Row row = new Row();
			foreach (String s in stringArray) {
				row.Append(new Cell() {
					DataType = new EnumValue<CellValues>(CellValues.String),
					CellValue = new CellValue() {
						Text = s
					}
				});
			}
			return row;
		}

		/// <summary>
		/// This is the buildStringArray method.
		/// It is used to build an array of String from given entry and riskFactor.
		/// </summary>
		/// <param name="entry">the DataEntry being transformed to a string array</param>
		/// <param name="riskFactor">the RiskFactor of the entry</param>
		/// <returns>a string array being transformed to a xlsx row</returns>
		private String[] buildStringArray(DataEntry entry, RiskFactor riskFactor) {
			String[] stringArray = new String[10];

			// Plugin Name
			stringArray[0] = entry.getPluginName();

			// Hosts Affected
			stringArray[1] = entry.getIp();


			// Description
			stringArray[2] = entry.getDescription();

			// Impact
			stringArray[3] = entry.getImpact();

			// Risk Level
			stringArray[4] = RiskFactorFunction.getEnumString(riskFactor);

			// Recommendations
			stringArray[5] = entry.getRecommendation();

			// Reference
			// CVE
			String tempString = "N/A";
			if (entry.getCve() != null) {
				tempString = entry.getCve();
			}
			stringArray[6] = tempString;

			// BID
			tempString = "N/A";
			if (entry.getBid() != null) {
				tempString = entry.getBid();
			}
			stringArray[7] = tempString;

			// OSVDB
			tempString = "N/A";
			if (entry.getOsvdb() != null) {
				tempString = entry.getOsvdb();
			}
			stringArray[8] = tempString;

			// Reference Link
			stringArray[9] = entry.getReferenceLink();

			return stringArray;
		}

        private String[] buildAcunetixStringArray(DataEntry entry, RiskFactor riskFactor, AffectedItem item)
        {
            String[] stringArray = new String[23];

            // Plugin Name
            stringArray[0] = entry.getPluginName();

            // Hosts Affected
            stringArray[1] = entry.getIp();

            // Description
            stringArray[2] = entry.getDescription();

            // Impact
            stringArray[3] = entry.getImpact();

            // Risk Level
            stringArray[4] = RiskFactorFunction.getEnumString(riskFactor);

            // Recommendations
            stringArray[5] = entry.getRecommendation();

            stringArray[6] = entry.getFileName();

            stringArray[7] = ((AcunetixDataEntry)entry).getSubDomain();

            stringArray[8] = item.getSubDirectory();

            stringArray[9] =item.getDepartment();
            stringArray[10] =item.getName();

            stringArray[11] = item.getLink();

            stringArray[12] = item.getDetail();
            stringArray[13] = item.getRequest();
            stringArray[14] = item.getResponse();
            stringArray[15] = ((AcunetixDataEntry)entry).getModuleName();
            stringArray[16] = ((AcunetixDataEntry)entry).getIsFalsePositive();
            stringArray[17] = ((AcunetixDataEntry)entry).getAOP_SourceFile();
            stringArray[18] = ((AcunetixDataEntry)entry).getAOP_SourceLine();
            stringArray[19] = ((AcunetixDataEntry)entry).getAOP_Additional();
            stringArray[20] = ((AcunetixDataEntry)entry).getDetailedInformation();
            stringArray[21] = ((AcunetixDataEntry)entry).getAcunetixType();
            stringArray[22] = ((AcunetixDataEntry)entry).getAcunetixReferenceListString();
            return stringArray;
        }

        private String[] buildNmapStringArray(DataEntry entry)
        {
            String[] stringArray = new String[12];

            // Plugin Name
            stringArray[0] = entry.getPluginName();

            // Hosts Affected
            stringArray[1] = entry.getIp();

            // Description
            stringArray[2] = entry.getDescription();

            stringArray[3] = RiskFactorFunction.getEnumString(entry.getRiskFactor());

            stringArray[4] = entry.getFileName();

            stringArray[5] = entry.getEntryTypeString();

            stringArray[6] = ((NmapDataEntry)entry).getOS();

            stringArray[7] = ((NmapDataEntry)entry).getOSDetail();

            stringArray[8] = ((NmapDataEntry)entry).getOpenPortListString();

            stringArray[9] = ((NmapDataEntry)entry).getClosedPortListString();

            stringArray[10] = ((NmapDataEntry)entry).getFilteredPortListString();

            stringArray[11] = ((NmapDataEntry)entry).getUnknownPortListString();

            return stringArray;
        }

        private String[] buildMbsaStringArray(DataEntry entry)
        {
            String[] stringArray = new String[35];

            // Plugin Name
            stringArray[0] = entry.getPluginName();

            // Hosts Affected
            stringArray[1] = entry.getIp();

            // Description
            stringArray[2] = entry.getDescription();

            // Impact
            stringArray[3] = entry.getImpact();

            // Risk Level
            stringArray[4] = RiskFactorFunction.getEnumString(entry.getRiskFactor());

            // Recommendations
            stringArray[5] = entry.getRecommendation();

            stringArray[6] = entry.getBid();


            stringArray[7] = entry.getCve();

            stringArray[8] = entry.getOsvdb();

            stringArray[9] = entry.getReferenceLink();
            stringArray[10] = entry.getFileName();

            stringArray[11] = entry.getEntryTypeString();

            stringArray[12] = ((MBSADataEntry)entry).getCheckID();
            stringArray[13] = ((MBSADataEntry)entry).getCheckGrade();
            stringArray[14] = ((MBSADataEntry)entry).getCheckType();
            stringArray[15] = ((MBSADataEntry)entry).getCheckCat();
            stringArray[16] = ((MBSADataEntry)entry).getCheckRank();
            stringArray[17] = ((MBSADataEntry)entry).getCheckName();
            stringArray[18] = ((MBSADataEntry)entry).getCheckURL1();
            stringArray[19] = ((MBSADataEntry)entry).getCheckURL2();
            stringArray[20] = ((MBSADataEntry)entry).getCheckGroupID();
            stringArray[21] = ((MBSADataEntry)entry).getCheckGroupName();
            stringArray[22] = ((MBSADataEntry)entry).getDetailText();
            stringArray[23] = ((MBSADataEntry)entry).getUpdateDataIsInstalled();
            stringArray[24] = ((MBSADataEntry)entry).getUpdateDataRestartRequired();
            stringArray[25] = ((MBSADataEntry)entry).getUpdateDataID();
            stringArray[26] = ((MBSADataEntry)entry).getUpdateDataGUID();
            stringArray[27] = ((MBSADataEntry)entry).getUpdateDataBulletinID();
            stringArray[28] = ((MBSADataEntry)entry).getUpdateDataKBID();
            stringArray[29] = ((MBSADataEntry)entry).getUpdateDataType();
            stringArray[30] = ((MBSADataEntry)entry).getUpdateDataInformationURL();
            stringArray[31] = ((MBSADataEntry)entry).getUpdateDataDownloadURL();
            stringArray[32] = ((MBSADataEntry)entry).getSeverityString();
            stringArray[33] = ((MBSADataEntry)entry).getTableHeaderString();
            stringArray[34] = ((MBSADataEntry)entry).getTableRowDataString();
            return stringArray;
        }

        private String[] buildNessusStringArray(DataEntry entry)
        {
            String[] stringArray = new String[26];

            // Plugin Name
            stringArray[0] = entry.getPluginName();

            // Hosts Affected
            stringArray[1] = entry.getIp();

            // Description
            stringArray[2] = entry.getDescription();

            // Impact
            stringArray[3] = entry.getImpact();

            // Risk Level
            stringArray[4] = RiskFactorFunction.getEnumString(entry.getRiskFactor());

            // Recommendations
            stringArray[5] = entry.getRecommendation();

            stringArray[6] = entry.getBid();


            stringArray[7] = entry.getCve();

            stringArray[8] = entry.getOsvdb();

            stringArray[9] = entry.getReferenceLink();
            stringArray[10] = entry.getFileName();

            stringArray[11] = entry.getEntryTypeString();

            stringArray[12] = ((NessusDataEntry)entry).getPort();
            stringArray[13] = ((NessusDataEntry)entry).getProtocol();
            stringArray[14] = ((NessusDataEntry)entry).getSvc_name();
            stringArray[15] = ((NessusDataEntry)entry).getPluginFamily();
            stringArray[16] = ((NessusDataEntry)entry).getPlugin_publication_date();
            stringArray[17] = ((NessusDataEntry)entry).getPlugin_modification_date();
            stringArray[18] = ((NessusDataEntry)entry).getCvss_vector();
            stringArray[19] = ((NessusDataEntry)entry).getCvss_base_score();
            stringArray[20] = ((NessusDataEntry)entry).getPlugin_output();
            stringArray[21] = ((NessusDataEntry)entry).getPlugin_version();
            stringArray[22] = ((NessusDataEntry)entry).getSee_also();
            stringArray[23] = ((NessusDataEntry)entry).getPluginID();
            stringArray[24] = ((NessusDataEntry)entry).getMicrosoftID();
            stringArray[25] = ((NessusDataEntry)entry).getSeverityString();

            return stringArray;
        }


        public void PuttingRawDataIntoExcelInPanelRecordEdit(string path)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
            {

                // Add a new workbook part
                WorkbookPart wbPart = package.AddWorkbookPart();
                wbPart.Workbook = new Workbook();

                // Add a new worksheet part
                WorksheetPart wsPart = package.WorkbookPart.AddNewPart<WorksheetPart>();

                //Create the Spreadsheet DOM
                Worksheet worksheet = new Worksheet();


                SheetData sheetData = new SheetData();

                String[] stringArray = {"Plugin Name",
										"Hosts Affected",
										"Description",
									    "pulginoutput"};
                sheetData.Append(buildRow(stringArray));

                worksheet.Append(sheetData);


                Program.state.panelRecordEdit_recordDatabaser.FromRawDatabaseToExcel(sheetData);

                wsPart.Worksheet = worksheet;

                // Save changes to the spreadsheet part
                wsPart.Worksheet.Save();

                // create the worksheet to workbook relation
                wbPart.Workbook.AppendChild(new Sheets());
                wbPart.Workbook.GetFirstChild<Sheets>().AppendChild(new Sheet()
                {
                    Id = wbPart.GetIdOfPart(wsPart),
                    SheetId = 1,
                    Name = "Findings"
                });
                wbPart.Workbook.Save();



            }
        }





	}
}
