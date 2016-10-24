using UnityEngine;

public class PaddleServeController : MonoBehaviour {
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

    public bool Serve (Ball ball, Vector3 serveForce) { // TODO: IMPORTANT TO VERIFY WE DO NOT SERVE OFF SCREEN!!!
        if (ball != null) {
            Rigidbody2D rb = ball.RB;
            if (rb != null) {
                ball.transform.SetParent (DynamicSceneGameObjectController.Container);

                rb.isKinematic = false;
                rb.AddForce(serveForce);

                return true;
            }
        }     
        return false;
    }
}
