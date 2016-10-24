using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class UICenterBannerController : MonoBehaviour {
    public Text BannerText = null;

	public IEnumerator FireCenterScreenNotification (UICenterBannerController banner, string txt, float delay) {
        banner.BannerText.text = txt;
        yield return new WaitForEndOfFrame();
        banner.gameObject.Enable();
        yield return new WaitForSeconds(delay);
        yield return StartCoroutine (FadeEnunerator.CanvasGroupToZero (gameObject));
        banner.gameObject.Disable();
    }

    public GameObject SetTextAndEnable (GameObject section, Text field, string text) {
        field.text = text;
        section.Enable ();
        return section;
    }

    public GameObject ClearTextAndDisable (GameObject section, Text field) {
        section.Disable ();
        field.text = "";
        return section;
    }

    public IEnumerator FadeThenDisable (GameObject section, Text field) {
        yield return StartCoroutine (FadeEnunerator.CanvasGroupToZero (gameObject));
        section.gameObject.Disable();
        field.text = "";
    }

    private void Start () {
		gameObject.Disable ();
	}

    private void OnDisable () {
        gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
    }
}