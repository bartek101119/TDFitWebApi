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
    [Route("api/training")] // atrybut ten wskazuje ścieżkę do diet
    [Authorize]
    public class TrainingController : ControllerBase
    {
        private readonly TDFitContext tDFitContext;
        private readonly IMapper mapper;
        public TrainingController(TDFitContext tDFitContext, IMapper mapper)
        {
            this.tDFitContext = tDFitContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<TrainingDto>> Get() // metoda ktora zwraca cala liste diet
        {
            var training = tDFitContext.Tranings
                .ToList(); // pod ta zmienną są dane z bazy
            var trainingDtos = mapper.Map<List<TrainingDto>>(training);

            return Ok(trainingDtos); // zwracam klientowi liste diet /  ze statusem 200 
        }

        [HttpGet("{name}")]
        public ActionResult<TrainingDto> Get(string name) // metoda ktora zwraca diety i calorie po nazwie
        {
            var training = tDFitContext.Tranings
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

            if (training== null)
            {
                return NotFound();
            }

            var trainingDto = mapper.Map<TrainingDto>(training);
            return Ok(trainingDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody]TrainingDto model)
        {
            if (!ModelState.IsValid) // jezeli model jest niepoprawny
            {
                return BadRequest(ModelState);
            }


            var training = mapper.Map<Training>(model);
            tDFitContext.Tranings.Add(training);
            tDFitContext.SaveChanges();

            var key = training.Name.Replace(" ", "-").ToLower();

            return Created("api/diet/" + key, null);
        }

        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody]TrainingDto model)
        {
            var training = tDFitContext.Tranings
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

            if (training == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) // jezeli model jest niepoprawny
            {
                return BadRequest(ModelState);
            }

            training.Name = model.Name;
            training.Series = model.Series;
            training.Repeat = model.Repeat;

            tDFitContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {

            var training = tDFitContext.Tranings
                       .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

            //czy zasob istnieje
            if (training == null)
            {
                return NotFound();
            }

            tDFitContext.Remove(training);
            tDFitContext.SaveChanges();

            return NoContent();
        }

    }
}
