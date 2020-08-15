using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerGarage.Models;

namespace GerGarage.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesListController : Controller
    {
        
        private GerGarageDbEntities db = new GerGarageDbEntities();

        // GET: EmployeesList
        
        public ActionResult Index()
        {
            return View(db.EmployeeRegistries.ToList());
        }

        // GET: EmployeesList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegistry employeeRegistry = db.EmployeeRegistries.Find(id);
            if (employeeRegistry == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegistry);
        }

        // GET: EmployeesList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesList/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeFirstName,EmployeeLastName,EmployeeContact,EmployeeEmailId,EmployeePassword")] EmployeeRegistry employeeRegistry)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRegistries.Add(employeeRegistry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeRegistry);
        }

        // GET: EmployeesList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegistry employeeRegistry = db.EmployeeRegistries.Find(id);
            if (employeeRegistry == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegistry);
        }

        // POST: EmployeesList/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeFirstName,EmployeeLastName,EmployeeContact,EmployeeEmailId,EmployeePassword")] EmployeeRegistry employeeRegistry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRegistry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRegistry);
        }

        // GET: EmployeesList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegistry employeeRegistry = db.EmployeeRegistries.Find(id);
            if (employeeRegistry == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegistry);
        }

        // POST: EmployeesList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRegistry employeeRegistry = db.EmployeeRegistries.Find(id);
            db.EmployeeRegistries.Remove(employeeRegistry);
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
