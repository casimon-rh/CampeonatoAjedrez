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
    public class PARTIDA_JUGADORApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PARTIDA_JUGADORApi
        public IQueryable<PARTIDA_JUGADOR> GetPARTIDA_JUGADOR()
        {
            return db.PARTIDA_JUGADOR;
        }

        // GET: api/PARTIDA_JUGADORApi/5
        [ResponseType(typeof(PARTIDA_JUGADOR))]
        public async Task<IHttpActionResult> GetPARTIDA_JUGADOR(int id)
        {
            PARTIDA_JUGADOR pARTIDA_JUGADOR = await db.PARTIDA_JUGADOR.FindAsync(id);
            if (pARTIDA_JUGADOR == null)
            {
                return NotFound();
            }

            return Ok(pARTIDA_JUGADOR);
        }

        // PUT: api/PARTIDA_JUGADORApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPARTIDA_JUGADOR(int id, PARTIDA_JUGADOR pARTIDA_JUGADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pARTIDA_JUGADOR.IDPARTIDA)
            {
                return BadRequest();
            }

            db.Entry(pARTIDA_JUGADOR).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PARTIDA_JUGADORExists(id))
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

        // POST: api/PARTIDA_JUGADORApi
        [ResponseType(typeof(PARTIDA_JUGADOR))]
        public async Task<IHttpActionResult> PostPARTIDA_JUGADOR(PARTIDA_JUGADOR pARTIDA_JUGADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PARTIDA_JUGADOR.Add(pARTIDA_JUGADOR);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PARTIDA_JUGADORExists(pARTIDA_JUGADOR.IDPARTIDA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pARTIDA_JUGADOR.IDPARTIDA }, pARTIDA_JUGADOR);
        }

        // DELETE: api/PARTIDA_JUGADORApi/5
        [ResponseType(typeof(PARTIDA_JUGADOR))]
        public async Task<IHttpActionResult> DeletePARTIDA_JUGADOR(int id)
        {
            PARTIDA_JUGADOR pARTIDA_JUGADOR = await db.PARTIDA_JUGADOR.FindAsync(id);
            if (pARTIDA_JUGADOR == null)
            {
                return NotFound();
            }

            db.PARTIDA_JUGADOR.Remove(pARTIDA_JUGADOR);
            await db.SaveChangesAsync();

            return Ok(pARTIDA_JUGADOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PARTIDA_JUGADORExists(int id)
        {
            return db.PARTIDA_JUGADOR.Count(e => e.IDPARTIDA == id) > 0;
        }
    }
}