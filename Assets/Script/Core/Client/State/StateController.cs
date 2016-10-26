using UnityEngine;
using mExtensions.Enum;
using System.Collections.Generic;

namespace mStateFramework {
    public class StateController : MonoBehaviour {
        public enum Step : int {
            None = 0,
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
        private State<Game> next = null;
        private State<Game> end = null;
    
        private Game game = null;


        private void Awake () {
            GlobalMediator.RaiseOnNewGameStarted += 
                () => step = StateController.Step.EnterGameplay;
        }

        private void Start () {
            log = msg => Debug.LogFormat (
                "[STATE][INFO][{0}]: {1}", 
                this.GetType().Name, 
                msg
            );
        }

        private bool ProcessFrameEnterGameplay () {
            step = StateController.Step.OnGameplay;
            return true;
        }

        private bool ProcessFrameOnGameplay () {
            if (current == null) {
                current = new StateSpawnNewSession(null);
                return true;
            }

            log("processing gameplay, stage = " + current.CurrentStage);

            switch (current.CurrentStage) {
                case State<Game>.Stage.None:
                    return true;
                case State<Game>.Stage.Enter:
                    current = current.Enter ();
                    return true;
                case State<Game>.Stage.Update:
                    current = current.Update ();
                    return true;
                case State<Game>.Stage.Exit:
                    next = current.Exit ();
                    return true;
                default:
                    return false;
            }
        }

        private void Update () {
            log("update, step = " + step.AsString());

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
            }
        }
    }
}
