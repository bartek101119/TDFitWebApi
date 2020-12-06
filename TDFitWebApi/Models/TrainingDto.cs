using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Models
{
    public class TrainingDto
    {
        public string Name { get; set; }
        public string Series { get; set; }
        public int Repeat { get; set; }
    }
}
