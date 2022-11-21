using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.GenreDTOs
{
    public class CreateGenreDTO
    {
        public string Name { get; set; }
    }
    public class CreateGenreResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
