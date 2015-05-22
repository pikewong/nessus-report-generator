using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {
	public class NessusDataEntry : DataEntry{
		
		public NessusDataEntry(String pluginName,
							String ip,
							String description,
							String impact,
							int severity,
							RiskFactor riskFactor,
							String recommendation,
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
			this.description = description == null ? "" : processString(description);
			this.impact = impact == null ? "" : processString(impact);
			this.riskFactor = riskFactor;
			this.recommendation = recommendation == null ? "" : processString(recommendation);
			this.cveList = cveList;
			this.bidList = bidList;
			this.osvdbList = osvdbList;
			this.referenceLink = "";
			this.valid = true;
			this.type = EntryType.NESSUS;
		}

		public NessusDataEntry(String pluginName,
							String ip,
							String description,
							String impact,
							int severity,
							RiskFactor riskFactor,
							String recommendation,
							List<String> cveList,
							List<String> bidList,
							List<String> osvdbList,
							String referenceLink) {
			if (severity <= 1 && riskFactor == RiskFactor.NULL) {
				this.valid = false;
				return;
			}
			else if (riskFactor == RiskFactor.NULL) {
				riskFactor = RiskFactorFunction.getEnum(severity);
			}

			this.pluginName = pluginName;
			ipList.Add(ip);
			this.description = description == null ? "" : processString(description);
			this.impact = impact == null ? "" : processString(impact);
			this.riskFactor = riskFactor;
			this.recommendation = recommendation == null ? "" : processString(recommendation);
			this.cveList = cveList;
			this.bidList = bidList;
			this.osvdbList = osvdbList;
			this.referenceLink = referenceLink;
			this.valid = true;
			this.type = EntryType.NESSUS;
		}

		private String processString(String s) {
			//String temp = "";
			//for (int i = 0; i < s.Length; i++) {
			//    if (s[i] == '-' &&
			//        (i >= 3 && (s[i - 1] != 'E' && s[i - 2] != 'V' && s[i - 3] != 'C')) &&
			//        (i >= 8 && (s[i - 6] != 'E' && s[i - 7] != 'V' && s[i - 8] != 'C')) &&
			//        (i >= 2 && (s[i - 2] == ':' || s[i - 2] == '.' || s[i - 2] == ')'))
			//        ) {
			//        temp += '\n';
			//    }
			//    if (s[i] != '\n') {
			//        temp += s[i];
			//    }
			//    else if (temp.Length > 0 &&
			//            ((temp[temp.Length - 1] >= 'a' && temp[temp.Length - 1] <= 'z') ||
			//             (temp[temp.Length - 1] >= 'A' && temp[temp.Length - 1] <= 'Z'))) {
			//        temp += ' ';
			//    }
			//}

			//String temp2 = "";
			//for (int i = 0; i < temp.Length; i++) {
			//    temp2 += temp[i];
			//    if (temp[i] == ' ') {
			//        while (i < temp.Length && temp[i] == ' ') {
			//            i++;
			//        }
			//        i--;
			//    }
			//}

			//temp2 += "   ";
			//String temp3 = "";
			//for (int i = 0; i < temp2.Length - 3; i++) {
			//    temp3 += temp2[i];

			//    if (temp2[i] == ':' && (i > 0 && temp2[i - 1] == ' ')) {
			//        temp3 += "\n\n";
			//    }

			//    if ((temp2[i] == '.' && (temp2[i + 1] >= 'A' && temp[i + 1] <= 'Z' && (temp2[i + 1] != 'N' && temp2[i + 2] != 'E' && temp2[i + 3] != 'T'))) ||
			//        (temp2[i] == ',' && (temp2[i + 1] >= 'a' && temp[i + 1] <= 'z')) ||
			//        (temp2[i] == ',' && (temp2[i + 1] >= 'A' && temp[i + 1] <= 'Z')) ||
			//        (temp2[i] == ',' && (temp2[i + 1] >= '.')) ||
			//        (temp2[i] == ')' && (temp2[i + 1] >= 'a' && temp[i + 1] <= 'z')) ||
			//        (temp2[i] == ')' && (temp2[i + 1] >= 'A' && temp[i + 1] <= 'Z'))) {
			//        temp3 += ' ';
			//    }
			//}
			//while (!String.IsNullOrEmpty(temp3) && temp3[temp3.Length - 1] == ' ') {
			//    temp3 = temp3.Substring(0, temp3.Length - 1);
			//}
			String[] strings = s.Split('\n');
			String temp = "";

			for (int i = 0; i < strings.Length; i++) {
				
				while (strings[i].Length > 0 && strings[i][0] == ' ') {
					strings[i] = strings[i].Substring(1);
				}
				while (strings[i].Length > 0 && strings[i][strings[i].Length - 1] == ' ') {
					strings[i] = strings[i].Substring(0, strings[i].Length - 1);
				}

				if (!String.IsNullOrEmpty(strings[i])) {
					if (strings[i][0] != '-') {
						temp += ' ' + strings[i];
					}
					else {
						if (temp.Length > 0 &&
							temp[temp.Length - 1] == ':') {
							temp += '\n';
						}
						temp += '\n' + strings[i];
					}
				}
			}

			while (temp.Length > 0 && temp[0] == ' ') {
				temp = temp.Substring(1);
			}
			return temp;
		}

	}

}
