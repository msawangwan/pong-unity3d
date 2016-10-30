using UnityEngine;
using mGameFramework;

public interface IGameState {
	Game   GameWithUpdatedState { get; }
	Game UpdateState ();
}
