using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TDFitWebApi.Models
{
    public class DietDto
    {
        // model potrzebny do tworzenia diet
        // walidacja danych poprzez atrybuty
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Type { get; set; }

        public double Kcal { get; set; }

       

    }
}
