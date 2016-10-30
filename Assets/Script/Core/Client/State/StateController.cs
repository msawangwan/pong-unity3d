using UnityEngine;
using mGameFramework;
using mUIFramework.Core;
using mExtensions.Common;

namespace mStateFramework {
    public partial class StateController : MonoBehaviour {
        public enum State : int {
            None = 0,
            Load,
            EnterUI,
            UpdateUI,
            ExitUI,
            Enter,
            Update,
            Exit,
            Continue,
        }

        public enum Session : byte {
            NoInstance,
            HasInstance,
        }

        public UIMasterCanvasController UIController = null;

        private StateController.State masterState = StateController.State.None;
        private StateController.Session session = StateController.Session.NoInstance;

        private State<Game> gameState = null;
        // private State<UI> uiState = null;

        private bool canContinue = false;

        private void Awake () {
            GlobalMediator.RaiseOnNewGameStarted +=
                () => masterState = StateController.State.Load;
        }

        private void Update () {
            switch (masterState) {
                case StateController.State.None:
                    return;
                case StateController.State.Load:
                    if (gameState == null && session == StateController.Session.NoInstance) {
                        gameState = new StateGame(null, new StateCreateSessionInstance(), null, null, null);
                        session = StateController.Session.HasInstance;
                        masterState = StateController.State.Enter;
                    }
                    return;
                default:
                    break;
            }

            switch (masterState) {
                case StateController.State.Enter:
                    break;
                case StateController.State.Update:
                    break;
                case StateController.State.Exit:
                    break;
                default:
                    break;
            }

            switch (masterState) {
                case StateController.State.EnterUI:
                    return;
                case StateController.State.UpdateUI:
                    break;
                case StateController.State.ExitUI:
                    break;
                default:
                    break;
            }
        }
    }
}
