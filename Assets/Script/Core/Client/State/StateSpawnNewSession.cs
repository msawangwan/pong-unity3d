using UnityEngine;
using mExtensions.Common;

namespace mStateFramework {
    public class StateSpawnNewSession : StateGameplay {
        protected override State<Game> nextState {
            get {
                return nnnnnn;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get {
                return State<Game>.Stage.Enter;
            }
        }

        private readonly State<Game> nnnnnn = null;

        public StateSpawnNewSession (Game currentContext) : base (currentContext) {
            nnnnnn = new StateGameSetup(game);
        }

        public override bool Enter () {
            return true;
        }
    }
}
