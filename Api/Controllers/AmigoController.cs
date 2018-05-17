using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
    public class AmigoController : ApiController
    {
        private AppDbContext _context;

        public AmigoController()
        {
            _context = new AppDbContext();
            
        }

        //GET /api/amigo
        public IHttpActionResult GetAmigo()
        {
            var amigos = _context.Amigos.ToList();

            return Ok(amigos);
        }

        //GET /api/amigo/1
        public IHttpActionResult GetAmigo(int id)
        {
            var amigo = _context.Amigos.SingleOrDefault(x => x.Id == id);

            if (amigo == null)
                return NotFound();

            return Ok(amigo);
        }

        //POST /api/amigo
        [HttpPost]
        public IHttpActionResult CreateAmigo(Amigo amigo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Amigos.Add(amigo);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + amigo.Id), amigo);

        }

        //PUT /api/amigo/1
        [HttpPut]
        public IHttpActionResult UpdateAmigo(int id, Amigo amigo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var amigoInDb = _context.Amigos.SingleOrDefault(x => x.Id == id);

            if (amigoInDb == null)
                return NotFound();

            amigoInDb.Name = amigo.Name;
            amigoInDb.LastName = amigo.LastName;
            amigoInDb.Email = amigo.Email;
            amigoInDb.Birthday = amigo.Birthday;
            amigoInDb.Tel = amigo.Tel;

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/amigo/1
        [HttpDelete]
        public IHttpActionResult DeleteAmigo(int id)
        {
            var amigoInDb = _context.Amigos.SingleOrDefault(x => x.Id == id);

            if (amigoInDb == null)
                return NotFound();

            _context.Amigos.Remove(amigoInDb);

            _context.SaveChanges();

            return Ok();

        }


    }
}
