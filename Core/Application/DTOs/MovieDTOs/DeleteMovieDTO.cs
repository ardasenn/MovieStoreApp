using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDTOs
{
    public class DeleteMovieDTO
    {
        public string Id { get; set; }
    }
    public class DeleteMovieResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
