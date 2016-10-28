using UnityEngine;

public static class ExtensionPaddle {
    public static bool ChangePhaseToServe (this Paddle p) {
        p.IsInServePhase = true;
        return true;
    }
}
