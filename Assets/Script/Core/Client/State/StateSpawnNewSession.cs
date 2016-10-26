using UnityEngine;
using mExtensions.Common;

namespace mStateFramework {
    public class StateSpawnNewSession : State<Game> {
        public StateSpawnNewSession (Game currentContext) : base (currentContext) {}
        
        protected override State<Game>.Stage SetStage () {
            return State<Game>.Stage.Enter;
        }

        public override State<Game> Enter () {
            log("spawned new session");
            return new StateGameSetup (new Game());
        }
    }
}
