using mGameFramework;

namespace mStateFramework {
    public class StateHandlePointScore : State<Game> {
        private readonly Player.PlayerID scored; // todo: change to type
        private Game game = null;
        private bool isExecuting = true;

        protected override bool completedExecution { get; set; }

        public StateHandlePointScore(Player.PlayerID scored) : base () {
            this.scored = scored;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                foreach (Player p in game.Players) {
                    if (p.PID == scored) {
                        ++p.PointsScored;
                    }
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
                new StateDesignateServingPlayer (
                    new PlayerServer (game.PlayerOne)
                ),
                null
            );
        }
    }
}
