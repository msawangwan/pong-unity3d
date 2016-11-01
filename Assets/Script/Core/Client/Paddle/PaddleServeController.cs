using UnityEngine;

public class PaddleServeController : MonoBehaviour {
    private Paddle paddle = null;
    private Paddle paddleCached {
        get {
            if (paddle == null) {
                paddle = gameObject.GetComponent<Paddle>();
            }
            return paddle;
        }
    }

    public Vector3 CalculateServiceForce (Paddle server, float serveForceMultiplier = 300.0f, float maxServeForce = 50.0f) { // paddleForceInfluence = input x
        Vector3 lateralMoveForce = server.RB.velocity.Truncate(maxServeForce);
        return new Vector3(lateralMoveForce.x, serveForceMultiplier, 0.0f);
    }

    public bool SetForService (Paddle server, Ball ball, float offset = 0.3f) {
        if (ball != null) {
            Vector3 ballPosition = server.transform.position + new Vector3 (0.0f, offset, 0.0f);
            Ball.ResetAndPositionAt (transform, ball, ballPosition);
            ball.gameObject.SetActive (true);
            return true;
        }
        return false;
    }

    public bool Serve (Ball ball, Vector3 serveForce) { // idea: use a fixed trigger area instead of calculating the bounds to check if player is on screen when serving
        if (ball != null) {
            if (ball.RB != null) {
                float xPos = paddleCached.transform.position.x;

                bool leftSideScreenCheck = ((xPos - paddleCached.ColliderLength) <= paddleCached.LeftSideScreenBoundry);
                bool rightSideScreenCheck = ((xPos + paddleCached.ColliderLength) >= paddleCached.RightSideScreenBoundry);

                if (leftSideScreenCheck || rightSideScreenCheck) {
                    return false;
                } else {
                    ball.transform.SetParent (DynamicSceneGameObjectController.Container);

                    ball.RB.isKinematic = false;
                    ball.RB.AddForce(serveForce);

                    ball.TR.Clear ();
                    ball.TR.enabled = true;

                    return true;
                }
            }
        }     
        return false;
    }
}