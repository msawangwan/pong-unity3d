using UnityEngine;

namespace mStateFramework {
    public abstract class StateGameplay : State<Game> {
        protected readonly Game game;

        protected abstract State<Game> nextState { get; }
        protected abstract State<Game>.Stage initialStage { get; }

        public StateGameplay (Game currentContext) : base (currentContext) {
            if (currentContext != null) {
                // this.game = Game.CopyOf(StateContext.Current);
                this.game = currentContext;
            }

            log("Initialised: " + this.GetType().FullName);
        }

        protected override State<Game> DoNextState {
            get {
                return nextState;
            }
        }

        protected override State<Game>.Stage SetInitialStage () {
            log("Initial State Stage: " + initialStage);
            return initialStage;
        }
    }
}
