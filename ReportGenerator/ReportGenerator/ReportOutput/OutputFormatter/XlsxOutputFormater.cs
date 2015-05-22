using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using ReportGenerator.Record;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	class XlsxOutputFormater : OutputDefault{
		private Record.Record record = null;

		public override void output(string path, ref Record.Record record) {
			this.record = record;

			// Create a Wordprocessing document.
			using (SpreadsheetDocument package = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook)) {

				// Add a new workbook part
				WorkbookPart wbPart = package.AddWorkbookPart();
				wbPart.Workbook = new Workbook();

				// Add a new worksheet part
				WorksheetPart wsPart = package.WorkbookPart.AddNewPart<WorksheetPart>();
				
				//Create the Spreadsheet DOM
				Worksheet worksheet = new Worksheet();
				
				SheetData sheetData = new SheetData();

				String[] stringArray = {"Plugin Name",
										"Hosts Affected",
										"Description",
									    "Impact",
									    "Risk Level",
									    "Recommendations",
									    "Reference (CVE)",
									    "Reference (BID)",
									    "Reference (OSVDB)"};
				sheetData.Append(buildRow(stringArray));
				worksheet.Append(sheetData);

				printHighRisk(sheetData);
				printMediumRisk(sheetData);
				printLowRisk(sheetData);
				printNoneRisk(sheetData);
				printOpenPort(sheetData);

				wsPart.Worksheet = worksheet;

				// Save changes to the spreadsheet part
				wsPart.Worksheet.Save();

				// create the worksheet to workbook relation
				wbPart.Workbook.AppendChild(new Sheets());
				wbPart.Workbook.GetFirstChild<Sheets>().AppendChild(new Sheet() {
					Id = wbPart.GetIdOfPart(wsPart),
					SheetId = 1,
					Name = "Findings"
				});
				wbPart.Workbook.Save();
			}
		}

		public void printHighRisk(SheetData sheetData) {
			foreach (KeyValuePair<int, DataEntry> entry in record.getHighRisk()) {
				sheetData.Append(buildRow(buildStringArray(entry.Value, RiskFactor.HIGH)));
			}
		}

		public void printMediumRisk(SheetData sheetData) {
			foreach (KeyValuePair<int, DataEntry> entry in record.getMediumRisk()) {
				sheetData.Append(buildRow(buildStringArray(entry.Value, RiskFactor.MEDIUM)));
			}
		}

		public void printLowRisk(SheetData sheetData) {
			foreach (KeyValuePair<int, DataEntry> entry in record.getLowRisk()) {
				sheetData.Append(buildRow(buildStringArray(entry.Value, RiskFactor.LOW)));
			}
		}

		public void printNoneRisk(SheetData sheetData) {
			foreach (KeyValuePair<int, DataEntry> entry in record.getNoneRisk()) {
				sheetData.Append(buildRow(buildStringArray(entry.Value, RiskFactor.NONE)));
			}
		}

		public void printOpenPort(SheetData sheetData) {
			foreach (KeyValuePair<int, DataEntry> entry in record.getOpenPort()) {
				sheetData.Append(buildRow(buildStringArray(entry.Value, RiskFactor.OPEN)));
			}
		}

		private Row buildRow(String[] stringArray) {
			Row row = new Row();
			foreach (String s in stringArray) {
				row.Append(new Cell() {
					DataType = new EnumValue<CellValues>(CellValues.String),
					CellValue = new CellValue() {
						Text = s
					}
				});
			}
			return row;
		}

		private String[] buildStringArray(DataEntry entry, RiskFactor riskFactor) {
			String[] stringArray = new String[9];

			// Plugin Name
			stringArray[0] = entry.getPluginName();

			// Hosts Affected
			String tempString = "";
			foreach (String ip in entry.getIpList()) {
				tempString += ip + '\n';
			}
			stringArray[1] = tempString.Substring(0, tempString.Length - 1);

			// Description
			stringArray[2] = entry.getDescription();

			// Impact
			stringArray[3] = entry.getImpact();

			// Risk Level
			stringArray[4] = RiskFactorFunction.getEnumString(riskFactor);

			// Recommendations
			stringArray[5] = entry.getRecommendation();

			// Reference
			
			// CVE
			tempString = "N/A";
			if (entry.getCve() != null) {
				tempString = entry.getCve();
			}
			stringArray[6] = tempString;

			// BID
			tempString = "N/A";
			if (entry.getBid() != null) {
				tempString = entry.getBid();
			}
			stringArray[7] = tempString;

			// OSVDB
			tempString = "N/A";
			if (entry.getOsvdb() != null) {
				tempString = entry.getOsvdb();
			}
			stringArray[8] = tempString;

			return stringArray;
		}

	}
}