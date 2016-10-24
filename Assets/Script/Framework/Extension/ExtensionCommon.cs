using UnityEngine;

public static class ExtensionCommon {
	public static void InvokeSafe(this System.Action invoker) {
		if (invoker != null) {
            invoker();
        }
	}
	public static void InvokeSafe<T>(this System.Action<T> invoker, T arg) {
		if (invoker != null) {
            invoker(arg);
        }
	}

	public static bool InvokeSafe (this System.Func<bool> invoker) {
		if (invoker != null) {
            return invoker();
        }
        return false;
    }

	public static int InvokeSafe (this System.Func<int> invoker) {
		if (invoker != null) {
            return invoker();
        }
        return 0;
    }

	public static T InvokeSafe<T> (this System.Func<T> invoker) where T : class {
		if (invoker != null) {
            return invoker();
        }
        return null;
    }

	public static bool InvokeSafe<T> (this System.Func<T, bool> invoker, T arg) {
		if (invoker != null) {
            return invoker(arg);
        }
        return false;
    }
}
