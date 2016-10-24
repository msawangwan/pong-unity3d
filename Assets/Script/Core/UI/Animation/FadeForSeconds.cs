using UnityEngine;
using System.Collections;

public class FadeEnunerator : MonoBehaviour {
	public static IEnumerator CanvasGroupToZero (GameObject go, float rate = 0.05f) {
        CanvasGroup cgroup = go.GetComponent<CanvasGroup>();
		if (cgroup != null) {
            while (cgroup.alpha > 0) {
                cgroup.alpha -= rate;
                yield return new WaitForEndOfFrame ();
            }
        }
        yield return null;
    }
}
