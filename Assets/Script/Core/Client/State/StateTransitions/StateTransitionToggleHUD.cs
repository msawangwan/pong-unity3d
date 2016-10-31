using mUIFramework.Core;

namespace mStateFramework {
	public class StateTransitionToggleHUD : StateTransition<UI> {
        private readonly bool toggleOn;

        public StateTransitionToggleHUD (bool toggleOn) : base () {
            this.toggleOn = toggleOn;
        }

        protected override System.Collections.IEnumerable Transition() {
            UIMasterCanvasController.SingletonInstance.ToggleScoreboardActive(toggleOn);
            yield return null;
        }
	}
}
