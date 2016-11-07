using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class DeadZone : MonoBehaviour {
        public int SceneToLoadOnEnd = 1;

        private void OnCollisionEnter2D (Collision2D c) {
            Ball b = c.gameObject.GetComponent<Ball>();
            if (b) {
                b.Controller.ToZeroState (
                    BallManager.S.transform, 
                    Vector3.zero
                );

                Loader.Instance.LoadSceneAtIndex (SceneToLoadOnEnd);
            }
        }
    }
}
