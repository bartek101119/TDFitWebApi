using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Models
{
    public class KeepDietDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string TimeOfEat { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Kcal { get; set; }
        [Required]
        public double Protein { get; set; }
        [Required]
        public double Carbohydrate { get; set; }
        [Required]
        public double Fat { get; set; }
        public double MacroSum { get; set; }
        public double KcalSum { get; set; }
        public string Email { get; set; }
    }
}
