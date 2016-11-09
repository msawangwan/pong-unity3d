using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class CoinFaller : DynamicCollectable {
        public int PointValue = 1;
        public float FallAcceleration = 0.5f;

        protected override int collectablePointValue { get { return PointValue; } }

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
