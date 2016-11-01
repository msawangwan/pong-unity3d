namespace mUIFramework.Core {
	public class UI {
        public static float DisplayTime = 2.0f;
		public static float DisplayInterval {
			get {
                return UnityEngine.Time.time + DisplayTime;
            }
		}
    }
}

