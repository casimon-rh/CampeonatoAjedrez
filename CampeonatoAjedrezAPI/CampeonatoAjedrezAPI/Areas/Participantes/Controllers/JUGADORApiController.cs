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
    public class JUGADORApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/JUGADORApi
        public IQueryable<JUGADOR> GetJUGADOR()
        {
            return db.JUGADOR;
        }

        // GET: api/JUGADORApi/5
        [ResponseType(typeof(JUGADOR))]
        public async Task<IHttpActionResult> GetJUGADOR(int id)
        {
            JUGADOR jUGADOR = await db.JUGADOR.FindAsync(id);
            if (jUGADOR == null)
            {
                return NotFound();
            }

            return Ok(jUGADOR);
        }

        // PUT: api/JUGADORApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJUGADOR(int id, JUGADOR jUGADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jUGADOR.IDJUGADOR)
            {
                return BadRequest();
            }

            db.Entry(jUGADOR).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JUGADORExists(id))
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

        // POST: api/JUGADORApi
        [ResponseType(typeof(JUGADOR))]
        public async Task<IHttpActionResult> PostJUGADOR(JUGADOR jUGADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JUGADOR.Add(jUGADOR);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JUGADORExists(jUGADOR.IDJUGADOR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jUGADOR.IDJUGADOR }, jUGADOR);
        }

        // DELETE: api/JUGADORApi/5
        [ResponseType(typeof(JUGADOR))]
        public async Task<IHttpActionResult> DeleteJUGADOR(int id)
        {
            JUGADOR jUGADOR = await db.JUGADOR.FindAsync(id);
            if (jUGADOR == null)
            {
                return NotFound();
            }

            db.JUGADOR.Remove(jUGADOR);
            await db.SaveChangesAsync();

            return Ok(jUGADOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JUGADORExists(int id)
        {
            return db.JUGADOR.Count(e => e.IDJUGADOR == id) > 0;
        }
    }
}