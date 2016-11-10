using UnityEngine.SceneManagement;

public class Loader : ControllerBehaviour<Loader> {
    public void LoadSceneAtIndex (int sceneIndex) {
        SceneManager.LoadSceneAsync (sceneIndex);
    }
}
