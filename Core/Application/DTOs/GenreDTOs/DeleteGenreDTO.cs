using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.GenreDTOs
{
    public class DeleteGenreDTO
    {
        public string Id { get; set; }
    }
    public class DeleteGenreResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
