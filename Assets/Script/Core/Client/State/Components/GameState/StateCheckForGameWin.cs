using mGameFramework.Core;

namespace mStateFramework.Core {
    public class StateCheckForGameWin :State<Game> {
        private readonly PlayerWinner winner;

        private Game game = null;
        private State<Game> next;

        protected override bool isExecuting { get; set; }

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
