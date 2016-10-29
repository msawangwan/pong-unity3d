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

        private StateController.State masterState = StateController.State.None;
        private StateController.Session session = StateController.Session.NoInstance;

        private State<Game> gameState = null;
        private State<UI> uiState = null;

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
                        gameState = new StateStartSession (Game.New ());
                        session = StateController.Session.HasInstance;
                        masterState = StateController.State.Enter;
                    }
                    if (uiState == null) {
                        uiState = new StateEnableGameHUD (
                            new UI(UIController),
                            b => UIController.ToggleScoreboardActive(b)
                        );
                        masterState = StateController.State.EnterUI;
                    }
                    return;
                default:
                    break;
            }

            switch (masterState) {
                case StateController.State.Enter:
                    gameState.Enter ();
                    masterState = StateController.State.Update;
                    break;
                case StateController.State.Update:
                    canContinue = gameState.Update ();
                    if (canContinue) {
                        masterState = StateController.State.Exit;
                    }
                    break;
                case StateController.State.Exit:
                    State<Game> next = gameState.Exit ();
                    if (!next.IsNull()) {
                        gameState = next;
                    }
                    masterState = StateController.State.EnterUI;
                    break;
                default:
                    break;
            }

            switch (masterState) {
                case StateController.State.EnterUI:
                    uiState.Enter ();
                    masterState = StateController.State.UpdateUI;
                    return;
                case StateController.State.UpdateUI:
                    canContinue = uiState.Update ();
                    if (!canContinue) {
                        return;
                    }
                    masterState = StateController.State.ExitUI;
                    break;
                case StateController.State.ExitUI:
                    State<UI> next = uiState.Exit ();
                    if (!next.IsNull()) {
                        uiState = next;
                    }
                    masterState = StateController.State.Enter;
                    break;
                default:
                    break;
            }
        }
    }
}
