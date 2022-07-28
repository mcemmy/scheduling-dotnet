namespace StaffScheduler.Core.Domain.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime Within(this DateTime dateTime, int periodInMonths)
        {
            if (periodInMonths > 12)
            {
                periodInMonths = 12; //can be configurable
            }

            return dateTime.AddMonths(-periodInMonths);
        }
    }
}
