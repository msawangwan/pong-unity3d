using UnityEngine;

public static class ExtensionVector3 {
	public static Vector3 FindNormal2DLeftHand (this Vector3 v) {
        return new Vector3(-v.y, v.x, v.z);
    }

	public static Vector3 FindNormal2DRightHand (this Vector3 v) {
        return new Vector3(v.y,-v.x, v.z);
    }

    public static Vector3 Truncate (this Vector3 v, float maxLength) {
        if (v.magnitude > maxLength) {
            return v.normalized * maxLength;
        }
        return v;
    }
}
