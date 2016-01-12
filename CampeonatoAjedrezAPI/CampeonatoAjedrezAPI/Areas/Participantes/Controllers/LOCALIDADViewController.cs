﻿using System;
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
    public class LOCALIDADViewController : Controller
    {
        private Model1 db = new Model1();

        // GET: Participantes/LOCALIDADView
        public async Task<ActionResult> Index()
        {
            return View(await db.LOCALIDAD.ToListAsync());
        }

        // GET: Participantes/LOCALIDADView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOCALIDAD lOCALIDAD = await db.LOCALIDAD.FindAsync(id);
            if (lOCALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(lOCALIDAD);
        }

        // GET: Participantes/LOCALIDADView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participantes/LOCALIDADView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDLOCALIDAD,NOMLOCALIDAD")] LOCALIDAD lOCALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.LOCALIDAD.Add(lOCALIDAD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lOCALIDAD);
        }

        // GET: Participantes/LOCALIDADView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOCALIDAD lOCALIDAD = await db.LOCALIDAD.FindAsync(id);
            if (lOCALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(lOCALIDAD);
        }

        // POST: Participantes/LOCALIDADView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDLOCALIDAD,NOMLOCALIDAD")] LOCALIDAD lOCALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOCALIDAD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lOCALIDAD);
        }

        // GET: Participantes/LOCALIDADView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOCALIDAD lOCALIDAD = await db.LOCALIDAD.FindAsync(id);
            if (lOCALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(lOCALIDAD);
        }

        // POST: Participantes/LOCALIDADView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LOCALIDAD lOCALIDAD = await db.LOCALIDAD.FindAsync(id);
            db.LOCALIDAD.Remove(lOCALIDAD);
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
