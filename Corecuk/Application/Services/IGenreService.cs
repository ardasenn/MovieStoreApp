using Application.DTOs.GenreDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IGenreService
    {
        Task<CreateGenreResponse> CreateGenre(CreateGenreDTO model);
        Task<UpdateGenreResponse> UpdateGenre(UpdateGenreDTO model);
        List<Genre> GetAll();
    }
}
