using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	abstract class OutputDefault : OutputFormater {
		abstract public void output(String path, ref Record.Record record);
	}
}
