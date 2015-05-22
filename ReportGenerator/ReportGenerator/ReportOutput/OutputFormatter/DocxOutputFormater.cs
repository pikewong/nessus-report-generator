using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.Record;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	class DocxOutputFormater : OutputDefault {

		public override void output(string path, ref Record.Record record) {
			Dictionary<int, DataEntry> highRisk = record.getHighRisk();
			Dictionary<int, DataEntry> mediumRisk = record.getMediumRisk();
			Dictionary<int, DataEntry> lowRisk = record.getLowRisk();
			Dictionary<int, DataEntry> noneRisk = record.getNoneRisk();
			Dictionary<int, DataEntry> openPort = record.getOpenPort();
			RiskStats riskStats = record.getRiskStats();

			using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document)) {
				MainDocumentPart mainDocumentPart = wordDoc.AddMainDocumentPart();
				Document document = new Document();

				Body body = new Body();
				document.Append(body);

				mainDocumentPart.Document = document;

				// start output
				addParagraph(body, "Risk Statistics", true, 5, false, false);
				addParagraph(body, "High Risk: " + highRisk.Count, false, 2, false, false);
				addParagraph(body, "Medium Risk: " + mediumRisk.Count, false, 2, false, false);
				addParagraph(body, "Low Risk: " + lowRisk.Count, false, 2, false, false);
				addParagraph(body, "None Risk: " + noneRisk.Count, false, 2, false, false);
				addParagraph(body, "Open Port: " + openPort.Count, false, 2, false, false);

				// Per host statistics
				addParagraph(body, "Risk Statistics", true, 5, true, false);
				foreach (KeyValuePair<String, Dictionary<RiskFactor, int>> entry in riskStats.getRiskStats()) {
					String tempString = entry.Key;

					Dictionary<RiskFactor, int> hostRisks = entry.Value;
					foreach (KeyValuePair<RiskFactor, int> hostRisk in hostRisks) {
						if (hostRisk.Key != RiskFactor.NULL) {
							tempString += " " + RiskFactorFunction.getEnumString(hostRisk.Key) + ": " +
								 hostRisk.Value.ToString();
						}
					}
					addParagraph(body, tempString, false, 0, false, false);
				}

				// High Risks
				addParagraph(body, "High Risk Findings\n", true, 2, true, false);
				foreach (KeyValuePair<int, DataEntry> entry in highRisk) {
					addParagraph(body, entry.Value.getPluginName(), true, 0, true, false);
					addTable(body, buildTable(entry.Value, RiskFactor.HIGH));
				}

				// Medium Risks
				addParagraph(body, "Medium Risk Findings\n", true, 2, true, false);
				foreach (KeyValuePair<int, DataEntry> entry in mediumRisk) {
					addParagraph(body, entry.Value.getPluginName(), true, 0, true, false);
					addTable(body, buildTable(entry.Value, RiskFactor.MEDIUM));
				}

				// Low Risks
				addParagraph(body, "Low Risk Findings\n", true, 2, true, false);
				foreach (KeyValuePair<int, DataEntry> entry in lowRisk) {
					addParagraph(body, entry.Value.getPluginName(), true, 0, true, false);
					addTable(body, buildTable(entry.Value, RiskFactor.LOW));
				}

				// None Risks
				addParagraph(body, "None Risk Findings\n", true, 2, true, false);
				foreach (KeyValuePair<int, DataEntry> entry in noneRisk) {
					addParagraph(body, entry.Value.getPluginName(), true, 0, true, false);
					addTable(body, buildTable(entry.Value, RiskFactor.NONE));
				}

				// Open Ports
				addParagraph(body, "Open Ports Findings\n", true, 2, true, false);
				foreach (KeyValuePair<int, DataEntry> entry in openPort) {
					addParagraph(body, entry.Value.getPluginName(), true, 0, true, false);
					addTable(body, buildTable(entry.Value, RiskFactor.OPEN));
				}

			}

		}

		private void addParagraph(Body body, String content, Boolean bold, int spacing, bool insertParagraphBefore, bool insertParagraphAfter) {
			if (insertParagraphBefore) {
				body.Append(new Paragraph());
			}

			Paragraph paragraph = new Paragraph(new ParagraphProperties());

			if (spacing != 0) {
				paragraph.ParagraphProperties.Append(new SpacingBetweenLines() {
					BeforeLines = spacing,
					AfterLines = spacing
				});
			}

			Run run = new Run(new RunProperties());
			if (bold) {
				run.RunProperties.Append(new Bold() {
					Val = OnOffValue.FromBoolean(true)
				});
			}

			Text text = new Text(content);

			run.Append(text);
			paragraph.Append(run);
			body.Append(paragraph);

			if (insertParagraphAfter) {
				body.Append(new Paragraph());
			}
		}

		private void addTable(Body body, Dictionary<KeyValuePair<int, int>, String> t) {
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

			body.Append(table);
		}

		private Dictionary<KeyValuePair<int, int>, String> buildTable(DataEntry entry, RiskFactor riskFactor) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Hosts Affected
			table[new KeyValuePair<int, int>(1, 1)] = "Hosts Affected:";

			String tempString = entry.getIp();
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
	}
}
