
using System;

namespace CleanCode.DuplicatedCode
{
    public class Time
    {
        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public static Time Parse(string dateTime)
        {
            var hours = 0;
            var minutes = 0;
            if (!string.IsNullOrWhiteSpace(dateTime))
            {
                if (int.TryParse(dateTime.Replace(":", ""), out int time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("dateTime");
                }
            }
            else
                throw new ArgumentNullException(nameof(dateTime));

            return new Time(hours, minutes);
        }
    }

    public class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);
            var hours = time.Hours;

            // Some more logic 
            // ...
            if (hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var hours = 0;
            var getTime = Time.Parse(admissionDateTime);
            hours = getTime.Hours;

            // Some more logic 
            // ...
            if (hours < 10)
            {

            }
        }
    }
}
