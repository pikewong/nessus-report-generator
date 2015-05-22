using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {
	class NmapDataEntry : DataEntry {
		public NmapDataEntry(String pluginName,
							 String ip,
							 String description,
							 RiskFactor riskFactor) {
			
			this.pluginName = pluginName;
			ipList.Add(ip);
			this.description = description == null ? "" : description;
			this.impact = impact == null ? "" : impact;
			this.riskFactor = riskFactor;
			this.recommendation = recommendation == null ? "" : recommendation;
			this.cveList = null;
			this.bidList = null;
			this.osvdbList = null;
			this.referenceLink = "";
			this.valid = true;
			this.type = EntryType.NMAP;
		}
	}
}
