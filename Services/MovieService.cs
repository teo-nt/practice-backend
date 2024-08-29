using MovieAPI.DTO;
using MovieAPI.Models;
using MovieAPI.Repositories;

namespace MovieAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MovieReadOnlyDTO> CreateMovie(MovieCreateDTOcs movie)
        {
            var newMovie = new Movie
            {
                Title = movie.Title,
                Url = movie.Url,
                Price = movie.Price,
                Country = movie.Country,
                Description = movie.Description,
                Director = movie.Director,
                Genre = movie.Genre,
                Language = movie.Language,
                LeadActor = movie.LeadActor,
                Plot = movie.Plot,
                Rate = movie.Rate,
                ReleaseDate = movie.ReleaseDate,
                ScreenYear = movie.ScreenYear,
                Type = movie.Type,
                Writer = movie.Writer
            };

            await _unitOfWork.MovieRepository.CreateMovie(newMovie);
            await _unitOfWork.SaveAsync();

            var movieToReturn = new MovieReadOnlyDTO
            {
                Id = newMovie.Id,
                Title = newMovie.Title,
                Url = newMovie.Url,
                Price = newMovie.Price,
                Country = newMovie.Country,
                Description = newMovie.Description,
                Director = newMovie.Director,
                Genre = newMovie.Genre,
                Language = newMovie.Language,
                LeadActor = newMovie.LeadActor,
                Plot = newMovie.Plot,
                Rate = newMovie.Rate,
                ReleaseDate = newMovie.ReleaseDate,
                ScreenYear = newMovie.ScreenYear,
                Type = newMovie.Type,
                Writer = newMovie.Writer
            };

            return movieToReturn;
        }

        public async Task<MovieReadOnlyDTO> DeleteMovie(int id)
        {
            var movieToDelete = await _unitOfWork.MovieRepository.GetMovieById(id);

            if (movieToDelete == null)
            {
                return null;
            }
            await _unitOfWork.MovieRepository.DeleteMovie(id);
            await _unitOfWork.SaveAsync();

            var movieToReturn = new MovieReadOnlyDTO
            {
                Id = movieToDelete.Id,
                Title = movieToDelete.Title,
                Url = movieToDelete.Url,
                Price= movieToDelete.Price,
                Country = movieToDelete.Country,
                Description = movieToDelete.Description,
                Director = movieToDelete.Director,
                Genre = movieToDelete.Genre,
                Language = movieToDelete.Language,
                LeadActor = movieToDelete.LeadActor,
                Plot = movieToDelete.Plot,
                Rate = movieToDelete.Rate,
                ReleaseDate = movieToDelete.ReleaseDate,
                ScreenYear = movieToDelete.ScreenYear,
                Type = movieToDelete.Type,
                Writer = movieToDelete.Writer
            };
            return movieToReturn;
        }

        public async Task<IEnumerable<MovieReadOnlyDTO>> GetAllMovies()
        {
            var existingMovies = await _unitOfWork.MovieRepository.GetAllMovies();

            var movies = new List<MovieReadOnlyDTO>();
            foreach (var movie in existingMovies)
            {
                movies.Add(new MovieReadOnlyDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Url = movie.Url,
                    Price = movie.Price,
                    Country = movie.Country,
                    Description = movie.Description,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    Language = movie.Language,
                    LeadActor = movie.LeadActor,
                    Plot = movie.Plot,
                    Rate = movie.Rate,
                    ReleaseDate = movie.ReleaseDate,
                    ScreenYear = movie.ScreenYear,
                    Type = movie.Type,
                    Writer = movie.Writer
                });
            }
            return movies;
        }

        public async Task<MovieReadOnlyDTO> GetMovieById(int id)
        {
            var existingMovie = await _unitOfWork.MovieRepository.GetMovieById(id);

            if (existingMovie is null)
            {
                return null;
            }

            var movieToReturn = new MovieReadOnlyDTO
            {
                Id = existingMovie.Id,
                Title = existingMovie.Title,
                Url = existingMovie.Url,
                Price = existingMovie.Price,
                Country = existingMovie.Country,
                Description = existingMovie.Description,
                Director = existingMovie.Director,
                Genre = existingMovie.Genre,
                Language = existingMovie.Language,
                LeadActor = existingMovie.LeadActor,
                Plot = existingMovie.Plot,
                Rate = existingMovie.Rate,
                ReleaseDate = existingMovie.ReleaseDate,
                ScreenYear = existingMovie.ScreenYear,
                Type = existingMovie.Type,
                Writer = existingMovie.Writer
            };
            return movieToReturn;
        }

        public async Task<MovieReadOnlyDTO> UpdateMovie(MovieUpdateDTO movie)
        {
            var existingMovie = await _unitOfWork.MovieRepository.GetMovieById(movie.Id);

            if (existingMovie == null)
            {
                return null;
            }

            var editableMovie = new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Url = movie.Url,
                Price = movie.Price,
                Country = movie.Country,
                Description = movie.Description,
                Director = movie.Director,
                Genre = movie.Genre,
                Language = movie.Language,
                LeadActor = movie.LeadActor,
                Plot = movie.Plot,
                Rate = movie.Rate,
                ReleaseDate = movie.ReleaseDate,
                ScreenYear = movie.ScreenYear,
                Type = movie.Type,
                Writer = movie.Writer
            };


            await _unitOfWork.MovieRepository.UpdateMovie(editableMovie);
            await _unitOfWork.SaveAsync();

            var movieToUpdate = new MovieReadOnlyDTO
            {
                Id = editableMovie.Id,
                Title = editableMovie.Title,
                Url = editableMovie.Url,
                Price = editableMovie.Price,
                Country = editableMovie.Country,
                Description = editableMovie.Description,
                Director = editableMovie.Director,
                Genre = editableMovie.Genre,
                Language = editableMovie.Language,
                LeadActor = editableMovie.LeadActor,
                Plot = editableMovie.Plot,
                Rate = editableMovie.Rate,
                ReleaseDate = editableMovie.ReleaseDate,
                ScreenYear = editableMovie.ScreenYear,
                Type = editableMovie.Type,
                Writer = editableMovie.Writer
            };

            return movieToUpdate;
        }
    }
}
