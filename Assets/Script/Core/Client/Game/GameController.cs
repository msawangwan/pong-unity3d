using UnityEngine;

namespace mGameFramework.Core {
    public class GameController : MonoBehaviour {
        public static GameController StaticInstance        = null;

        public  bool                 OutputDebugToConsole  = false;

        public static float TimeStamp { 
            get  { 
                return Time.time; 
            }
        }

        public int PointsPerRound {
            get {
                return parameters.WinningScore.Value;
            }
        }

        public int RoundLimit {
            get {
                return parameters.RequiredWins.Value;
            }
        }

        [SerializeField] private Game.GameParameters parameters     = null;

        private void Awake () {
            StaticInstance = this;
        }
    }
}