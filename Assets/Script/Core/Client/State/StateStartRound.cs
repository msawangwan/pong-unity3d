using UnityEngine;

namespace mStateFramework {
    public class StateStartRound : State<Game> {
        private readonly Player.PlayerID serverPID;

        public StateStartRound (Game currentContext, Player.PlayerID serverPID) : base (currentContext) {
            this.serverPID = serverPID;
        }

        protected override State<Game>.Stage SetStage () {
            return State<Game>.Stage.Enter;
        }

        public override State<Game> Enter () {
            Game game = Game.CopyOf (StateContext.Current);

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

            game = new Game(players); // todo: needs copyTo overload
            return null;
        }
    }
}
