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
    public class PARTIDA_JUGADORViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Participantes/PARTIDA_JUGADORView
        public async Task<ActionResult> Index()
        {
            var pARTIDA_JUGADOR = db.PARTIDA_JUGADOR.Include(p => p.JUGADOR).Include(p => p.PARTIDA);
            return View(await pARTIDA_JUGADOR.ToListAsync());
        }

        // GET: Participantes/PARTIDA_JUGADORView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTIDA_JUGADOR pARTIDA_JUGADOR = await db.PARTIDA_JUGADOR.FindAsync(id);
            if (pARTIDA_JUGADOR == null)
            {
                return HttpNotFound();
            }
            return View(pARTIDA_JUGADOR);
        }

        // GET: Participantes/PARTIDA_JUGADORView/Create
        public ActionResult Create()
        {
            ViewBag.IDJUGADOR = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR");
            ViewBag.IDPARTIDA = new SelectList(db.PARTIDA, "IDPARTIDA", "IDPARTIDA");
            return View();
        }

        // POST: Participantes/PARTIDA_JUGADORView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDPARTIDA,IDJUGADOR,COLOR")] PARTIDA_JUGADOR pARTIDA_JUGADOR)
        {
            if (ModelState.IsValid)
            {
                db.PARTIDA_JUGADOR.Add(pARTIDA_JUGADOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDJUGADOR = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR", pARTIDA_JUGADOR.IDJUGADOR);
            ViewBag.IDPARTIDA = new SelectList(db.PARTIDA, "IDPARTIDA", "IDPARTIDA", pARTIDA_JUGADOR.IDPARTIDA);
            return View(pARTIDA_JUGADOR);
        }

        // GET: Participantes/PARTIDA_JUGADORView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTIDA_JUGADOR pARTIDA_JUGADOR = await db.PARTIDA_JUGADOR.FindAsync(id);
            if (pARTIDA_JUGADOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDJUGADOR = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR", pARTIDA_JUGADOR.IDJUGADOR);
            ViewBag.IDPARTIDA = new SelectList(db.PARTIDA, "IDPARTIDA", "IDPARTIDA", pARTIDA_JUGADOR.IDPARTIDA);
            return View(pARTIDA_JUGADOR);
        }

        // POST: Participantes/PARTIDA_JUGADORView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDPARTIDA,IDJUGADOR,COLOR")] PARTIDA_JUGADOR pARTIDA_JUGADOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARTIDA_JUGADOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDJUGADOR = new SelectList(db.JUGADOR, "IDJUGADOR", "IDJUGADOR", pARTIDA_JUGADOR.IDJUGADOR);
            ViewBag.IDPARTIDA = new SelectList(db.PARTIDA, "IDPARTIDA", "IDPARTIDA", pARTIDA_JUGADOR.IDPARTIDA);
            return View(pARTIDA_JUGADOR);
        }

        // GET: Participantes/PARTIDA_JUGADORView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTIDA_JUGADOR pARTIDA_JUGADOR = await db.PARTIDA_JUGADOR.FindAsync(id);
            if (pARTIDA_JUGADOR == null)
            {
                return HttpNotFound();
            }
            return View(pARTIDA_JUGADOR);
        }

        // POST: Participantes/PARTIDA_JUGADORView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PARTIDA_JUGADOR pARTIDA_JUGADOR = await db.PARTIDA_JUGADOR.FindAsync(id);
            db.PARTIDA_JUGADOR.Remove(pARTIDA_JUGADOR);
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
