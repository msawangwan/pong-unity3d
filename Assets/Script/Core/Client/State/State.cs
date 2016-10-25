using UnityEngine;

public abstract class State {
    public readonly StateContext<Game> Context;

    public bool DoneEnter { get; private set; }
    public bool DoneUpdate { get; private set; }
    public bool DoneExit { get; private set; }

    public State (StateContext<Game> context) {
        Context = context;
    }

    protected virtual StateContext<Game> UpdateState () {
        return null;
    }

    protected virtual StateContext<Game> EnterState () {
        return null; 
    }

    protected virtual StateContext<Game> ExitState () {
        return null; 
    }

    public StateContext<Game> OnEnterState () {
        StateContext<Game> newContext = EnterState ();
        if (newContext != null) {
            DoneEnter = newContext.IsComplete;
        } else {
            DoneEnter = true;
        }
        return newContext;
    }

    public StateContext<Game> OnUpdateState () {
        StateContext<Game> newContext = UpdateState ();
        if (newContext != null) {
            DoneUpdate = newContext.IsComplete;
        } else {
            DoneUpdate = true;
        }
        return newContext;
    }

    public StateContext<Game> OnExitState () {
        StateContext<Game> newContext = OnExitState ();
        if (newContext != null) {
            DoneExit = newContext.IsComplete;
        } else {
            DoneExit = true;
        }
        return newContext;
    }
}