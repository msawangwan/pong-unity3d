using UnityEngine;

public class GameStateCheckRoundsWon : GameState {
    private readonly int roundsRequired;

    public GameStateCheckRoundsWon (Game gameWithState, int roundsRequired) : base (gameWithState) {
        this.roundsRequired = roundsRequired;
    }

	public override Game UpdateState () {
        Winner winner = default(Winner);

        int currentIndex = -1;
        int gameWinnerIndex = -1;

        winner.Current = null;

		foreach (Player p in GameWithUpdatedState.Players) {
            ++currentIndex;
            if (p.RoundsWon >= roundsRequired) {
                winner.Current = Player.NewFrom (p);
                gameWinnerIndex = currentIndex;
                break;
            }
		}

        Player[] players = new Player[] {
            GameWithUpdatedState.PlayerOne,
            GameWithUpdatedState.PlayerTwo
        };

		if (winner.Current != null && gameWinnerIndex != -1) {
            players[gameWinnerIndex] = winner.Current;
        	return new Game(players[0], players[1], winner, true);
        }

        return new Game(players[0], players[1], winner);
    }
}
