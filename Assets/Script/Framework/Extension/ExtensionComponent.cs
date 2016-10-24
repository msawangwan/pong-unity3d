using UnityEngine;

public static class ExtensionComponent {
	public static bool EnableOnlyIfInactive (this Component c) {
		if (c.gameObject.activeInHierarchy == false) {
            c.gameObject.SetActive (true);
            return true;
        }
        return false;
    }

	public static bool DisableOnlyIfActive (this Component c) {
		if (c.gameObject.activeInHierarchy == true) {
            c.gameObject.SetActive (false);
            return true;
        }
        return false;
    }
}
