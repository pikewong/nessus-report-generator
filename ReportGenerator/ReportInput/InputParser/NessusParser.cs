using System;
using System.Xml;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;

namespace ReportGenerator.ReportInput.InputParser {
	class NessusParser : InputParser {

		override public void getData(String filePath, ref Record.Record record) {
			this.tempRecord = record;

			XmlTextReader reader = new XmlTextReader(filePath);
			Dictionary<String, String> attributes = null;
			String name = null;

			while (reader.Read()) {
				switch (reader.NodeType) {
					case XmlNodeType.Element:
						if (reader.Name != null) {
							name = reader.Name;
							attributes = new Dictionary<string, string>();

							while (reader.MoveToNextAttribute()) // Read the attributes
								attributes[reader.Name] = reader.Value;

							startTag(name, attributes);
						}
						break;
					case XmlNodeType.Text:
						pushContent(reader.Value);
						break;
					case XmlNodeType.EndElement:
						endTag(reader.Name);
						break;
				}
			}
		}

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

				this.hostName = attributes["name"];
			}
			else if (tag.CompareTo("ReportItem") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("ReportHost") == 0) {
					elementStack.Push(tag);
				}

				this.tempPluginId = "-1";
				this.tempPluginName = null;
				this.defaultRiskFactor = RiskFactor.NULL;

				//Collect attribute data for V2 format

				//Initialize nessusV2 attributes
				description = null;
				impact = null;
				recommendation = null;
				bidList = null;
				cveList = null;
				xrefList = null;
				tempCve = null;
				tempBid = null;
				tempXref = null;

				String temp = attributes["pluginID"];
				if (temp != null) {
					this.tempPluginId = temp;
				}

				this.tempPluginName = attributes["pluginName"];
				temp = attributes["severity"];
				if (temp != null) {
					tempSeverity = int.Parse(temp);
				}
			}
			else if (elementStack.Count != 0 &&
					 elementStack.Peek().CompareTo("ReportItem") == 0) {
				// NessusV2 specific tags
				if (tag.CompareTo("solution") == 0) {
					elementStack.Push(tag);
					this.recommendation = "";
				}
				else if (tag.CompareTo("risk_factor") == 0) {
					elementStack.Push(tag);
				}
				else if (tag.CompareTo("description") == 0) {
					elementStack.Push(tag);
					this.impact = "";
				}
				else if (tag.CompareTo("synopsis") == 0) {
					elementStack.Push(tag);
					this.description = "";
				}
				else if (tag.CompareTo("cve") == 0) {
					elementStack.Push(tag);
					this.tempCve = "";

					if (this.cveList == null) {
						cveList = new List<String>();
					}
				}
				else if (tag.CompareTo("bid") == 0) {
					elementStack.Push(tag);
					tempBid = "";

					if (this.bidList == null) {
						bidList = new List<String>();
					}
				}
				else if (tag.CompareTo("xref") == 0) {
					elementStack.Push(tag);
					tempXref = "";

					if (this.xrefList == null) {
						xrefList = new List<String>();
					}
				}
			}
		}

		override protected void pushContent(string content) {
			if (elementStack.Count != 0) {
				if (elementStack.Peek().CompareTo("HostName") == 0) {
					hostName += content;
				}
				else {
					if (elementStack.Peek().CompareTo("solution") == 0) {
						this.recommendation += content;
					}
					else if (elementStack.Peek().CompareTo("risk_factor") == 0) {
						this.defaultRiskFactor = RiskFactorFunction.getEnum(content);
					}
					else if (elementStack.Peek().CompareTo("description") == 0) {
						this.impact += content;
					}
					else if (elementStack.Peek().CompareTo("synopsis") == 0) {
						this.description += content;
					}
					else if (elementStack.Peek().CompareTo("cve") == 0) {
						this.tempCve += content;
					}
					else if (elementStack.Peek().CompareTo("bid") == 0) {
						this.tempBid += content;
					}
					else if (elementStack.Peek().CompareTo("xref") == 0) {
						this.tempXref += content;
					}
				}
			}
		}

		override protected void endTag(string tag) {
			if (elementStack.Count != 0) {
				if (tag.CompareTo("ReportItem") == 0 &&
					elementStack.Peek().CompareTo("ReportItem") == 0) {
					elementStack.Pop();

					DataEntry entry = null;
					entry = new DataEntry(tempPluginName,
										  hostName,
										  description,
										  impact,
										  tempSeverity,
										  defaultRiskFactor,
										  recommendation,
										  cveList,
										  bidList,
										  xrefList);

					if (entry.isValid()) {
						tempRecord.addEntry(int.Parse(tempPluginId), hostName, entry);
					}
				}
				else if (tag.CompareTo("cve") == 0 &&
					elementStack.Peek().CompareTo("cve") == 0) {
					elementStack.Pop();
					cveList.Add(tempCve);
				}
				else if (tag.CompareTo("bid") == 0 &&
						 elementStack.Peek().CompareTo("bid") == 0) {
					elementStack.Pop();
					bidList.Add(tempBid);
				}
				else if (tag.CompareTo("xref") == 0 &&
					elementStack.Peek().CompareTo("xref") == 0) {
					elementStack.Pop();
					xrefList.Add(tempXref);
				}
				else if (elementStack.Peek().CompareTo(tag) == 0) {
					elementStack.Pop();
				}
			}
		}

	}
}
