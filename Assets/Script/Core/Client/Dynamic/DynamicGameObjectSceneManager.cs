using UnityEngine;

public class DynamicGameObjectSceneManager : MonoBehaviour {
	public static DynamicGameObjectSceneManager S = null;

	public static Transform Container {
		get {
			return DynamicGameObjectSceneManager.S.transform;
		}
	}

	private void Awake () {
		S = this;
	}
}