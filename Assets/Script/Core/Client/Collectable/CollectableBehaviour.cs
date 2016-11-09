using UnityEngine;

namespace mUnityFramework.Game.Pong {
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class CollectableBehaviour : MonoBehaviour {
        [SerializeField] CollectableNotifier collectableNotifier = null;

        protected abstract bool collectsOnPaddle { get; }
        protected abstract bool collectsOnBall   { get; }
        protected abstract bool collectsOnWall   { get; }

        protected abstract int pointValue { get; }

        protected static System.Action<string> info = msg => Debug.LogFormat (
            "[info][CollectableBehaviour][{0}]", msg
        );

        private void RaiseCollectedEvent (int pointValue) {
            if (collectableNotifier) {
                collectableNotifier.onCollectableCollected(pointValue);
            }
            info ("collected " + pointValue);
        }

        private void OnTriggerEnter2D (Collider2D c) {
            if (collectsOnPaddle) {
                if (c.GetComponent<Paddle>()) {
                    gameObject.SetActive (false);
                    RaiseCollectedEvent(pointValue);
                }
            }

            if (collectsOnBall) {
                if (c.GetComponent<Ball>()) {
                    gameObject.SetActive (false);
                    RaiseCollectedEvent(pointValue);
                }
            }

            if (collectsOnWall) {
                if (c.GetComponent<Wall>()) {
                    gameObject.SetActive (false);
                    RaiseCollectedEvent(pointValue);
                }
            }
        }
    }
}
