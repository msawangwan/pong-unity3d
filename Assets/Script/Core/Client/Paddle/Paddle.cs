﻿using UnityEngine;
using mExtensions.Common;
using System.Collections.Generic;

/// <summary>
/// base class for a paddle gameObject
/// </summary>

namespace mUnityFramework.Pong {
    [RequireComponent(typeof(EdgeCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PaddleServeController))]
    [RequireComponent(typeof(PaddleStrikeController))]
    public abstract class Paddle : MonoBehaviour {
        [System.Serializable]
        public class PaddleParamters {
            public Paddle.PaddleID PID                   = Paddle.PaddleID.None;
            [RangeAttribute(00.01f, 100.00f)]
            public float  HorizontalMoveForceMultiplier  = 3.0f;
            public float  FixedHorizontalPosition        = 0.0f; // y position
            public float  MaximumHorizontalMoveForce = 10.0f;
        }

        public enum PaddleID : int { 
            None = 0,
            Bottom, 
            Top,
        }

        public enum GameState : int { 
            None = 0,
            Menu,
            Enter, 
            Idle,
            Serve, 
            Play, 
            Exit,
        }

        private static List<Paddle>      instances        = new List<Paddle>();
        public static IEnumerable<Paddle> Instances { get { return instances; } }

        public Player.PlayerID AssignedPlayer { 
            get {
                return assignedPlayer;
            }

            set {
                assignedPlayer = value;
            } 
        }

        public PaddleSurface Surface {
            get {
                if (surface.IsNull()) {
                    surface = gameObject.GetComponent<PaddleSurface>();
                }
                return surface;
            }
        }

        public PaddleServeController ServeController {
            get {
                if (serveController == null) {
                    serveController = gameObject.GetComponentSafe<PaddleServeController> ();
                }
                return serveController;
            }
        }

        public PaddleStrikeController StrikeController {
            get {
                if (serveController == null) {
                    strikeController = gameObject.GetComponentSafe<PaddleStrikeController> ();
                }
                return strikeController;
            }
        }

        public Rigidbody2D RB {
            get {
                if (rb == null) {
                    rb = gameObject.GetComponent<Rigidbody2D> ();
                }
                return rb;
            }
        }

        public TrailRenderer TR {
            get {
                if (tr == null) {
                    tr = gameObject.GetComponentInChildren<TrailRenderer> ();
                    if (tr == null) {
                        err (gameObject.name + ": null trail renderer");
                    }
                }
                return tr;
            }
        }

        public Vector3 ColliderOrthogonal {
            get {
                return Surface.Orthogonal;
            }
        }

        public float ColliderLength {
            get {
                return Surface.Length;
            }
        }

        public float ColliderMidpoint {
            get {
                return Surface.Length * 0.5f;
            }
        }

        public          PaddleParamters        Parameters       = null;

        protected const string                 kHAxis           = "Horizontal";

        protected       System.Action<string>  log              = (msg) => Debug.LogFormat ("[info][paddle] {0}", msg);
        protected       System.Action<string>  err              = (msg) => Debug.LogErrorFormat ("[error][paddle] {0}", msg);

        protected       Player.PlayerID        assignedPlayer   = Player.PlayerID.None;
        protected       Ball                   ball             = null;

        private         PaddleSurface          surface          = null;
        private         PaddleServeController  serveController  = null;
        private         PaddleStrikeController strikeController = null;
        private         Rigidbody2D            rb               = null;
        private         TrailRenderer          tr               = null;
        private         int                    serveState       = 0;
        private         int                    playState        = 0;
        private         float                  xLeftWrapBound   = 0.0f;
        private         float                  xRightWrapBound  = 0.0f;
        private         bool                   isInServePhase   = false;
        private         bool                   isInPlayPhase    = false;
        private         bool                   isSetAsServing   = false;
        private         bool                   hasServed        = false;

        public float LeftSideScreenBoundry { 
            get {
                return xLeftWrapBound;
            }
        }

        public float RightSideScreenBoundry { 
            get {
                return xRightWrapBound;
            }
        }

        public bool IsInServePhase {
            get {
                return isInServePhase;
            }
            set {
                isInServePhase = value;
            }
        }

        public bool IsInPlayPhase {
            get {
                return isInPlayPhase;
            }
            set {
                isInPlayPhase = value;
            }
        }

        public bool HasServed {
            get {
                return hasServed;
            }
            set {
                hasServed = value;
            }
        }

        public bool IsSetAsServing {
            get {
                return isSetAsServing;
            }
            set {
                isSetAsServing = value;
            }
        }

        private float hForceMultiplier { 
            get { 
                return Parameters.HorizontalMoveForceMultiplier; 
            } 
        }

        protected abstract bool ServeBall ();
        protected abstract Vector3 CalculateHorizontalMoveForce (float paddleMoveSpeed);

        private Vector3 WrapPositionIfOffScreen (float xComponentCurrentPosition) {
            float xInverted = xComponentCurrentPosition * -1.0f; // sign flip
            if ((xComponentCurrentPosition - ColliderMidpoint) < xLeftWrapBound) {
                TR.Clear ();
                return new Vector3 (xInverted - ColliderLength, Parameters.FixedHorizontalPosition, 0.0f);
            } else if ((xComponentCurrentPosition + ColliderMidpoint) > xRightWrapBound) {
                TR.Clear ();
                return new Vector3 (xInverted + ColliderLength, Parameters.FixedHorizontalPosition, 0.0f);
            } else {
                return transform.position;
            }
        }

        private void Awake () {
            instances.Add (this);
        }

        private void Start () {
            float[] wallBounds = WallManager.CalculateVerticalLeftAndRightWrapBounds (ColliderLength);
            xLeftWrapBound = wallBounds[0];
            xRightWrapBound = wallBounds[1];
        }

        private void Update () {
            if (isInServePhase == true && isSetAsServing == true) {
                log(string.Format("{0} in serve phase loop", AssignedPlayer));

                if (serveState == 0) {
                    if (ball == null) {
                        ball = BallManager.StaticInstance.CurrentBall;
                    }
                    serveState = 1;
                }

                if (serveState == 1) {
                    ServeController.SetForService (this, ball);
                    serveState = 2;
                }

                if (serveState == 2) {
                    hasServed = ServeBall ();
                    if (hasServed == true) {
                        bool served = ServeController.Serve (
                            ball, 
                            ServeController.ServeForce ()
                        );

                        if (served) {
                            isSetAsServing = false;
                            isInServePhase = false;
                            isInPlayPhase = true;
                            serveState = 0;
                        }
                    }
                }

                return;
            } else {
                isInPlayPhase = true;
            }

            if (isInPlayPhase == true) {
                log(string.Format("{0} in play phase loop", AssignedPlayer));

                if (playState == 0)  {
                    playState = 1;
                    return;
                }

                if (playState == 1) {
                    return;
                }
            }
        }

        private void FixedUpdate () {
            RB.AddForce(CalculateHorizontalMoveForce(hForceMultiplier).Truncate(Parameters.MaximumHorizontalMoveForce));
            transform.position = WrapPositionIfOffScreen (transform.position.x);
        }

        private void OnEnable () {
            transform.position = Parameters.FixedHorizontalPosition.AsVectorComponenty ();
        }
    }
}