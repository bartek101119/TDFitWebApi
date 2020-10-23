using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Models
{
    public class DietDetailsDto
    {
        // klasa do usuniecia id, zabezpieczenie przeciwko nieupoważnionym osobom
        // i do geta
        public string Name { get; set; }
        public string Type { get; set; }

        public double Kcal { get; set; }
        public List<CalorieDto> Calories { get; set; }

    }
}
