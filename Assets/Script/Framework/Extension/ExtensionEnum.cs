using UnityEngine;

namespace mExtensions.Enum {
    public static class ExtensionEnum {
        public static string AsString (this mStateFramework.StateController.Stage e) {
            return e.ToString();
        }

        public static string AsString (this mStateFramework.State<Game>.Stage e) {
            return e.ToString();
        }

        public static int AsInt (this mStateFramework.StateController.Stage e) {
            return (int) e;
        }

        public static int AsInt (this mStateFramework.State<Game>.Stage e) {
            return (int) e;
        }
    }
}
