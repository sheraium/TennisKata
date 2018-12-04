using System.Collections.Generic;

namespace TennisKata
{
    public class TennisGame
    {
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
            {
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" },
            };

        private int _secondPlayerSocreTimes;

        public string Score()
        {
            if (_secondPlayerSocreTimes == 1)
            {
                return "Love Fifteen";
            }
            if (_firstPlayerScoreTimes > 0)
            {
                return _scoreLookup[_firstPlayerScoreTimes] + " Love";
            }

            return "Love All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public void SecondPlayerScore()
        {
            _secondPlayerSocreTimes++;
        }
    }
}