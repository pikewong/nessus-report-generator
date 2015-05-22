using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGenerator.Record;
using ReportGenerator.Database;

namespace ReportGenerator {
	
	/// <summary>
	/// This is the State Class.
	/// It works like a "global" variables through the whole program.
	/// </summary>
	public class State {

		// Variables
		#region // FormStart Parameters
		public enum FormStartState {
			CREATE,
			OPEN
		};
		public FormStartState formStartState;
		#endregion

		#region // FormCaseCreateAndOpen Parameters
		public String formCaseCreateAndOpenPath = "";
		#endregion

		#region // FormMain Parameters

		#region // FormMain PanelFileInput State
		public List<String> formMainInputPaths = null;
		public List<Boolean> formMainInputPathSelected = null;
		#endregion

        public Dictionary<DataEntry.EntryType, List<String>> fileNames= null;
		#region // FormMain PanelRecordEdit State
		public Boolean panelRecordEdit_isSaveDatabase = false;
		public Boolean panelRecordEdit_isSaveConfig = false;
		public Databaser panelRecordEdit_recordDatabaser = null;
        public PermanentDatabaser amendmentDatabaser = null;
        public String amendmentDatabaserDefaultPath = null;
		public Record.Record panelRecordEdit_record = null;
		public Record.Record panelRecordEdit_ConfirmedRecord = null;
		public Dictionary<int, bool> panelRecordEdit_RecordSelected = null;
		public Dictionary<int, bool> panelRecordEdit_RecordMerged = null;
		public Dictionary<int, bool> panelRecordEdit_RecordEdited = null;
		public Dictionary<int, int> dataGridView_Id = null;
		public Dictionary<int, int> dataGridView_OldId = null;
		public Dictionary<int, int> dataGridView_DatabaseId = null;
		public String panelRecordEdit_DatabasePath = "";
		public Boolean panelRecordEdit_showHigh = true;
		public Boolean panelRecordEdit_showMedium = true;
		public Boolean panelRecordEdit_showLow = true;
		public Boolean panelRecordEdit_showNone = true;
		public Boolean panelRecordEdit_showOpenPort = true;
		public Boolean panelRecordEdit_showNessus = true;
		public Boolean panelRecordEdit_showNmap = true;
		public Boolean panelRecordEdit_showMbsa = true;
        public String ProjectName = "";
        public String Remark = "";

        //To record deleted/edited dataEntry for undo
        public Dictionary<int, DataEntry> panelRecordEdit_undoDataEntryList = null;
        public Dictionary<int, bool> panelRecordEdit_undoEdited = null;
        public Dictionary<int, bool> panelRecordEdit_undoMegered = null;

		#endregion

		#region // FormMain PanelOutputSelect State
		public enum PanelOutputSelectState {
			HTML,
			DOCX,
			DOCXTEM,
			XLSX,
			NULL
		}

		public static String panelOutputSelect_HTMLSelected = "HTML Output Settings";
		public static String panelOutputSelect_DOCXSelected = "DOCX Output Settings";
		public static String panelOutputSelect_DOCXTEMSelected = "DOCX with DOCX Template Output Settings";
		public static String panelOutputSelect_XLSXSelected = "XLSX Output Settings";

		public PanelOutputSelectState panelOutputSelect_State;
		public String panelOutputSelect_OutputPath = "";
		public String panelOutputSelect_TemplatePath = "";
		public Boolean panelOutputSelect_isOutputHotfix = true;
		public Boolean panelOutputSelect_isOutputOpenPort = true;
        public Boolean panelOutputSelect_isOutputIpHost = true;
        public Boolean panelOutputSelect_isOutputPluginOutput = true;
        public List<string> ForbiddenHost=new List<string>();
        public Boolean isinpanelLast = false;
        public String TextFileLocation = null;

		#endregion

		#region // FormMain PanelTemplateStringEdit State
		public Dictionary<String, String> panelTemplateStringEdit_dict = null;
		#endregion

		#region // FormMain PanelLast State
		#endregion

		#endregion

		#region // FormEditFinding Parameters
		public enum FormEditFindingState {
			OK,
			CANCEL,
			NULL
		}
		public FormEditFindingState formEditFindingState = FormEditFindingState.NULL;
		public DataEntry formEditFindingEntry = null;
		#endregion

		#region // FormEditFindingString Parameters
		public enum FormEditFindingStringState {
			OK,
			CANCEL,
            APPLYTOALL,
			NULL
		}
		public FormEditFindingStringState formEditFindingStringState = FormEditFindingStringState.NULL;
		public String formEditFindingString_stringText = "";
		#endregion

		#region // FormEditTemplateString Parameters
		public enum FormEditTemplateStringState {
			OK,
			CANCEL,
			NULL
		}
		public FormEditTemplateStringState formEditTemplateStringState = FormEditTemplateStringState.NULL;
		public String formEditTemplateString_stringText = "";
		#endregion

		/// <summary>
		/// This is the initialize method.
		/// It is used to initialize all variables in State.
		/// </summary>
		public void initialize() {
			#region // FormCaseCreateAndOpen Parameter Initialize
			formCaseCreateAndOpenPath = "";
			#endregion

			#region // formMain Parameter Initialize
			panelRecordEdit_isSaveDatabase = false;

			formMainInputPaths = null;
			formMainInputPathSelected = null;

			panelRecordEdit_recordDatabaser = null;
			panelRecordEdit_record = null;
			panelRecordEdit_ConfirmedRecord = null;
			panelRecordEdit_RecordSelected = null;
			panelRecordEdit_RecordMerged = null;
			panelRecordEdit_RecordEdited = null;

            panelRecordEdit_undoDataEntryList = null;
            panelRecordEdit_undoEdited = null;
            panelRecordEdit_undoMegered = null;

			dataGridView_Id = null;
			dataGridView_OldId = null;
			dataGridView_DatabaseId = null;
		
			panelRecordEdit_DatabasePath = "";
			
			panelRecordEdit_showHigh = true;
			panelRecordEdit_showMedium = true;
			panelRecordEdit_showLow = true;
			panelRecordEdit_showNone = true;
			panelRecordEdit_showOpenPort = true;
			panelRecordEdit_showNessus = true;
			panelRecordEdit_showNmap = true;
			panelRecordEdit_showMbsa = true;

			panelOutputSelect_OutputPath = "";
			panelOutputSelect_TemplatePath = "";
			panelOutputSelect_isOutputHotfix = true;
			panelOutputSelect_isOutputOpenPort = true;
            panelOutputSelect_isOutputIpHost = true;

			panelTemplateStringEdit_dict = null;

			panelOutputSelect_State = PanelOutputSelectState.NULL;
			#endregion
            fileNames = null;
			#region // formEditFinding Parameter Initialize
			formEditFindingState = FormEditFindingState.NULL;
			formEditFindingEntry = null;
			#endregion

			#region // formEditFindingString Parameter Initialize
			formEditFindingStringState = FormEditFindingStringState.NULL;
			formEditFindingString_stringText = "";
			#endregion

			#region // formEditTemplateString Parameter Initialize
			formEditTemplateStringState = FormEditTemplateStringState.NULL;
			formEditTemplateString_stringText = "";
			#endregion
		}
	}
}
