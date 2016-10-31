using UnityEngine;
using System.Collections.Generic;
using mExtensions.Common;

public class PlayerQuery {
    public IEnumerable<Player> Players { 
        get {
            if (players.IsNull()) {
                return playersEnumerable;
            }
            return players; 
        }
    }

    public readonly Player.PlayerID QueryTargetPID;

    private readonly Player[] players;
    private readonly IEnumerable<Player> playersEnumerable;

    public PlayerQuery (Player[] players, Player.PlayerID queryTargetPID) {
        this.players = players;
        this.QueryTargetPID = queryTargetPID;
    }

    public PlayerQuery (IEnumerable<Player> players, Player.PlayerID queryTargetPID) {
        this.playersEnumerable = players;
        this.QueryTargetPID = queryTargetPID;
    }
}
