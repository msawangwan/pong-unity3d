namespace mStateFramework {
	public interface IState<T> {
		bool hasCompletedExecution { get; }

        System.Action<IStateContext<T>> OnRaiseStateChanged { get; set; }

        void Enter(T currentContext);
        void Execute();
    }
}