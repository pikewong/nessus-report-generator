using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.ReportOutput.OutputFormatter {
	
	/// <summary>
	/// This is the OutputFromTemplateFormater Class.
	/// This is the parent class of all OutputFromTemplateFormater output formater.
	/// (With reference file)
	/// </summary>
	abstract class OutputFromTemplateFormater : OutputFormater{

		/// <summary>
		/// This is the abstract output method.
		/// It is used to output the file from given path and also given Record,
		/// with reference to the given template path and also a dictionary includes
		/// the string to be replaced.
		/// </summary>
		/// <param name="path">the file path for output</param>
		/// <param name="template">the template path for output</param>
		/// <param name="record">the Record for output</param>
		/// <param name="dict">the dict for string replacement</param>
		abstract public void output(String path, String template, ref Record.Record record, ref Dictionary<String, String> dict);
	}
}
