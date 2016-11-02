using UnityEngine;

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

    private Ball ball = null;
    private Rigidbody2D rb = null;
    private TrailRenderer tr = null;

    public State CurrentState { get; set; }
    public Player.PlayerID LastToHit { get; set; }

    public Vector3 DeriveReflectionForce (Collision2D c, WallVertical w) {
        return -2 * Vector3.Dot (c.relativeVelocity, w.Orthogonal) * w.Orthogonal; // [r = e - 2(dot(e,n)) * n][e = relative velocity][n = wall normal]
    }

    public Vector3 DerivePaddleReflectionForce (Collision2D c, Paddle p) {
        return -2 * Vector3.Dot (c.relativeVelocity, p.ColliderNormal) *  p.ColliderNormal; // [r = e - 2(dot(e,n)) * n][e = relative velocity][n = wall normal]
    }

    public Vector3 CalculateEnglish (Player.PlayerID strikingPlayer, Vector3 ballPosition, Vector3 paddlePosition, float paddleLength, float ballSpeed = 4.0f) {
        float x = (ballPosition.x - paddlePosition.x) / paddleLength; // normalize
        Vector3 englishApplied = new Vector3 (x, 1f, 0f);
        if (strikingPlayer == Player.PlayerID.P2) {
            englishApplied.y = -1f;
        }
        return englishApplied.normalized * ballSpeed;
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