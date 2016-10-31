using mGameFramework;

namespace mStateFramework {
    public class StateCheckForRoundWin : State<Game> {
        private readonly PlayerScorer scored; // todo: change to type
        private Game game = null;
        private bool isExecuting = true;
        private State<Game> next;

        protected override bool completedExecution { get; set; }

        public StateCheckForRoundWin(PlayerScorer scored) : base () {
            this.scored = scored;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                int winningScore = GameController.StaticInstance.PointsPerRound;

                if (scored.CurrentScore >= winningScore) {
                    next = new StateHandleRoundWin (
                        new PlayerWinner (scored.Scorer, PlayerWinner.Type.Round)
                    );
                } else {
                    next = new StateDesignateServingPlayer (
                        new PlayerServer (game.PlayerOne) // todo: should be scorer
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