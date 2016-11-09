using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class StaticCollectable : CollectableBehaviour {
        protected override bool collectsOnPaddle { get { return willCollectOnPaddle; } }
        protected override bool collectsOnBall   { get { return willCollectOnBall; } }
        protected override bool collectsOnWall   { get { return willCollectOnWall; } }

        protected virtual bool willCollectOnPaddle { get { return false; } }
        protected virtual bool willCollectOnBall { get { return true; } }
        protected virtual bool willCollectOnWall { get { return true; } }
    }
}