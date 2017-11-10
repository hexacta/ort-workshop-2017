using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OrtWorkshopBackend.Data.Entities;

namespace OrtWorkshopBackend.Data
{
    public class SeedData
    {
        private static ILogger logger;

        public void Initialize(IServiceProvider serviceProvider, string databaseName)
        {
            DbContextOptions<OrtWorkshopContext> ortWorkshopContext = serviceProvider.GetRequiredService<DbContextOptions<OrtWorkshopContext>>();

            logger = serviceProvider.GetRequiredService<ILogger<SeedData>>();

            using (var context = new OrtWorkshopContext(ortWorkshopContext))
            {
                context.Database.EnsureCreated();

                //Look for any movies.
                if (context.Movie.Any())
                {
                    logger.LogInformation("There is data in movie table");

                    return;
                }

                logger.LogInformation("Insert data in movie table");

                //Add movies
                context.Movie.AddRange(
                        new Movie
                        {
                            Title = "Blade Runner",
                            Year = 1982,
                            Genre = "Sci-Fi, Thriller",
                            Director = "Ridley Scott" 
                        },

                        new Movie
                        {
                            Title = "Alien",
                            Year = 1979,
                            Genre = "Horror, Sci-Fi",
                            Director = "Ridley Scott",
                        }
                );

                //Save
                context.SaveChanges();
            }
        }
    }
}