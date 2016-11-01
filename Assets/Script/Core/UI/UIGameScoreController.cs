using UnityEngine;
using UnityEngine.UI;

public class UIGameScoreController : MonoBehaviour {
    public GameObject MatchHUDContainerGameObject = null;
    public Text TopPlayerScore = null;
    public Text BottomPlayerScore = null;

    private int p1Score = 0; // todo: seperate data from view
    private int p2Score = 0;
}
