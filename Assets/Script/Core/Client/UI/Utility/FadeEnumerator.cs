using UnityEngine;
using System.Collections;

public static class FadeEnumerator {
	public static IEnumerator CanvasGroupToZero (this GameObject go, float rate = 0.05f) {
        CanvasGroup cgroup = go.GetComponent<CanvasGroup>();
		if (cgroup != null) {
            while (cgroup.alpha > 0) {
                cgroup.alpha -= rate;
                yield return new WaitForEndOfFrame ();
            }
        }
        yield return null;
        go.SetActive(false);
        cgroup.alpha = 1;
        yield return new WaitForEndOfFrame();
    }

	public static IEnumerator CanvasGroupToZeroAfterSeconds (this GameObject go, float seconds, float rate = 0.05f) {
        yield return new WaitForSeconds (seconds);
        CanvasGroup cgroup = go.GetComponent<CanvasGroup>();
		if (cgroup != null) {
            while (cgroup.alpha > 0) {
                cgroup.alpha -= rate;
                yield return new WaitForEndOfFrame ();
            }
        }
        yield return null;
        go.SetActive(false);
        cgroup.alpha = 1;
        yield return new WaitForEndOfFrame();
    }
}
