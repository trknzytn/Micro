using Micro.Business.Concrates;
using Micro.Dal.Concrates.EF;
using Micro.Dal.Concrates.Repo;
using Micro.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Micro.MediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly ILogger<MediaController> _logger;
        MicroMediaContext _microMediaContext;
        MovieManager movieManager;
        MovieVoteManager movieVoteManager;
        
        public MediaController(ILogger<MediaController> logger, MicroMediaContext MicroMediaContext)
        {
            _logger = logger;
            _microMediaContext = MicroMediaContext;
            movieManager = new MovieManager(new MovieRepository(_microMediaContext));
            movieVoteManager = new MovieVoteManager(new MovieVoteRepository(_microMediaContext));
        }

        
        [Authorize]
        [HttpGet("GetMovieList")]
        public IEnumerable<Movie> GetList(string page)
        {            
           return movieManager.Find(x=>x.page == Convert.ToInt32(page));
        }

        [Authorize]
        [HttpGet("GetMovie")]
        public Movie GetMovie(string id)
        {
            return movieManager.Find(x => x.id == (Convert.ToInt32(id))).FirstOrDefault();
        }

        [Authorize]
        [HttpPost("SendVote")]
        public HttpResponseMessage SendVote([FromBody] MovieVote movieVote)
        {  
            if (ModelState.IsValid)
            {
                movieVoteManager.Add(movieVote);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("AdviceMovie")]
        public HttpResponseMessage AdviceMovie([FromBody] MailModel mailModel)
        {
            try
            {
                string body = "<h3>" + mailModel.Message + " " + mailModel.MovieId + "</h3>";
                EmailManager emailManager = new EmailManager();
                emailManager.Send(mailModel.MailAddress, mailModel.Subject, body);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
        }

    }
}
