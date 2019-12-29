using System;

namespace TestYourKnowledge.Extensions
{
    public static class DateTimeExtensions
    {
        public static double GetSecondsDifference(this DateTime greater, DateTime less)
        {
            return Math.Round((greater - less).TotalSeconds);
        }

        public static int GetSecondsDifferenceFromNow(this DateTime dateTime)
        {
            var now = DateTime.Now;
            return Convert.ToInt32(GetSecondsDifference(now, dateTime));
        }
    }
}
