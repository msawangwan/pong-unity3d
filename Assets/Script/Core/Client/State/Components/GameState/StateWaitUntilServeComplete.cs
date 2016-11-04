using mGameFramework.Core;
using mExtensions.Common;

namespace mStateFramework.Core {
    public class StateWaitUntilServeComplete : State<Game> {
        private readonly PlayerServer served;

        private Game game = null;

        protected override bool isExecuting { get; set; }

        public StateWaitUntilServeComplete (PlayerServer served) : base () {
            this.served = served;
        }

        public override void Enter (Game context) {
            game = context;
        }

        public override void Execute () {
            if (isExecuting) {
                isExecuting = !served.Server.AssignedPaddle.HasServed;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game> (
                game, 
                new StateWaitUntilPointScore(), 
                null
            );
        }
    }
}
