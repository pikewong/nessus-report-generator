using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.ReportOutput.OutputFormatter;

namespace ReportGenerator.ReportOutput {
	class ReportOutputer {
		public void output (String path, ref Record.Record record) {
			OutputDefault outputFormater = getOutputFormater(path);
			if (outputFormater != null) {
				outputFormater.output(path, ref record);
			}
		}

		public void output (String path, String template, ref Record.Record record, ref Dictionary<String, String> dict) {
			OutputFromTemplateFormater outputFormater = getOutputFormater(path, template);
			if (outputFormater != null) {
				outputFormater.output(path, template, ref record, ref dict);
			}
		}

		private OutputDefault getOutputFormater (String path) {
			String fileType = path.Substring(path.LastIndexOf(".") + 1);
			switch (fileType) {
				case "docx":
					return new DocxOutputFormater();
					//return new DocxAsTemplate();
				case "html":
				case "htm":
					return new HTMLOutputFormater();
				case "xlsx":
					return new XlsxOutputFormater();
			}
			return null;
		}

		private OutputFromTemplateFormater getOutputFormater (String path, String template) {
			String fileType = path.Substring(path.LastIndexOf(".") + 1);
			String templateType = template.Substring(template.LastIndexOf(".") + 1);
			switch (fileType) {
				case "docx":
					if (templateType == "dotx") {
						return new DocxFromDotxTemplateOutputer();
					}
					else {
						return new DocxFromDocxTemplateOutputer();
					}
				default:
					break;
			}
			return null;
		}
	}
}
