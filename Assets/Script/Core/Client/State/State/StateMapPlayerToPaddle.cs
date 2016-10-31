using mGameFramework;

namespace mStateFramework {
    public class StateMapPlayerToPaddle : State<Game> {
        private Game game = null;
        private bool isExecuting = true;

        protected override bool completedExecution { get; set; }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                foreach (Player p in game.Players) {
                    p.AssignedPaddle.EnableOnlyIfInactive ();
                }
                isExecuting = false;
            } else {
                OnChangeState();
                completedExecution = true;
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
