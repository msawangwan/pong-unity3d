namespace mStateFramework {
    public class StateWaitUntilPointScore : StateGame {
        public static System.Func<Player.PlayerID> onScore { get; set; }
        private Player.PlayerID scorer = Player.PlayerID.None;

        public StateWaitUntilPointScore(Game context) : base(context) { }

        public override bool Update () {
            if (onScore == null) {
                return false;
            }

            scorer = onScore ();
            onScore = null;
            return true;
        }

        public override State<Game> Exit () {
            return new StateHandlePointScore (context, scorer);
        }
    }
}
