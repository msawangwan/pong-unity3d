using UnityEngine;

public class Total {
    public class Score {
        public int Current { get; private set; }
        public int RequiredToWin { get; private set; }

        public Score (int current, int requiredToWin) {
            Current = current;
            RequiredToWin = requiredToWin;
        }
    }

    public class Round {
        public int Current { get; private set; }
        public int RequiredToWin { get; private set; }

        public Round (int current, int requiredToWin) {
            Current = current;
            RequiredToWin = requiredToWin;
        }
    }
}
