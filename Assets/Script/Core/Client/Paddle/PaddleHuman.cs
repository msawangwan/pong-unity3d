using UnityEngine;

namespace mUnityFramework.Pong {
    public class PaddleHuman : Paddle {
        protected override bool ServeBall () {
            if (Input.GetKeyDown (KeyCode.Space)) {
                return true;
            }
            return false;
        }

        protected override Vector3 CalculateHorizontalMoveForce (float paddleMoveSpeed) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                return (Vector3.left * paddleMoveSpeed);
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                return (Vector3.right * paddleMoveSpeed);
            }

            return Vector3.zero;
        }
    }
}