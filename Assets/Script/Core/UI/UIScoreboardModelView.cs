using UnityEngine;
using UnityEngine.UI;

namespace mUIFramework.mvc {
    using Category = UIScoreboardController.ScoreCategory;

    public class UIScoreboardModelView : MonoBehaviour {
        public GameObject Scoreboard          = null;

        [SerializeField] private Text       FieldPointsScoredP1 = null;
        [SerializeField] private Text       FieldRoundsWonP1    = null;
        [SerializeField] private Text       FieldGamesWonP1     = null;

        [SerializeField] private Text       FieldPointsScoredP2 = null;
        [SerializeField] private Text       FieldRoundsWonP2    = null;
        [SerializeField] private Text       FieldGamesWonP2     = null;

        private void HandleOnUpdateScoreBoard (int p1, int p2, Category category) {
            Category cat = (Category) category;
            switch (cat) {
                case Category.Point:
                    FieldPointsScoredP1.text = string.Format("{0}", p1);
                    FieldPointsScoredP2.text = string.Format("{0}", p2);
                    break;
                case Category.Round:
                    FieldRoundsWonP1.text = string.Format("{0}", p1);
                    FieldRoundsWonP2.text = string.Format("{0}", p2);
                    break;
                case Category.Game:
                    FieldGamesWonP1.text = string.Format("{0}", p1);
                    FieldGamesWonP2.text = string.Format("{0}", p2);
                    break;
                default:
                    break;
            }
        }

        private void Awake () {
            Scoreboard.Disable ();
        }

        private void OnEnable() {
            UIScoreboardController.RaiseScoreboardUpdated += HandleOnUpdateScoreBoard;
        }

        private void OnDisable() {
            UIScoreboardController.RaiseScoreboardUpdated -= HandleOnUpdateScoreBoard;
        }
    }
}
