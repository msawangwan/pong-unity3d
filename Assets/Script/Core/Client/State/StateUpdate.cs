﻿using UnityEngine;

namespace mStateFramework {
    public class StateUpdate : StateGameplay {
        protected override State<Game>.Stage initialStage {
            get {
                return State<Game>.Stage.Update;
            }
        }

        public StateUpdate (Game currentContext) : base (currentContext) { } 
    }
}
