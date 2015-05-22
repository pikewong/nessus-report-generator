using System;
using System.IO;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportGenerator.ReportOutput.OutputFormatter {

	/// <summary>
	/// This is the HTMLOutputFormater Class.
	/// It is used to create the html report output.
	/// </summary>
	class HTMLOutputFormater : OutputDefault {

		// Variables
		private String HTML_TABLE_START = "<table border=\"1\">";
		private String HTML_TABLE_END = "</table>\n";

		/// <summary>
		/// This is the output method.
		/// It is used to output the file from given path and also given Record.
		/// </summary>
		/// <param name="path">the file path for output</param>
		/// <param name="record">the Record for output</param>
		public override void output(string fileName, ref Record.Record record) {
			StreamWriter sw = new StreamWriter(fileName);
			sw.Write(getOutput(ref record));
			sw.Flush();
			sw.Close();
		}

		/// <summary>
		/// This is the getOutput method.
		/// It is used to create a series of string with HTML elements for the HTML
		/// output.
		/// </summary>
		/// <param name="record">the Record for output</param>
		/// <returns>a series of string with HTML tags for HTML output</returns>
		private String getOutput(ref Record.Record record) {

			#region // get Useful Data
			List<DataEntry> highRisk = record.getHighRiskEntriesWithoutHotfix();
			List<DataEntry> mediumRisk = record.getMediumRiskEntriesWithoutHotfix();
			List<DataEntry> lowRisk = record.getLowRiskEntriesWithoutHotfix();
			List<DataEntry> noneRisk = record.getNoneRiskEntriesWithoutHotfix();
			
			Dictionary<int, DataEntry> openPort = new Dictionary<int,DataEntry>();
			if (Program.state.panelOutputSelect_isOutputOpenPort) {
				openPort = record.getOpenPort();
			}

			List<DataEntry> tempEntries = record.getWholeEntriesWithoutOpenPortAndHotfix();
			Record.Record tempRecord = new Record.Record();
			foreach (DataEntry entry in tempEntries) {
				tempRecord.guiAddEntry(entry);
			}
			if (Program.state.panelOutputSelect_isOutputOpenPort) {
				foreach (DataEntry entry in openPort.Values) {
					tempRecord.guiAddEntry(entry);
				}
			}

			RiskStats riskStats = tempRecord.getRiskStats();
			#endregion

			StringBuilder sb = new StringBuilder();

			#region // print Risk Statistics
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Risk Statistics</H4>" + "\n");

			sb.Append("<br>High Risk: " + highRisk.Count + "\n");
			sb.Append("<br>Medium Risk: " + mediumRisk.Count + "\n");
			sb.Append("<br>Low Risk: " + lowRisk.Count + "\n");
			sb.Append("<br>None Risk: " + noneRisk.Count + "\n");

			if (Program.state.panelOutputSelect_isOutputOpenPort) {
				sb.Append("<br>Open Port: " + openPort.Count + "\n");
			}

			sb.Append("</DIV>" + "\n");
			#endregion

			#region // print Host Statistics
			// Per host statistics
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Risk Statistics</H4>" + "\n");

			foreach (KeyValuePair<String, Dictionary<RiskFactor, int>> entry in riskStats.getRiskStats()) {
				sb.Append("<br/>");
				sb.Append(HTMLOutputFormater.forHTML(entry.Key));
				sb.Append(":\t");

				Dictionary<RiskFactor, int> hostRisks = entry.Value;
				foreach (KeyValuePair<RiskFactor, int> hostRisk in hostRisks) {
					if (hostRisk.Key != RiskFactor.NULL) {
						if (hostRisk.Key != RiskFactor.OPEN ||
							(hostRisk.Key == RiskFactor.OPEN && Program.state.panelOutputSelect_isOutputOpenPort)) {
							
							sb.Append(HTMLOutputFormater.forHTML(RiskFactorFunction.getEnumString(hostRisk.Key) + " : "));

							if (hostRisk.Key != RiskFactor.OPEN) {
								sb.Append(HTMLOutputFormater.forHTML(hostRisk.Value.ToString()) + '\t');
							}
							else if (Program.state.panelOutputSelect_isOutputOpenPort){
								bool isOutput = false;
								
								foreach (DataEntry tempEntry in openPort.Values) {
									if (tempEntry.getIp() == entry.Key) {
										sb.Append(tempEntry.getDescription().Split(',').Length.ToString() + '\t');
										isOutput = true;
										break;
									}
								}

								if (!isOutput) {
									sb.Append("0\t");
								}
							}
						}
					}
				}
			}

			sb.Append("</DIV>" + "\n");
			#endregion

			#region // print HIGH/MEDIUM/LOW/NONE Findings
			// High Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>High Risk Findings</H4>" + "\n");

			foreach (DataEntry entry in highRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry, RiskFactor.HIGH));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");

			// Medium Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Medium Risk Findings</H4>" + "\n");

			foreach (DataEntry entry in mediumRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry, RiskFactor.MEDIUM));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");

			// Low Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Low Risk Findings</H4>" + "\n");

			foreach (DataEntry entry in lowRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry, RiskFactor.LOW));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");

			// None Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>None Risk Findings</H4>" + "\n");

			foreach (DataEntry entry in noneRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry, RiskFactor.NONE));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");
			#endregion

			#region // print Missing Hotfix Findings
			if (Program.state.panelOutputSelect_isOutputHotfix) {
				sb.Append("<DIV>" + "\n");
				sb.Append("<H4>Missing Hotfix Findings</H4>" + "\n");

				sb.Append("<p>" + "\n");

				sb.Append(HTML_TABLE_START);
				sb.Append("\n");
				sb.Append("<TR>\n");
				sb.Append("<TD>Host</TD>\n");
				sb.Append("<TD>Missing Hotfix(s)</TD>\n");
				sb.Append("</TR>\n");

				Dictionary<String, String> hotfixList = new Hotfix(record).getHotfixListGroupByHost();

				foreach (KeyValuePair<String, String> finding in hotfixList) {
					sb.Append("<TR>\n");

					// ip address for the open port findings
					sb.Append("<TD>");
					//MessageBox.Show(finding.Key);
					sb.Append(finding.Key);
					sb.Append("</TD>\n");

					// open ports
					sb.Append("<TD>");
					sb.Append(HTMLOutputFormater.forHTML(finding.Value).Replace("\n", "<br/>"));
					sb.Append("</TD>\n");

					sb.Append("</TR>\n");
				}

				sb.Append(HTML_TABLE_END);
				sb.Append("</p>" + "\n");
				sb.Append("</DIV>" + "\n");
			}
			#endregion

			#region // print Open Port Findings
			// Open Ports
			if (Program.state.panelOutputSelect_isOutputOpenPort) {
				sb.Append("<DIV>" + "\n");
				sb.Append("<H4>Open Ports Findings</H4>" + "\n");

				sb.Append("<p>" + "\n");

				sb.Append(HTML_TABLE_START);
				sb.Append("\n");
				sb.Append("<TR>\n");
				sb.Append("<TD>Host</TD>\n");
				sb.Append("<TD>Open Port(s)</TD>\n");
				sb.Append("</TR>\n");

				foreach (KeyValuePair<int, DataEntry> keyValuePair in openPort) {
					DataEntry entry = keyValuePair.Value;

					sb.Append("<TR>\n");

					// ip address for the open port findings
					sb.Append("<TD>");
					sb.Append(entry.getIp());
					sb.Append("</TD>\n");

					// open ports
					sb.Append("<TD>");
					sb.Append(HTMLOutputFormater.forHTML(entry.getDescription()).Replace("\n", "<br/>"));
					sb.Append("</TD>\n");

					sb.Append("</TR>\n");
				}

				sb.Append(HTML_TABLE_END);
				sb.Append("</p>" + "\n");
				sb.Append("</DIV>" + "\n");
			}
			#endregion

			return sb.ToString();
		}

		/// <summary>
		/// This is the getDataEntryHTML method.
		/// It is used to create a string for HTML output from given entry and
		/// RiskFactor.
		/// </summary>
		/// <param name="entry">the DataEntry being transformed to HTML text string</param>
		/// <param name="riskFactor">riskFactor of that entry</param>
		/// <returns>a HTML string text for that entry</returns>
		private String getDataEntryHTML(DataEntry entry, RiskFactor riskFactor) {

			StringBuilder sb = new StringBuilder();
			sb.Append("<H5>" + HTMLOutputFormater.forHTML(entry.getPluginName()) + "</H5>");
			sb.Append(HTML_TABLE_START);
			sb.Append("\n");

			// Hosts Affected
			sb.Append("<TR>\n");
			sb.Append("<TD>Hosts Affected:</TD>\n");
			sb.Append("<TD>");
			sb.Append(entry.getIp());
			sb.Append("</TD>\n");
			sb.Append("</TR>\n");

			// Description
			sb.Append("<TR>\n");
			sb.Append("<TD>Description:</TD>\n");
			sb.Append("<TD>");
			sb.Append(HTMLOutputFormater.forHTML(entry.getDescription()).Replace("\n", "<br/>"));
			sb.Append("</TD>\n");
			sb.Append("</TR>\n");

			// Impact
			sb.Append("<TR>\n");
			sb.Append("<TD>Impact:</TD>\n");
			sb.Append("<TD>");
			sb.Append(HTMLOutputFormater.forHTML(entry.getImpact()).Replace("\n", "<br/>"));
			sb.Append("</TD>\n");
			sb.Append("</TR>\n");

			// Risk Level
			sb.Append("<TR>\n");
			sb.Append("<TD>Risk Level: </TD>\n");
			sb.Append("<TD>");
			sb.Append(RiskFactorFunction.getEnumString(riskFactor));
			sb.Append("</TD>\n");
			sb.Append("</TR>\n");

			// Recommendations
			sb.Append("<TR>\n");
			sb.Append("<TD>Recommendation:</TD>\n");
			sb.Append("<TD>");
			sb.Append(HTMLOutputFormater.forHTML(entry.getRecommendation()).Replace("\n", "<br/>"));
			sb.Append("</TD>\n");
			sb.Append("</TR>\n");

			// Reference
			bool hasRef = false;
			sb.Append("<TR>\n");
			sb.Append("<TD>Reference:</TD>\n");
			sb.Append("<TD>");

			// CVE/BID/OSVDB

			if (!String.IsNullOrEmpty(entry.getCve()) || !String.IsNullOrEmpty(entry.getBid()) || !String.IsNullOrEmpty(entry.getOsvdb())) {
				// CVE
				if (!String.IsNullOrEmpty(entry.getCve())) {
					hasRef = true;
					sb.Append("CVE: ");
					sb.Append(HTMLOutputFormater.forHTML(entry.getCve()));
					sb.Append("<br/>");
				}

				// BID
				if (!String.IsNullOrEmpty(entry.getBid())) {
					hasRef = true;
					sb.Append("BID: ");
					sb.Append(HTMLOutputFormater.forHTML(entry.getBid()));
					sb.Append("<br/>");
				}

				// OSVDB
				if (!String.IsNullOrEmpty(entry.getOsvdb())) {
					hasRef = true;
					sb.Append("OSVDB: ");
					sb.Append(HTMLOutputFormater.forHTML(entry.getOsvdb()));
					sb.Append("<br/>");
				}
			}

			if (hasRef) {
				sb.Remove(sb.Length - 5, 5);
			}
			else {
				sb.Append("N/A");
			}

			sb.Append("</TD>\n");
			sb.Append("</TR>\n");

			// Reference Link
			if (!String.IsNullOrEmpty(entry.getReferenceLink())) {
				sb.Append("<TR>\n");
				sb.Append("<TD>Reference Link:</TD>\n");
				sb.Append("<TD><a href=\"");
				sb.Append(HTMLOutputFormater.forHTML(entry.getReferenceLink()).Replace("\n", "<br/>"));
				sb.Append("\" target=\"_blank\" >" + HTMLOutputFormater.forHTML(entry.getReferenceLink()).Replace("\n", "<br/>") + "</a></TD>\n");
				sb.Append("</TR>\n");
			}

			sb.Append(HTML_TABLE_END);

			return sb.ToString();
		}

		/// <summary>
		/// This is the forHTML method.
		/// It is used to put escape char of HTML from given text.
		/// </summary>
		/// <param name="aText">the text being put the escape char</param>
		/// <returns>a HTML string text for given text</returns>
		private static String forHTML(String aText) {
			if (aText == null)
				return "N/A";

			StringBuilder result = new StringBuilder();

			foreach (char character in aText) {
				if (character == '<') {
					result.Append("&lt;");
				}
				else if (character == '>') {
					result.Append("&gt;");
				}
				else if (character == '&') {
					result.Append("&amp;");
				}
				else if (character == '\"') {
					result.Append("&quot;");
				}
				else if (character == '\t') {
					addCharEntity(9, result);
				}
				else if (character == '!') {
					addCharEntity(33, result);
				}
				else if (character == '#') {
					addCharEntity(35, result);
				}
				else if (character == '$') {
					addCharEntity(36, result);
				}
				else if (character == '%') {
					addCharEntity(37, result);
				}
				else if (character == '\'') {
					addCharEntity(39, result);
				}
				else if (character == '(') {
					addCharEntity(40, result);
				}
				else if (character == ')') {
					addCharEntity(41, result);
				}
				else if (character == '*') {
					addCharEntity(42, result);
				}
				else if (character == '+') {
					addCharEntity(43, result);
				}
				else if (character == ',') {
					addCharEntity(44, result);
				}
				else if (character == '-') {
					addCharEntity(45, result);
				}
				else if (character == '.') {
					addCharEntity(46, result);
				}
				else if (character == '/') {
					addCharEntity(47, result);
				}
				else if (character == ':') {
					addCharEntity(58, result);
				}
				else if (character == ';') {
					addCharEntity(59, result);
				}
				else if (character == '=') {
					addCharEntity(61, result);
				}
				else if (character == '?') {
					addCharEntity(63, result);
				}
				else if (character == '@') {
					addCharEntity(64, result);
				}
				else if (character == '[') {
					addCharEntity(91, result);
				}
				else if (character == '\\') {
					addCharEntity(92, result);
				}
				else if (character == ']') {
					addCharEntity(93, result);
				}
				else if (character == '^') {
					addCharEntity(94, result);
				}
				else if (character == '_') {
					addCharEntity(95, result);
				}
				else if (character == '`') {
					addCharEntity(96, result);
				}
				else if (character == '{') {
					addCharEntity(123, result);
				}
				else if (character == '|') {
					addCharEntity(124, result);
				}
				else if (character == '}') {
					addCharEntity(125, result);
				}
				else if (character == '~') {
					addCharEntity(126, result);
				}
				else {
					// the char is not a special one
					// add it to the result as is
					result.Append(character);
				}
			}

			return result.ToString();
		}

		/// <summary>
		/// This is the addCharEntity method.
		/// It is used to add special character to the string builder from given
		/// char index.
		/// </summary>
		/// <param name="aIdx">the index of that special char</param>
		/// <param name="aBuilder">a string builder appending that special char</param>
		private static void addCharEntity(int aIdx, StringBuilder aBuilder) {
			String padding = "";
			if (aIdx <= 9) {
				padding = "00";
			}
			else if (aIdx <= 99) {
				padding = "0";
			}
			else {
				// no prefix
			}

			String number = padding + aIdx.ToString();
			aBuilder.Append("&#" + number + ";");
		}
	}
}
