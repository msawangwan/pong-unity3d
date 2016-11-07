using UnityEngine;

namespace mUnityFramework.Game.Pong {
	public class BallManager : MonoBehaviour {
		public static BallManager S = null;

		public Ball CurrentBall = null;

		private void Awake () {
			S = this;
		}

		private void Start () {
			CurrentBall.Controller.ToZeroState(transform.parent, Vector3.zero);
		}
	}
}