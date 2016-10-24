using UnityEngine;

public static class Global {
	public static class UUID {
        private static int currentID = -1;
		public static int NextID { 
			get {
                return ++currentID;
            }
		}
    }
}
