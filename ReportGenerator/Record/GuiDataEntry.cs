using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {

	/// <summary>
	/// This is the GuiDataEntry Class.
	/// It is used to store the DataEntry from GUI.
    /// For Open port
	/// </summary>
	class GuiDataEntry : DataEntry{

		/// <summary>
		/// This is the constructor of GuiDataEntry.
		/// (With EntryType parameter)
		/// </summary>
		/// <param name="pluginName">pluginName of the DataEntry</param>
		/// <param name="ipString">string with all host name of the DataEntry</param>
		/// <param name="description">description of the DataEntry</param>
		/// <param name="impact">impact of the DataEntry</param>
		/// <param name="riskFactor">RiskFactor of the DataEntry</param>
		/// <param name="recommendation">recommendation of the DataEntry</param>
		/// <param name="cveList">cveList of the DataEntry</param>
		/// <param name="bidList">bidList of the DataEntry</param>
		/// <param name="osvdbList">osvdbList of the DataEntry</param>
		/// <param name="referenceLink">referenceLink of the DataEntry</param>
		/// <param name="entryType">EntryType of the DataEntry</param>
		public GuiDataEntry(String pluginName,
							String ipString,
							String description,
							String impact,
							RiskFactor riskFactor,
							String recommendation,
							List<String> cveList,
							List<String> bidList,
							List<String> osvdbList,
							String referenceLink,
							DataEntry.EntryType entryType,
                            String pluginversion,
                            String pluginID) 
        {
            this.pluginID_nessusfinding = pluginID;
            this.pluginversion_nessusfinding = pluginversion;
            //this.louise = louiselouise;
			this.pluginName = pluginName;

			if (ipString.Contains(",")) {
				String[] ipListArray = ipString.Split(',');
				for (int i = 0; i < ipListArray.Length; i++) {

                    ipListArray[i]=ipListArray[i].Replace(" ", "");
                    //foreach (char c in ipListArray[i]) 
                    //{
                    //    if (c != ' ') {
                    //        tempString += c;
                    //    }
                    //}
                    ipListArray[i] = ipListArray[i].Replace("(", " (");
				}

				foreach (String s in ipListArray) {
					if (!ipList.Contains(s)) {
						ipList.Add(s);
                        hostlist_findingdetail.Add(s);
                        port_with_protocollist_findingdetail.Add("");
                        pluginoutputlist_findingdetail.Add("");
					}
				}
			}
			else if (!ipList.Contains(ipString)) {
				ipList.Add(ipString);
                hostlist_findingdetail.Add(ipString);
                port_with_protocollist_findingdetail.Add("");
                pluginoutputlist_findingdetail.Add("");
			}
            
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

		/// <summary>
		/// This is the constructor of GuiDataEntry.
		/// (With EntryType string)
		/// </summary>
		/// <param name="pluginName">pluginName of the DataEntry</param>
		/// <param name="ipString">string with all host name of the DataEntry</param>
		/// <param name="description">description of the DataEntry</param>
		/// <param name="impact">impact of the DataEntry</param>
		/// <param name="riskFactor">RiskFactor of the DataEntry</param>
		/// <param name="recommendation">recommendation of the DataEntry</param>
		/// <param name="cveList">cveList of the DataEntry</param>
		/// <param name="bidList">bidList of the DataEntry</param>
		/// <param name="osvdbList">osvdbList of the DataEntry</param>
		/// <param name="referenceLink">referenceLink of the DataEntry</param>
		/// <param name="entryType">EntryType string of the DataEntry</param>
        // @@@@@This class had been enter 3times for presenting just ONE row(!!!) in dataGrid 
		public GuiDataEntry(String pluginName,
							String ipString,
							String description,
							String impact,
							RiskFactor riskFactor,
							String recommendation,
							List<String> cveList,
							List<String> bidList,
							List<String> osvdbList,
							String referenceLink,
							String entryType,
                            String pluginversion,
                            String pluginID)          
        {
            this.pluginID_nessusfinding = pluginID;

            //this.louise = description;
            //this.louise = louise == null ? "" : louise;           //@@@@@
            this.pluginversion_nessusfinding = pluginversion;
			this.pluginName = pluginName;


                if (ipString.Contains(","))
                {
                    String[] ipListArray = ipString.Split(',');
                    for (int i = 0; i < ipListArray.Length; i++)
                    {
                        ipListArray[i] = ipListArray[i].Replace(" ", "");

                        //String tempString = "";
                        //foreach (char c in ipListArray[i])
                        //{
                        //    if (c != ' ')
                        //    {
                        //        tempString += c;
                        //    }
                        //}
                        ipListArray[i] = ipListArray[i].Replace("(", " (");
                    }



                    foreach (String s in ipListArray)
                    {
                        if (!ipList.Contains(s))
                        {
                            ipList.Add(s);
                            
                        }
                    }
                }
                else if (!ipList.Contains(ipString))
                {
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

			EntryType tempEntryType = DataEntry.stringToEntryType(entryType);
			if (tempEntryType != EntryType.NULL) {
				this.type = tempEntryType;
			}
			else {
				this.type = EntryType.GUI;
			}
		}

		/*
		 * This is the constructor of GuiDataEntry.
		 * (Without EntryType)
		 */
		/// <summary>
		/// This is the constructor of GuiDataEntry.
		/// (Without EntryType)
		/// </summary>
		/// <param name="pluginName">pluginName of the DataEntry</param>
		/// <param name="ipString">string with all host name of the DataEntry</param>
		/// <param name="description">description of the DataEntry</param>
		/// <param name="impact">impact of the DataEntry</param>
		/// <param name="riskFactor">RiskFactor of the DataEntry</param>
		/// <param name="recommendation">recommendation of the DataEntry</param>
		/// <param name="cveList">cveList of the DataEntry</param>
		/// <param name="bidList">bidList of the DataEntry</param>
		/// <param name="osvdbList">osvdbList of the DataEntry</param>
		/// <param name="referenceLink">referenceLink of the DataEntry</param>
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
                    ipListArray[i] = ipListArray[i].Replace(" ", "");

                    //String tempString = "";
                    //foreach (char c in ipListArray[i]) {
                    //    if (c != ' ') {
                    //        tempString += c;
                    //    }
                    //}
                    ipListArray[i] = ipListArray[i].Replace("(", " (");
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
