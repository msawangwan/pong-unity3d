using UnityEngine;
using UnityEngine.UI;

public class UIGameScoreController : MonoBehaviour {
    public GameObject MatchHUDContainerGameObject = null;
    public Text TopPlayerScore = null;
    public Text BottomPlayerScore = null;

    private int p1Score = 0; // todo: seperate data from view
    private int p2Score = 0;

    public void UpdateScoreBoard (int p1, int p2) {
        BottomPlayerScore.text = string.Format("{0}", p1);
        TopPlayerScore.text = string.Format("{0}", p2);
	}

    private void ClearScoreboard () {
        BottomPlayerScore.text = "0";
        TopPlayerScore.text = "0";
    }

    private void Start () {
        MatchHUDContainerGameObject.Disable ();
        ClearScoreboard ();
    }
}
