using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ActorDTOs
{
    public class DeleteActorDTO
    {
        public string Id { get; set; }
    }
    public class DeleteActorResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
