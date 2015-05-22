using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ReportGenerator.Record;

namespace ReportGenerator.ReportOutput.OutputFormatter {

	/// <summary>
	/// This is the OutputFromTemplateFormater Class.
	/// This is the parent class of all OutputFromTemplateFormater output formater.
	/// (With reference file)
	/// </summary>
	class DocxFromDocxTemplateOutputer : OutputFromTemplateFormater{

		// Variables
		private Record.Record record = null;
		private int noOfHighRiskItems;
		private int noOfMediumRiskItems;
		private int noOfLowRiskItems;
		private int noOfNoneRiskItems;
		private int totalItems;
		private double percentageOfHigh;
		private double percentageOfMedium;
		private double percentageOfLow;
		private double percentageOfNone;

		/// <summary>
		/// This is the abstract output method.
		/// It is used to output the file from given path and also given Record,
		/// with reference to the given template path and also a dictionary includes
		/// the string to be replaced.
		/// </summary>
		/// <param name="path">the file path for output</param>
		/// <param name="template">the template path for output</param>
		/// <param name="record">the Record for output</param>
		/// <param name="dict">the dict for string replacement</param>
		public override void output(string path, string template, ref Record.Record record, ref Dictionary<String, String> dict) {
			if (!File.Exists(template)) {
				Console.Error.WriteLine("The Template doesn't exist.");
				Environment.Exit(0);
			}

			this.record = record;
			File.Copy(template, path, true);

			calculateRiskStats();

			using (WordprocessingDocument doc = WordprocessingDocument.Open(path, true)) {
				// Obtain all paragraphs
				Paragraph[] paragraphs = doc.MainDocumentPart.Document.Descendants<Paragraph>().ToArray<Paragraph>();

				foreach (Paragraph paragraph in paragraphs) {
					
					// Obtain the whole text from each paragraph
					OpenXmlLeafTextElement[] textElements = paragraph.Descendants<OpenXmlLeafTextElement>().ToArray<OpenXmlLeafTextElement>();
					String wholeText = "";
					foreach (OpenXmlLeafTextElement textElement in textElements) {
						wholeText += textElement.Text;
					}

					// if the whole text contains '[' and contains ']', it's a string need to replace
					if (wholeText.Contains('[') && wholeText.Contains(']')) {
						String beforeReplaceText;
						String afterReplaceText;
						String text;

						if (wholeText.IndexOf('[') == 0) {
							beforeReplaceText = "";
						}
						else {
							beforeReplaceText = wholeText.Substring(0, wholeText.IndexOf('['));
						}
						text = wholeText.Substring(wholeText.IndexOf('['), wholeText.LastIndexOf(']') - wholeText.IndexOf('[') + 1);
						if (wholeText.LastIndexOf(']') == wholeText.Length - 1) {
							afterReplaceText = "";
						}
						else {
							afterReplaceText = wholeText.Substring(wholeText.LastIndexOf(']') + 1);
						}

						bool textChanged = false;
						
						// replace text if the text appears in keys in dict
						if (dict.ContainsKey(text)) {
							text = dict[text];
							textChanged = true;
						}

						// otherwise
						else {
							switch (text) {
								case "[Title]":
									text = "eWalker";
									textChanged = true;
									break;
								case "[(RESTRICTED)]":
									text = "(RESTRICTED)";
									textChanged = true;
									break;
								case "[date]":
									text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
									textChanged = true;
									break;
								case "[version]":
									text = "1.0";
									textChanged = true;
									break;
								case "[Responsible person]":
									text = "Ricci IEONG, Principal Consultant";
									textChanged = true;
									break;
								case "[phone]":
									text = "+852 3520 4004";
									textChanged = true;
									break;
								case "[ver 0.1 date]":
									text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
									textChanged = true;
									break;
								case "[ver 0.1 revisor]":
									text = "eWalker Project Team";
									textChanged = true;
									break;
								case "[ver 0.1 description]":
									text = "First release";
									textChanged = true;
									break;
								case "[ver 1.0 date]":
									text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
									textChanged = true;
									break;
								case "[ver 1.0 revisor]":
									text = "eWalker Project Team";
									textChanged = true;
									break;
								case "[ver 1.0 description]":
									text = "Second release";
									textChanged = true;
									break;
								case "[Executive Summary]":
									text = "// TODO: Executive Summary";
									textChanged = true;
									break;
								case "[Risk Severity Table]":
									break;
								case "[number of high risk items]":
									text = noOfHighRiskItems.ToString() + " (" + String.Format("{0:0.00}", percentageOfHigh*100) + "%)";
									textChanged = true;
									break;
								case "[number of medium risk items]":
									text = noOfMediumRiskItems.ToString() + " (" + String.Format("{0:0.00}", percentageOfMedium * 100) + "%)";
									textChanged = true;
									break;
								case "[number of low risk items]":
									text = noOfLowRiskItems.ToString() + " (" + String.Format("{0:0.00}", percentageOfLow * 100) + "%)";
									textChanged = true;
									break;
								case "[number of AOI risk items]":
									text = noOfNoneRiskItems.ToString() + " (" + String.Format("{0:0.00}", percentageOfNone * 100) + "%)";
									textChanged = true;
									break;
								case "[number of total risk items]":
									text = totalItems.ToString();
									textChanged = true;
									break;
								case "[High Risk Issues]":
									printHighRisk(paragraph);
									break;
								case "[Medium Risk Issues]":
									printMediumRisk(paragraph);
									break;
								case "[Low Risk Issues]":
									printLowRisk(paragraph);
									break;
								case "[Area of Improvement]":
									printNoneRisk(paragraph);
									break;
								case "[Hotfix Findings]":
									printHotfix(paragraph);
									break;
								case "[OpenPort Findings]":
									printOpenPort(paragraph);
									break;
								case "[Conclusions]":
									break;
								case "[tool name 001]":
									break;
								case "[tool description 001]":
									break;
								case "[tool name 002]":
									break;
								case "[tool description 002]":
									break;
								default:
									break;
							}
						}

						// textChanged here means the current paragraph need to clear
						// and append a new text before it
						if (textChanged) {
							int limit = textElements.Count();
							for (int i = 0; i < limit; i++) {
								textElements.ElementAt(i).Text = "";
							}
							
							textElements.ElementAt(0).InsertBeforeSelf(new Text(beforeReplaceText));
							
							String[] s = text.Split('\n');
							for (int j = 0; j < s.Count(); j++) {
								if (j > 0) {
									textElements.ElementAt(0).InsertBeforeSelf(new Break());
								}
								textElements.ElementAt(0).InsertBeforeSelf(new Text(s[j]));
							}

							textElements.ElementAt(0).InsertAfterSelf(new Text(afterReplaceText));
						}
					}
				}

				doc.MainDocumentPart.Document.Save();
			}
		}

