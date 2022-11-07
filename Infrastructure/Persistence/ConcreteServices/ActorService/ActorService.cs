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
        private readonly IDirectorService directorService;

        public ActorService(IActorWriteRepository writeRepository,IActorReadRepository readRepository,IMapper mapper,IDirectorService directorService)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
            this.mapper = mapper;
            this.directorService = directorService;
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
        public async Task<object> IsActorExist (string name,string lastName)
        {
            Actor actor=await readRepository.GetSingleAsync(a=>a.FirstName.ToLower()==name.ToLower().Trim()&& a.LastName.ToLower()==lastName.ToLower().Trim());
            if (actor != null)return actor.Id;
            else return false;
        }
        public List<Actor> GetAll() => readRepository.GetAll().ToList();

        public async Task<UpdateActorResponse> UpdateActor(UpdateActorDTO model)
        {
            var actor = await readRepository.GetByIdAsync(model.Id.ToString());
            UpdateActorResponse response = new();
            if (actor == null)
            {
                response.Succeded = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                mapper.Map(model, actor);
                bool result = writeRepository.Update(actor);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.UpdateSucceeded;
                else
                {
                    response.Succeded = result;
                    response.Message = Messages.SaveFail;
                }
            }
            return response;
        }
        public async Task<DeleteActorResponse> DeleteActor(DeleteActorDTO model)
        {
            var actor = await readRepository.GetByIdAsync(model.Id);
            DeleteActorResponse response = new();
            if (actor == null)
            {
                response.Succeded = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                bool result = await writeRepository.RemoveAsync(model.Id.ToString());
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.DeleteSucceeded;
                else
                {
                    response.Succeded = result;
                    response.Message = Messages.SaveFail;
                }

            }
            return response;
        }
    }
}
