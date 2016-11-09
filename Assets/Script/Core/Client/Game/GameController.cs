using UnityEngine;
using mUnityFramework.Game.Pong;
using System.Collections.Generic;

namespace mUnityFramework.Game {
    public class GameController : MonoBehaviour {
        public enum State {
            None = 0,
            Block,
            Continue,
        }

        private static List<GameController> instances = new List<GameController>();

        public static GameController Instance {
            get {
                return instances[0];
            }
        }

        public Paddle p;
        public int step = -10;

        private float ttl = 2.0f;
        private float timestamp = 0;

        private CountDown countdown = null;
        private bool canContinue = false;

        public GameController.State ControllerState { get; private set; }

        private void Awake () {
            if (instances.Count > 0) {
                instances[0] = this;
            } else {
                instances.Add(this);
            }
        }

        private void Start () {
            ControllerState = GameController.State.Block;
        }

        private void Update () {
            switch (ControllerState) {
                case GameController.State.Block:
                    if (step == -10) {
                        if (countdown == null) {
                            countdown = CountDown.New();
                            countdown.Begin(
                                () => {
                                    canContinue = true;
                                }
                            );
                        }
                        step = -5;
                    }

                    if (step == -5) {
                        if (canContinue) {
                            step = 0;
                            ControllerState = GameController.State.Continue;
                        }
                    }

                    return;
                case GameController.State.Continue:
                    if (step == 0) {
                        p.PaddleState = Paddle.State.Serve;
                        step = 5;
                        return;
                    }

                    if (step == 5) {
                        return;
                    }

                    return;
                default:
                    return;
            }
        }
    }
}
