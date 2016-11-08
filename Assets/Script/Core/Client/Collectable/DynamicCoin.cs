using UnityEngine;

namespace mUnityFramework.Game.Pong {
    [RequireComponent(typeof(Rigidbody2D))]
    public class DynamicCoin : Collectable {
        public float fallingAcceleration = 0.5f;

        public override bool collectsOnPaddle { get { return true; } }
        public override bool collectsOnBall { get { return false; } }
        public override bool collectsOnWall { get { return false; } }

        private Vector3 downForce = Vector3.zero;

        private Rigidbody2D cachedRb = null;
        private Rigidbody2D rb {
            get {
                if (! cachedRb) {
                    cachedRb = GetComponent<Rigidbody2D>();
                }
                return cachedRb;
            }
        }

        private void FixedUpdate () {
            downForce = new Vector3(0, Mathf.Abs(fallingAcceleration) * -1f, 0f);
            rb.AddForce(downForce);
        }
    }
}