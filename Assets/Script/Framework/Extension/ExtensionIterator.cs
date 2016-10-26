using UnityEngine;
using System.Collections;

public static class ExtensionIterator {
	public static IEnumerator BlockUntil (float seconds) {
        yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds (seconds);
    }
}
