using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;


namespace ReportGenerator.ReportOutput {
    class InteropExcel {
        string resultPath = null;
        Excel.Application excelApp = null;
        Excel.Workbook Wb = null;
        Excel.Worksheet Ws = null;
        int numOfItems = 2;

        enum patchSheetOrder { 
            Bulletin = 1,
            Patches = 2,
            Host = 3        
        }

        private void initializePatchSheet(Excel.Worksheet Ws) {
            Ws.Cells[1, patchSheetOrder.Bulletin] = @"Bulletin / Advisory";
            ((Excel.Range)Ws.Columns[patchSheetOrder.Bulletin]).ColumnWidth = 30;

            Ws.Cells[1, patchSheetOrder.Patches] = @"Patches";
            ((Excel.Range)Ws.Columns[patchSheetOrder.Patches]).ColumnWidth = 100;

            Ws.Cells[1, patchSheetOrder.Host] = @"Hosts Affected";
            ((Excel.Range)Ws.Columns[patchSheetOrder.Host]).ColumnWidth = 160;

            Ws.Range["A1","C1"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.CornflowerBlue);
        }

        public InteropExcel() {
            excelApp = new Excel.Application();
            excelApp.Visible = false;
            Wb = excelApp.Workbooks.Add();
            Ws = (Excel.Worksheet)excelApp.Worksheets[1];
            initializePatchSheet(Ws);
        }

        public void addPatchRecord(string bulletin, string patches, string hostAffected){
            Ws.Cells[numOfItems, patchSheetOrder.Bulletin] = bulletin;
            Ws.Cells[numOfItems, patchSheetOrder.Patches] = patches;
            Ws.Cells[numOfItems, patchSheetOrder.Host] = hostAffected;
            numOfItems++;
        }

        public void sortBulletinByName() {
            Excel.Range rngSort = Ws.get_Range("A2", "C"+numOfItems);
            rngSort.Sort(rngSort.Columns[patchSheetOrder.Bulletin, Type.Missing], 
                Excel.XlSortOrder.xlAscending,
                Type.Missing,
                Type.Missing,
                Excel.XlSortOrder.xlAscending,
                Type.Missing,
                Excel.XlSortOrder.xlAscending,
                Excel.XlYesNoGuess.xlNo,
                Type.Missing,
                Type.Missing,
                Excel.XlSortOrientation.xlSortColumns,
                Excel.XlSortMethod.xlStroke,
                Excel.XlSortDataOption.xlSortNormal,
                Excel.XlSortDataOption.xlSortNormal,
                Excel.XlSortDataOption.xlSortNormal
                );
        }

        public void SaveWorkbook() {
            sortBulletinByName();
            string saveDirecory = Program.state.formCaseCreateAndOpenPath.Substring(0, Program.state.formCaseCreateAndOpenPath.LastIndexOf("\\"));
            Wb.SaveAs(saveDirecory + "\\MissingMSPatches.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Wb.Close();
            excelApp.Quit();
        }
    }
}
