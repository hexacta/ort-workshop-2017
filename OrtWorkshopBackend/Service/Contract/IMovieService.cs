using System.Collections.Generic;
using System.Threading.Tasks;
using OrtWorkshopBackend.Data.Models;

namespace OrtWorkshopBackend.Service.Contract
{
    public interface IMovieService
    {
        Task<MovieModel> Get(int movieId);

        Task<IEnumerable<MovieModel>> GetAll();

        Task<int> Add(MovieModel movieModel);
        
        Task Remove(int movieId);
        
        Task Update(int movieId, MovieModel movieModel);
    }
}