using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportGenerator.Record {
	/// <summary>
	/// This is the Hotfix Class.
	/// It's used to store the hotfix findings.
	/// </summary>
	public class Hotfix {

		// Variables
		private List<DataEntry> hotfixList = new List<DataEntry>();
		private int highRiskHotfix = 0;
		private int mediumRiskHotfix = 0;
		private int lowRiskHotfix = 0;
		private int noneRiskHotfix = 0;

		/// <summary>
		/// This is the constructor of Hotfix.
		/// It's used to get the hotfix findings from given Record.
		/// </summary>
		/// <param name="record">the Record including all findings</param>
		public Hotfix(Record record) {
			List<DataEntry> entries = record.getWholeEntriesWithoutOpenPort();

			foreach (DataEntry entry in entries) {
				if (isHotfix(entry)) {
					addHotfix(entry);
				}
			}

			hotfixList.Sort(delegate(DataEntry d1, DataEntry d2) {
				return d1.getPluginName().CompareTo(d2.getPluginName());
			});
		}

		/// <summary>
		/// This is the getRiskFactor method.
		/// </summary>
		/// <returns>RiskFactor from all hotfix findings currently in hotfixList.</returns>
		public RiskFactor getRiskFactor() {
			int maximum = Math.Max(highRiskHotfix,
						  Math.Max(mediumRiskHotfix,
						  Math.Max(lowRiskHotfix,
								   noneRiskHotfix)));

			if (maximum == highRiskHotfix) {
				return RiskFactor.HIGH;
			}
			else if (maximum == mediumRiskHotfix) {
				return RiskFactor.MEDIUM;
			}
			else if (maximum == lowRiskHotfix) {
				return RiskFactor.LOW;
			}
			return RiskFactor.NONE;
		}

		/// <summary>
		/// This is the getHotfixList method.
		/// </summary>
		/// <returns>a list of DataEntry from the Hotfix.</returns>
		public List<DataEntry> getHotfixList() {
			return hotfixList;
		}

		/// <summary>
		/// This is the getHotfixListGroupByHost method.
		/// </summary>
		/// <returns>a Dictionary of all hotfix findings and group by host.</returns>
		public Dictionary<String, String> getHotfixListGroupByHost() {
			SortedDictionary<String, String> tempHotfixList = new SortedDictionary<String, String>();

			foreach (DataEntry entry in hotfixList) {
				List<String> ips = entry.getIpList();

				foreach (String ip in ips) {
					if (tempHotfixList.ContainsKey(ip)) {
						if (!tempHotfixList[ip].Contains(entry.getPluginName())) {
							tempHotfixList[ip] += ",\n" + entry.getPluginName();
						}
					}
					else {
						tempHotfixList[ip] = entry.getPluginName();
					}
				}
			}
			var dictionary = new Dictionary<string, string>(tempHotfixList);
			return dictionary;
		}

		/// <summary>
		/// This is the addHotfix method.
		/// It is used to add a given entry to the Hotfix list.
		/// </summary>
		/// <param name="entry">the DataEntry that being added to the hotfix</param>
		private void addHotfix(DataEntry entry) {
			RiskFactor tempRiskFactor = entry.getRiskFactor();
			switch (tempRiskFactor) {
				case RiskFactor.HIGH:
					highRiskHotfix++;
					break;
				case RiskFactor.MEDIUM:
					mediumRiskHotfix++;
					break;
				case RiskFactor.LOW:
					lowRiskHotfix++;
					break;
				case RiskFactor.NONE:
					noneRiskHotfix++;
					break;
			}

			hotfixList.Add(entry);
			hotfixList.Sort(delegate(DataEntry d1, DataEntry d2) {
				return d1.getPluginName().CompareTo(d2.getPluginName());
			});
		}

		/// <summary>
		/// This is the isHotfix method.
		/// It is used to determine a given entry is a hotfix finding or not.
		/// </summary>
		/// <param name="entry">The DataEntry</param>
		/// <returns>true if the given entry is a hotfix finding, false otherwise</returns>
		public static bool isHotfix(DataEntry entry){
			String tempPluginName = entry.getPluginName();

			// here only plugin name starts with "MSXX-XXX" (X = 0-9)
			// are considered as hotfix finding
			if (tempPluginName.Length >= 9 &&
				tempPluginName[0] == 'M' &&
				tempPluginName[1] == 'S' &&
				tempPluginName[2] >= '0' && tempPluginName[2] <= '9' &&
				tempPluginName[3] >= '0' && tempPluginName[3] <= '9' &&
				tempPluginName[4] == '-' &&
				tempPluginName[5] >= '0' && tempPluginName[5] <= '9' &&
				tempPluginName[6] >= '0' && tempPluginName[6] <= '9' &&
				tempPluginName[7] >= '0' && tempPluginName[7] <= '9' &&
				(tempPluginName[8] == ' ' || tempPluginName[8] == ':')
				) {

				// check the pluginName contains "KBXXXXXX" (X = 0-9) or 
				// other possibilities
				if (tempPluginName.Contains('(') && tempPluginName.Contains(')')) {
					String kbString = tempPluginName.Substring(tempPluginName.LastIndexOf('('));
					
					if (kbString[kbString.Length - 1] == ')') {
						String tempString = "";
						
						int counter = 0;
						for (int i = 1; i < kbString.Length - 1; i++) {
							if (!(kbString[i] >= '0' && kbString[i] <= '9')) {
								tempString += kbString[i];
							}
							else {
								counter++;
							}
						}

						if (tempString == "KB" || String.IsNullOrEmpty(tempString)) {
							if (tempPluginName[8] == ':') {
								tempPluginName = tempPluginName.Substring(0, 8) + tempPluginName.Substring(9);
								entry.setPluginName(tempPluginName);

							}
							return true;
						}
					}
				}
			}
			return false;
		}

		/// <summary>
		/// This is the getNonHotfixList method.
		/// </summary>
		/// <param name="record">the Record including all findings</param>
		/// <returns>a list of DataEntry with non-hotfix findings from given Record.</returns>
		public static List<DataEntry> getNonHotfixList(Record record) {
			List<DataEntry> entries = record.getWholeEntries();
			List<DataEntry> tempEntries = new List<DataEntry>();

			foreach (DataEntry entry in entries) {
				if (!isHotfix(entry)) {
					tempEntries.Add(entry);
				}
			}

			return tempEntries;
		}

		/// <summary>
		/// This is the getNonHotfixListWithoutOpenPort method.
		/// </summary>
		/// <param name="record">the Record including all findings</param>
		/// <returns>a list of DataEntry with non-hotfix findings and non-openPort findings from given Record.</returns>
		public static List<DataEntry> getNonHotfixListWithoutOpenPort(Record record) {
			List<DataEntry> entries = record.getWholeEntriesWithoutOpenPort();
			List<DataEntry> tempEntries = new List<DataEntry>();

			foreach (DataEntry entry in entries) {
				if (!isHotfix(entry)) {
					tempEntries.Add(entry);
				}
			}

			return tempEntries;
		}

	}
}
