using UnityEngine;
using System.Collections.Generic;

public abstract class ControllerBehaviour<T> : MonoBehaviour {
    public static ControllerBehaviour<T> Instance {
        get {
            if (instances.Count <= 0) {
                return new GameObject ("ControllerBehaviour").AddComponent<ControllerBehaviour<T>>();
            }
            return instances [0];
        }
    }

    private static List<ControllerBehaviour<T>> instances = new List<ControllerBehaviour<T>> ();

    private void Awake () {
        if (instances.Count <= 0) {
            instances.Add (this);
            DontDestroyOnLoad (gameObject);
        } else {
            DestroyImmediate (gameObject);
        }
    }
}
