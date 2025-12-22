using GhazaSystem.Common.DTOs;
using System.Globalization;

namespace GhazaSystem.Common.Services;

public class PersianCalendarService
{
    public CalendarMont AutoPersianCalendar()
    {
        var pc = new PersianCalendar();

        // دریافت تاریخ میلادی امروز
        DateTime today = DateTime.Today;

        // استخراج عدد ماه شمسی فعلی (مثلاً 9 برای آذر)
        int currentPersianMonth = pc.GetMonth(today);
        return GetMonthCalendar(currentPersianMonth);
    }

    public CalendarMont GetMonthCalendar(int month)
    {
        var pc = new PersianCalendar();
        var result = new CalendarMont();
        result.MonthNumber = month;
        // دریافت سال جاری شمسی برای دقت بیشتر
        int currentYear = pc.GetYear(DateTime.Now);

        // محاسبه تعداد روزهای آن ماه (29، 30 یا 31)
        int daysInMonth = pc.GetDaysInMonth(currentYear, month);

        // پیدا کردن تاریخ میلادی روز اول ماه برای شروع حلقه
        DateTime startDate = pc.ToDateTime(currentYear, month, 1, 0, 0, 0, 0);

        // محاسبه آفست برای شروع هفته از شنبه
        // DayOfWeek در دات نت: Sunday=0, Monday=1, ..., Saturday=6
        // ما می‌خواهیم: Saturday=0, Sunday=1, ..., Friday=6
        // فرمول: (روز + 1) % 7
        int startDayOffset = ((int)startDate.DayOfWeek + 1) % 7;

        var currentWeek = new CalendarWeek();

        // پر کردن روزهای خالی قبل از شروع ماه (برای هفته اول)
        for (int i = 0; i < startDayOffset; i++)
        {
            currentWeek.WeekDay?.Add(null!); // روزهای قبل از یکم ماه خالی هستند
        }

        // حلقه روی تمام روزهای ماه
        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime gregorianDate = pc.ToDateTime(currentYear, month, day, 0, 0, 0, 0);

            var calendarDay = new CalendarDay
            {
                DayNumber = day,
                PersianDate = $"{currentYear}/{month:00}/{day:00}",
                GregorianDate = DateOnly.FromDateTime(gregorianDate),
                DayName = GetPersianDayName(gregorianDate.DayOfWeek)
            };
            if (currentWeek.DayCount == 0) currentWeek.FirstDay = calendarDay.DayNumber;
            currentWeek.WeekDay!.Add(calendarDay);
            currentWeek.DayCount++;
            if (calendarDay.DayName == "جمعه")
            {
                currentWeek.LastDay = calendarDay.DayNumber;
                result.MontWeek?.Add(currentWeek);
                currentWeek = new CalendarWeek();
            }
            // اگر هفته پر شد (7 روز)، آن را به لیست کلی اضافه کن و هفته جدید بساز
            if (currentWeek.DayCount == 7)
            {
                currentWeek.LastDay = calendarDay.DayNumber;
                result.MontWeek?.Add(currentWeek);
                currentWeek = new CalendarWeek();
            }
        }

        // اگر آخرین هفته کامل نشده بود، روزهای باقی‌مانده را با null پر کن و اضافه کن
        if (currentWeek.DayCount > 0)
        {
            while (currentWeek.DayCount < 7)
            {
                currentWeek.WeekDay?.Add(null!);
                currentWeek.DayCount++;
            }
            currentWeek.LastDay = daysInMonth;
            result.MontWeek?.Add(currentWeek);
        }
        result.YearNumber = currentYear;
        return result;
    }

    // متد کمکی برای تبدیل نام روزها به فارسی
    private string GetPersianDayName(DayOfWeek dayOfWeek)
    {
        return dayOfWeek switch
        {
            DayOfWeek.Saturday => "شنبه",
            DayOfWeek.Sunday => "یکشنبه",
            DayOfWeek.Monday => "دوشنبه",
            DayOfWeek.Tuesday => "سه‌شنبه",
            DayOfWeek.Wednesday => "چهارشنبه",
            DayOfWeek.Thursday => "پنج‌شنبه",
            DayOfWeek.Friday => "جمعه",
            _ => ""
        };
    }

    public string GetPersianMontName(int MontNumber)
    {
        return MontNumber switch
        {
            1 => "فروردین",
            2 => "اردیبهشت",
            3 => "خرداد",
            4 => "تیر",
            5 => "مرداد",
            6 => "شهریور",
            7 => "مهر",
            8 => "آبان",
            9 => "آذر",
            10 => "دی",
            11 => "بهمن",
            12 => "اسفند",
            _ => ""
        };
    }

}
