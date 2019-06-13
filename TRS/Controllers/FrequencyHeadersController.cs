using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TRS.Models;

namespace TRS.Controllers
{
    public class FrequencyHeadersController : Controller
    {
        private TRSEntities db = new TRSEntities();

        // GET: FrequencyHeaders
        public ActionResult Index()
        {
            return View(db.FrequencyHeaders.ToList());
        }

        // GET: FrequencyHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequencyHeader frequencyHeader = db.FrequencyHeaders.Find(id);
            if (frequencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(frequencyHeader);
        }

        // GET: FrequencyHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FrequencyHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VFPFreqhedrid,Freqcode,Qty,Description,status,AddedBy,DateAdded,ChangedBy,DateChanged,ChangedPrev,DateChangedPrev,ChangedOld,DateChangedOld,DeletedBy,DateDeleted,Validbynm,Validdttm,validrecord")] FrequencyHeader frequencyHeader)
        {
            if (ModelState.IsValid)
            {
                db.FrequencyHeaders.Add(frequencyHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frequencyHeader);
        }

        // GET: FrequencyHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequencyHeader frequencyHeader = db.FrequencyHeaders.Find(id);
            if (frequencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(frequencyHeader);
        }

        // POST: FrequencyHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VFPFreqhedrid,Freqcode,Qty,Description,status,AddedBy,DateAdded,ChangedBy,DateChanged,ChangedPrev,DateChangedPrev,ChangedOld,DateChangedOld,DeletedBy,DateDeleted,Validbynm,Validdttm,validrecord")] FrequencyHeader frequencyHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frequencyHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frequencyHeader);
        }

        // GET: FrequencyHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequencyHeader frequencyHeader = db.FrequencyHeaders.Find(id);
            if (frequencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(frequencyHeader);
        }

        // POST: FrequencyHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FrequencyHeader frequencyHeader = db.FrequencyHeaders.Find(id);
            db.FrequencyHeaders.Remove(frequencyHeader);
            db.SaveChanges();
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
        //UpdateRowSource routine
        [HttpPost]
        public ActionResult UpdateFrequencyHeader(FrequencyHeader frequencyheader)
        {
            using (TRSEntities entities = new TRSEntities())
            {
                FrequencyHeader updatedFrequencyHeader = (from c in entities.FrequencyHeaders
                                                          where c.ID == frequencyheader.ID
                                                          select c).FirstOrDefault();
                updatedFrequencyHeader.Freqcode = frequencyheader.Freqcode;
                updatedFrequencyHeader.Qty = frequencyheader.Qty;
                updatedFrequencyHeader.Description = frequencyheader.Description;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }
    }
}
