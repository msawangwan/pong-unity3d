using UnityEngine;

namespace mStateFramework {
    public class StateRoundPlay : StateGameplay {
        protected override State<Game> nextState {
            get {
                return new StateRoundPlay (game);
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Enter; 
            } 
        }

        public StateRoundPlay (Game currentContext) : base (currentContext) { }

        public override bool Update () {
            return false;
        }        
    }
}
