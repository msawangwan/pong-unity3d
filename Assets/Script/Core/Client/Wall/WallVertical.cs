using UnityEngine;
using mUnityFramework.Pong;

public class WallVertical : WallSurface {
    private void OnCollisionEnter2D (Collision2D collider) {
        // RaycastHit2D hit = Physics2D.Raycast(collider.transform.position);
        Ball ball = collider.gameObject.GetComponent<Ball>();
        Vector3 reflectionForce = ball.DeriveReflectionForce (collider, this);
        ball.RB.velocity = reflectionForce;
        // ball.ApplyForce(reflectionForce);

        Debug.DrawRay(collider.transform.position, reflectionForce, Color.red, 3.0f);
    }
}