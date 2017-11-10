using System.Collections.Generic;
using System.Threading.Tasks;
using OrtWorkshopBackend.Data.Entities;

namespace OrtWorkshopBackend.Service.Contract
{
    public interface IMovieService
    {
        Task<Movie> Get(int movieId);

        Task<IEnumerable<Movie>> GetAll();

        Task<int> Add(Movie movie);
        
        Task Remove(int movieId);
        
        Task Update(int movieId, Movie movie);
    }
}