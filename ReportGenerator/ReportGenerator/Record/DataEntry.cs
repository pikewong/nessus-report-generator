using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {
	public abstract class DataEntry {
		public enum EntryType {
			NESSUS,
			MBSA,
			NMAP,
			HOTFIX,
			GUI,
			NULL
		};

		protected String pluginName = null;
		protected List<String> ipList = new List<String>();
		protected String description = null;
		protected String impact = null;
		protected RiskFactor riskFactor = RiskFactor.NULL;
		protected String recommendation = null;
		protected List<String> cveList = new List<string>();
		protected List<String> bidList = new List<string>();
		protected List<String> osvdbList = new List<string>();
		protected String referenceLink = null;
		protected EntryType type = EntryType.NULL;

		protected bool valid = false;

		public String getPluginName() {
			if (String.IsNullOrEmpty(pluginName)) {
				return "";
			}
			return pluginName;
		}

		public String getIp() {
			String ips = "";
			foreach (String ip in ipList) {
				ips += ip + ", ";
			}
			if (!String.IsNullOrEmpty(ips)) {
				ips = ips.Substring(0, ips.Length - 2);
			}
			return ips;
		}

		public List<String> getIpList() {
			return ipList;
		}

		public String getDescription() {
			if (String.IsNullOrEmpty(description)) {
				return "";
			}
			return description;
		}

		public void setDescription(String description) {
			this.description = description;
		}

		public String getImpact() {
			if (String.IsNullOrEmpty(impact)) {
				return "";
			}
			return impact;
		}

		public RiskFactor getRiskFactor() {
			return riskFactor;
		}

		public String getRecommendation() {
			if (String.IsNullOrEmpty(recommendation)) {
				return "";
			}
			return recommendation;
		}

		public String getCve() {
			if (cveList != null && cveList.Count != 0) {
				StringBuilder sb = new StringBuilder();
				foreach (String item in cveList) {
					sb.Append(item);
					sb.Append(", ");
				}
				sb.Remove(sb.Length - 2, 2);
				return sb.ToString();
			}
			return "";
		}

		public List<String> getCveList() {
			return cveList;
		}

		public String getBid() {
			if (bidList != null && bidList.Count != 0) {
				StringBuilder sb = new StringBuilder();
				foreach (String item in bidList) {
					sb.Append(item);
					sb.Append(", ");
				}
				sb.Remove(sb.Length - 2, 2);
				return sb.ToString();
			}
			return "";
		}

		public List<String> getBidList() {
			return bidList;
		}

		public String getOsvdb() {
			if (osvdbList != null && osvdbList.Count != 0) {
				StringBuilder sb = new StringBuilder();
				foreach (String item in osvdbList) {
					sb.Append(item.Replace("OSVDB:", ""));
					sb.Append(", ");
				}
				sb.Remove(sb.Length - 2, 2);
				return sb.ToString();
			}
			return "";
		}

		public List<String> getOsvdbList() {
			return osvdbList;
		}

		public bool isValid() {
			return valid;
		}

		public void addIp(String ip) {
			if (!ipList.Contains(ip)) {
				ipList.Add(ip);
			}
		}

		public bool removeIp(String ip) {
			return ipList.Remove(ip);
		}

		public int getIpSize() {
			return ipList.Count;
		}

		public bool containsIp(String ip) {
			return ipList.Contains(ip);
		}

		public String getReferenceLink() {
			if (String.IsNullOrEmpty(referenceLink)) {
				return "";
			}
			return referenceLink;
		}

		public EntryType getEntryType() {
			return type;
		}

		public void setEntryType(EntryType type) {
			this.type = type;
		}
	}
}
