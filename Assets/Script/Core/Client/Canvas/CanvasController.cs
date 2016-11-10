using UnityEngine;
using UnityEngine.UI;

public class CanvasController : ControllerBehaviour<CanvasController> {
    [SerializeField] private GameObject goCenterBanner = null;
    [SerializeField] private Text txtFieldCenterBanner = null;

    public void PrintText (string text) {
        if (goCenterBanner == null) {
            goCenterBanner = FindObjectOfType<CenterBanner>().gameObject;
            if (txtFieldCenterBanner == null) {
                txtFieldCenterBanner = GetComponentInChildren<Text>();
            }
        }
        goCenterBanner.SetActive(true);
        txtFieldCenterBanner.text = text;
    }

    public void FadeBannerAfterSeconds (float seconds) {
        StartCoroutine(goCenterBanner.CanvasGroupToZeroAfterSeconds(seconds));
    }
}
