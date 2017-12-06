using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OrtWorkshopBackend.Data;
using OrtWorkshopBackend.Data.Entities;
using OrtWorkshopBackend.Data.Models;
using OrtWorkshopBackend.Service.Contract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;

namespace OrtWorkshopBackend.Service.Implement
{
    public class MovieService : IMovieService
    {
        private readonly ILogger logger;
        
        private readonly OrtWorkshopContext ortWorkshopContext;

        public MovieService(ILogger<MovieService> logger, OrtWorkshopContext ortWorkshopContext)
        {
            this.logger = logger;

            this.ortWorkshopContext = ortWorkshopContext; 
        }

        public async Task<MovieModel> Get(int movieId)
        {
            logger.LogInformation($"Service get movie ID '{movieId}'");

            Movie movie = await this.ortWorkshopContext.Movie.FindAsync(movieId);

            if (movie == null)
            {
                throw new OrtWorkshopException(HttpStatusCode.NotFound, $"The movie with ID {movieId} wasn't found.");
            }

            MovieModel movieModel = this.ConvertEntityToModel(movie);

            return movieModel;
        }

        public async Task<IEnumerable<MovieModel>> GetAll()
        {
            logger.LogInformation($"Service get all movies");

            List<Movie> movies = await this.ortWorkshopContext.Movie.ToListAsync();

            var moviesModel = new List<MovieModel>();

            movies.ForEach(entity => moviesModel.Add(this.ConvertEntityToModel(entity)));

            return moviesModel;
        }

        public async Task<int> Add(MovieModel movieModel)
        {
            logger.LogInformation($"Service add movie title '{movieModel.Title}'");

            Movie movie = this.ConvertModelToEntity(movieModel);

            EntityEntry<Movie> movieNew = this.ortWorkshopContext.Movie.Add(movie);

            await this.ortWorkshopContext.SaveChangesAsync();

            return movieNew.Entity.MovieId;
        }

        public async Task Remove(int movieId)
        {
            logger.LogInformation($"Service remove movie ID '{movieId}'");

            Movie movieDelete = await this.ortWorkshopContext.Movie.FindAsync(movieId);

            if (movieDelete == null)
            {
                throw new OrtWorkshopException(HttpStatusCode.NotFound, $"The movie with ID {movieId} wasn't found.");
            }

            this.ortWorkshopContext.Entry<Movie>(movieDelete).State = EntityState.Deleted; 

            await this.ortWorkshopContext.SaveChangesAsync();
        }

        public async Task Update(int movieId, MovieModel movieModel)
        {
            logger.LogInformation($"Service update movie ID '{movieId}'");

            //TODO Workshop

            //anular este paso
            await Task.CompletedTask;

            //Steps
            //search movie

            //update movie from movie parameter

            //update status

            //save changes
        }

        private MovieModel ConvertEntityToModel(Movie movie)
        {
            var movieModel = new MovieModel
            {
                MovieId = movie.MovieId,
                Director = movie.Director,
                Genre = movie.Genre,
                Title = movie.Title,
                Year = movie.Year,
            };

            return movieModel;
        }

        private Movie ConvertModelToEntity(MovieModel movieModel)
        {
            var movie = new Movie
            {
                MovieId = movieModel.MovieId,
                Director = movieModel.Director,
                Genre = movieModel.Genre,
                Title = movieModel.Title,
                Year = movieModel.Year,
            };

            return movie;
        }
    }
}