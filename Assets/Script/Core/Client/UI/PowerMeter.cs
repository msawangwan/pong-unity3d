using UnityEngine;
using UnityEngine.UI;

public class PowerMeter : MonoBehaviour {
	private Slider slider = null;

	public float Level {
		get {
			if (! slider) {
                slider = GetComponent<Slider>();
            }
            return slider.value;
        }

		set {
			if (! slider) {
                slider = GetComponent<Slider>();
            }
            slider.value = value;
        }
	}
}
