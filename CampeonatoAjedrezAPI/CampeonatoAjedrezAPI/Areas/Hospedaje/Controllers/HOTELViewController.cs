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

namespace CampeonatoAjedrezAPI.Areas.Hospedaje.Controllers
{
    public class HOTELViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Hospedaje/HOTELView
        public async Task<ActionResult> Index()
        {
            return View(await db.HOTEL.ToListAsync());
        }

        // GET: Hospedaje/HOTELView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = await db.HOTEL.FindAsync(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL);
        }

        // GET: Hospedaje/HOTELView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospedaje/HOTELView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_HOTEL,NOMBREHOTEL,DIRNUM,DIRCALLE,DIRCP")] HOTEL hOTEL)
        {
            if (ModelState.IsValid)
            {
                db.HOTEL.Add(hOTEL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hOTEL);
        }

        // GET: Hospedaje/HOTELView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = await db.HOTEL.FindAsync(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL);
        }

        // POST: Hospedaje/HOTELView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_HOTEL,NOMBREHOTEL,DIRNUM,DIRCALLE,DIRCP")] HOTEL hOTEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOTEL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hOTEL);
        }

        // GET: Hospedaje/HOTELView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = await db.HOTEL.FindAsync(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL);
        }

        // POST: Hospedaje/HOTELView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HOTEL hOTEL = await db.HOTEL.FindAsync(id);
            db.HOTEL.Remove(hOTEL);
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
