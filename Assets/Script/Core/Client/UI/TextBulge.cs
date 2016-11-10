using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace mUnityFramework.UI.Animation {
	public class TextBulge : MonoBehaviour {
        public float animDurationDelat = 0.5f;

        private const string kBulge = "bulge";

        private Animator cachedAnimator;
        private Animator animator {
			get {
				if (! cachedAnimator){
                    cachedAnimator = GetComponent<Animator>();
                }
                return cachedAnimator;
            }
		}

		public void BulgeAnimation () {
            animator.SetTrigger(kBulge);
        }
    }
}