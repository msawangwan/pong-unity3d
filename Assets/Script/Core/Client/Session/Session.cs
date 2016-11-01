using UnityEngine;
using System.Collections.Generic;

namespace mGameFramework.Core {
    public class Session {
        public static Session NullSession = Session.New (false);

        public  IEnumerable<Game> Games { get { return games; } }
        public bool IsValid { get { return isValid; } }

        private  List<Game> games = new List<Game> ();
        private bool isValid = true;

        private Session (bool isValid) {
            this.isValid = isValid;
        }

        public static Session New (bool isValid) {
            return new Session (isValid);
        }
    }
}