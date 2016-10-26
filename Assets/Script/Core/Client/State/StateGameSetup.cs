using UnityEngine;
using System.Collections;

namespace mStateFramework {
    public class StateGameSetup : State<Game> {
        private readonly Game game;        

        protected override State<Game>.Stage SetStage () {
            return State<Game>.Stage.Enter;
        }

        public StateGameSetup (Game currentContext) : base (currentContext){
            this.game = Game.CopyOf(currentContext);
        }

        public override State<Game> Enter () {
            foreach (Player p in game.Players) {
                p.AssignedPaddle.EnableOnlyIfInactive ();
            }

            return new StateStartRound (game, Player.PlayerID.P1);
        }
    }
}
