using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OrtWorkshopBackend.Data;
using OrtWorkshopBackend.Service.Contract;
using OrtWorkshopBackend.Service.Implement;

namespace OrtWorkshopBackend
{
    public class Startup
    {
        public const string InMemoryDatabaseName = "79E14EE0-8C55-4980-BCF8-DC13A8C1B87C";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext by Dependency Injection | InMemory 
            services.AddDbContext<OrtWorkshopContext>(options => 
                options.UseInMemoryDatabase(Startup.InMemoryDatabaseName));

            //Dependency Injection
            services.AddTransient<IMovieService, MovieService>();

            services.AddLogging();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials() );
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseErrorCustomHandling();

            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
