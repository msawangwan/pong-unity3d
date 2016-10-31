using mGameFramework;

namespace mStateFramework {
    public class StateHandleRoundWin : State<Game> {
        private readonly PlayerWinner winner;
        private Game game = null;
        private bool isExecuting = true;
        private bool allocatedScore = false;

        protected override bool completedExecution { get; set; }

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
                completedExecution = true;
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
