using Application.DTOs.CustomerDTOs;
using AutoMapper;
using MovieStoreAPI.Models;

namespace MovieStoreAPI.MappingProfile
{
    public class VMsProfile : Profile
    {
        public VMsProfile()
        {
            CreateMap<CreateCustomerVM, CreateCustomerDTO>();
        }
    }
}
