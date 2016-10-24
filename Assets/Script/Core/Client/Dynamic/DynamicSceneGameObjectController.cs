using UnityEngine;

public class DynamicSceneGameObjectController : MonoBehaviour {
    public static DynamicSceneGameObjectController StaticInstance = null;
	public static Transform Container { get { return StaticInstance.transform; } }

	private void Awake () {
        StaticInstance = this;
    }
}
