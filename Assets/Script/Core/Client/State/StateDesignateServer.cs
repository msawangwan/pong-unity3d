using mExtensions.Common;

namespace mStateFramework {
    public class StateDesignateServer : StateGameplay {
        protected override State<Game> nextState {
            get {
                if (next.IsNull()) {
                    next = new StateWaitForServe (gameInServeState, serverPID);
                }
                return next;
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Enter; 
            } 
        }

        private State<Game> next = null;

        private Player.PlayerID serverPID;
        private Game gameInServeState = null;

        public StateDesignateServer (Game context, Player.PlayerID serverPID) : base (context) {
            this.serverPID = serverPID;
        }

        public override bool Enter () {
            Player[] players = new Player[] {
                Player.NewCopyFrom (game.PlayerOne), 
                Player.NewCopyFrom (game.PlayerTwo)
            };

            int iServer = -1;
            int iCurrentPlayer = -1;

            foreach (Player p in game.Players) {
                ++iCurrentPlayer;

                p.AssignedPaddle.ChangePhaseToServe ();
                if (p.PID == serverPID) {
                    iServer = iCurrentPlayer;
                }
            }

            Player server = Player.NewCopyFrom (players[iServer]);
            server.AssignedPaddle.IsSetAsServing = true;
            players[iServer] = server;

            gameInServeState = Game.CopyOf(game);

            return true;
        }
    }
}
