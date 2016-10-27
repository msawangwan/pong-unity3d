using UnityEngine;

namespace mStateFramework {
    public class StateRoundPlay : StateGameplay {
        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Enter; 
            } 
        }

        public StateRoundPlay (Game currentContext) : base (currentContext) { }

        public override State<Game> Update () {
            return null;
        }        
    }
}
