using UnityEngine;

public class WallManager : MonoBehaviour {
    public static WallManager StaticInstance = null;

	/* calculate the wrap threshold x value of the left and right screen borders, represented by the left and right walls and adjust based on the paddle length  */
    public static float[] CalculateVerticalLeftAndRightWrapBounds (float paddleColliderLength) {
        float xComponentLeftWallPositionAdjusted = WallVertical.Instances [0].transform.position.x;
        float xComponentRightWallPositionAdjusted = WallVertical.Instances [1].transform.position.x;

        if (xComponentLeftWallPositionAdjusted > xComponentRightWallPositionAdjusted) { // means left == right and right == left, aka backwards
            float[] walls = UtilCommon.Swap (xComponentLeftWallPositionAdjusted, xComponentRightWallPositionAdjusted);
            xComponentLeftWallPositionAdjusted = walls[0];
            xComponentRightWallPositionAdjusted = walls[1];
        }

        xComponentLeftWallPositionAdjusted -= paddleColliderLength;
        xComponentRightWallPositionAdjusted += paddleColliderLength;

        return new float[] { xComponentLeftWallPositionAdjusted, xComponentRightWallPositionAdjusted };
    }

	private void Awake () {
        StaticInstance = this;
    }
}
