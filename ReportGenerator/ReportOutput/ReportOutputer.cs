using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.ReportOutput.OutputFormatter;

namespace ReportGenerator.ReportOutput {
	
	/// <summary>
	/// This is the ReportOutputer Class.
	/// It is used to handle the output from the given file path.
	/// </summary>
	class ReportOutputer {

		/// <summary>
		/// This is the output method.
		/// It is used to output the file from the given path and Record.
		/// </summary>
		/// <param name="path">output file path</param>
		/// <param name="record">Record required to output</param>
		public void output (String path, ref Record.Record record) {
			
			OutputDefault outputFormater = getOutputFormater(path);
			if (outputFormater != null) {
				outputFormater.output(path, ref record);
			}
		}

		/// <summary>
		/// This is the output method.
		/// It is used to output the file from the given path, template path, Record
		/// and also the dictionary for string replacement.
		/// </summary>
		/// <param name="path">output file path</param>
		/// <param name="template">the template required by the output file</param>
		/// <param name="record">Record required to output</param>
		/// <param name="dict">the dictionary for string replacement</param>
		public void output (String path, String template, ref Record.Record record, 
							ref Dictionary<String, String> dict) {
			
			OutputFromTemplateFormater outputFormater = getOutputFormater(path, template);
			if (outputFormater != null) {
				outputFormater.output(path, template, ref record, ref dict);
			}
		}

		/// <summary>
		/// This is the getOutputFormater method.
		/// </summary>
		/// <param name="path">the output file path, used to check which outputformatter</param>
		/// <returns>OutputDefault object according to the given path,
		/// null if no suitable output formater exist.</returns>
		private OutputDefault getOutputFormater (String path) {
			String fileType = path.Substring(path.LastIndexOf(".") + 1);
			switch (fileType) {
				case "docx":
					return new DocxOutputFormater();
				case "html":
				case "htm":
					return new HTMLOutputFormater();
				case "xlsx":
					return new XlsxOutputFormater();
			}
			return null;
		}

		/// <summary>
		/// This is the getOutputFormater mthod.
		/// </summary>
		/// <param name="path">the output file path, used to check which outputformatter</param>
		/// <param name="template">the template file path, used to check which outputformatter too</param>
		/// <returns>OutputFromTemplateFormater object according to the given path,
		/// null if no suitable output formater exist.</returns>
		private OutputFromTemplateFormater getOutputFormater (String path, String template) {
			String fileType = path.Substring(path.LastIndexOf(".") + 1);
			String templateType = template.Substring(template.LastIndexOf(".") + 1);
			switch (fileType) {
				case "docx":
					//if (templateType == "dotx") {
					//	return new DocxFromDotxTemplateOutputer();
					//}
					//else {
					return new DocxFromDocxTemplateOutputer();
					//}
				default:
					break;
			}
			return null;
		}
	}
}
