using System;
using mUIFramework.Core;
using mExtensions.Common;

namespace mStateFramework {
	public class StateFadeText : StateUI {
        private float startTime;

        public StateFadeText(UI context) : base(context) {}

		public override void Enter () {
            context.controller.FadeCenter();
            startTime = UI.DisplayInterval;
        }

		public override bool Update () {
			if (UnityEngine.Time.time > startTime) {
                return true;
            }
            return false;
        }
	}
}
