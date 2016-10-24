using UnityEngine;
using UnityEngine.UI;

public class UIStartMenuController : MonoBehaviour {
    public GameObject MenuPanelContainer = null;
    public Button BtnNewGame = null;
    public Button BtnSettings = null;

	private void InitialiseMenuButtons () {
		if (BtnNewGame != null && BtnSettings != null && MenuPanelContainer != null) {
			BtnNewGame.onClick.RemoveAllListeners();
			BtnNewGame.onClick.AddListener(() => {
                GlobalMediator.RaiseOnNewGameStarted.InvokeSafe();
                MenuPanelContainer.SetActive(false);
            });

			BtnSettings.onClick.RemoveAllListeners();
			BtnSettings.onClick.AddListener( () => {
				Debug.LogFormat("SETTINGS NOT IMPLEMENTED YET: {0}", true);
			});
		} else {
            Debug.LogWarningFormat(gameObject, "assign button references in inspector for {0} and {1} and {2} !", BtnNewGame.name, BtnSettings.name, MenuPanelContainer.name);
        }
    }

	private void Awake () {
        InitialiseMenuButtons();
    }
}
