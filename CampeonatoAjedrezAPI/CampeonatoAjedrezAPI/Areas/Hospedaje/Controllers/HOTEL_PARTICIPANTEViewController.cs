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
    public class HOTEL_PARTICIPANTEViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Hospedaje/HOTEL_PARTICIPANTEView
        public async Task<ActionResult> Index()
        {
            var hOTEL_PARTICIPANTE = db.HOTEL_PARTICIPANTE.Include(h => h.HOTEL).Include(h => h.PARTICIPANTE);
            return View(await hOTEL_PARTICIPANTE.ToListAsync());
        }

        // GET: Hospedaje/HOTEL_PARTICIPANTEView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE = await db.HOTEL_PARTICIPANTE.FindAsync(id);
            if (hOTEL_PARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL_PARTICIPANTE);
        }

        // GET: Hospedaje/HOTEL_PARTICIPANTEView/Create
        public ActionResult Create()
        {
            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL");
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE");
            return View();
        }

        // POST: Hospedaje/HOTEL_PARTICIPANTEView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PARTICIPANTE,ID_HOTEL,FECHA_INICIO,FECHA_FINAL")] HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE)
        {
            if (ModelState.IsValid)
            {
                db.HOTEL_PARTICIPANTE.Add(hOTEL_PARTICIPANTE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL", hOTEL_PARTICIPANTE.ID_HOTEL);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", hOTEL_PARTICIPANTE.ID_PARTICIPANTE);
            return View(hOTEL_PARTICIPANTE);
        }

        // GET: Hospedaje/HOTEL_PARTICIPANTEView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE = await db.HOTEL_PARTICIPANTE.FindAsync(id);
            if (hOTEL_PARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL", hOTEL_PARTICIPANTE.ID_HOTEL);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", hOTEL_PARTICIPANTE.ID_PARTICIPANTE);
            return View(hOTEL_PARTICIPANTE);
        }

        // POST: Hospedaje/HOTEL_PARTICIPANTEView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PARTICIPANTE,ID_HOTEL,FECHA_INICIO,FECHA_FINAL")] HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOTEL_PARTICIPANTE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HOTEL = new SelectList(db.HOTEL, "ID_HOTEL", "NOMBREHOTEL", hOTEL_PARTICIPANTE.ID_HOTEL);
            ViewBag.ID_PARTICIPANTE = new SelectList(db.PARTICIPANTE, "ID_PARTICIPANTE", "NOMBRE", hOTEL_PARTICIPANTE.ID_PARTICIPANTE);
            return View(hOTEL_PARTICIPANTE);
        }

        // GET: Hospedaje/HOTEL_PARTICIPANTEView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE = await db.HOTEL_PARTICIPANTE.FindAsync(id);
            if (hOTEL_PARTICIPANTE == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL_PARTICIPANTE);
        }

        // POST: Hospedaje/HOTEL_PARTICIPANTEView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HOTEL_PARTICIPANTE hOTEL_PARTICIPANTE = await db.HOTEL_PARTICIPANTE.FindAsync(id);
            db.HOTEL_PARTICIPANTE.Remove(hOTEL_PARTICIPANTE);
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
