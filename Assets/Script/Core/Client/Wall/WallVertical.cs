using UnityEngine;
using System.Collections.Generic;
using mExtensions.Common;

[RequireComponent(typeof(EdgeCollider2D))]
public class WallVertical : MonoBehaviour {
    public enum Facing { 
        None, 
        Left, 
        Right 
    }

    public static List<WallVertical> Instances = new List<WallVertical>();

    public Facing VerticalFacing               = WallVertical.Facing.None;
   
    public EdgeCollider2D EC {
        get {
            if (ec.IsNull()){
                ec = gameObject.GetComponent<EdgeCollider2D>();
            }
            return ec;
        }
    }

    public Bounds B {
        get {
            return EC.bounds;
        }
    }

    public Vector3 Orthogonal { 
        get; 
        private set; 
    }

    public float Height { 
        get { 
            return B.size.y; 
        } 
    }

    private EdgeCollider2D ec = null;

    private Vector3 CalculateOrthogonal (WallVertical.Facing facing) {
        if (facing == Facing.Left) {
            return B.Orthogonal(ExtensionBounds.ScaleBy.Height);
        } else {
            return B.Orthogonal(ExtensionBounds.ScaleBy.Height, false);
        }
    }

    private void Start () {
        if (VerticalFacing == WallVertical.Facing.None) {
            Debug.LogErrorFormat(gameObject, "{0} hasn't been assigned a facing!", gameObject.name);
        }

        Orthogonal = CalculateOrthogonal (VerticalFacing);
    }

    private void Update() {
        Debug.DrawRay(transform.position, Orthogonal * 0.1f, Color.red);
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
