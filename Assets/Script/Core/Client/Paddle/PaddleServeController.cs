using UnityEngine;

namespace mUnityFramework.Pong {
    public class PaddleServeController : MonoBehaviour {
        private Paddle paddleCached = null;
        private Paddle paddle {
            get {
                if (paddleCached == null) {
                    paddleCached = gameObject.GetComponent<Paddle>();
                }
                return paddleCached;
            }
        }

        public Vector3 ServeForce (float powerScalar = 1.0f, float steepness = 5.0f) {
            return new Vector3 (paddle.RB.velocity.x * powerScalar, steepness, 0f);
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

        public bool IsInBounds (float xPos) {
            return 
                ((xPos - paddle.ColliderLength) <= paddle.LeftSideScreenBoundry) || 
                ((xPos + paddle.ColliderLength) >= paddle.RightSideScreenBoundry);
        }

        public bool Serve (Ball ball, Vector3 momentumForce) { // idea: use a fixed trigger area instead of calculating the bounds to check if player is on screen when serving
            if (ball != null) {
                if (IsInBounds (paddle.transform.position.x)) {
                    return false;
                } else {
                    ball.transform.SetParent (DynamicSceneGameObjectController.Container);

                    // Debug.DrawRay (transform.position, momentumForce, Color.cyan, 5.0f);

                    ball.RB.isKinematic = false;
                    ball.ApplyForce (momentumForce, true);
                    // ball.ApplyForce (momentumForce);

                    ball.TR.Clear ();
                    ball.TR.enabled = true;

                    return true;
                }
            }     
            return false;
        }
    }
}