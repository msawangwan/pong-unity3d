namespace mStateFramework {
	public interface IStateContinuer {
		IStateContexter<T> CanContinue<T> (float t);
	}
}