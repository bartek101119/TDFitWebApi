using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;
using TDFitWebApi.Models;

namespace TDFitWebApi.Controllers
{
    [Route("api/summary")] // atrybut ten wskazuje ścieżkę do treningu
    [Authorize]
    public class SummaryController : ControllerBase
    {
        private readonly TDFitContext tDFitContext;
        private readonly IMapper mapper;
        public SummaryController(TDFitContext tDFitContext, IMapper mapper)
        {
            this.tDFitContext = tDFitContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Summary>> Get() // metoda ktora zwraca cala liste diet
        {
            var summary = tDFitContext.Summaries
                .ToList(); // pod ta zmienną są dane z bazy
            var summaryDtos = mapper.Map<List<Summary>>(summary);

            return Ok(summaryDtos); // zwracam klientowi liste diet /  ze statusem 200 
        }



        [HttpGet("{id}")]
        public ActionResult<Summary> Get(int id) // metoda ktora zwraca diety i calorie po nazwie
        {
            var summary = tDFitContext.Summaries
                .FirstOrDefault(m => m.Id == id);

            if (summary == null)
            {
                return NotFound();
            }

            var summaryDto = mapper.Map<Summary>(summary);
            return Ok(summaryDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody]SummaryDto model)
        {
            if (!ModelState.IsValid) // jezeli model jest niepoprawny
            {
                return BadRequest(ModelState);
            }


            var summary = mapper.Map<Summary>(model);
            tDFitContext.Summaries.Add(summary);
            tDFitContext.SaveChanges();

            var key = summary.Id;

            return Created("api/summary/" + key, null);

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Summary model)
        {
            var summary = tDFitContext.Summaries
                .FirstOrDefault(m => m.Id == id);

            if (summary == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) // jezeli model jest niepoprawny
            {
                return BadRequest(ModelState);
            }

            if(summary.CarbohydrateKeep > 0 && (summary.Id > 0 && summary.Id < 4)) {
                summary.Weight = model.Weight;
                summary.KcalKeep = model.KcalKeep;
                summary.CarbohydrateKeep = model.CarbohydrateKeep;
                summary.ProteinKeep = model.ProteinKeep;
                summary.FatKeep = model.FatKeep;

            }
            else if(summary.CarbohydrateLose > 0 && (summary.Id > 0 && summary.Id < 4)) {
                summary.Weight = model.Weight;
                summary.KcalLose = model.KcalLose;
                summary.CarbohydrateLose = model.CarbohydrateLose;
                summary.ProteinLose = model.ProteinLose;
                summary.FatLose = model.FatLose;
            }
            else if(summary.CarbohydrateGain > 0  && (summary.Id > 0 && summary.Id < 4))
            {
                summary.Weight = model.Weight;
                summary.KcalGain = model.KcalGain;
                summary.CarbohydrateGain = model.CarbohydrateGain;
                summary.ProteinGain = model.ProteinGain;
                summary.FatGain = model.FatGain;
            }

            tDFitContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var summary = tDFitContext.Summaries
                       .FirstOrDefault(m => m.Id == id);

            //czy zasob istnieje
            if (summary == null)
            {
                return NotFound();
            }

            tDFitContext.Remove(summary);
            tDFitContext.SaveChanges();

            return NoContent();
        }
    }
}
