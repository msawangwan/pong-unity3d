namespace mStateFramework {
	public class StateContext<T> : IStateContexter<T> {
		public T Context { get; private set; }
		public bool isChangeToNext { get; private set; }

        public StateContext (T context, bool isChangeToNext) {
            this.Context = context;
            this.isChangeToNext = isChangeToNext;
        }
    }
}
