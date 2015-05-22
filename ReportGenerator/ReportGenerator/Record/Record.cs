using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {
	public class Record {
		private Dictionary<int, DataEntry> highRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> mediumRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> lowRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> noneRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> openPort = new Dictionary<int, DataEntry>();
		private RiskStats riskStats = new RiskStats();

		public void nessusAddEntry(int pluginId, String ip, DataEntry entry) {
			Dictionary<int, DataEntry> targetHashMap = null;

			switch (entry.getRiskFactor()) {
				case RiskFactor.HIGH:
					targetHashMap = highRisk;
					break;
				case RiskFactor.MEDIUM:
					targetHashMap = mediumRisk;
					break;
				case RiskFactor.LOW:
					targetHashMap = lowRisk;
					break;
				case RiskFactor.NONE:
					targetHashMap = noneRisk;
					break;
				case RiskFactor.OPEN:
					targetHashMap = openPort;
					break;
			}

			// Change risk stat
			riskStats.add(ip, entry.getRiskFactor());

			// Add ReportItem entry to hashmap (Dictionary)
			if (entry.getRiskFactor() != RiskFactor.OPEN) {
				if (targetHashMap.ContainsKey((int)pluginId)) {
					targetHashMap[pluginId].addIp(ip);
				}
				else {
					targetHashMap[pluginId] = entry;
				}
			}
			// Add Open Port entry to hashmap (Dictionary)
			else {
				bool isDuplicate = false;
				foreach (KeyValuePair<int, DataEntry> keyValuePair in targetHashMap) {
					DataEntry tempEntry = keyValuePair.Value;
					List<String> ipList = tempEntry.getIpList();
					foreach (String s in ipList) {
						if (s == entry.getIp()) {
							tempEntry.setDescription(tempEntry.getDescription() + ", " + entry.getDescription());
							isDuplicate = true;
							break;
						}
					}
					if (isDuplicate) {
						break;
					}
				}
				if (!isDuplicate) {
					targetHashMap.Add(targetHashMap.Count, entry);
				}
			}
		}

		public void mbsaAddEntry(DataEntry entry) {
			Dictionary<int, DataEntry> targetHashMap = null;

			switch (entry.getRiskFactor()) {
				case RiskFactor.HIGH:
					targetHashMap = highRisk;
					break;
				case RiskFactor.MEDIUM:
					targetHashMap = mediumRisk;
					break;
				case RiskFactor.LOW:
					targetHashMap = lowRisk;
					break;
				case RiskFactor.NONE:
					targetHashMap = noneRisk;
					break;
				case RiskFactor.OPEN:
					targetHashMap = openPort;
					break;
			}

			if (!isDuplicate(entry)) {
				//Add ReportItem entry to hashmap (dictionary)
				targetHashMap.Add(targetHashMap.Count, entry);

				// Change risk stat
				riskStats.add(entry.getIp(), entry.getRiskFactor());
			}
		}

		public void nmapAddEntry(DataEntry entry) {
			Dictionary<int, DataEntry> targetHashMap = openPort;

			if (!isDuplicate(openPort, entry)) {
				//Add ReportItem entry to hashmap (dictionary)
				targetHashMap.Add(targetHashMap.Count, entry);

				// Change risk stat
				riskStats.add(entry.getIp(), entry.getRiskFactor());
			}
		}

		public void guiAddEntry(DataEntry entry) {
			Dictionary<int, DataEntry> targetHashMap = null;

			switch (entry.getRiskFactor()) {
				case RiskFactor.HIGH:
					targetHashMap = highRisk;
					break;
				case RiskFactor.MEDIUM:
					targetHashMap = mediumRisk;
					break;
				case RiskFactor.LOW:
					targetHashMap = lowRisk;
					break;
				case RiskFactor.NONE:
					targetHashMap = noneRisk;
					break;
				case RiskFactor.OPEN:
					targetHashMap = openPort;
					break;
			}

			// Change risk stat
			foreach (String ip in entry.getIpList()) {
				if (ip.Contains(",")) {
					String[] ipList = ip.Split(',');
					for (int i = 0; i < ipList.Length; i++) {
						String tempString = "";
						foreach (char c in ipList[i]) {
							if (c != ' ') {
								tempString += c;
							}
						}
						ipList[i] = tempString;
					}

					foreach (String s in ipList) {
						riskStats.add(s, entry.getRiskFactor());
					}
				}
				else {
					riskStats.add(ip, entry.getRiskFactor());
				}
			}

			//Add ReportItem entry to hashmap (dictionary)
			targetHashMap.Add(targetHashMap.Count, entry);
		}

		public Dictionary<int, DataEntry> getHighRisk() {
			return highRisk;
		}

		public Dictionary<int, DataEntry> getMediumRisk() {
			return mediumRisk;
		}

		public Dictionary<int, DataEntry> getLowRisk() {
			return lowRisk;
		}

		public Dictionary<int, DataEntry> getNoneRisk() {
			return noneRisk;
		}

		public Dictionary<int, DataEntry> getOpenPort() {
			return openPort;
		}

		public RiskStats getRiskStats() {
			return riskStats;
		}

		public DataEntry.EntryType getEntryType(DataEntry entry) {

			DataEntry.EntryType tempEntryType = getEntryType(highRisk, entry);
			if (tempEntryType == DataEntry.EntryType.NULL) {
				tempEntryType = getEntryType(mediumRisk, entry);
				if (tempEntryType == DataEntry.EntryType.NULL) {
					tempEntryType = getEntryType(lowRisk, entry);
					if (tempEntryType == DataEntry.EntryType.NULL) {
						tempEntryType = getEntryType(noneRisk, entry);
						if (tempEntryType == DataEntry.EntryType.NULL) {
							tempEntryType = getEntryType(openPort, entry);
						}
					}
				}
			}

			return tempEntryType;
		}

		private DataEntry.EntryType getEntryType(Dictionary<int, DataEntry> risk, DataEntry entry) {
			foreach (DataEntry tempEntry in risk.Values) {
				if (tempEntry.getIp() == entry.getIp() &&
					tempEntry.getPluginName() == entry.getPluginName() &&
					tempEntry.getDescription() == entry.getDescription() &&
					tempEntry.getImpact() == entry.getImpact() &&
					tempEntry.getCve() == entry.getCve() &&
					tempEntry.getBid() == entry.getBid() &&
					tempEntry.getOsvdb() == entry.getOsvdb() &&
					tempEntry.getRiskFactor() == entry.getRiskFactor()) {

					return tempEntry.getEntryType();
				}
			}
			return DataEntry.EntryType.NULL;
		}

		private bool isDuplicate(DataEntry entry) {
			return isDuplicate(highRisk, entry) ||
				   isDuplicate(mediumRisk, entry) ||
				   isDuplicate(lowRisk, entry) ||
				   isDuplicate(noneRisk, entry) || 
				   isDuplicate(openPort, entry);
		}

		private bool isDuplicate(Dictionary<int, DataEntry> risk, DataEntry entry) {
			foreach (KeyValuePair<int, DataEntry> keyValuePair in risk) {
				DataEntry tempEntry = keyValuePair.Value;

				if (entry.getRiskFactor() != RiskFactor.OPEN) {
					if (tempEntry.getIp() == entry.getIp() &&
						tempEntry.getPluginName() == entry.getPluginName() &&
						tempEntry.getDescription() == entry.getDescription() &&
						tempEntry.getReferenceLink() == entry.getReferenceLink()) {

						return true;
					}
					else if (tempEntry.getPluginName() == entry.getPluginName() &&
						tempEntry.getDescription() == entry.getDescription() &&
						tempEntry.getReferenceLink() == entry.getReferenceLink()) {

						List<String> ips = entry.getIpList();
						foreach (String ip in ips) {
							tempEntry.addIp(ip);
						}

						return true;
					}
				}
				else {
					if (tempEntry.getRiskFactor() != RiskFactor.OPEN) {
						return false;
					}
					else {
						List<String> ips = tempEntry.getIpList();
						foreach (String ip in ips) {
							if (ip == entry.getIp()) {
								String tempDescription = tempEntry.getDescription();
								String[] tempSplitter = {", "};
								String[] descriptionList = entry.getDescription().Split(tempSplitter, StringSplitOptions.None);
								foreach (String description in descriptionList) {
									if (!tempDescription.Contains(description)) {
										tempDescription += ", " + description;
									}
								}
								tempEntry.setDescription(tempDescription);
								return true;
							}
						}
					}
				}
			}
			return false;
		}
	}
}
