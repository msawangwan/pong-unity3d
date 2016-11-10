using UnityEngine;

namespace mUnityFramework.Game.Pong {
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class CollectableBehaviour : MonoBehaviour {
        public int PointValue = 0;

        [SerializeField] CollectableNotifier collectableNotifier = null;

        protected abstract bool collectsOnPaddle { get; }
        protected abstract bool collectsOnBall   { get; }
        protected abstract bool collectsOnWall   { get; }

        protected abstract bool pointsOnPaddle { get; }
        protected abstract bool pointsOnBall   { get; }
        protected abstract bool pointsOnWall   { get; }

        private int pointValue {get { return PointValue; } }

        protected static System.Action<string> info = msg => Debug.LogFormat (
            "[info][CollectableBehaviour][{0}]", msg
        );

        private void RaiseCollectedEvent (int pointValue) {
            if (collectableNotifier) {
                collectableNotifier.onCollectableCollected(pointValue);
            }
        }

        private void OnTriggerEnter2D (Collider2D c) {
            if (collectsOnPaddle) {
                if (c.GetComponent<Paddle>()) {
                    gameObject.SetActive (false);
                    if (pointsOnPaddle) {
                        RaiseCollectedEvent(pointValue);
                    }
                }
            }

            if (collectsOnBall) {
                if (c.GetComponent<Ball>()) {
                    gameObject.SetActive (false);
                    if (pointsOnBall) {
                        RaiseCollectedEvent(pointValue);
                    }
                }
            }

            if (collectsOnWall) {
                if (c.GetComponent<Wall>()) {
                    gameObject.SetActive (false);
                    if (pointsOnWall) {
                        RaiseCollectedEvent(pointValue);
                    }
                }
            }
        }
    }
}
