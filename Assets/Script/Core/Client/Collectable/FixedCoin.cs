using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class FixedCoin : Collectable {
        public override bool collectsOnPaddle { get { return false; } }
        public override bool collectsOnBall { get { return true; } }
        public override bool collectsOnWall { get { return true; } }
    }
}