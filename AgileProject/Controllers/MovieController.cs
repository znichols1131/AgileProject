using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgileProject.Controllers
{
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // POST
        // api/Movie
        [HttpPost]
        public async Task<IHttpActionResult> PostMovie([FromBody] Movie model)
        {
            if (model is null)
                return BadRequest("Your request body cannot be empty");

            model.TypeOfContent = ContentType.Movie;

            if (ModelState.IsValid)
            {
                _context.ContentList.Add(model);
                await _context.SaveChangesAsync();
                return Ok("Movie was created.");
            }

            return BadRequest(ModelState);
        }


        // GET ALL
        // api/Movie
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Content> contentList = await _context.ContentList.Where(c => c.TypeOfContent == ContentType.Movie).ToListAsync();
            List<Movie> movies = new List<Movie>();

            foreach(Content c in contentList)
            {
                if (c.TypeOfContent == ContentType.Movie)
                    movies.Add((Movie)c);
            }

            if (movies.Count > 0)
                return Ok(movies);

            return NotFound();
        }


        // GET BY ID
        // api/Movie/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Content content = await _context.ContentList.FindAsync(id);

            if (content != null && content.TypeOfContent == ContentType.Movie)
                return Ok((Movie) content);

            return NotFound();
        }


        // PUT
        // api/Movie/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateById([FromUri] int id, [FromBody] Movie updatedMovie)
        {
            // Check the ids if they match
            if (id != updatedMovie?.ContentId)
                return BadRequest("Ids do not match.");

            // Check model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the movie in the database
            Content oldContent = await _context.ContentList.FindAsync(id);
            if (oldContent is null || oldContent.TypeOfContent != ContentType.Movie)
                return NotFound();

            Movie oldMovie = (Movie)oldContent;

            // Update the movie in the database
            oldMovie.Title = updatedMovie.Title;
            oldMovie.Description = updatedMovie.Description;
            oldMovie.LengthOfMovie = updatedMovie.LengthOfMovie;

            // Save changes
            await _context.SaveChangesAsync();

            return Ok("Movie was updated");
        }


        // DELETE
        // api/Movie/{id}
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMovie([FromUri] int id)
        {
            Content content = await _context.ContentList.FindAsync(id);
            if (content is null || content.TypeOfContent != ContentType.Movie)
                return NotFound();

            Movie movie = (Movie)content;

            _context.ContentList.Remove(movie);

            if (await _context.SaveChangesAsync() > 0)
                return (Ok("Movie was deleted."));

            return InternalServerError();
        }
    }
}
