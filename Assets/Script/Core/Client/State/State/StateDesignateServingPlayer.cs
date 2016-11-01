using mGameFramework;

namespace mStateFramework {
    public class StateDesignateServingPlayer : State<Game> {
        private readonly PlayerServer serving;

        private Game game = null;

        protected override bool isExecuting { get; set; }

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
