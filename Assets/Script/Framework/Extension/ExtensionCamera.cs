using UnityEngine;

public static class ExtensionCamera {
    public static float xComponentInScreenSpace (this Camera c, float x) {
        return Camera.main.WorldToScreenPoint(x.AsXOfNewVector()).x;
    }

    public static float yComponentInScreenSpace (this Camera c, float y) {
        return Camera.main.WorldToScreenPoint(y.AsYOfNewVector()).x;
    }

    public static float zComponentInScreenSpace (this Camera c, float z) {
        return Camera.main.WorldToScreenPoint(z.AsZOfNewVector()).x;
    }
}
