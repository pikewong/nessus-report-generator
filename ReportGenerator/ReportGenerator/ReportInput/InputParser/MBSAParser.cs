using System;
using System.Xml;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportGenerator.ReportInput.InputParser {
	class MBSAParser : XmlParser {

		#region MBSA Parser Variables
		// Grade Lookup
		private String[] scoreLookup = {"",				// Check Not Performed
										"Medium",		// Unable to scan
										"High",			// Check failed (critical)
										"Low",			// Check failed (non-critical)
										"None",			// Best Practice"
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

		private Dictionary<int, String> tableHeader = new Dictionary<int, string>();
		private Dictionary<int, String> tableRow = new Dictionary<int, string>();
		private int tableColCounter = 0;
		private bool isTableHeader = true;
		private String tempTableString = "";
		private String tempType = "";
		//private int tempCounter = 0;
		#endregion

		protected override void startTag(string tag, Dictionary<string, string> attributes) {

			if (tag.CompareTo("SecScan") == 0) {
				this.tempIpList = attributes["IP"];
				elementStack.Push(tag);
			}
			else if (tag.CompareTo("Check") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("SecScan") == 0) {
					if (attributes.ContainsKey("Grade") && attributes.ContainsKey("Name")) {

						this.tempRiskFactor = RiskFactorFunction.getEnum(scoreLookup[int.Parse(attributes["Grade"])]);

						if (this.tempRiskFactor != RiskFactor.NULL && this.tempRiskFactor != RiskFactor.NA) {
							this.tempPluginName = attributes["Name"];
							elementStack.Push(tag);
						}
						else {
							this.tempRiskFactor = RiskFactor.NULL;
						}
					}
				}
			}
			else if (tag.CompareTo("Advice") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("Check") == 0) {
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("Detail") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("Check") == 0) {
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("UpdateData") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("Detail") == 0) {

					if (attributes.ContainsKey("IsInstalled") &&
						attributes.ContainsKey("RestartRequired") &&
						attributes.ContainsKey("Severity")) {

						this.tempRiskFactor = RiskFactor.NULL;
						elementStack.Push(tag);

						if (attributes["IsInstalled"] == "false" ||
							attributes["RestartRequired"] == "true") {

							this.tempRiskFactor = RiskFactorFunction.getEnum(severityLookup[int.Parse(attributes["Severity"])]);

							if (tempRiskFactor != RiskFactor.NA) {
								tempPluginId = attributes["ID"];

								if (String.IsNullOrEmpty(tempPluginName)) {
									tempPluginName = tempPluginId;
								}
								else {
									tempPluginName = tempPluginId;
								}

								if (attributes["IsInstalled"] == "false") {
									tempDescription = "The software update was not installed.";
								}
								else {
									tempDescription = "Installation of the software update was not completed. You must restart your computer to finish the installation";
								}
							}
						}
					}
				}
			}
			else if (tag.CompareTo("Title") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("UpdateData") == 0) {
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("References") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("UpdateData") == 0) {
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("BulletinURL") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("References") == 0) {
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("Head") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("Detail") == 0) {
					tableHeader.Clear();
					tableColCounter = 0;
					isTableHeader = true;
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("Row") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("Detail") == 0) {

					if (attributes.ContainsKey("Grade")) {
						RiskFactor tempRF = RiskFactorFunction.getEnum(scoreLookup[int.Parse(attributes["Grade"])]);

						if (tempRiskFactor != RiskFactor.NULL &&
							tempRiskFactor != RiskFactor.NA) {

							this.tempRiskFactor = tempRF;
							tableColCounter = 0;
							isTableHeader = false;
							elementStack.Push(tag);
						}
					}
				}
			}
			else if (tag.CompareTo("Col") == 0) {
				if (elementStack.Count != 0 &&
					tempRiskFactor != RiskFactor.NULL &&
					tempRiskFactor != RiskFactor.NA &&
				   (elementStack.Peek().CompareTo("Row") == 0 ||
					elementStack.Peek().CompareTo("Head") == 0)) {

					string tempTag = elementStack.Pop();
					if (elementStack.Peek().CompareTo("Detail") == 0) {
						elementStack.Push(tempTag);
						elementStack.Push(tag);
					}
					else {
						elementStack.Push(tempTag);
					}
				}
			}
			else if (tag.CompareTo("SETTINGS") == 0) {
				elementStack.Push(tag);
			}
			else if (tag.CompareTo("OtherIDs") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("UpdateData") == 0) {

					//Console.WriteLine(tag);
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("OtherID") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("OtherIDs") == 0) {

					if (attributes.ContainsKey("Type")) {

						switch (attributes["Type"]) {
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

		protected override void pushContent(string content) {
			if (elementStack.Count != 0) {
				if (elementStack.Peek().CompareTo("Advice") == 0) {
					tempDescription += content;
				}
				else if (elementStack.Peek().CompareTo("Title") == 0) {
					if (String.IsNullOrEmpty(tempPluginName)) {
						tempPluginName += content;
					}
					else {
						tempPluginName += " " + content;
					}
				}
				else if (elementStack.Peek().CompareTo("BulletinURL") == 0) {
					tempReferenceLink += content;
				}
				else if (elementStack.Peek().CompareTo("Col") == 0) {
					if (isTableHeader) {
						tableHeader[tableColCounter] = content;
						tableColCounter++;
					}
					else {
						tableRow[tableColCounter] = content;
						tableColCounter++;
					}
				}
				else if (elementStack.Peek().CompareTo("OtherID") == 0) {
					if (!String.IsNullOrEmpty(tempType)) {
						switch (tempType) {
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

		protected override void endTag(string tag) {

			if (elementStack.Count != 0) {
				if ((tag.CompareTo("Check") == 0 && elementStack.Peek().CompareTo("Check") == 0) ||
					(tag.CompareTo("UpdateData") == 0 && elementStack.Peek().CompareTo("UpdateData") == 0)) {

					elementStack.Pop();

					if (this.tempRiskFactor == RiskFactor.NULL || this.tempRiskFactor == RiskFactor.NA) {
						initialize();
						return;
					}

					if (!String.IsNullOrEmpty(tempTableString)) {
						while (tempTableString[tempTableString.Length - 1] == '\n') {
							tempTableString = tempTableString.Substring(0, tempTableString.Length - 1);
						}
						tempDescription += "\nTable: \n" + tempTableString;
					}

					MBSADataEntry entry = null;
					if (String.IsNullOrEmpty(tempReferenceLink)) {
						entry = new MBSADataEntry(tempPluginName,
												  tempIpList,
												  tempDescription,
												  1,
												  this.tempRiskFactor,
												  tempCveList,
												  tempBidList,
												  tempOsvdbList);
					}
					else {
						entry = new MBSADataEntry(tempPluginName,
												  tempIpList,
												  tempDescription,
												  1,
												  this.tempRiskFactor,
												  tempReferenceLink,
												  tempCveList,
												  tempBidList,
												  tempOsvdbList);
					}

					if (entry.isValid()) {
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
						 elementStack.Peek().CompareTo("Detail") == 0) {
					tableHeader.Clear();
					elementStack.Pop();
				}
				else if (tag.CompareTo("Head") == 0 &&
						 elementStack.Peek().CompareTo("Head") == 0) {
					if (tableHeader.Count != 0) {
						for (int i = 0; i < tableHeader.Count; i++) {
							if (i != 0) {
								tempTableString += ",\t";
							}
							tempTableString += tableHeader[i];
						}
						tempTableString += "\n";
					}
					elementStack.Pop();
					tableHeader.Clear();
				}
				else if (tag.CompareTo("Row") == 0 &&
						 elementStack.Peek().CompareTo("Row") == 0) {
					elementStack.Pop();
					for (int i = 0; i < tableRow.Count; i++) {
						if (i != 0) {
							tempTableString += ",\t";
						}
						tempTableString += tableRow[i];
					}
					tempTableString += "\n";
					tableRow.Clear();
				}
				else if (elementStack.Peek().CompareTo(tag) == 0) {
					elementStack.Pop();
				}
			}
		}

		private void initialize() {
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
		}
	}
}

