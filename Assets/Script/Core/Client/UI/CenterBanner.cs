using UnityEngine;
using System.Collections.Generic;

public class CenterBanner : MonoBehaviour {
    public static CenterBanner Instance {
        get {
            return instances [0];
        }
    }

    private static List<CenterBanner> instances = new List<CenterBanner> ();

    private void Awake () {
        if (instances.Count <= 0) {
            instances.Add (this);
        } else {
            DestroyImmediate (gameObject);
        }
    }

}
