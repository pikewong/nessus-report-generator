using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.ReportOutput.OutputFormatter{

	/// <summary>
	/// This is the XlsxFromTemplateFormater Class.
	/// It is used to generate the report output from xlsx template and output xlsx report.
	/// 
	/// This class is not been used within the Report Generator.
	/// </summary>
	class XlsxFromTemplateFormater : OutputFromTemplateFormater {

		/*
		 * This is the output method.
		 * This method has not been implemented.
		 */
		public override void output(string path, string template, ref ReportGenerator.Record.Record record, ref Dictionary<String, String> dict) {
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
