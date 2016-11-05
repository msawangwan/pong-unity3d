using UnityEngine;
using System.Collections.Generic;

namespace mUnityFramework.TwoDee {
    public class Surface2D {
        public enum Axis : byte {
            Horizontal,
            Vertical,
        }

        public enum Front : byte {
            Left,
            Right,
        }

        private static Dictionary<Surface2D.Axis, List<Surface2D>> surfaces =
            new Dictionary<Surface2D.Axis, List<Surface2D>>();

        private EdgeCollider2D edgeCollider = null;
        private Bounds bounds = default(Bounds);

        private Surface2D.Axis axis = default(Surface2D.Axis);
        private Surface2D.Front front = default(Surface2D.Front);

        private Vector3 normalCached = Vector3.zero;
        private bool hasCalculatedNormal = false;

        public Vector3 Normal {
            get {
                if (!hasCalculatedNormal) {
                    if (front == Surface2D.Front.Right) {
                        normalCached = bounds.OrthogonalNormalizedOf (true);
                    } else {
                        normalCached = bounds.OrthogonalNormalizedOf (false);
                    }
                }
                return normalCached;
            }
        }

        public float hMidpoint {
            get {
                return bounds.size.x / 2.0f;
            }
        }

        public float vMidpoint {
            get {
                return bounds.size.y / 2.0f;
            }
        }

        public float Width {
            get {
                return bounds.size.x;
            }
        }

        public float Height {
            get {
                return bounds.size.y;
            }
        }

        private Surface2D (
            Surface2D.Axis axis,
            Surface2D.Front front,
            EdgeCollider2D edgeCollider, 
            Bounds bounds
        ) {
            this.axis = axis;
            this.front = front;
            this.edgeCollider = edgeCollider;
            this.bounds = bounds;
        }

        public static Surface2D New (
            Surface2D.Axis axis,
            Surface2D.Front front,
            EdgeCollider2D edgeCollider, 
            Bounds bounds
        ) {
            return new Surface2D(axis, front, edgeCollider, bounds);
        }
    }
}
