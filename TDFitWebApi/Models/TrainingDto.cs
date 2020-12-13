using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TDFitWebApi.Entities;

namespace TDFitWebApi.Models
{
    public class TrainingDto
    {
        public string Name { get; set; }
        public string Series { get; set; }
        public int Repeat { get; set; }

        public string Email { get; set; } 
    }
}
