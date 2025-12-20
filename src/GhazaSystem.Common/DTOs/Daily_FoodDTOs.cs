using GhazaSystem.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhazaSystem.Common.DTOs;

public class Daily_FoodDTOs
{
    public Food food { get; set; } = new Food();
    public DateOnly Date { get; set; }

    public int Mount { get; set; }


}

