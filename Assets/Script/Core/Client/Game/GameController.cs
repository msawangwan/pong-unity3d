using UnityEngine;
using System;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController StaticInstance = null;

    public static Func<int> onScore { get; set; } // todo: remove static

    public static int TickCounter {
        get {
            return GameController.StaticInstance.tickCount++;
        }
    }

    public static float TimeStamp { 
        get  { 
            return Time.time; 
        }
    }

    public  Game.GameParameters Parameters     = null;
    public  UIMasterCanvasController UI        = null;

    public  bool         OutputDebugToConsole  = false;

    private Game         game                  = null;

    private int          state                 = -100;
    private int          tickCount             = 0;

    private float        blockDuration     = 0.0f;
    private float        duration          = 2.0f;

    private float BlockUntil { get { return Time.time + duration; } }
    private Func<float, bool> onIsIntervalPastTime { get; set; }

    private void RegisterHandler () {
        GlobalMediator.RaiseOnNewGameStarted += () => { state = -50; };

        onIsIntervalPastTime = (timestamp) => {
            if (Time.time > timestamp) {
                return true;
            }
            return false;
        };
    }

    private void Awake () {
        StaticInstance = this;
    }

    private void Start () {
        RegisterHandler ();
    }


    private void Update_deprecate () {
        DebugToConsole (OutputDebugToConsole);

        if (state == -100) { // main menu
            return;
        }

        if (state == -50) {
            game = new Game ();
            state = -25;
            return;
        }

        if (state == -25) {
            game = Game.EnterState (new GameStateInitGame (game)); //STATE 1
            state = -15;
            return;
        }

        if (state == -15) {
            UI.UpdateScore (game.PlayerOne.PointsScored, game.PlayerTwo.PointsScored);
            state = 0;
            return;
        }

        if (state == 0) {
            UI.ScoreHUD.EnableOnlyIfInactive ();
            state = 1;
            return;
        }

        if (state == 1) { // start block
            UI.PrintCenter ("READY");
            blockDuration = BlockUntil;
            state = 2;
            return;
        }

        if (state == 2) { // block until true
            bool goNext = onIsIntervalPastTime (blockDuration);
            if (goNext) {
                UI.FadeCenter();
                state = 5;
            }
            return;
        }

        if (state == 5) {
            game = Game.EnterState (new GameStateServe (game, Player.PlayerID.P1)); //STATE 2
            state = 10;
            return;
        }

        if (state == 10) {
            if (game.PlayerOne.AssignedPaddle.IsInPlayPhase == true) {
                state = 20;
                return;
            }
        }

        if (state == 20) {
            Player.PlayerID scorer = Player.TryDetermineScoringPlayer (onScore);
            if (scorer != 0) {
                game = Game.EnterState (new GameStatePlayerScored (game, scorer)); //STATE 3
                onScore = null;
                state = 21;
                return;
            }
        }

        if (state == 21) { // start block
            UI.PrintCenter ("SCORE ");
            blockDuration = BlockUntil;
            state = 23;
            return;
        }

        if (state == 23) { // block until true
            bool goNext = onIsIntervalPastTime (blockDuration);
            if (goNext) {
                UI.FadeCenter();
                UI.UpdateScore (game.PlayerOne.PointsScored, game.PlayerTwo.PointsScored);
                blockDuration = BlockUntil;
                state = 26;
            }
            return;
        }

        if (state == 26) { // block until true
            bool goNext = onIsIntervalPastTime (blockDuration);
            if (goNext) {
                state = 40;
            }
            return;
        }

        if (state == 40) {
            game = Game.EnterState (new GameStateCheckScoreForWin (game, Parameters.WinningScore.Value)); //STATE 4
            if (game.PlayerRoundWinner != null) {
                state = 41;
            } else {
                state = 1;
            }
            return;
        }

        if (state == 41) { // start block
            UI.PrintCenter ("ROUND OVER");
            blockDuration = BlockUntil;
            state = 43;
            return;
        }

        if (state == 43) { // block until true
            bool goNext = onIsIntervalPastTime (blockDuration);
            if (goNext) {
                UI.FadeCenter();
                blockDuration = BlockUntil;
                state = 44;
            }
            return;
        }
    
        if (state == 44) { // block until true
            bool goNext = onIsIntervalPastTime (blockDuration);
            if (goNext) {
                state = 45;
            }
            return;
        }

        if (state == 45) {
            game = Game.EnterState (new GameStateCheckRoundsWon (game, Parameters.RequiredWins.Value)); //STATE 5
            if (game.PlayerGameWinner != null) {
                state = 46;
            } else {
                state = 1;
            }
            return;
        }

        if (state == 46) { // start block
            UI.PrintCenter ("GAME WINNER");
            blockDuration = BlockUntil;
            state = 47;
            return;
        }

        if (state == 47) { // block until true
            bool goNext = onIsIntervalPastTime (blockDuration);
            if (goNext) {
                UI.FadeCenter();
                blockDuration = BlockUntil;
                state = 48;
            }
            return;
        }

        if (state == 48) { // block until true
            bool goNext = onIsIntervalPastTime (blockDuration);
            if (goNext) {
                state = 50;
            }
            return;
        }

        if (state == 50) { // show winner menu
            state = -50;
            return;
        }
    }

    private void DebugToConsole (bool shouldPrint) {
        if (shouldPrint) {
            Debug.LogFormat("game controller state: {0}", state);
        }
    }
}
