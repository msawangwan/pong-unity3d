namespace mExtensions.Common {
    public static class ExtensionCommon {
        public static bool IsNull (this System.Object o) {
            if (o == null) {
                return true;
            }
            return false;
        }
    }
}
