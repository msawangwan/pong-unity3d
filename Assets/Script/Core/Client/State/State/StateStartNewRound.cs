using mGameFramework;
using mUIFramework.mvc;

namespace mStateFramework {
    public class StateStartNewRound : State<Game> {
        protected override bool isExecuting { get; set; }
        private Game game = null;

        public StateStartNewRound () : base () { }

        public override void Enter (Game context) {
            game = context;
        }
    
        public override void Execute () {
            if (isExecuting) {
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
                null
            );
        }
    }
}
