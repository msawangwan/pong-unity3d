namespace mStateFramework {
	public interface IStateTransition {
		bool hasTriggered { get; }
		bool hasCompleted { get; }

        System.Collections.IEnumerable LoadTransition();
    }
}
