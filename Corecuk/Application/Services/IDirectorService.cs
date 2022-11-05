using Application.DTOs.DirectorDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IDirectorService
    {
        Task<CreateDirectorResponse> CreateDirector(CreateDirectorDTO model);
        Task<UpdateDirectorResponse> UpdateDirector(UpdateDirectorDTO model);
        Task<DeleteDirectorResponse> DeleteDirector(DeleteDirectorDTO model);
        List<Director> GetAll();
    }
}
