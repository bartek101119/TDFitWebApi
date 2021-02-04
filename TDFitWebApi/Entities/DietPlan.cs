using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class DietPlan
    {
        public int Id { get; set; }
        public string TimeOfEat { get; set; }
        public string Name { get; set; }
        public double Kcal { get; set; }
        public double Protein { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public double MacroSum { get; set; }
        public double KcalSum { get; set; }
        public string Email { get; set; }

        public virtual DateDMY DateDMY { get; set; }

        public int DateDMYId { get; set; }
    }
}
