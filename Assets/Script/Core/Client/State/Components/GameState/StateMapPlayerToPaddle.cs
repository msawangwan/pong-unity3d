﻿using mGameFramework.Core;

namespace mStateFramework.Core {
    public class StateMapPlayerToPaddle : State<Game> {
        private Game game = null;

        protected override bool isExecuting { get; set; }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                foreach (Player p in game.Players) {
                    if (p.AssignedPaddle != null) {
                        p.AssignedPaddle.EnableOnlyIfInactive ();
                    }
                }
                isExecuting = false;
            } else {
                OnChangeState();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game>(
                game,
                new StateDesignateServingPlayer(
                    new PlayerServer(game.PlayerOne)
                ),
                null
            );
        }
    }
}
