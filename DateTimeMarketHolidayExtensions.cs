using System;
 
namespace MarketHolidays
{
    public static class DateTimeMarketHolidayExtensions
    {
        public static bool IsMarketHoliday(this DateTime dt)
        {
            return
                dt.IsNewYearsHoliday() ||
                dt.IsMLKDay() ||
                dt.IsPresidentsDay() ||
                dt.IsGoodFriday() ||
                dt.IsMemorialDay() ||
                dt.IsIndependenceHoliday() ||
                dt.IsLaborDay() ||
                dt.IsThanksgivingDay() ||
                dt.IsChristmasHoliday()
            ;
        }
 
        public static bool IsNewYearsHoliday(this DateTime dt)
        {
            DateTime newYear = new DateTime(dt.Year, 1, 1);
 
            // when new year's day falls on a Saturday, we do NOT observe it on Friday, because that would take us not only into the previous month, but the previous YEAR
            if(newYear.DayOfWeek == DayOfWeek.Saturday)
                return false;
 
            DateTime newYearHoliday = newYear.NearestWeekDay();
 
            return dt.Month == newYearHoliday.Month && dt.Day == newYearHoliday.Day;
        }
 
        public static bool IsMLKDay(this DateTime dt)
        {
            // January, third Monday
            return dt.Month == 1 && dt.IsXthDayOfWeek(3, DayOfWeek.Monday);
        }
 
        public static bool IsPresidentsDay(this DateTime dt)
        {
            // February, third Monday
            return dt.Month == 2 && dt.IsXthDayOfWeek(3, DayOfWeek.Monday);
        }
 
        public static bool IsLaborDay(this DateTime dt)
        {
            // September, first Monday
            return dt.Month == 9 && dt.IsXthDayOfWeek(1, DayOfWeek.Monday);
        }
 
        public static bool IsThanksgivingDay(this DateTime dt)
        {
            // November, fourth Thursday
            return dt.Month == 11 && dt.IsXthDayOfWeek(4, DayOfWeek.Thursday);
        }
 
        public static bool IsMemorialDay(this DateTime dt)
        {
            // May, last Monday
            return dt.Month == 5 && dt.IsLastDayOfWeek(DayOfWeek.Monday);
        }
 
        public static bool IsIndependenceHoliday(this DateTime dt)
        {
            DateTime fourthOfJulyHoliday = (new DateTime(dt.Year, 7, 4)).NearestWeekDay();
 
            return dt.Month == fourthOfJulyHoliday.Month && dt.Day == fourthOfJulyHoliday.Day;
        }
 
        public static DateTime ChristmasHoliday(int year)
        {
            return (new DateTime(year, 12, 25)).NearestWeekDay();
        }
 
        public static bool IsChristmasHoliday(this DateTime dt)
        {
            DateTime christmasHoliday = (new DateTime(dt.Year, 12, 25)).NearestWeekDay();
 
            return dt.Month == christmasHoliday.Month && dt.Day == christmasHoliday.Day;
        }
 
        // from http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year
        public static bool IsEasterSunday(this DateTime dt)
        {
            int day = 0;
            int month = 0;
 
            int g = dt.Year % 19;
            int century = dt.Year / 100;
            int h = (century - (int)(century / 4) - (int)((8 * century + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));
 
            day = i - ((dt.Year + (int)(dt.Year / 4) + i + 2 - century + (int)(century / 4)) % 7) + 28;
            month = 3;
 
            if (day > 31)
            {
                month++;
                day -= 31;
            }
 
            return dt.Month == month && dt.Day == day;
        }
 
        public static bool IsGoodFriday(this DateTime dt)
        {
            return dt.AddDays(2).IsEasterSunday();
        }
 
        public static DateTime NearestWeekDay(this DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Saturday)
                return dt.AddDays(-1);
            else if (dt.DayOfWeek == DayOfWeek.Sunday)
                return dt.AddDays(1);
            else
                return dt;
        }
 
        public static bool IsXthDayOfWeek(this DateTime dt, int x, DayOfWeek dow)
        {
            int tryDayOfMonth = (x - 1) * 7 + 1; // the first Monday could be as early as the first day of the month; the second could be the 8th day; the third could be the 15th
 
            // if tryDayOfMonth is not the type of day we're looking for, try the NEXT day
            while ((new DateTime(dt.Year, dt.Month, tryDayOfMonth)).DayOfWeek != dow)
            {
                tryDayOfMonth++;
            }
 
            return dt.Day == tryDayOfMonth;
        }
 
        public static bool IsLastDayOfWeek(this DateTime dt, DayOfWeek dow)
        {
            int tryDayOfMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
 
            // if tryDayOfMonth is not the type of day we're looking for, try the PREVIOUS day
            while ((new DateTime(dt.Year, dt.Month, tryDayOfMonth)).DayOfWeek != dow)
            {
                tryDayOfMonth--;
            }
 
            return dt.Day == tryDayOfMonth;
        }
    }
}
