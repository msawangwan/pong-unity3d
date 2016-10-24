using UnityEngine;

public class PaddleManager : MonoBehaviour {
    public static PaddleManager StaticInstance = null;

    public Paddle[] Paddles = new Paddle[ConstNumerical.Gameplay.PaddleCountMaximum];

    public static Paddle[] SetAllPaddleActiveState (Paddle[] paddles, bool isActive) {
        Paddle[] allPaddles = new Paddle[] { paddles [0], paddles [1] };
        foreach (Paddle paddle in allPaddles) {
            paddle.gameObject.SetActive(isActive);
        }
        return allPaddles;
    }

    private void Awake () {
        StaticInstance = this;
    }

    private void Start () {
        PaddleManager.SetAllPaddleActiveState (Paddles, false);
    }
}
