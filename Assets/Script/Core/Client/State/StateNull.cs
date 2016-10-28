using UnityEngine;

namespace mStateFramework {
    public class StateNull : StateGameplay {
        protected override State<Game> nextState {
            get {
                return new StateNull (game);
            }
        }

        protected override State<Game>.Stage initialStage { 
            get {
                return State<Game>.Stage.None;
            }
        }

        public StateNull (Game context) : base (context) { }
    }
}