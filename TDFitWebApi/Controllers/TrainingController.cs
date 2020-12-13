using AutoMapper;
using Microsoft.AspNetCore.Authentication;
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
    [Route("api/training")] // atrybut ten wskazuje ścieżkę do treningu
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
        public ActionResult<List<Training>> Get() // metoda ktora zwraca cala liste diet
        {
            var training = tDFitContext.Trainings
                .ToList(); // pod ta zmienną są dane z bazy
            var trainingDtos = mapper.Map<List<Training>>(training);

            return Ok(trainingDtos); // zwracam klientowi liste diet /  ze statusem 200 
        }



        [HttpGet("{id}")]
        public ActionResult<Training> Get(int id) // metoda ktora zwraca diety i calorie po nazwie
        {
            var training = tDFitContext.Trainings
                .FirstOrDefault(m => m.Id == id);

            if (training== null)
            {
                return NotFound();
            }

            var trainingDto = mapper.Map<Training>(training);
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
            tDFitContext.Trainings.Add(training);
            tDFitContext.SaveChanges();

            var key = training.Id;

            return Created("api/training/" + key, null);
           
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Training model)
        {
            var training = tDFitContext.Trainings
                .FirstOrDefault(m => m.Id == id);

            if (training == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) // jezeli model jest niepoprawny
            {
                return BadRequest(ModelState);
            }

          
            training.Series = model.Series;
            training.Repeat = model.Repeat;

            tDFitContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var training = tDFitContext.Trainings
                       .FirstOrDefault(m => m.Id == id);

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
