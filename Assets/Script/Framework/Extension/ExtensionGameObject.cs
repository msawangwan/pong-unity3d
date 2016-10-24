using UnityEngine;

public static class ExtensionGameObject {
    public static bool Enable(this GameObject go) {
        if (go.activeInHierarchy == false) {
            go.SetActive(true);
            return true;
        }
        return false;
    }

    public static bool Disable(this GameObject go) {
        if (go.activeInHierarchy == true) {
            go.SetActive(false);
            return true;
        }
        return false;
    }

    public static T GetComponentSafe<T> (this GameObject go) where T : Component {
        T c = go.GetComponent<T> ();
        if ( c == null ) {
            c = go.gameObject.AddComponent<T>();
        }
        return c;
    }
}
