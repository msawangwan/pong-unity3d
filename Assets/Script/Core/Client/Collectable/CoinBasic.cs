using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class CoinBasic : StaticCollectable {
        public int PointValue = 1;
        protected override int collectablePointValue { get { return PointValue; } }
    }
}