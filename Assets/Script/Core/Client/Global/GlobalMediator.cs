using UnityEngine;
using System;

public class GlobalMediator : MonoBehaviour {
    public static GlobalMediator StaticInstance = null;

    /* core game loop */
    public static Action RaiseOnNewGameStarted { get; set; }

    private void Awake () {
        StaticInstance = this;
    }
}
