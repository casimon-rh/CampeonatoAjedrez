using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CampeonatoAjedrezAPI.Areas;

namespace CampeonatoAjedrezAPI.Areas.Participantes.Controllers
{
    public class PARTICIPANTEViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Participantes/PARTICIPANTEView
        public async Task<ActionResult> Index()
        {
            var pARTICIPANTE = db.PARTICIPANTE.Include(p => p.ARBITRO).Include(p => p.JUGADOR).Include(p => p.LOCALIDAD);
            return View(await pARTICIPANTE.ToListAsync());
        }

        // GET: Participantes/PARTICIPANTEView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPANTE pARTICIPANTE = await db.PARTICIPANTE.FindAsync(id);
            if (pARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            return View(pARTICIPANTE);
        }

        // GET: Participantes/PARTICIPANTEView/Create
        public ActionResult Create()
        {
            ViewBag.ID_PARTICIPANTE = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO");
            ViewBag.ID_PARTICIPANTE = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR");
            ViewBag.IDLOCALIDAD = new SelectList(db.LOCALIDAD, "IDLOCALIDAD", "NOMLOCALIDAD");
            return View();
        }

        // POST: Participantes/PARTICIPANTEView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PARTICIPANTE,NOMBRE,APPATERNO,APMATERNO,IDLOCALIDAD")] PARTICIPANTE pARTICIPANTE)
        {
            if (ModelState.IsValid)
            {
                db.PARTICIPANTE.Add(pARTICIPANTE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PARTICIPANTE = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO", pARTICIPANTE.ID_PARTICIPANTE);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR", pARTICIPANTE.ID_PARTICIPANTE);
            ViewBag.IDLOCALIDAD = new SelectList(db.LOCALIDAD, "IDLOCALIDAD", "NOMLOCALIDAD", pARTICIPANTE.IDLOCALIDAD);
            return View(pARTICIPANTE);
        }

        // GET: Participantes/PARTICIPANTEView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPANTE pARTICIPANTE = await db.PARTICIPANTE.FindAsync(id);
            if (pARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PARTICIPANTE = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO", pARTICIPANTE.ID_PARTICIPANTE);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR", pARTICIPANTE.ID_PARTICIPANTE);
            ViewBag.IDLOCALIDAD = new SelectList(db.LOCALIDAD, "IDLOCALIDAD", "NOMLOCALIDAD", pARTICIPANTE.IDLOCALIDAD);
            return View(pARTICIPANTE);
        }

        // POST: Participantes/PARTICIPANTEView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PARTICIPANTE,NOMBRE,APPATERNO,APMATERNO,IDLOCALIDAD")] PARTICIPANTE pARTICIPANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARTICIPANTE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PARTICIPANTE = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO", pARTICIPANTE.ID_PARTICIPANTE);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR", pARTICIPANTE.ID_PARTICIPANTE);
            ViewBag.IDLOCALIDAD = new SelectList(db.LOCALIDAD, "IDLOCALIDAD", "NOMLOCALIDAD", pARTICIPANTE.IDLOCALIDAD);
            return View(pARTICIPANTE);
        }

        // GET: Participantes/PARTICIPANTEView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTICIPANTE pARTICIPANTE = await db.PARTICIPANTE.FindAsync(id);
            if (pARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            return View(pARTICIPANTE);
        }

        // POST: Participantes/PARTICIPANTEView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PARTICIPANTE pARTICIPANTE = await db.PARTICIPANTE.FindAsync(id);
            db.PARTICIPANTE.Remove(pARTICIPANTE);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
