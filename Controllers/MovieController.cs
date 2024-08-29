using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTO;
using MovieAPI.Services;

namespace MovieAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public MovieController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<MovieReadOnlyDTO>> AddMovie(MovieCreateDTOcs movie)
        {
            var response = await _applicationService.MovieService.CreateMovie(movie);
            return Ok(response);
        }

        [HttpGet()]
        [Authorize]
        public async Task<ActionResult<MovieReadOnlyDTO>> GetAllMovies()
        {
            var response = await _applicationService.MovieService.GetAllMovies();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<MovieReadOnlyDTO>> GetMovieById(int id)
        {
            var response = await _applicationService.MovieService.GetMovieById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var response = await _applicationService.MovieService.DeleteMovie(id);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateMovie(MovieUpdateDTO movie)
        {
            var response = await _applicationService.MovieService.UpdateMovie(movie);
            return Ok(response);
        }
    }
}
