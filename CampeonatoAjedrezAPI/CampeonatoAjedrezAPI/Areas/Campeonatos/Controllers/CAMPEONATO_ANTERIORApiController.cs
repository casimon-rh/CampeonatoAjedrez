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
    public class CAMPEONATO_ANTERIORApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/CAMPEONATO_ANTERIORApi
        public IQueryable<CAMPEONATO_ANTERIOR> GetCAMPEONATO_ANTERIOR()
        {
            return db.CAMPEONATO_ANTERIOR;
        }

        // GET: api/CAMPEONATO_ANTERIORApi/5
        [ResponseType(typeof(CAMPEONATO_ANTERIOR))]
        public async Task<IHttpActionResult> GetCAMPEONATO_ANTERIOR(int id)
        {
            CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR = await db.CAMPEONATO_ANTERIOR.FindAsync(id);
            if (cAMPEONATO_ANTERIOR == null)
            {
                return NotFound();
            }

            return Ok(cAMPEONATO_ANTERIOR);
        }

        // PUT: api/CAMPEONATO_ANTERIORApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCAMPEONATO_ANTERIOR(int id, CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAMPEONATO_ANTERIOR.IDCAMPEONATO)
            {
                return BadRequest();
            }

            db.Entry(cAMPEONATO_ANTERIOR).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAMPEONATO_ANTERIORExists(id))
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

        // POST: api/CAMPEONATO_ANTERIORApi
        [ResponseType(typeof(CAMPEONATO_ANTERIOR))]
        public async Task<IHttpActionResult> PostCAMPEONATO_ANTERIOR(CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAMPEONATO_ANTERIOR.Add(cAMPEONATO_ANTERIOR);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cAMPEONATO_ANTERIOR.IDCAMPEONATO }, cAMPEONATO_ANTERIOR);
        }

        // DELETE: api/CAMPEONATO_ANTERIORApi/5
        [ResponseType(typeof(CAMPEONATO_ANTERIOR))]
        public async Task<IHttpActionResult> DeleteCAMPEONATO_ANTERIOR(int id)
        {
            CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR = await db.CAMPEONATO_ANTERIOR.FindAsync(id);
            if (cAMPEONATO_ANTERIOR == null)
            {
                return NotFound();
            }

            db.CAMPEONATO_ANTERIOR.Remove(cAMPEONATO_ANTERIOR);
            await db.SaveChangesAsync();

            return Ok(cAMPEONATO_ANTERIOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAMPEONATO_ANTERIORExists(int id)
        {
            return db.CAMPEONATO_ANTERIOR.Count(e => e.IDCAMPEONATO == id) > 0;
        }
    }
}