using GhazaSystem.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhazaSystem.Common.DTOs
{
    public class ListUserDailyFoodsDTO
    {
        public Guid? UserId { get; set; }
        public Guid? DailyFoodId { get; set; }
        public List<Daily_Food>? ListDailyFoods { get; set; }
        public int Mount { get; set; }

    }
}
