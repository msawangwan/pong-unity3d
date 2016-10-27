using UnityEngine;
using mExtensions.Common;
using mExtensions.Enum;
using System.Collections.Generic;

namespace mStateFramework {
    public class StateController : MonoBehaviour {
        public enum Step : int {
            None = 0,
            Continue,
            EnterMenu,
            OnMenu,
            ExitMenu,
            EnterGameplay,
            OnGameplay,
            ExitGameplay,
        }

        private System.Action<string> log;

        private StateController.Step step = StateController.Step.None;
        private State<Game>.Stage stage = State<Game>.Stage.None;

        private State<Game> current = null;
        private State<Game> newCurrent = null;

        private Game game = null;


        private void Awake () {
            GlobalMediator.RaiseOnNewGameStarted += 
                () => step = StateController.Step.EnterGameplay;
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

        private bool ProcessFrameEnterGameplay () {
            log("[Entered EnterGameplay]");

            if (current.IsNull ()) {
                current = new StateSpawnNewSession (null);
                step = StateController.Step.OnGameplay;
                return true;
            }

            return true;
        }

        private bool ProcessFrameOnGameplay () {
            log("[Entered OnGameplay]");
            log("[Stage: " + current.CurrentStage + "]");

            newCurrent = null;

            switch (current.CurrentStage) {
                case State<Game>.Stage.None:
                    return true;
                case State<Game>.Stage.Enter:
                    newCurrent = current.Enter ();

                    if (newCurrent.IsNull () == false) {
                        current = newCurrent;
                    }

                    return true;
                case State<Game>.Stage.Update:
                    newCurrent = current.Update ();

                    if (newCurrent.IsNull () == false) {
                        current = newCurrent;
                    }

                    return true;
                case State<Game>.Stage.Exit:
                    newCurrent  = current.Exit ();

                    if (newCurrent.IsNull () == false) {
                        current = newCurrent;
                    }
    
                    return true;
                default:
                    return false;
            }
        }

        private void Update () {
            log("[Update: Current Step is " + step.AsString() + " ]");

            switch (step) {
                case StateController.Step.None:
                    return;
                case StateController.Step.EnterMenu:
                    return;
                case StateController.Step.OnMenu:
                    return;
                case StateController.Step.ExitMenu:
                    return;
                case StateController.Step.EnterGameplay:
                    ProcessFrameEnterGameplay ();
                    return;
                case StateController.Step.OnGameplay:
                    ProcessFrameOnGameplay ();
                    return;
                case StateController.Step.ExitGameplay:
                    return;
                default:
                    return;
            }
        }
    }
}
