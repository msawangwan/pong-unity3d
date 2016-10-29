using System;
using mUIFramework.Core;
using mExtensions.Common;

namespace mStateFramework {
	public class StateEnableGameHUD : StateUI {
        private readonly Action<bool> action;

        public StateEnableGameHUD(UI context, Action<bool> action) : base(context) {
            this.action = action;
        }

		public override void Enter () {
			if (!action.IsNull()) {
                action(true);
            }
		}

		public override State<UI> Exit () {
            return new StatePrintText(context, "READY");
        }
	}
}
