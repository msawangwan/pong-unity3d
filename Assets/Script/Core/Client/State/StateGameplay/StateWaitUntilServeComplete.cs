namespace mStateFramework {
    public class StateWaitUntilServeComplete : StateGame {
        public StateWaitUntilServeComplete (Game context) : base (context) { }

        public override bool Update () {
            return context.PlayerOne.AssignedPaddle.IsInPlayPhase = true; // temp: hard-coded as p1
        }

        public override State<Game> Exit () {
            return new StateWaitUntilPointScore (context);
        }
    }
}
