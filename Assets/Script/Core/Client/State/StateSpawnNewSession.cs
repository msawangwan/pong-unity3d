using UnityEngine;
using mExtensions.Common;

namespace mStateFramework {
    public class StateSpawnNewSession : StateGameplay {
        protected override State<Game>.Stage initialStage { 
            get {
                return State<Game>.Stage.Enter;
            }
        }

        public StateSpawnNewSession (Game currentContext) : base (currentContext) {}

        public override State<Game> Enter () {
            return new StateGameSetup (new Game());
        }
    }
}
