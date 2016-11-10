using UnityEngine;

namespace mUnityFramework.Game {
	public class Player : MonoBehaviour {
		public Score CurrentScore = null;

		public static Player New () {
			return new GameObject("player").AddComponent<Player>();
		}
	}
}
