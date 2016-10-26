using UnityEngine;

namespace mStateFramework {
    public class StateStartRound : State<Game> {
        private readonly Player.PlayerID serverPID;

        // public StateStartRound (Player.PlayerID serverPID) : base () {
        //     this.serverPID = serverPID;
        // }

        protected override State<Game>.Stage SetStage () {
            return State<Game>.Stage.Enter;
        }

        // protected override State Enter () {
        //     int serverPlayerIDIndex = -1;
        //     int currentPlayerIDIndex = -1;

        //     foreach (Player p in GameWithUpdatedState.Players) {
        //         p.AssignedPaddle.ChangePhaseToServe ();

        //         ++currentPlayerIDIndex;

        //         if (p.PID == serverPID) {
        //             serverPlayerIDIndex = currentPlayerIDIndex;
        //         }
        //     }

        //     Player[] playersWithServerSet = new Player[] { 
        //         GameWithUpdatedState.PlayerOne, 
        //         GameWithUpdatedState.PlayerTwo 
        //     };

        // }
    }
}
