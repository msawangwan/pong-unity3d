using UnityEngine;

public class StateStartRound : State {
    public StateStartRound (StateContext<Game> context) : base (context) {}

    protected override State UpdateState () {
        return State.StateEmptyIteration();
    }

}
