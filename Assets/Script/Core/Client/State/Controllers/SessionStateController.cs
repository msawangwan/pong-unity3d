using UnityEngine;
using mGameFramework.Core;

namespace mStateFramework.Core {
    public class SessionStateController : StateController<Session> {
        protected override bool debug_startOnButtonPress { get { return false; } }

        protected override StateController<Session>.Status SetStatus() {
            return StateController<Session>.Status.Loading;
        }

        protected override State<Session> LoadNew (StateController<Session>.Initialised initStatus) {
            if (initStatus == StateController<Session>.Initialised.False) {
                return new LoadSessionInstance();
            }
            return null;
        }
    }
}