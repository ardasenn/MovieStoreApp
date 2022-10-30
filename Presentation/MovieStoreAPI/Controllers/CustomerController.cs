using Application.DTOs.CustomerDTOs;
using Application.Services;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreAPI.Models;
using MovieStoreAPI.Validator;
using System.Threading.Tasks;

namespace MovieStoreAPI.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService,IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> Create(CreateCustomerVM model)
        {
            CreateCustomerValidator validator = new();
            validator.ValidateAndThrow(model);
            CreateCustomerResponse response= await customerService.CreateCustomerAsync(mapper.Map<CreateCustomerDTO>(model));
            if(response.Succeeded) return Ok(response.Message);
            else return BadRequest(response.Message);
        } 
    }
}
