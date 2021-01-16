using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ServicesController : ApiController
    {
        private UserManagementContext db = new UserManagementContext();

        // GET: api/Services
        public IQueryable<Services> GetServices()
        {
            return db.Services;
        }

        // GET: api/Services/5
        [ResponseType(typeof(Services))]
        public async Task<IHttpActionResult> GetServices(int id)
        {
            Services services = await db.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }
        [HttpGet]
        [Route("api/Services/lisMedecins/{id}")]
        public List<Medecin> listMedecins(int id)
        {
            return db.Medecins.Where(a => a.ServiceID == id).ToList();
        }


        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServices(int id, Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != services.ServiceID)
            {
                return BadRequest();
            }

            db.Entry(services).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(id))
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

        // POST: api/Services
        [ResponseType(typeof(Services))]
        public async Task<IHttpActionResult> PostServices(Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Services.Add(services);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = services.ServiceID }, services);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Services))]
        public async Task<IHttpActionResult> DeleteServices(int id)
        {
            Services services = await db.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            db.Services.Remove(services);
            await db.SaveChangesAsync();

            return Ok(services);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServicesExists(int id)
        {
            return db.Services.Count(e => e.ServiceID == id) > 0;
        }
    }
}