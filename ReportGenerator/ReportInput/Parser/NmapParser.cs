using System;
using System.Xml;
using System.Text;
using ReportGenerator.Record;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportGenerator.ReportInput.InputParser {

	/// <summary>
	/// This is the NmapParser Class extends XmlParser.
	/// It is used to parse Nmap Xml file and get useful data.
	/// </summary>
	class NmapParser : XmlParser {

		#region // Nmap Parser Variables
		private bool isNoResponse;
		private String protocol;
		private String portId;
		private String portState;
		private String reason;
		private String serviceName;
		private String product;
		private int scriptIdCounter = 1;
		private int scriptIdOutputCounter = 1;
		private Dictionary<int, String> scriptId = new Dictionary<int, string>();
		private Dictionary<int, String> scriptOutput = new Dictionary<int, string>();
		#endregion

		/// <summary>
		/// This is the startTag method.
		/// It is used to handle the start tag/self closed tag from the XML file.
		/// </summary>
		/// <param name="tag">xml start tag name</param>
		/// <param name="attributes">xml tag's attributes</param>
		protected override void startTag(string tag, Dictionary<string, string> attributes) {
			if (tag.CompareTo("nmaprun") == 0) {
				elementStack.Push(tag);
			}
			else if (tag.CompareTo("host") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("nmaprun") == 0) {
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("status") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("host") == 0) {

					if (attributes.ContainsKey("state") &&
						attributes["state"] != "down" &&
						attributes.ContainsKey("reason") &&
						attributes["reason"] != "no-response") {

						isNoResponse = false;
						elementStack.Push(tag);
					}
					else {
						isNoResponse = true;
					}
				}
			}
			else if (tag.CompareTo("address") == 0 && !isNoResponse) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("host") == 0) {

					if (attributes.ContainsKey("addrtype")) {
						if (attributes["addrtype"] == "ipv4" ||
							attributes["addrtype"] == "ipv6") {
							
							if (!String.IsNullOrEmpty(tempIpList)) {
								tempIpList += ", ";
							}
							tempIpList += attributes["addr"];
							//+"(" + attributes["addrtype"] + ")";

							elementStack.Push(tag);
						}
					}
				}
			}
			else if (tag.CompareTo("ports") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("host") == 0) {

					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("port") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("ports") == 0) {

					if (attributes.ContainsKey("protocol")) {
						protocol = attributes["protocol"];
					}
					else {
						protocol = "";
					}

					if (attributes.ContainsKey("portid")) {
						portId = attributes["portid"];
					}
					else {
						portId = "";
					}
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("state") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("port") == 0) {

					if (attributes.ContainsKey("state") &&
						attributes["state"] == "open") {
						portState = attributes["state"];
					}
					else {
						portState = "";
					}

					if (attributes.ContainsKey("reason")) {
						reason = attributes["reason"];
					}
					else {
						reason = "";
					}

					if (reason == "no-response") {
						portState = "";
					}

					if (portState != "open") {
						elementStack.Pop();
					}
					else {
						elementStack.Push(tag);
					}
				}
			}
			else if (tag.CompareTo("service") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("port") == 0 &&
					!String.IsNullOrEmpty(portState)) {

					if (attributes.ContainsKey("name")) {
						serviceName = attributes["name"];
					}
					else {
						serviceName = "";
					}

					if (attributes.ContainsKey("product")) {
						product = attributes["product"];
					}
					else {
						product = "";
					}
					elementStack.Push(tag);
				}
			}
			else if (tag.CompareTo("script") == 0) {
				if (elementStack.Count != 0 &&
					elementStack.Peek().CompareTo("port") == 0 &&
					!String.IsNullOrEmpty(portState)) {


					if (attributes.ContainsKey("id")) {
						scriptId[scriptIdCounter] = attributes["id"];
					}
					else {
						scriptId[scriptIdCounter] = "";
					}
					scriptIdCounter++;

					if (attributes.ContainsKey("output")) {
						scriptOutput[scriptIdOutputCounter] = attributes["output"];
					}
					else {
						scriptOutput[scriptIdOutputCounter] = "";
					}
					scriptIdOutputCounter++;

					elementStack.Push(tag);
				}
			}
		}

		/// <summary>
		/// This is the pushContent method.
		/// It is used to handle the content between start tag and end tag from the XML file.
		/// </summary>
		/// <param name="content">the content between start tag an end tag from the XML file</param>
		protected override void pushContent(string content) {
			
		}

		/// <summary>
		/// This is the endTag method.
		/// It is used to handle the end tag from the XML file.
		/// </summary>
		/// <param name="tag">xml end tag name</param>
		protected override void endTag(string tag) {
			if (elementStack.Count != 0) {

				if (tag.CompareTo("host") == 0 && elementStack.Peek().CompareTo("host") == 0) {
					initialize();
					elementStack.Pop();
				}
				else if (tag.CompareTo("port") == 0 && elementStack.Peek().CompareTo("port") == 0) {

					//Console.WriteLine("ip: " + tempIpList);
					//Console.WriteLine("port protocol: " + protocol);
					//Console.WriteLine("portId: " + portId);
					//Console.WriteLine("portState: " + portState);
					//Console.WriteLine("reason: " + reason);
					//Console.WriteLine("serviceName: " + serviceName);
					//Console.WriteLine("product: " + product);

					//for (int i = 1; i < scriptIdCounter; i++) {
					//    Console.WriteLine("scriptId: " + scriptId[i]);
					//    Console.WriteLine("scriptOutput: " + scriptOutput[i]);
					//}

					//Console.WriteLine("##########################################################");
					//Console.WriteLine();

                    // null all the empty values first
					NmapDataEntry entry = new NmapDataEntry("Open Port Findings",
															tempIpList,
															portId + "/" + protocol,
                                                            RiskFactor.OPEN, tempFileName, null, null, null, null, null, null);

					tempRecord.nmapAddEntry(entry);
					scriptIdCounter = 1;
					scriptIdOutputCounter = 1;

					elementStack.Pop();
				}
				else if (elementStack.Peek().CompareTo(tag) == 0) {
					elementStack.Pop();
				}
			}
		}

		/// <summary>
		/// This is the initialize method.
		/// It is used to initialize all variables in this parser after a DataEntry is stored
		/// to the Record.
		/// </summary>
		private void initialize() {
			isNoResponse = false;
			tempIpList = "";
			protocol = "";
			portId = "";
			portState = "";
			reason = "";
			serviceName = "";
			product = "";
			scriptId = new Dictionary<int, string>();
			scriptOutput = new Dictionary<int, string>();
		}

		/// <summary>
		/// This is the isNmapXmlFile method.
		/// </summary>
		/// <param name="filePath">the filepath need to be checked is it a nmap xml file or not</param>
		/// <returns>true if the given filePath is a Nmap XML file.</returns>
		public static bool isNmapXmlFile(string filePath) {
			XmlTextReader reader = new XmlTextReader(filePath);
			try {
				while (reader.Read()) {
					switch (reader.NodeType) {
						case XmlNodeType.Element:

							// in here, only the start tag named nmaprun
							// be classified as Nmap XML file
							if (reader.Name == "nmaprun") {
								return true;
							}
							break;
					}
				}
			}
			catch (System.Xml.XmlException) {
				return false;
			}
			return false;
		}
	}
}
