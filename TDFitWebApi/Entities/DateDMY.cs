using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class DateDMY
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public virtual List<DietPlan> DietPlans { get; set; }

    }
}
