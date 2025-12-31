using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GhazaSystem.Common.DTOs.Report
{
    public class MontReportDTO
    {
        public int Culoms = 0;
        public int Rows = 0;
        public int Mont { get; set; }
        public string? MontName { get; set; } 
        public List<RowExcel>? RowMontExcelsOut { get; set; }
    }
    public class RowExcel
    {
        public List<CellMontExcel> CellOfRowExcel {  get; set; } = new List<CellMontExcel>();
    }
    public record CellMontExcel(string SCell , string User ,string DatePersian, DateOnly Date , int Index);
}
