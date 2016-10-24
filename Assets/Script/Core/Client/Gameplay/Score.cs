using UnityEngine;

[System.Serializable]
public struct Score {
    [SerializeField] private int assignedValue;
	public int Value { get { return assignedValue; } }

	public Score (int val) {
        this.assignedValue = val;
    }

	public static Score ToTotal (Point a, Point toAdd) {
        return new Score (a.Value + toAdd.Value);
    }
}
