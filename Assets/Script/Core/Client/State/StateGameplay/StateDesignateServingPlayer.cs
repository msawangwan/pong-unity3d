namespace mStateFramework {
    public class StateDesignateServingPlayer: StateGame {
        private readonly Player.PlayerID serverPID;

        public StateDesignateServingPlayer(Game context, PlayerServer serving) : base (context) {
            this.serverPID = serving.ServerPID;
        }

        public override void Enter () {
            foreach (Player p in context.Players) {
                p.AssignedPaddle.ChangePhaseToServe();
                if (p.PID == serverPID) {
                    p.AssignedPaddle.IsSetAsServing = true;
                }
            }
        }

        public override State<Game> Exit () {
            return new StateWaitUntilServeComplete (context);
        }
    }
}
