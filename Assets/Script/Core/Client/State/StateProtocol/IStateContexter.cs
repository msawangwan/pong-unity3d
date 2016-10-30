namespace mStateFramework {
	public interface IStateContexter<T> {
        T Context { get; }
        bool isChangeToNext { get; }
    }
}
