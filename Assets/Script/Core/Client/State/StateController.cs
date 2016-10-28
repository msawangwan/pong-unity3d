using UnityEngine;
using mExtensions.Common;
using mExtensions.Enum;

namespace mStateFramework {
    public partial class StateController : MonoBehaviour {
        public enum Stage : int {
            None = 0,
            Continue,
            Block,
            Enter,
            Update,
            Exit,
        }

        private bool isAlreadyGame = false;
        private bool isComplete = false;
        private State<Game> current = null;
        private StateController.Stage stage = StateController.Stage.None;
        private System.Action<string> log;

        private void Awake () {
            GlobalMediator.RaiseOnNewGameStarted += 
                () => stage = StateController.Stage.Enter;
        }

        private void Start () {
            log = msg => Debug.LogFormat (
                "[STATE][INFO][{0}]: [{1}] [{2}]", 
                this.GetType().Name, 
                msg,
                0// Time.time
            );
            
            log("[Logger Initialised]");
        }

        private void Update () {
            if (stage == StateController.Stage.None) {
                return;
            }

            if (current.IsNull () && isAlreadyGame == false) {
                current = new StateSpawnNewSession (new Game());
                isAlreadyGame = true;
            }

            log("[Update: Current Stage is " + stage.AsString() + " ]");
            log("[Update: Current State is " + current.GetType().Name + " ]");

            switch (stage) {
                case StateController.Stage.Continue:
                    break;
                case StateController.Stage.Block:
                    break;
                case StateController.Stage.Enter:
                    isComplete = current.Enter ();
                    break;
                case StateController.Stage.Update:
                    isComplete = current.Update ();
                    break;
                case StateController.Stage.Exit:
                    isComplete = current.Exit ();
                    break;
                default:
                    return;
            }

            if (isComplete) {
                StateController.Stage current_temp = stage;
                stage = NextStage(stage);

                if (current_temp == StateController.Stage.Exit) {
                    log("[Update: Stage Exit Reached: " +  current.GetType().Name + " ]");
                    // log("[Update: Stage Exit Reached: " +  current.GetType().Name + " " + current.Next.GetType().Name  +" ]");
                    current = current.Next;
                }

                log("[Update: Stage completed: " + current_temp.AsString() + " ]");
                log("[Update: Setting next stage too: " + stage.AsString() + " ]");

                return;
            }

            return;
        }
    }

    public partial class StateController {
        private StateController.Stage NextStage (StateController.Stage currentStage) {
            switch (currentStage) {
                case StateController.Stage.Continue:
                    return StateController.Stage.Continue;
                case StateController.Stage.Block:
                    return StateController.Stage.Block;
                case StateController.Stage.Enter:
                    return StateController.Stage.Update;
                case StateController.Stage.Update:
                    return StateController.Stage.Exit;
                case StateController.Stage.Exit:
                    return StateController.Stage.Enter;
                default:
                    return StateController.Stage.None;
            }
        }
    }
}
