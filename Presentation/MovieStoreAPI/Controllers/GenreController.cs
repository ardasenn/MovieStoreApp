using Application.DTOs.GenreDTOs;
using Application.Services;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreAPI.Models.GenreModels;
using MovieStoreAPI.Validator.GenreValidators;
using System.Threading.Tasks;

namespace MovieStoreAPI.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;
        private readonly IMapper mapper;

        public GenreController(IGenreService genreService,IMapper mapper)
        {
            this.genreService = genreService;
            this.mapper = mapper;
        }
        [HttpPost("CreateGenre")]
        public async Task<IActionResult> Create(CreateGenreVM model)
        {
            CreateGenreValidator validator = new();
            validator.ValidateAndThrow(model);
            CreateGenreResponse response = await genreService.CreateGenre(mapper.Map<CreateGenreDTO>(model));
            if (response.Succeded) return Ok(response.Message);
            return BadRequest(response.Message);
        }
        [HttpPost("UpdateGenre")]
        public async Task<IActionResult> Update (UpdateGenreVM model)
        {
            UpdateGenreValidator validator = new();
            validator.ValidateAndThrow(model);
            UpdateGenreResponse response= await genreService.UpdateGenre(mapper.Map<UpdateGenreDTO>(model));
            if (response.Succeded) return Ok(response.Message);
            return BadRequest(response.Message);
        }
    }
}
