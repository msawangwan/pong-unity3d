namespace mStateFramework {
		public interface IStateContext<T> {
				T Context { get; }
				IState<T> NextState { get; }
				IStateTransition Transition { get; }
  	}
}