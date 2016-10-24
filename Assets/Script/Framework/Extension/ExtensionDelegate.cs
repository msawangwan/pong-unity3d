using UnityEngine;
using System;

public static class ExtensionDelegate {
    public static bool InvokeSafeAndSetNull (this Func<bool> f) {
        if (f == null) {
            return false;
        }
        f.InvokeSafe();
        f = null;
        return true;
    }
}
