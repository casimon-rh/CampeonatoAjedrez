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
    public class HOTEL_TELEFONOApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/HOTEL_TELEFONOApi
        public IQueryable<HOTEL_TELEFONO> GetHOTEL_TELEFONO()
        {
            return db.HOTEL_TELEFONO;
        }

        // GET: api/HOTEL_TELEFONOApi/5
        [ResponseType(typeof(HOTEL_TELEFONO))]
        public async Task<IHttpActionResult> GetHOTEL_TELEFONO(int id)
        {
            HOTEL_TELEFONO hOTEL_TELEFONO = await db.HOTEL_TELEFONO.FindAsync(id);
            if (hOTEL_TELEFONO == null)
            {
                return NotFound();
            }

            return Ok(hOTEL_TELEFONO);
        }

        // PUT: api/HOTEL_TELEFONOApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHOTEL_TELEFONO(int id, HOTEL_TELEFONO hOTEL_TELEFONO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hOTEL_TELEFONO.ID_TELEFONO)
            {
                return BadRequest();
            }

            db.Entry(hOTEL_TELEFONO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HOTEL_TELEFONOExists(id))
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

        // POST: api/HOTEL_TELEFONOApi
        [ResponseType(typeof(HOTEL_TELEFONO))]
        public async Task<IHttpActionResult> PostHOTEL_TELEFONO(HOTEL_TELEFONO hOTEL_TELEFONO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HOTEL_TELEFONO.Add(hOTEL_TELEFONO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hOTEL_TELEFONO.ID_TELEFONO }, hOTEL_TELEFONO);
        }

        // DELETE: api/HOTEL_TELEFONOApi/5
        [ResponseType(typeof(HOTEL_TELEFONO))]
        public async Task<IHttpActionResult> DeleteHOTEL_TELEFONO(int id)
        {
            HOTEL_TELEFONO hOTEL_TELEFONO = await db.HOTEL_TELEFONO.FindAsync(id);
            if (hOTEL_TELEFONO == null)
            {
                return NotFound();
            }

            db.HOTEL_TELEFONO.Remove(hOTEL_TELEFONO);
            await db.SaveChangesAsync();

            return Ok(hOTEL_TELEFONO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HOTEL_TELEFONOExists(int id)
        {
            return db.HOTEL_TELEFONO.Count(e => e.ID_TELEFONO == id) > 0;
        }
    }
}