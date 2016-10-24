using UnityEngine;

public class GameStateServe : GameState {
    private readonly Player.PlayerID serverPID;

    public GameStateServe (Game gameWithState, Player.PlayerID serverPID) : base (gameWithState) {
        this.serverPID = serverPID;
    }

	public override Game UpdateState () {
        int serverPlayerIDIndex = -1;
        int currentPlayerIDIndex = -1;

        foreach (Player p in GameWithUpdatedState.Players) {
            p.AssignedPaddle.ChangePhaseToServe ();

            ++currentPlayerIDIndex;

			if (p.PID == serverPID) {
                serverPlayerIDIndex = currentPlayerIDIndex;
            }
        }

        Player[] playersWithServerSet = new Player[] { 
            GameWithUpdatedState.PlayerOne, 
            GameWithUpdatedState.PlayerTwo 
        };

        playersWithServerSet[serverPlayerIDIndex].AssignedPaddle.IsSetAsServing = true;;
        return new Game (playersWithServerSet);
    }
}
