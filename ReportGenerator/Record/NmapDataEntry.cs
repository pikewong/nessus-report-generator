using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {

	/// <summary>
	/// This is the NmapDataEntry Class.
	/// It is used to store the DataEntry from Nmap.
	/// </summary>
	class NmapDataEntry : DataEntry {

        private List<String> openPortList;
        private List<String> filteredPortList;
        private List<String> closedPortList;
        private List<String> unknownPortList;
        private String OS = "";
        private String OSDetail = "";

        public String getOpenPortListString()
        {
            if (openPortList == null)
                return "";
            String temp = "";
            foreach (String openPort in openPortList)
                temp += openPort + " ";
            if (!String.IsNullOrEmpty(temp))
                temp.Substring(0, temp.Length - 1);
            return temp;
        }
        public List<String> getOpenPortList() { return openPortList; }
        public String getFilteredPortListString()
        {
            if (filteredPortList == null)
                return "";
            String temp = "";
            foreach (String filteredPort in filteredPortList)
                temp += filteredPort + " ";
            if (!String.IsNullOrEmpty(temp))
                temp.Substring(0, temp.Length - 1);
            return temp;
        }
        public List<String> getFilteredPortList() { return filteredPortList; }
        public String getClosedPortListString()
        {
            if (closedPortList == null)
                return "";
            String temp = "";
            foreach (String closedPort in closedPortList)
                temp += closedPort + " ";
            if (!String.IsNullOrEmpty(temp))
                temp.Substring(0, temp.Length - 1);
            return temp;
        }
        public String getUnknownPortListString()
        {
            if (unknownPortList == null)
                return "";
            String temp = "";
            foreach (String unknownPort in unknownPortList)
                temp += unknownPort + " ";
            if (!String.IsNullOrEmpty(temp))
                temp.Substring(0, temp.Length - 1);
            return temp;
        }
		/// <summary>
		/// This is the constructor of NmapDataEntry.
		/// </summary>
		/// <param name="pluginName">plugin name of the DataEntry</param>
		/// <param name="ip">host name of the DataEntry</param>
		/// <param name="description">description of the DataEntry</param>
		/// <param name="riskFactor">RiskFactor of the DataEntry</param>
		public NmapDataEntry(String pluginName,
							 String ip,
							 String description,
							 RiskFactor riskFactor,
                             String fileName,
                             List<String> openPortList,
                             List<String> filteredPortList,
                             List<String> closedPortList,
                             List<String> unknownPortList,
                             String OS,
                             String OSDetail) {
			
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
            this.fileName = fileName;

			this.valid = true;
			this.type = EntryType.NMAP;

            
            this.openPortList = openPortList;
            this.filteredPortList = filteredPortList;
            this.closedPortList = closedPortList;
            this.unknownPortList = unknownPortList;
            this.OS = OS;
            this.OSDetail = OSDetail;

            //this.louise = "00000";         //@@@@@
            //System.Windows.Forms.MessageBox.Show(this.louise);

        }

        public string getOS()
        {
            return OS;
        }

        public string getOSDetail()
        {
            return OSDetail;
        }
    }
}
