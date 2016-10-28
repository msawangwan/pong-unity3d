using UnityEngine;
using System;
using mExtensions.Enum;

namespace mStateFramework {
    public abstract class State<T> {
        public class Context {
            public readonly T Current;

            public Context(T current) {
                Current = current;
            }
        }

        public enum Stage : int {
            None = 0,
            Enter,
            Update,
            Exit
        }

        public readonly State<T>.Context StateContext;

        public State<T> Next { get; private set; }
        public State<T>.Stage CurrentStage { get; private set; }

        protected Func<int> callbackReturnInteger;
        protected Action<int> callbackTakeInteger;
        protected Action<string> log;

        public State (T currentContext) {
            StateContext = new State<T>.Context (currentContext);

            log = msg => Debug.LogFormat (
                "[STATE][INFO][{0}]: [[{1}]] [{2}]", 
                this.GetType().Name, 
                msg,
                Time.time
            );

            //Next = SetNext ();
            CurrentStage = SetInitialStage ();
        }

        protected abstract State<T> SetNext ();
        protected abstract State<T>.Stage SetInitialStage ();

        public static State<T> NullState () {
            return new StateNull (null) as State<T>;
        }

        public virtual bool Enter () {
            return true;
        }

        public virtual bool Enter (T context) {
            return true;
        }

        public virtual bool Update () {
            return true;
        }

        public virtual bool Update (T context) {
            return true;
        }

        public virtual bool Exit () {
            return true;
        }

        public virtual bool Exit (T context) {
            return true;
        }
    }
}