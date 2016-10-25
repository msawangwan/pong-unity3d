using UnityEngine;

public class StateNewGame : State {
    public StateNewGame (StateContext<Game> context) : base (context) {}

    protected override StateContext<Game> UpdateState () {
        return null;
    }
}
