using UnityEngine;

namespace mStateFramework {
    public class StateNull : State<Game> {        
        public StateNull (Game currentContext) : base (currentContext) { }

        protected override State<Game>.Stage SetStage () {
            return State<Game>.Stage.None;
        }
    }
}