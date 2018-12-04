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

        private int _secondPlayerSocreTimes;

        public TennisGame(string firstPlayer, string secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        public string Score()
        {
            return IsDifferent() ? IsReadyForWin() ? AdvPlayer() + (IsAdv() ? " Adv" : " Win") :
                NormalScore() :
                IsDeuce() ? Deuce() : SameScore();
        }

        private bool IsReadyForWin()
        {
            return _firstPlayerScoreTimes >= 3 & _secondPlayerSocreTimes >= 3;
        }

        private string AdvPlayer()
        {
            return _firstPlayerScoreTimes > _secondPlayerSocreTimes
                ? _firstPlayer : _secondPlayer;
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScoreTimes - _secondPlayerSocreTimes) == 1
                   && _firstPlayerScoreTimes != 5 && _secondPlayerSocreTimes != 5;
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