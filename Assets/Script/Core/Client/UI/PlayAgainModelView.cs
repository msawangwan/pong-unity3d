using UnityEngine;
using UnityEngine.UI;

public class PlayAgainModelView : MonoBehaviour {
    [SerializeField] private Button BtnPlayAgain = null;
    [SerializeField] private int NewGameSceneIndex = 2;

    private void Start () {
        BtnPlayAgain.onClick.RemoveAllListeners();
        BtnPlayAgain.onClick.AddListener (
            () => Loader.Instance.LoadSceneAtIndex (
                NewGameSceneIndex
            )
        );
    }
}
