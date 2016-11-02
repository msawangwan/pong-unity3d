using mExtensions.Common;
using mGameFramework.Core;

namespace mStateFramework.Core {
    public class LoadSessionInstance : State<Session> {
        private Session session = null;
        // private Game game = null;

        protected override bool isExecuting { get; set; }

        public LoadSessionInstance () : base () { 
            if (session.IsNull()) {
                session = SessionController.SpawnNew ();
                if (!session.IsValid) {
                    log("invalid session");
                }
            }
        }

        public LoadSessionInstance (Session session) : base () {
            this.session = session;
        }

        public override void Enter (Session context) {
            // game = new Game ();
        }

        public override void Execute () {
            if (isExecuting) {
                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Session> InitialiseNewContext () {
            return new StateContext<Session> (
                null,
                null,
                null
            );
        }
    }
}