﻿using Application.Constants;
using Application.DTOs.MovieDTOs;
using Application.Repositories.IMovieRepositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ConcreteServices.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieReadRepository readRepository;
        private readonly IMovieWriteRepository writeRepository;
        private readonly IMapper mapper;

        public MovieService(IMovieReadRepository readRepository,IMovieWriteRepository writeRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<CreateMovieResponse> CreateMovie(CreateMovieDTO model)
        {
            var movie=readRepository.GetSingleAsync(a=>a.Name.ToLower()==model.Name.ToLower());
            CreateMovieResponse response = new();

            if (movie != null)
            {
                response.Succeded = false;
                response.Message = Messages.Exist;
            }
            else
            {
                bool result = await writeRepository.AddAsync(mapper.Map<Movie>(model));
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.AddSucceeded;
                else
                {
                    response.Message = Messages.SaveFail;
                    response.Succeded = result;
                }
            }
            return response;
        }

        public async Task<UpdateMovieResponse> UpdateMovie(UpdateMovieDTO model)
        {
           var movie= await readRepository.GetByIdAsync(model.Id);
            UpdateMovieResponse response = new();
            if(movie == null)
            {
                response.Succeded = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                mapper.Map(model, movie);
                bool result = writeRepository.Update(movie);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.UpdateSucceeded;
                else
                {
                    response.Message = Messages.SaveFail;
                    response.Succeded = result;
                }
            }
            return response;
        }
        public async Task<DeleteMovieResponse> DeleteMovie(DeleteMovieDTO model)
        {
            var movie=await readRepository.GetByIdAsync(model.Id);
            DeleteMovieResponse response = new();
            if(movie == null)
            {
                response.Succeded=false;
                response.Message = Messages.NotExist;
            }
            else
            {
                bool result = await writeRepository.RemoveAsync(model.Id);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.DeleteSucceeded;
                else
                {
                    response.Message = Messages.Fail;
                    response.Succeded = result;
                }
            }
            return response;
        }

        public List<Movie> GetAll() => readRepository.GetAll().ToList();
        
    }
}