		/// <summary>
		/// This is the getStringNeedReplace method.
		/// It is used to get a dictionary with strings that needs replace from the
		/// given template path.
		/// </summary>
		/// <param name="templatePath">the template path that requires string replacement</param>
		/// <returns>a dictionary with strings needs to replace.</returns>
		public Dictionary<String, String> getStringNeedReplace(string templatePath) {
			Dictionary<String, String> dict = new Dictionary<string, string>();

			using (WordprocessingDocument doc = WordprocessingDocument.Open(templatePath, true)) {
				// Obtain all paragraphs
				Paragraph[] paragraphs = doc.MainDocumentPart.Document.Descendants<Paragraph>().ToArray<Paragraph>();

				foreach (Paragraph paragraph in paragraphs) {

					// Obtain the whole text from each paragraph
					OpenXmlLeafTextElement[] textElements = paragraph.Descendants<OpenXmlLeafTextElement>().ToArray<OpenXmlLeafTextElement>();
					String wholeText = "";
					foreach (OpenXmlLeafTextElement textElement in textElements) {
						wholeText += textElement.Text;
					}

					// if the whole text contains '[' and contains ']', it's a string need to replace
					if (wholeText.Contains('[') && wholeText.Contains(']')) {
						String beforeReplaceText;
						String afterReplaceText;
						String text;

						if (wholeText.IndexOf('[') == 0) {
							beforeReplaceText = "";
						}
						else {
							beforeReplaceText = wholeText.Substring(0, wholeText.IndexOf('['));
						}
						text = wholeText.Substring(wholeText.IndexOf('['), wholeText.LastIndexOf(']') - wholeText.IndexOf('[') + 1);
						if (wholeText.LastIndexOf(']') == wholeText.Length - 1) {
							afterReplaceText = "";
						}
						else {
							afterReplaceText = wholeText.Substring(wholeText.LastIndexOf(']') + 1);
						}

						// here, you can say it's "reserved words"
						switch (text) {
							case "[number of high risk items]":
							case "[number of medium risk items]":
							case "[number of low risk items]":
							case "[number of AOI risk items]":
							case "[number of total risk items]":
							case "[High Risk Issues]":
							case "[Medium Risk Issues]":
							case "[Low Risk Issues]":
							case "[Area of Improvement]":
							case "[Hotfix Findings]":
							case "[OpenPort Findings]":
								break;
							default:
								dict[text] = "";
								break;
						}
					}
				}

				doc.Close();
			}

			return dict;
		}

