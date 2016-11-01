using UnityEngine;
using UnityEngine.UI;
using mExtensions.Common;

namespace mUIFramework.mvc {
	public class UICenterBannerModelView : MonoBehaviour {
        public GameObject CenterBanner = null;

        private CanvasGroup canvasGroup = null;
        [SerializeField] private Text FieldBannerText = null;

		public CanvasGroup CanvasGrp {
			get {
				if (canvasGroup.IsNull()) {
					canvasGroup = CenterBanner.GetComponent<CanvasGroup>();
				}
                return canvasGroup;
            }
		}

		public void SetTextAndEnable (string text) {
            FieldBannerText.text = text;
            CenterBanner.Enable ();
        }

		private void Awake () {
            CenterBanner.Disable ();
        }
    }
}
