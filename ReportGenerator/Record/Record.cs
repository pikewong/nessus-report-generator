using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {
	/// <summary>
	/// This is the Record Class.
	/// It is used to store the whole data from the nessus/mbsa/nmap reports.
	/// </summary>
    public enum PortType
    {
        TCP = 0,
        UDP = 1,
        ICMP = 2
    }
	public class Record {

        public class OpenPortTableItemData
        {

            private Dictionary<PortType, List<String>> nessusOpenPortDic = new Dictionary<PortType, List<string>>();
            private Dictionary<PortType, List<String>> nmapFilteredPortDic = new Dictionary<PortType, List<string>>();
            private Dictionary<PortType, List<String>> nmapOpenPortDic = new Dictionary<PortType, List<string>>();
            private Dictionary<PortType, List<String>> resultOpenPortDic = new Dictionary<PortType, List<string>>();

            public Dictionary<PortType, List<String>> getNessusOpenPortDic()
            {
                return nessusOpenPortDic;
            }
            public Dictionary<PortType, List<String>> getNmapFilteredPortDic()
            {
                return nmapFilteredPortDic;
            }
            public Dictionary<PortType, List<String>> getNmapOpenPortDic()
            {
                return nmapOpenPortDic;
            }
            public Dictionary<PortType, List<String>> getResultOpenPortDic()
            {
                return resultOpenPortDic;
            }

            /*
             * Constructor
             * Initialize variables
             * 
             * */
            public OpenPortTableItemData()
            {
                for (int i = 0; i < 3; i++)
                {
                    nessusOpenPortDic[(PortType)i] = new List<string>();
                    nmapFilteredPortDic[(PortType)i] = new List<string>();
                    nmapOpenPortDic[(PortType)i] = new List<string>();
                    resultOpenPortDic[(PortType)i] = new List<string>();
                }
            }

            public void makeResultOpenPort()
            {
                for (int i = 0; i < 3; i++)
                {
                    foreach (String port in nessusOpenPortDic[(PortType)i])
                        resultOpenPortDic[(PortType)i].Add(port);
                    foreach (String port in nmapOpenPortDic[(PortType)i])
                        if (!resultOpenPortDic[(PortType)i].Contains(port))
                            resultOpenPortDic[(PortType)i].Add(port);
                    nessusOpenPortDic[(PortType)i].Sort();
                    nmapOpenPortDic[(PortType)i].Sort();
                    nmapFilteredPortDic[(PortType)i].Sort();
                    resultOpenPortDic[(PortType)i].Sort();
                }               
            }

            public void addNessusOpenPort(String port,String protocol)
            {
                if (String.IsNullOrEmpty(port))
                    return;
                if (protocol.Contains("tcp"))
                {
                    if (!nessusOpenPortDic[PortType.TCP].Contains(port))
                        nessusOpenPortDic[PortType.TCP].Add(port);
                }
                else if (protocol.Contains("udp"))
                {
                    if (!nessusOpenPortDic[PortType.UDP].Contains(port))
                        nessusOpenPortDic[PortType.UDP].Add(port);
                }
                else if (protocol.Contains("icmp"))
                {
                    if (!nessusOpenPortDic[PortType.ICMP].Contains(port))
                        nessusOpenPortDic[PortType.ICMP].Add(port);
                }

            }
            public void addNmapOpenPort(List<String> portList)
            {
                if (portList == null)
                    return;
                foreach (String port in portList)
                {
                    if (String.IsNullOrEmpty(port))
                        continue;
                    String temp = port.Substring(0, port.IndexOf('/'));
                    if (port.Contains("/tcp"))
                    {
                        if (!nmapOpenPortDic[PortType.TCP].Contains(temp))
                            nmapOpenPortDic[PortType.TCP].Add(temp);
                    }
                    else if (port.Contains("/udp"))
                    {
                        if (!nmapOpenPortDic[PortType.UDP].Contains(temp))
                            nmapOpenPortDic[PortType.UDP].Add(temp);
                    }
                    else if (port.Contains("/icmp"))
                    {
                        if (!nmapOpenPortDic[PortType.ICMP].Contains(temp))
                            nmapOpenPortDic[PortType.ICMP].Add(temp);
                    }

                }
            }
            public void addNmapFilteredPort(List<String> portList)
            {
                if (portList == null)
                    return;
                foreach (String port in portList)
                {
                    if (String.IsNullOrEmpty(port))
                        continue;
                    String temp = port.Substring(0, port.IndexOf('/'));
                    if (port.Contains("/tcp"))
                    {
                        if (!nmapFilteredPortDic[PortType.TCP].Contains(temp))
                            nmapFilteredPortDic[PortType.TCP].Add(temp);
                    }
                    else if (port.Contains("/udp"))
                    {
                        if (!nmapFilteredPortDic[PortType.UDP].Contains(temp))
                            nmapFilteredPortDic[PortType.UDP].Add(temp);
                    }
                    else if (port.Contains("/icmp"))
                    {
                        if (!nmapFilteredPortDic[PortType.ICMP].Contains(temp))
                            nmapFilteredPortDic[PortType.ICMP].Add(temp);
                    }

                }
            }
        }

		// Variables
		private Dictionary<int, DataEntry> highRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> mediumRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> lowRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> noneRisk = new Dictionary<int, DataEntry>();
		private Dictionary<int, DataEntry> openPort = new Dictionary<int, DataEntry>();
        private Dictionary<int, DataEntry> checkNA = new Dictionary<int, DataEntry>(); // for NBSA check passed entry,grade(0/5/8)
		private RiskStats riskStats = new RiskStats();

        //Raw dictionary to store all the raw data
        private List<DataEntry> highRiskRaw = new List<DataEntry>();
        private List<DataEntry> mediumRiskRaw = new List<DataEntry>();
        private List<DataEntry> lowRiskRaw = new List<DataEntry>();
        private List<DataEntry> noneRiskRaw = new List<DataEntry>();
        private List<DataEntry> openPortRaw = new List<DataEntry>();
        private List<DataEntry> checkNARaw = new List<DataEntry>(); // for MBSA check passed entry,grade(0/5/8) or NA entry
       
        //To keep list of file names for tree view in raw , not displace empty entry files
        private Dictionary<DataEntry.EntryType, List<String>> fileNameRaw = new Dictionary<DataEntry.EntryType, List<String>>();
        public Dictionary<DataEntry.EntryType, List<String>> getFileNameRaw() { return fileNameRaw; }

        private Dictionary<String,OpenPortTableItemData> openPortTableItem = new Dictionary<string,OpenPortTableItemData>(); //ip to data
        public Dictionary<String, OpenPortTableItemData>  getOpenPortTableItem() { return openPortTableItem; }

        bool isOutputRecord = false; //To indicate it is for output acunetix excel
        DataEntry.EntryType outputEntryType;
        public void setIsOutputRecord(bool isOutputRecord) { this.isOutputRecord = isOutputRecord; }
        public bool getIsOutputRecord() { return isOutputRecord; }
        public DataEntry.EntryType getOutputEntryType() { return outputEntryType; }
        public void setOutputEntryType(DataEntry.EntryType outputEntryType) { this.outputEntryType = outputEntryType; }

        public void addEntry(DataEntry entry)
        {
            if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.NESSUS) == 0)
                nessusAddEntry(entry);
            else if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.MBSA) == 0)
                mbsaAddEntry(entry);
            else if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.NMAP) == 0)
                nmapAddEntry(entry);
            else if (entry.getEntryType().CompareTo(ReportGenerator.Record.DataEntry.EntryType.Acunetix) == 0)
                acunetixAddEntry(entry);
        }

        public void acunetixAddEntry(DataEntry entry)
        {
            string ip = entry.getIp();
            Dictionary<int, DataEntry> targetDictionary = null;
            List<DataEntry> targetDictionaryRaw = null;

            // Find which Dictionary the entry to be stored
            switch (entry.getRiskFactor())
            {
                case RiskFactor.HIGH:
                    targetDictionary = highRisk;
                    targetDictionaryRaw = highRiskRaw;
                    break;
                case RiskFactor.MEDIUM:
                    targetDictionary = mediumRisk;
                    targetDictionaryRaw = mediumRiskRaw;
                    break;
                case RiskFactor.LOW:
                    targetDictionary = lowRisk;
                    targetDictionaryRaw = lowRiskRaw;
                    break;
                case RiskFactor.NONE:
                    targetDictionary = noneRisk;
                    targetDictionaryRaw = noneRiskRaw;
                    break;
                case RiskFactor.OPEN:
                    targetDictionary = openPort;
                    targetDictionaryRaw = openPortRaw;
                    break;
                default:
                    targetDictionary = checkNA;
                    targetDictionaryRaw = checkNARaw;
                    break;

            }

            // return if entry is with unknow RiskFactor
            if (targetDictionary == null)
            {
                return;
            }

            string fileName = entry.getFileName();
            if (!fileNameRaw.ContainsKey(DataEntry.EntryType.Acunetix))
                fileNameRaw.Add(DataEntry.EntryType.Acunetix,new List<string>());
            if (!fileNameRaw[DataEntry.EntryType.Acunetix].Contains(fileName))
                fileNameRaw[DataEntry.EntryType.Acunetix].Add(fileName);

            targetDictionaryRaw.Add(entry.deepCopy());
            // Add ReportItem entry to hashmap (dictionary)
            targetDictionary.Add(targetDictionary.Count, entry);

            // Change risk stat
            riskStats.addHost(ip, entry.getRiskFactor());
        }

        //for output excel
        public void nessusAddRawEntry(DataEntry entry)
        {
            List<DataEntry> targetDictionaryRaw = null;

            // Find which Dictionary the entry to be stored
            switch (entry.getRiskFactor())
            {
                case RiskFactor.HIGH:
                    targetDictionaryRaw = highRiskRaw;
                    break;
                case RiskFactor.MEDIUM:
                    targetDictionaryRaw = mediumRiskRaw;
                    break;
                case RiskFactor.LOW:
                    targetDictionaryRaw = lowRiskRaw;
                    break;
                case RiskFactor.NONE:
                    targetDictionaryRaw = noneRiskRaw;
                    break;
                case RiskFactor.OPEN:
                    targetDictionaryRaw = openPortRaw;
                    break;
                default:
                    targetDictionaryRaw = checkNARaw;
                    break;
            }
            if (targetDictionaryRaw!= null)
                targetDictionaryRaw.Add(entry.deepCopy());
        }

		/// <summary>
		/// This is the nessusAddEntry method.
		/// It is used to add an Nessus finding to the Record.
		/// </summary>
		/// <param name="pluginId">the pluginID of the nessus finding</param>
		/// <param name="ip">the host name of the nessus finding</param>
		/// <param name="entry">the whole nessus dataentry finding</param>
		public void nessusAddEntry(DataEntry entry) {
            int pluginId = int.Parse(((NessusDataEntry)entry).getPluginID());
            string ip = entry.getIp();
			Dictionary<int, DataEntry> targetDictionary = null;
            List<DataEntry> targetDictionaryRaw = null;

			// Find which Dictionary the entry to be stored
			switch (entry.getRiskFactor()) {
				case RiskFactor.HIGH:
					targetDictionary = highRisk;
                    targetDictionaryRaw = highRiskRaw;
					break;
				case RiskFactor.MEDIUM:
					targetDictionary = mediumRisk;
                    targetDictionaryRaw = mediumRiskRaw;
					break;
				case RiskFactor.LOW:
					targetDictionary = lowRisk;
                    targetDictionaryRaw = lowRiskRaw;
					break;
				case RiskFactor.NONE:
					targetDictionary = noneRisk;
                    targetDictionaryRaw = noneRiskRaw;
					break;
				case RiskFactor.OPEN:
					targetDictionary = openPort;
                    targetDictionaryRaw = openPortRaw;
					break;
                default:
                    targetDictionary = checkNA;
                    targetDictionaryRaw = checkNARaw;
                    break;
			}

			// return if entry is with unknow RiskFactor
			if (targetDictionary == null) {
				return;
			}


            string fileName = entry.getFileName();
            if (!fileNameRaw.ContainsKey(DataEntry.EntryType.NESSUS))
                fileNameRaw.Add(DataEntry.EntryType.NESSUS,new List<string>());
            if (!fileNameRaw[DataEntry.EntryType.NESSUS].Contains(fileName))
                fileNameRaw[DataEntry.EntryType.NESSUS].Add(fileName);

            targetDictionaryRaw.Add(entry.deepCopy());

            if (!openPortTableItem.ContainsKey(ip))
                openPortTableItem[ip] = new OpenPortTableItemData();
            openPortTableItem[ip].addNessusOpenPort(((NessusDataEntry)entry).getPort(),((NessusDataEntry)entry).getProtocol());
            // Change risk stat
            riskStats.addHost(ip, entry.getRiskFactor());

            // Add ReportItem entry to the dictionary (for an non-openPort finding)
            

            if (entry.getRiskFactor() != RiskFactor.OPEN)
            {
                if (targetDictionary.ContainsKey((int)pluginId))
                {
                    //String p_w_p = entry.getportwithprotocol();
                    //@@@@@System.Windows.Forms.MessageBox.Show(entry.getIpList().IndexOf(ip.Substring(0, ip.Length)).ToString() + "))" + ip + ">>" + ip.Substring(0, ip.IndexOf("(")));
                    //Plan 3targetDictionary[pluginId].addIp(ip, entry.getportwithprotocol()[entry.getIpList().IndexOf(ip.Substring(0,ip.IndexOf("(")))]);       //@@@@@
                    
                    //Plan 2
                    targetDictionary[pluginId].addIp(ip, entry.getportwithprotocol(),entry.getpluginoutput_findingdetail());
                }
                else
                {
                    targetDictionary[pluginId] = entry;
                    //plan 2
                    //targetDictionary[pluginId].combine_ip_with_corresponding_port();
                }
            }

            // Add Open Port finding to dictionary
            else
            {
                //entry.combine_ip_with_corresponding_port();
            //    bool isDuplicate = false;

            //    foreach (KeyValuePair<int, DataEntry> keyValuePair in targetDictionary)
            //    {

            //        DataEntry tempEntry = keyValuePair.Value;
            //        List<String> ipList = tempEntry.getIpList();

            //        foreach (String host in ipList)
            //        {

            //            // merging of open port finding if host exist in open port findings
            //            if (host == entry.getIp())
            //            {

            //                if (!tempEntry.getDescription().Contains(entry.getDescription()))
            //                {
            //                    tempEntry.setDescription(tempEntry.getDescription() + ", " + entry.getDescription());
            //                }

            //                isDuplicate = true;
            //                break;
            //            }
            //        }

            //        if (isDuplicate)
            //        {
            //            break;
            //        }
            //    }

            //    // If the current entry is not an Duplicate entry
            //    if (!isDuplicate)
            //    {

            //        // Add it to the OpenPort findings
            //        targetDictionary.Add(targetDictionary.Count, entry);
            //    }
            }
		}

		/// <summary>
		/// This is the mbsaAddEntry method.
		/// It is used to add an MBSA finding to the Record.
		/// </summary>
		/// <param name="entry">the whole mbsa dataentry finding</param>
		public void mbsaAddEntry(DataEntry entry) {
			Dictionary<int, DataEntry> targetDictionary = null;
            List<DataEntry> targetDictionaryRaw = null;
			// find which Dictionary the entry to be stored
			switch (entry.getRiskFactor()) {
				case RiskFactor.HIGH:
					targetDictionary = highRisk;
                    targetDictionaryRaw = highRiskRaw;
					break;
				case RiskFactor.MEDIUM:
					targetDictionary = mediumRisk;
                    targetDictionaryRaw = mediumRiskRaw;
					break;
				case RiskFactor.LOW:
					targetDictionary = lowRisk;
                    targetDictionaryRaw = lowRiskRaw;
					break;
				case RiskFactor.NONE:
					targetDictionary = noneRisk;
                    targetDictionaryRaw = noneRiskRaw;
					break;
				case RiskFactor.OPEN:
					targetDictionary = openPort;
                    targetDictionaryRaw = openPortRaw;
					break;
                case RiskFactor.NA:
                case RiskFactor.NULL:
                    targetDictionary = checkNA;
                    targetDictionaryRaw = checkNARaw;
					break;
			}

			// return if entry is with unknow RiskFactor
			if (targetDictionary == null) {
				return;
			}

            string fileName = entry.getFileName();
            if (!fileNameRaw.ContainsKey(DataEntry.EntryType.MBSA))
                fileNameRaw.Add(DataEntry.EntryType.MBSA,new List<string>());
            if (!fileNameRaw[DataEntry.EntryType.MBSA].Contains(fileName))
                fileNameRaw[DataEntry.EntryType.MBSA].Add(fileName);

            targetDictionaryRaw.Add(entry.deepCopy());

			// if the entry if not duplicate
			if (!isDuplicate(entry)) {
				
				// Add ReportItem entry to hashmap (dictionary)
				targetDictionary.Add(targetDictionary.Count, entry);

				// Change risk stat
				riskStats.addHost(entry.getIp(), entry.getRiskFactor());
			}
		}

		/// <summary>
		/// This is the nmapAddEntry method.
		/// It is used to add an Nmap finding to the Record.
		/// </summary>
		/// <param name="entry">the whole nmap dataentry finding</param>
		public void nmapAddEntry(DataEntry entry) {
			// return if entry is with non-openPort RiskFactor
			if (entry.getRiskFactor() != RiskFactor.OPEN) {
                checkNARaw.Add(entry.deepCopy());
				return;
			}

            string fileName = entry.getFileName();
            if (!fileNameRaw.ContainsKey(DataEntry.EntryType.NMAP))
                fileNameRaw.Add(DataEntry.EntryType.NMAP,new List<string>());
            if (!fileNameRaw[DataEntry.EntryType.NMAP].Contains(fileName))
                fileNameRaw[DataEntry.EntryType.NMAP].Add(fileName);

            openPortRaw.Add(entry.deepCopy());
			// If the entry is not duplicate

            String ip = entry.getIp();
            if (!openPortTableItem.ContainsKey(ip))
                openPortTableItem[ip] = new OpenPortTableItemData();
            openPortTableItem[ip].addNmapOpenPort(((NmapDataEntry)entry).getOpenPortList());
            openPortTableItem[ip].addNmapFilteredPort(((NmapDataEntry)entry).getFilteredPortList());
			if (!isDuplicate(openPort, entry)) {

                //// Add ReportItem entry to dictionary
                //openPort.Add(openPort.Count, entry);

				// Change risk stat
				riskStats.addHost(entry.getIp(), entry.getRiskFactor());
			}
		}

		/// <summary>
		/// This is the guiAddEntry method.
		/// It is used to add an finding from GUI to the Record.
		/// </summary>
		/// <param name="entry"></param>
		public void guiAddEntry(DataEntry entry) {
			Dictionary<int, DataEntry> targetDictionary = null;

			// Find which Dictionary the entry to be stored
			switch (entry.getRiskFactor()) {
				case RiskFactor.HIGH:
					targetDictionary = highRisk;
					break;
				case RiskFactor.MEDIUM:
					targetDictionary = mediumRisk;
					break;
				case RiskFactor.LOW:
					targetDictionary = lowRisk;
					break;
				case RiskFactor.NONE:
					targetDictionary = noneRisk;
					break;
                case RiskFactor.NA:

				case RiskFactor.OPEN:
					targetDictionary = openPort;
					break;
			}

			// Change RiskStats
			foreach (String ip in entry.getIpList()) {
				if (ip.Contains(",")) {
					String[] ipList = ip.Split(',');
					for (int i = 0; i < ipList.Length; i++) {
						String tempString = "";
						foreach (char c in ipList[i]) {
							if (c != ' ') {
								tempString += c;
							}
						}
						ipList[i] = tempString;
					}

					foreach (String s in ipList) {
						riskStats.addHost(s, entry.getRiskFactor());
					}
				}
				else {
					riskStats.addHost(ip, entry.getRiskFactor());
				}
			}

			// Add ReportItem entry to dictionary
			targetDictionary.Add(targetDictionary.Count, entry);
		}

		public List<DataEntry> getHighRiskRaw() {		
            //highRiskRaw.Sort(delegate(DataEntry d1, DataEntry d2) {
            //    return d1.getIp().CompareTo(d2.getIp());
            //});
            return highRiskRaw;
		}

        public List<DataEntry> getMediumRiskRaw()
        {
            //mediumRiskRaw.Sort(delegate(DataEntry d1, DataEntry d2)
            //{
            //    return d1.getIp().CompareTo(d2.getIp());
            //});
            return mediumRiskRaw;
        }
        public List<DataEntry> getLowRiskRaw()
        {
            //lowRiskRaw.Sort(delegate(DataEntry d1, DataEntry d2)
            //{
            //    return d1.getIp().CompareTo(d2.getIp());
            //});
            return lowRiskRaw;
        }
        public List<DataEntry> getNoneRiskRaw()
        {
            //noneRiskRaw.Sort(delegate(DataEntry d1, DataEntry d2)
            //{
            //    return d1.getIp().CompareTo(d2.getIp());
            //});
            return noneRiskRaw;
        }
        public List<DataEntry> getOpenPortRaw()
        {
            //openPortRaw.Sort(delegate(DataEntry d1, DataEntry d2)
            //{
            //    return d1.getIp().CompareTo(d2.getIp());
            //});
            return openPortRaw;
        }
        public List<DataEntry> getCheckNARaw()
        {
            //checkNARaw.Sort(delegate(DataEntry d1, DataEntry d2)
            //{
            //    return d1.getIp().CompareTo(d2.getIp());
            //});
            return checkNARaw;
        }

		/// <summary>
		/// This is the getHighRisk method.
		/// </summary>
		/// <returns>the high risk findings from the Record.</returns>
		public Dictionary<int, DataEntry> getHighRisk() {
			return sort(highRisk);
		}

		/// <summary>
		/// This is the getMediumRisk method.
		/// </summary>
		/// <returns>the medium risk findings from the Record.</returns>
		public Dictionary<int, DataEntry> getMediumRisk() {
			return sort(mediumRisk);
		}

		/// <summary>
		/// This is the getLowRisk method.
		/// </summary>
		/// <returns>the low risk findings from the Record.</returns>
		public Dictionary<int, DataEntry> getLowRisk() {
			return sort(lowRisk);
		}

		/// <summary>
		/// This is the getNoneRisk method.
		/// </summary>
		/// <returns>the none risk findings (AOI (Area of Improvement)) from the Record.</returns>
		public Dictionary<int, DataEntry> getNoneRisk() {
			return sort(noneRisk);
		}

		/// <summary>
		/// This is the getOpenPort method.
		/// </summary>
		/// <returns>the open port findings from the Record.</returns>
		public Dictionary<int, DataEntry> getOpenPort() {
			return sort(openPort);
		}

		/// <summary>
		/// This is the getWholeEntries method.
		/// </summary>
		/// <returns>all findings from the Record.</returns>
		public List<DataEntry> getWholeEntries() {
			List<DataEntry> tempDataEntry = new List<DataEntry>();
			foreach (DataEntry entry in sort(highRisk).Values) {
				tempDataEntry.Add(entry);
			}
			foreach (DataEntry entry in sort(mediumRisk).Values) {
				tempDataEntry.Add(entry);
			}
			foreach (DataEntry entry in sort(lowRisk).Values) {
				tempDataEntry.Add(entry);
			}
			foreach (DataEntry entry in sort(noneRisk).Values) {
				tempDataEntry.Add(entry);
			}
			foreach (DataEntry entry in sort(openPort).Values) {
				tempDataEntry.Add(entry);
			}
			return tempDataEntry;
		}

        public List<DataEntry> getRawMBSAEnties() {

            List<DataEntry> tempDataEntry = new List<DataEntry>();
            foreach (DataEntry entry in getHighRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.MBSA)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getMediumRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.MBSA)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getLowRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.MBSA)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getNoneRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.MBSA)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getOpenPortRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.MBSA)
                    tempDataEntry.Add(entry);
            }

            return tempDataEntry;
        }

        public List<DataEntry> getRawNessusEnties()
        {
            List<DataEntry> tempDataEntry = new List<DataEntry>();
            foreach (DataEntry entry in getHighRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.NESSUS)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getMediumRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.NESSUS)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getLowRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.NESSUS)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getNoneRiskRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.NESSUS)
                    tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getOpenPortRaw())
            {
                if (entry.getEntryType() == DataEntry.EntryType.NESSUS)
                    tempDataEntry.Add(entry);
            }

            return tempDataEntry;
        }

        public List<DataEntry> getWholeRawEntriesWithNA()
        {
            List<DataEntry> tempDataEntry = new List<DataEntry>();
            foreach (DataEntry entry in getHighRiskRaw())
            {
                tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getMediumRiskRaw())
            {
                tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getLowRiskRaw())
            {
                tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getNoneRiskRaw())
            {
                tempDataEntry.Add(entry);
            }
            foreach (DataEntry entry in getOpenPortRaw())
            {
                tempDataEntry.Add(entry);
            }

            foreach (DataEntry entry in getCheckNARaw())
            {
                tempDataEntry.Add(entry);
            }
            return tempDataEntry;
        }

        /// <summary>
        /// This is the getCount method.
        /// </summary>
        /// <returns>total findings from the Record.</returns>
        public int getRawCount()
        {
            return highRiskRaw.Count + mediumRiskRaw.Count + lowRiskRaw.Count + noneRiskRaw.Count + openPortRaw.Count + checkNARaw.Count;
        }

		/// <summary>
		/// This is the getWholeEntriesWithoutOpenPort method.
		/// </summary>
		/// <returns>all findings except open port findings from the Record.</returns>
		public List<DataEntry> getWholeEntriesWithoutOpenPort(){
			List<DataEntry> tempDataEntry = new List<DataEntry>();
			foreach (DataEntry entry in sort(highRisk).Values) {
				tempDataEntry.Add(entry);
			}
			foreach (DataEntry entry in sort(mediumRisk).Values) {
				tempDataEntry.Add(entry);
			}
			foreach (DataEntry entry in sort(lowRisk).Values) {
				tempDataEntry.Add(entry);
			}
			foreach (DataEntry entry in sort(noneRisk).Values) {
				tempDataEntry.Add(entry);
			}
			return tempDataEntry;
		}

		/// <summary>
		/// This is the getWholeEntriesWithoutHotfix method.
		/// </summary>
		/// <returns>all findings except hotfix findings from the Record.</returns>
		public List<DataEntry> getWholeEntriesWithoutHotfix() {
			List<DataEntry> entries = new List<DataEntry>();
			List<DataEntry> tempEntries = getWholeEntries();

			foreach (DataEntry entry in tempEntries) {
				if (!Hotfix.isHotfix(entry)) {
					entries.Add(entry);
				}
			}

			return entries;
		}

		/// <summary>
		/// This is the getWholeEntriesWithoutOpenPortAndHotfix method.
		/// </summary>
		/// <returns>all findings except open port and hotfix findings from the record.</returns>
		public List<DataEntry> getWholeEntriesWithoutOpenPortAndHotfix() {
			List<DataEntry> entries = new List<DataEntry>();
			List<DataEntry> tempEntries = getWholeEntries();

			foreach (DataEntry entry in tempEntries) {
				if (entry.getRiskFactor() != RiskFactor.OPEN && !Hotfix.isHotfix(entry)) {
					entries.Add(entry);
				}
			}

			return entries;
		}

		/// <summary>
		/// This is the getHighRiskEntriesWithoutHotfix method.
		/// </summary>
		/// <returns>high risk findings except hotfix findings from the Record.</returns>
		public List<DataEntry> getHighRiskEntriesWithoutHotfix() {
			List<DataEntry> entries = new List<DataEntry>();

			//foreach (DataEntry entry in sort(highRisk).Values) {
            foreach (DataEntry entry in highRisk.Values) {
				if (!Hotfix.isHotfix(entry)) {
					entries.Add(entry);
				}
			}

			return entries;
		}

		/// <summary>
		/// This is the getMediumRiskEntriesWithoutHotfix method.
		/// </summary>
		/// <returns>medium risk findings except hotfix findings from the Record.</returns>
		public List<DataEntry> getMediumRiskEntriesWithoutHotfix() {
			List<DataEntry> entries = new List<DataEntry>();

			foreach (DataEntry entry in mediumRisk.Values) {
				if (!Hotfix.isHotfix(entry)) {
					entries.Add(entry);
				}
			}

			return entries;
		}

		/// <summary>
		/// This is the getLowRiskEntriesWithoutHotfix method.
		/// </summary>
		/// <returns>low risk findings except hotfix findings from the Record.</returns>
		public List<DataEntry> getLowRiskEntriesWithoutHotfix() {
			List<DataEntry> entries = new List<DataEntry>();

			foreach (DataEntry entry in lowRisk.Values) {
				if (!Hotfix.isHotfix(entry)) {
					entries.Add(entry);
				}
			}

			return entries;
		}

		/// <summary>
		/// This is the getNoneRiskEntriesWithoutHotfix method.
		/// </summary>
		/// <returns>none risk findings (AOI (Area of Improvement)) except hotfix findings from the Record.</returns>
		public List<DataEntry> getNoneRiskEntriesWithoutHotfix() {
			List<DataEntry> entries = new List<DataEntry>();

			foreach (DataEntry entry in noneRisk.Values) {
				if (!Hotfix.isHotfix(entry)) {
					entries.Add(entry);
				}
			}

			return entries;
		}

		/// <summary>
		/// This is the getHotfix method.
		/// </summary>
		/// <returns>hotfix findings from the Record.</returns>
		public Hotfix getHotfix() {
			return new Hotfix(this);
		}

		/// <summary>
		/// This is the getNonHotfixList method.
		/// </summary>
		/// <returns>non-hotfix findings from the Record.</returns>
		public List<DataEntry> getNonHotfixList() {
			return Hotfix.getNonHotfixList(this);
		}

		/// <summary>
		/// This is the getNonHotfixListWithoutOpenPort method.
		/// </summary>
		/// <returns>non-hotfix findings except open port findings from the Record.</returns>
		public List<DataEntry> getNonHotfixListWithoutOpenPort() {
			return Hotfix.getNonHotfixListWithoutOpenPort(this);
		}

		/// <summary>
		/// This is the getCount method.
		/// </summary>
		/// <returns>total findings from the Record.</returns>
		public int getCount() {
			return highRisk.Count + mediumRisk.Count + lowRisk.Count + noneRisk.Count + openPort.Count;
		}

		/// <summary>
		/// This is the getRiskStats method.
		/// </summary>
		/// <returns>the RiskStats from the Record.</returns>
		public RiskStats getRiskStats() {
			return riskStats;
		}

		/// <summary>
		/// This is the isDuplicate method.
		/// </summary>
		/// <param name="entry"></param>
		/// <returns>true if the entry is already found from the Record, false otherwise.</returns>
		private bool isDuplicate(DataEntry entry) {
			return isDuplicate(highRisk, entry) ||
				   isDuplicate(mediumRisk, entry) ||
				   isDuplicate(lowRisk, entry) ||
				   isDuplicate(noneRisk, entry) || 
				   isDuplicate(openPort, entry);
		}

		/// <summary>
		/// This is the isDuplicate method.
		/// </summary>
		/// <param name="risk">high/medium/low/none/openport risk findings</param>
		/// <param name="entry">the DataEntry</param>
		/// <returns>true if the entry is already found from the risk findings.</returns>
		private bool isDuplicate(Dictionary<int, DataEntry> risk, DataEntry entry) {
			foreach (KeyValuePair<int, DataEntry> keyValuePair in risk) {
				DataEntry tempEntry = keyValuePair.Value;

                
                

				if (entry.getRiskFactor() != RiskFactor.OPEN) {
					if (tempEntry.getIp() == entry.getIp() &&
						tempEntry.getPluginName() == entry.getPluginName() &&
						tempEntry.getDescription() == entry.getDescription() &&
						tempEntry.getReferenceLink() == entry.getReferenceLink()) {

						return true;
					}
					else if (tempEntry.getPluginName() == entry.getPluginName() &&
						tempEntry.getDescription() == entry.getDescription() &&
						tempEntry.getReferenceLink() == entry.getReferenceLink()) {

						List<String> ips = entry.getIpList();
                        //Plan3 List<String> port_with_protocols = entry.getportwithprotocol();
                        String port_with_protocols = entry.getportwithprotocol();
						foreach (String ip in ips) {
							tempEntry.addIp(ip,port_with_protocols,entry.getpluginoutput_findingdetail());           //@@@@@
                            


						}

						return true;
					}
				}
				else {
					if (tempEntry.getRiskFactor() != RiskFactor.OPEN) {
						return false;
					}
					else {
						List<String> ips = tempEntry.getIpList();
						foreach (String ip in ips) {
							if (ip == entry.getIp()) {
								String tempDescription = tempEntry.getDescription();
								String[] tempSplitter = {", "};
								String[] descriptionList = entry.getDescription().Split(tempSplitter, StringSplitOptions.None);
								foreach (String description in descriptionList) {
									if (!tempDescription.Contains(description)) {
										tempDescription += ", " + description;
									}
								}
								tempEntry.setDescription(tempDescription);
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		/// <summary>
		/// This the the sort method.
		/// This method would sort the risk items according to it's ip.
		/// </summary>
		/// <param name="risk">high/medium/low/none/openport risk findings</param>
		/// <returns>return a Dictionary that sort the risk items accoding to it's ip.</returns>
		private Dictionary<int, DataEntry> sort(Dictionary<int, DataEntry> risk) {
			Dictionary<int, DataEntry> dataEntries = new Dictionary<int, DataEntry>();
			List<DataEntry> entryList = new List<DataEntry>();
			//SortedDictionary<string, DataEntry> tempDictionary = new SortedDictionary<string, DataEntry>();

			foreach (DataEntry d in risk.Values) {
				entryList.Add(d);
				//tempDictionary[d.getIp()] = d;
			}

			entryList.Sort(delegate(DataEntry d1, DataEntry d2) {
				return d1.getIp().CompareTo(d2.getIp());
			});

			foreach (DataEntry d in entryList) {
				dataEntries[dataEntries.Count] = d;
			}
			//foreach (DataEntry d in tempDictionary.Values) {
			//	dataEntries[dataEntries.Count] = d;
			//}

			
            return dataEntries;
		}
	}
}
