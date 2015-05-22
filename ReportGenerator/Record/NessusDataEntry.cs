using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {
	
	/// <summary>
	/// This is the NessusDataEntry Class.
	/// It is used to store the DataEntry from Nessus.
	/// </summary>
	public class NessusDataEntry : DataEntry{

        protected String port = null;
        protected String protocol = null;
        protected String svc_name = null;
        protected String pluginFamily = null;
        protected String plugin_publication_date = null;
        protected String plugin_modification_date = null;
        protected String cvss_vector = null;
        protected String cvss_base_score = null;
        protected String plugin_output = null;
        protected String plugin_version = null;
        protected List<String> see_alsoList = new List<String>();
        protected String pluginID = null;
        protected int severity = -1;
        protected string microSoftID;

        String severityString = null; // for output excel

        		/// <summary>
		/// This is the constructor of NessusDataEntry.
		/// (With/Without referenceLink)
		/// </summary>
		/// <param name="pluginName">plugin name of the DataEntry</param>
		/// <param name="ip">host name of the DataEntry</param>
		/// <param name="description">description of the DataEntry</param>
		/// <param name="impact">impact of the DataEntry</param>
		/// <param name="severity">int represents the risk of the DataEntry</param>
		/// <param name="riskFactor">RiskFactor of the DataEntry</param>
		/// <param name="recommendation">recommendation of the DataEntry</param>
		/// <param name="cveList">cveList of the DataEntry</param>
		/// <param name="bidList">bidList of the DataEntry</param>
		/// <param name="osvdbList">osvdbList of the DataEntry</param>
        /// <param name="referenceLink">referenceLink of the DataEntry (default without = "")</param>
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
                               String fileName,
                               String port,
                               String protocol,
                               String svc_name,
                               String pluginFamily,
                               String plugin_publication_date,
                               String plugin_modification_date,
                               String cvss_vector,
                               String cvss_base_score,
                               String plugin_output,
                               String plugin_version,
                               List<String> see_alsoList,
                               String pluginID,
                               String microSoftID,
                               String referenceLink = "") {

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

            this.port = port == null ? "" : port;
            this.protocol = protocol == null ? "" : protocol;
            this.svc_name = svc_name == null ? "" : svc_name;
            this.pluginFamily = pluginFamily == null ? "" : pluginFamily;
            this.plugin_publication_date = plugin_publication_date == null ? "" :plugin_publication_date;
            this.plugin_modification_date = plugin_modification_date == null ? "" :plugin_modification_date;
            this.cvss_vector = cvss_vector == null ? "" :cvss_vector;
            this.cvss_base_score = cvss_base_score == null ? "" :cvss_base_score;
            this.plugin_output = plugin_output == null ? "" :plugin_output;
            this.plugin_version = plugin_version == null ? "" :plugin_version;
            this.see_alsoList = see_alsoList;
            this.pluginID = pluginID == null ? "" :pluginID;
            this.severity = severity;
            this.microSoftID = microSoftID == null ? "" :microSoftID;
            this.referenceLink = referenceLink == null ? "" :referenceLink;
            this.fileName = fileName == null ? "" : fileName;

            this.valid = true;
			this.type = EntryType.NESSUS;

            this.port_with_protocol=("("+port+"/"+protocol+")");          //@@@@@
            this.hostlist_findingdetail.Add(ip);
            this.port_with_protocollist_findingdetail.Add("(" + port + "/" + protocol + ")");
            this.pluginoutputlist_findingdetail.Add(plugin_output);
            this.pluginoutput_findingdetail = plugin_output;
            this.pluginversion_nessusfinding = plugin_version == null ? "" : plugin_version;
            this.pluginID_nessusfinding = pluginID == null ? "" : pluginID;
		}

        /// <summary>
        /// This is the output raw excel constructor of NessusDataEntry.
        /// (With/Without referenceLink)
        /// </summary>
        /// <param name="pluginName">plugin name of the DataEntry</param>
        /// <param name="ip">host name of the DataEntry</param>
        /// <param name="description">description of the DataEntry</param>
        /// <param name="impact">impact of the DataEntry</param>
        /// <param name="severity">int represents the risk of the DataEntry</param>
        /// <param name="riskFactor">RiskFactor of the DataEntry</param>
        /// <param name="recommendation">recommendation of the DataEntry</param>
        /// <param name="cveList">cveList of the DataEntry</param>
        /// <param name="bidList">bidList of the DataEntry</param>
        /// <param name="osvdbList">osvdbList of the DataEntry</param>
        /// <param name="referenceLink">referenceLink of the DataEntry (default without = "")</param>
        public NessusDataEntry(String pluginName,
                               String ip,
                               String description,
                               String impact,
                               String severityString,
                               RiskFactor riskFactor,
                               String recommendation,
                               List<String> cveList,
                               List<String> bidList,
                               List<String> osvdbList,
                               String fileName,
                               String port,
                               String protocol,
                               String svc_name,
                               String pluginFamily,
                               String plugin_publication_date,
                               String plugin_modification_date,
                               String cvss_vector,
                               String cvss_base_score,
                               String plugin_output,
                               String plugin_version,
                               List<String> see_alsoList,
                               String pluginID,
                               String microSoftID,
                               String referenceLink = "")
        {
        

            this.pluginName = pluginName;
            ipList.Add(ip);
            this.description = description == null ? "" : processString(description);
            this.impact = impact == null ? "" : processString(impact);
            this.riskFactor = riskFactor;
            this.recommendation = recommendation == null ? "" : processString(recommendation);
            this.cveList = cveList;
            this.bidList = bidList;
            this.osvdbList = osvdbList;

            this.port = port == null ? "" : port;
            this.protocol = protocol == null ? "" : protocol;
            this.svc_name = svc_name == null ? "" : svc_name;
            this.pluginFamily = pluginFamily == null ? "" : pluginFamily;
            this.plugin_publication_date = plugin_publication_date == null ? "" : plugin_publication_date;
            this.plugin_modification_date = plugin_modification_date == null ? "" : plugin_modification_date;
            this.cvss_vector = cvss_vector == null ? "" : cvss_vector;
            this.cvss_base_score = cvss_base_score == null ? "" : cvss_base_score;
            this.plugin_output = plugin_output == null ? "" : plugin_output;
            this.plugin_version = plugin_version == null ? "" : plugin_version;
            this.see_alsoList = see_alsoList;
            this.pluginID = pluginID == null ? "" : pluginID;
            this.severityString = severityString;
            this.microSoftID = microSoftID == null ? "" : microSoftID;
            this.referenceLink = referenceLink == null ? "" : referenceLink;
            this.fileName = fileName == null ? "" : fileName;

            this.valid = true;
            this.type = EntryType.NESSUS;

            this.port_with_protocol=("(" + port + "/" + protocol + ")");
            this.hostlist_findingdetail.Add(ip);
            this.port_with_protocollist_findingdetail.Add("(" + port + "/" + protocol + ")");
            this.pluginoutputlist_findingdetail.Add(plugin_output);
            this.pluginoutput_findingdetail = plugin_output;
            this.pluginversion_nessusfinding=plugin_version == null ? "" : plugin_version;
            this.pluginID_nessusfinding = pluginID == null ? "" : pluginID;
        }


        ///// <summary>
        ///// This is the constructor of NessusDataEntry.
        ///// (With referenceLink)
        ///// </summary>
        ///// <param name="pluginName">plugin name of the DataEntry</param>
        ///// <param name="ip">host name of the DataEntry</param>
        ///// <param name="description">description of the DataEntry</param>
        ///// <param name="impact">impact of the DataEntry</param>
        ///// <param name="severity">int represents the risk of the DataEntry</param>
        ///// <param name="riskFactor">RiskFactor of the DataEntry</param>
        ///// <param name="recommendation">recommendation of the DataEntry</param>
        ///// <param name="cveList">cveList of the DataEntry</param>
        ///// <param name="bidList">bidList of the DataEntry</param>
        ///// <param name="osvdbList">osvdbList of the DataEntry</param>
        ///// <param name="referenceLink">referenceLink of the DataEntry</param>
        //public NessusDataEntry(String pluginName,
        //                       String ip,
        //                       String description,
        //                       String impact,
        //                       int severity,
        //                       RiskFactor riskFactor,
        //                       String recommendation,
        //                       List<String> cveList,
        //                       List<String> bidList,
        //                       List<String> osvdbList,
        //                       String referenceLink) {
        //    if (severity <= 1 && riskFactor == RiskFactor.NULL) {
        //        this.valid = false;
        //        return;
        //    }
        //    else if (riskFactor == RiskFactor.NULL) {
        //        riskFactor = RiskFactorFunction.getEnum(severity);
        //    }

        //    this.pluginName = pluginName;
        //    ipList.Add(ip);
        //    this.description = description == null ? "" : processString(description);
        //    this.impact = impact == null ? "" : processString(impact);
        //    this.riskFactor = riskFactor;
        //    this.recommendation = recommendation == null ? "" : processString(recommendation);
        //    this.cveList = cveList;
        //    this.bidList = bidList;
        //    this.osvdbList = osvdbList;
        //    this.referenceLink = referenceLink;
        //    this.valid = true;
        //    this.type = EntryType.NESSUS;
        //}

		/// <summary>
		/// This is the processString method.
		/// </summary>
		/// <param name="s">string that requires the remove of "\n"</param>
		/// <returns>the string deleting most of the "\n" in the given string.</returns>
		private String processString(String s) {
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

        /// <summary>
        /// This is the getPort method.
        /// </summary>
        /// <returns>the port of current finding.</returns>
        public String getPort() {
            return port; 
        }

        /// <summary>
        /// This is the getProtocol method.
        /// </summary>
        /// <returns>the protocol of current finding.</returns>
        public String getProtocol() { 
            return protocol; 
        }

        /// <summary>
        /// This is the getSvc_name method.
        /// </summary>
        /// <returns>the svc_name of current finding.</returns>
        public String getSvc_name() { 
            return svc_name;
        }

        /// <summary>
        /// This is the getPluginFamily method.
        /// </summary>
        /// <returns>the pluginFamily of current finding.</returns>
        public String getPluginFamily() { 
            return pluginFamily; 
        }

        /// <summary>
        /// This is the getPlugin_publication_date method.
        /// </summary>
        /// <returns>the plugin_publication_date of current finding.</returns>
        public String getPlugin_publication_date() { 
            return plugin_publication_date; 
        }

        /// <summary>
        /// This is the getPlugin_modification_date method.
        /// </summary>
        /// <returns>the plugin_modification_date of current finding.</returns>
        public String getPlugin_modification_date() { 
            return plugin_modification_date; 
        }

        /// <summary>
        /// This is the getCvss_vector method.
        /// </summary>
        /// <returns>the cvss_vector of current finding.</returns>
        public String getCvss_vector() { 
            return cvss_vector; 
        }

        /// <summary>
        /// This is the getCvss_base_score method.
        /// </summary>
        /// <returns>the cvss_base_score of current finding.</returns>
        public String getCvss_base_score() { 
            return cvss_base_score; 
        }

        /// <summary>
        /// This is the getPlugin_output method.
        /// </summary>
        /// <returns>the plugin_output of current finding.</returns>
        public String getPlugin_output() { 
            return plugin_output; 
        }

        /// <summary>
        /// This is the getPlugin_version method.
        /// </summary>
        /// <returns>the plugin_version of current finding.</returns>
        public String getPlugin_version() { 
            return plugin_version; 
        }

        /// <summary>
        /// This is the getSee_alsoList method.
        /// </summary>
        /// <returns>the see_alsoList of current finding.</returns>
        public List<String> getSee_alsoList() {
            return see_alsoList; 
        }

        /// <summary>
        /// This is the getSee_also method.
        /// </summary>
        /// <returns>the see_also of current finding in a string.</returns>
        public String getSee_also()
        {
            if (see_alsoList != null && see_alsoList.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (String item in see_alsoList)
                {
                    sb.Append(item);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);
                return sb.ToString();
            }
            return "";
        }

        /// <summary>
        /// This is the getPluginID method.
        /// </summary>
        /// <returns>the pluginID of current finding in a string.</returns>
        public String getPluginID() {
            return pluginID;
        }

        public String getSeverityString()
        {
            if (severityString != null)
                return severityString;
            else
                return getSeverity().ToString();
        }

        public int getSeverity() { 
            return severity;
        }

        internal string getMicrosoftID()
        {
            return microSoftID;
        }
    }


}
