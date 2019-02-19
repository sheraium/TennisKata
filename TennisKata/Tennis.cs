using System.Collections.Generic;

namespace TennisKata
{
    public class Tennis
    {
        private readonly string _firstPlayer;
        private readonly string _secondPlayer;
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0,"Love" },
            {1,"Fifteen" },
            {2,"Thirty" },
            {3,"Forty" },
        };

        private int _secondPlayerScoreTimes;

        public Tennis(string firstPlayer, string secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        public string Score()
        {
            if (IsDifferentScore())
            {
                if (_firstPlayerScoreTimes == 4 || _secondPlayerScoreTimes == 4)
                {
                    return AdvPlayer() + " Adv";
                }

                return $"{_scoreLookup[_firstPlayerScoreTimes]} {_scoreLookup[_secondPlayerScoreTimes]}";
            }

            if (_firstPlayerScoreTimes >= 3)
            {
                return "Deuce";
            }
            return _scoreLookup[_firstPlayerScoreTimes] +
                   " All";
        }

        private bool IsDifferentScore()
        {
            return _firstPlayerScoreTimes != _secondPlayerScoreTimes;
        }

        private string AdvPlayer()
        {
            var advPlayer = _firstPlayerScoreTimes > _secondPlayerScoreTimes
                ? _firstPlayer
                : _secondPlayer;
            return advPlayer;
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