using UnityEngine;

public static class ExtensionRigidBody2D  {
	public static void AddForceMaximum(this Rigidbody2D rb, Vector3 f, float maxMagnitude) {
        rb.AddForce(f.Truncate(maxMagnitude));
    }

	public static void SetVelocity (this Rigidbody2D rb, Vector3 f, float maxVelocity) {
        rb.velocity = f.Truncate(maxVelocity);
    }
}
