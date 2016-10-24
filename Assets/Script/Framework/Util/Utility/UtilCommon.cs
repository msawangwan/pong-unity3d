using UnityEngine;

public static class UtilCommon {
	public static string[] Swap(string a, string b) {
        return new string[] { b, a };
    }

	public static int[] Swap(int a, int b) {
        return new int[] { b, a };
    }

	public static float[] Swap(float a, float b) {
        return new float[] { b, a };
    }

	public static T[] Swap<T>(T a, T b) where T : class {
        return new T[] { b, a };
    }
}
