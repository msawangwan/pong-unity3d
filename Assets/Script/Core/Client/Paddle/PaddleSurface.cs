using UnityEngine;
using mExtensions.Common;

namespace mUnityFramework.Pong {
    [RequireComponent(typeof(EdgeCollider2D))]
    public class PaddleSurface : MonoBehaviour {
        public enum ScreenLocation : int {
            None = 0,
            Bottom,
            Top,
        }

        public PaddleSurface.ScreenLocation Location = PaddleSurface.ScreenLocation.None;

        public EdgeCollider2D EC {
            get {
                if (ec.IsNull()) {
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

        public float Length {
            get {
                return B.size.x;
            }
        }

        private EdgeCollider2D ec = null;

        private void NormalizePositionAndRotation () {
            if (Location == PaddleSurface.ScreenLocation.Top) {
                transform.rotation = Quaternion.Euler (0, 0, 180f);
            }
        }

        private Vector3 CalculateOrthogonal (PaddleSurface.ScreenLocation location) {
            if (location == PaddleSurface.ScreenLocation.Top) {
                return B.Orthogonal(ExtensionBounds.ScaleBy.Width);
            } else {
                return B.Orthogonal(ExtensionBounds.ScaleBy.Width, false);
            }
        }

        private void Start () {
            NormalizePositionAndRotation();
            Orthogonal = CalculateOrthogonal(Location);
        }

        private void Update () {
            Debug.DrawRay(transform.position, Orthogonal, Color.red);
        }
    }
}
