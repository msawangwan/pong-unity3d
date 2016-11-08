using UnityEngine;

namespace mUnityFramework.Game.Pong {
	public class PaddleForceBehaviour : PaddleBehaviour {
		private void OnTriggerEnter2D (Collider2D c) {
			Ball b = c.gameObject.GetComponent<Ball>();

			if (b) {
				Vector3 rf = b.Force.SetVelocityTo (
					b.Force.DeriveReflectionForce (
						b.Rb.velocity,
						paddle.Surface.Normal
					)
				);

				Debug.DrawRay(paddle.transform.position, rf, Color.blue, 2.0f);
			}
		}

		// private void OnCollisionEnter2D (Collision2D c) {
		// 	Ball b = c.gameObject.GetComponent<Ball>();

		// 	if (b) {
		// 		Vector3 rf = b.Force.SetVelocityTo (
		// 			b.Force.DeriveReflectionForce (
		// 				c.relativeVelocity,
		// 				paddle.Surface.Normal
		// 			)
		// 		);

		// 		Debug.DrawRay(paddle.transform.position, rf, Color.blue, 2.0f);
		// 	}
		// }
	}
}