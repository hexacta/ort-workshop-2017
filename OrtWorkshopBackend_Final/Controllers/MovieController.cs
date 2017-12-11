using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrtWorkshopBackend.Data.Models;
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

            IEnumerable<MovieModel> moviesModel = await this.movieService.GetAll();

            return Ok(moviesModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            logger.LogInformation($"Get movie with ID '{id}'");
            
            MovieModel movieModel = await this.movieService.Get(id);

            return Ok(movieModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MovieModel movieModel)
        {
            logger.LogInformation($"New movie title '{movieModel.Title}'");
            
            int movieId = await this.movieService.Add(movieModel);

            return Ok(new { movieId = movieId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]MovieModel movieModel)
        {
            logger.LogInformation($"Update movie title '{movieModel.Title}'");

            await this.movieService.Update(id, movieModel);

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
