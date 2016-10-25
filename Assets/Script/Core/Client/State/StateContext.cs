using UnityEngine;

public class StateContext<T> : IStateContext {
    public T               Context    { get; private set; }
    public bool            IsComplete { get; set; }

    public StateContext(T context, bool isComplete) {
        Context = context;
        IsComplete = isComplete;
    }
}
