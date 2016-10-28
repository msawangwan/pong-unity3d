namespace mStateFramework {
    public class StateWaitForServe : StateGameplay {
        protected override State<Game> nextState {
            get {
                return nnnnn;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Update; 
            } 
        }

        private readonly State<Game> nnnnn = null;

        private Player.PlayerID serverPID;

        public StateWaitForServe (Game currentContext, Player.PlayerID serverPID) : base (currentContext) {
            this.serverPID = serverPID;
            nnnnn = new StateRoundPlay(game);
        }

        public override bool Update () {
            return game.PlayerOne.AssignedPaddle.IsInPlayPhase;
        }
    }
}