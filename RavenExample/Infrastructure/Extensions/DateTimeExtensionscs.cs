using System;

namespace RavenExample.Infrastructure.Extensions
{
    public static class DateTimeExtensionscs
    {
        public static DateTime StartOfDay(this DateTime theDate) => theDate.Date;

        public static DateTime EndOfDay(this DateTime theDate) => 
            theDate
                .Date
                .AddDays(1)
                .AddTicks(-1);

        public static DateTime NextDay(this DateTime theDate) =>
            theDate
                .Date
                .AddDays(1);
    }
}
