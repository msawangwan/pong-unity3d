using UnityEngine;

public class PlayerWinner {
    public enum Type {
        None = 0,
        Round,
        Game,
    }

    public readonly Player Winner;
    public readonly PlayerWinner.Type WinnerType;

    public PlayerWinner (Player winner, PlayerWinner.Type winnerType) {
        this.Winner = winner;
        this.WinnerType = winnerType;
    }
}
