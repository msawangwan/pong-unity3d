using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class CoinFaller : DynamicCollectable {
        public float FallAcceleration = 0.5f;

        private Vector3 fallForce {
            get {
                return new Vector3 (
                    0,
                    Mathf.Abs(FallAcceleration) * -1,
                    0
                );
            }
        }

        private void FixedUpdate () {
            rb.AddForce(fallForce);
        }
    }
}
