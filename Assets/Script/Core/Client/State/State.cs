using UnityEngine;
using System;

namespace mStateFramework {
    public abstract class State<T> : IStateContinuer, IStateEnterer, IStateUpdater, IStateExiter, IStateBlocker {
        protected static Action<string> log = 
            (msg) => Debug.LogFormat("[info][state<t>] {0}", msg);

        private readonly State<T> next;

        private readonly IStateContinuer co;
        private readonly IStateEnterer en;
        private readonly IStateUpdater up;
        private readonly IStateExiter ex;
        private readonly IStateBlocker bl;

        public State (IStateContinuer co, IStateEnterer en, IStateUpdater up, IStateExiter ex, IStateBlocker bl) {
            this.co = co;
            this.en = en;
            this.up = up;
            this.ex = ex;
            this.bl = bl;
        }

        public IStateContexter<T> CanContinue<T>(float t = 0) {
            return co.CanContinue<T> (t);
        }

        public IStateContexter<T> Enter<T> (IStateContexter<T> current) 
                where T : new () {
            return en.Enter<T> (current);
        }

        public IStateContexter<T> Update<T> (float t = 0) {
            return up.Update<T> (t);
        }

        public IStateContexter<T> Exit<T> (float t = 0) {
            return ex.Exit<T> (t);
        }

        public float DetermineBlockDuration (float t = 0) {
            return bl.DetermineBlockDuration (t);
        }
    }
}