using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public abstract class StaticCollectable : CollectableBehaviour {
        protected override bool collectsOnPaddle    { get { return willCollectOnPaddle; } }
        protected override bool collectsOnBall      { get { return willCollectOnBall; } }
        protected override bool collectsOnWall      { get { return willCollectOnWall; } }

        protected override int pointValue           { get { return collectablePointValue; } }

        protected virtual bool willCollectOnPaddle  { get { return false; } }
        protected virtual bool willCollectOnBall    { get { return true; } }
        protected virtual bool willCollectOnWall    { get { return true; } }

        protected abstract int collectablePointValue { get; }
    }
}