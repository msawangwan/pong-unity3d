namespace mStateFramework {
    // public class StateMapPlayerToPaddle : StateGame {
    //     private readonly PlayerServer server;

    //     public StateMapPlayerToPaddle (Game context) : base (context) {
    //         server = new PlayerServer(context.PlayerOne);
    //     }

    //     public override void Enter () {
    //         foreach (Player p in context.Players) {
    //             p.AssignedPaddle.EnableOnlyIfInactive ();
    //         }
    //     }

    //     public override State<Game> Exit () {
    //         return new StateDesignateServingPlayer(context, server);
    //     }
    // }
}
