using UnityEngine;
using mUIFramework.mvc;

public class UIMasterCanvasController : MonoBehaviour { // todo: make singleton
    public static UIMasterCanvasController SingletonInstance = null;
    public UICenterBannerController CenterNotificationHUD = null;


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
