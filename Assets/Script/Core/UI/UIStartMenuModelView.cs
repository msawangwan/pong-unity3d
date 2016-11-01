using UnityEngine;
using UnityEngine.UI;

namespace mUIFramework.mvc {
	public class UIStartMenuModelView : MonoBehaviour {
        public GameObject StartMenu = null;

		[SerializeField] private Button btnStartNewGame = null;
		[SerializeField] private Button btnGameSettings = null;

		public Button BtnStartNewGame {
			get {
                return btnStartNewGame;
            }
		}

		public Button BtnGameSettings {
			get {
                return btnGameSettings;
            }
		}
    }
}
