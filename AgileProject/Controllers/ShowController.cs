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
    public class ShowController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // POST
        // api/Show
        [HttpPost]
        public async Task<IHttpActionResult> PostShow([FromBody] Show model)
        {
            if (model is null)
                return BadRequest("Your request body cannot be empty");

            model.TypeOfContent = ContentType.Show;

            if (ModelState.IsValid)
            {
                _context.ContentList.Add(model);
                await _context.SaveChangesAsync();
                return Ok("Show was created.");
            }

            return BadRequest(ModelState);
        }


        // GET ALL
        // api/Show
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Content> contentList = await _context.ContentList.Where(c => c.TypeOfContent == ContentType.Show).ToListAsync();
            List<Show> shows = new List<Show>();

            foreach (Content c in contentList)
            {
                shows.Add((Show)c);
            }

            if (shows.Count > 0)
                return Ok(shows);

            return NotFound();
        }


        // GET BY ID
        // api/Show/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Content content = await _context.ContentList.FindAsync(id);

            if (content != null && content.TypeOfContent == ContentType.Show)
                return Ok((Show)content);

            return NotFound();
        }

        // GET SHOWS WITH 5 OR MORE SEASONS
        // api/Show/
        /// <summary>
        /// Retrieves all shows with at least 5 seasons.
        [Route("api/Show/GetLongShows")]
        [HttpGet]
        public async Task<IHttpActionResult> GetLongShows()
        {
            List<Content> contentList = await _context.ContentList.Where(c => c.TypeOfContent == ContentType.Show).ToListAsync();
            List<Show> shows = new List<Show>();

            foreach (Show s in contentList)
            {
                if (s.NumberOfSeasons >= 5)
                    shows.Add((Show)s);
            }

            if (shows.Count > 0)
                return Ok(shows);

            return NotFound();
        }

        // PUT
        // api/Show/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateById([FromUri] int id, [FromBody] Show updatedShow)
        {
            // Check the ids if they match
            if (id != updatedShow?.ContentId)
                return BadRequest("Ids do not match.");

            // Check model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the show in the database
            Content oldContent = await _context.ContentList.FindAsync(id);
            if (oldContent is null || oldContent.TypeOfContent != ContentType.Show)
                return NotFound();

            Show oldShow = (Show)oldContent;

            // Update the show in the database
            oldShow.Title = updatedShow.Title;
            oldShow.Description = updatedShow.Description;
            oldShow.NumberOfSeasons = updatedShow.NumberOfSeasons;

            // Save changes
            await _context.SaveChangesAsync();

            return Ok("Show was updated");
        }

        // DELETE
        // api/Show/{id}
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteShow([FromUri] int id)
        {
            Content content = await _context.ContentList.FindAsync(id);
            if (content is null || content.TypeOfContent != ContentType.Show)
                return NotFound();

            Show show = (Show)content;

            _context.ContentList.Remove(show);

            if (await _context.SaveChangesAsync() > 0)
                return (Ok("Show was deleted."));

            return InternalServerError();
        }
    }
}
