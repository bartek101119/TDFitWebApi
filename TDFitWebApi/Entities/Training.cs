using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Series { get; set; }
        public int Repeat { get; set; }


        public string Email { get; set; }
        public User User { get; set; }

    }
}
