﻿using UnityEngine;

namespace mUnityFramework.Game.Pong {
	public class PaddleLauncherBehaviour : PaddleBehaviour {
		public PowerMeter powerMeter;
		public bool isServing = true;

		private Ball ball = null;
		private int state = 0;

		private System.Func<float> LaunchPower () {
			if (Input.GetKeyUp(KeyCode.Space)) { // todo: restrict move!!!
				return () => { 
					return powerMeter.Level; 
				};
			} else if (Input.GetKey(KeyCode.Space)) {
				powerMeter.Level += 1.0f * Time.deltaTime;
				return null;
			} else {
				return null;
			}
		}

		private bool IsOutOfBounds (float xPos) {
			return ((xPos - paddle.Surface.Length) <= WallManager.S.LeftWallPosition.x) || 
				((xPos + paddle.Surface.Length) >= WallManager.S.RightWallPosition.x);
		}

		private bool Launch (Ball b, Vector3 lForce) {
			if (! IsOutOfBounds (transform.position.x)) {
				b.transform.SetParent (DynamicGameObjectSceneManager.Container);

				b.Rb.isKinematic = false;

				b.Force.SetVelocityTo(lForce);

				b.Tr.Clear();
				b.Tr.enabled = true;

				Debug.DrawRay(transform.position, lForce, Color.cyan, 5.0f);

				return true;
			}
			return false;
		}

		private Vector3 DeriveLaunchForce (Ball ball, float multiplierPercentage = 0.0f, float steepness = 0.0f) {
			return new Vector3 (
				rb.velocity.x * (
					paddle.Property.LaunchPowerScalar + (
						paddle.Property.LaunchMaximumMultiplier * Mathf.Clamp01 (
							multiplierPercentage
							)
						)
					), 
				paddle.Property.LaunchSteepness,
				0f
			) * ball.Rb.mass;
		}

		public void LaunchUpdate () {
			switch (paddle.PaddleState) {
				case Paddle.State.Serve:
					if (isServing) {
						if (state == 0) {
							if (! ball) {
								ball = BallManager.S.CurrentBall;
							}
							state = 1;
						}

						if (state == 1) {
							ball.Controller.ToLaunchState (
								paddle.transform, 
								paddle.Property.LaunchOffset
							);
							state = 2;
						}

						if (state == 2) {
							System.Func<float> onLaunchGetPowerReading = LaunchPower();
							if (onLaunchGetPowerReading != null) {
								float power = onLaunchGetPowerReading();
								bool hasServed = Launch (
									ball, 
									DeriveLaunchForce (ball, power)
								);

								if (hasServed) {
									state = 0;
									isServing = false;
									powerMeter.Level = 0f;
									paddle.PaddleState = Paddle.State.Play;
								}
							} 
						}
					} else {
						paddle.PaddleState = Paddle.State.Play;
					}
					return;
				case Paddle.State.Play:
					return;
				default:
					return;
			}
		}
	}
}