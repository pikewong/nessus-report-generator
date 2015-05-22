using System;
using System.Collections.Generic;
using System.Text;
using ReportGenerator.Record;

namespace ReportGenerator.ReportInput.InputParser {
	abstract class InputParser {

		// parser required field
		protected Stack<String> elementStack = new Stack<string>();
		protected Stack<int> severityStack = new Stack<int>();

		// entry field
		protected String hostName = null;
		protected String description = null;
		protected String impact = null;
		protected String recommendation = null;
		protected List<String> cveList = null;
		protected List<String> bidList = null;
		protected List<String> xrefList = null;
		protected String tempCve = null;
		protected String tempBid = null;
		protected String tempXref = null;
		protected String tempPluginId = null;
		protected String tempPluginName = null;
		protected int tempSeverity = -1;
		protected RiskFactor defaultRiskFactor = RiskFactor.NULL;

		// data field
		protected Record.Record tempRecord = null;

		// InputParser functions
		abstract public void getData(String filePath, ref Record.Record record);
		abstract protected void startTag(String tag, Dictionary<String, String> attributes);
		abstract protected void pushContent(String content);
		abstract protected void endTag(String tag);
	}
}
