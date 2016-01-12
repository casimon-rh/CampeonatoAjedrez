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
    public class ARBITROApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ARBITROApi
        public IQueryable<ARBITRO> GetARBITRO()
        {
            return db.ARBITRO;
        }

        // GET: api/ARBITROApi/5
        [ResponseType(typeof(ARBITRO))]
        public async Task<IHttpActionResult> GetARBITRO(int id)
        {
            ARBITRO aRBITRO = await db.ARBITRO.FindAsync(id);
            if (aRBITRO == null)
            {
                return NotFound();
            }

            return Ok(aRBITRO);
        }

        // PUT: api/ARBITROApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutARBITRO(int id, ARBITRO aRBITRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aRBITRO.IDARBITRO)
            {
                return BadRequest();
            }

            db.Entry(aRBITRO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ARBITROExists(id))
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

        // POST: api/ARBITROApi
        [ResponseType(typeof(ARBITRO))]
        public async Task<IHttpActionResult> PostARBITRO(ARBITRO aRBITRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ARBITRO.Add(aRBITRO);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ARBITROExists(aRBITRO.IDARBITRO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aRBITRO.IDARBITRO }, aRBITRO);
        }

        // DELETE: api/ARBITROApi/5
        [ResponseType(typeof(ARBITRO))]
        public async Task<IHttpActionResult> DeleteARBITRO(int id)
        {
            ARBITRO aRBITRO = await db.ARBITRO.FindAsync(id);
            if (aRBITRO == null)
            {
                return NotFound();
            }

            db.ARBITRO.Remove(aRBITRO);
            await db.SaveChangesAsync();

            return Ok(aRBITRO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ARBITROExists(int id)
        {
            return db.ARBITRO.Count(e => e.IDARBITRO == id) > 0;
        }
    }
}