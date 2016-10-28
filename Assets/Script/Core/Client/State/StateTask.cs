using UnityEngine;
using System.Collections;

namespace mStateFramework {
    public class StateTask {
        public readonly IEnumerator Task;
        public StateTask Next;
        public StateScheduler Scheduler;
        public int Data;

        public StateTask (IEnumerator task, StateScheduler scheduler) {
            this.Task = task;
            this.Scheduler = scheduler;
        }
    }
}
