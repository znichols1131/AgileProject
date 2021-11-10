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

            if (ModelState.IsValid)
            {
                _context.Movies.Add(model);
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
            List<Movie> movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }


        // GET BY ID
        // api/Movie/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);

            if (movie != null)
                return Ok(movie);

            return NotFound();
        }


        // PUT
        // api/Movie/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateById([FromUri] int id, [FromBody] Movie updatedMovie)
        {
            // Check the ids if they match
            if (id != updatedMovie?.MovieId)
                return BadRequest("Ids do not match.");

            // Check model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the movie in the database
            Movie oldMovie = await _context.Movies.FindAsync(id);

            // If it doesn't exist, then handle it
            if (oldMovie is null)
                return NotFound();

            // Update the movie in the database
            oldMovie.Title = updatedMovie.Title;
            oldMovie.Description = updatedMovie.Description;

            // Save changes
            await _context.SaveChangesAsync();

            return Ok("Movie was updated");
        }


        // DELETE
        // api/Movie/{id}
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMovie([FromUri] int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);

            if (movie is null)
                return NotFound();

            _context.Movies.Remove(movie);

            if (await _context.SaveChangesAsync() > 0)
                return (Ok("Movie was deleted."));

            return InternalServerError();
        }
    }
}
