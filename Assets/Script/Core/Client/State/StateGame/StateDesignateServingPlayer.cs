namespace mStateFramework {
    // public class StateDesignateServingPlayer: StateGame {
    //     private readonly PlayerServer serving;

    //     public StateDesignateServingPlayer(Game context, PlayerServer serving) : base (context) {
    //         this.serving = serving;
    //     }

    //     public override void Enter () {
    //         foreach (Player p in context.Players) {
    //             p.AssignedPaddle.ChangePhaseToServe();
    //             if (p.PID == serving.ServerPID) {
    //                 p.AssignedPaddle.IsSetAsServing = true;
    //             }
    //         }
    //     }

    //     public override State<Game> Exit () {
    //         return new StateWaitUntilServeComplete (context, serving);
    //     }
    // }
}
