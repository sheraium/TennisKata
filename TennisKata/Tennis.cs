using System.Collections.Generic;

namespace TennisKata
{
    internal class Tennis
    {
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
            {
                {0,"Love" },
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" },
            };

        private int _secondPlayerScoreTimes;

        public string Score()
        {
            if (IsDifferent())
            {
                return NoramlScore();
            }
            if (_firstPlayerScoreTimes == 2)
            {
                return "Thirty All";
            }
            if (_firstPlayerScoreTimes == 1)
            {
                return "Fifteen All";
            }
            return "Love All";
        }

        private string NoramlScore()
        {
            return _scoreLookup[_firstPlayerScoreTimes] + " " + _scoreLookup[_secondPlayerScoreTimes];
        }

        private bool IsDifferent()
        {
            return _firstPlayerScoreTimes != _secondPlayerScoreTimes;
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScoreTimes++;
        }
    }
}