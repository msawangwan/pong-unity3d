﻿using UnityEngine;

namespace mStateFramework {
    public class StateStartRound : StateGameplay {
        protected override State<Game>.Stage initialStage { get { return State<Game>.Stage.Enter; } }

        public StateStartRound (Game currentContext) : base (currentContext) { }
    }
}