		/// <summary>
		/// This is the printHighRisk method.
		/// It is used to output the high risk findings before the given paragraph.
		/// </summary>
		/// <param name="paragraph">the location where the data should append to</param>
		public void printHighRisk(Paragraph paragraph) {
			String s = "5.2.1.";
			int no = 1;
			foreach (DataEntry entry in record.getHighRiskEntriesWithoutHotfix()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));
				paragraph.InsertBeforeSelf(addTable(buildTable(entry, RiskFactor.HIGH)));
				no++;
			}
		}

		/// <summary>
		/// This is the printMediumRisk method.
		/// It is used to output the medium risk findings before the given paragraph.
		/// </summary>
		/// <param name="paragraph">the location where the data should append to</param>
		public void printMediumRisk(Paragraph paragraph) {
			String s = "5.2.2.";
			int no = 1;
			foreach (DataEntry entry in record.getMediumRiskEntriesWithoutHotfix()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));				
				paragraph.InsertBeforeSelf<Table>(addTable(buildTable(entry, RiskFactor.MEDIUM)));
				no++;
			}
		}

		/// <summary>
		/// This is the printLowRisk method.
		/// It is used to output the low risk findings before the given paragraph.
		/// </summary>
		/// <param name="paragraph">the location where the data should append to</param>
		public void printLowRisk(Paragraph paragraph) {
			String s = "5.2.3.";
			int no = 1;
			foreach (DataEntry entry in record.getLowRiskEntriesWithoutHotfix()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));
				paragraph.InsertBeforeSelf<Table>(addTable(buildTable(entry, RiskFactor.LOW)));
				no++;
			}
		}

		/// <summary>
		/// This is the printHighRisk method.
		/// It is used to output the none risk findings (AOI (Area of improvement))
		/// before the given paragraph.
		/// </summary>
		/// <param name="paragraph">the location where the data should append to</param>
		public void printNoneRisk(Paragraph paragraph) {
			String s = "5.2.4.";
			int no = 1;
			
			foreach (DataEntry entry in record.getNoneRiskEntriesWithoutHotfix()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));
				paragraph.InsertBeforeSelf<Table>(addTable(buildTable(entry, RiskFactor.NONE)));
				no++;
			}
		}

		/// <summary>
		/// This is the printHotfix method.
		/// It is used to output the hotfix findings before the given paragraph.
		/// </summary>
		/// <param name="paragraph">the location where the data should append to</param>
		public void printHotfix(Paragraph paragraph) {
			if (Program.state.panelOutputSelect_isOutputHotfix) {
				paragraph.InsertBeforeSelf<Table>(addTable(buildTableHotfix(new Hotfix(record))));
			}
			foreach (OpenXmlLeafTextElement textElement in paragraph.Descendants<OpenXmlLeafTextElement>().ToArray()) {
				textElement.Text = "";
			}
		}

		/// <summary>
		/// This is the printOpenPort method.
		/// It is used to output the open port findings before the given paragraph.
		/// </summary>
		/// <param name="paragraph">the location where the data should append to</param>
		public void printOpenPort(Paragraph paragraph) {
			if (Program.state.panelOutputSelect_isOutputOpenPort) {
				paragraph.InsertBeforeSelf<Table>(addTable(buildTableOpenPort(record.getOpenPort())));
			}
			foreach (OpenXmlLeafTextElement textElement in paragraph.Descendants<OpenXmlLeafTextElement>().ToArray()) {
				textElement.Text = "";
			}
		}

		/// <summary>
		/// This is the addParagraph method.
		/// It is used to add the given content on the given paragraph.
		/// </summary>
		/// <param name="content">the content added to the paragraph</param>
		/// <param name="paragraph">the paragraph as a style reference</param>
		/// <returns>a paragraph with content</returns>
		private Paragraph addParagraph(String content, Paragraph paragraph) {
			Paragraph newParagraph = new Paragraph() {
				InnerXml = paragraph.InnerXml
			};
			foreach (OpenXmlLeafTextElement textElement in paragraph.Descendants<OpenXmlLeafTextElement>().ToArray<OpenXmlLeafTextElement>()) {
				if (textElement == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
					textElement.Text = content;
				}
				else {
					textElement.Remove();
				}
			}
			return newParagraph;
		}

		/// <summary>
		/// This is the addTable method.
		/// It is used to add the table from given dictionary t.
		/// </summary>
		/// <param name="t">dictionary with table's values.</param>
		/// <returns>a table that would append to the document</returns>
		private Table addTable(Dictionary<KeyValuePair<int, int>, String> t) {
			Table table = new Table();

			// Create a TableProperties object and specify its border information.
			TableProperties tblProp = new TableProperties(
				new TableBorders(
					new TopBorder() {
						Val = new EnumValue<BorderValues>(BorderValues.Single),
						Size = 2
					},
					new BottomBorder() {
						Val = new EnumValue<BorderValues>(BorderValues.Single),
						Size = 2
					},
					new LeftBorder() {
						Val = new EnumValue<BorderValues>(BorderValues.Single),
						Size = 2
					},
					new RightBorder() {
						Val = new EnumValue<BorderValues>(BorderValues.Single),
						Size = 2
					},
					new InsideHorizontalBorder() {
						Val = new EnumValue<BorderValues>(BorderValues.Single),
						Size = 2
					},
					new InsideVerticalBorder() {
						Val = new EnumValue<BorderValues>(BorderValues.Single),
						Size = 2
					}
				)
			);

			// Append the TableProperties object to the empty table.
			table.AppendChild<TableProperties>(tblProp);

			for (int r = 1; r <= t.Keys.Count / 2; r++) {
				// Create a row.
				TableRow tr = new TableRow();

				// Create two table cells.
				TableCell tc1 = new TableCell();
				TableCell tc2 = new TableCell();

				// Specify the width property of the table cell.
				tc1.Append(new TableCellProperties(
					new TableCellWidth() {
						Type = TableWidthUnitValues.Dxa,
						Width = "2400"
					}));
				tc2.Append(new TableCellProperties(
					new TableCellWidth() {
						Type = TableWidthUnitValues.Dxa,
						Width = "10000"
					}));

				// Specify the table cell content.
				tc1.Append(new Paragraph(new Run(new Text(t[new KeyValuePair<int, int>(r, 1)]))));

				String[] s = t[new KeyValuePair<int, int>(r, 2)].Split('\n');
				foreach (String tempString in s) {
					tc2.Append(new Paragraph(new ParagraphProperties(
					new SpacingBetweenLines() {
						Before = "0",
						After = "0",
						BeforeAutoSpacing = OnOffValue.FromBoolean(false),
						AfterAutoSpacing = OnOffValue.FromBoolean(false)
					}) {
					}, new Run(new RunProperties() {
					}, new Text(tempString))));
				}

				// Append the table cell to the table row.
				tr.Append(tc1);
				tr.Append(tc2);

				// Append the table row to the table.
				table.Append(tr);
			}

			return table;
		}

		/// <summary>
		/// This is the buildTable method.
		/// It is used to build the table from given entry and riskFactor.
		/// </summary>
		/// <param name="entry">the DataEntry being transformed to a dictionary</param>
		/// <param name="riskFactor">the RiskFactor of the entry.</param>
		/// <returns>a dictionary with table's values</returns>
		private Dictionary<KeyValuePair<int, int>, String> buildTable(DataEntry entry, RiskFactor riskFactor) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Hosts Affected
			table[new KeyValuePair<int, int>(1, 1)] = "Hosts Affected:";
			table[new KeyValuePair<int, int>(1, 2)] = entry.getIp();

			// Description
			table[new KeyValuePair<int, int>(2, 1)] = "Description";
			table[new KeyValuePair<int, int>(2, 2)] = entry.getDescription();

			// Impact
			table[new KeyValuePair<int, int>(3, 1)] = "Impact:";
			table[new KeyValuePair<int, int>(3, 2)] = entry.getImpact();

			// Risk Level
			table[new KeyValuePair<int, int>(4, 1)] = "Risk Level:";
			table[new KeyValuePair<int, int>(4, 2)] = RiskFactorFunction.getEnumString(riskFactor);

			// Recommendations
			table[new KeyValuePair<int, int>(5, 1)] = "Recommendation:";
			table[new KeyValuePair<int, int>(5, 2)] = entry.getRecommendation();

			// Reference
			table[new KeyValuePair<int, int>(6, 1)] = "Reference:";

			// CVE/BID/OSVDB
			String tempString = "";
			if (!String.IsNullOrEmpty(entry.getCve()) ||
				!String.IsNullOrEmpty(entry.getBid()) ||
				!String.IsNullOrEmpty(entry.getOsvdb())) {

				// CVE
				if (!String.IsNullOrEmpty(entry.getCve())) {
					tempString = "CVE: " + entry.getCve() + "\n";
				}

				// BID
				if (!String.IsNullOrEmpty(entry.getBid())) {
					tempString += "BID: " + entry.getBid() + "\n";
				}

				// OSVDB
				if (!String.IsNullOrEmpty(entry.getOsvdb())) {
					tempString += "OSVDB: " + entry.getOsvdb();
				}
			}
			else {
				tempString = "N/A";
			}
			table[new KeyValuePair<int, int>(6, 2)] = tempString;

			// Reference Link
			if (!String.IsNullOrEmpty(entry.getReferenceLink())) {
				table[new KeyValuePair<int, int>(7, 1)] = "Reference Link";
				table[new KeyValuePair<int, int>(7, 2)] = entry.getReferenceLink();
			}

			return table;
		}

		/// <summary>
		/// This is the buildTableHotfix method.
		/// It is used to build the hotfix table from given hotfix findings.
		/// </summary>
		/// <param name="hotfix">the hotfix for making dictionary with table's values</param>
		/// <returns>a dictionary with table's values</returns>
		private Dictionary<KeyValuePair<int, int>, String> buildTableHotfix(Hotfix hotfix) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Header
			table[new KeyValuePair<int, int>(1, 1)] = "Host";
			table[new KeyValuePair<int, int>(1, 2)] = "Missing Hotfix(s)";

			Dictionary<String, String> hotfixList = hotfix.getHotfixListGroupByHost();
			int rowCounter = 2;

			// hotfix data (ip, missing hotfix)
			foreach (KeyValuePair<String, String> keyValuePair in hotfixList) {
				table[new KeyValuePair<int, int>(rowCounter, 1)] = keyValuePair.Key;
				table[new KeyValuePair<int, int>(rowCounter, 2)] = keyValuePair.Value;
				rowCounter++;
			}

			return table;
		}

		/// <summary>
		/// This is the buildTableOpenPort method.
		/// It is used to build the openport findings tbale from given open port findings
		/// </summary>
		/// <param name="risk">the open port findings to be output</param>
		/// <returns>a dictionary with table's values</returns>
		private Dictionary<KeyValuePair<int, int>, String> buildTableOpenPort(Dictionary<int, DataEntry> risk) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Header
			table[new KeyValuePair<int, int>(1, 1)] = "Host";
			table[new KeyValuePair<int, int>(1, 2)] = "Open Port(s)";

			int rowCounter = 2;

			// open port data (ip, open port list)
			foreach (DataEntry entry in risk.Values) {
				table[new KeyValuePair<int, int>(rowCounter, 1)] = entry.getIp();
				table[new KeyValuePair<int, int>(rowCounter, 2)] = entry.getDescription();
				rowCounter++;
			}

			return table;
		}

		/// <summary>
		/// This is the calculateRiskStats method.
		/// It is used to calculate the risk stats and store those values to the private
		/// variables.
		/// </summary>
		private void calculateRiskStats(){
			noOfHighRiskItems = record.getHighRiskEntriesWithoutHotfix().Count;
			noOfMediumRiskItems = record.getMediumRiskEntriesWithoutHotfix().Count;
			noOfLowRiskItems = record.getLowRiskEntriesWithoutHotfix().Count;
			noOfNoneRiskItems = record.getNoneRiskEntriesWithoutHotfix().Count;

			totalItems = noOfHighRiskItems + noOfMediumRiskItems + noOfLowRiskItems + noOfNoneRiskItems;

			percentageOfHigh = (noOfHighRiskItems + 0.0) / totalItems;
			percentageOfMedium = (noOfMediumRiskItems + 0.0) / totalItems;
			percentageOfLow = (noOfLowRiskItems + 0.0) / totalItems;
			percentageOfNone = (noOfNoneRiskItems + 0.0) / totalItems;
		}
	}
}
