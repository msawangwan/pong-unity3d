using UnityEngine;
using System.Collections;

public class StateGameSetup : State {
    public StateGameSetup (StateContext<Game> context) : base (context) {}

    protected override State UpdateState () {
        Player[] players = new Player[2];
        int i = -1;
        foreach (Player p in Context.Context.Players) {
            i++;
            players[i] = Player.NewCopyFrom(p);
            players[i].AssignedPaddle.EnableOnlyIfInactive ();
            Debug.Log("PPPSDA");
        }

        Game game = new Game(players);
        return null;
    }
}
