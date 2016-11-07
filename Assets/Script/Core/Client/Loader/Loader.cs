using UnityEngine;
using UnityEngine.UI;
using SM = UnityEngine.SceneManagement.SceneManager;

public class Loader : MonoBehaviour {
    public Button b;

	private void Start() {
        b.onClick.RemoveAllListeners();
        b.onClick.AddListener(() => SM.LoadSceneAsync(0));
    }
}
