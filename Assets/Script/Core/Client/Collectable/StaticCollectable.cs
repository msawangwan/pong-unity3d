using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public abstract class StaticCollectable : CollectableBehaviour {
        protected override bool collectsOnPaddle    { get { return willCollectOnPaddle; } }
        protected override bool collectsOnBall      { get { return willCollectOnBall; } }
        protected override bool collectsOnWall      { get { return willCollectOnWall; } }

        protected virtual bool willCollectOnPaddle  { get { return false; } }
        protected virtual bool willCollectOnBall    { get { return true; } }
        protected virtual bool willCollectOnWall    { get { return true; } }

        protected override bool pointsOnPaddle    { get { return earnPointsOnPaddle; } }
        protected override bool pointsOnBall      { get { return earnPointsOnBall; } }
        protected override bool pointsOnWall      { get { return earnPointsOnWall; } }

        protected virtual bool earnPointsOnPaddle  { get { return false; } }
        protected virtual bool earnPointsOnBall    { get { return true; } }
        protected virtual bool earnPointsOnWall    { get { return false; } }
    }
}