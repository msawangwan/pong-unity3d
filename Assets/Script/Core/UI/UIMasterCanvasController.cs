using UnityEngine;

public class UIMasterCanvasController : MonoBehaviour { // todo: make singleton
    public UIGameScoreController ScoreHUD = null;
    public UICenterBannerController CenterNotificationHUD = null;

    public void UpdateScore (int p1, int p2) {
        ScoreHUD.UpdateScoreBoard (p1, p2);
    }

    public void ToggleScoreboardActive (bool activate) {
        if (activate == true) {
            ScoreHUD.gameObject.Enable ();
        } else {
            ScoreHUD.gameObject.Disable ();
        }
    }

    // public float StartCoroutineForSecondsAndPrintToScreen (string text, float seconds = 2.0f) {
    //     StartCoroutine (CenterNotificationHUD.FireCenterScreenNotification (CenterNotificationHUD, text, seconds));
    //     return Time.time + seconds;
    // }

    public void PrintCenter (string s) {
        CenterNotificationHUD.SetTextAndEnable(CenterNotificationHUD.gameObject, CenterNotificationHUD.BannerText, s);
    }

    public void FadeCenter () {
        StartCoroutine(CenterNotificationHUD.FadeThenDisable(CenterNotificationHUD.gameObject, CenterNotificationHUD.BannerText));
    }

    public void ClearCenter () {
        CenterNotificationHUD.ClearTextAndDisable(CenterNotificationHUD.gameObject, CenterNotificationHUD.BannerText);
    }
}
