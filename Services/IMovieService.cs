using MovieAPI.DTO;
using MovieAPI.Models;

namespace MovieAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieReadOnlyDTO>> GetAllMovies();
        Task<MovieReadOnlyDTO> GetMovieById(int id);
        Task<MovieReadOnlyDTO> CreateMovie(MovieCreateDTOcs movie);
        Task<MovieReadOnlyDTO> UpdateMovie(MovieUpdateDTO movie);
        Task<MovieReadOnlyDTO> DeleteMovie(int id);
    }
}
