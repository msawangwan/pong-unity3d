using UnityEngine;

namespace mStateFramework {
    public class StateRoundServe : StateGameplay {
        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Enter; 
            } 
        }

        private Player.PlayerID serverPID;

        public StateRoundServe (Game currentContext, Player.PlayerID serverPID) : base (currentContext) {
            this.serverPID = serverPID;
        }

        public override State<Game> Enter () {     
            Player[] players = new Player[] {
                Player.NewCopyFrom (game.PlayerOne), 
                Player.NewCopyFrom (game.PlayerTwo)
            };

            int iServer = -1;
            int iCurrentPlayer = -1;

            foreach (Player p in players) {
                p.AssignedPaddle.ChangePhaseToServe ();

                ++iCurrentPlayer;
                if (p.PID == serverPID) {
                    iServer = iCurrentPlayer;
                }
            }

            Player server = Player.NewCopyFrom (players[iServer]);
            server.AssignedPaddle.IsSetAsServing = true;
            players[iServer] = server;

            Game gameNewState = Game.CopyOf(game);

            return new StateRoundPlay (gameNewState);
        }
    }
}
