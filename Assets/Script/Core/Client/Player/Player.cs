using UnityEngine;

[System.Serializable]
public class Player {
    [System.Serializable]
    public class Details {
        public Player.PlayerID pID = Player.PlayerID.None;
        public string Name = "";
    }

	public enum PlayerID : int { 
        None = 0, 
        P1, 
        P2,
    }

    public Player.PlayerID PID { get; set; }

    public Paddle AssignedPaddle { get { return assignedPaddle; } }

    public int PointsScored {
        get {
            return pointsScored;
        }
        set {
            pointsScored = value;
        }
    }

    public int RoundsWon {
        get {
            return roundsWon;
        }
        set {
            roundsWon = value;
        }
    }

    [SerializeField]
    private Player.Details PlayerDetails;
    private Paddle assignedPaddle = null;
    private int pointsScored = 0;
    private int roundsWon = 0;

    public Player () { }

    public Player (Player.PlayerID pid, int points = 0, int wins = 0) {
        PID = pid;
        pointsScored = points;
        roundsWon = wins;
    }

    public static Player NewFrom (Player p) {
        return new Player (p.PID, p.PointsScored, p.RoundsWon);
    }

    public static Player Add1Score (Player p) {
        return new Player (p.PID, (p.PointsScored + 1), p.RoundsWon);
    }

    public static Player Add1RoundWin (Player p) {
        return new Player (p.PID, p.PointsScored, (p.RoundsWon + 1));
    }

    public void AssignPaddle () {
        foreach (Paddle paddle in Paddle.Instances) {
            if ((int) paddle.Parameters.PID == (int) this.PID) {
                Debug.LogFormat("Assigned player {0} to paddle {1}", this.PID, paddle.Parameters.PID);
                assignedPaddle = paddle;
                assignedPaddle.AssignedPlayer = this.PID;
            }
        }
    }
}