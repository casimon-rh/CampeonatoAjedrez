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
    public class PARTIDAApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PARTIDAApi
        public IQueryable<PARTIDA> GetPARTIDA()
        {
            return db.PARTIDA;
        }

        // GET: api/PARTIDAApi/5
        [ResponseType(typeof(PARTIDA))]
        public async Task<IHttpActionResult> GetPARTIDA(int id)
        {
            PARTIDA pARTIDA = await db.PARTIDA.FindAsync(id);
            if (pARTIDA == null)
            {
                return NotFound();
            }

            return Ok(pARTIDA);
        }

        // PUT: api/PARTIDAApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPARTIDA(int id, PARTIDA pARTIDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pARTIDA.IDPARTIDA)
            {
                return BadRequest();
            }

            db.Entry(pARTIDA).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PARTIDAExists(id))
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

        // POST: api/PARTIDAApi
        [ResponseType(typeof(PARTIDA))]
        public async Task<IHttpActionResult> PostPARTIDA(PARTIDA pARTIDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PARTIDA.Add(pARTIDA);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pARTIDA.IDPARTIDA }, pARTIDA);
        }

        // DELETE: api/PARTIDAApi/5
        [ResponseType(typeof(PARTIDA))]
        public async Task<IHttpActionResult> DeletePARTIDA(int id)
        {
            PARTIDA pARTIDA = await db.PARTIDA.FindAsync(id);
            if (pARTIDA == null)
            {
                return NotFound();
            }

            db.PARTIDA.Remove(pARTIDA);
            await db.SaveChangesAsync();

            return Ok(pARTIDA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PARTIDAExists(int id)
        {
            return db.PARTIDA.Count(e => e.IDPARTIDA == id) > 0;
        }
    }
}