using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Mapping between Customer to CustomerDto
            Mapper.CreateMap<Customer, CustomerDto>();
            //Mapping between Movie to MovieDto
            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            // Dto to Domain

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}