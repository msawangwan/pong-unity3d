using UnityEngine;

namespace mUnityFramework.Pong {
    public class PaddleStrikeController : PaddleComponent {
        void OnCollisionEnter2D (Collision2D c) {
            Ball ball = c.gameObject.GetComponent<Ball>();

            if (ball != null) {
                Vector3 vUpdated = Ball.SetVelocityOf (
                    ball, 
                    ball.DeriveReflectionForce (c, paddle.ColliderOrthogonal)
                );

                ball.LastToHit = paddle.AssignedPlayer; // <- handle in ball class?
                Debug.DrawRay(paddle.transform.position, vUpdated, Color.green, 3.0f);
            }
        }
    }
}
