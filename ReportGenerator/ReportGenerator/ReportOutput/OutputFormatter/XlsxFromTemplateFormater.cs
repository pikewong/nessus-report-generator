using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.ReportOutput.OutputFormatter{
	class XlsxFromTemplateFormater : OutputFromTemplateFormater {
		public override void output(string path, string template, ref ReportGenerator.Record.Record record, ref Dictionary<String, String> dict) {
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
