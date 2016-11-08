using UnityEngine;

namespace mUnityFramework.Game.Pong {
	public class BallForceBehaviour : BallBehaviour {
		public Vector3 DeriveReflectionForce (Vector3 relativeVelocity, Vector3 impactSurfaceNormal) {
            return (
				relativeVelocity - ( 
				2 * Vector3.Dot (
					relativeVelocity, 
					impactSurfaceNormal
					) * 
				impactSurfaceNormal
				)
			);
        }

		public Vector3 SetVelocityTo (Vector3 velocity) {
            rb.velocity = velocity.Truncate (
                property.MaxAttainableVelocity
            );
            return rb.velocity;
        }
	}
}