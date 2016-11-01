using UnityEngine;

namespace mGameFramework.Core {
    public class SessionController : MonoBehaviour {
        public static SessionController Singleton = null;

        public bool isAleadyActive { get; private set; }

        public static Session SpawnNew () {
            return Session.New (true);
        }

        private void Awake () {
            Singleton = this;
        }
    }
}
