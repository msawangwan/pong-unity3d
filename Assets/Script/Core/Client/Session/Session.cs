using UnityEngine;
using System.Collections.Generic;

namespace mGameFramework.Core {
    public class Session {
        public static Session NullSession = Session.New (false);

        public  IEnumerable<Game> Games { get { return games; } }
        public bool IsValid { get { return isValid; } }
        public int GameIndex  { get; private set; }

        private List<Game> games = new List<Game> ();
        private bool isValid = true;

        private Session () {
            GameIndex = -1;
        }

        private Session (bool isValid) {
            this.isValid = isValid;
            GameIndex = -1;
        }

        public static Session New () {
            return new Session ();
        }

        public static Session New (bool isValid) {
            return new Session (isValid);
        }

        public int NewGame () {
            games.Add(new Game());
            return ++GameIndex;
        }
    }
}