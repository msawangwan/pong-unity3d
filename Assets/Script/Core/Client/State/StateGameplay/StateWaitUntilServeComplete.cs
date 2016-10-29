namespace mStateFramework {
    public class StateWaitUntilServeComplete : StateGame {
        private readonly PlayerServer served;

        public StateWaitUntilServeComplete (Game context, PlayerServer served) : base (context) {
            this.served = served;
        }

        public override bool Update () {
            return served.Server.AssignedPaddle.IsInPlayPhase = true; // temp: hard-coded as p1
        }

        public override State<Game> Exit () {
            return new StateWaitUntilPointScore (context);
        }
    }
}
