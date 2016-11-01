using UnityEngine;
using UnityEngine.UI;
using mExtensions.Common;

namespace mUIFramework.mvc {
    public class UIStartMenuController {
        private UIStartMenuModelView startMenuMV = null;

        public UIStartMenuController(UIStartMenuModelView startMenuMV) {
            this.startMenuMV = startMenuMV;
        }

        public void InitialiseMenuButtons () {
            startMenuMV.BtnStartNewGame.onClick.RemoveAllListeners();
            startMenuMV.BtnStartNewGame.onClick.AddListener(() => {
                GlobalMediator.RaiseOnNewGameStarted.InvokeSafe();
                startMenuMV.StartMenu.Disable();
            });

            startMenuMV.BtnGameSettings.onClick.RemoveAllListeners();
            startMenuMV.BtnGameSettings.onClick.AddListener( () => {
                Debug.LogFormat("SETTINGS NOT IMPLEMENTED YET: {0}", true);
            });
        }
    }
}
