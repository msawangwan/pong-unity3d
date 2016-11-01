﻿using mGameFramework;
using mUIFramework.mvc;

namespace mStateFramework {
	public class StateSpawnNewSessionInstance : State<Game> {
        private Game game = null;

        protected override bool isExecuting { get; set; }

        public StateSpawnNewSessionInstance() : base () { }

        public override void Enter (Game context) {
            game = new Game();
        }

        public override void Execute () {
            if (isExecuting) {
                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game> (
                game,
                new StateStartNewRound (),
                null
            );
        }
    }
}