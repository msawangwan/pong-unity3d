using UnityEngine;

namespace mUnityFramework.Pong {
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour {
        public enum State { None, AtRest, ToServe, InPlay }

        public Ball Balll {
            get {
                if (ball == null) {
                    ball = GetComponent<Ball>();
                }
                return ball;
            }
        }

        public Rigidbody2D RB {
            get {
                if (rb == null) {
                    rb = gameObject.GetComponentSafe<Rigidbody2D>();
                }
                return rb;
            }
        }

        public TrailRenderer TR {
            get {
                if (tr == null) {
                    tr = gameObject.GetComponentInChildren<TrailRenderer> ();
                    if (tr == null) {
                        Debug.LogErrorFormat("problem: {0} couldn't find a trail renderer in its children", gameObject.name);
                    }
                }
                return tr;
            }
        }

        public float MaxAttainableVelocity = 10.0f;

        private Ball ball = null;
        private Rigidbody2D rb = null;
        private TrailRenderer tr = null;
        private bool addImpulse = false;
        private Vector3 force = Vector3.zero;

        public State CurrentState { get; set; }
        public Player.PlayerID LastToHit { get; set; }

        public Vector3 DeriveReflectionForce (Collision2D c, WallVertical w) {
            return ((Vector3) c.relativeVelocity - (2 * Vector3.Dot (c.relativeVelocity, w.Orthogonal) * w.Orthogonal)) * -1f; // [r = e - 2(dot(e,n)) * n][e = relative velocity][n = wall normal]
        }

        public Vector3 DerivePaddleReflectionForce (Collision2D c, Paddle p) {
            return ((Vector3) c.relativeVelocity - (2 * Vector3.Dot (c.relativeVelocity, p.ColliderNormal) *  p.ColliderNormal)) * -1f; // [r = e - 2(dot(e,n)) * n][e = relative velocity][n = wall normal]
        }

        public void ApplyForce (Vector3 f, bool isImpulse = false) {
            if (isImpulse) {
                Balll.RB.AddForce (f, ForceMode2D.Impulse);
            }
        }

        public static void ResetAndPositionAt (Transform parent, Ball ball, Vector3 restPosition) {
            ball.gameObject.SetActive (false);

            ball.RB.isKinematic = true;
            ball.RB.velocity = Vector3.zero;

            ball.TR.enabled = false;
            ball.TR.Clear ();

            ball.transform.rotation = Quaternion.identity;
            ball.transform.position = restPosition;
            ball.transform.SetParent (parent);
        }
    }
}