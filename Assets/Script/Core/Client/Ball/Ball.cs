using UnityEngine;

namespace mUnityFramework.Game.Pong {
	[RequireComponent(typeof(BallProperty))]
	[RequireComponent(typeof(BallForceBehaviour))]
	[RequireComponent(typeof(BallControllerBehaviour))]
	[RequireComponent(typeof(CircleCollider2D))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class Ball : MonoBehaviour {
		public const int ballLayer = 22;

		private BallProperty            cachedProperty = null;
		private BallControllerBehaviour cachedController = null;
		private BallForceBehaviour      cachedForce = null;
		private Rigidbody2D             cachedRb = null;
		private CircleCollider2D        cachedCc = null;
		private TrailRenderer           cachedTr = null;

		public BallProperty Property {
			get {
				if (cachedProperty == null) {
					cachedProperty = GetComponent<BallProperty>();
				}
				return cachedProperty;
			}
		}

		public BallControllerBehaviour Controller {
			get {
				if (cachedController == null) {
					cachedController = GetComponent<BallControllerBehaviour>();
				}
				return cachedController;
			}
		}

		public BallForceBehaviour Force {
			get {
				if (cachedForce == null) {
					cachedForce = GetComponent<BallForceBehaviour>();
				}
				return cachedForce;
			}
		}

		public CircleCollider2D Cc {
			get {
				if (cachedCc == null) {
					cachedCc = GetComponent<CircleCollider2D>();
				}
				return cachedCc;
			}
		}

		public Rigidbody2D Rb {
			get {
				if (cachedRb == null) {
					cachedRb = GetComponent<Rigidbody2D>();
				}
				return cachedRb;
			}
		}

		public TrailRenderer Tr {
			get {
				if (cachedTr == null) {
					cachedTr = GetComponentInChildren<TrailRenderer>();
				}
				return cachedTr;
			}
		}
	}
}