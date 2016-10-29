using UnityEngine;
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

        private StateController.State current = StateController.State.None;
        private StateController.Session session = StateController.Session.NoInstance;
        private State<Game> gameState = null;
        private State<UI> uiState = null;

        private void Awake () {
            GlobalMediator.RaiseOnNewGameStarted +=
                () => current = StateController.State.Load;
        }

        private void Update () {
            switch (current) {
                case StateController.State.None:
                    return;
                case StateController.State.Load:
                    if (gameState == null && session == StateController.Session.NoInstance) {
                        gameState = new StateStartSession (Game.New ());
                        session = StateController.Session.HasInstance;
                        current = StateController.State.Enter;
                    }
                    if (uiState == null) {
                        uiState = new StateEnableGameHUD (
                            new UI(UIController),
                            b => UIController.ToggleScoreboardActive(b)
                        );
                        current = StateController.State.EnterUI;
                    }
                    return;
                default:
                    break;
            }

            bool canContinue = false;

            switch (current) {
                case StateController.State.EnterUI:
                    uiState.Enter ();
                    current = StateController.State.UpdateUI;
                    return;
                case StateController.State.UpdateUI:
                    canContinue = uiState.Update ();
                    if (!canContinue) {
                        return;
                    }
                    current = StateController.State.ExitUI;
                    break;
                case StateController.State.ExitUI:
                    State<UI> next = uiState.Exit ();
                    if (!next.IsNull()) {
                        uiState = next;
                    }
                    current = StateController.State.Enter;
                    break;
                default:
                    break;
            }

            bool stateComplete = false;

            switch (current) {
                case StateController.State.Enter:
                    gameState.Enter ();
                    current = StateController.State.Update;
                    break;
                case StateController.State.Update:
                    stateComplete = gameState.Update ();
                    if (stateComplete) {
                        current = StateController.State.Exit;
                    }
                    break;
                case StateController.State.Exit:
                    State<Game> next = gameState.Exit ();
                    if (!next.IsNull()) {
                        gameState = next;
                    }
                    current = StateController.State.EnterUI;
                    break;
                default:
                    break;
            }
        }
    }
}
