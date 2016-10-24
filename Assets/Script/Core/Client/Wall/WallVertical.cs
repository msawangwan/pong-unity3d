using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(EdgeCollider2D))]
public class WallVertical : MonoBehaviour {
    public enum Handedness { None, Left, Right }

    public static List<WallVertical> Instances = new List<WallVertical>();

    public Vector3 Normal { get { return normal; } }

    public Handedness ScreenEdge = WallVertical.Handedness.None; // should set in inspector rather than Start ()?

    private float xComponentTransform = 0.0f;
    private Vector3 normal = Vector3.zero;

    private float height { get { return Camera.main.orthographicSize * 2f; } }

    private void DetermineLeftOrRightHandedness () {
        xComponentTransform = transform.position.x;
        if (xComponentTransform > 0) {
            normal = transform.position.FindNormal2DLeftHand();
            ScreenEdge = Handedness.Right;
        } else {
            normal = transform.position.FindNormal2DRightHand();
            ScreenEdge = Handedness.Left;
        }
    }

    private void Start () {
        xComponentTransform = transform.position.x;
        if (xComponentTransform > 0) {
            normal = transform.position.FindNormal2DLeftHand();
            ScreenEdge = Handedness.Right;
        } else {
            normal = transform.position.FindNormal2DRightHand();
            ScreenEdge = Handedness.Left;
        }
    }

    private void OnEnable () {
        if (Instances.Contains(this) == false) {
            Instances.Add(this);
        }
    }

    private void OnDisable () {
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
