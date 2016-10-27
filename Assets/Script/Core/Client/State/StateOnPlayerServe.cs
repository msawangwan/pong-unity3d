using UnityEngine;

namespace mStateFramework {
    public class StateOnPlayerServe : StateGameplay {
        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Update; 
            } 
        }

        private Player.PlayerID serverPID;

        public StateOnPlayerServe (Game currentContext, Player.PlayerID serverPID) : base (currentContext) {
            this.serverPID = serverPID;
        }

    }
}
