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
    public class ARBITROViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Participantes/ARBITROView
        public async Task<ActionResult> Index()
        {
            var aRBITRO = db.ARBITRO.Include(a => a.PARTICIPANTE);
            return View(await aRBITRO.ToListAsync());
        }

        // GET: Participantes/ARBITROView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARBITRO aRBITRO = await db.ARBITRO.FindAsync(id);
            if (aRBITRO == null)
            {
                return HttpNotFound();
            }
            return View(aRBITRO);
        }

        // GET: Participantes/ARBITROView/Create
        public ActionResult Create()
        {
            ViewBag.IDARBITRO = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE");
            return View();
        }

        // POST: Participantes/ARBITROView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDARBITRO")] ARBITRO aRBITRO)
        {
            if (ModelState.IsValid)
            {
                db.ARBITRO.Add(aRBITRO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDARBITRO = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", aRBITRO.IDARBITRO);
            return View(aRBITRO);
        }

        // GET: Participantes/ARBITROView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARBITRO aRBITRO = await db.ARBITRO.FindAsync(id);
            if (aRBITRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDARBITRO = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", aRBITRO.IDARBITRO);
            return View(aRBITRO);
        }

        // POST: Participantes/ARBITROView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDARBITRO")] ARBITRO aRBITRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRBITRO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDARBITRO = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", aRBITRO.IDARBITRO);
            return View(aRBITRO);
        }

        // GET: Participantes/ARBITROView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARBITRO aRBITRO = await db.ARBITRO.FindAsync(id);
            if (aRBITRO == null)
            {
                return HttpNotFound();
            }
            return View(aRBITRO);
        }

        // POST: Participantes/ARBITROView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ARBITRO aRBITRO = await db.ARBITRO.FindAsync(id);
            db.ARBITRO.Remove(aRBITRO);
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
