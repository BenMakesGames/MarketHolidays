<a href='https://ko-fi.com/A0A12KQ16' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://cdn.ko-fi.com/cdn/kofi3.png?v=3' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>

Why?
====

Determining whether or not a given day is a "market holiday" is tricky. The rules are as follows:

* If the date is one of the observed holidays, and it's on a weekday, okay: it's a market holiday
* If the date is one of the observed holidays, and it's on a Sunday, then the following Monday is a market holiday
* If the date is one of the observed holidays, and it's on a Saturday, then the previous Friday is a market holiday, UNLESS you're checking for New Year's day, in which case New Year's day is not observed this year

And then there's the whole business of holidays being on the Xth Monday of whatever month, bla-bla-bla. And don't even get me started on calculating Easter/Good Friday!

More details can be found all over the internet. I happened to find these particularly useful:
* http://www.rightline.net/calendar/market-holidays.html
* http://markets.on.nytimes.com/research/markets/holidays/holidays.asp?display=market
* http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

I GUESS you could look up a list of dates and hand-code them in, years in advance, but... no thanks. Humans are too error-prone. Better to make the computer figure it out.

Example usage
=============

    using MarketHolidays;
  
    ...
  
    DateTime tomorrow = DateTime.Today.AddDays(1);
  
    if(tomorrow.IsChristmasHoliday()) // the 25th on most years, but the 24th or 26th on some
        Console.WriteLine("Tomorrow is Christmas Day (observed)");
    
    if(tomorrow.IsMarketHoliday())
        Console.WriteLine("Tomrrow is some kind of market holiday.");
