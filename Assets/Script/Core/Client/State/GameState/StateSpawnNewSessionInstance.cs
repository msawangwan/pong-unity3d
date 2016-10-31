using mExtensions.Common;
using mGameFramework;

namespace mStateFramework {
	public class StateSpawnNewSessionInstance : State<Game> {
        protected override bool completedExecution { get; set; }
        private bool isExecuting = true;

        private Game game = null;

        public StateSpawnNewSessionInstance() : base () {
            completedExecution = false;
        }

        public override void Enter (Game context) {
            game = new Game();
        }

        public override void Execute () {
            if (isExecuting) {
                isExecuting = false;
            } else {
                OnChangeState ();
                completedExecution = true;
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game> (
                game,
                new StateMapPlayerToPaddle (),
                new StateTransitionToggleHUD (true)
            );
        }
    }
}
