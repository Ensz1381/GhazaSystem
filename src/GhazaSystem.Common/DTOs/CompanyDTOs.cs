using GhazaSystem.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhazaSystem.Common.DTOs
{
    public class CompanyDTOs
    {
        public List<User>? Users { get; set; }
        public string? Name { get; set; }
        public int? C_Code { get; set; }
    }
}
