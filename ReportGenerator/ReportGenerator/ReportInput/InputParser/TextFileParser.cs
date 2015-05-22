using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReportGenerator.ReportInput.InputParser {
	public abstract class TextFileParser : Parser{
		
		// TextFileParser functions

		public override void getData(string filePath, ref Record.Record record) {
			this.tempRecord = record;
			try {
				using (StreamReader sr = new StreamReader(filePath)) {
					string line;

					while ((line = sr.ReadLine()) != null) {
						processData(line);
					}
				}
			}
			catch (System.IO.IOException) {
			}
		}

		protected abstract void processData(String content);
	}
}
