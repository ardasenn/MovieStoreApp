using Application.DTOs.ActorDTOs;
using Application.DTOs.DirectorDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IActorService
    {
        Task<CreateActorResponse> CreateActor(CreateActorDTO model);
        //Task<UpdateActorResponse> UpdateActor(UpdateActorDTO model);
        //Task<DeleteActorResponse> DeleteActor(DeleteActorDTO model);
        List<Actor> GetAll();
    }
}
