using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReportGenerator {

	/// <summary>
	/// This is the Program Class.
	/// The main entry point for the application.
	/// </summary>
	public class Program {

		// Variables
		public static State state = new State();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormStart());
		}
	}
}
