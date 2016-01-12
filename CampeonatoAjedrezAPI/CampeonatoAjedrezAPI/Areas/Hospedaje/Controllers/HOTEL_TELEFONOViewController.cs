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
    public class HOTEL_TELEFONOViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Hospedaje/HOTEL_TELEFONOView
        public async Task<ActionResult> Index()
        {
            var hOTEL_TELEFONO = db.HOTEL_TELEFONO.Include(h => h.HOTEL);
            return View(await hOTEL_TELEFONO.ToListAsync());
        }

        // GET: Hospedaje/HOTEL_TELEFONOView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_TELEFONO hOTEL_TELEFONO = await db.HOTEL_TELEFONO.FindAsync(id);
            if (hOTEL_TELEFONO == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL_TELEFONO);
        }

        // GET: Hospedaje/HOTEL_TELEFONOView/Create
        public ActionResult Create()
        {
            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL");
            return View();
        }

        // POST: Hospedaje/HOTEL_TELEFONOView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_TELEFONO,ID_HOTEL,TELEFONO")] HOTEL_TELEFONO hOTEL_TELEFONO)
        {
            if (ModelState.IsValid)
            {
                db.HOTEL_TELEFONO.Add(hOTEL_TELEFONO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL", hOTEL_TELEFONO.ID_HOTEL);
            return View(hOTEL_TELEFONO);
        }

        // GET: Hospedaje/HOTEL_TELEFONOView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_TELEFONO hOTEL_TELEFONO = await db.HOTEL_TELEFONO.FindAsync(id);
            if (hOTEL_TELEFONO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL", hOTEL_TELEFONO.ID_HOTEL);
            return View(hOTEL_TELEFONO);
        }

        // POST: Hospedaje/HOTEL_TELEFONOView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_TELEFONO,ID_HOTEL,TELEFONO")] HOTEL_TELEFONO hOTEL_TELEFONO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOTEL_TELEFONO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL", hOTEL_TELEFONO.ID_HOTEL);
            return View(hOTEL_TELEFONO);
        }

        // GET: Hospedaje/HOTEL_TELEFONOView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_TELEFONO hOTEL_TELEFONO = await db.HOTEL_TELEFONO.FindAsync(id);
            if (hOTEL_TELEFONO == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL_TELEFONO);
        }

        // POST: Hospedaje/HOTEL_TELEFONOView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HOTEL_TELEFONO hOTEL_TELEFONO = await db.HOTEL_TELEFONO.FindAsync(id);
            db.HOTEL_TELEFONO.Remove(hOTEL_TELEFONO);
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
