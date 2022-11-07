using Application.Constants;
using Application.DTOs.ActorDTOs;
using Application.DTOs.DirectorDTOs;
using Application.DTOs.GenreDTOs;
using Application.Repositories.IActorRepositories;
using Application.Repositories.IDirectorRepositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ConcreteServices.DirectorService
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorWriteRepository writeRepository;
        private readonly IDirectorReadRepository readRepository;
        private readonly IMapper mapper;
        private readonly IActorService actorService;
        private readonly IActorReadRepository actorReadRepository;

        public DirectorService(IDirectorWriteRepository writeRepository, IDirectorReadRepository readRepository, IMapper mapper, IActorService actorService,IActorReadRepository actorReadRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
            this.mapper = mapper;
            this.actorService = actorService;
            this.actorReadRepository = actorReadRepository;
        }
        public async Task<CreateDirectorResponse> CreateDirector(CreateDirectorDTO model)
        {
            var director = readRepository.GetSingleAsync(a => a.FirstName.ToLower() == model.FirstName.ToLower().Trim() && a.LastName.ToLower() == model.LastName.ToLower().Trim());
            CreateDirectorResponse response = new();
            if (director != null)
            {
                response.Succeded = false;
                response.Message = Messages.Exist;
            }
            else
            {
                var relationResult = await actorService.IsActorExist(model.FirstName, model.LastName);
                if (relationResult is Guid)
                {
                    var newDirector = mapper.Map<Director>(model);
                    newDirector.Actor.Id = (Guid)relationResult;
                    bool result = await writeRepository.AddAsync(newDirector);
                    await writeRepository.SaveAsync();
                    if (result) response.Message = Messages.AddSucceeded;
                    else
                    {
                        response.Succeded = result;
                        response.Message = Messages.SaveFail;
                    }
                }
                else
                {
                    var actorDTO = mapper.Map<CreateActorDTO>(model);
                    await actorService.CreateActor(actorDTO);
                 var actor =  await actorReadRepository.GetSingleAsync(a => a.FirstName.ToLower() == model.FirstName.ToLower().Trim());
                    var newDirector=mapper.Map<Director>(model);
                    newDirector.Actor = actor;
                    bool result = await writeRepository.AddAsync(newDirector);
                    await writeRepository.SaveAsync();
                    if (result) response.Message = Messages.AddSucceeded;
                    else
                    {
                        response.Succeded = result;
                        response.Message = Messages.SaveFail;
                    }
                }
            }
            return response;
        }
        public async Task<UpdateDirectorResponse> UpdateDirector(UpdateDirectorDTO model)
        {
            var director = await readRepository.GetByIdAsync(model.Id);
            UpdateDirectorResponse response = new();
            if (director == null)
            {
                response.Succeded = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                mapper.Map(model, director);
                bool result = writeRepository.Update(director);
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

        public List<Director> GetAll() => readRepository.GetAll().ToList();

        public async Task<DeleteDirectorResponse> DeleteDirector(DeleteDirectorDTO model)
        {
            var director = await readRepository.GetByIdAsync(model.Id.ToString());
            DeleteDirectorResponse response = new();
            if (director == null)
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
