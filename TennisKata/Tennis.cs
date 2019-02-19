using System.Collections.Generic;

namespace TennisKata
{
    public class Tennis
    {
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {1,"Fifteen" },
            {2,"Thirty" },
        };

        public string Score()
        {
            if (_firstPlayerScoreTimes == 2 || _firstPlayerScoreTimes == 1)
            {
                return _scoreLookup[_firstPlayerScoreTimes] +
                       " Love";
            }
            if (_firstPlayerScoreTimes == 3)
            {
                return "Forty Love";
            }

            return "Love All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }
    }
}