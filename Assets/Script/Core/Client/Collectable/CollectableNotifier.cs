using UnityEngine;
using System;

public class CollectableNotifier : MonoBehaviour {
	public static Action<int> RaisedOnCollectableCollected { get; set; }

    public void onCollectableCollected (int pointValue) {
		if (RaisedOnCollectableCollected != null) {
			RaisedOnCollectableCollected (pointValue);
		}
	}
}
