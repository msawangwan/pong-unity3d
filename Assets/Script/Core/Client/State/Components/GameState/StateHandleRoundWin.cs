using mGameFramework.Core;

namespace mStateFramework.Core {
    public class StateHandleRoundWin : State<Game> {
        private readonly PlayerWinner winner;

        private Game game = null;
        private bool allocatedScore = false;

        protected override bool isExecuting { get; set; }

        public StateHandleRoundWin (PlayerWinner winner) : base () {
            this.winner = winner;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                if (!allocatedScore) {
                    allocatedScore = true;
                    ++winner.Winner.RoundsWon;
                }

                // todo: UPDATE UI

                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game>(
                game,
                new StateCheckForGameWin (winner),
                null
            );
        }
    }
}
