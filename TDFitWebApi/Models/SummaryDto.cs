using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Models
{
    public class SummaryDto
    {
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
