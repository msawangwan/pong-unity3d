using UnityEngine;

namespace mStateFramework.Core {
    public class StateManager : MonoBehaviour {
        public SessionStateController sessionState = null;
        public GameStateController gameState = null;

        private void Start () {
            System.Func<int, int> onEndSendBackwinner = (winnerID) => {
                return winnerID;
            };
            GlobalMediator.RaiseOnNewGameStarted +=
                () => sessionState.BeginStartController(onEndSendBackwinner);
        }
    }
}
