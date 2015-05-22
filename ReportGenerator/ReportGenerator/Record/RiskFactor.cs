using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {
	public enum RiskFactor : int {
		NA = 0,
		OPEN = 1,
		NONE = 2,
		LOW = 3,
		MEDIUM = 4,
		HIGH = 5,
		NULL = -1
	}

	public abstract class RiskFactorFunction {

		internal static RiskFactor getEnum(String s) {
			if (s.CompareTo("None") == 0) {
				return RiskFactor.NONE;
			}
			else if (s.CompareTo("Low") == 0) {
				return RiskFactor.LOW;
			}
			else if (s.CompareTo("Medium") == 0 ||
				s.CompareTo("Moderate") == 0) {
				return RiskFactor.MEDIUM;
			}
			else if (s.CompareTo("High") == 0 ||
				s.CompareTo("Important") == 0 ||
				s.CompareTo("Critical") == 0) {
				return RiskFactor.HIGH;
			}
			else if (s.CompareTo("Open Port") == 0 ||
				s.CompareTo("OpenPort") == 0) {
				return RiskFactor.OPEN;
			}
			else {
				//Console.WriteLine("Unknown Risk_Factor attribute: " + s);
				return RiskFactor.NA;
			}
		}

		internal static RiskFactor getEnum(int severity) {
			if (severity == 0) {
				return RiskFactor.OPEN;
			}
			else if (severity == 1) {
				return RiskFactor.LOW;
			}
			else if (severity == 2) {
				return RiskFactor.MEDIUM;
			}
			else if (severity == 3) {
				return RiskFactor.HIGH;
			}
			else {
				return RiskFactor.NA;
			}
		}

		internal static String getEnumString(RiskFactor severity) {
			if (severity == RiskFactor.NONE) {
				return "None";
			}
			else if (severity == RiskFactor.OPEN) {
				return "Open Port";
			}
			else if (severity == RiskFactor.LOW) {
				return "Low";
			}
			else if (severity == RiskFactor.MEDIUM) {
				return "Medium";
			}
			else if (severity == RiskFactor.HIGH) {
				return "High";
			}
			else {
				return "Not Applicable";
			}
		}
	}
}
