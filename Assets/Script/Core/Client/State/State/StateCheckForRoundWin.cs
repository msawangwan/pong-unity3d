using mGameFramework;

namespace mStateFramework {
    public class StateCheckForRoundWin : State<Game> {
        private readonly PlayerScorer scored;

        private string text = string.Empty;
        private Game game = null;
        private State<Game> next = null;
        private StateTransition<mUIFramework.Core.UI> transition = null;

        protected override bool isExecuting { get; set; }

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

                    text = string.Format("ROUND WINNER: {0}", scored.ScorerPID);
                    transition = new StateTransitionPrintFadeText(text, 2.0f);
                } else {
                    next = new StateDesignateServingPlayer (
                        new PlayerServer (game.PlayerOne) // todo: should be scorer
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
                transition
            );
        }
    }
}