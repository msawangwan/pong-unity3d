using UnityEngine;
using mGameFramework;

public class GameStatePlayerScored : GameState {
    private readonly Player.PlayerID scoringPID;

    public GameStatePlayerScored (Game gameWithState, Player.PlayerID scoringPID) : base (gameWithState) {
        this.scoringPID = scoringPID;
    }

	public override Game UpdateState () {
        int currentPlayerIndex = -1;
        int scoringPlayerIndex = -1;

        foreach (Player p in GameWithUpdatedState.Players) {
            ++currentPlayerIndex;
            if (p.PID == scoringPID) {
                scoringPlayerIndex = currentPlayerIndex;
                break;
            }
		}

        Player[] players = new Player[] { 
            GameWithUpdatedState.PlayerOne, 
            GameWithUpdatedState.PlayerTwo 
        };

        Player scored = players[scoringPlayerIndex];
        players[scoringPlayerIndex] = Player.Add1Score(scored);

        return new Game (players);
    }
}