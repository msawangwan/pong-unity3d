namespace mStateFramework {
    public class StateWaitForServe : StateGameplay {
        protected override State<Game> nextState {
            get {
                if (nnnnn == null) {
                    nnnnn = new StateRoundPlay(game);
                }
                return nnnnn;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Update; 
            } 
        }

        private State<Game> nnnnn = null;

        private Player.PlayerID serverPID;

        public StateWaitForServe (Game context, Player.PlayerID serverPID) : base (context) {
            this.serverPID = serverPID;
        }

        public override bool Update () {
            return game.PlayerOne.AssignedPaddle.IsInPlayPhase;
        }
    }
}