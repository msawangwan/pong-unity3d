using UnityEngine;
using mExtensions.Common;

namespace mUIFramework.mvc {
    public class UIMasterController : MonoBehaviour {
        public static UIMasterController Singleton = null;

        [SerializeField] private UIScoreboardModelView scoreboardModelView = null;
        [SerializeField] private UICenterBannerModelView centerBannerModelView = null;

        private UIScoreboardController scoreboard = null;
        private UICenterBannerController centerBanner = null;

        public UIScoreboardController Scoreboard {
            get {
                if (scoreboard.IsNull()) {
                    scoreboard = new UIScoreboardController (scoreboardModelView);
                }
                return scoreboard;
            }
        }

        public UICenterBannerController CenterBanner {
            get {
                if (centerBanner.IsNull()) {
                    centerBanner = new UICenterBannerController (centerBannerModelView);
                }
                return centerBanner;
            }
        }

        private void Awake () {
            Singleton = this;
        }
    }
}
