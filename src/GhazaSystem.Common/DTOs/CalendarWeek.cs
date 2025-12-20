namespace GhazaSystem.Common.DTOs;

public class CalendarWeek
{
    public List<CalendarDay>? WeekDay { get; set; } = new List<CalendarDay>();
    public int WeekNumbwr { get; set; }
    public int DayCount { get; set; }
    public int YearNumber { get; set; }
    public int FirstDay { get; set; }
    public int LastDay { get; set; }
}
