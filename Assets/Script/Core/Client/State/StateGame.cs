namespace mStateFramework {
    public class StateGame : State<Game> {
        protected readonly Game context;

        public StateGame (Game context) : base() {
            log("new instance of state: " + this.GetType().Name);
            this.context = context;
        }
    }
}
