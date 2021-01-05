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
   
        [Route("api/keepdiet")] // atrybut ten wskazuje ścieżkę do treningu
        [Authorize]
        public class KeepDietController : ControllerBase
        {
            private readonly TDFitContext tDFitContext;
            private readonly IMapper mapper;
            public KeepDietController(TDFitContext tDFitContext, IMapper mapper)
            {
                this.tDFitContext = tDFitContext;
                this.mapper = mapper;
            }

            [HttpGet]
            public ActionResult<List<KeepDiet>> Get() // metoda ktora zwraca cala liste diet
            {
                var keepdiet = tDFitContext.KeepDiets
                    .ToList(); // pod ta zmienną są dane z bazy
                var keepdietdtos = mapper.Map<List<KeepDiet>>(keepdiet);

                return Ok(keepdietdtos); // zwracam klientowi liste diet /  ze statusem 200 
            }



            [HttpGet("{id}")]
            public ActionResult<KeepDiet> Get(int id) // metoda ktora zwraca diety i calorie po nazwie
            {
                var keepdiet = tDFitContext.KeepDiets
                    .FirstOrDefault(m => m.Id == id);

                if (keepdiet == null)
                {
                    return NotFound();
                }

                var keepdietDto = mapper.Map<KeepDiet>(keepdiet);
                return Ok(keepdietDto);
            }

            [HttpPost]
            public ActionResult Post([FromBody]KeepDietDto model)
            {
                if (!ModelState.IsValid) // jezeli model jest niepoprawny
                {
                    return BadRequest(ModelState);
                }


                var keepdiet = mapper.Map<KeepDiet>(model);
                tDFitContext.KeepDiets.Add(keepdiet);
                tDFitContext.SaveChanges();

                var key = keepdiet.Id;

                return Created("api/keepdiet/" + key, null);

            }

            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody]KeepDiet model)
            {
                var keepdiet = tDFitContext.KeepDiets
                    .FirstOrDefault(m => m.Id == id);

                if (keepdiet == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid) // jezeli model jest niepoprawny
                {
                    return BadRequest(ModelState);
                }


               // training.Series = model.Series;
               // training.Repeat = model.Repeat;

                tDFitContext.SaveChanges();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {

                var keepdiet = tDFitContext.KeepDiets
                           .FirstOrDefault(m => m.Id == id);

                //czy zasob istnieje
                if (keepdiet == null)
                {
                    return NotFound();
                }

                tDFitContext.Remove(keepdiet);
                tDFitContext.SaveChanges();

                return NoContent();
            }
        }

        
}
