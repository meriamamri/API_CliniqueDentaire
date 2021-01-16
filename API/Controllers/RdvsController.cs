using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using API.RetourType;

namespace API.Controllers
{
    public class RdvsController : ApiController
    {
        private UserManagementContext db = new UserManagementContext();

        // GET: api/Rdvs
        public List<Rdv> GetRdvs()
        {
           
            return db.Rdvs.ToList();
        }


        [HttpGet]
        [Route("api/Rdvs/Medecin/{id}")]
        public List<Rdv> GetRdvsByMedecin(int id)
        {
            DateTime inf = DateTime.Today;
         //   DateTime sup = DateTime.Today.AddDays(1);
          //  return db.Rdvs.Where(p => p.MedecinID == id && p.Date > inf && p.Date < sup).OrderBy(p =>p.Hdebut).ToList();
            return db.Rdvs.Where(p => p.MedecinID == id && p.Date==inf).OrderBy(p => p.Hdebut).ToList();
        }


        [HttpGet]
        [Route("api/Rdvs/disponibilities/{id}/{date}")]
        public List<DayIntervals> GetDisponiblities(int id,DateTime date)
        {
            


            List<DayIntervals> days = new List<DayIntervals>();
            DateTime comp = date;

            //diponibilities for 5 days
            for (int i = 0; i < 5; i++)
            {

                DayIntervals dispo = new DayIntervals();
                dispo.day = comp;
                dispo.intervals = new List<Interval>();

                //get list rendez vous
                List<Rdv> t = db.Rdvs.Where(p => p.MedecinID == id && p.Date == comp).OrderBy(p => p.Hdebut).ToList();


                //preparing disponibilities intervals

                DateTime debut = new DateTime(comp.Year, comp.Month, comp.Day, 9, 00, 0);

                if (t.Count == 0)
                {
                    dispo.intervals.Add(new Interval(new DateTime(comp.Year, comp.Month, comp.Day, 9, 00, 0), new DateTime(comp.Year, comp.Month, comp.Day, 18, 00, 0)));
                }
                else
                { 
                    foreach (Rdv rd in t)
                    {
                        if (rd.Hdebut > debut)
                        {
                            Interval it = new Interval(debut, (DateTime)rd.Hdebut);
                            debut = (DateTime)rd.Hfin;
                            dispo.intervals.Add(it);
                        }
                        else
                        if (rd.Hdebut == debut)
                        {

                            debut = (DateTime)rd.Hfin;
                        }


                    }
                    if (t[t.Count - 1].Hfin < new DateTime(comp.Year, comp.Month, comp.Day, 18, 00, 0))
                    {
                        Interval it = new Interval((DateTime)t[t.Count - 1].Hfin, new DateTime(comp.Year, comp.Month, comp.Day, 18, 00, 0));
                        dispo.intervals.Add(it);
                    }

                }

                days.Add(dispo);
                comp=comp.AddDays(1);
            }





            return days;
        }


    

        // GET: api/Rdvs/5
        [ResponseType(typeof(Rdv))]
        public IHttpActionResult GetRdv(int id)
        {
            Rdv rdv = db.Rdvs.Find(id);
            if (rdv == null)
            {
                return NotFound();
            }

            return Ok(rdv);
        }

        // PUT: api/Rdvs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRdv(int id, Rdv rdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rdv.RdvID)
            {
                return BadRequest();
            }

            db.Entry(rdv).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RdvExists(id))
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

        // POST: api/Rdvs
        [ResponseType(typeof(Rdv))]
        public IHttpActionResult PostRdv(Rdv rdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            List<Rdv> t = db.Rdvs.Where(p => rdv.Date==p.Date 
            && (p.Hdebut>=rdv.Hdebut && p.Hdebut <rdv.Hfin)  ||(rdv.Hdebut >= p.Hdebut && rdv.Hdebut < p.Hfin)).ToList();


            if (t.Count == 0)
            {
                db.Rdvs.Add(rdv);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = rdv.RdvID }, rdv);

            }
            else
                return BadRequest();

        }

        // DELETE: api/Rdvs/5
        [ResponseType(typeof(Rdv))]
        public IHttpActionResult DeleteRdv(int id)
        {
            Rdv rdv = db.Rdvs.Find(id);
            if (rdv == null)
            {
                return NotFound();
            }

            db.Rdvs.Remove(rdv);
            db.SaveChanges();

            return Ok(rdv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RdvExists(int id)
        {
            return db.Rdvs.Count(e => e.RdvID == id) > 0;
        }
    }
}