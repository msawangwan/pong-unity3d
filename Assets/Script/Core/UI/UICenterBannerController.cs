namespace mUIFramework.mvc {
    public class UICenterBannerController {
        private UICenterBannerModelView centerBannerMV;

        public UICenterBannerController(UICenterBannerModelView centerBannerMV) {
            this.centerBannerMV = centerBannerMV;
        }

        public bool ShowText (string text) {
            centerBannerMV.SetTextAndEnable(text);
            return true;
        }

        public System.Collections.IEnumerator Fade (float rate = 0.05f) {
            yield return FadeEnumerator.CanvasGroupToZero(centerBannerMV.CenterBanner, rate);
            centerBannerMV.CenterBanner.Disable ();
            centerBannerMV.CanvasGrp.alpha = 1.0f; // reset alpha
        }
    }
}