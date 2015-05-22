using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {
	class GuiDataEntry : DataEntry{
		public GuiDataEntry(String pluginName,
							String ip,
							String description,
							String impact,
							RiskFactor riskFactor,
							String recommendation,
							List<String> cveList,
							List<String> bidList,
							List<String> osvdbList,
							String referenceLink,
							DataEntry.EntryType entryType) {
			
			this.pluginName = pluginName;

			ipList.Add(ip);
			this.description = description == null ? "" : description;
			this.impact = impact == null ? "" : impact;
			this.riskFactor = riskFactor;
			this.recommendation = recommendation == null ? "" : recommendation;
			this.cveList = cveList;
			this.bidList = bidList;
			this.osvdbList = osvdbList;
			this.referenceLink = referenceLink;

			if (entryType != EntryType.NULL) {
				this.type = entryType;
			}
			else {
				this.type = EntryType.GUI;
			}
		}

		public GuiDataEntry(String pluginName,
							String ipString,
							String description,
							String impact,
							RiskFactor riskFactor,
							String recommendation,
							List<String> cveList,
							List<String> bidList,
							List<String> osvdbList,
							String referenceLink) {

			this.pluginName = pluginName;

			if (ipString.Contains(",")) {
				String[] ipListArray = ipString.Split(',');
				for (int i = 0; i < ipListArray.Length; i++) {
					String tempString = "";
					foreach (char c in ipListArray[i]) {
						if (c != ' ') {
							tempString += c;
						}
					}
					ipListArray[i] = tempString;
				}

				foreach (String s in ipListArray) {
					if (!ipList.Contains(s)) {
						ipList.Add(s);
					}
				}
			}
			else if (!ipList.Contains(ipString)) {
				ipList.Add(ipString);
			}

			this.description = description == null ? "" : description;
			this.impact = impact == null ? "" : impact;
			this.riskFactor = riskFactor;
			this.recommendation = recommendation == null ? "" : recommendation;
			this.cveList = cveList;
			this.bidList = bidList;
			this.osvdbList = osvdbList;
			this.referenceLink = referenceLink;

			this.type = EntryType.NULL;
		}

		

	}
}
