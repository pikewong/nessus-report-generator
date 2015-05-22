using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {
	class Hotfix {

		private List<DataEntry> hotfixList = new List<DataEntry>();
		private int highRiskHotfix = 0;
		private int mediumRiskHotfix = 0;
		private int lowRiskHotfix = 0;
		private int noneRiskHotfix = 0;

		public void addHotfix(DataEntry entry) {
			if (!isDuplicate(entry)) {
				
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
			}
		}

		public static bool isHotfix(DataEntry entry){
			String tempPluginName = entry.getPluginName();

			return false;
		}

		public List<DataEntry> getHotfixList() {
			return hotfixList;
		}

		public RiskFactor hotfixRiskFactor() {
			int maximum = Math.Max(highRiskHotfix,
						  Math.Max(mediumRiskHotfix,
						  Math.Max(lowRiskHotfix,
								   noneRiskHotfix)));

			if (maximum == highRiskHotfix){
				return RiskFactor.HIGH;
			}
			else if (maximum == mediumRiskHotfix){
				return RiskFactor.MEDIUM;
			}
			else if (maximum == lowRiskHotfix){
				return RiskFactor.LOW;
			}
			return RiskFactor.NONE;
		}

		private bool isDuplicate(DataEntry entry) {
			return false;
		}
	}
}
