using UnityEngine;

public class StateContext<T> {
    public readonly T Context;

    public StateContext(T context) {
        Context = context;
    }
}
