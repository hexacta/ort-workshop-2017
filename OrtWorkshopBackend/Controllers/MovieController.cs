using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrtWorkshopBackend.Data.Entities;
using OrtWorkshopBackend.Service.Contract;

namespace OrtWorkshopBackend.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly ILogger logger;
        
        private readonly IMovieService movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            this.logger = logger;

            this.movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Get all movies");

            IEnumerable<Movie> movies = await this.movieService.GetAll();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            logger.LogInformation($"Get movie with ID '{id}'");
            
            Movie movie = await this.movieService.Get(id);

            return Ok(movie);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Movie movie)
        {
            logger.LogInformation($"New movie title '{movie.Title}'");
            
            int movieId = await this.movieService.Add(movie);

            return Ok(new { movieId = movieId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(int id, [FromBody]Movie movie)
        {
            logger.LogInformation($"Update movie title '{movie.Title}'");

            //TODO Workshop
            //await this.movieService.Update(id, movie);
        
            await Task.CompletedTask;

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation($"Delete movie ID '{id}'");
            
            await this.movieService.Remove(id);

            return Ok();
        }
    }
}
