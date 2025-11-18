using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhazaSystem.Common.DTOs
{
    public class FoodDTOs
    {
        public required string Name { get; set; }
        public required float Amount { get; set; }
        public string? Photos { get; set; }
        public string? Description { get; set; }
    }
}
