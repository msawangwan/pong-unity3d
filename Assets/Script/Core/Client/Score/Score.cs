using UnityEngine;
using System.Collections.Generic;

namespace mUnityFramework.Game {
	public class Score {
		public class Point {
			public readonly int Value;

			private Point(int v) {
				this.Value = v;
			}

			public static Point Earned() {
				return new Score.Point(1);
			}
		}

		private List<Score.Point> total = new List<Score.Point>();

		public IEnumerable<Score.Point> Total {
			get {
				return total;
			}
		}

		public int RunningTotal {
			get {
				return total.Count;
			}
		}
	}
}
