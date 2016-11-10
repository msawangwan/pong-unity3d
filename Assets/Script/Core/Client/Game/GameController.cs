using UnityEngine;
using mUnityFramework.Game.Pong;

namespace mUnityFramework.Game {
    public class GameController : ControllerBehaviour<GameController> {
        public enum State {
            None = 0,
            Enter,
            Execute,
            Exit,
        }

        public ScoreboardModelView scoreboardModelView = null;

        public Paddle p;
        public int step = 0;

        private CountDown countdown = null;
        private bool canContinue = false;

        private Score score = null;

        public GameController.State ControllerState { get; private set; }

        private void HandleOnCollectableNotifierNotify (int pointValue) {
            int pointsCountedSoFar = 1;
            while (pointsCountedSoFar < pointValue + 1 ) {
                score = score.IncrementByOne();
                pointsCountedSoFar += 1;
            }
            scoreboardModelView.WriteScore(score.Total);
        }

        private void Start () {
            ControllerState = GameController.State.Enter;
            score = Score.New();

            if (! scoreboardModelView) {
                scoreboardModelView = ScoreboardModelView.Instance;
            }

            CollectableNotifier.RaisedOnCollectableCollected += HandleOnCollectableNotifierNotify;
        }

        private void Update () {
            switch (ControllerState) {
                case GameController.State.Enter:
                    if (step == 0) {
                        p.PaddleStatus = Paddle.Status.Enabled;

                        if (countdown == null) {
                            countdown = CountDown.New();
                            countdown.Begin(
                                () => {
                                    canContinue = true;
                                }
                            );
                        }

                        step++;
                    }

                    if (step == 1) {
                        if (canContinue) {
                            step = 0;
                            ControllerState = GameController.State.Execute;
                        }
                    }

                    return;
                case GameController.State.Execute:
                    if (step == 0) {
                        p.PaddleState = Paddle.State.Serve;
                        step++;
                        return;
                    }

                    if (step == 1) {
                        return;
                    }

                    return;
                case GameController.State.Exit:
                    return;
                default:
                    return;
            }
        }
    }
}
