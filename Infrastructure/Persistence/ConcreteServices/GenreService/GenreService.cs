using Application.Constants;
using Application.DTOs.GenreDTOs;
using Application.Repositories.IGenreRepositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ConcreteServices.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly IGenreReadRepository readRepository;
        private readonly IGenreWriteRepository writeRepository;
        private readonly IMapper mapper;

        public GenreService(IGenreReadRepository readRepository, IGenreWriteRepository writeRepository, IMapper mapper)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<CreateGenreResponse> CreateGenre(CreateGenreDTO model)
        {
            var genre = await readRepository.GetSingleAsync(a => a.Name.ToLower() == model.Name.ToLower());
            CreateGenreResponse response = new();
            if (genre == null)
            {
                Genre newGenre = mapper.Map<Genre>(model);

                bool result = await writeRepository.AddAsync(newGenre);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.AddSucceeded;
                else
                {
                    response.Succeded = false;
                    response.Message = Messages.SaveFail;
                }
            }
            else
            {
                response.Succeded = false;
                response.Message = Messages.Exist;
            }
            return response;

        }

        public async Task<UpdateGenreResponse> UpdateGenre(UpdateGenreDTO model)
        {
            var genre = await readRepository.GetByIdAsync(model.Id.ToString());
            UpdateGenreResponse response = new();
            if (genre == null)
            {
                response.Succeded = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                var checkName = await readRepository.GetSingleAsync(a => a.Name.ToLower() == model.Name.ToLower());
                if (checkName == null)
                {
                    mapper.Map(model, genre);
                    bool result = writeRepository.Update(genre);
                    int zort = await writeRepository.SaveAsync();
                    if (result) response.Message = Messages.UpdateSucceeded;
                    else
                    {
                        response.Succeded = false;
                        response.Message = Messages.SaveFail;
                    }
                }
                else
                {
                    response.Succeded = false;
                    response.Message = Messages.Exist;
                }
            }
            return response;
        }
    }
}
