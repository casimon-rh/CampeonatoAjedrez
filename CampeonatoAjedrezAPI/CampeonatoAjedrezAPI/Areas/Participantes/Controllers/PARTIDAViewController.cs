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
    public class PARTIDAViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Participantes/PARTIDAView
        public async Task<ActionResult> Index()
        {
            var pARTIDA = db.PARTIDA.Include(p => p.ARBITRO);
            return View(await pARTIDA.ToListAsync());
        }

        // GET: Participantes/PARTIDAView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTIDA pARTIDA = await db.PARTIDA.FindAsync(id);
            if (pARTIDA == null)
            {
                return HttpNotFound();
            }
            return View(pARTIDA);
        }

        // GET: Participantes/PARTIDAView/Create
        public ActionResult Create()
        {
            ViewBag.IDARBITRO = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO");
            return View();
        }

        // POST: Participantes/PARTIDAView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDPARTIDA,IDARBITRO,HORA")] PARTIDA pARTIDA)
        {
            if (ModelState.IsValid)
            {
                db.PARTIDA.Add(pARTIDA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDARBITRO = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO", pARTIDA.IDARBITRO);
            return View(pARTIDA);
        }

        // GET: Participantes/PARTIDAView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTIDA pARTIDA = await db.PARTIDA.FindAsync(id);
            if (pARTIDA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDARBITRO = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO", pARTIDA.IDARBITRO);
            return View(pARTIDA);
        }

        // POST: Participantes/PARTIDAView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDPARTIDA,IDARBITRO,HORA")] PARTIDA pARTIDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARTIDA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDARBITRO = new SelectList(db.ARBITRO, "IDARBITRO", "IDARBITRO", pARTIDA.IDARBITRO);
            return View(pARTIDA);
        }

        // GET: Participantes/PARTIDAView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTIDA pARTIDA = await db.PARTIDA.FindAsync(id);
            if (pARTIDA == null)
            {
                return HttpNotFound();
            }
            return View(pARTIDA);
        }

        // POST: Participantes/PARTIDAView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PARTIDA pARTIDA = await db.PARTIDA.FindAsync(id);
            db.PARTIDA.Remove(pARTIDA);
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
