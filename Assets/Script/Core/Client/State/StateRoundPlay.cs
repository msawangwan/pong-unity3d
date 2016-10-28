using UnityEngine;

namespace mStateFramework {
    public class StateRoundPlay : StateGameplay {
        protected override State<Game> nextState {
            get {
                return nnnn;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Enter; 
            } 
        }

        private readonly State<Game> nnnn = null;

        public StateRoundPlay (Game currentContext) : base (currentContext) {
            nnnn = new StateRoundPlay(game);
        }

        public override bool Update () {
            return true;
        }        
    }
}
