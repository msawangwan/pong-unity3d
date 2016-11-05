using mGameFramework.Core;

namespace mStateFramework.Core {
    public class HandleCreateNewGame : State<Session> {
        private Session session = null;

        protected override bool isExecuting { get; set; }

        public override void Enter (Session context) {
            this.session = context;
        }

        public override void Execute () {
            if (isExecuting) {
                session.NewGame();
                GameStateController.Singleton.BeginStartController(null);
                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Session> InitialiseNewContext () {
            return new StateContext<Session> (
                session,
                new HandleGameInPlay(),
                null
            );
        }
    }
}