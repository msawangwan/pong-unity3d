using UnityEngine;

namespace mStateFramework {
    public class StateRoundOnScore : State<Game> {
        private readonly Player.PlayerID scorerPID;

        public StateRoundOnScore (Game currentContext, Player.PlayerID scorerPID) : base (currentContext) { }

        protected override State<Game>.Stage SetInitialStage () {
            return State<Game>.Stage.Exit;
        }

        public override State<Game> Exit () {
            Player[] players = new Player[] { 
                Player.NewCopyFrom (StateContext.Current.PlayerOne), 
                Player.NewCopyFrom (StateContext.Current.PlayerTwo) 
            };

            int iCurrentPlayer = -1;
            int iScorer = -1;

            foreach (Player p in players) {
                ++iCurrentPlayer;
                if (p.PID == scorerPID) {
                    iScorer = iCurrentPlayer;
                    break;
                }
            }

            Player scored = Player.NewCopyFrom (players[iScorer]);
            players[iScorer] = Player.Add1Score (scored);

            return null;
        }        
    }
}