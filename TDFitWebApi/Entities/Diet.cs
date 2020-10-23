using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // typ diety (odchudzanie, utrzymanie, przytycie)

        public double Kcal { get; set; }

        public virtual List<Calorie> Calories { get; set; }
        

        // public virtual List<Day> Days { get; set; }
    }
}
