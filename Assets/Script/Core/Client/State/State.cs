using UnityEngine;

public abstract class State {
    public readonly StateContext<Game> Context;

    public bool DoneEnter { get; private set; }
    public bool DoneUpdate { get; private set; }
    public bool DoneExit { get; private set; }

    private System.Action<string> log;

    public State (StateContext<Game> context, bool doneEnter, bool doneUpdate, bool doneExit) {
        log = msg => Debug.LogFormat("current state is in: {0}", msg);
        Context = context;

        DoneEnter = doneEnter;
        DoneUpdate = doneUpdate;
        DoneExit = doneExit;
    }

    public static State StateEmptyIteration () {
        return new StateBlank (new StateContext<Game> (null, true), true, true, true);
    }

    protected virtual State EnterState () {
        return State.StateEmptyIteration();
    }

    protected virtual State UpdateState () {
        return State.StateEmptyIteration();
    }

    protected virtual State ExitState () {
        return State.StateEmptyIteration();
    }

    public State OnEnterState () {
        State newState = EnterState ();
        DoneEnter = newState.Context.IsComplete;
        log(DoneEnter.ToString());
        return newState;
    }

    public State OnUpdateState () {
        State newState = UpdateState ();
        DoneUpdate = newState.Context.IsComplete;
        log(DoneUpdate.ToString());
        return newState;
    }

    public State OnExitState () {
        State newState = ExitState ();
        DoneExit = newState.Context.IsComplete;
        log(DoneExit.ToString());
        return newState;
    }
}