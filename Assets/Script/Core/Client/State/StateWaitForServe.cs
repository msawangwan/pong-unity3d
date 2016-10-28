namespace mStateFramework {
    public class StateWaitForServe : StateGameplay {
        protected override State<Game> nextState {
            get {
                return new StateRoundPlay (game);
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Update; 
            } 
        }

        private Player.PlayerID serverPID;

        public StateWaitForServe (Game currentContext, Player.PlayerID serverPID) : base (currentContext) {
            this.serverPID = serverPID;
        }

        public override bool Update () {
            return game.PlayerOne.AssignedPaddle.IsInPlayPhase;
        }
    }
}