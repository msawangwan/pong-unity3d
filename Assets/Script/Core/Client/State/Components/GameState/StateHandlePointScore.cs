using mGameFramework.Core;
using mUIFramework.mvc;

namespace mStateFramework.Core {
    public class StateHandlePointScore : State<Game> {
        private readonly PlayerScorer scored;

        private Game game = null;
        private bool allocatedPoints = false;

        protected override bool isExecuting { get; set; }

        public StateHandlePointScore(PlayerScorer scored) : base () {
            this.scored = scored;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                if (!allocatedPoints) {
                    ++scored.Scorer.PointsScored;
                    allocatedPoints = true; // double-ensure this happens once
                }

                UIMasterController.Singleton.Scoreboard.UpdateScoreboardWith(
                    game.PlayerOne.PointsScored,
                    game.PlayerTwo.PointsScored,
                    UIScoreboardController.ScoreCategory.Point
                );

                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game>(
                game,
                new StateCheckForRoundWin (scored),
                null
            );
        }
    }
}