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
    public class CAMPEONATO_ANTERIORViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Campeonatos/CAMPEONATO_ANTERIORView
        public async Task<ActionResult> Index()
        {
            return View(await db.CAMPEONATO_ANTERIOR.ToListAsync());
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIORView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR = await db.CAMPEONATO_ANTERIOR.FindAsync(id);
            if (cAMPEONATO_ANTERIOR == null)
            {
                return HttpNotFound();
            }
            return View(cAMPEONATO_ANTERIOR);
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIORView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campeonatos/CAMPEONATO_ANTERIORView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCAMPEONATO,FECHA,NOMBRE")] CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR)
        {
            if (ModelState.IsValid)
            {
                db.CAMPEONATO_ANTERIOR.Add(cAMPEONATO_ANTERIOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cAMPEONATO_ANTERIOR);
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIORView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR = await db.CAMPEONATO_ANTERIOR.FindAsync(id);
            if (cAMPEONATO_ANTERIOR == null)
            {
                return HttpNotFound();
            }
            return View(cAMPEONATO_ANTERIOR);
        }

        // POST: Campeonatos/CAMPEONATO_ANTERIORView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCAMPEONATO,FECHA,NOMBRE")] CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMPEONATO_ANTERIOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cAMPEONATO_ANTERIOR);
        }

        // GET: Campeonatos/CAMPEONATO_ANTERIORView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR = await db.CAMPEONATO_ANTERIOR.FindAsync(id);
            if (cAMPEONATO_ANTERIOR == null)
            {
                return HttpNotFound();
            }
            return View(cAMPEONATO_ANTERIOR);
        }

        // POST: Campeonatos/CAMPEONATO_ANTERIORView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CAMPEONATO_ANTERIOR cAMPEONATO_ANTERIOR = await db.CAMPEONATO_ANTERIOR.FindAsync(id);
            db.CAMPEONATO_ANTERIOR.Remove(cAMPEONATO_ANTERIOR);
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
