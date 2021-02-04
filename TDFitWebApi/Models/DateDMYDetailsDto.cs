using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;

namespace TDFitWebApi.Models
{
    public class DateDMYDetailsDto
    {
        public DateTime Date { get; set; }

        public virtual List<DietPlan> DietPlans { get; set; }
    }
}
