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
    public class HOTEL_PARTICIPANTEApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/HOTEL_PARTICIPANTEApi
        public IQueryable<HOTEL_PARTICIPANTE> GetHOTEL_PARTICIPANTE()
        {
            return db.HOTEL_PARTICIPANTE;
        }

        // GET: api/HOTEL_PARTICIPANTEApi/5
        [ResponseType(typeof(HOTEL_PARTICIPANTE))]
        public async Task<IHttpActionResult> GetHOTEL_PARTICIPANTE(int id)
        {
            HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE = await db.HOTEL_PARTICIPANTE.FindAsync(id);
            if (hOTEL_PARTICIPANTE == null)
            {
                return NotFound();
            }

            return Ok(hOTEL_PARTICIPANTE);
        }

        // PUT: api/HOTEL_PARTICIPANTEApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHOTEL_PARTICIPANTE(int id, HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hOTEL_PARTICIPANTE.ID_PARTICIPANTE)
            {
                return BadRequest();
            }

            db.Entry(hOTEL_PARTICIPANTE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HOTEL_PARTICIPANTEExists(id))
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

        // POST: api/HOTEL_PARTICIPANTEApi
        [ResponseType(typeof(HOTEL_PARTICIPANTE))]
        public async Task<IHttpActionResult> PostHOTEL_PARTICIPANTE(HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HOTEL_PARTICIPANTE.Add(hOTEL_PARTICIPANTE);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HOTEL_PARTICIPANTEExists(hOTEL_PARTICIPANTE.ID_PARTICIPANTE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hOTEL_PARTICIPANTE.ID_PARTICIPANTE }, hOTEL_PARTICIPANTE);
        }

        // DELETE: api/HOTEL_PARTICIPANTEApi/5
        [ResponseType(typeof(HOTEL_PARTICIPANTE))]
        public async Task<IHttpActionResult> DeleteHOTEL_PARTICIPANTE(int id)
        {
            HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE = await db.HOTEL_PARTICIPANTE.FindAsync(id);
            if (hOTEL_PARTICIPANTE == null)
            {
                return NotFound();
            }

            db.HOTEL_PARTICIPANTE.Remove(hOTEL_PARTICIPANTE);
            await db.SaveChangesAsync();

            return Ok(hOTEL_PARTICIPANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HOTEL_PARTICIPANTEExists(int id)
        {
            return db.HOTEL_PARTICIPANTE.Count(e => e.ID_PARTICIPANTE == id) > 0;
        }
    }
}