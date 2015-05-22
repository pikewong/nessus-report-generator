using System;
using System.Xml;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportGenerator.ReportInput.InputParser {
	class NessusParser : XmlParser {

		override protected void startTag(string tag, Dictionary<string, string> attributes) {
			if (tag.CompareTo("NessusClientData_v2") == 0) {
				elementStack.Push(tag);
			}
			else if (tag.CompareTo("Report") == 0) {
				if (elementStack.Count != 0 &&
				   (elementStack.Peek().CompareTo("NessusClientData") == 0 ||
					elementStack.Peek().CompareTo("NessusClientData_v2") == 0)) {
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("ReportHost") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("Report") == 0) {
					elementStack.Push(tag);
				}
				if (attributes.ContainsKey("name")) {
					this.tempIpList = attributes["name"];
				}
				else {
					this.tempIpList = "";
				}
			}
			else if (tag.CompareTo("ReportItem") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("ReportHost") == 0) {
					elementStack.Push(tag);
				}

				this.tempPluginId = "-1";
				this.tempPluginName = null;
				this.tempRiskFactor = RiskFactor.NULL;

				//Collect attribute data for V2 format

				//Initialize nessusV2 attributes
				tempDescription = null;
				tempImpact = null;
				tempRecommendation = null;
				tempBidList = null;
				tempCveList = null;
				tempOsvdbList = null;
				tempCve = null;
				tempBid = null;
				tempOsvdb = null;

				String temp = null;
				if (attributes.ContainsKey("pluginID")) {
					this.tempPluginId = attributes["pluginID"];
				}
				else {
					temp = null;
				}

				if (attributes.ContainsKey("pluginName")) {
					this.tempPluginName = attributes["pluginName"];
				}
				else{
					temp = null;
				}

				if (attributes.ContainsKey("severity")) {
					temp = attributes["severity"];
				}
				else {
					temp = null;
				}

				if (!String.IsNullOrEmpty(temp)) {
					tempSeverity = int.Parse(temp);
				}

				if (tempPluginId == "0") {
					if (attributes.ContainsKey("svc_name") &&
						attributes.ContainsKey("port") &&
						attributes.ContainsKey("protocol") && 
						attributes.ContainsKey("severity")) {
						if (attributes["svc_name"] != "unknown") {
							tempPluginName = "Open Port Findings";
							tempDescription = attributes["port"] + "/" + attributes["protocol"];
							tempImpact = "";
							tempSeverity = 0;
							tempRiskFactor = RiskFactor.OPEN;
							tempRecommendation = "";
							if (tempBidList != null) {
								tempCveList.Clear();
							}
							if (tempBidList != null) {
								tempBidList.Clear();
							}
							if (tempOsvdbList != null) {
								tempOsvdbList.Clear();
							}
						}
					}
				}
			}
			else if (elementStack.Count != 0 &&
					 elementStack.Peek().CompareTo("ReportItem") == 0) {
				// NessusV2 specific tags
				if (tag.CompareTo("solution") == 0) {
					elementStack.Push(tag);
					this.tempRecommendation = "";
				}
				else if (tag.CompareTo("risk_factor") == 0) {
					elementStack.Push(tag);
				}
				else if (tag.CompareTo("description") == 0) {
					elementStack.Push(tag);
					this.tempImpact = "";
				}
				else if (tag.CompareTo("synopsis") == 0) {
					elementStack.Push(tag);
					this.tempDescription = "";
				}
				else if (tag.CompareTo("cve") == 0) {
					elementStack.Push(tag);
					this.tempCve = "";

					if (this.tempCveList == null) {
						tempCveList = new List<String>();
					}
				}
				else if (tag.CompareTo("bid") == 0) {
					elementStack.Push(tag);
					tempBid = "";

					if (this.tempBidList == null) {
						tempBidList = new List<String>();
					}
				}
				else if (tag.CompareTo("osvdb") == 0) {
					elementStack.Push(tag);
					tempOsvdb = "";

					if (this.tempOsvdbList == null) {
						tempOsvdbList = new List<String>();
					}
				}
			}
		}

		override protected void pushContent(string content) {
			if (elementStack.Count != 0) {
				if (elementStack.Peek().CompareTo("HostName") == 0) {
					tempIpList += content;
				}
				else {
					if (elementStack.Peek().CompareTo("solution") == 0) {
						this.tempRecommendation += content;
					}
					else if (elementStack.Peek().CompareTo("risk_factor") == 0) {
						this.tempRiskFactor = RiskFactorFunction.getEnum(content);
					}
					else if (elementStack.Peek().CompareTo("description") == 0) {
						this.tempImpact += content;
					}
					else if (elementStack.Peek().CompareTo("synopsis") == 0) {
						this.tempDescription += content;
					}
					else if (elementStack.Peek().CompareTo("cve") == 0) {
						this.tempCve += content;
					}
					else if (elementStack.Peek().CompareTo("bid") == 0) {
						this.tempBid += content;
					}
					else if (elementStack.Peek().CompareTo("osvdb") == 0) {
						this.tempOsvdb += content;
					}
				}
			}
		}

		override protected void endTag(string tag) {
			if (elementStack.Count != 0) {
				if (tag.CompareTo("ReportItem") == 0 &&
					elementStack.Peek().CompareTo("ReportItem") == 0) {
					elementStack.Pop();

					NessusDataEntry entry = null;
					entry = new NessusDataEntry(tempPluginName,
												tempIpList,
												tempDescription,
												tempImpact,
												tempSeverity,
												tempRiskFactor,
												tempRecommendation,
												tempCveList,
												tempBidList,
												tempOsvdbList);
					
					if (entry.isValid()) {
						tempRecord.nessusAddEntry(int.Parse(tempPluginId), tempIpList, entry);
					}
				}
				else if (tag.CompareTo("cve") == 0 &&
					elementStack.Peek().CompareTo("cve") == 0) {
					elementStack.Pop();
					tempCveList.Add(tempCve);
				}
				else if (tag.CompareTo("bid") == 0 &&
						 elementStack.Peek().CompareTo("bid") == 0) {
					elementStack.Pop();
					tempBidList.Add(tempBid);
				}
				else if (tag.CompareTo("osvdb") == 0 &&
					elementStack.Peek().CompareTo("osvdb") == 0) {
					elementStack.Pop();
					tempOsvdbList.Add(tempOsvdb);
				}
				else if (elementStack.Peek().CompareTo(tag) == 0) {
					elementStack.Pop();
				}
			}
		}

	}
}
