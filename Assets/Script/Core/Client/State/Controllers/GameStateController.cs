using UnityEngine;
using mGameFramework.Core;

namespace mStateFramework.Core {
    public class GameStateController : StateController<Game> {
        protected override State<Game> LoadNew (StateController<Game>.Initialised initStatus) {
            if (initStatus == StateController<Game>.Initialised.False) {
                return new StateSpawnNewSessionInstance();
            }
            return null;
        }
    }
}
