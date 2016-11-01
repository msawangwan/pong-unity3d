using mExtensions.Common;
using mGameFramework.Core;
using mUIFramework.mvc;

namespace mStateFramework.Core {
	public class StateSpawnNewSessionInstance : State<Game> {
        private Session session = null;
        private Game game = null;

        protected override bool isExecuting { get; set; }

        public StateSpawnNewSessionInstance () : base () { 
            if (session.IsNull()) {
                session = SessionController.SpawnNew ();
                if (!session.IsValid) {
                    log("invalid session");
                }
            }
        }

        public StateSpawnNewSessionInstance (Session session) : base () {
            this.session = session;
        }

        public override void Enter (Game context) {
            game = new Game ();
        }

        public override void Execute () {
            if (isExecuting) {
                isExecuting = false;
            } else {
                OnChangeState ();
            }
        }

        protected override StateContext<Game> InitialiseNewContext () {
            return new StateContext<Game> (
                game,
                new StateStartNewRound (),
                null
            );
        }
    }
}
