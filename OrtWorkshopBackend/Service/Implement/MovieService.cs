using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OrtWorkshopBackend.Data;
using OrtWorkshopBackend.Data.Entities;
using OrtWorkshopBackend.Service.Contract;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<Movie> Get(int movieId)
        {
            logger.LogInformation($"Service get movie ID '{movieId}'");

            Movie movie = await this.ortWorkshopContext.Movie.FindAsync(movieId);

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            logger.LogInformation($"Service get all movies");

            List<Movie> movies = await this.ortWorkshopContext.Movie.ToListAsync();

            return movies;
        }

        public async Task<int> Add(Movie movie)
        {
            logger.LogInformation($"Service add movie title '{movie.Title}'");

            EntityEntry<Movie> movieNew = this.ortWorkshopContext.Movie.Add(movie);

            await this.ortWorkshopContext.SaveChangesAsync();

            return movieNew.Entity.MovieId;
        }

        public async Task Remove(int movieId)
        {
            logger.LogInformation($"Service remove movie ID '{movieId}'");

            Movie movieDelete = await this.ortWorkshopContext.Movie.FindAsync(movieId);

            this.ortWorkshopContext.Entry<Movie>(movieDelete).State = EntityState.Deleted; 

            await this.ortWorkshopContext.SaveChangesAsync();
        }

        public async Task Update(int movieId, Movie movie)
        {
            logger.LogInformation($"Service update movie ID '{movieId}'");

            //TODO Workshop
            await Task.CompletedTask;

            /*
            Steps:
            search movie
            update movie from movie parameter
            update status
            save changes
            */
        }
    }
}