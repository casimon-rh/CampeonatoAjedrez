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
    public class JUGADORViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Participantes/JUGADORView
        public async Task<ActionResult> Index()
        {
            var jUGADOR = db.JUGADOR.Include(j => j.PARTICIPANTE);
            return View(await jUGADOR.ToListAsync());
        }

        // GET: Participantes/JUGADORView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JUGADOR jUGADOR = await db.JUGADOR.FindAsync(id);
            if (jUGADOR == null)
            {
                return HttpNotFound();
            }
            return View(jUGADOR);
        }

        // GET: Participantes/JUGADORView/Create
        public ActionResult Create()
        {
            ViewBag.IDJUGADOR = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE");
            return View();
        }

        // POST: Participantes/JUGADORView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDJUGADOR,NIVEL")] JUGADOR jUGADOR)
        {
            if (ModelState.IsValid)
            {
                db.JUGADOR.Add(jUGADOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDJUGADOR = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", jUGADOR.IDJUGADOR);
            return View(jUGADOR);
        }

        // GET: Participantes/JUGADORView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JUGADOR jUGADOR = await db.JUGADOR.FindAsync(id);
            if (jUGADOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDJUGADOR = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", jUGADOR.IDJUGADOR);
            return View(jUGADOR);
        }

        // POST: Participantes/JUGADORView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDJUGADOR,NIVEL")] JUGADOR jUGADOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jUGADOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDJUGADOR = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", jUGADOR.IDJUGADOR);
            return View(jUGADOR);
        }

        // GET: Participantes/JUGADORView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JUGADOR jUGADOR = await db.JUGADOR.FindAsync(id);
            if (jUGADOR == null)
            {
                return HttpNotFound();
            }
            return View(jUGADOR);
        }

        // POST: Participantes/JUGADORView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            JUGADOR jUGADOR = await db.JUGADOR.FindAsync(id);
            db.JUGADOR.Remove(jUGADOR);
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
