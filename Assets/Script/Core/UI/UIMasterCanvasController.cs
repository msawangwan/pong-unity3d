using UnityEngine;

public class UIMasterCanvasController : MonoBehaviour { // todo: make singleton
    public static UIMasterCanvasController SingletonInstance = null;

    public UIGameScoreController ScoreHUD = null;
    public UICenterBannerController CenterNotificationHUD = null;

    public void UpdateScore (int p1, int p2) {
        ScoreHUD.UpdateScoreBoard (p1, p2);
    }

    public void ToggleScoreboardActive (bool activate) {
        if (activate == true) {
            ScoreHUD.EnableOnlyIfInactive();
        } else {
            ScoreHUD.DisableOnlyIfActive();
        }
    }

    public void PrintCenter (string s) {
        CenterNotificationHUD.SetTextAndEnable(CenterNotificationHUD.gameObject, CenterNotificationHUD.BannerText, s);
    }

    public void ClearCenter () {
        CenterNotificationHUD.ClearTextAndDisable(CenterNotificationHUD.gameObject, CenterNotificationHUD.BannerText);
    }

    private void Awake() {
        SingletonInstance = this;
    }
}
