using UnityEngine;
using System.Collections;

namespace mStateFramework {
    public class StateGameSetup : StateGameplay {
        protected override State<Game>.Stage initialStage { get { return State<Game>.Stage.Enter; } }

        public StateGameSetup (Game currentContext) : base (currentContext) { }

        public override State<Game> Enter () {
            foreach (Player p in game.Players) {
                p.AssignedPaddle.EnableOnlyIfInactive ();
            }

            return new StateRoundServe (game, Player.PlayerID.P1);
        }
    }
}
