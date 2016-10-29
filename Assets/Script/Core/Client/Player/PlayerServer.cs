using UnityEngine;

public class PlayerServer {
    public readonly Player Server;
    public Player.PlayerID ServerPID { get { return Server.PID; } }

    public PlayerServer(Player server) {
        Server = server;
    }
}
