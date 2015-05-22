using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Packaging;
using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using Pic = DocumentFormat.OpenXml.Drawing.Pictures;
using Dgm = DocumentFormat.OpenXml.Drawing.Diagrams;
using Dsp = DocumentFormat.OpenXml.Office.Drawing;
using Ds = DocumentFormat.OpenXml.CustomXmlDataProperties;
using V = DocumentFormat.OpenXml.Vml;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using M = DocumentFormat.OpenXml.Math;
using Op = DocumentFormat.OpenXml.CustomProperties;
using ReportGenerator.ReportOutput.OutputFormatter;
using ReportGenerator.Record;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	class DocxAsTemplate : OutputDefault {
		private Record.Record record = null;
		
		public override void output(string path, ref Record.Record record) {
			this.record = record;

			using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document)) {
				new DocxTemplateBuilder().build(wordDoc, this);
			}
		}

		public void printHighRisk(Body body) {
			String s = "5.2.1.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getHighRisk()) {
				addParagraph(body, s + no.ToString() + " " + entry.Value.getPluginName());
				addTable(body, buildTable(entry.Value, RiskFactor.HIGH));
				no++;
			}
		}

		public void printMediumRisk(Body body) {
			String s = "5.2.2.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getMediumRisk()) {
				addParagraph(body, s + no.ToString() + " " + entry.Value.getPluginName());
				addTable(body, buildTable(entry.Value, RiskFactor.MEDIUM));
				no++;
			}
		}

		public void printLowRisk(Body body) {
			String s = "5.2.3.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getLowRisk()) {
				addParagraph(body, s + no.ToString() + " " + entry.Value.getPluginName());
				addTable(body, buildTable(entry.Value, RiskFactor.LOW));
				no++;
			}
		}

		public void printNoneRisk(Body body) {
			String s = "5.2.4.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getNoneRisk()) {
				addParagraph(body, s + no.ToString() + " " + entry.Value.getPluginName());
				addTable(body, buildTable(entry.Value, RiskFactor.NONE));
				no++;
			}
		}

		public void printOpenPort(Body body) {
			String s = "5.2.5.";
			int no = 1;
			foreach (KeyValuePair<int, DataEntry> entry in record.getOpenPort()) {
				addParagraph(body, s + no.ToString() + " " + entry.Value.getPluginName());
				addTable(body, buildTable(entry.Value, RiskFactor.OPEN));
				no++;
			}
		}

		private void addParagraph(Body body, String content){
			body.Append(new Paragraph(new Run(new Text(content))));
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
	}
}
