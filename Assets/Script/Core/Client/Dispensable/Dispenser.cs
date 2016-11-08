using UnityEngine;

namespace mUnityFramework.Game.Pong {
    [RequireComponent(typeof(EdgeCollider2D))]
    public class Dispenser : MonoBehaviour {
        public GameObject CoinPrize = null;

        private EdgeCollider2D cachedEc = null;

        private EdgeCollider2D ec {
            get {
                if (! cachedEc) {
                    cachedEc = GetComponent<EdgeCollider2D>();
                }
                return cachedEc;
            }
        }

        private void OnTriggerEnter2D (Collider2D c) {
            Ball b = c.GetComponent<Ball>();

            if (b) {
                Instantiate (CoinPrize, c.gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
