using UnityEngine;
using System;

namespace mStateFramework {
    public abstract class State<T> {
        protected static Action<string> log = (msg) => Debug.LogFormat("[info][state<T>] {0}", msg);
        private readonly State<T> next;

        public State () { }

        public State (State<T> next) {
            this.next = next;
        }

        public virtual void Enter () {
            return;
        }

        public virtual bool Update () {
            return true;
        }

        public virtual State<T> Exit () {
            return next;
        }
    }
}