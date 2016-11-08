using UnityEngine;

namespace mUnityFramework.Game.Pong {
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingWall : Wall {
        [SerializeField] private float weight = 1000;
        [SerializeField] private float downwardPressure = 10.0f;

        private GameController gc = null;

        private Rigidbody2D cachedRb = null;
        private Rigidbody2D rb {
            get {
                if (! cachedRb) {
                    cachedRb = GetComponent<Rigidbody2D>();
                }
                return cachedRb;
            }
        }

        private float downForce {
            get {
                return Mathf.Abs(downwardPressure) * -1f;
            }
        }

        public void PushUp () {
            if (rb) {
                rb.AddForce (new Vector3 (0, downForce * 0.5f * -1f, 0));
            }
        }

        private void Start () {
            rb.mass = weight;
        }

        private void FixedUpdate () {
            if (! gc) {
                gc = GameController.Instance;
            }

            switch (gc.ControllerState) {
                case GameController.State.Block:
                    return;
                case GameController.State.Continue:
                    rb.AddForce (new Vector3 (0, downForce, 0));
                    return;
                default:
                    return;
            }
        }
    }
}
