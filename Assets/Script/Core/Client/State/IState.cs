using UnityEngine;

public interface IState {
    StateContext<Game> OnEnterState  ();
    StateContext<Game> UpdateState ();
    StateContext<Game> OnExitState   ();
}
