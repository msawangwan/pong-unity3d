using UnityEngine;
using System.Collections.Generic;

public abstract class ControllerBehaviour<T> : MonoBehaviour where T : class {
    public static T Instance {
        get {
            return instances[0] as T;
        }
    }

    private static List<ControllerBehaviour<T>> instances = new List<ControllerBehaviour<T>> ();

    /* mark object with 'DontDestroyOnLoad' */
    public bool isPersistant = false;

    /* replace the previous instance with current, use the same gameObject */
    public bool dontDestroy = false;

    /* wrapper for Debug.LogFormat with some reflection added in  */
    protected System.Action<string> info = msg => Debug.LogFormat (
        "[info][{0}][{1}][{2}]", Instance.GetType().Name, msg, Time.time
    );

    private void Awake () {
        if (instances.Count > 0) {
            if (dontDestroy) {
                instances[0] = this;
            } else {
                DestroyImmediate (gameObject);
            }
        } else {
            instances.Add (this);
            if (isPersistant) {
                DontDestroyOnLoad (gameObject);
            }
        }
    }
}
