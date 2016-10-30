using mGameFramework;

namespace mStateFramework {
    public class StateGame : State<Game> {
        public StateGame(IStateContinuer co, IStateEnterer en, IStateUpdater up, IStateExiter ex, IStateBlocker bl) 
            : base (co, en, up, ex, bl) {} 
    }
}
