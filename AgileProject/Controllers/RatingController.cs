using AgileProject.Models;
using System;
using System.Collections.Generic;
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

        }


        // GET ALL
        // api/Rating
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {

        }


        // GET BY ID
        // api/Rating/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {

        }


        // PUT
        // api/Rating/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateById([FromUri] int id, [FromBody] Rating updatedRating)
        {

        }


        // DELETE
        // api/Rating/{id}
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRating([FromUri] int id)
        {

        }
    }
}
