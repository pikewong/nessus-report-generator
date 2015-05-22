using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	abstract class OutputFromTemplateFormater : OutputFormater{
		abstract public void output(String path, String template, ref Record.Record record, ref Dictionary<String, String> dict);
	}
}
