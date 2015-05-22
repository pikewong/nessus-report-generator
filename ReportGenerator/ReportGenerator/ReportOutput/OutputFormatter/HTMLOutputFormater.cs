using System;
using System.IO;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	class HTMLOutputFormater : OutputDefault {
		public override void output(string fileName, ref Record.Record record) {
			StreamWriter sw = new StreamWriter(fileName);
			sw.Write(getOutput(ref record));
			sw.Flush();
			sw.Close();
		}

		private String getOutput(ref Record.Record record) {
			Dictionary<int, DataEntry> highRisk = record.getHighRisk();
			Dictionary<int, DataEntry> mediumRisk = record.getMediumRisk();
			Dictionary<int, DataEntry> lowRisk = record.getLowRisk();
			Dictionary<int, DataEntry> noneRisk = record.getNoneRisk();
			Dictionary<int, DataEntry> openPort = record.getOpenPort();
			RiskStats riskStats = record.getRiskStats();

			StringBuilder sb = new StringBuilder();

			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Risk Statistics</H4>" + "\n");

			sb.Append("<br>High Risk: " + highRisk.Count + "\n");
			sb.Append("<br>Medium Risk: " + mediumRisk.Count + "\n");
			sb.Append("<br>Low Risk: " + lowRisk.Count + "\n");
			sb.Append("<br>None Risk: " + noneRisk.Count + "\n");
			sb.Append("<br>Open Port: " + openPort.Count + "\n");

			sb.Append("</DIV>" + "\n");

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
						sb.Append(HTMLOutputFormater.forHTML(RiskFactorFunction.getEnumString(hostRisk.Key) + " : "));
						sb.Append(HTMLOutputFormater.forHTML(hostRisk.Value.ToString()) + '\t');
					}
				}
			}

			sb.Append("</DIV>" + "\n");

			// High Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>High Risk Findings</H4>" + "\n");

			foreach (KeyValuePair<int, DataEntry> entry in highRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry.Value, RiskFactor.HIGH));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");

			// Medium Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Medium Risk Findings</H4>" + "\n");

			foreach (KeyValuePair<int, DataEntry> entry in mediumRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry.Value, RiskFactor.MEDIUM));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");

			// Low Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Low Risk Findings</H4>" + "\n");

			foreach (KeyValuePair<int, DataEntry> entry in lowRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry.Value, RiskFactor.LOW));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");

			// None Risks
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>None Risk Findings</H4>" + "\n");

			foreach (KeyValuePair<int, DataEntry> entry in noneRisk) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry.Value, RiskFactor.NONE));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");


			// Open Ports
			sb.Append("<DIV>" + "\n");
			sb.Append("<H4>Open Ports Findings</H4>" + "\n");

			foreach (KeyValuePair<int, DataEntry> entry in openPort) {
				sb.Append("<p>" + "\n");
				sb.Append(getDataEntryHTML(entry.Value, RiskFactor.OPEN));
				sb.Append("</p>" + "\n");
			}

			sb.Append("</DIV>" + "\n");

			return sb.ToString();
		}

		private String getDataEntryHTML(DataEntry entry, RiskFactor riskFactor) {
			String HTML_TABLE_START = "<table border=\"1\">";
			String HTML_TABLE_END = "</table>\n";

			StringBuilder sb = new StringBuilder();
			sb.Append("<H5>" + HTMLOutputFormater.forHTML(entry.getPluginName()) + "</H5>");
			sb.Append(HTML_TABLE_START);
			sb.Append("\n");

			// Hosts Affected
			sb.Append("<TR>\n");
			sb.Append("<TD>Hosts Affected:</TD>\n");
			sb.Append("<TD>");
			foreach (String ip in entry.getIpList()) {
				sb.Append(ip + "<br/>");
			}
			sb.Remove(sb.Length - 5, 5);
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

			// CVE
			if (entry.getCve() != null) {
				hasRef = true;
				sb.Append("CVE: ");
				sb.Append(HTMLOutputFormater.forHTML(entry.getCve()));
				sb.Append("<br/>");
			}

			// BID
			if (entry.getBid() != null) {
				hasRef = true;
				sb.Append("BID: ");
				sb.Append(HTMLOutputFormater.forHTML(entry.getBid()));
				sb.Append("<br/>");
			}

			// OSVDB
			if (entry.getOsvdb() != null) {
				hasRef = true;
				sb.Append("OSVDB: ");
				sb.Append(HTMLOutputFormater.forHTML(entry.getOsvdb()));
				sb.Append("<br/>");
			}

			if (hasRef) {
				sb.Remove(sb.Length - 5, 5);
			}
			else {
				sb.Append("N/A");
			}

			sb.Append("</TD>\n");
			sb.Append("</TR>\n");

			sb.Append(HTML_TABLE_END);

			return sb.ToString();
		}

		/**
		 * Use this to put escape char of HTML
		 * @param aText String to be escaped
		 * @return HTML escaped String
		 */
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
