using UnityEngine;
using mGameFramework.Core;

namespace mStateFramework.Core {
    public class GameStateController : StateController<Game> {
        public static GameStateController Singleton = null;

        protected override StateController<Game>.Status controllerStatus { get; set; }
        protected override bool debug_startOnButtonPress { get { return true; } }

        protected override StateController<Game>.Status SetStatus() {
            return StateController<Game>.Status.Loading;
        }

        protected override State<Game> LoadNew (StateController<Game>.Initialised initStatus) {
            if (initStatus == StateController<Game>.Initialised.False) {
                return new NewGameCreated();
            }
            return null;
        }

        private void Awake () {
            Singleton = this;
        }
    }
}