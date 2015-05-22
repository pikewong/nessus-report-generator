using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {

	/// <summary>
	/// This is the RiskFactor Class.
	/// It is used to determine the Risk of each Findings.
	/// </summary>
	public enum RiskFactor : int {
		NA = 0,
		OPEN = 1,
		NONE = 2,
		LOW = 3,
		MEDIUM = 4,
		HIGH = 5,
		NULL = -1
	}

	/// <summary>
	/// This is the RiskFactorFunction Class.
	/// It is used to get enum of RiskFactor or
	/// get the string from enum RiskFactor.
	/// </summary>
	public abstract class RiskFactorFunction {

		/// <summary>
		/// This the getEnum method.
		/// </summary>
		/// <param name="enumString">string to change to riskFactor</param>
		/// <returns>RiskFactor from given enumString.</returns>
		internal static RiskFactor getEnum(String enumString) {
            if (enumString.CompareTo("None") == 0 ||
                enumString.CompareTo("Informational") == 0||
                enumString.CompareTo("info") == 0)
            {
				return RiskFactor.NONE;
			}
			else if (enumString.CompareTo("Low") == 0 ||
                enumString.CompareTo("low") == 0)
            {
				return RiskFactor.LOW;
			}
			else if (enumString.CompareTo("Medium") == 0 ||
                enumString.CompareTo("medium") == 0||
				enumString.CompareTo("Moderate") == 0) {
				return RiskFactor.MEDIUM;
			}
			else if (enumString.CompareTo("High") == 0 ||
                enumString.CompareTo("high") == 0 ||
				enumString.CompareTo("Important") == 0 ||
				enumString.CompareTo("Critical") == 0) {
				return RiskFactor.HIGH;
			}
			else if (enumString.CompareTo("Open Port") == 0 ||
				enumString.CompareTo("OpenPort") == 0) {
				return RiskFactor.OPEN;
			}
			else {
				return RiskFactor.NA;
			}
		}

		/// <summary>
		/// This is getEnum method.
		/// </summary>
		/// <param name="severity">intger represents the severity</param>
		/// <returns>RiskFactor from given severity(integer).</returns>
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

		/// <summary>
		/// This is getEnumString method.
		/// </summary>
		/// <param name="severity">intger represents the severity</param>
		/// <returns>string from given RiskFactor</returns>
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
				return "";
			}
		}
	}
}
