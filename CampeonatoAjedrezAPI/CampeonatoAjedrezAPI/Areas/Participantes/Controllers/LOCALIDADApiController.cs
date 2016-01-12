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
    public class LOCALIDADApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/LOCALIDADApi
        public IQueryable<LOCALIDAD> GetLOCALIDAD()
        {
            return db.LOCALIDAD;
        }

        // GET: api/LOCALIDADApi/5
        [ResponseType(typeof(LOCALIDAD))]
        public async Task<IHttpActionResult> GetLOCALIDAD(int id)
        {
            LOCALIDAD lOCALIDAD = await db.LOCALIDAD.FindAsync(id);
            if (lOCALIDAD == null)
            {
                return NotFound();
            }

            return Ok(lOCALIDAD);
        }

        // PUT: api/LOCALIDADApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLOCALIDAD(int id, LOCALIDAD lOCALIDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lOCALIDAD.IDLOCALIDAD)
            {
                return BadRequest();
            }

            db.Entry(lOCALIDAD).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LOCALIDADExists(id))
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

        // POST: api/LOCALIDADApi
        [ResponseType(typeof(LOCALIDAD))]
        public async Task<IHttpActionResult> PostLOCALIDAD(LOCALIDAD lOCALIDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LOCALIDAD.Add(lOCALIDAD);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lOCALIDAD.IDLOCALIDAD }, lOCALIDAD);
        }

        // DELETE: api/LOCALIDADApi/5
        [ResponseType(typeof(LOCALIDAD))]
        public async Task<IHttpActionResult> DeleteLOCALIDAD(int id)
        {
            LOCALIDAD lOCALIDAD = await db.LOCALIDAD.FindAsync(id);
            if (lOCALIDAD == null)
            {
                return NotFound();
            }

            db.LOCALIDAD.Remove(lOCALIDAD);
            await db.SaveChangesAsync();

            return Ok(lOCALIDAD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LOCALIDADExists(int id)
        {
            return db.LOCALIDAD.Count(e => e.IDLOCALIDAD == id) > 0;
        }
    }
}