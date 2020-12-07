namespace GameTime
{
    public class GameTime
    {
        public int Hours;
        public int Minutes;
        public int Days;

        public GameTime()
        {
            Hours = 0;
            Minutes = 0;
            Days = 0;
        }

        public void AddHours(int hours)
        {
            CorrectHours(hours);
        }

        public void AddMinutes(int minutes)
        {
            Minutes += minutes;

            if (Minutes >= 60)
            {
                int hours = Minutes / 60;
                Minutes = Minutes % 60;
                CorrectHours(hours);
            }
        }

        public int GetInMinutes()
        {
            return Days * 24 * 60 + Hours * 60 + Minutes;
        }

        private void CorrectHours(int hours)
        {
            Hours += hours;

            if (Hours >= 24)
            {
                Days += Hours / 24;
                Hours %= 24;
            }
        }
    }
}
