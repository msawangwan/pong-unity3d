using mGameFramework;
using mUIFramework.mvc;

namespace mStateFramework {
    public class StateStartNewRound : State<Game> {
        protected override bool isExecuting { get; set; }

        private string text = string.Empty;
        private Game game = null;

        public override void Enter (Game context) {
            game = context;
        }
    
        public override void Execute () {
            if (isExecuting) {
                text = string.Format("LETS BEGIN");

                UIMasterController.Singleton.Scoreboard.UpdateScoreboardWith ( // todo: create a 'new game' state
                    0, 0, UIScoreboardController.ScoreCategory.Point
                );

                UIMasterController.Singleton.Scoreboard.ToggleScoreboard (
                    true
                );

                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game> (
                game,
                new StateMapPlayerToPaddle (),
                new StateTransitionPrintFadeText (text, 2.0f)
            );
        }
    }
}
