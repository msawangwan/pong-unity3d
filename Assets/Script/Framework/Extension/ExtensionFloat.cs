using UnityEngine;

public static class ExtensionFloat {
    public static Vector3 AsVectorComponentx(this float x) {
        return new Vector3(x, 0.0f, 0.0f);
    }
    
    public static Vector3 AsVectorComponenty(this float y) {
        return new Vector3(0.0f, y, 0.0f);
    }
    
    public static Vector3 AsVectorComponentz(this float z) {
        return new Vector3(0.0f, 0.0f, z);
    }
}
