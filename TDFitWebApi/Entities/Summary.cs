using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class Summary
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double CarbohydrateKeep { get; set; }
        public double ProteinKeep { get; set; }
        public double FatKeep { get; set; }
        public double CarbohydrateLose { get; set; }
        public double ProteinLose { get; set; }
        public double FatLose { get; set; }
        public double CarbohydrateGain { get; set; }
        public double ProteinGain { get; set; }
        public double FatGain { get; set; }
        public double KcalKeep { get; set; }
        public double KcalLose { get; set; }
        public double KcalGain { get; set; }

        public string Email { get; set; }

    }
}
