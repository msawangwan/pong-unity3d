using UnityEngine;

public class StateController : MonoBehaviour {
    private State currentState = null;
    private Game game = null;
    private int goInt = -100;

    private System.Action<string> log;

    private void Awake () {
        GlobalMediator.RaiseOnNewGameStarted += () => goInt = 0;
    }

    private void Start () {
        log = msg => Debug.LogFormat("current state is in: {0}", msg);
    }

    private void Update () {
        if (goInt != 0) {
            return;
        }

        if (currentState == null) {
            currentState = new StateSpawnNewSession (new StateContext<Game>(null, true));
            return;
        } else {
            log("state enter bool " + currentState.DoneEnter);
            if (currentState.DoneEnter == false) {
                currentState = currentState.OnEnterState();
                log("state enter");
                log("state enter bool after  " + currentState.DoneEnter);
                return;
            }

            if (currentState.DoneUpdate == false) {
                currentState= currentState.OnUpdateState();
                log("state update");
                return;
            }

            if (currentState.DoneExit == false) {
                currentState = currentState.OnExitState();
                log("state exit");
                return;
            }
        }
    }
}
