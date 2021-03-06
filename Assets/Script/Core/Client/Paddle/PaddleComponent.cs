﻿using UnityEngine;
using mExtensions.Common;

namespace mUnityFramework.Pong {
    public abstract class PaddleComponent : MonoBehaviour {
        protected Paddle paddleCached = null;
        protected Paddle paddle {
            get {
                if (paddleCached.IsNull()) {
                    paddleCached = gameObject.GetComponent<Paddle>();
                }
                return paddleCached;
            }
        }
    }
}