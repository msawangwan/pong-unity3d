using System.Collections;

namespace mStateFramework.Core {
	public abstract class StateTransition<T> : IStateTransition {
		public bool hasTriggered { get; protected set; }
		public bool hasCompleted { get; protected set; }

        public IEnumerable LoadTransition() {
            hasTriggered = true;

            IEnumerator transition = Transition().GetEnumerator();

			while (transition.MoveNext ()) {
                yield return transition.Current;
            }

            hasCompleted = true;
        }

        protected abstract IEnumerable Transition();
    }
}