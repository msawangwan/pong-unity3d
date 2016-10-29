using mUIFramework.Core;

namespace mStateFramework {
	public class StateUI : State<UI> {
        protected readonly UI context;

		public StateUI (UI context) : base() {
            log("new instance of UI state: " + this.GetType().Name);
            this.context = context;
        }
    }
}
