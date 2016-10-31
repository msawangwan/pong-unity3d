using mGameFramework;
using mExtensions.Common;

namespace mStateFramework {
    public class StateWaitUntilPointScore : State<Game> {
        public static System.Func<Player.PlayerID> onScore { get; set; }
        private Player.PlayerID scorer = Player.PlayerID.None;
        private bool isExecuting = true;
        private Game game;

        protected override bool completedExecution { get; set; }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                if (onScore.IsNull()) {
                    return;
                }

                scorer = onScore ();

                onScore = null;
                isExecuting = false;

                return;
            } else {
                OnChangeState ();
                completedExecution = true;
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game>(
                game,
                new StateHandlePointScore (scorer),
                new StateTransitionPrintFadeText ("SCORE", 2.0f)
            );
        }
    }
}
