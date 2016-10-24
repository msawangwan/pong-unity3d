using UnityEngine;

public abstract class GameState : IGameState {
	public Game   GameWithUpdatedState { get; protected set; }

    public GameState (Game gameWithState) {
        Player oldP1 = gameWithState.PlayerOne;
        Player oldP2 = gameWithState.PlayerTwo;

        Player newP1 = new Player (oldP1.PID, oldP1.PointsScored, oldP1.RoundsWon);
        Player newP2 = new Player (oldP2.PID, oldP2.PointsScored, oldP2.RoundsWon);

        GameWithUpdatedState = new Game (newP1, newP2);
    }

    public abstract Game UpdateState ();
}
