using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;
using TDFitWebApi.Models;

namespace TDFitWebApi
{
    public class TDFitProfile : Profile
    {
        public TDFitProfile()
        {
            CreateMap<Diet, DietDetailsDto>();
            CreateMap<DietDto, Diet>();

            CreateMap<CalorieDto, Calorie>()
                .ReverseMap();

            CreateMap<Training, TrainingDto>()
                .ReverseMap();
            CreateMap<Summary, SummaryDto>()
                .ReverseMap();
            CreateMap<KeepDiet, KeepDietDto>()
               .ReverseMap();
   

        }
    }
}
