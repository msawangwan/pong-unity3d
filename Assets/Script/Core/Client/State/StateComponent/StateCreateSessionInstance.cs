using mGameFramework;

namespace mStateFramework {
	public class StateCreateSessionInstance : IStateEnterer  {
        public IStateContexter<Game> Enter<Game> (IStateContexter<Game> current) where Game : new () {
            return new StateContext<Game>(new Game(), true);
        }
	}
}