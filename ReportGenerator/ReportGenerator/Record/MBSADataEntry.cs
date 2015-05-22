using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {
	class MBSADataEntry : DataEntry {
		public MBSADataEntry(String pluginName,
							 String ip,
							 String description,
							 int severity,
							 RiskFactor riskFactor,
							 List<String> cveList,
							 List<String> bidList,
							 List<String> osvdbList) {
			if (severity <= 1 && riskFactor == RiskFactor.NULL) {
				this.valid = false;
				return;
			}
			else if (riskFactor == RiskFactor.NULL) {
				riskFactor = RiskFactorFunction.getEnum(severity);
			}

			this.pluginName = pluginName;
			ipList.Add(ip);
			this.description = description == null ? "" : description;
			this.riskFactor = riskFactor;
			this.valid = true;
			this.cveList = cveList;
			this.bidList = bidList;
			this.osvdbList = osvdbList;
			this.type = EntryType.MBSA;
		}

		public MBSADataEntry(String pluginName,
							 String ip,
							 String description,
							 int severity,
							 RiskFactor riskFactor,
							 String referenceLink,
							 List<String> cveList,
							 List<String> bidList,
							 List<String> osvdbList) {
			if (severity <= 1 && riskFactor == RiskFactor.NULL) {
				this.valid = false;
				return;
			}
			else if (riskFactor == RiskFactor.NULL) {
				riskFactor = RiskFactorFunction.getEnum(severity);
			}

			this.pluginName = pluginName;
			ipList.Add(ip);
			this.description = description == null ? "" : description;
			this.riskFactor = riskFactor;
			this.referenceLink = referenceLink;
			this.valid = true;
			this.cveList = cveList;
			this.bidList = bidList;
			this.osvdbList = osvdbList;
			this.type = EntryType.MBSA;
		}
	}
}
