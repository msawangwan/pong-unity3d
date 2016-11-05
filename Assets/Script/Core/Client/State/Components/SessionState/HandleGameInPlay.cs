using UnityEngine;
using mGameFramework.Core;

namespace mStateFramework.Core {
    public class HandleGameInPlay : State<Session> {
        private Session session = null;

        protected override bool isExecuting { get; set; }

        public override void Enter (Session context) {
            this.session = context;
        }

        public override void Execute () {
            if (isExecuting) {

                // isExecuting = false;
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