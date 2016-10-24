using UnityEngine;
using System.Collections;

public static class ExtensionEnumerator {
	public static IEnumerator BlockUntil (float seconds) {
        yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds (seconds);
    }
}
