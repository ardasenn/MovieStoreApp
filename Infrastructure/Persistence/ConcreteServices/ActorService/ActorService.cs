using Application.Constants;
using Application.DTOs.ActorDTOs;
using Application.DTOs.DirectorDTOs;
using Application.Repositories.IActorRepositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ConcreteServices.ActorService
{
    public class ActorService : IActorService
    {
        private readonly IActorWriteRepository writeRepository;
        private readonly IActorReadRepository readRepository;
        private readonly IMapper mapper;

        public ActorService(IActorWriteRepository writeRepository,IActorReadRepository readRepository,IMapper mapper)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<CreateActorResponse> CreateActor(CreateActorDTO model)
        {
            var actor = readRepository.GetSingleAsync(a => a.FirstName.ToLower() == model.FirstName.ToLower().Trim() && a.LastName.ToLower() == model.LastName.ToLower().Trim());
            CreateActorResponse response = new();
            if (actor == null)
            {
                response.Succeded = false;
                response.Message = Messages.Exist;
            }
            else
            {
                bool result = await writeRepository.AddAsync(mapper.Map<Actor>(model));
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.AddSucceeded;
                else
                {
                    response.Succeded = result;
                    response.Message = Messages.SaveFail;
                }
            }
            return response;
        }

        public List<Actor> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
