using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.DirectorDTOs
{
    public class DeleteDirectorDTO
    {
        public Guid Id { get; set; }
    }
    public class DeleteDirectorResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
