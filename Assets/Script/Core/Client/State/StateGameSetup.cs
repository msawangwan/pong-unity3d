﻿/// <summary>
/// todo: rename to paddlesetup
/// </summary>

namespace mStateFramework {
    public class StateGameSetup : StateGameplay {
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

        public StateGameSetup (Game currentContext) : base (currentContext) { 
            nnnnnn = new StateDesignateServer (game, Player.PlayerID.P1);
        }

        public override bool Enter () {
            bool wasSuccess = false;

            foreach (Player p in game.Players) {
                wasSuccess = p.AssignedPaddle.EnableOnlyIfInactive ();
            }

            return wasSuccess;
        }
    }
}
