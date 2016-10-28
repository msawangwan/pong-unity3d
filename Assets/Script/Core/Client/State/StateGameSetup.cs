/// <summary>
/// todo: rename to paddlesetup
/// </summary>

namespace mStateFramework {
    public class StateGameSetup : StateGameplay {
        protected override State<Game> nextState {
            get {
                return new StateDesignateServer (game, Player.PlayerID.P1);
            }
        }

        protected override State<Game>.Stage initialStage { 
            get {
                return State<Game>.Stage.Enter; 
            } 
        }

        public StateGameSetup (Game currentContext) : base (currentContext) { }

        public override bool Enter () {
            bool wasSuccess = false;

            foreach (Player p in game.Players) {
                wasSuccess = p.AssignedPaddle.EnableOnlyIfInactive ();
            }

            return wasSuccess;
        }
    }
}
