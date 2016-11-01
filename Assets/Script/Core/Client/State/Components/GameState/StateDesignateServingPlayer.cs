using mGameFramework.Core;

namespace mStateFramework.Core {
    public class StateDesignateServingPlayer : State<Game> {
        private readonly PlayerServer serving;

        private string text = string.Empty;
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
                        text = string.Format("SERVER: {0}", serving.ServerPID);
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
                new StateTransitionPrintFadeText (text, 2.0f)
            );
        }
    }
}
