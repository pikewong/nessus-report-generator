using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Record {
	public class RiskStats {

		private Dictionary<String, Dictionary<RiskFactor, int>> riskStats = new Dictionary<string, Dictionary<RiskFactor, int>>();

		/**
		 * Add one to the given ip-riskFactor paring
		 * @param ip The ip of the host to add stats too
		 * @param riskFactor The desired riskFactor
		 */
		public void add(String ip, RiskFactor riskFactor) {
			if (riskFactor == RiskFactor.NULL) {
				Console.Error.WriteLine("RiskStats: Invalid RiskFactor");
				return;
			}

			if (riskStats.ContainsKey(ip)) {
				Dictionary<RiskFactor, int> hostStat = riskStats[ip];
				int i = hostStat[riskFactor];
				hostStat[riskFactor] = i + 1;
			}
			else {
				Dictionary<RiskFactor, int> hostStat = new Dictionary<RiskFactor, int>();

				foreach (RiskFactor risks in Enum.GetValues(typeof(RiskFactor))) {
					hostStat[risks] = 0;
				}

				int i = hostStat[riskFactor];
				hostStat[riskFactor] = i + 1;
				riskStats[ip] = hostStat;
			}
		}

		public void remove(String ip, RiskFactor riskFactor) {
			if (riskFactor == RiskFactor.NULL) {
				Console.Error.WriteLine("RiskStats: Invalid RiskFactor");
				return;
			}

			if (riskStats.ContainsKey(ip)) {
				Dictionary<RiskFactor, int> hostStat = riskStats[ip];
				int i = hostStat[riskFactor];
				hostStat[riskFactor] = i - 1;
			}
		}

		/**
		  * @return the HashMap mapping of ip-RiskRating
		  */
		public Dictionary<String, Dictionary<RiskFactor, int>> getRiskStats() {
			return this.riskStats;
		}
	}
}
