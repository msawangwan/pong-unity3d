using UnityEngine;

namespace mUnityFramework.Pong {
    public class PaddleServeController : PaddleComponent {
        public float PowerScalar = 1.0f;
        public float SteepnessValue = 2.0f;
        public float MaximumMultiplier = 0.0f;

        public Vector3 ServeForce (float multiplierPercentage = 0.0f, float steepness = 0.0f) {
            return new Vector3 (
                paddle.RB.velocity.x * (
                    PowerScalar + (
                        MaximumMultiplier * Mathf.Clamp01 (multiplierPercentage)
                        )
                    ), 
                SteepnessValue, 
                0f
            );
        }

        public bool IsOutOfBounds (float xPos) { // idea: use a fixed trigger area instead of calculating the bounds to check if player is on screen when serving
            return ((xPos - paddle.ColliderLength) <= paddle.LeftSideScreenBoundry) || 
                ((xPos + paddle.ColliderLength) >= paddle.RightSideScreenBoundry);
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

        public bool Serve (Ball ball, Vector3 momentumForce) {
            if (ball != null) {
                if (!IsOutOfBounds (paddle.transform.position.x)) {
                    ball.transform.SetParent (DynamicSceneGameObjectController.Container);
                    ball.RB.isKinematic = false;

                    Ball.SetVelocityOf (ball, momentumForce);

                    ball.TR.Clear ();
                    ball.TR.enabled = true;

                    Debug.DrawRay (transform.position, momentumForce, Color.cyan, 5.0f);

                    return true;
                }
            }
            return false;
        }
    }
}