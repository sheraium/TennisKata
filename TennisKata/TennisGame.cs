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
                if (IsReadyForWin())
                {
                    return AdvPlayer() + (IsAdv() ? " Adv" : " Win");
                }

                return NormalScore();
            }

            return IsDeuce() ? Deuce() : SameScore();
        }

        private string AdvPlayer()
        {
            return _firstPlayerScoreTimes > _secondPlayerScoreTimes
                ? _firstPlayer : _secondPlayer;
        }

        private bool IsReadyForWin()
        {
            return _firstPlayerScoreTimes >= 3 && _secondPlayerScoreTimes >= 3;
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1
                   && _firstPlayerScoreTimes != 5 && _secondPlayerScoreTimes != 5;
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDeuce()
        {
            return _firstPlayerScoreTimes >= 3;
        }

        private string SameScore()
        {
            return _scoreLookup[_firstPlayerScoreTimes] + " All";
        }

        private string NormalScore()
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