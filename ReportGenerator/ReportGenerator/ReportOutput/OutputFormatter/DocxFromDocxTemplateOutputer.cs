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
	class DocxFromDocxTemplateOutputer : OutputFromTemplateFormater{

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
						if (dict.ContainsKey(text)) {
							text = dict[text];
							textChanged = true;
						}
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

						if (textChanged) {
							foreach (OpenXmlLeafTextElement textElement in textElements) {
								if (textElement == textElements.First()) {
									textElements.First().Text = beforeReplaceText + text + afterReplaceText;
								}
								else {
									textElement.Remove();
								}
							}
						}
					}
				}

				doc.MainDocumentPart.Document.Save();
			}
		}

		public void printHighRisk(Paragraph paragraph) {
			String s = "5.2.1.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getHighRisk()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.Value.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.Value.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));
				paragraph.InsertBeforeSelf(addTable(buildTable(entry.Value, RiskFactor.HIGH)));
				no++;
			}
		}

		public void printMediumRisk(Paragraph paragraph) {
			String s = "5.2.2.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getMediumRisk()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.Value.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.Value.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));				
				paragraph.InsertBeforeSelf<Table>(addTable(buildTable(entry.Value, RiskFactor.MEDIUM)));
				no++;
			}
		}

		public void printLowRisk(Paragraph paragraph) {
			String s = "5.2.3.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getLowRisk()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.Value.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.Value.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));
				paragraph.InsertBeforeSelf<Table>(addTable(buildTable(entry.Value, RiskFactor.LOW)));
				no++;
			}
		}

		public void printNoneRisk(Paragraph paragraph) {
			String s = "5.2.4.";
			int no = 1;
			
			foreach (KeyValuePair<int, DataEntry> entry in record.getNoneRisk()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.Value.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.Value.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));
				paragraph.InsertBeforeSelf<Table>(addTable(buildTable(entry.Value, RiskFactor.NONE)));
				no++;
			}
		}

		public void printOpenPort(Paragraph paragraph) {
			String s = "5.2.5.";
			int no = 1;

			foreach (KeyValuePair<int, DataEntry> entry in record.getOpenPort()) {
				if (no == 1) {
					foreach (OpenXmlLeafTextElement text in paragraph.Descendants<OpenXmlLeafTextElement>()) {
						if (text == paragraph.Descendants<OpenXmlLeafTextElement>().First()) {
							text.Text = s + no.ToString() + " " + entry.Value.getPluginName();
						}
						else {
							text.Remove();
						}
					}
				}
				else {
					paragraph.InsertBeforeSelf(addParagraph(s + no.ToString() + " " + entry.Value.getPluginName(), paragraph));
				}
				paragraph.InsertBeforeSelf(addParagraph("", paragraph));
				paragraph.InsertBeforeSelf<Table>(addTable(buildTable(entry.Value, RiskFactor.OPEN)));
				no++;
			}
		}

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

						switch (text) {
							//case "[Title]":
							//case "[(RESTRICTED)]":
							//case "[date]":
							//case "[version]":
							//case "[Responsible person]":
							//case "[phone]":
							//case "[ver 0.1 date]":
							//case "[ver 0.1 revisor]":
							//case "[ver 0.1 description]":
							//case "[ver 1.0 date]":
							//case "[ver 1.0 revisor]":
							//case "[ver 1.0 description]":
							//case "[Executive Summary]":
							//case "[Risk Severity Table]":
							//    break;
							case "[number of high risk items]":
							case "[number of medium risk items]":
							case "[number of low risk items]":
							case "[number of AOI risk items]":
							case "[number of total risk items]":
							case "[High Risk Issues]":
							case "[Medium Risk Issues]":
							case "[Low Risk Issues]":
							case "[Area of Improvement]":
							case "[Conclusions]":
								break;
							//case "[tool name 001]":
							//case "[tool description 001]":
							//case "[tool name 002]":
							//case "[tool description 002]":
							//	break;
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

			for (int r = 1; r <= 6; r++) {
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

		private Dictionary<KeyValuePair<int, int>, String> buildTable(DataEntry entry, RiskFactor riskFactor) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Hosts Affected
			table[new KeyValuePair<int, int>(1, 1)] = "Hosts Affected:";

			String tempString = "";
			foreach (String ip in entry.getIpList()) {
				tempString += ip + '\n';
			}
			table[new KeyValuePair<int, int>(1, 2)] = tempString.Substring(0, tempString.Length - 1);

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
			bool hasRef = false;
			table[new KeyValuePair<int, int>(6, 1)] = "Reference:";

			tempString = "";
			// CVE
			if (entry.getCve() != null) {
				hasRef = true;
				tempString = "CVE: " + entry.getCve() + "\n";
			}

			// BID
			if (entry.getBid() != null) {
				hasRef = true;
				tempString += "BID: " + entry.getBid() + "\n";
			}

			// OSVDB
			if (entry.getOsvdb() != null) {
				hasRef = true;
				tempString += "OSVDB: " + entry.getOsvdb();
			}

			if (!hasRef) {
				tempString = "N/A";
			}
			table[new KeyValuePair<int, int>(6, 2)] = tempString;

			return table;
		}

		private void calculateRiskStats(){
			noOfHighRiskItems = record.getHighRisk().Count;
			noOfMediumRiskItems = record.getMediumRisk().Count;
			noOfLowRiskItems = record.getLowRisk().Count;
			noOfNoneRiskItems = record.getNoneRisk().Count;

			totalItems = noOfHighRiskItems + noOfMediumRiskItems + noOfLowRiskItems + noOfNoneRiskItems;

			percentageOfHigh = (noOfHighRiskItems + 0.0) / totalItems;
			percentageOfMedium = (noOfMediumRiskItems + 0.0) / totalItems;
			percentageOfLow = (noOfLowRiskItems + 0.0) / totalItems;
			percentageOfNone = (noOfNoneRiskItems + 0.0) / totalItems;
		}
	}
}
