using UnityEngine;

public class PaddleCPU : Paddle {
    [RangeAttribute(0.0f, 1.0f)]
    public float AIResponseTimeMultiplier = 1.0f;

    private float xComponentBallPosition = 0.0f;
    private float updateIntervalInSeconds = 1.2f;
    private float lastUpdateTimestamp = 0.0f;

    private float interval { get { return updateIntervalInSeconds * AIResponseTimeMultiplier; } }

    protected override bool ServeBall () {
        return false;
    }

    protected override Vector3 CalculateHorizontalMoveForce (float paddleMoveSpeed) {
        if (ball == null) {
                ball = BallManager.StaticInstance.CurrentBall;
            if (ball == null) {
                return Vector3.zero;
            }
        }

        xComponentBallPosition = ball.transform.position.x;

        if (Time.time > lastUpdateTimestamp) {
            lastUpdateTimestamp = Time.time + interval;

            if (xComponentBallPosition > transform.position.x) {
                return Vector3.right * paddleMoveSpeed;
            }

            if (xComponentBallPosition < transform.position.x) {
                return Vector3.left * paddleMoveSpeed;
            }
        }

        return Vector3.zero;
    }
}