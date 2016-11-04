using UnityEngine;

namespace mUnityFramework.Pong {
    public class PaddleStrikeController : PaddleComponent {
        private Player.PlayerID player = Player.PlayerID.None;

        void OnCollisionEnter2D (Collision2D c) {
            Ball ball = c.gameObject.GetComponent<Ball>();

            if (ball != null) {
                player = paddle.AssignedPlayer;
                Vector3 f = ball.DerivePaddleReflectionForce(c, paddle);

                ball.ApplyForce(f);
                ball.LastToHit = player;

                Debug.DrawRay(paddle.transform.position, f, Color.red, 3.0f);
            }
        }
    }
}
