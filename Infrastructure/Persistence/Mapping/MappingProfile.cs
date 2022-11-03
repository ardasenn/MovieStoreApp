using Application.DTOs.ActorDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.DirectorDTOs;
using Application.DTOs.GenreDTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mapping

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<CreateDirectorDTO, Director>();
            CreateMap<UpdateDirectorDTO, Director>();
            CreateMap<CreateActorDTO, Actor>();
            CreateMap<UpdateActorDTO, Actor>();

        }
    }
}
