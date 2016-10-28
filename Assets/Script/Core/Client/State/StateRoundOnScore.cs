using UnityEngine;

namespace mStateFramework {
    public class StateRoundOnScore : StateGameplay {
        protected override State<Game> nextState {
            get {
                return null;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get {
                return State<Game>.Stage.None;
            }
        }

        private readonly Player.PlayerID scorerPID;

        public StateRoundOnScore (Game currentContext, Player.PlayerID scorerPID) : base (currentContext) { }


        public override bool Exit () {
            // Player[] players = new Player[] { 
            //     Player.NewCopyFrom (StateContext.Current.PlayerOne), 
            //     Player.NewCopyFrom (StateContext.Current.PlayerTwo) 
            // };

            // int iCurrentPlayer = -1;
            // int iScorer = -1;

            // foreach (Player p in players) {
            //     ++iCurrentPlayer;
            //     if (p.PID == scorerPID) {
            //         iScorer = iCurrentPlayer;
            //         break;
            //     }
            // }

            // Player scored = Player.NewCopyFrom (players[iScorer]);
            // players[iScorer] = Player.Add1Score (scored);

            return false;
        }        
    }
}