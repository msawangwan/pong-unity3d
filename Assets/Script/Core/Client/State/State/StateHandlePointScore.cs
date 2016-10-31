using mGameFramework;

namespace mStateFramework {
    public class StateHandlePointScore : State<Game> {
        private readonly PlayerScorer scored;
        private Game game = null;
        private bool isExecuting = true;
        private bool allocatedPoints = false;

        protected override bool completedExecution { get; set; }

        public StateHandlePointScore(PlayerScorer scored) : base () {
            this.scored = scored;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                if (!allocatedPoints) {
                    allocatedPoints = true; // double-ensure this happens once
                    ++scored.Scorer.PointsScored;
                }

                UIMasterCanvasController.SingletonInstance.UpdateScore (
                    game.PlayerOne.PointsScored,
                    game.PlayerTwo.PointsScored
                );

                isExecuting = false;
            } else {
                OnChangeState ();
                completedExecution = true;
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
