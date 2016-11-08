using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CanvasController : MonoBehaviour {
    public static CanvasController Instance {
        get {
            if (instances.Count <= 0) {
                return new GameObject ("canvascontroller (spawned)").AddComponent<CanvasController>();
            }
            return instances [0];
        }
    }

    public static System.Action<string> info = msg => Debug.LogFormat (
        "[info][canvascontroller][{0}][{1}]", msg, Time.time
    );

    private static List<CanvasController> instances = new List<CanvasController> ();

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

    private void Awake () {
        if (instances.Count <= 0) {
            instances.Add (this);
            DontDestroyOnLoad (gameObject);
            info ("created canvascontroller");
        } else {
            DestroyImmediate (gameObject);
            info ("destroyed canvascontroller");
        }
    }
}
