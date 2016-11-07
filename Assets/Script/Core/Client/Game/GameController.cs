using UnityEngine;
using mUnityFramework.Game.Pong;

public class GameController : MonoBehaviour {
    public Paddle p;
    public int state = -10;

    private float ttl = 2.0f;
    private float timestamp = 0;

    private CountDown countdown = null;
    private bool canContinue = false;

    private void Update () {
        if (state == -10) {
            if (countdown == null) {
                countdown = CountDown.New();
                countdown.Begin(
                    () => {
                        canContinue = true;
                    }
                );
            }
            state = -5;
        }

        if (state == -5) {
            if (canContinue) {
                state = 0;
            }
        }

        if (state == 0) {
            p.PaddleState = Paddle.State.Serve;
            state = 5;
            return;
        }

        if (state == 5) {
            return;
        }
    }
}
