using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGenerator.Record;
using ReportGenerator.Database;

namespace ReportGenerator {
	public class State {
		public enum FormEnum {
			ONE,
			TWO,
			THREE
		};

		#region Form1 Parameters
		public enum Form1State {
			CREATE,
			OPEN
		};
		public Form1State form1State;
		#endregion

		#region Form2 Parameters
		public String form2Path = "";
		#endregion

		#region Form3 Parameters

		#region Form3 Panel1 State
		public List<String> form3Paths = null;
		public List<bool> form3PathSelected = null;
		#endregion

		#region Form3 Panel2 State
		public Databaser form3Databaser = null;
		public Record.Record form3Record = null;
		public Record.Record form3ConfirmedRecord = null;
		public Dictionary<int, bool> form3RecordSelected = null;
		public Dictionary<int, bool> form3RecordMerged = null;
		public Dictionary<int, bool> form3RecordEdited = null;
		public Dictionary<int, int> form3Id = null;
		public Dictionary<int, int> form3OldId = null;
		public String form3DatabasePath = "";
		public Boolean form3Panel2showHigh = true;
		public Boolean form3Panel2showMedium = true;
		public Boolean form3Panel2showLow = true;
		public Boolean form3Panel2showNone = true;
		public Boolean form3Panel2showOpenPort = true;
		#endregion

		#region Form3 Panel3 State
		public enum Form3Panel3State {
			HTML,
			DOCX,
			DOCXTEM,
			XLSX,
			NULL
		}

		public static String form3Panel3HTMLSelected = "HTML Output Settings";
		public static String form3Panel3DOCXSelected = "DOCX Output Settings";
		public static String form3Panel3DOCXTEMSelected = "DOCX with DOCX Template Output Settings";
		public static String form3Panel3XLSXSelected = "XLSX Output Settings";

		public Form3Panel3State form3Panel3State;
		public String form3Panel3OutputPath = "";
		public String form3Panel3TemplatePath = "";
		#endregion

		#region Form3 Panel4 State
		public Dictionary<String, String> panel4_dict = null;
		#endregion

		#region Form3 Panel5 State
		#endregion

		#endregion

		#region Form4 Parameters
		public enum Form4State {
			OK,
			CANCEL,
			NULL
		}
		public Form4State form4State = Form4State.NULL;
		public DataEntry form4entry = null;
		#endregion

		#region Form5 Parameters
		public enum Form5State {
			OK,
			CANCEL,
			NULL
		}
		public Form5State form5State = Form5State.NULL;
		public String form5Data = "";
		#endregion

		public void initialize() {
			form2Path = "";
			form3Paths = null;
			form3PathSelected = null;
			form3Record = null;
			form3RecordSelected = null;
			form3RecordMerged = null;
			form3RecordEdited = null;
			form3Panel3State = Form3Panel3State.NULL;
		}
	}
}
