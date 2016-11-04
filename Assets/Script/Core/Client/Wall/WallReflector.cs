using UnityEngine;
using mUnityFramework.Pong;

public class WallReflector : WallSurface {
    private void OnCollisionEnter2D (Collision2D c) {
        Ball ball = c.gameObject.GetComponent<Ball>();

        if (ball != null) {
            Vector3 vUpdated = Ball.SetVelocityOf (
                ball, 
                ball.DeriveReflectionForce (c, Orthogonal)
            );

            Debug.DrawRay(c.transform.position, vUpdated, Color.red, 1.5f);
        }
    }
}