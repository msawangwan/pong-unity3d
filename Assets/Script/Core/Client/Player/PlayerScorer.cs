using UnityEngine;

public class PlayerScorer {
    public readonly Player Scorer;
    public readonly Player.PlayerID ScorerPID;

    public int CurrentScore {
        get {
            return Scorer.PointsScored;
        }
    }

    public PlayerScorer (Player scorer) {
        Scorer = scorer;
        ScorerPID = Scorer.PID;
    }
}
