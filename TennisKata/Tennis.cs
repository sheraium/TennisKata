using System.Collections.Generic;

namespace TennisKata
{
    public class Tennis
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
                return NormalScore();
            }

            if (_firstPlayerScoreTimes == 3)
            {
                return "Deuce";
            }
            return SameScore();
        }

        private string SameScore()
        {
            return _scoreLookup[_firstPlayerScoreTimes] + " All";
        }

        private bool IsDifferent()
        {
            return _firstPlayerScoreTimes != _secondPlayerScoreTimes;
        }

        private string NormalScore()
        {
            return _scoreLookup[_firstPlayerScoreTimes] + " " + _scoreLookup[_secondPlayerScoreTimes];
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