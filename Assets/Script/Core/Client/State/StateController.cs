using UnityEngine;
using mExtensions.Common;

namespace mStateFramework {
    public partial class StateController : MonoBehaviour {
        public enum State : int {
            None = 0,
            Block,
            Load,
            Enter,
            Update,
            Exit,
            Continue,
        }

        private StateController.State current = StateController.State.None;
        private State<Game> state = null;
        private Game game = new Game ();
        private bool isSessionInstance = false;

        private void Awake () {
            GlobalMediator.RaiseOnNewGameStarted +=
                () => current = StateController.State.Load;
        }

        private void Update () {
            switch (current) {
                case StateController.State.None:
                    return;
                case StateController.State.Load:
                    if (state == null && isSessionInstance == false) {
                        current = StateController.State.Enter;
                        state = new StateStartSession (Game.New ());
                        isSessionInstance = true;
                    }
                    return;
                default:
                    break;
            }

            bool stateComplete = false;

            switch (current) {
                case StateController.State.Enter:
                    state.Enter ();
                    current = StateController.State.Update;
                    break;
                case StateController.State.Update:
                    stateComplete = state.Update ();
                    if (stateComplete) {
                        current = StateController.State.Exit;
                    }
                    break;
                case StateController.State.Exit:
                    State<Game> next = state.Exit ();
                    if (!next.IsNull()) {
                        state = next;
                    }
                    current = StateController.State.Enter;
                    break;
                default:
                    break;
            }
        }
    }
}
