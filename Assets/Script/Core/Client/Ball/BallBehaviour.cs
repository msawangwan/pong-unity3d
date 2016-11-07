using UnityEngine;

namespace mUnityFramework.Game.Pong {
	[RequireComponent(typeof(Ball))]
	public abstract class BallBehaviour : MonoBehaviour {
        private Ball cachedBall = null;

		protected Ball ball {
			get {
				if (cachedBall == null) {
                    cachedBall = GetComponent<Ball>();
                }
                return cachedBall;
            }
		}

		protected BallProperty property {
			get {
                return ball.Property;
            }
		}

		protected Rigidbody2D rb {
			get {
                return ball.Rb;
            }
		}

		protected TrailRenderer tr {
			get {
                return ball.Tr;
            }
		}
    }
}