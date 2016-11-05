using mExtensions.Common;
using mGameFramework.Core;

namespace mStateFramework.Core {
    public class HandleGameComplete : State<Session> {
        private Session session = null;

        protected override bool isExecuting { get; set; }

        public override void Enter (Session context) {

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
