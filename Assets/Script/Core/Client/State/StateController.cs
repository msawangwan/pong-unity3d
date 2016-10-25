using UnityEngine;

public class StateController : MonoBehaviour {
    private State currentState = null;
    private Game game = null;

    private System.Action<string> log;

    private void Start () {
        log = msg => { Debug.LogFormat("current state is in: {0}", msg); };
    }

    private void Update () {
        if (currentState == null) {
            currentState = new StateSpawnNewSession (null);
            return;
        } else {
            if (currentState.DoneEnter == false) {
                StateContext<Game> stateEntered = currentState.OnEnterState();
                log("state enter");
                return;
            }

            if (currentState.DoneUpdate == false) {
                StateContext<Game> updatedState = currentState.OnUpdateState();
                log("state update");
                return;
            }

            if (currentState.DoneExit == false) {
                StateContext<Game> stateExited = currentState.OnExitState();
                log("state exit");
                return;
            }
        }
    }
}
