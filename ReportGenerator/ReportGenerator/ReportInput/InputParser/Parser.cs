using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGenerator.Record;

namespace ReportGenerator.ReportInput.InputParser {
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

		// data field
		protected Record.Record tempRecord = null;

		// parser functions
		public abstract void getData(string filePath, ref Record.Record record);
	}
}
