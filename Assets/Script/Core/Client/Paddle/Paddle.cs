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
				if (cachedProperty == null) {
					cachedProperty = GetComponent<PaddleProperty>();
				}
				return cachedProperty;
			}
		}

		public PaddleMoveBehaviour Mover {
			get {
				if (cachedMover == null) {
					cachedMover = GetComponent<PaddleMoveBehaviour>();
				}
				return cachedMover;
			}
		}

		public PaddleLauncherBehaviour Launcher {
			get {
				if (cachedLauncher == null) {
					cachedLauncher = GetComponent<PaddleLauncherBehaviour>();
				}
				return cachedLauncher;
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

		public Rigidbody2D Rb {
			get {
				if (cachedRigidBody == null) {
					cachedRigidBody = GetComponent<Rigidbody2D>();
				}
				return cachedRigidBody;
			}
		}

		public EdgeCollider2D Ec {
			get {
				if (cachedEdgeCollider == null) {
					cachedEdgeCollider = GetComponent<EdgeCollider2D>();
				}
				return cachedEdgeCollider;
			}
		}

		public TrailRenderer Tr {
			get {
				if (cachedTrailRenderer == null) {
					cachedTrailRenderer = GetComponentInChildren<TrailRenderer>();
				}
				return cachedTrailRenderer;
			}
		}

		private void Start () {
			PaddleStatus = Paddle.Status.Enabled;
            // PaddleState = Paddle.State.Serve;
            Rb.position = new Vector3(0, Property.hPosition, 0);
        }

		private void FixedUpdate () {
			Mover.MoveUpdate ();
            Launcher.LaunchUpdate ();
            Surface.DrawNormal ();
		}
	}
}