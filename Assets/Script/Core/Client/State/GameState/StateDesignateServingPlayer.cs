using mGameFramework;

namespace mStateFramework {
    public class StateDesignateServingPlayer : State<Game> {
        private readonly PlayerServer serving;
        private Game game = null;
        private bool isExecuting = true;

        protected override bool completedExecution { get; set; }

        public StateDesignateServingPlayer(PlayerServer serving) : base () {
            this.serving = serving;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                foreach (Player p in game.Players) {
                    p.AssignedPaddle.ChangePhaseToServe();
                    if (p.PID == serving.ServerPID) {
                        p.AssignedPaddle.IsSetAsServing = true;
                    }
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
                new StateWaitUntilServeComplete(serving),
                new StateTransitionPrintFadeText ("GO", 2.0f)
            );
        }
    }
}
