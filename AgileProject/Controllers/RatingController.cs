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
    public class RatingController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // POST
        // api/Rating
        [HttpPost]
        public async Task<IHttpActionResult> PostRating([FromBody] Rating model)
        {
            if (model is null)
                return BadRequest("Your request body cannot be empty");
        
            if(!ModelState.IsValid)            
                return BadRequest(ModelState);

            Content content = await _context.ContentList.FindAsync(model.ContentId);
            if (content is null)
                return NotFound();

            _context.Ratings.Add(model);
            content.Ratings.Add(model);
            model.Content = content;
            await _context.SaveChangesAsync();
            return Ok("Rating was created.");            
        }


        // GET ALL
        // api/Rating
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Rating> ratings = await _context.Ratings.Include(r => r.Content).ToListAsync();
            return Ok(ratings);
        }


        // GET BY ID
        // api/Rating/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            //Rating rating = await _context.Ratings.FindAsync(id);
            Rating rating = await _context.Ratings.Include(r => r.Content).FirstOrDefaultAsync(i => i.RatingId == id);

            if (rating != null)
                return Ok(rating);

            return NotFound();
        }


        // PUT
        // api/Rating/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateById([FromUri] int id, [FromBody] Rating updatedRating)
        {
            // Check the ids if they match
            if (id != updatedRating?.RatingId)
                return BadRequest("Ids do not match.");

            // Check model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the rating in the database
            Rating oldRating = await _context.Ratings.FindAsync(id);

            // If it doesn't exist, then handle it
            if (oldRating is null)
                return NotFound();

            // Update the rating in the database
            oldRating.Score = updatedRating.Score;
            oldRating.Review = updatedRating.Review;

            // Save changes
            await _context.SaveChangesAsync();

            return Ok("Rating was updated");
        }


        // DELETE
        // api/Rating/{id}
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRating([FromUri] int id)
        {
            Rating rating = await _context.Ratings.FindAsync(id);

            if (rating is null)
                return NotFound();

            Content content = await _context.ContentList.FindAsync(rating.ContentId);
            if (content is null)
                return NotFound();

            content.Ratings.Remove(rating);
            _context.Ratings.Remove(rating);

            if (await _context.SaveChangesAsync() > 0)            
                return (Ok("Rating was deleted."));
            
            return InternalServerError();
        }
    }
}
