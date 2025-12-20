namespace GhazaSystem.Common.DTOs;

public class CalendarMont
{
    public int MonthNumber { get; set; }
    public int YearNumber { get; set; }
    public int DayCount { get; set; }
    public int WeekCount { get; set; }
    public List<CalendarWeek>? MontWeek { get; set; } = new List<CalendarWeek>();
    public int FirstDay { get; set; }
    public int LastDay { get; set; }
}

