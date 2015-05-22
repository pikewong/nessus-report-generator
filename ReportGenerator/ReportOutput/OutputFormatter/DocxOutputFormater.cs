using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.Record;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ReportGenerator.ReportOutput.OutputFormatter {

	/// <summary>
	/// This is the DocxOutputFormater Class.
	/// It is used to create the docx report output.
	/// </summary>
	class DocxOutputFormater : OutputDefault {
        StyleDefinitionsPart styleDefinitionsPart;
		/// <summary>
		/// This is the output method.
		/// It is used to output the file from given path and also given Record.
		/// </summary>
		/// <param name="path">the file path for output</param>
		/// <param name="record">the Record for output</param>
		public override void output(string path, ref Record.Record record) {
			
			#region // get Useful Data
			List<DataEntry> highRisk = record.getHighRiskEntriesWithoutHotfix();
			List<DataEntry> mediumRisk = record.getMediumRiskEntriesWithoutHotfix();
			List<DataEntry> lowRisk = record.getLowRiskEntriesWithoutHotfix();
			List<DataEntry> noneRisk = record.getNoneRiskEntriesWithoutHotfix();

			Dictionary<int, DataEntry> openPort = new Dictionary<int, DataEntry>();
			if (Program.state.panelOutputSelect_isOutputOpenPort) {
				openPort = record.getOpenPort();
			}

			List<DataEntry> tempEntries = record.getWholeEntriesWithoutOpenPortAndHotfix();
			Record.Record tempRecord = new Record.Record();
			foreach (DataEntry entry in tempEntries) {
				tempRecord.guiAddEntry(entry);
			}
			if (Program.state.panelOutputSelect_isOutputOpenPort) {
				foreach (DataEntry entry in openPort.Values) {
					tempRecord.guiAddEntry(entry);
				}
			}

			RiskStats riskStats = tempRecord.getRiskStats();
			#endregion

			using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document)) {
				MainDocumentPart mainDocumentPart = wordDoc.AddMainDocumentPart();

                styleDefinitionsPart = wordDoc.MainDocumentPart.StyleDefinitionsPart;
                // If the Styles part does not exist, add it and then add the style.
                if (styleDefinitionsPart == null)
                {
                    styleDefinitionsPart = AddStylesPartToPackage(wordDoc);
                    // Code removed here...
                }
                AddNewStyle(styleDefinitionsPart, "entry_heading", "Entry_heading");

				Document document = new Document();

				Body body = new Body();
				document.Append(body);

				mainDocumentPart.Document = document;

				#region // print Risk Statistics
				// start output
				addParagraph(body, "Risk Statistics", true, 5, false, false);
				addParagraph(body, "High Risk: " + highRisk.Count, false, 2, false, false);
				addParagraph(body, "Medium Risk: " + mediumRisk.Count, false, 2, false, false);
				addParagraph(body, "Low Risk: " + lowRisk.Count, false, 2, false, false);
				addParagraph(body, "None Risk: " + noneRisk.Count, false, 2, false, false);

				if (Program.state.panelOutputSelect_isOutputOpenPort) {
					addParagraph(body, "Open Port: " + openPort.Count, false, 2, false, false);
				}
				#endregion

				#region // print Host Statistics
				// Per host statistics
				addParagraph(body, "Risk Statistics", true, 5, true, false);
				foreach (KeyValuePair<String, Dictionary<RiskFactor, int>> entry in riskStats.getRiskStats()) {
					String tempString = entry.Key;

					Dictionary<RiskFactor, int> hostRisks = entry.Value;
					foreach (KeyValuePair<RiskFactor, int> hostRisk in hostRisks) {
						if (hostRisk.Key != RiskFactor.NULL) {
							if (hostRisk.Key != RiskFactor.OPEN ||
								(hostRisk.Key == RiskFactor.OPEN && Program.state.panelOutputSelect_isOutputOpenPort)) {

								tempString += " " + RiskFactorFunction.getEnumString(hostRisk.Key) + ": ";

								if (hostRisk.Key != RiskFactor.OPEN) {
									tempString += hostRisk.Value.ToString();
								}
								else if (Program.state.panelOutputSelect_isOutputOpenPort) {
									bool isOutput = false;

									foreach (DataEntry tempEntry in openPort.Values) {
										if (tempEntry.getIp() == entry.Key) {
											tempString += tempEntry.getDescription().Split(',').Length.ToString();
											isOutput = true;
											break;
										}
									}

									if (!isOutput) {
										tempString += "0";
									}
								}
							}
						}
					}
					addParagraph(body, tempString, false, 0, false, false);
				}
				#endregion

				#region // print HIGH/MEDIUM/LOW/NONE Findings
				// High Risks
				addParagraph(body, "High Risk Findings\n", true, 2, true, false);
				foreach (DataEntry entry in highRisk) {
                    addParagraph(body, entry.getPluginName(), true, 0, true, false, true);
					addTable(body, buildTable(entry, RiskFactor.HIGH));
				}

				// Medium Risks
				addParagraph(body, "Medium Risk Findings\n", true, 2, true, false);
				foreach (DataEntry entry in mediumRisk) {
                    addParagraph(body, entry.getPluginName(), true, 0, true, false, true);
					addTable(body, buildTable(entry, RiskFactor.MEDIUM));
				}

				// Low Risks
				addParagraph(body, "Low Risk Findings\n", true, 2, true, false);
				foreach (DataEntry entry in lowRisk) {
                    addParagraph(body, entry.getPluginName(), true, 0, true, false, true);
					addTable(body, buildTable(entry, RiskFactor.LOW));
				}

				// None Risks
				addParagraph(body, "None Risk Findings\n", true, 2, true, false);
				foreach (DataEntry entry in noneRisk) {
                    addParagraph(body, entry.getPluginName(), true, 0, true, false, true);
					addTable(body, buildTable(entry, RiskFactor.NONE));
				}
				#endregion

				#region // print Missing Hotfix findings
				if (Program.state.panelOutputSelect_isOutputHotfix) {
					addParagraph(body, "Missing Hotfix Findings\n", true, 2, true, false);
					addTable(body, buildTableHotfix(new Hotfix(record)));
				}
				#endregion

				#region // print Open Port Findings
				// Open Ports
				if (Program.state.panelOutputSelect_isOutputOpenPort) {
					addParagraph(body, "Open Ports Findings\n", true, 2, true, false);
					addTable(body, buildTableOpenPort(openPort));
				}
				#endregion

                #region // print IP Host Table
                // Open Ports
                if (Program.state.panelOutputSelect_isOutputIpHost)
                {
                    addParagraph(body, "IP Host Table\n", true, 2, true, false);
                    addTable(body, buildTableIpHost());
                }
                #endregion
			}

		}

		/// <summary>
		/// This is the addParagraph method.
		/// It is used to create a paragraph and append to body with style
		/// and preference according to the given parameters.
		/// </summary>
		/// <param name="body">the location where the content push to</param>
		/// <param name="content">the content push to the body</param>
		/// <param name="bold">determine the paragraph is bold or not</param>
		/// <param name="spacing">spacing between lines</param>
		/// <param name="insertParagraphBefore">determine whether a blank paragraph before the content push</param>
		/// <param name="insertParagraphAfter">determine whether a blank paragraph after the content push</param>
		private void addParagraph(Body body, String content, Boolean bold, int spacing, bool insertParagraphBefore, bool insertParagraphAfter, bool entryTitle = false) {

			// insert a new paragraph before the body
			if (insertParagraphBefore) {
				body.Append(new Paragraph());
			}

            ParagraphProperties pPr = new ParagraphProperties();
            Paragraph paragraph = new Paragraph(pPr);

			if (spacing != 0) {
				paragraph.ParagraphProperties.Append(new SpacingBetweenLines() {
					BeforeLines = spacing,
					AfterLines = spacing
				});
			}

            // make header style
            if (entryTitle)
            {
                pPr.ParagraphStyleId = new ParagraphStyleId() { Val = "entry_heading" };
            }

			Run run = new Run(new RunProperties());
			if (bold) {
				run.RunProperties.Append(new Bold() {
					Val = OnOffValue.FromBoolean(true)
				});
			}

			Text text = new Text(content);

			// set text of the paragraph and append it to the body
			run.Append(text);
			paragraph.Append(run);
			body.Append(paragraph);

			// insert a new paragraph after the body
			if (insertParagraphAfter) {
				body.Append(new Paragraph());
			}
		}


         // Add a StylesDefinitionsPart to the document.  Returns a reference to it.
        public static StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            StyleDefinitionsPart part;
            part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new Styles();
            root.Save(part);
            return part;
        }


        // Create a new style with the specified styleid and stylename and add it to the specified
        // style definitions part.
        private static void AddNewStyle(StyleDefinitionsPart styleDefinitionsPart,
            string styleid, string stylename)
        {
            // Get access to the root element of the styles part.
            Styles styles = styleDefinitionsPart.Styles;

            // Create a new paragraph style and specify some of the properties.
            Style style = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = styleid,
                CustomStyle = true
            };
            StyleName styleName1 = new StyleName() { Val = stylename };
            BasedOn basedOn1 = new BasedOn() { Val = "Normal" };
            NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normal" };
            style.Append(styleName1);
            style.Append(basedOn1);
            style.Append(nextParagraphStyle1);

            //// Create the StyleRunProperties object and specify some of the run properties.
            //StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            //Bold bold1 = new Bold();
            //Color color1 = new Color() { ThemeColor = ThemeColorValues.Dark1 };
            //RunFonts font1 = new RunFonts() { Ascii = "Lucida Console" };
            //Italic italic1 = new Italic();
            //// Specify a 12 point size.
            //FontSize fontSize1 = new FontSize() { Val = "24" };
            //styleRunProperties1.Append(bold1);
            //styleRunProperties1.Append(color1);
            //styleRunProperties1.Append(font1);
            //styleRunProperties1.Append(fontSize1);
            //styleRunProperties1.Append(italic1);

            //// Add the run properties to the style.
            //style.Append(styleRunProperties1);

            // Add the style to the styles part.
            styles.Append(style);
        }


		/// <summary>
		/// This is the addTable method.
		/// It is used to append to the body of the word document from given table.
		/// </summary>
		/// <param name="body">the loation where the table push to</param>
		/// <param name="t">the dictionary includes the table's values</param>
		private void addTable(Body body, Dictionary<KeyValuePair<int, int>, String> t) {
			Table table = new Table();

			#region // create TableProperties Object
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
			#endregion

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

			body.Append(table);
		}

		/// <summary>
		/// This is the buildTable method.
		/// It is used to create the table from given entry and riskFactor.
		/// (normal entry output)
		/// </summary>
		/// <param name="entry">the DataEntry being transformed to the dictionary</param>
		/// <param name="riskFactor">the riskFactor of that DataEntry</param>
		/// <returns>a dictionary includes the table's values.</returns>
		private Dictionary<KeyValuePair<int, int>, String> buildTable(DataEntry entry, RiskFactor riskFactor) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Hosts Affected
			table[new KeyValuePair<int, int>(1, 1)] = "Hosts Affected:";

			String tempString = entry.getIp();
			while (tempString.Length > 0 && tempString[tempString.Length - 1] == ' ') {
				tempString = tempString.Substring(0, tempString.Length - 1);
			}
			table[new KeyValuePair<int, int>(1, 2)] = tempString;

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

			// ReferenceLink
			if (!String.IsNullOrEmpty(entry.getReferenceLink())){
				table[new KeyValuePair<int, int>(7, 1)] = "Reference Link";
				table[new KeyValuePair<int, int>(7, 2)] = entry.getReferenceLink();
			}

			return table;
		}

		/// <summary>
		/// This is the buildTableHotfix method.
		/// It is used to create the table from given Hotfix.
		/// </summary>
		/// <param name="hotfix">the Hotfix of a record</param>
		/// <returns>a dictionary includes the table's values.</returns>
		private Dictionary<KeyValuePair<int, int>, String> buildTableHotfix(Hotfix hotfix) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Header
			table[new KeyValuePair<int, int>(1, 1)] = "Host";
			table[new KeyValuePair<int, int>(1, 2)] = "Missing Hotfix(s)";

			Dictionary<String, String> hotfixList = hotfix.getHotfixListGroupByHost();
			int rowCounter = 2;

			// hotfix findings data (ip, missing hotfix)
			foreach (KeyValuePair<String, String> keyValuePair in hotfixList) {
				table[new KeyValuePair<int, int>(rowCounter, 1)] = keyValuePair.Key;
				table[new KeyValuePair<int, int>(rowCounter, 2)] = keyValuePair.Value;
				rowCounter++;
			}

			return table;
		}

		/// <summary>
		/// This is the buildTableOpenPort method.
		/// It is used to create the table from given open port findings.
		/// </summary>
		/// <param name="risk">the open port findings that needs to tranform to a dictionary</param>
		/// <returns>a dicrionary includes the table's values.</returns>
		private Dictionary<KeyValuePair<int, int>, String> buildTableOpenPort(Dictionary<int, DataEntry> risk) {
			Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();

			// Header
			table[new KeyValuePair<int, int>(1, 1)] = "Host";
			table[new KeyValuePair<int, int>(1, 2)] = "Open Port(s)";

			int rowCounter = 2;

			// open port findings data (ip, open port list)
			foreach (DataEntry entry in risk.Values) {
				table[new KeyValuePair<int, int>(rowCounter, 1)] = entry.getIp();
				table[new KeyValuePair<int, int>(rowCounter, 2)] = entry.getDescription();
				rowCounter++;
			}

			return table;
		}

        private Dictionary<KeyValuePair<int, int>, String> buildTableIpHost()
        {
            Dictionary<KeyValuePair<int, int>, String> table = new Dictionary<KeyValuePair<int, int>, string>();
            Dictionary<String, String> ipHost = Program.state.panelRecordEdit_recordDatabaser.getIpHost();

            // Header
            table[new KeyValuePair<int, int>(1, 1)] = "IP";
            table[new KeyValuePair<int, int>(1, 2)] = "Host Name";

            int rowCounter = 2;

            // open port findings data (ip, open port list)
            foreach (KeyValuePair<String,String> data in ipHost)
            {
                table[new KeyValuePair<int, int>(rowCounter, 1)] = data.Key;
                table[new KeyValuePair<int, int>(rowCounter, 2)] = data.Value;
                rowCounter++;
            }

            return table;
        }
	}
}
