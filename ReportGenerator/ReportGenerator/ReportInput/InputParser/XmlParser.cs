using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.Record;
using System.Xml;

namespace ReportGenerator.ReportInput.InputParser {
	public abstract class XmlParser : Parser{

		// XmlParser functions

		public override void getData(string filePath, ref Record.Record record) {
			this.tempRecord = record;

			XmlTextReader reader = new XmlTextReader(filePath);
			Dictionary<String, String> attributes = null;
			String name = null;

			while (reader.Read()) {
				switch (reader.NodeType) {
					case XmlNodeType.Element:
						if (reader.Name != null) {
							bool isEndTag = reader.IsEmptyElement;

							name = reader.Name;
							attributes = new Dictionary<string, string>();

							while (reader.MoveToNextAttribute()) // Read the attributes
								attributes[reader.Name] = reader.Value;

							startTag(name, attributes);

							if (isEndTag) {
								endTag(name);
							}
						}

						break;
					case XmlNodeType.Text:
						pushContent(reader.Value);
						break;
					case XmlNodeType.EndElement:
						endTag(reader.Name);
						break;
				}
			}
		}

		abstract protected void startTag(String tag, Dictionary<String, String> attributes);
		abstract protected void pushContent(String content);
		abstract protected void endTag(String tag);
	}
}
