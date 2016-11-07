using UnityEngine;
using UnityEngine.UI;

public class BeginNewModelView : MonoBehaviour {
    [SerializeField] private Button BtnBeginNewGame = null;
    [SerializeField] private int NewGameSceneIndex = 2;

    private void Start () {
        BtnBeginNewGame.onClick.RemoveAllListeners();
        BtnBeginNewGame.onClick.AddListener (
            () => Loader.Instance.LoadSceneAtIndex (
                NewGameSceneIndex
            )
        );
    }
}