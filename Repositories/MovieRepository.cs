using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _dataContext;

        public MovieRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            await _dataContext.Movies.AddAsync(movie);
            return movie;
        }


        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _dataContext.Movies.ToListAsync();
        }

        public async Task<Movie>? GetMovieById(int id)
        {
            return await _dataContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var existingMovie = await _dataContext.Movies.FirstOrDefaultAsync(x => x.Id == movie.Id);

            if (existingMovie is null)
            {
                return null;
            }

            _dataContext.Entry(existingMovie).CurrentValues.SetValues(movie);
            return movie;
        }
        public async Task<Movie> DeleteMovie(int id)
        {
            var existingMovie = await _dataContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            _dataContext.Set<Movie>().Remove(existingMovie);
            return existingMovie;

        }
    }
}
