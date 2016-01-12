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

namespace CampeonatoAjedrezAPI.Areas.Campeonatos.Controllers
{
    public class CAMPEONATO_ANTERIOR_PARTICIPANTEViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView
        public async Task<ActionResult> Index()
        {
            var cAMPEONATO_ANTERIOR_PARTICIPANTE = db.CAMPEONATO_ANTERIOR_PARTICIPANTE.Include(c => c.CAMPEONATO_ANTERIOR).Include(c => c.PARTICIPANTE);
            return View(await cAMPEONATO_ANTERIOR_PARTICIPANTE.ToListAsync());
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE = await db.CAMPEONATO_ANTERIOR_PARTICIPANTE.FindAsync(id);
            if (cAMPEONATO_ANTERIOR_PARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            return View(cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView/Create
        public ActionResult Create()
        {
            ViewBag.IDCAMPEONATO = new SelectList(db.CAMPEONATO_ANTERIOR, "IDCAMPEONATO", "NOMBRE");
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE");
            return View();
        }

        // POST: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCAMPEONATO,ID_PARTICIPANTE,TIPO")] CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE)
        {
            if (ModelState.IsValid)
            {
                db.CAMPEONATO_ANTERIOR_PARTICIPANTE.Add(cAMPEONATO_ANTERIOR_PARTICIPANTE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDCAMPEONATO = new SelectList(db.CAMPEONATO_ANTERIOR, "IDCAMPEONATO", "NOMBRE", cAMPEONATO_ANTERIOR_PARTICIPANTE.IDCAMPEONATO);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", cAMPEONATO_ANTERIOR_PARTICIPANTE.ID_PARTICIPANTE);
            return View(cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE = await db.CAMPEONATO_ANTERIOR_PARTICIPANTE.FindAsync(id);
            if (cAMPEONATO_ANTERIOR_PARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCAMPEONATO = new SelectList(db.CAMPEONATO_ANTERIOR, "IDCAMPEONATO", "NOMBRE", cAMPEONATO_ANTERIOR_PARTICIPANTE.IDCAMPEONATO);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", cAMPEONATO_ANTERIOR_PARTICIPANTE.ID_PARTICIPANTE);
            return View(cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        // POST: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCAMPEONATO,ID_PARTICIPANTE,TIPO")] CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMPEONATO_ANTERIOR_PARTICIPANTE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDCAMPEONATO = new SelectList(db.CAMPEONATO_ANTERIOR, "IDCAMPEONATO", "NOMBRE", cAMPEONATO_ANTERIOR_PARTICIPANTE.IDCAMPEONATO);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", cAMPEONATO_ANTERIOR_PARTICIPANTE.ID_PARTICIPANTE);
            return View(cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE = await db.CAMPEONATO_ANTERIOR_PARTICIPANTE.FindAsync(id);
            if (cAMPEONATO_ANTERIOR_PARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            return View(cAMPEONATO_ANTERIOR_PARTICIPANTE);
        }

        // POST: Campeonatos/CAMPEONATO_ANTERIOR_PARTICIPANTEView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CAMPEONATO_ANTERIOR_PARTICIPANTE cAMPEONATO_ANTERIOR_PARTICIPANTE = await db.CAMPEONATO_ANTERIOR_PARTICIPANTE.FindAsync(id);
            db.CAMPEONATO_ANTERIOR_PARTICIPANTE.Remove(cAMPEONATO_ANTERIOR_PARTICIPANTE);
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
