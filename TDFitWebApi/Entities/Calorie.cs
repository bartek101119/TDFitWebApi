using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class Calorie
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Growth { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; } // płeć

        public bool Activity { get; set; } // aktywnosc fizyczna

        public int Carbohydrate { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }

        public double Kcal { get; set; }

        public virtual Diet Diet { get; set; }

        public int DietId { get; set; }

    }
}
