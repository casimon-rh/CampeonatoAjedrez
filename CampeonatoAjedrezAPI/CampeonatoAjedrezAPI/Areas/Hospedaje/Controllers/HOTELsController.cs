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
using CampeonatoAjedrezAPI.Areas;

namespace CampeonatoAjedrezAPI.Areas.Hospedaje.Controllers
{
    public class HOTELsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/HOTELs
        public IQueryable<HOTEL> GetHOTEL()
        {
            return db.HOTEL;
        }

        // GET: api/HOTELs/5
        [ResponseType(typeof(HOTEL))]
        public async Task<IHttpActionResult> GetHOTEL(int id)
        {
            HOTEL hOTEL = await db.HOTEL.FindAsync(id);
            if (hOTEL == null)
            {
                return NotFound();
            }

            return Ok(hOTEL);
        }

        // PUT: api/HOTELs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHOTEL(int id, HOTEL hOTEL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hOTEL.ID_HOTEL)
            {
                return BadRequest();
            }

            db.Entry(hOTEL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HOTELExists(id))
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

        // POST: api/HOTELs
        [ResponseType(typeof(HOTEL))]
        public async Task<IHttpActionResult> PostHOTEL(HOTEL hOTEL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HOTEL.Add(hOTEL);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hOTEL.ID_HOTEL }, hOTEL);
        }

        // DELETE: api/HOTELs/5
        [ResponseType(typeof(HOTEL))]
        public async Task<IHttpActionResult> DeleteHOTEL(int id)
        {
            HOTEL hOTEL = await db.HOTEL.FindAsync(id);
            if (hOTEL == null)
            {
                return NotFound();
            }

            db.HOTEL.Remove(hOTEL);
            await db.SaveChangesAsync();

            return Ok(hOTEL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HOTELExists(int id)
        {
            return db.HOTEL.Count(e => e.ID_HOTEL == id) > 0;
        }
    }
}