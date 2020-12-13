using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TDFitWebApi.Entities;
using TDFitWebApi.Identity;
using TDFitWebApi.Models;



namespace TDFitWebApi.Controllers
{
    [Route("api/getminetraining")] // atrybut ten wskazuje ścieżkę do treningu
    [Authorize]
    public class TrainingGetMineController : ControllerBase
    {
        private readonly TDFitContext tDFitContext;
        private readonly IMapper mapper;
       
        public TrainingGetMineController(TDFitContext tDFitContext, IMapper mapper)
        {
            this.tDFitContext = tDFitContext;
            this.mapper = mapper;
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

            var key = training.Name.Replace(" ", "-").ToLower();

            return Created("api/getminetraining/" + key, null);
        }

        [HttpGet("{email}")]
        public ActionResult<List<TrainingDto>> Get(string email) // metoda ktora zwraca cala liste diet
        {
            var training = tDFitContext.Trainings                
                .Where(u => u.User.Email.ToLower() == email.ToLower())
                .ToList(); // pod ta zmienną są dane z bazy
            
            var trainingDtos = mapper.Map<List<TrainingDto>>(training);

            return Ok(trainingDtos); // zwracam klientowi liste diet /  ze statusem 200 
        }

     

    }
}
