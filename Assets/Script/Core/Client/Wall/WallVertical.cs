using UnityEngine;
using System.Collections.Generic;
using mExtensions.Common;

[RequireComponent(typeof(EdgeCollider2D))]
public class WallVertical : WallSurface {
    public static List<WallVertical> Instances = new List<WallVertical>();

    public float Height { 
        get { 
            return B.size.y; 
        } 
    }

    protected override void OnEnable () {
        base.OnEnable();
        if (Instances.Contains(this) == false) {
            Instances.Add(this);
        }
    }

    protected override void OnDisable () {
        base.OnDisable();
        if (Instances.Contains(this) == true) {
            Instances.Remove(this);
        }
    }

    private void OnCollisionEnter2D (Collision2D collider) {
        Ball ball = collider.gameObject.GetComponent<Ball>();
        Vector3 reflectionForce = ball.DeriveReflectionForce (collider, this);
        ball.RB.AddForce (reflectionForce);
    }
}
