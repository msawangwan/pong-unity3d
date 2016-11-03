using UnityEngine;
using System.Collections.Generic;

public class PaddleServeController : MonoBehaviour {
    private Paddle paddleCached = null;
    private Paddle paddle {
        get {
            if (paddleCached == null) {
                paddleCached = gameObject.GetComponent<Paddle>();
            }
            return paddleCached;
        }
    }

    public Vector3 CalculateServiceForce (Paddle server, float serveForceMultiplier = 300.0f, float maxServeForce = 50.0f) { // paddleForceInfluence = input x
        Vector3 lateralMoveForce = server.RB.velocity.Truncate(maxServeForce);
        return new Vector3(lateralMoveForce.x, serveForceMultiplier, 0.0f);
    }

    public bool SetForService (Paddle server, Ball ball, float offset = 0.3f) {
        if (ball != null) {
            Vector3 ballPosition = server.transform.position + new Vector3 (0.0f, offset, 0.0f);
            Ball.ResetAndPositionAt (transform, ball, ballPosition);
            ball.gameObject.SetActive (true);
            return true;
        }
        return false;
    }

    public bool Serve (Ball ball, Vector3 momentumForce) { // idea: use a fixed trigger area instead of calculating the bounds to check if player is on screen when serving
        if (ball != null) {
            if (ball.RB != null) {
                float xPos = paddle.transform.position.x;

                bool leftSideScreenCheck = ((xPos - paddle.ColliderLength) <= paddle.LeftSideScreenBoundry);
                bool rightSideScreenCheck = ((xPos + paddle.ColliderLength) >= paddle.RightSideScreenBoundry);

                if (leftSideScreenCheck || rightSideScreenCheck) {
                    return false;
                } else {
                    ball.transform.SetParent (DynamicSceneGameObjectController.Container);

                    ball.RB.isKinematic = false;
                    ball.RB.AddForce(momentumForce * ball.RB.mass, ForceMode2D.Impulse);

                    ball.TR.Clear ();
                    ball.TR.enabled = true;

                    return true;
                }
            }
        }     
        return false;
    }

    public Vector3 Tether() { // TEMP FUNCTION, MOVE ELSE WHERE??
        Debug.Log(gameObject.name + " " +  Time.time);
        Vector3 root = Vector3.zero;
        List<WallSurface> ws = WallSurface.Horizontals as List<WallSurface>;
        foreach (WallSurface wall in ws) {
            if (wall.GetComponent<WallScoreZone>().DefendingPlayer == paddle.AssignedPlayer) {
                Debug.Log("assigned " + paddle.AssignedPlayer + " to  " + wall.name);
                return wall.transform.position;
            }
        }
        return root;
    }

    public Vector3 CalcTheta() { // SKETCHING IDEAS
        List<WallSurface> ws = WallSurface.Verticals as List<WallSurface>;
        EdgeCollider2D wallcol = ws[0].GetComponent<EdgeCollider2D>();
        float wallMidpoint = wallcol.points[1].y + wallcol.points[0].y;
        float xLeftWall = ws[0].transform.position.x;
        float xRightWall = ws[1].transform.position.x;
        float paddleMidpoint = paddle.ColliderMidpoint;
        float xPaddle = paddle.transform.position.x;
        Vector3 leftWallMidpoint = new Vector3(xLeftWall, wallMidpoint, 0.0f);
        Vector3 rightWallMidpoint = new Vector3(xRightWall, wallMidpoint, 0.0f);
        Vector3 leftWallBasepoint = new Vector3(xLeftWall, paddle.transform.position.y, 0.0f);
        Vector3 rightWallBasepoint = new Vector3(xRightWall, paddle.transform.position.y, 0.0f);
        Vector3 p = new Vector3(xPaddle, paddle.transform.position.y, 0);
        // Debug.DrawLine(p, leftWallMidpoint, Color.red);
        // Debug.DrawLine(p, leftWallBasepoint, Color.yellow);
        // Debug.DrawLine(p, rightWallMidpoint, Color.red);
        // Debug.DrawLine(p, rightWallBasepoint, Color.yellow);
        Vector3 leftHypot = leftWallMidpoint - paddle.transform.position;
        Vector3 rightHypot = rightWallMidpoint - paddle.transform.position;
        Debug.DrawRay(paddle.transform.position, leftHypot);
        Debug.DrawRay(paddle.transform.position, rightHypot);
        // Vector3
        Debug.DrawLine(paddle.transform.position, Vector3.zero, Color.green, 0.01f);
        return leftHypot;
    }

    Vector3 tetherBase;

    private void OnEnable () {
        tetherBase = Tether();
    }

    private void Update() {
        Debug.DrawLine(tetherBase, paddle.transform.position, Color.magenta);
    }
}