using UnityEngine;

public class StateSpawnNewSession : State {
    public StateSpawnNewSession (StateContext<Game> context) : base (context) { }

    protected override State UpdateState () {
        StateContext<Game> newGameContext = new StateContext<Game>(
            new Game(),
            true
        );

        return new StateGameSetup (newGameContext);
    }
}
