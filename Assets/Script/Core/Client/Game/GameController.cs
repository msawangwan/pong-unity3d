using UnityEngine;
using mGameFramework;

public class GameController : MonoBehaviour {
    public static GameController StaticInstance = null;

    public  bool         OutputDebugToConsole  = false;

    [SerializeField] private Game.GameParameters parameters     = null;

    public static int TickCounter {
        get {
            return 0;
        }
    }

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

    private void Awake () {
        StaticInstance = this;
    }
}
