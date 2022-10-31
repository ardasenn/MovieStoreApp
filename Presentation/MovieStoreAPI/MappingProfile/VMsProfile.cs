using Application.DTOs.CustomerDTOs;
using Application.DTOs.GenreDTOs;
using AutoMapper;
using MovieStoreAPI.Models;
using MovieStoreAPI.Models.GenreModels;

namespace MovieStoreAPI.MappingProfile
{
    public class VMsProfile : Profile
    {
        public VMsProfile()
        {
            CreateMap<CreateCustomerVM, CreateCustomerDTO>();
            CreateMap<CreateGenreVM, CreateGenreDTO>();
            CreateMap<UpdateGenreVM, UpdateGenreDTO>();
        }
    }
}
