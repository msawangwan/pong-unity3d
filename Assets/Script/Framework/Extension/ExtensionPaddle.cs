using UnityEngine;

public static class ExtensionPaddle {
    public static void ChangePhaseToServe (this Paddle p) {
        p.IsInServePhase = true;
    }
}
