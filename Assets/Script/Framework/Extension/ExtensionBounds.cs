using UnityEngine;

public static class ExtensionBounds {
    public enum ScaleBy : int {
        None = 0,
        Width,
        Height,
    }

    public static Vector3 OrthogonalNormalizedOf (this Bounds b, bool leftFacing=true) {
        if (leftFacing) {
            return (b.min - b.max).FindNormal2DLeftHand().normalized;
        } else {
            return (b.min - b.max).FindNormal2DRightHand().normalized;
        }
    }

    /* scales by |v| * 1/2  */
    public static Vector3 OrthogonalOf (this Bounds b, ExtensionBounds.ScaleBy s, bool leftFacing=true) {
        float scalar = 0.0f;

        if (s == ExtensionBounds.ScaleBy.Width) {
            scalar = b.extents.x;
        } else {
            scalar = b.extents.y;
        }

        if (leftFacing) {
            return (b.min - b.max).FindNormal2DLeftHand().normalized * scalar;
        } else {
            return (b.min - b.max).FindNormal2DRightHand().normalized * scalar;
        }
    }
}
