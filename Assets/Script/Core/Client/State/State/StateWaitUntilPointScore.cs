using mGameFramework;
using mExtensions.Common;

namespace mStateFramework {
    public class StateWaitUntilPointScore : State<Game> {
        public static System.Func<Player.PlayerID> onScore { get; set; } // idea: make a static method of type 'player'

        private PlayerScorer scorer = null;
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

                Player.PlayerID scorerPID  = onScore ();
                PlayerQuery query = new PlayerQuery (
                    game.Players,
                    scorerPID
                );

                scorer = Player.ExtractScoringPlayer(query);

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
