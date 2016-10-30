using UnityEngine;
using mGameFramework;

public class GameStateCheckScoreForWin : GameState {
    private readonly int scoreRequired;

    public GameStateCheckScoreForWin (Game gameWithState, int scoreRequired) : base (gameWithState) {
        this.scoreRequired = scoreRequired;
    }

	public override Game UpdateState () {
        Winner winner = default(Winner);
        int currentIndex = -1;
        int winnerIndex = -1;
        winner.Current = null;

        foreach (Player p in GameWithUpdatedState.Players) {
            ++currentIndex;
            if (p.PointsScored >= scoreRequired) {
                winner.Current = Player.Add1RoundWin(p);
                winnerIndex = currentIndex;
                break;
            }
		}

		Player[] players = new Player[] {
			GameWithUpdatedState.PlayerOne,
			GameWithUpdatedState.PlayerTwo
		};

		if (winner.Current != null && winnerIndex != -1) {
            players[winnerIndex] = winner.Current;
        }

        return new Game (players[0], players[1], winner);
    }
}
