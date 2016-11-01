namespace mUIFramework.mvc {
    using Category = UIScoreboardController.ScoreCategory;

    public class UIScoreboardController {
        public enum ScoreCategory {
            None = 0,
            Point,
            Round,
            Game,
        }

        public static event System.Action<int, int, Category> RaiseScoreboardUpdated;

        private UIScoreboardModelView scoreboardMV;

        public UIScoreboardController(UIScoreboardModelView scoreboardMV) {
            this.scoreboardMV = scoreboardMV;
        }

        public bool UpdateScoreboardWith (int p1Score, int p2Score, Category scoreCategory) {
            if (RaiseScoreboardUpdated != null) {
                RaiseScoreboardUpdated(p1Score, p2Score, scoreCategory);
                return true;
            }
            return false;
        }

        public bool ToggleScoreboard (bool toggleOn) {
            if (toggleOn) {
                scoreboardMV.Scoreboard.Enable ();
                return true;
            } else {
                scoreboardMV.Scoreboard.Disable ();
                return false;
            }
        }
    }
}
