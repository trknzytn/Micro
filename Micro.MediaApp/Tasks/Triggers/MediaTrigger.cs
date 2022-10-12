using EFCore.BulkExtensions;
using Micro.Business.Concrates;
using Micro.Dal.Concrates.EF;
using Micro.Dal.Concrates.Repo;
using Micro.MediaApp.Tasks.Jobs;
using Micro.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
//using Quartz.Impl;
//using Quartz.Spi;

namespace Micro.MediaApp.Tasks.Triggers
{
    public class MediaTrigger
    {
        public static async void GetMoviesFromMainApi()
        {
            MovieObject movieList = new MovieObject();            
            HttpClient client = new HttpClient();
            int page=0;
            do
            {
                page++;
                HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/movie/now_playing?api_key=b1bba1cac52c7493ea1699ac204fb34d&language=en-US&page=" + page.ToString());
                if (response.IsSuccessStatusCode)
                {                    
                    movieList = await response.Content.ReadFromJsonAsync<MovieObject>();

                    var builder = WebApplication.CreateBuilder();
                    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
                    var optionsBuilder = new DbContextOptionsBuilder<MicroMediaContext>();
                    optionsBuilder.UseSqlServer(cs);
                    MicroMediaContext context = new MicroMediaContext(optionsBuilder.Options);
                    context.Database.EnsureCreated();


                    MovieManager movieManager = new MovieManager(new MovieRepository(context));

                    //movieManager.AddBulk(movieList.results);
                    movieManager.AddBulk_(movieList);
                }

            } while (movieList.total_pages >= page);
        }


    }
}
