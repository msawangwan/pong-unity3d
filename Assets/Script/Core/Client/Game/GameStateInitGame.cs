using UnityEngine;

public class GameStateInitGame : GameState {
	public GameStateInitGame (Game gameWithState) : base (gameWithState) {}

	public override Game UpdateState () {
		foreach (Player p in GameWithUpdatedState.Players) {
			p.AssignedPaddle.gameObject.Enable ();
		}

        return GameWithUpdatedState;
    }
}
