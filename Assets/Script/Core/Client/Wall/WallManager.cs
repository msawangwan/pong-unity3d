using UnityEngine;
using System;
using System.Collections.Generic;

public class WallManager : MonoBehaviour {
    public static WallManager StaticInstance = null;

    public Func<Player.PlayerID> onBallEnteredScoreZone { get; set; }

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

    public static void BallEnteredScoreZone(Player.PlayerID attackingPlayerPID) {
        mStateFramework.Core.StateWaitUntilPointScore.onScore = () => {
            return attackingPlayerPID;
        };
    }

	private void Awake () {
        StaticInstance = this;
    }
}
