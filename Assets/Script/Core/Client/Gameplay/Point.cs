using UnityEngine;

[System.Serializable]
public struct Point {
    [SerializeField] private int assignedValue;
	public int Value { get { return assignedValue; } }

	private Point (int val) {
        this.assignedValue = val;
    }

	public static Point Add0 (int a = 0) {
        return new Point(a + 0);
    }

	public static Point Add1 (int a) {
        return new Point(a + 1);
    }

	public static Point Sum2 (int a, int b) {
        return new Point(a + b);
    }
}