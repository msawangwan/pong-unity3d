using System;
using mExtensions.Common;

namespace mStateFramework {
    public abstract class State<T> : IState<T> {
        public static Action<string> log = (msg) => UnityEngine.Debug.LogFormat("[info][state<t>] {0}", msg);

        public bool hasCompletedExecution { get { return completedExecution; } }
        public Action<IStateContext<T>> OnRaiseStateChanged { get; set; }

        protected abstract bool completedExecution { get; set; }
        protected abstract StateContext<T> InitialiseNewContext();

        protected void OnChangeState() {
            if (!OnRaiseStateChanged.IsNull()) {
                StateContext<T> context = InitialiseNewContext();
                OnRaiseStateChanged(context);
            }
        }

        public abstract void Enter(T currentContext);
        public abstract void Execute();
    }
}