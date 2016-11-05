using UnityEngine;
using System;
using System.Collections.Generic;
// using mUnityFramework.Pong;

public class WallManager : MonoBehaviour {
    public static WallManager StaticInstance = null;

    public Func<Player.PlayerID> onBallEnteredScoreZone { get; set; }

    public float LeftMostVertical = 0.0f;
    public float RightMostVertical = 0.0f;

    public static float[] CalculateVerticalLeftAndRightWrapBounds (float paddleColliderLength) {
        List<WallSurface> ws = WallSurface.Verticals as List<WallSurface>;

        float xComponentLeftWallPositionAdjusted = ws [0].transform.position.x;
        float xComponentRightWallPositionAdjusted = ws [1].transform.position.x;

        if (xComponentLeftWallPositionAdjusted > xComponentRightWallPositionAdjusted) { // means left == right and right == left, aka backwards
            float[] walls = UtilCommon.Swap (xComponentLeftWallPositionAdjusted, xComponentRightWallPositionAdjusted);
            xComponentLeftWallPositionAdjusted = walls[0];
            xComponentRightWallPositionAdjusted = walls[1];
        }

        xComponentLeftWallPositionAdjusted -= paddleColliderLength;
        xComponentRightWallPositionAdjusted += paddleColliderLength;

        return new float[] { xComponentLeftWallPositionAdjusted, xComponentRightWallPositionAdjusted };
    }

    // public Vector3 WrapPosition (Paddle p) {
    //     float xLeft = p.transform.position.x - p.ColliderMidpoint;
    //     float xRight = p.transform.position.x + p.ColliderMidpoint;
    //     float xInverse = p.transform.position.x * -1.0f;

    //     if (xLeft < LeftMostVertical) {
    //         p.TR.Clear();
    //         return new Vector3(xInverse - p.ColliderLength, p.Parameters.FixedHorizontalPosition, 0.0f);
    //     } else if (xRight > RightMostVertical) {
    //         p.TR.Clear();
    //         return new Vector3(xInverse + p.ColliderLength, p.Parameters.FixedHorizontalPosition, 0.0f);
    //     } else {
    //         return transform.position;
    //     }
    // }

    public static void BallEnteredScoreZone(Player.PlayerID attackingPlayerPID) {
        mStateFramework.Core.StateWaitUntilPointScore.onScore = () => {
            return attackingPlayerPID;
        };
    }

	private void Awake () {
        StaticInstance = this;
    }

    private void Start () {
        List<WallSurface> ws = WallSurface.Verticals as List<WallSurface>;

        LeftMostVertical = ws [0].transform.position.x;
        RightMostVertical = ws [1].transform.position.x;

        if (LeftMostVertical > RightMostVertical) {
            float[] walls = UtilCommon.Swap(LeftMostVertical, RightMostVertical);
            LeftMostVertical = walls [0];
            RightMostVertical = walls [1];
        }
    }
}
