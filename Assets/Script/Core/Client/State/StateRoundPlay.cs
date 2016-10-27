using UnityEngine;

namespace mStateFramework {
    public class StateRoundPlay : State<Game> {
        public StateRoundPlay (Game currentContext) : base (currentContext) { }

        protected override State<Game>.Stage SetInitialStage () {
            return State<Game>.Stage.Update;
        }

        public override State<Game> Update () {
            return null;
        }        
    }
}
