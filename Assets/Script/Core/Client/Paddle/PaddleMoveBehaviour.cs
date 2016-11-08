using UnityEngine;

namespace mUnityFramework.Game.Pong {
	public class PaddleMoveBehaviour : PaddleBehaviour {
		private Vector3 CalculateHorizontalMoveForce (float multiplier) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				return (Vector3.left * multiplier);
			}

			if (Input.GetKey(KeyCode.RightArrow)) {
				return (Vector3.right * multiplier);
			}

			return Vector3.zero;
		}

		private bool isOffScreen (Vector3 currentPosition) {
			return ((currentPosition.x - surface.hMidpoint) < (WallManager.S.LeftWallPosition.x - surface.Length)) || 
				((currentPosition.x + surface.hMidpoint) > (WallManager.S.RightWallPosition.x + surface.Length));
		}

		public void MoveUpdate () {
			switch (paddle.PaddleStatus) {
				case Paddle.Status.Enabled:
					rb.AddForceMaximum (
						CalculateHorizontalMoveForce (
							property.hMoveForceMultiplier
						), 
						property.MaxAttainableMoveForce
					);

					if (isOffScreen (transform.position)) {
						tr.Clear ();
						rb.position = new Vector3 (
							transform.position.x * -1.0f,
							property.hPosition,
							0f
						);
					}

					return;
				case Paddle.Status.Disabled:
					return;
				default:
					return;
			}
		}
	}
}
