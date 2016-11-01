using UnityEngine;

namespace mUIFramework.mvc {
    public class UIMasterController : MonoBehaviour {
        public static UIMasterController Singleton = null;

        [SerializeField] private UIScoreboardModelView scoreboardModelView = null;
        private UIScoreboardController scoreboard = null;
        
        public UIScoreboardController Scoreboard {
            get {
                if (scoreboard == null) {
                    scoreboard = new UIScoreboardController (scoreboardModelView);
                }
                return scoreboard;
            }
        }

        private void Awake () {
            Singleton = this;
        }
    }
}
