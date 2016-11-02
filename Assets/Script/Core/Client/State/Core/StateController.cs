using UnityEngine;
using mExtensions.Common;

namespace mStateFramework.Core {
    public abstract class StateController<T> : MonoBehaviour {
        public enum Status : int {
            None = 0,
            Loading,
            Executing,
            Terminating,
        }

        protected enum Initialised : byte {
            True,
            False,
        }

        private StateController<T>.Status controllerStatus = StateController<T>.Status.None;
        private StateController<T>.Initialised initialisedStatus = StateController<T>.Initialised.False;

        private T context = default(T); // context

        private IState<T> current;      // current state
        private IState<T> next;         // queued state

        private IState<T> initialised { // validates queued state prior to current = next
            set {
                current = value;
                current.OnRaiseStateChanged += HandleOnStateChanged;
                current.Enter (context);
            }
        }

        private IStateTransition transition;

        protected abstract bool debug_startOnButtonPress { get; }
        protected abstract StateController<T>.Status SetStatus();
        protected abstract State<T> LoadNew (StateController<T>.Initialised initStatus);

        public bool SetStatusToLoading () {
            return false;
        }

        private void HandleOnStateChanged(IStateContext<T> context) {
            this.context = context.Context;
            this.next = context.NextState;
            this.transition = context.Transition;
        }

        private void Start () {
            if (debug_startOnButtonPress) {
                GlobalMediator.RaiseOnNewGameStarted += 
                    () => controllerStatus = StateController<T>.Status.Loading;
            }
        }

        private void Update () {
            switch (controllerStatus) {
                case StateController<T>.Status.None:
                    return;
                case StateController<T>.Status.Loading:
                    State<T> newSession = LoadNew(initialisedStatus);

                    if (newSession.IsNull()) {
                        initialisedStatus = StateController<T>.Initialised.False;
                        return;
                    }

                    initialised = newSession;
                    initialisedStatus = StateController<T>.Initialised.True;
                    controllerStatus = StateController<T>.Status.Executing;

                    return;
                case StateController<T>.Status.Executing:
                    if (transition.IsNull() && !current.hasCompletedExecution) {
                        current.Execute();
                        return;
                    }

                    current.OnRaiseStateChanged -= HandleOnStateChanged;

                    if (next.IsNull()) {
                        controllerStatus = StateController<T>.Status.Terminating;
                        return;
                    }

                    if (!transition.IsNull()) {
                        if (!transition.hasTriggered) {
                            StartCoroutine (transition.LoadTransition ().GetEnumerator ());
                            return;
                        }

                        if (!transition.hasCompleted) {
                            return;
                        }
                    }

                    initialised = next;

                    next = null;
                    transition = null;

                    return;
                case StateController<T>.Status.Terminating:
                    return;
                default:
                    break;
            }
        }
    }
}