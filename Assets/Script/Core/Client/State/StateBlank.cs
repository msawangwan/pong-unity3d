using UnityEngine;

public class StateBlank : State {
    public StateBlank (StateContext<Game> context) : base (context) {
        Context.IsComplete = true;
    }
}
