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

		public int Total {
			get {
				return total.Count;
			}
		}

		private Score () { }

		public static Score New () {
            return new Score();
        }

		public Score IncrementByOne () {
            Score.Point point = Score.Point.Earned();
            total.Add(point);
            return this;
        }
	}
}
