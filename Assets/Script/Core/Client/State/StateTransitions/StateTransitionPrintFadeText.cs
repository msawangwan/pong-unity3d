using mUIFramework.Core;

namespace mStateFramework {
	public class StateTransitionPrintFadeText : StateTransition<UI> {
        private readonly string text;
        private readonly float duration;

        public StateTransitionPrintFadeText(string text, float duration = 1.0f) {
            this.text = text;
            this.duration = duration;
        }

        protected override System.Collections.IEnumerable Transition() {
            UIMasterCanvasController.SingletonInstance.PrintCenter(text);
            yield 
                return new UnityEngine.WaitForSeconds(duration);
            yield 
                return UIMasterCanvasController.SingletonInstance.CenterNotificationHUD.FadeThenDisable();
        }
	}
}
