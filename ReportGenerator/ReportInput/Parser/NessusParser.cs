using System;
using System.Xml;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportGenerator.ReportInput.InputParser {

	/// <summary>
	/// This is the NessusParser Class.
	/// </summary>
	class NessusParser : XmlParser {
        protected String tempPort = null;
        protected String tempProtocol = null;
        protected String tempSvc_name = null;
        protected String tempPluginFamily = null;
        protected String tempPlugin_publication_date = null;
        protected String tempPlugin_modification_date = null;
        protected String tempCvss_vector = null;
        protected String tempCvss_base_score = null;
        protected String tempPlugin_output = null;
        protected String tempPlugin_version = null;
        protected String tempSee_also = null;
        protected List<String> tempSee_alsoList = new List<String>();
        protected String tempMicrosoftID = null;

		/// <summary>
		/// This is the startTag method.
		/// It is used to handle the start tag/self closed tag from the XML file.
		/// </summary>
		/// <param name="tag">xml start tag name</param>
		/// <param name="attributes">xml tag's attributes</param>
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

				//Collect attribute data for V2 format

				//Initialize nessusV2 attributes
				this.tempPluginId = "-1";
				this.tempPluginName = null;
				this.tempRiskFactor = RiskFactor.NULL;

				tempDescription = null;
				tempImpact = null;
				tempRecommendation = null;
				tempBidList = null;
				tempCveList = null;
				tempOsvdbList = null;
				tempCve = null;
				tempBid = null;
				tempOsvdb = null;

                tempPort = null;
                tempProtocol = null;
                tempSvc_name = null;
                tempPluginFamily = null;
                tempPlugin_publication_date = null;
                tempPlugin_modification_date = null;
                tempCvss_vector = null;
                tempCvss_base_score = null;
                tempPlugin_output = null;
                tempPlugin_version = null;
                tempSee_also = null;
                tempSee_alsoList = null;
                tempPluginId = null;
                tempMicrosoftID = null;

                if (attributes.ContainsKey("port"))
                {
                    this.tempPort = attributes["port"];
                }

                if (attributes.ContainsKey("protocol"))
                {
                    this.tempProtocol = attributes["protocol"];
                }

                if (attributes.ContainsKey("svc_name"))
                {
                    this.tempSvc_name = attributes["svc_name"];
                }

                if (attributes.ContainsKey("pluginFamily"))
                {
                    this.tempPluginFamily = attributes["pluginFamily"];
                }

				if (attributes.ContainsKey("pluginID")) {
					this.tempPluginId = attributes["pluginID"];
				}
                //else {
                //    temp = null;
                //}

				if (attributes.ContainsKey("pluginName")) {
					this.tempPluginName = attributes["pluginName"];
				}
                //else{
                //    temp = null;
                //}

				if (attributes.ContainsKey("severity")) {
                    String temp = null;
					temp = attributes["severity"];
                    if (!String.IsNullOrEmpty(temp)){
                        tempSeverity = int.Parse(temp);
                    }
				}
                //else {
                //    temp = null;
                //}

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
				else if (tag.CompareTo("xref") == 0) {
					elementStack.Push(tag);
					tempOsvdb = "";

					if (this.tempOsvdbList == null) {
						tempOsvdbList = new List<String>();
					}
				}
                else if (tag.CompareTo("plugin_publication_date") == 0)
                {
                    elementStack.Push(tag);
                    this.tempPlugin_publication_date = "";
                }
                else if (tag.CompareTo("plugin_modification_date") == 0)
                {
                    elementStack.Push(tag);
                    this.tempPlugin_modification_date = "";
                }
                else if (tag.CompareTo("cvss_vector") == 0)
                {
                    elementStack.Push(tag);
                    this.tempCvss_vector = "";
                }
                else if (tag.CompareTo("cvss_base_score") == 0)
                {
                    elementStack.Push(tag);
                    this.tempCvss_base_score = "";
                }
                else if (tag.CompareTo("plugin_output") == 0)
                {
                    elementStack.Push(tag);
                    this.tempPlugin_output = "";
                }
                else if (tag.CompareTo("plugin_version") == 0)
                {
                    elementStack.Push(tag);
                    this.tempPlugin_version = "";
                }
                else if (tag.CompareTo("see_also") == 0)
                {
                    elementStack.Push(tag);
                    tempSee_also = "";

                    if (this.tempSee_alsoList == null)
                    {
                        tempSee_alsoList = new List<String>();
                    }
                }
			}
		}

		/// <summary>
		/// This is the pushContent method.
		/// It is used to handle the content between start tag and end tag from the XML file.
		/// </summary>
		/// <param name="content">the content between start tag an end tag from the XML file</param>
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
					else if (elementStack.Peek().CompareTo("xref") == 0) {
						this.tempOsvdb += content;
					}
                    else if (elementStack.Peek().CompareTo("plugin_publication_date") == 0)
                    {
                        this.tempPlugin_publication_date += content;
                    }
                    else if (elementStack.Peek().CompareTo("plugin_modification_date") == 0)
                    {
                        this.tempPlugin_modification_date += content;
                    }
                    else if (elementStack.Peek().CompareTo("cvss_vector") == 0)
                    {
                        this.tempCvss_vector += content;
                    }
                    else if (elementStack.Peek().CompareTo("cvss_base_score") == 0)
                    {
                        this.tempCvss_base_score += content;
                    }
                    else if (elementStack.Peek().CompareTo("plugin_output") == 0)
                    {
                        this.tempPlugin_output += content;
                    }
                    else if (elementStack.Peek().CompareTo("plugin_version") == 0)
                    {
                        this.tempPlugin_version += content;
                    }
                    else if (elementStack.Peek().CompareTo("see_also") == 0)
                    {
                        this.tempSee_also += content;
                    }
				}
			}
		}

		/// <summary>
		/// This is the endTag method.
		/// It is used to handle the end tag from the XML file.
		/// </summary>
		/// <param name="tag">xml end tag name</param>
		override protected void endTag(string tag) {
			if (elementStack.Count != 0) {
				if (tag.CompareTo("ReportItem") == 0 &&
					elementStack.Peek().CompareTo("ReportItem") == 0) {
					elementStack.Pop();

                    // check whether is MS id

                    if (tempPluginName.Length >= 2 && tempPluginName.Substring(0, 2).Contains("MS"))
                        if (tempPluginName.IndexOf(':')!= -1)
                            this.tempMicrosoftID = tempPluginName.Substring(0, tempPluginName.IndexOf(':'));
                    else
                        this.tempMicrosoftID = "";
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
												tempOsvdbList,
                                                tempFileName,
                                                tempPort,
                                                tempProtocol,
                                                tempSvc_name,
                                                tempPluginFamily,
                                                tempPlugin_publication_date,
                                                tempPlugin_modification_date,
                                                tempCvss_vector,
                                                tempCvss_base_score,
                                                tempPlugin_output,
                                                tempPlugin_version,
                                                tempSee_alsoList,
                                                tempPluginId,
                                                tempMicrosoftID);
					
					if (entry.isValid()) {
						tempRecord.nessusAddEntry(entry);
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
				else if (tag.CompareTo("xref") == 0 &&
					elementStack.Peek().CompareTo("xref") == 0) {
					elementStack.Pop();
					tempOsvdbList.Add(tempOsvdb);
				}
                else if (tag.CompareTo("see_also") == 0 &&
                    elementStack.Peek().CompareTo("see_also") == 0) {
                    elementStack.Pop();
                    tempSee_alsoList.Add(tempSee_also);
                }
				else if (elementStack.Peek().CompareTo(tag) == 0) {
					elementStack.Pop();
				}
			}
		}

	}
}
