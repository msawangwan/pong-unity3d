using UnityEngine;

public class StateSpawnNewSession : State {
    private readonly Game newGame;

    public StateSpawnNewSession (StateContext<Game> context) : base (context) { }

    protected override StateContext<Game> UpdateState () {
        return new StateContext<Game> (
            new Game(),
            true
        );
    }
}
