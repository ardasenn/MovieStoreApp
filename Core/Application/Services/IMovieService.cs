using Application.DTOs.MovieDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMovieService
    {
        Task<CreateMovieResponse> CreateMovie(CreateMovieDTO model);
        Task<UpdateMovieResponse> UpdateMovie(UpdateMovieDTO model);
        Task<DeleteMovieResponse> DeleteMovie(DeleteMovieDTO model);
        List<Movie> GetAll();
    }
}
