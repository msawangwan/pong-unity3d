using UnityEngine;

public class WallVertical : WallSurface {
    private void OnCollisionEnter2D (Collision2D collider) {
        Ball ball = collider.gameObject.GetComponent<Ball>();
        Vector3 reflectionForce = ball.DeriveReflectionForce (collider, this);
        ball.RB.AddForce (reflectionForce);
        Debug.LogWarningFormat(gameObject, "wall hit: {0} [@t: {1}]", gameObject.name, Time.time);
    }
}
