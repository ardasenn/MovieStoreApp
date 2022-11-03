using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ActorDTOs
{
    public class CreateActorDTO
    {
        public CreateActorDTO()
        {
            Movies = new List<Movie>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Movie> Movies { get; set; }
        public Director Actor { get; set; }
    }
    public class CreateActorResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
