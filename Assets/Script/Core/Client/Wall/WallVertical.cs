using UnityEngine;
using System.Collections.Generic;
using mExtensions.Common;

[RequireComponent(typeof(EdgeCollider2D))]
public class WallVertical : WallSurface {
    public float Height { 
        get { 
            return B.size.y; 
        } 
    }

    private void OnCollisionEnter2D (Collision2D collider) {
        Ball ball = collider.gameObject.GetComponent<Ball>();
        Vector3 reflectionForce = ball.DeriveReflectionForce (collider, this);
        ball.RB.AddForce (reflectionForce);
        Debug.LogWarningFormat("ball hit me: {0} [@t: {1}]", gameObject.name, Time.time);
    }
}
