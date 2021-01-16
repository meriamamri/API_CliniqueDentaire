using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class MedecinsController : ApiController
    {
        private UserManagementContext db = new UserManagementContext();

        // GET: api/Medecins
        public List<Medecin> GetMedecins()
        {
            return db.Medecins.ToList(); 
        }

        // GET: api/Medecins/5
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult GetMedecin(int id)
        {
            Medecin medecin = db.Medecins.Find(id);
            if (medecin == null)
            {
                return NotFound();
            }

            return Ok(medecin);
        }

        [HttpGet]
        [Route("api/Medecin/get/{id}")]

        [ResponseType(typeof(Medecin))]
        public IHttpActionResult GetMedecinByUserId(int id)
        {
            try
            {
                Medecin medecin = db.Medecins.Where(a => a.UserID == id).Single();
                if (medecin == null)
                {
                    return NotFound();
                }
                else
                    return Ok(medecin);


            }
            catch (Exception)
            {
                return NotFound();
            }
 
        }

        // PUT: api/Medecins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedecin(int id, Medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medecin.MedecinID)
            {
                return BadRequest();
            }

            db.Entry(medecin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedecinExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Medecins
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult PostMedecin(Medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medecins.Add(medecin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medecin.MedecinID }, medecin);
        }

        // DELETE: api/Medecins/5
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult DeleteMedecin(int id)
        {
            Medecin medecin = db.Medecins.Find(id);
            if (medecin == null)
            {
                return NotFound();
            }

            db.Medecins.Remove(medecin);
            db.SaveChanges();

            return Ok(medecin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedecinExists(int id)
        {
            return db.Medecins.Count(e => e.MedecinID == id) > 0;
        }
    }
}