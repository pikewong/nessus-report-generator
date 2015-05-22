using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ReportGenerator.Record;
using System.Windows.Forms;

namespace ReportGenerator.ReportInput.InputParser {
	public class NmapTxtParser : TextFileParser{

		private Dictionary<int, String> openPortList = new Dictionary<int,string>();
		private int OpenPortCounter = 1;
		private bool canReadPort = false;

		protected override void processData(string content) {

			if (!String.IsNullOrEmpty(content)) {
				if (content.Length > 4 && content.Substring(0, 4) == "Host") {

					int e = content.IndexOf(" is up");
					int s = e - 1;
					while (content[s] != ' ')
						s--;
					
					tempIpList = content.Substring(s + 1, e - s);
					if (tempIpList[0] == '(') {
						tempIpList = tempIpList.Substring(1, tempIpList.Length - 3);
					}
					while (tempIpList.Length > 0 && tempIpList[tempIpList.Length - 1] == ' ') {
						tempIpList = tempIpList.Substring(0, tempIpList.Length - 1);
					}
				}
				else if (content.Contains("PORT") &&
						 content.Contains("STATE") &&
						 content.Contains("SERVICE")) {
					canReadPort = true;
				}
				else if (canReadPort &&
						 content.Contains("open")){
					int e = 0;
					for (int i = 0; i < content.Length; i++) {
						if (content[i] == ' ') {
							e = i;
							break;
						}
					}
					openPortList[OpenPortCounter++] = content.Substring(0, e);
				}
				else if (canReadPort &&
						!String.IsNullOrEmpty(tempIpList) &&
						openPortList.Count > 0) {
					tempDescription = "";

					foreach (String ports in openPortList.Values) {
						if (String.IsNullOrEmpty(tempDescription)) {
							tempDescription = ports;
						}
						else {
							tempDescription += ", " + ports;
						}
					}

					NmapDataEntry entry = new NmapDataEntry("Open Port Findings",
															tempIpList,
															tempDescription,
															RiskFactor.OPEN);
					this.tempRecord.nmapAddEntry(entry);

					tempIpList = "";
					tempDescription = "";
					openPortList.Clear();
					OpenPortCounter = 1;
					canReadPort = false;
				}

			}
		}

		public static bool isNmapTxtFile(String filePath) {
			try {
				using (StreamReader sr = new StreamReader(filePath)) {
					string line;

					while ((line = sr.ReadLine()) != null) {
						if (line.Contains("http://nmap.org")) {
							return true;
						}
					}
				}
			}
			catch (System.IO.IOException) {
				return false;
			}
			return false;
		}
	}
}
