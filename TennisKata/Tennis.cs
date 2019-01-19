namespace TennisKata
{
    internal class Tennis
    {
        private int _firstPlayerScoreTimes;

        public string Score()
        {
            if (_firstPlayerScoreTimes == 1)
            {
                return "Fifteen Love";
            }
            if (_firstPlayerScoreTimes == 2)
            {
                return "Thirty Love";
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }
    }
}