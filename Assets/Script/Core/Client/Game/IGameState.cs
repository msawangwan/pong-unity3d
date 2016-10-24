using UnityEngine;

public interface IGameState {
	Game   GameWithUpdatedState { get; }
	Game UpdateState ();
}
