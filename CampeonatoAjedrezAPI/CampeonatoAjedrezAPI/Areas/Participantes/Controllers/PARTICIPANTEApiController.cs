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

namespace CampeonatoAjedrezAPI.Areas.Participantes.Controllers
{
    public class PARTICIPANTEApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PARTICIPANTEApi
        public IQueryable<PARTICIPANTE> GetPARTICIPANTE()
        {
            return db.PARTICIPANTE;
        }

        // GET: api/PARTICIPANTEApi/5
        [ResponseType(typeof(PARTICIPANTE))]
        public async Task<IHttpActionResult> GetPARTICIPANTE(int id)
        {
            PARTICIPANTE pARTICIPANTE = await db.PARTICIPANTE.FindAsync(id);
            if (pARTICIPANTE == null)
            {
                return NotFound();
            }

            return Ok(pARTICIPANTE);
        }

        // PUT: api/PARTICIPANTEApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPARTICIPANTE(int id, PARTICIPANTE pARTICIPANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pARTICIPANTE.ID_PARTICIPANTE)
            {
                return BadRequest();
            }

            db.Entry(pARTICIPANTE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PARTICIPANTEExists(id))
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

        // POST: api/PARTICIPANTEApi
        [ResponseType(typeof(PARTICIPANTE))]
        public async Task<IHttpActionResult> PostPARTICIPANTE(PARTICIPANTE pARTICIPANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PARTICIPANTE.Add(pARTICIPANTE);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pARTICIPANTE.ID_PARTICIPANTE }, pARTICIPANTE);
        }

        // DELETE: api/PARTICIPANTEApi/5
        [ResponseType(typeof(PARTICIPANTE))]
        public async Task<IHttpActionResult> DeletePARTICIPANTE(int id)
        {
            PARTICIPANTE pARTICIPANTE = await db.PARTICIPANTE.FindAsync(id);
            if (pARTICIPANTE == null)
            {
                return NotFound();
            }

            db.PARTICIPANTE.Remove(pARTICIPANTE);
            await db.SaveChangesAsync();

            return Ok(pARTICIPANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PARTICIPANTEExists(int id)
        {
            return db.PARTICIPANTE.Count(e => e.ID_PARTICIPANTE == id) > 0;
        }
    }
}