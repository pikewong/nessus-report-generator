using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReportGenerator.ReportInput.InputParser {

	/// <summary>
	/// This is the TextFileParser Class extends Parser.
	/// This is the parent class of all text file parser.
	/// </summary>
	public abstract class TextFileParser : Parser{

		/// <summary>
		/// This is the getData method.
		/// It is used to get data from the given text file path and store
		/// those data in given Record.
		/// </summary>
		/// <param name="filePath">the file path includes the useful information</param>
		/// <param name="record">the variable stores the output</param>
		public override void getData(string filePath, ref Record.Record record) {
			this.tempRecord = record;
			try {
				string line;

				// read through the text file
				using (StreamReader sr = new StreamReader(filePath)) {
					
					while ((line = sr.ReadLine()) != null) {
						// process each line
                        if (line == "65389/tcp unknown unknown")
                            continue;
						processData(line);
					}
				}
			}
			catch (System.IO.IOException) {
			}
		}

		/// <summary>
		/// This is the abstract processData method. 
		/// It is used to process each line on the text file.
		/// </summary>
		/// <param name="content">the string in each line of text file</param>
		protected abstract void processData(String content);
	}
}
