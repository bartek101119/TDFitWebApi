using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TDFitWebApi.Models
{
    public class CalorieDto
    {
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Growth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool Sex { get; set; } // płeć
        [Required]
        public bool Activity { get; set; } // aktywnosc fizyczna
        [Required]
        public int Carbohydrate { get; set; }
        [Required]
        public int Protein { get; set; }
        [Required]
        public int Fat { get; set; }
        
    }
}
