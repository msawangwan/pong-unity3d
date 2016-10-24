using UnityEngine;

public class BallManager : MonoBehaviour {
    public static BallManager StaticInstance = null;

    public GameObject BallGameobject = null;

    private Ball currentBall = null;
    public Ball CurrentBall {
        get {
            if (currentBall == null) {
                currentBall = BallGameobject.GetComponent<Ball>();
            }
            return currentBall;
        }
    }

    private void Awake () {
        StaticInstance = this;
    }
}