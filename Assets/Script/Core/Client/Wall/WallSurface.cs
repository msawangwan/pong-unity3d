using UnityEngine;
using System.Collections.Generic;
using mExtensions.Common;

[RequireComponent(typeof(EdgeCollider2D))]
public abstract class WallSurface : MonoBehaviour {
    public enum AxisAlignment : int {
        None = 0,
        Horizontal,
        Vertical,
    }

    public enum Facing : int {
        None = 0, 
        Left, 
        Right 
    }

    private static Dictionary<WallSurface.AxisAlignment, List<WallSurface>> instances = 
        new Dictionary<WallSurface.AxisAlignment, List<WallSurface>>();

    public bool debugDrawGizmosInScene = true;

    [SerializeField] private WallSurface.AxisAlignment alignedAxis = WallSurface.AxisAlignment.None;
    [SerializeField] private WallSurface.Facing        frontFace   = WallSurface.Facing.None;

    private EdgeCollider2D ec = null;

    public WallSurface.AxisAlignment AlignedAxis {
        get {
            return alignedAxis;
        }
    }

    public WallSurface.Facing FrontFace {
        get {
            return frontFace;
        }
    }

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

    public float hMidpoint {
        get {
            return B.size.x / 2.0f; // todo: what about .extents?
        }
    }

    public float vMidpoint {
        get {
            return B.size.y / 2.0f; // todo: what about .extents?
        }
    }

    public float Width {
        get {
            return B.size.x;
        }
    }

    public float Height {
        get {
            return B.size.y;
        }
    }

    public static IEnumerable<WallSurface> Horizontals {
        get {
            foreach (var wall in instances.Keys) {
                if (wall == WallSurface.AxisAlignment.Horizontal) {
                    return instances[wall];
                }
            }
            return null;
        }
    }

    public static IEnumerable<WallSurface> Verticals {
        get {
            foreach (var wall in instances.Keys) {
                if (wall == WallSurface.AxisAlignment.Vertical) {
                    return instances[wall];
                }
            }
            return null;
        }
    }

    private Vector3 CalculateOrthogonal (WallSurface.AxisAlignment axis, WallSurface.Facing facing) {
        ExtensionBounds.ScaleBy originalAxis = ExtensionBounds.ScaleBy.Height;
        bool facingLeft = false;

        if (axis == WallSurface.AxisAlignment.Horizontal) {
            originalAxis = ExtensionBounds.ScaleBy.Width;
        }

        if (facing == WallSurface.Facing.Right) {
            facingLeft = true;
        }

        return B.OrthogonalOf(originalAxis, facingLeft);
    }

    public List<WallSurface> GetInstances {
        get {
            List<WallSurface> ws = null;
            if (AlignedAxis == WallSurface.AxisAlignment.Horizontal) {
                ws = Horizontals as List<WallSurface>;
            } else {
                ws = Verticals as List<WallSurface>;
            }
            if (ws.IsNull()) {
                return new List<WallSurface>();
            }
            return ws;
        }
    }

    private void Start () {
        if (FrontFace == WallSurface.Facing.None) {
            Debug.LogErrorFormat(gameObject, "{0} hasn't been assigned a facing!", gameObject.name);
        }

        Orthogonal = CalculateOrthogonal (AlignedAxis, FrontFace);
    }

    private void Update () {
        if (debugDrawGizmosInScene) {
            Debug.DrawRay(transform.position, Orthogonal * 0.1f, Color.red);
        }
    }

    protected virtual void OnEnable () {
        List<WallSurface> hs = GetInstances;
        if (!hs.Contains(this)) {
            hs.Add(this);
            instances[AlignedAxis] = hs;
            Debug.LogFormat(gameObject, "{0} was added to the wall instance list", gameObject.name);
        }
    }

    protected virtual void OnDisable () {
        List<WallSurface> hs = GetInstances;
        if (hs.Contains(this)) {
            hs.Remove(this);
            instances[AlignedAxis] = hs;
            Debug.LogFormat(gameObject, "{0} was removed from the wall instance list", gameObject.name);
        }
    }
}
