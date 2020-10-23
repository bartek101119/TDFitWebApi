using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;
using TDFitWebApi.Models;

namespace TDFitWebApi.Controllers
{
    [Route("api/diet")] // atrybut ten wskazuje ścieżkę do diet
    public class DietController : ControllerBase
    {
        private readonly TDFitContext tDFitContext;
        private readonly IMapper mapper;

        public DietController(TDFitContext tDFitContext, IMapper mapper) // odniesienie do bazy danych poprzez wstrzyknięcie tdfitcontext przez konstruktor
        {
            this.tDFitContext = tDFitContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<DietDetailsDto>> Get() // metoda ktora zwraca cala liste diet
        {
            var diets = tDFitContext.Diets
                .Include(d => d.Calories)
                .ToList(); // pod ta zmienną są dane z bazy
            var dietDtos = mapper.Map<List<DietDetailsDto>>(diets);

            return Ok(dietDtos); // zwracam klientowi liste diet /  ze statusem 200 
        }

        [HttpGet("{name}")]
        public ActionResult<DietDetailsDto> Get(string name) // metoda ktora zwraca diety i calorie po nazwie
        {
            var diet = tDFitContext.Diets
                .Include(d => d.Calories)
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

            if (diet == null)
            {
                return NotFound();
            }

            var dietDto = mapper.Map<DietDetailsDto>(diet);
            return Ok(dietDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody]DietDto model)
        {
            if (!ModelState.IsValid) // jezeli model jest niepoprawny
            {
                return BadRequest(ModelState);
            }


            var diet = mapper.Map<Diet>(model);
            tDFitContext.Diets.Add(diet);
            tDFitContext.SaveChanges();

            var key = diet.Name.Replace(" ", "-").ToLower();

            return Created("api/diet/" + key, null);
        }

        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody]DietDto model)
        {
            var diet = tDFitContext.Diets
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

            if (diet == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) // jezeli model jest niepoprawny
            {
                return BadRequest(ModelState);
            }

            diet.Name = model.Name;
            diet.Type = model.Type;

            tDFitContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {

            var diet = tDFitContext.Diets
              
               .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());
            
            //czy zasob istnieje
            if (diet == null)
            {
                return NotFound();
            }

            tDFitContext.Remove(diet);
            tDFitContext.SaveChanges();

            return NoContent();
        }
    }
}
