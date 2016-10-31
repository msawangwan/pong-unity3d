using System.Collections;

namespace mStateFramework {
	public abstract class StateTransition<T> : IStateTransition {
		public bool hasTriggered { get; protected set; }
		public bool hasCompleted { get; protected set; }

        public IEnumerable LoadTransition() {
            State<T>.log("started " + UnityEngine.Time.time);
            hasTriggered = true;

            IEnumerator transition = Transition().GetEnumerator();

			while (transition.MoveNext ()) {
                yield return transition.Current;
            }

            hasCompleted = true;
            State<T>.log("done " + UnityEngine.Time.time);
        }

        protected abstract IEnumerable Transition();
    }
}
