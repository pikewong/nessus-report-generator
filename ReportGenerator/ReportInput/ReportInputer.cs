using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.Record;
using ReportGenerator.ReportInput.InputParser;
using ReportGenerator.ReportInput.Parser;

//.ReportInput
namespace ReportGenerator{

	/// <summary>
	/// This is the ReportInputer Class.
	/// It is used to handle the input from the given file paths.
	/// </summary>
	class ReportInputer {
		
		// Variables
		private Record.Record record = null;

		/// <summary>
		/// This is the getData method.3
		/// </summary>
		/// <param name="paths">file paths that including the useful information (String array).</param>
		/// <returns>a Record (all findings) from given paths.</returns>
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

		/// <summary>
		/// This is the getData method.		/// </summary>
		/// <param name="paths">file paths that including the useful information (List of string storing the paths).</param>
		/// <returns>a Record (all findings) from given paths.</returns>
		public Record.Record getData(List<String> paths) {
			record = new Record.Record();
			foreach (String path in paths) {
				Parser inputParser = getInputParser(path);
				if (inputParser != null) {
                    string[] tempString = path.Split('\\');
                    string fileName = "";
                    if (tempString.Length>0)
                        fileName = tempString[tempString.Length - 1];
                    inputParser.setFileName(fileName);
					inputParser.getData(path, ref record);
				}
			}
			return record;
		}

		/// <summary>
		/// This is the getInputParser method.
		/// </summary>
		/// <param name="path">the file path</param>
		/// <returns>a suitable parser from a valid path, null if a suitable path not exist.</returns>
		private Parser getInputParser(String path) {
			String fileType = path.Substring(path.LastIndexOf(".") + 1);
			switch (fileType) {
				case "nessus":
					return new NessusParser();
				case "mbsa":
					return new MBSAParser();
				case "xml":
					NmapParser tempNmapParser = new NmapParser();
                    if (NmapParser.isNmapXmlFile(path))
                    {
                        return new NmapParser();
                    }
                    else
                        return new AcunetixXMLParser();
				case "txt":
					if (NmapTxtParser.isNmapTxtFile(path)) {
						return new NmapTxtParser();
					}
					break;
                case "html":
                    return new AcunetixParser();
                default:
                    break;
			}
			return null;
		}
	}
}
