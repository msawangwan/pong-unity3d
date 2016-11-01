using mGameFramework;

namespace mStateFramework {
    public class StateHandleGameWin : State<Game> {
        private readonly PlayerWinner winner;

        private Game game = null;

        protected override bool isExecuting { get; set; }

        public StateHandleGameWin(PlayerWinner winner) : base () {
            this.winner = winner;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {

                // todo: track # of games won and branch if necessary
                
                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game>(
                game,
                new StateStartNewRound(),
                new StateTransitionPrintFadeText(winner.Winner.PID.ToString() + " WON", 2.0f)
            );
        }
    }
}
