using UnityEngine;

namespace mStateFramework {
    public class StateNull : State<Game> {        
        public StateNull () : base () {

        }

        protected override State<Game>.Stage SetStage () {
            return State<Game>.Stage.None;
        }
    }
}