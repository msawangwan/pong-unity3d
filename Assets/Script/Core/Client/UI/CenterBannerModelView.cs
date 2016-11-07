using UnityEngine;
using UnityEngine.UI;

public class CenterBannerModelView : MonoBehaviour {
    [SerializeField] private Text txtCenterField = null;

    public void PrintText (string text) {
        txtCenterField.text = text;
    }
}
