using AutoMapper;
using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<NewProductDto, Product>();
        }
    }
}
