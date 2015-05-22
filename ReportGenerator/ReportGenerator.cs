using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ReportGenerator.ReportInput;
using ReportGenerator.ReportOutput;

namespace ReportGenerator {
	class Program {
		public static void Main(string[] args) {
			if (args.Length <= 1) {
				Console.WriteLine("Usage: ReportGenerator <.nessus Folder Directory> <output filename>");
				Environment.Exit(0);
			}

			if (!Directory.Exists(args[0])) {
				Console.WriteLine(args[0] + " is not a directory");
				Environment.Exit(0);
			}

			String[] paths = Directory.GetFiles(args[0], "*.nessus", SearchOption.AllDirectories);
			if (paths.Length == 0) {
				Console.WriteLine("No .nessus files found in " + args[0]);
				Environment.Exit(0);
			}

			// get data from report inputer
			ReportInputer reportInputer = new ReportInputer();
			Record.Record record = reportInputer.getData(paths);

			// data process by end-user


			// output the report by the report outputer
			ReportOutputer reportOutputer = new ReportOutputer();

			if (args.Length > 2) {
				reportOutputer.output(args[2], args[1], ref record);
			}
			else {
				reportOutputer.output(args[1], ref record);
			}
		}
	}
}
