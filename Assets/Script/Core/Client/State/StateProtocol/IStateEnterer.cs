namespace mStateFramework {
	public interface IStateEnterer {
		IStateContexter<T> Enter<T> (IStateContexter<T> current) where T : new();
	}
}
