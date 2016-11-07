using UnityEngine;

namespace mUnityFramework.Game.Pong {
	public class BallProperty : MonoBehaviour {
		[SerializeField] private float maximumAttainableVelocity = 15.0f;

		public float MaxAttainableVelocity {
			get {
                return maximumAttainableVelocity;
            }
		}
	}
}