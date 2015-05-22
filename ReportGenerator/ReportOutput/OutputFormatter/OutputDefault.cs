using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	
	/// <summary>
	/// This is the OutputDefault Class.
	/// This is the parent class of all OutputDefault output formater.
	/// (Without reference file)
	/// </summary>
	abstract class OutputDefault : OutputFormater {

		/// <summary>
		/// This is the abstract output method.
		/// It is used to output the file from given path and also given Record.
		/// </summary>
		/// <param name="path">the file path for output</param>
		/// <param name="record">the Record for output</param>
		abstract public void output(String path, ref Record.Record record);
	}
}
