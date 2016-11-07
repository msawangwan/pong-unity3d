using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class BallControllerBehaviour : BallBehaviour {
        public void ToLaunchState (Transform launcher, float offset) {
            ball.Controller.ToZeroState(
                launcher,
                Vector3.zero
            );

            rb.position = launcher.position;
            // rb.position = launcher.position + offset.AsYOfNewVector();
            ball.gameObject.SetActive (true);
        }

        public void ToZeroState (Transform parent, Vector3 position) {
            ball.gameObject.SetActive (false);

            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.position = position;

            tr.enabled = false;
            tr.Clear();

            transform.rotation = Quaternion.identity;
            transform.SetParent(parent);
        }
    }
}
