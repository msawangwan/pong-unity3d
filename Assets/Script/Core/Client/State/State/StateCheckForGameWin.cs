using mGameFramework;

namespace mStateFramework {
    public class StateCheckForGameWin :State<Game> {
        private readonly PlayerWinner winner;
        private Game game = null;
        private bool isExecuting = true;
        private State<Game> next;

        protected override bool completedExecution { get; set; }

        public StateCheckForGameWin (PlayerWinner winner) : base () {
            this.winner = winner;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                int roundLimit = GameController.StaticInstance.RoundLimit;

                if (winner.Winner.RoundsWon >= roundLimit) {
                    next = new StateHandleGameWin (
                        new PlayerWinner(winner.Winner, PlayerWinner.Type.Game)
                    );
                } else {
                    next = new StateDesignateServingPlayer(
                        new PlayerServer(game.PlayerOne) // todo: should be scorer
                    );
                }

                isExecuting = false;
            } else {
                OnChangeState ();
                completedExecution = true;
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game>(
                game,
                next,
                null
            );
        }
    }
}
