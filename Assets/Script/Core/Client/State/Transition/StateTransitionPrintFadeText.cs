using mUIFramework.Core;
using mUIFramework.mvc;

namespace mStateFramework.Core {
	public class StateTransitionPrintFadeText : StateTransition<UI> {
        private readonly string text;
        private readonly float duration;

        public StateTransitionPrintFadeText(string text, float duration = 1.0f) {
            this.text = text;
            this.duration = duration;
        }

        protected override System.Collections.IEnumerable Transition() {
            UIMasterController.Singleton.CenterBanner.ShowText(text);
            yield 
                return new UnityEngine.WaitForSeconds(duration);
            yield
                return UIMasterController.Singleton.CenterBanner.Fade();
        }
	}
}
