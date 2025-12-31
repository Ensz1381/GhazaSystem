namespace GhazaSystem.Common.DTOs.Report
{
    public class ListReportDailyDTO
    {
        public List<NOFoods>? Foods { get; set; } = new List<NOFoods>();
        public List<DailyDTO>? daily{ get; set; } = new List<DailyDTO>();
    }
}

