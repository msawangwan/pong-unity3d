using mExtensions.Common;

namespace mStateFramework {
    public class StateSpawnNewSession : StateGameplay {
        protected override State<Game> nextState {
            get {
                if (nnnnnn.IsNull()) {
                    nnnnnn = new StateMapPlayerToPaddle(game);
                }
                return nnnnnn;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get {
                return State<Game>.Stage.Enter;
            }
        }

        private State<Game> nnnnnn = null;

        public StateSpawnNewSession (Game context) : base (context) { }

        public override bool Enter () {
            return true;
        }
    }
}
