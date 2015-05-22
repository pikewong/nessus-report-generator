using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.Record;
using System.Xml;

namespace ReportGenerator.ReportInput.InputParser {

	/// <summary>
	/// This is the XmlParser Class.
	/// This is the parent class of all XML Parser.
	/// </summary>
	public abstract class XmlParser : Parser{

		/// <summary>
		/// This is the getData method.
		/// It is used to get data from the given XML file path and store
		/// those data in given Record.
		/// </summary>
		/// <param name="filePath">the file path includes the needed information</param>
		/// <param name="record">the record storing the output</param>
		public override void getData(string filePath, ref Record.Record record) {
			this.tempRecord = record;

			XmlTextReader reader = new XmlTextReader(filePath);
			Dictionary<String, String> attributes = null;
			String name = null;

			// read the xml file
			while (reader.Read()) {
				switch (reader.NodeType) {
					case XmlNodeType.Element:
						if (reader.Name != null) {

							// isEndTag here checks for self-ended tag
							bool isEndTag = reader.IsEmptyElement;

							name = reader.Name;
							attributes = new Dictionary<string, string>();

							while (reader.MoveToNextAttribute()) { // Read the attributes
								attributes[reader.Name] = reader.Value;
							}

							// action for startTag
							startTag(name, attributes);

							// is self-ended tag, take action on endTag
							if (isEndTag) {
								 endTag(name);
							}
						}
						break;
					case XmlNodeType.Text:
						pushContent(reader.Value);
						break;
                    case XmlNodeType.CDATA:
                        pushContent(reader.Value);
						break;
					case XmlNodeType.EndElement:
						endTag(reader.Name);
						break;
				}
			}
		}

		/// <summary>
		/// This is the abstract startTag method.
		/// It is used to handle the start tag/self closed tag from the XML file.
		/// </summary>
		/// <param name="tag">xml start tag name</param>
		/// <param name="attributes">xml tag's attributes</param>
		abstract protected void startTag(String tag, Dictionary<String, String> attributes);

		/// <summary>
		/// This is the abstract pushContent method.
		/// It is used to handle the content between start tag and end tag from the XML file.
		/// </summary>
		/// <param name="content">the content between start tag an end tag from the XML file</param>
		abstract protected void pushContent(String content);

		/// <summary>
		/// This is the abstract endTag method.
		/// It is used to handle the end tag from the XML file.
		/// </summary>
		/// <param name="tag">xml end tag name</param>
		abstract protected void endTag(String tag);
	}
}
