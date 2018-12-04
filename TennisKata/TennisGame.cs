using System.Collections.Generic;

namespace TennisKata
{
    public class TennisGame
    {
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
            {
                {0,"Love" },
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" },
            };

        private int _secondPlayerSocreTimes;

        public string Score()
        {
            if (IsDifferent())
            {
                return NormalScore();
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

        private bool IsDifferent()
        {
            return _firstPlayerScoreTimes != _secondPlayerSocreTimes;
        }

        private string NormalScore()
        {
            return _scoreLookup[_firstPlayerScoreTimes] + " " + _scoreLookup[_secondPlayerSocreTimes];
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