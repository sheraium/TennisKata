using System;
using System.Collections.Generic;

namespace TennisKata
{
    public class TennisGame
    {
        private readonly string _firstPlayer;
        private readonly string _secondPlayer;
        private int _firstPlayerScoreTimes;
        Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
            {
                {0,"Love" },
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" },
            };

        private int _secondPlayerScoreTimes;

        public TennisGame(string firstPlayer, string secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        public string Score()
        {
            if (IsDifferent())
            {
                if (_firstPlayerScoreTimes>=3&&_secondPlayerScoreTimes>=3)
                {
                    if (IsAdv())
                    {
                        var advPlayer = _firstPlayerScoreTimes > _secondPlayerScoreTimes
                                       ? _firstPlayer : _secondPlayer;
                        return advPlayer + " Adv";
                    }
                }

                return NormalScore();
            }

            return IsDeuce() ? Deuce() : SameScore();
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScoreTimes-_secondPlayerScoreTimes)==1
                   && _firstPlayerScoreTimes!=5&&_secondPlayerScoreTimes!=5;
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDeuce()
        {
            return _firstPlayerScoreTimes>=3;
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