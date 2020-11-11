using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/diet/{dietName}/calorie")]
    [Authorize]
    public class CalorieController : ControllerBase
    {
        private readonly TDFitContext tDFitContext;
        private readonly IMapper mapper;

        public CalorieController(TDFitContext tDFitContext, IMapper mapper) // odniesienie do bazy danych poprzez wstrzyknięcie tdfitcontext przez konstruktor
        {
            this.tDFitContext = tDFitContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get(string dietName)  // zwraca calorie po nazwie
        {
            var diet = tDFitContext.Diets
            .Include(d => d.Calories)
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == dietName.ToLower());

            if (diet == null)
            {
                return NotFound();
            }

            var calories = mapper.Map<List<CalorieDto>>(diet.Calories);

            return Ok(calories);
        }

        [HttpPost]
        public ActionResult Post(string dietName, [FromBody]CalorieDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diet = tDFitContext.Diets
              .Include(d => d.Calories)
              .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == dietName.ToLower());

            if (diet == null)
            {
                return NotFound();
            }

            var calories = mapper.Map<Calorie>(model);
            diet.Calories.Add(calories);
            tDFitContext.SaveChanges();

            return Created($"api/diet/{dietName}", null);


        }

        [HttpDelete]
        public ActionResult Delete(string dietName)
        {
            var diet = tDFitContext.Diets
          .Include(d => d.Calories)
          .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == dietName.ToLower());

            if (diet == null)
            {
                return NotFound();
            }

            tDFitContext.Calories.RemoveRange(diet.Calories);
            tDFitContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string dietName, int id)
        {
            var diet = tDFitContext.Diets
          .Include(d => d.Calories)
          .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == dietName.ToLower());

            if (diet == null)
            {
                return NotFound();
            }

            var calorie = diet.Calories.FirstOrDefault(c => c.Id == id);

            if(calorie == null)
            {
                return NotFound();
            }    

            tDFitContext.Calories.Remove(calorie);
            tDFitContext.SaveChanges();

            return NoContent();
        }
    }
}
