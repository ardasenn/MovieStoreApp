using Application.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerDTO model);
    }
}
