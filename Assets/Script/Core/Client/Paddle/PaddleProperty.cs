using UnityEngine;

namespace mUnityFramework.Game.Pong {
    public class PaddleProperty : MonoBehaviour {
        [SerializeField] private float horizontalPosition = 0.0f;

        [SerializeField] private float horizontalMoveForceMultiplier = 1.0f;
        [SerializeField] private float maximumAttainableMoveForce = 10.0f;

        [SerializeField] private float launchPowerScalar = 1.0f;
        [SerializeField] private float launchSteepness = 2.0f;
        [SerializeField] private float launchMaximumMultiplier = 0.0f;
        [SerializeField] private float launchOffset = 0.3f;

        public float hPosition { 
            get {
                return Mathf.Abs (horizontalPosition) * -1.0f;
            }
        }

        public float hMoveForceMultiplier {
            get {
                return horizontalMoveForceMultiplier;
            }
        }

        public float MaxAttainableMoveForce {
            get {
                return maximumAttainableMoveForce;
            }
        }

        public float LaunchPowerScalar {
            get {
                return launchPowerScalar;
            }
        }

        public float LaunchSteepness {
            get {
                return launchSteepness;
            }
        }

        public float LaunchMaximumMultiplier {
            get {
                return launchMaximumMultiplier;
            }
        }

        public float LaunchOffset {
            get {
                return launchOffset;
            }
        }
    }
}