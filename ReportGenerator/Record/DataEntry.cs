using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record {

	/// <summary>
	/// This is the DataEntry Class.
	/// DataEntry is an object storing each finding.
	/// </summary>
	public abstract class DataEntry {

		/// <summary>
		/// This is the enum EntryType.
		/// It is used to determine the entry type of the finding.
		/// </summary>
		public enum EntryType {
			NESSUS,
			MBSA,
			NMAP,
            Acunetix,
            MBSA_NESSUS,
			HOTFIX,
			GUI,
			NULL
		};

		// Variables
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
        protected String fileName = null;
        
        protected String port_with_protocol = null;             //@@@@@
        protected List<String> hostlist_findingdetail = new List<string>();
        protected List<String> port_with_protocollist_findingdetail = new List<string>();
        protected List<String> pluginoutputlist_findingdetail = new List<string>();
        protected String pluginoutput_findingdetail = null;
        protected String pluginversion_nessusfinding = null;
        protected String pluginID_nessusfinding = null;
        private List<String> checkDuplicateIpAndPort = new List<String>();
       



		protected bool valid = false;


        public String getFileName()
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return "";
            }
            return fileName;
        }

		/// <summary>
		/// This is the getPluginName method.
		/// </summary>
		/// <returns>the pluginName of current finding.</returns>
		public String getPluginName() {
			if (String.IsNullOrEmpty(pluginName)) {
				return "";
			}
			return pluginName;
		}

		/// <summary>
		/// This is the setPluginName method.
		/// It is used to set the pluginName of current finding.
		/// </summary>
		/// <param name="pluginName">the new pluginName for current finding</param>
		public void setPluginName(String pluginName) {
			this.pluginName = pluginName;
		}

		/// <summary>
		/// This is the getIp method.
		/// </summary>
		/// <returns>a string including all host(s) of current finding.</returns>
		public String getIp() {
			String ips = "";


            // Checking if specific host is stated to be eliminated from the output
            if ((Program.state.ForbiddenHost.Count != 0) && (Program.state.isinpanelLast))
            {

                for (int n = 0; n < Program.state.ForbiddenHost.Count; n++)
                {
                    for (int i = 0; i < ipList.Count; i++)
                    {
                        string temphost = ipList[i].Replace(" ", "");
                        if (temphost.IndexOf("(") >= 0)
                        {
                            if (temphost.Substring(0, temphost.IndexOf("(")) == (Program.state.ForbiddenHost[n]))
                            {
                                ipList.RemoveAt(i);
                                i--;
                            }
                        }
                        else if (temphost == Program.state.ForbiddenHost[n])
                            {
                                ipList.RemoveAt(i);
                                i--;
                            }
                        
                    }
                }
                ips = string.Join(", ", ipList.ToArray());
                return ips;
            }
            else
            {ips = string.Join(", ", ipList.ToArray());
                return ips;}
           
            
            

		}

		/// <summary>
		/// This is getIpList method.
		/// </summary>
		/// <returns>a list of string including all host(s) of current finding.</returns>
		public List<String> getIpList() {
			return ipList;
		}

		/// <summary>
		/// This is the getDescription method.
		/// </summary>
		/// <returns>the description of current finding.</returns>
		public String getDescription() {
			if (String.IsNullOrEmpty(description)) {
				return "";
			}
			return description;
		}

		/// <summary>
		/// This is the setDescription method.
		/// It is used to set the description of the current finding.
		/// </summary>
		/// <param name="description">new description for current finding</param>
		public void setDescription(String description) {
			this.description = description;
		}

		/// <summary>
		/// This is the getImpact method.
		/// </summary>
		/// <returns>the impact of current finding.</returns>
		public String getImpact() {
			if (String.IsNullOrEmpty(impact)) {
				return "";
			}
			return impact;
		}

		/// <summary>
		/// This is the getRiskFactor method.
		/// </summary>
		/// <returns>the RiskFactor of current finding.</returns>
		public RiskFactor getRiskFactor() {
			return riskFactor;
		}

		/// <summary>
		/// This is the getRecommendation method.
		/// </summary>
		/// <returns>the recommendation of current finding.</returns>
		public String getRecommendation() {
			if (String.IsNullOrEmpty(recommendation)) {
				return "";
			}
			return recommendation;
		}

		/// <summary>
		/// This is the getCve method.
		/// </summary>
		/// <returns>the string including all CVE(s) of current finding.</returns>
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

		/// <summary>
		/// This is the getCveList method.
		/// </summary>
		/// <returns>return a list of CVE of all CVE(s) of current finding.</returns>
		public List<String> getCveList() {
			return cveList;
		}

		/// <summary>
		/// This is the getBid method.
		/// </summary>
		/// <returns>the string including all BID(s) of current finding.</returns>
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

		/// <summary>
		/// This is the getBidList method.
		/// </summary>
		/// <returns>a list of BID of all BID(s) of current finding.</returns>
		public List<String> getBidList() {
			return bidList;
		}

		/// <summary>
		/// This is the getOsvdb method.
		/// </summary>
		/// <returns>the string including all OSVDB(s) of current finding.</returns>
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

		/// <summary>
		/// This is the getOsvdbList method.
		/// </summary>
		/// <returns>a list of OSVDB of all OSVDB(s) of current finding.</returns>
		public List<String> getOsvdbList() {
			return osvdbList;
		}

		/// <summary>
		/// This is the isValid method.
		/// </summary>
		/// <returns>the boolean value valid of current finding.</returns>
		public bool isValid() {
			return valid;
		}

		/// <summary>
		/// This is the addIp method.
		/// </summary>
		/// <param name="ip">host name to be added to the ipList</param>
        public void addIp(String ip, String port_with_protocol_c,String pluginoutput_c)
        {

            if (!ipList.Contains(ip))
            {
                ipList.Add(ip);

                ipList.Sort(delegate(String ip1, String ip2)
                {
                    return (ip1.CompareTo(ip2));
                });
            } 




            // Check if duplicate ip and port exist
            checkDuplicateIpAndPort=new List<string>();

                for (int n=0;n<hostlist_findingdetail.Count;n++)
                {

                    checkDuplicateIpAndPort.Add(hostlist_findingdetail[n] + port_with_protocollist_findingdetail[n]);
                }


                if (!checkDuplicateIpAndPort.Contains(ip + port_with_protocol_c))
            {           hostlist_findingdetail.Add(ip);
                        port_with_protocollist_findingdetail.Add(port_with_protocol_c);
                        pluginoutputlist_findingdetail.Add(pluginoutput_c);

                      
            }

                    


        }




        // This is  merge_port_with_same_ip method
        // To check if there is same ip with different port. If yes, merging is executed. 
        // 
        //public List<String> merge_port_with_same_ip(List<String> thelist)            //@@@@@
        //{
        //    for (int n = 0; n < thelist.Count() - 1; n++)
        //    {
        //        if ((thelist[n].IndexOf("(")>0) && (thelist[n + 1].IndexOf("(")>0))
        //        {if (thelist[n].Substring(0, thelist[n].IndexOf("(")) == thelist[n + 1].Substring(0, thelist[n + 1].IndexOf("(")))
        //        {
        //            thelist[n] = thelist[n] + thelist[n + 1].Substring(thelist[n + 1].IndexOf("("));
        //            thelist.Remove(thelist[n + 1]);

        //        }}
        //    }
        //    return thelist;
       
        //}

        //sort the port in numerical order
        private static int SortPort(string x, string y)
        {
            int xx = int.Parse(x.Substring(1, x.IndexOf("/") - 1));
            int yy = int.Parse(y.Substring(1, y.IndexOf("/") - 1));

            if (xx > yy)
                return 1;
            else if (xx < yy)
                return -1;
            else
                return 0;

        }


        // Sort the iplist and port list before importing to database
        public void sortForFindingDetail2()
        {
            List<String> tempstoreportwithpluginoutput = new List<string>();
            Dictionary<String, List<String>> IpandPortsorting = new Dictionary<string, List<string>>();

            for (int n = 0; n < hostlist_findingdetail.Count(); n++)
            {
                if (IpandPortsorting.ContainsKey(hostlist_findingdetail[n]))
                {
                    tempstoreportwithpluginoutput = (IpandPortsorting[hostlist_findingdetail[n]]);
                    tempstoreportwithpluginoutput.Add(port_with_protocollist_findingdetail[n] + "~" + pluginoutputlist_findingdetail[n]);
                    IpandPortsorting[hostlist_findingdetail[n]] = tempstoreportwithpluginoutput;
                    tempstoreportwithpluginoutput = new List<string>();

                }
                else
                {
                    tempstoreportwithpluginoutput.Add(port_with_protocollist_findingdetail[n] + "~" + pluginoutputlist_findingdetail[n]);
                    IpandPortsorting.Add(hostlist_findingdetail[n], tempstoreportwithpluginoutput);
                    tempstoreportwithpluginoutput = new List<string>();
                      

                }
            }

            var ipkeylist = IpandPortsorting.Keys.ToList();
            ipkeylist.Sort();

            hostlist_findingdetail=new List<string>();
            port_with_protocollist_findingdetail=new List<string>();
            pluginoutputlist_findingdetail= new List<string>();
            

            foreach (var ipkey in ipkeylist)
            {
                tempstoreportwithpluginoutput = IpandPortsorting[ipkey];
                tempstoreportwithpluginoutput.Sort(SortPort);
                foreach (String portAndPluginoutput in tempstoreportwithpluginoutput)
                {
                    hostlist_findingdetail.Add(ipkey);
                    port_with_protocollist_findingdetail.Add(portAndPluginoutput.Substring(0, portAndPluginoutput.IndexOf("~")));
                    pluginoutputlist_findingdetail.Add(portAndPluginoutput.Substring(portAndPluginoutput.IndexOf("~") + 1));

                
                }           
            }

        
        }

       


        //This is the combine_ip_with_corresponding_port
        //to combine ip and port and save into the variable ipList
        //public void combine_ip_with_corresponding_port()
        //{
        //    //System.Windows.Forms.MessageBox.Show(ipList.Count.ToString());
        //    if (ipList.Count < 2)
        //    {
        //        //ipList[0] += port_with_protocol;
        //        ipList[0] = ipList[0]+"WHAT";
        //    }
        //}

        public String getportwithprotocol()
        {
            return port_with_protocol;
        }

        public String getpluginoutput_findingdetail()
        {
            return pluginoutput_findingdetail;
        
        }

        public List<String> gethostlist()
        {
            return hostlist_findingdetail;
        }

        public List<String> getport_with_protocollist()
        {
            return port_with_protocollist_findingdetail;
        }

        public List<String> getpluginoutputlist()
        {
            return pluginoutputlist_findingdetail;
        }

        public String getpluginversion()
        {
            return pluginversion_nessusfinding;
        }

        public String getpluginID()
        {
            return pluginID_nessusfinding;
        }

		/*
		 * This is the removeIp method.
		 * remove the given host name from the ipList.
		 */
		/// <summary>
		/// This is the removeIp method.
		/// Remove the given host name from the ipList.
		/// </summary>
		/// <param name="ip">the host name to be remove to the ipList</param>
		/// <returns>true if successfully remove the ip, false otherwise</returns>
        /// //No use
		public bool removeIp(String ip) {
			return ipList.Remove(ip);
		}

		/// <summary>
		/// This is the getIpSize method.
		/// </summary>
		/// <returns>the current ipList size.</returns>
        /// ////No use
		public int getIpSize() {
			return ipList.Count;
		}

		/// <summary>
		/// This is the containsIp method.
		/// </summary>
		/// <param name="ip">host to check</param>
		/// <returns>true if the given host already in the ipList, false otherwise</returns>
        /// ////No use
		public bool containsIp(String ip) {
			return ipList.Contains(ip);
		}

		/// <summary>
		/// This is the getReferenceLink method.
		/// </summary>
		/// <returns>the referenceLink of the current finding.</returns>
		public String getReferenceLink() {
			if (String.IsNullOrEmpty(referenceLink)) {
				return "";
			}
			return referenceLink;
		}

		/// <summary>
		/// This is the getEntryType method.
		/// </summary>
		/// <returns>the entryType of the current finding.</returns>
		public EntryType getEntryType() {
			return type;
		}

		/// <summary>
		/// This is the setEntryType method.
		/// set the entryType of the current finding.
		/// </summary>
		/// <param name="type">new entryType for current finding.</param>
		public void setEntryType(EntryType type) {
			this.type = type;
		}

		/// <summary>
		/// This is the getEntryTypeString method.
		/// </summary>
		/// <returns>a string according to the entryType of the current finding.</returns>
		public String getEntryTypeString() {
			switch (type) {
				case EntryType.NESSUS:
					return "NESSUS";
				case EntryType.MBSA:
					return "MBSA";
				case EntryType.NMAP:
					return "NMAP";
                case EntryType.Acunetix:
                    return "Acunetix";

                case EntryType.MBSA_NESSUS:
                    return "MBSA_NESSUS";
				case EntryType.GUI:
					return "GUI";
				case EntryType.HOTFIX:
					return "HOTFIX";
				default:
					return "NULL";
			}
		}

        public static String getEntryTypeString(EntryType type)
        {
            switch (type)
            {
                case EntryType.NESSUS:
                    return "NESSUS";
                case EntryType.MBSA:
                    return "MBSA";
                case EntryType.NMAP:
                    return "NMAP";
                case EntryType.Acunetix:
                    return "Acunetix";
                case EntryType.MBSA_NESSUS:
                    return "MBSA_NESSUS";
                case EntryType.GUI:
                    return "GUI";
                case EntryType.HOTFIX:
                    return "HOTFIX";
                default:
                    return "NULL";
            }
        }

		/// <summary>
		/// This is the static stringToEntryType method.
		/// </summary>
		/// <param name="typeString"></param>
		/// <returns>the EntryType according to the given typeString.</returns>
		public static EntryType stringToEntryType(String typeString) {
			switch (typeString) {
				case "NESSUS":
					return EntryType.NESSUS;
				case "NMAP":
					return EntryType.NMAP;
				case "MBSA":
					return EntryType.MBSA;
                case "Acunetix":
                    return EntryType.Acunetix;
                case "MBSA_NESSUS":
                    return EntryType.MBSA_NESSUS;
				case "GUI":
					return EntryType.GUI;
				case "HOTFIX":
					return EntryType.HOTFIX;
				default:
					return EntryType.NULL;
			}
		}

        public void setRecommendation(string recommendation)
        {
            this.recommendation = recommendation;
        }

        public DataEntry deepCopy()
        {
            DataEntry entry = (DataEntry)this.MemberwiseClone(); 
            entry.setIpList(new List<String>(ipList));
            entry.setDescription(new String(description.ToCharArray()));
            return entry;
        }

        public void setIpList(List<String> ipList) {
            this.ipList = ipList;
        }

        public void setReferenceLink(String referenceLink)
        {
            this.referenceLink = referenceLink;
        }
    }
}
