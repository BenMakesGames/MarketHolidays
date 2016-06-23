using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketHolidays;
 
namespace MarketHolidaysTest
{
    [TestClass]
    public class DateTimeMarketHolidayExtensionsTest
    {
        [TestMethod]
        public void TestIsHoliday()
        {
            List<string> foundHolidays = new List<string>();
 
            // we're going to test all the holidays in 2015 through the end of 2020 - 11 years of testing!
            int startYear = 2015;
            int endYear = 2025;
            int expectedHolidayDays = (endYear - startYear + 1) * 9 - 1; // one New Year's Day (in 2022) is not observed, thus: -1
 
            int christmas = 0, goodFriday = 0, independence = 0, laborDay = 0, memorialDay = 0;
            int MLK = 0, newYears = 0, presidents = 0, thanksgiving = 0;
 
            DateTime testDay = new DateTime(startYear, 1, 1);
 
            do
            {
                FbmDateTime fbmDateTime = new FbmDateTime(testDay);
 
                if (fbmDateTime.Date.IsChristmasHoliday())
                    christmas++;
               
                if (fbmDateTime.Date.IsGoodFriday())
                    goodFriday++;
               
                if (fbmDateTime.Date.IsIndependenceHoliday())
                    independence++;
 
                if (fbmDateTime.Date.IsLaborDay())
                    laborDay++;
 
                if (fbmDateTime.Date.IsMemorialDay())
                    memorialDay++;
 
                if (fbmDateTime.Date.IsMLKDay())
                    MLK++;
 
                if (fbmDateTime.Date.IsNewYearsHoliday())
                    newYears++;
 
                if (fbmDateTime.Date.IsPresidentsDay())
                    presidents++;
 
                if (fbmDateTime.Date.IsThanksgivingDay())
                    thanksgiving++;
 
                if (fbmDateTime.IsHoliday)
                {
                    foundHolidays.Add(testDay.ToString("MM/dd/yyyy"));
                }
 
                testDay = testDay.AddDays(1);
 
            } while (testDay.Year <= endYear);
 
            Assert.AreEqual(11, christmas, "Found 11 Christmas holidays.");
            Assert.AreEqual(11, goodFriday, "Found 11 Good Fridays.");
            Assert.AreEqual(11, independence, "Found 11 Independence Day holidays.");
            Assert.AreEqual(11, laborDay, "Found 11 Labor Days.");
            Assert.AreEqual(11, memorialDay, "Found 11 Memorial Days.");
            Assert.AreEqual(11, MLK, "Found 11 MLK Days.");
            Assert.AreEqual(10, newYears, "Found 10 New Year's Day holidays."); // 2022's New Year's day is not observed, since it falls on a Saturday
            Assert.AreEqual(11, presidents, "Found 11 Presidents Days.");
            Assert.AreEqual(11, thanksgiving, "Found 11 Thanksgivings.");
 
            Assert.AreEqual(expectedHolidayDays, foundHolidays.Count, "There are " + expectedHolidayDays + " holiday days from " + startYear + " through " + endYear + ".");
 
            List<string> actualHolidays = new List<string>()
            {
                "01/01/2015", // New Years Day 2015
                "01/19/2015", // Martin Luther King, Jr. Day 2015
                "02/16/2015", // Washington's Birthday (Presidents' Day) 2015
                "04/03/2015", // Good Friday 2015
                "05/25/2015", // Memorial Day 2015
                "07/03/2015", // Independence Day 2015 (observed on the 3rd)
                "09/07/2015", // Labor Day 2015
                "11/26/2015", // Thanksgiving 2015
                "12/25/2015", // Christmas Day 2015
 
                "01/01/2016", // New Years Day 2016
                "01/18/2016", // Martin Luther King, Jr. Day 2016
                "02/15/2016", // Washington's Birthday (Presidents' Day) 2016
                "03/25/2016", // Good Friday 2016
                "05/30/2016", // Memorial Day 2016
                "07/04/2016", // Independence Day 2016
                "09/05/2016", // Labor Day 2014
                "11/24/2016", // Thanksgiving 2016
                "12/26/2016", // Christmas Day 2016 (observed on the 26st)
 
                "01/02/2017", // New Years Day 2017 (observed on the 2nd)
                "01/16/2017", // Martin Luther King, Jr. Day 2017
                "02/20/2017", // Washington's Birthday (Presidents' Day) 2017
                "04/14/2017", // Good Friday 2017
                "05/29/2017", // Memorial Day 2017
                "07/04/2017", // Independence Day 2017
                "09/04/2017", // Labor Day 2017
                "11/23/2017", // Thanksgiving 2017
                "12/25/2017", // Christmas Day 2017
 
                "01/01/2018", // New Years Day 2018
                "01/15/2018", // Martin Luther King, Jr. Day 2018
                "02/19/2018", // Washington's Birthday (Presidents' Day) 2018
                "03/30/2018", // Good Friday 2018
                "05/28/2018", // Memorial Day 2018
                "07/04/2018", // Independence Day 2018
                "09/03/2018", // Labor Day 2018
                "11/22/2018", // Thanksgiving 2018
                "12/25/2018", // Christmas Day 2018
 
                "01/01/2019", // New Years Day 2019
                "01/21/2019", // Martin Luther King, Jr. Day 2019
                "02/18/2019", // Washington's Birthday (Presidents' Day) 2019
                "04/19/2019", // Good Friday 2019
                "05/27/2019", // Memorial Day 2019
                "07/04/2019", // Independence Day 2019
                "09/02/2019", // Labor Day 2019
                "11/28/2019", // Thanksgiving 2019
                "12/25/2019", // Christmas Day 2019
 
                "01/01/2020", // New Years Day 2020
                "01/20/2020", // Martin Luther King, Jr. Day 2020
                "02/17/2020", // Washington's Birthday (Presidents' Day) 2020
                "04/10/2020", // Good Friday 2020
                "05/25/2020", // Memorial Day 2020
                "07/03/2020", // Independence Day 2020 (observed on the 3rd)
                "09/07/2020", // Labor Day 2020
                "11/26/2020", // Thanksgiving 2020
                "12/25/2020", // Christmas Day 2020
 
                "01/01/2021", // New Years Day 2021
                "01/18/2021", // Martin Luther King, Jr. Day 2021
                "02/15/2021", // Washington's Birthday (Presidents' Day) 2021
                "04/02/2021", // Good Friday 2021
                "05/31/2021", // Memorial Day 2021
                "07/05/2021", // Independence Day 2021 (observed on the 5th)
                "09/06/2021", // Labor Day 2021
                "11/25/2021", // Thanksgiving 2021
                "12/24/2021", // Christmas Day 2021 (observed on the 24th)
 
                // new year's day is not observed in 2022
                "01/17/2022", // Martin Luther King, Jr. Day 2022
                "02/21/2022", // Washington's Birthday (Presidents' Day) 2022
                "04/15/2022", // Good Friday 2022
                "05/30/2022", // Memorial Day 2022
                "07/04/2022", // Independence Day 2022
                "09/05/2022", // Labor Day 2022
                "11/24/2022", // Thanksgiving 2022
                "12/26/2022", // Christmas Day 2022 (observed on the 26th)
 
                "01/02/2023", // New Years Day 2023 (observed on the 2nd)
                "01/16/2023", // Martin Luther King, Jr. Day 2023
                "02/20/2023", // Washington's Birthday (Presidents' Day) 2023
                "04/07/2023", // Good Friday 2023
                "05/29/2023", // Memorial Day 2023
                "07/04/2023", // Independence Day 2023
                "09/04/2023", // Labor Day 2023
                "11/23/2023", // Thanksgiving 2023
                "12/25/2023", // Christmas Day 2023
 
                "01/01/2024", // New Years Day 2024
                "01/15/2024", // Martin Luther King, Jr. Day 2024
                "02/19/2024", // Washington's Birthday (Presidents' Day) 2024
                "03/29/2024", // Good Friday 2024
                "05/27/2024", // Memorial Day 2024
                "07/04/2024", // Independence Day 2024
                "09/02/2024", // Labor Day 2024
                "11/28/2024", // Thanksgiving 2024
                "12/25/2024", // Christmas Day 2024
 
                "01/01/2025", // New Years Day 2025
                "01/20/2025", // Martin Luther King, Jr. Day 2025
                "02/17/2025", // Washington's Birthday (Presidents' Day) 2025
                "04/18/2025", // Good Friday 2025
                "05/26/2025", // Memorial Day 2025
                "07/04/2025", // Independence Day 2025
                "09/01/2025", // Labor Day 2025
                "11/27/2025", // Thanksgiving 2025
                "12/25/2025"  // Christmas Day 2025
            };
 
            foreach(string actualHoliday in actualHolidays)
            {
                bool foundHoliday = foundHolidays.Contains(actualHoliday);
 
                Assert.IsTrue(foundHoliday, "Recognized " + actualHoliday + " as a holiday.");
            }
        }
    }
}
