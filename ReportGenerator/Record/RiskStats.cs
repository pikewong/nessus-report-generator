using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {

	/// <summary>
	/// This is RiskStats Class.
	/// It is used to store the risk statistics for all findings (group by ip)
	/// </summary>
	public class RiskStats {
		
		// Variables
		private Dictionary<String, Dictionary<RiskFactor, int>> riskStats = new Dictionary<string, Dictionary<RiskFactor, int>>();

		/// <summary>
		/// This is addHost method.
		/// It is used to add a host to the RiskStats.
		/// </summary>
		/// <param name="ip">the host name</param>
		/// <param name="riskFactor">the RiskFactor of that finding</param>
		public void addHost(String ip, RiskFactor riskFactor) {

			// if riskFactor = RiskFactor.NULL, this finding is not valid
			if (riskFactor == RiskFactor.NULL) {
				return;
			}

			// action taken if the host already in the riskStats
			if (riskStats.ContainsKey(ip)) {
				Dictionary<RiskFactor, int> hostStat = riskStats[ip];
				hostStat[riskFactor]++;
			}

			// action taken if the host is new to riskStats
			else {
				Dictionary<RiskFactor, int> hostStat = new Dictionary<RiskFactor, int>();

				foreach (RiskFactor risks in Enum.GetValues(typeof(RiskFactor))) {
					hostStat[risks] = 0;
				}

				hostStat[riskFactor]++;
				riskStats[ip] = hostStat;
			}
		}

		/// <summary>
		/// This is the removeHost method.
		/// It is used to remove a host from the RiskStats.
		/// </summary>
		/// <param name="ip">the host name</param>
		/// <param name="riskFactor">the RiskFactor of that finding</param>
		public void removeHost(String ip, RiskFactor riskFactor) {

			// if riskFactor = RiskFactor.NULL, this finding is not valid
			if (riskFactor == RiskFactor.NULL) {
				return;
			}

			// action taken if the host is in the riskStats
			if (riskStats.ContainsKey(ip)) {
				Dictionary<RiskFactor, int> hostStat = riskStats[ip];
				hostStat[riskFactor]--;
			}
		}

		/// <summary>
		/// This is the getter method.
		/// </summary>
		/// <returns>current risk statistics from RiskStats.</returns>
		public Dictionary<String, Dictionary<RiskFactor, int>> getRiskStats() {
			return this.riskStats;
		}
	}
}
