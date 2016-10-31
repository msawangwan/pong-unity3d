using UnityEngine;
using System;
using mGameFramework;

public class GameController : MonoBehaviour {
    public static GameController StaticInstance = null;

    public static Func<int> onScore { get; set; } // todo: remove static

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

    public  UIMasterCanvasController UI        = null;
    public  bool         OutputDebugToConsole  = false;

    [SerializeField]
    private Game.GameParameters parameters     = null;


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
    // private Game         game                  = null;

    // private int          state                 = -100;
    // private int          tickCount             = 0;

    // private float        blockDuration     = 0.0f;
    // private float        duration          = 2.0f;

    // private float BlockUntil { get { return Time.time + duration; } }
    // private Func<float, bool> onIsIntervalPastTime { get; set; }

    // private void RegisterHandler () {
    //     GlobalMediator.RaiseOnNewGameStarted += () => { state = -50; };

    //     onIsIntervalPastTime = (timestamp) => {
    //         if (Time.time > timestamp) {
    //             return true;
    //         }
    //         return false;
    //     };
    // }

    private void Awake () {
        StaticInstance = this;
    }

    // private void Start () {
    //     RegisterHandler ();
    // }

}
