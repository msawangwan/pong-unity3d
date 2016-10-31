namespace mStateFramework {
	public class StateContext<T> : IStateContext<T>  {
        public T Context { get; private set; }
		public IState<T> NextState { get; private set; }
		public IStateTransition Transition { get; private set; }


        public StateContext (T context, IState<T> nextState, IStateTransition transition) {
            this.Context = context;
            this.NextState = nextState;
            this.Transition = transition;
        }
    }
}