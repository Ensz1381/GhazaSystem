using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhazaSystem.Common.DTOs;

public class CalendarDay
{
    
    public int DayNumber { get; set; }         // شماره روز (مثلا 15)
    public string? PersianDate { get; set; }    // تاریخ کامل شمسی (1403/05/15)
    public string? DayName { get; set; }        // نام روز هفته (شنبه، یکشنبه...)
    public DateOnly GregorianDate { get; set; } // تاریخ میلادی
    public int MonthNumber { get; set; }
    public int YearNumber { get; set; }
    public int WeekNumbwr { get; set; }

}
