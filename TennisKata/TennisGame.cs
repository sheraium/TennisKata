using System;
using System.Collections.Generic;

namespace TennisKata
{
    public class TennisGame
    {
        private readonly string _firstPlayer;
        private readonly string _secondPlayer;
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
            {
                {0,"Love" },
                { 1,"Fifteen"},
                {2,"Thirty" },
                {3,"Forty" },
            };

        private int _secondPlayerScoreTimes;

        public TennisGame(string firstPlayer, string secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public string Score()

        {
            if (_firstPlayerScoreTimes != _secondPlayerScoreTimes)
            {
                if (_firstPlayerScoreTimes >= 3 && _secondPlayerScoreTimes >= 3)
                {
                    if (Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1)
                    {
                        return _firstPlayer + " Adv";
                    }
                }
                return _scoreLookup[_firstPlayerScoreTimes] + " " + _scoreLookup[_secondPlayerScoreTimes];
            }

            return IsDeuce() ? Deuce() : SameScore();
        }

        private string SameScore()
        {
            return _scoreLookup[_firstPlayerScoreTimes] + " All";
        }

        private bool IsDeuce()
        {
            return _firstPlayerScoreTimes >= 3;
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScoreTimes++;
        }
    }
}