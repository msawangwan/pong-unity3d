/// <summary>
/// todo: rename to paddlesetup
/// </summary>
using mExtensions.Common;

namespace mStateFramework {
    public class StateMapPlayerToPaddle : StateGameplay {
        protected override State<Game> nextState {
            get {
                if (nnnnnn.IsNull()) {
                    nnnnnn = new StateDesignateServer (game, Player.PlayerID.P1);
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

        public StateMapPlayerToPaddle (Game context) : base (context) { }

        public override bool Enter () {
            bool wasSuccess = false;

            foreach (Player p in game.Players) {
                wasSuccess = p.AssignedPaddle.EnableOnlyIfInactive ();
            }

            return wasSuccess;
        }
    }
}
