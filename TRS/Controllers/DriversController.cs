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
    public class DriversController : Controller
    {
        private TRSEntities db = new TRSEntities();

        // GET: Drivers
        public ActionResult Index()
        {
            var drivers = db.Drivers.Include(d => d.DriverType1).Include(d => d.licensetype1).Include(d => d.Location1).Include(d => d.state1).Include(d => d.Terminal);
            return View(drivers.ToList());
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            ViewBag.DriverType = new SelectList(db.DriverTypes, "ID", "Description");
            ViewBag.LicenseType = new SelectList(db.licensetypes, "ID", "Description");
            ViewBag.Location = new SelectList(db.Locations, "ID", "VFPLocationid");
            ViewBag.State = new SelectList(db.states, "id", "name");
            ViewBag.CoTerminal = new SelectList(db.Terminals, "ID", "Name");
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VFPDriverID,EmpNo,FrmCode,NameFirst,NameLast,NameMIddle,SocialSec,Location,CoTerminal,Company,Position,NormDisp,AddressLn1,AddressLn2,City,State,Zip,HomePhone,CellPhone,AlternatePhone,OtherPhone,Fax,Email,DateOfBirth,LicenseNumber,LicenseState,LicenseType,Licenseexpire,EmploymentDate,TerminationDate,Picture,DriverType,PhysicalExpire,BadgeType,BadgeExpire,BadgePendStat,status,AddedBy,DateAdded,ChangedBy,DateChanged,ChangedPrev,DateChangedPrev,ChangedOld,DateChangedOld,DeletedBy,dateDeleted")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Drivers.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverType = new SelectList(db.DriverTypes, "ID", "Description", driver.DriverType);
            ViewBag.LicenseType = new SelectList(db.licensetypes, "ID", "Description", driver.LicenseType);
            ViewBag.Location = new SelectList(db.Locations, "ID", "VFPLocationid", driver.Location);
            ViewBag.State = new SelectList(db.states, "id", "name", driver.State);
            ViewBag.CoTerminal = new SelectList(db.Terminals, "ID", "Name", driver.CoTerminal);
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverType = new SelectList(db.DriverTypes, "ID", "Description", driver.DriverType);
            ViewBag.LicenseType = new SelectList(db.licensetypes, "ID", "Description", driver.LicenseType);
            ViewBag.Location = new SelectList(db.Locations, "ID", "VFPLocationid", driver.Location);
            ViewBag.State = new SelectList(db.states, "id", "name", driver.State);
            ViewBag.CoTerminal = new SelectList(db.Terminals, "ID", "Name", driver.CoTerminal);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VFPDriverID,EmpNo,FrmCode,NameFirst,NameLast,NameMIddle,SocialSec,Location,CoTerminal,Company,Position,NormDisp,AddressLn1,AddressLn2,City,State,Zip,HomePhone,CellPhone,AlternatePhone,OtherPhone,Fax,Email,DateOfBirth,LicenseNumber,LicenseState,LicenseType,Licenseexpire,EmploymentDate,TerminationDate,Picture,DriverType,PhysicalExpire,BadgeType,BadgeExpire,BadgePendStat,status,AddedBy,DateAdded,ChangedBy,DateChanged,ChangedPrev,DateChangedPrev,ChangedOld,DateChangedOld,DeletedBy,dateDeleted")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverType = new SelectList(db.DriverTypes, "ID", "Description", driver.DriverType);
            ViewBag.LicenseType = new SelectList(db.licensetypes, "ID", "Description", driver.LicenseType);
            ViewBag.Location = new SelectList(db.Locations, "ID", "VFPLocationid", driver.Location);
            ViewBag.State = new SelectList(db.states, "id", "name", driver.State);
            ViewBag.CoTerminal = new SelectList(db.Terminals, "ID", "Name", driver.CoTerminal);
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = db.Drivers.Find(id);
            db.Drivers.Remove(driver);
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
    }
}
