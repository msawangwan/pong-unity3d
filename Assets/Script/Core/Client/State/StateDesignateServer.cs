namespace mStateFramework {
    public class StateDesignateServer : StateGameplay {
        protected override State<Game> nextState {
            get {
                return new StateWaitForServe (gameInServeState, serverPID);
            }
        }

        protected override State<Game>.Stage initialStage { 
            get { 
                return State<Game>.Stage.Enter; 
            } 
        }

        private Player.PlayerID serverPID;
        private Game gameInServeState = null;

        public StateDesignateServer (Game currentContext, Player.PlayerID serverPID) : base (currentContext) {
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
