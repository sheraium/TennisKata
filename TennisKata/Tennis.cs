using System;
using System.Collections.Generic;

namespace TennisKata
{
    public class Tennis
    {
        private readonly string _firstPlayer;
        private readonly string _secondPlayer;
        private int _firstPlayerScore;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0,"Love" },
            {1,"Fifteen" },
            {2,"Thirty" },
            {3,"Forty" },
        };

        private int _secondPlayerScore;

        public Tennis(string firstPlayer, string secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        public string Score()
        {
            return IsDifferent() ? IsGamePoint() ? AdvState() : LookupScore() : IsDeuce() ? Deuce() : SameScore();
        }

        private string AdvState()
        {
            if (IsAdv())
            {
                return $"{AdvPlayer()} Adv";
            }

            return $"{AdvPlayer()} Win";
        }

        private bool IsGamePoint()
        {
            return _firstPlayerScore >= 3 && _secondPlayerScore >= 3;
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1;
        }

        private string AdvPlayer()
        {
            return _firstPlayerScore > _secondPlayerScore
                ? _firstPlayer : _secondPlayer;
        }

        private bool IsDeuce()
        {
            return _firstPlayerScore >= 3;
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDifferent()
        {
            return _firstPlayerScore != _secondPlayerScore;
        }

        private string LookupScore()
        {
            return $"{_scoreLookup[_firstPlayerScore]} {_scoreLookup[_secondPlayerScore]}";
        }

        private string SameScore()
        {
            return $"{_scoreLookup[_firstPlayerScore]} All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScore++;
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScore++;
        }
    }
}