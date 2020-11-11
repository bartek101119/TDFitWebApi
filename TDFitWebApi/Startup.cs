using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TDFitWebApi.Entities;
using TDFitWebApi.Identity;
using TDFitWebApi.Models;
using TDFitWebApi.Validators;

namespace TDFitWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var jwtOptions = new JwtOptions();
            Configuration.GetSection("jwt").Bind(jwtOptions);

            services.AddSingleton(jwtOptions);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false; // autentykacja w protokole http
                cfg.TokenValidationParameters = new TokenValidationParameters // konkretne parametry walidacji tokenów
                {
                    ValidIssuer = jwtOptions.JwtIssuer, // wydawca tokenów
                    ValidAudience = jwtOptions.JwtIssuer, // odbiorcy tokenów
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.JwtKey)) // podpis wydawcy na podstawie klucza ktory zostal zapisany w seksji jwt w pliku appsettings 
                };
            });

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddControllers().AddFluentValidation();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
            services.AddDbContext<TDFitContext>();
            services.AddScoped<TDFitSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TDFitSeeder tDFitSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
                
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            tDFitSeeder.Seed();
        }
    }
}
