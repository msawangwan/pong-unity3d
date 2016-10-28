using UnityEngine;

namespace mStateFramework {
    public class StateRoundPlay : StateGameplay {
        protected override State<Game> nextState {
            get {
                if (nnnn == null) {
                    nnnn = new StateRoundPlay(game);
                }
                return nnnn;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Update; 
            } 
        }

        private State<Game> nnnn = null;

        public StateRoundPlay (Game context) : base (context) { }

        public override bool Update () {
            return false;
        }        
    }
}
