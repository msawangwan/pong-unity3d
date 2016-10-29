namespace mStateFramework {
    public class StateWaitUntilPointScore : StateGame {
        public StateWaitUntilPointScore(Game context) : base(context) { }

        public override bool Update () {
            return false; // no score
        }

        public override State<Game> Exit () {
            return next;
        }
    }
}
