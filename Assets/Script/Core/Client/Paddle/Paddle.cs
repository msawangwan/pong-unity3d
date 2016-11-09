using UnityEngine;
using mUnityFramework.Physics.TwoDee;

namespace mUnityFramework.Game.Pong {
	[RequireComponent(typeof(PaddleProperty))]
	[RequireComponent(typeof(PaddleMoveBehaviour))]
	[RequireComponent(typeof(PaddleLauncherBehaviour))]
	[RequireComponent(typeof(EdgeCollider2D))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class Paddle : MonoBehaviour {
		public enum Status : byte {
			None = 0,
			Enabled,
			Disabled,
		}

		public enum State : byte {
			None = 0,
			Serve,
			Play,
		}

		public static System.Action<string> info = msg => Debug.LogFormat (
			"[info][Paddle][{0}]", msg
		);

		private PaddleProperty          cachedProperty      = null;
		private PaddleMoveBehaviour     cachedMover         = null;
		private PaddleLauncherBehaviour cachedLauncher      = null;
		private Rigidbody2D             cachedRigidBody     = null;
		private EdgeCollider2D          cachedEdgeCollider  = null;
		private Surface2D               cachedSurface       = null;
		private TrailRenderer           cachedTrailRenderer = null;

		public Paddle.Status PaddleStatus { get; set; }
		public Paddle.State PaddleState { get; set; }

		public PaddleProperty Property {
			get {
				if (! cachedProperty) {
					cachedProperty = GetComponent<PaddleProperty>();
				}
				return cachedProperty;
			}
		}

		public PaddleMoveBehaviour Mover {
			get {
				if (! cachedMover) {
					cachedMover = GetComponent<PaddleMoveBehaviour>();
				}
				return cachedMover;
			}
		}

		public PaddleLauncherBehaviour Launcher {
			get {
				if (! cachedLauncher) {
					cachedLauncher = GetComponent<PaddleLauncherBehaviour>();
				}
				return cachedLauncher;
			}
		}

		public Rigidbody2D Rb {
			get {
				if (! cachedRigidBody) {
					cachedRigidBody = GetComponent<Rigidbody2D>();
				}
				return cachedRigidBody;
			}
		}

		public EdgeCollider2D Ec {
			get {
				if (! cachedEdgeCollider) {
					cachedEdgeCollider = GetComponent<EdgeCollider2D>();
				}
				return cachedEdgeCollider;
			}
		}

		public TrailRenderer Tr {
			get {
				if (! cachedTrailRenderer) {
					cachedTrailRenderer = GetComponentInChildren<TrailRenderer>();
				}
				return cachedTrailRenderer;
			}
		}

		public Surface2D Surface {
			get {
				if (cachedSurface == null) {
					cachedSurface = Surface2D.New (
						Surface2D.Axis.Horizontal,
						Surface2D.Front.Right,
						Ec
					);
				}
				return cachedSurface;
			}
		}

		private void FixedUpdate () {
			Mover.MoveUpdate ();
            Launcher.LaunchUpdate ();
            Surface.DrawNormal (); // debug
		}

		private void OnEnable () {
			Rb.position = new Vector3 (0, Property.hPosition, 0); // set default fixed horizontal offset
		}
	}
}