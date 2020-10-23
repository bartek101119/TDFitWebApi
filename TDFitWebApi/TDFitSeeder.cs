using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;

namespace TDFitWebApi
{
    public class TDFitSeeder
    {
        private readonly TDFitContext tDFitContext;

        public TDFitSeeder(TDFitContext tDFitContext)
        {
            this.tDFitContext = tDFitContext;
        }

        public void Seed()
        {
            if (tDFitContext.Database.CanConnect())
            {
                if(!tDFitContext.Diets.Any())
                {
                    InsertSampleData();

                }
            }
        }

        private void InsertSampleData()
        {
            var diets = new List<Diet>
            {
                new Diet
                {
                    Name = "Dieta Michała",
                    Type = "Odchudzanie",
                  
                },
                new Diet
                {
                    Name = "Dieta Andrzeja",
                    Type = "Przytycie",
                   
                }


            };

            tDFitContext.AddRange(diets);
            tDFitContext.SaveChanges();
            
        }
    }
}
