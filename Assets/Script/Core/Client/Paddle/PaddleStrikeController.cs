using UnityEngine;

public class PaddleStrikeController : MonoBehaviour {
    public System.Action RaiseOnStruckBall { get; set; }

    private Paddle paddle = null;
    private Player.PlayerID player = Player.PlayerID.None;

    private void Start () {
        paddle = gameObject.GetComponent<Paddle>();
    }

    void OnCollisionEnter2D (Collision2D c) {
        Ball ball = c.gameObject.GetComponent<Ball>();

        if (ball != null) {
            player = paddle.AssignedPlayer;
            Vector3 f = ball.CalculateEnglish (player, ball.transform.position, transform.position, paddle.ColliderLength);
            ball.RB.AddForce(f);
            ball.LastToHit = player;

            RaiseOnStruckBall = () => { 
                Debug.LogFormat ("struck by {0}", ball.LastToHit); 
            };
        }

        RaiseOnStruckBall.InvokeSafe ();
    }
}
