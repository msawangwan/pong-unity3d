using UnityEngine;
using mGameFramework.Core;

namespace mStateFramework.Core {
    public class GameStateController : StateController<Game> {
        protected override bool debug_startOnButtonPress { get { return true; } }

        protected override StateController<Game>.Status SetStatus() {
            return StateController<Game>.Status.Loading;
        }

        protected override State<Game> LoadNew (StateController<Game>.Initialised initStatus) {
            if (initStatus == StateController<Game>.Initialised.False) {
                return new StateSpawnNewSessionInstance();
            }
            return null;
        }
    }
}