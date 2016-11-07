using UnityEngine;

namespace mUnityFramework.Game.Pong {
	public class WallManager : MonoBehaviour {
        public static WallManager S = null;

        [SerializeField] private GameObject leftWall;
		[SerializeField] private GameObject rightWall;
		[SerializeField] private GameObject topWall;
		[SerializeField] private GameObject bottomWall;

		public Vector3 LeftWallPosition {
			get {
                return leftWall.transform.position;
            }
		}

		public Vector3 RightWallPosition {
			get {
                return rightWall.transform.position;
            }
		}

		private void Awake () {
            S = this;
        }
    }
}