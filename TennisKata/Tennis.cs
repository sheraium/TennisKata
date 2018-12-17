namespace TennisKata
{
    public class Tennis
    {
        private int _firstPlayerScoreTimes;

        public string Score()
        {
            if (_firstPlayerScoreTimes == 1)
            {
                return "Fifteen Love";
            }

            return "Love All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }
    }
}