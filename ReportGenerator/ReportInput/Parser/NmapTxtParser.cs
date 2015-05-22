using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ReportGenerator.Record;
using System.Windows.Forms;

namespace ReportGenerator.ReportInput.InputParser {
	
	/// <summary>
	/// This is the NmapTxtParser Class extends TextFileParser.
	/// It is used to parse Nmap text file and get the useful data.
	/// </summary>
	public class NmapTxtParser : TextFileParser{

		// Variables
        private List<String> openPortList = new List<String>();
        private List<String> filteredPortList = new List<String>();
        private List<String> closedPortList = new List<String>();
        private List<String> unknownPortList = new List<String>();

        //private int OpenPortCounter = 1;
		private bool canReadPort = false;
        private bool scanedRunningOS = false;
        private bool startReadPort = false;
        //private bool emptyString = false;
        private String OS = "";
        private String OSDetail = "";

		/// <summary>
		/// This is the processData method.
		/// It is used to process each line on the text file.
		/// </summary>
		/// <param name="content"></param>
		protected override void processData(string content) {
            //if (String.IsNullOrEmpty(content))
            //    emptyString = true;
            //else
            //    emptyString = false;
            //if (!String.IsNullOrEmpty(content)) {

				// in here, only content start with "Host" and contains "is up"
				// would trigger the action to get the host list
                if (content.Length > 6 &&
                    content.Substring(0, 4) == "Host" &&
                    content.Contains(" is up"))
                {

                    int e = content.IndexOf(" is up");
                    int s = e - 1;
                    while (s >= 0 && content[s] != ' ')
                        s--;

                    if (s != -1)
                    {
                        tempIpList = content.Substring(s + 1, e - s);
                        if (tempIpList.Length > 0 && tempIpList[0] == '(')
                        {
                            tempIpList = tempIpList.Substring(1, tempIpList.Length - 3);
                        }
                        while (tempIpList.Length > 0 && tempIpList[tempIpList.Length - 1] == ' ')
                        {
                            tempIpList = tempIpList.Substring(0, tempIpList.Length - 1);
                        }
                    }
                }
                else if (content.Contains("Nmap scan report for "))
                {
                    tempIpList = content.Substring(21, content.Length - 21);
                    if (tempIpList.Contains('(') && tempIpList.Contains(')'))
                    {
                        int length = tempIpList.IndexOf(')') - tempIpList.IndexOf('(') - 1;
                        tempIpList = tempIpList.Substring(tempIpList.IndexOf('(') + 1, length);
                    }
                }
                // in here, only content contains "PORT", "STATE", "SERVICE"
                // would trigger the action to get the open port finding
                else if (content.Contains("PORT") &&
                         content.Contains("STATE") &&
                         content.Contains("SERVICE"))
                {
                    startReadPort = true;
                    canReadPort = true;
                }
                else if (content.Contains("MAC Address:"))
                    canReadPort = false;  //To stop reading port
                //else if (content == "\n")
                //    canReadPort = false;  //To stop reading port
                // get the open port out
                else if (canReadPort && content != "")
                {
                    if (content.Contains(" open "))
                    // && (content.Contains("open"))) || content.Contains("filtered") || content.Contains("closed")))  
                    {
                        int e = 0;
                        for (int i = 0; i < content.Length; i++)
                        {
                            if (content[i] == ' ')
                            {
                                e = i;
                                break;
                            }
                        }
                        if (openPortList == null)
                            openPortList = new List<String>();
                        //openPortList[OpenPortCounter++] = content.Substring(0, e);
                        openPortList.Add(content.Substring(0, e));
                    }
                    else if (content.Contains(" filtered "))
                    {
                        int e = 0;
                        for (int i = 0; i < content.Length; i++)
                        {
                            if (content[i] == ' ')
                            {
                                e = i;
                                break;
                            }
                        }
                        if (filteredPortList == null)
                            filteredPortList = new List<String>();
                        filteredPortList.Add(content.Substring(0, e));
                    }
                    else if (content.Contains(" closed "))
                    {
                        int e = 0;
                        for (int i = 0; i < content.Length; i++)
                        {
                            if (content[i] == ' ')
                            {
                                e = i;
                                break;
                            }
                        }
                        if (closedPortList == null)
                            closedPortList = new List<String>();
                        closedPortList.Add(content.Substring(0, e));
                    }
                    else if (content.Contains(" unknown "))
                    {
                        int e = 0;
                        for (int i = 0; i < content.Length; i++)
                        {
                            if (content[i] == ' ')
                            {
                                e = i;
                                break;
                            }
                        }
                        if (unknownPortList == null)
                            unknownPortList = new List<String>();
                        unknownPortList.Add(content.Substring(0, e));
                    }

                }
                //get OS detail
                else if (content.Contains("Running: "))
                {
                    OS = content.Substring(9, content.Length - 9);

                }
                else if (content.Contains("No exact OS matches for host"))
                {
                    OS = "No exact OS matches for host";
                    scanedRunningOS = true;
                }
                else if (content.Contains("Running (JUST GUESSING) : "))
                {
                    OS = content.Substring(26, content.Length - 26);
                }
                else if (content.Contains("OS details: "))
                {
                    OSDetail = content.Substring(12, content.Length - 12);
                    scanedRunningOS = true;
                }
                else if (content.Contains("Aggressive OS guesses: "))
                {
                    OSDetail = content.Substring(23, content.Length - 23);
                    scanedRunningOS = true;
                }
                // after getting all open port on a host
                // store those results to the record
                else if (((scanedRunningOS == true &&canReadPort == false )||
                        (startReadPort == true && String.IsNullOrEmpty(content))) 
                        &&  !String.IsNullOrEmpty(tempIpList) )
                   // && openPortList.Count > 0)
                {
                    tempDescription = "";
                    if (openPortList!= null)
                        foreach (String ports in openPortList)
                        {
                            if (String.IsNullOrEmpty(tempDescription))
                            {
                                tempDescription = ports;
                            }
                            else
                            {
                                tempDescription += ", " + ports;
                            }
                        }

                    NmapDataEntry entry = new NmapDataEntry("Open Port Findings",
                                                            tempIpList,
                                                            tempDescription,
                                                            RiskFactor.OPEN,
                                                            tempFileName,
                                                            openPortList,
                                                            filteredPortList,
                                                            closedPortList,
                                                            unknownPortList,
                                                            OS,
                                                            OSDetail);
                    this.tempRecord.nmapAddEntry(entry);

                    tempIpList = "";
                    tempDescription = "";
                    openPortList = null;
                    filteredPortList = null;
                    closedPortList = null;
                    unknownPortList = null;
                    //OpenPortCounter = 1;
                    canReadPort = false;
                    startReadPort = false;

                    OS = "";
                    OSDetail = "";
                    scanedRunningOS = false;
                }

            //}
		}

		/// <summary>
		/// This is the static isNmapTxtFile method.
		/// It is used to determine the given filePath is valid Nmap text file.
		/// </summary>
		/// <param name="filePath">the filepath needs to be checked is it a nmap text file</param>
		/// <returns>true is the given filePath is Nmap text file, false otherwise.</returns>
		public static bool isNmapTxtFile(String filePath) {
			try {
				using (StreamReader sr = new StreamReader(filePath)) {
					string line;

					while ((line = sr.ReadLine()) != null) {
						if (line.Contains("Nmap")
                            //line.Contains("Start") &&
                            //line.Contains("http://nmap.org") &&						
							) {
							return true;
						}
					}
				}
			}
			catch (System.IO.IOException) {
				return false;
			}
			return false;
		}
	}
}
