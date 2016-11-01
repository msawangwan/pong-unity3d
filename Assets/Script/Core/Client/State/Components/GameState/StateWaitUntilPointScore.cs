using mGameFramework.Core;
using mExtensions.Common;

namespace mStateFramework.Core {
    public class StateWaitUntilPointScore : State<Game> {
        public static System.Func<Player.PlayerID> onScore { get; set; } // idea: make a static method of type 'player' or use a mediator

        private string text = string.Empty;
        private PlayerScorer scorer = null;
        private Game game = null;

        protected override bool isExecuting { get; set; }

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

                scorer = Player.ExtractScoringPlayer (query);
                text = string.Format("POINT: {0}", scorer.ScorerPID);

                onScore = null;
                isExecuting = false;

                return;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game>(
                game,
                new StateHandlePointScore (scorer),
                new StateTransitionPrintFadeText (text, 2.0f)
            );
        }
    }
}
