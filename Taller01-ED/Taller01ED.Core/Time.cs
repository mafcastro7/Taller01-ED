namespace Taller01ED.Core
{
    public class Time
    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time()
        {
            Hour = 0;
            Millisecond = 0;
            Minute = 0;
            Second = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
            Millisecond = 0;
            Minute = 0;
            Second = 0;
        }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Millisecond = 0;
            Minute = minute;
            Second = 0;
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Millisecond = 0;
            Minute = minute;
            Second = second;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Millisecond = millisecond;
            Minute = minute;
            Second = second;
        }

        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }

        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidateMillisecond(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidateMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidateSecond(value);
        }

        public long ToMilliseconds()
        {
            return (long)Hour * 60 * 60 * 1000
                 + (long)Minute * 60 * 1000
                 + (long)Second * 1000
                 + Millisecond;
        }

        public long ToMinutes()
        {
            return (long)Hour * 60 + Minute;
        }


        public long ToSeconds()
        {
            return (long)Hour * 60 * 60
                 + (long)Minute * 60
                 + (long)Second;
        }

        public Time Add(Time other)
        {

            int newMillisecond = this.Millisecond + other.Millisecond;
            int extraSeconds = 0;
            if (newMillisecond > 999)
            {
                extraSeconds = newMillisecond / 1000;
                newMillisecond = newMillisecond % 1000;
            }


            int newSecond = this.Second + other.Second + extraSeconds;
            int extraMinutes = 0;
            if (newSecond > 59)
            {
                extraMinutes = newSecond / 60;
                newSecond = newSecond % 60;
            }


            int newMinute = this.Minute + other.Minute + extraMinutes;
            int extraHours = 0;
            if (newMinute > 59)
            {
                extraHours = newMinute / 60;
                newMinute = newMinute % 60;
            }


            int newHour = this.Hour + other.Hour + extraHours;
            if (newHour > 23)
            {
                newHour = newHour % 24;
            }

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }
        public bool IsOtherDay(Time other)
        {
            int totalMillisecond = this.Millisecond + other.Millisecond;
            int cSecond = totalMillisecond / 1000;

            int totalSecond = this.Second + other.Second + cSecond;
            int cMinute = totalSecond / 60;

            int totalMinute = this.Minute + other.Minute + cMinute;
            int cHour = totalMinute / 60;

            int totalHour = this.Hour + other.Hour + cHour;

            return totalHour >= 24;
        }

        public override string ToString()
        {
            int displayHour;
            if (Hour == 0)
            {
                displayHour = 0; 
            }
            else
            {
                displayHour = Hour % 12;
                if (displayHour == 0) displayHour = 12;
            }

            string ampm = Hour < 12 ? "AM" : "PM";

            return $"{displayHour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {ampm}";
        }


        private int ValidateHour(int value)
        {
            if (value < 0 || value > 23)
                throw new Exception($"The hour: {value}, is not valid.");
            return value;
        }

        private int ValidateMinute(int value)
        {
            if (value < 0 || value > 59)
                throw new Exception($"The minute: {value}, is not valid.");
            return value;
        }

        private int ValidateSecond(int value)
        {
            if (value < 0 || value > 59)
                throw new Exception($"The second: {value}, is not valid.");
            return value;
        }

        private int ValidateMillisecond(int value)
        {
            if (value < 0 || value > 999)
                throw new Exception($"The millisecond: {value}, is not valid.");
            return value;
        }
    }
}
