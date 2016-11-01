using UnityEngine;
using mGameFramework.Core;
using mUIFramework.Core;
using mExtensions.Common;

namespace mStateFramework.Core {
    public partial class StateController : MonoBehaviour {
        public enum Status : int {
            None = 0,
            Loading,
            Executing,
            Terminating,
        }

        public enum Session : byte {
            NotLoaded,
            HasLoaded,
        }

        private StateController.Status controllerStatus = StateController.Status.None;
        private StateController.Session session = StateController.Session.NotLoaded;

        private Game game = null; // context

        private IState<Game> current; // current state
        private IState<Game> next; // queued state

        private IState<Game> initialised { // run queued state through a property prior
            set {
                current = value;
                current.OnRaiseStateChanged += HandleOnStateChanged;
                current.Enter (game);
            }
        }

        private IStateTransition transition;

        private void HandleOnStateChanged(IStateContext<Game> context) {
            game = context.Context;
            next = context.NextState;
            transition = context.Transition;
        }

        private void Start () {
            GlobalMediator.RaiseOnNewGameStarted += 
                () => controllerStatus = StateController.Status.Loading;
        }

        private void Update () {
            switch (controllerStatus) {
                case StateController.Status.None:
                    return;
                case StateController.Status.Loading:
                    State<Game> newSession = LoadNew(session);

                    if (newSession.IsNull()) {
                        session = StateController.Session.NotLoaded;
                        return;
                    }

                    initialised = newSession;
                    session = StateController.Session.HasLoaded;
                    controllerStatus = StateController.Status.Executing;

                    return;
                case StateController.Status.Executing:
                    if (transition.IsNull() && !current.hasCompletedExecution) {
                        current.Execute();
                        return;
                    }

                    current.OnRaiseStateChanged -= HandleOnStateChanged;

                    if (next.IsNull()) {
                        controllerStatus = StateController.Status.Terminating;
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
                case StateController.Status.Terminating:
                    return;
                default:
                    break;
            }
        }

        private State<Game> LoadNew(StateController.Session sessionStatus) {
            if (sessionStatus == StateController.Session.NotLoaded) {
                return new StateSpawnNewSessionInstance();
            }
            return null;
        }
    }
}