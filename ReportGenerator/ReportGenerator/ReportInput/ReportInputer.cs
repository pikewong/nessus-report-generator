using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.Record;
using ReportGenerator.ReportInput.InputParser;

namespace ReportGenerator.ReportInput {
	class ReportInputer {
		private Record.Record record = null;

		public Record.Record getData(String[] paths) {
			record = new Record.Record();
			foreach (String path in paths) {
				Parser parser = getInputParser(path);
				if (parser != null) {
					parser.getData(path, ref record);
				}
			}
			return record;
		}

		public Record.Record getData(List<String> paths) {
			record = new Record.Record();
			foreach (String path in paths) {
				Parser inputParser = getInputParser(path);
				if (inputParser != null) {
					inputParser.getData(path, ref record);
				}
			}
			return record;
		}

		private Parser getInputParser(String path) {
			String fileType = path.Substring(path.LastIndexOf(".") + 1);
			switch (fileType) {
				case "nessus":
					return new NessusParser();
				case "mbsa":
					return new MBSAParser();
				case "xml":
					NmapParser tempNmapParser = new NmapParser();
					if (NmapParser.isNmapXmlFile(path)){
						return new NmapParser();
					}
					break;
				default:
					if (NmapTxtParser.isNmapTxtFile(path)) {
						return new NmapTxtParser();
					}
					break;
			}
			return null;
		}
	}
}
