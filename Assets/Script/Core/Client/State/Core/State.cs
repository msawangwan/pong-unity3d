using mExtensions.Common;

namespace mStateFramework.Core {
    public abstract class State<T> : IState<T> {
        public static System.Action<string> log = 
            (msg) => UnityEngine.Debug.LogFormat ("[info][state<t>] {0}", msg);

        public bool hasCompletedExecution { get { return completedExecution; } }
        public System.Action<IStateContext<T>> OnRaiseStateChanged { get; set; }

        protected bool completedExecution { get; private set; }

        protected abstract bool isExecuting { get; set; }
        protected abstract StateContext<T> InitialiseNewContext ();

        protected void OnChangeState () {
            if (!OnRaiseStateChanged.IsNull()) {
                StateContext<T> context = InitialiseNewContext ();
                OnRaiseStateChanged (context);
                completedExecution = true;
            }
        }

        public abstract void Enter (T currentContext);
        public abstract void Execute ();

        public State () {
            completedExecution = false;
            isExecuting = true;
        }
    }
}