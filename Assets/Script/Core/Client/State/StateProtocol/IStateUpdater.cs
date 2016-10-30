namespace mStateFramework {
	public interface IStateUpdater {
        IStateContexter<T> Update<T> (float t);
    }
}