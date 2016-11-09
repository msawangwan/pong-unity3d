using UnityEngine;

namespace mUnityFramework.Game.Pong {
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class CollectableBehaviour : MonoBehaviour {
        protected abstract bool collectsOnPaddle { get; }
        protected abstract bool collectsOnBall { get; }
        protected abstract bool collectsOnWall { get; }

        private void OnTriggerEnter2D (Collider2D c) {
            if (collectsOnPaddle) {
                if (c.GetComponent<Paddle>()) {
                    gameObject.SetActive (false);
                }
            }

            if (collectsOnBall) {
                if (c.GetComponent<Ball>()) {
                    gameObject.SetActive (false);
                }
            }

            if (collectsOnWall) {
                if (c.GetComponent<Wall>()) {
                    gameObject.SetActive (false);
                }
            }
        }
    }
}
