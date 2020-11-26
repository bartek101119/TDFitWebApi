using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;
using TDFitWebApi.Identity;
using TDFitWebApi.Models;

namespace TDFitWebApi.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly TDFitContext tDFitContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IJwtProvider jwtProvider;

        public AccountController(TDFitContext tDFitContext, IPasswordHasher<User> passwordHasher, IJwtProvider jwtProvider)
        {
            this.tDFitContext = tDFitContext;
            this.passwordHasher = passwordHasher;
            this.jwtProvider = jwtProvider;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]UserLoginDto userLoginDto) // zwracanie tokena uzytkownikom
        {
            var user = tDFitContext.Users
                .Include(user => user.Role)
                .FirstOrDefault(user => user.Email == userLoginDto.Email);

            if(user == null)
            {
                return BadRequest("Invalid username or password");
            }
            try
            {
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userLoginDto.Password);
                if (passwordVerificationResult == PasswordVerificationResult.Failed)
                {
                    return BadRequest("Invalid username or password");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Invalid username or password");
            }

            var token = jwtProvider.GenerateJwtToken(user);

            return Ok(token);

        }

        [HttpPost("register")]
        public ActionResult Register([FromBody]RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid) // czy model nie jest poprawny
            {
                return BadRequest(ModelState);
            }

            var newUser = new User()
            {
                Email = registerUserDto.Email,
                Nationality = registerUserDto.Nationality,
                DateOfBirth = registerUserDto.DateOfBirth,
                RoleId = registerUserDto.RoleId
            };

            var passwordHash = passwordHasher.HashPassword(newUser, registerUserDto.Password); // zmienna do trzymania hashu hasła
            newUser.PasswordHash = passwordHash; // dodanie hasha do bazy dla danego uzytkownika

            tDFitContext.Users.Add(newUser);
            tDFitContext.SaveChanges();

            return Ok();
        }
    }
}
