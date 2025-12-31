using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhazaSystem.Common.DTOs.Report
{


    public class DailyDTO
    {

        public string? Fild1 { get; set; }
        public string? Fild2 { get; set; }
    }
    public record NOFoods(int NumberUser,string NameFood );
}

