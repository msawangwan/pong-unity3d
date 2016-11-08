using UnityEngine;
using System;
using System.Collections;

public class CountDown : MonoBehaviour {
    public CanvasController cc;

    Action onComplete;

    int state = -1;
    int count = 3;
    float fadetime = 0.65f;
    float ttl = 0;

    public static CountDown New () {
        return new GameObject("countdown").AddComponent<CountDown>();
    }

    public void Begin (Action onComplete) {
        this.onComplete = onComplete;
        state = 0;
    }

    private IEnumerator BlockFor (float t) {
        yield return new WaitForSeconds(t);
        state++;
    }

    private void Update () {
        if (cc == null) {
            cc = CanvasController.Instance;
        }

        if (state == 0) {
            if (count == 0){
                cc.PrintText("GO");
            } else {
                cc.PrintText(count.ToString());
            }
            state++;
            return;
        }

        if (state == 1) {
            cc.FadeBannerAfterSeconds(fadetime);
            ttl = Time.time + fadetime;
            state++;
            return;
        }

        if (state == 2) {
            if (Time.time > ttl) {
                state++;
                StartCoroutine(BlockFor(fadetime));
            }
            return;
        }

        if (state == 3) {
            return;
        }

        if (state == 4) {
            count--;
            if (count <= -1) {
                if (onComplete != null) {
                    onComplete();
                }
                Destroy(gameObject);
            } else {
                state = 0;
            }
            return;
        }
    }
}
