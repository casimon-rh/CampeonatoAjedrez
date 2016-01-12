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

namespace CampeonatoAjedrezAPI.Areas.Campeonatos.Controllers
{
    public class CAMPEONATO_ANTERIOR_PARTICIPANTEApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/CAMPEONATO_ANTERIOR_PARTICIPANTEApi
        public IQueryable<CAMPEONATO_ANTERIOR_PARTICIPANTE> GetCAMPEONATO_ANTERIOR_PARTICIPANTE()
        {
            return db.CAMPEONATO_ANTERIOR_PARTICIPANTE;
        }

        // GET: api/CAMPEONATO_ANTERIOR_PARTICIPANTEApi/5
        [ResponseType(typeof(CAMPEONATO_ANTERIOR_PARTICIPANTE))]
        public async Task<IHttpActionResult> GetCAMPEONATO_ANTERIOR_PARTICIPANTE(int id)
        {
            CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE = await db.CAMPEONATO_ANTERIOR_PARTICIPANTE.FindAsync(id);
            if (cAMPEONATO_ANTERIOR_PARTICIPANTE == null)
            {
                return NotFound();
            }

            return Ok(cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        // PUT: api/CAMPEONATO_ANTERIOR_PARTICIPANTEApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCAMPEONATO_ANTERIOR_PARTICIPANTE(int id, CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAMPEONATO_ANTERIOR_PARTICIPANTE.IDCAMPEONATO)
            {
                return BadRequest();
            }

            db.Entry(cAMPEONATO_ANTERIOR_PARTICIPANTE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAMPEONATO_ANTERIOR_PARTICIPANTEExists(id))
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

        // POST: api/CAMPEONATO_ANTERIOR_PARTICIPANTEApi
        [ResponseType(typeof(CAMPEONATO_ANTERIOR_PARTICIPANTE))]
        public async Task<IHttpActionResult> PostCAMPEONATO_ANTERIOR_PARTICIPANTE(CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAMPEONATO_ANTERIOR_PARTICIPANTE.Add(cAMPEONATO_ANTERIOR_PARTICIPANTE);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CAMPEONATO_ANTERIOR_PARTICIPANTEExists(cAMPEONATO_ANTERIOR_PARTICIPANTE.IDCAMPEONATO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cAMPEONATO_ANTERIOR_PARTICIPANTE.IDCAMPEONATO }, cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        // DELETE: api/CAMPEONATO_ANTERIOR_PARTICIPANTEApi/5
        [ResponseType(typeof(CAMPEONATO_ANTERIOR_PARTICIPANTE))]
        public async Task<IHttpActionResult> DeleteCAMPEONATO_ANTERIOR_PARTICIPANTE(int id)
        {
            CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE = await db.CAMPEONATO_ANTERIOR_PARTICIPANTE.FindAsync(id);
            if (cAMPEONATO_ANTERIOR_PARTICIPANTE == null)
            {
                return NotFound();
            }

            db.CAMPEONATO_ANTERIOR_PARTICIPANTE.Remove(cAMPEONATO_ANTERIOR_PARTICIPANTE);
            await db.SaveChangesAsync();

            return Ok(cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAMPEONATO_ANTERIOR_PARTICIPANTEExists(int id)
        {
            return db.CAMPEONATO_ANTERIOR_PARTICIPANTE.Count(e => e.IDCAMPEONATO == id) > 0;
        }
    }
}