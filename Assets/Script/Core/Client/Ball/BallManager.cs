using UnityEngine;

namespace mUnityFramework.Pong {
    public class BallManager : MonoBehaviour {
        public static BallManager StaticInstance = null;

        public GameObject BallGameobject = null;

        private Ball currentBall = null;
        public Ball CurrentBall {
            get {
                if (currentBall == null) {
                    currentBall = BallGameobject.GetComponent<Ball>();
                }
                return currentBall;
            }
        }

        private void Awake () {
            StaticInstance = this;
        }

        private void Start () {
            Ball.ResetAndPositionAt(CurrentBall.transform.parent, CurrentBall, Vector3.zero);
        }
    }
}