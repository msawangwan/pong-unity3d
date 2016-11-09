using UnityEngine;

namespace mUnityFramework.Game.Pong {
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class DynamicCollectable : CollectableBehaviour {
        protected override bool collectsOnPaddle { get { return willCollectOnPaddle; } }
        protected override bool collectsOnBall   { get { return willCollectOnBall; } }
        protected override bool collectsOnWall   { get { return willCollectOnWall; } }

        protected virtual bool willCollectOnPaddle { get { return true; } }
        protected virtual bool willCollectOnBall { get { return false; } }
        protected virtual bool willCollectOnWall { get { return false; } }

        private Rigidbody2D cachedRb = null;

        protected Rigidbody2D rb {
            get {
                if (! cachedRb) {
                    cachedRb = GetComponent<Rigidbody2D>();
                }
                return cachedRb;
            }
        }
    }
}