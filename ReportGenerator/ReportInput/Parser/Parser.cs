using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGenerator.Record;

namespace ReportGenerator.ReportInput.InputParser {

	/// <summary>
	/// This is the Parser Class.
	/// This is the parent class of all parser.
	/// </summary>
	public abstract class Parser {

		// parser required field
		protected Stack<String> elementStack = new Stack<string>();
		protected Stack<int> severityStack = new Stack<int>();

		// entry field
		protected String tempIpList = null;
		protected String tempDescription = null;
		protected String tempImpact = null;
		protected String tempRecommendation = null;
		protected List<String> tempCveList = new List<String>();
		protected List<String> tempBidList = new List<String>();
		protected List<String> tempOsvdbList = new List<String>();
		protected String tempCve = null;
		protected String tempBid = null;
		protected String tempOsvdb = null;
		protected String tempPluginId = null;
		protected String tempPluginName = null;
		protected String tempReferenceLink = null;
		protected int tempSeverity = -1;
		protected RiskFactor tempRiskFactor = RiskFactor.NULL;
        protected String tempFileName = null;

		// data field
		protected Record.Record tempRecord = null;

		/// <summary>
		/// This is the abstract getData method.
		/// It is used to get data and store to the given record.
		/// </summary>
		/// <param name="filePath">the file path needs get information</param>
		/// <param name="record">the record storing the output</param>
		public abstract void getData(string filePath, ref Record.Record record);

        public void setFileName(string fileName) { tempFileName = fileName; }
	}
}
