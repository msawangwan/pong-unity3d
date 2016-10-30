namespace mStateFramework {
	public interface IStateExiter {
        IStateContexter<T> Exit<T> (float t);
    }
}