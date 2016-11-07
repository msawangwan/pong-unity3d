using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Loader : MonoBehaviour {
    public static Loader Instance {
        get {
            if (instances.Count <= 0) {
                return new GameObject ("loader (spawned)").AddComponent<Loader>();
            }
            return instances [0];
        }
    }

    public static System.Action<string> info = msg => Debug.LogFormat (
        "[info][loader][{0}][{1}]", msg, Time.time
    );

    private static List<Loader> instances = new List<Loader> ();

    public void LoadSceneAtIndex (int sceneIndex) {
        SceneManager.LoadSceneAsync (sceneIndex);
    }

    private void Awake () {
        if (instances.Count <= 0) {
            instances.Add (this);
            DontDestroyOnLoad (gameObject);
            info ("created loader");
        } else {
            DestroyImmediate (gameObject);
            info ("destroyed loader");
        }
    }
}
